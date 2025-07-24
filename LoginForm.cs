// 所需命名空间
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography; // 加密库
using System.Net.Http;              // 网络请求
using System.Net.Sockets;           // Socket通信
using System.Net;                   // 网络类
using System.Management;           // 获取硬件信息
using System.IO;                   // 文件操作
using CredentialManagement;

namespace GasFormsApp
{
    public partial class LoginForm : Form
    {
        int version = -1;  // -1表示验证失败
        // 获取主板+CPU序列号（组合唯一识别码）
        public static string GetMotherboardAndCpuId()
        {
            string motherboardSN = GetMotherboardSerialNumber();
            string cpuId = GetCpuId();
            return $"{motherboardSN}-{cpuId}";
        }

        // 获取主板序列号
        public static string GetMotherboardSerialNumber()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                        return obj["SerialNumber"]?.ToString().Trim() ?? "UNKNOWN";
                }
            }
            catch { }
            return "UNKNOWN";
        }

        // 获取 CPU ID
        public static string GetCpuId()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                        return obj["ProcessorId"]?.ToString().Trim() ?? "UNKNOWN";
                }
            }
            catch { }
            return "UNKNOWN";
        }

        // 使用 RSA 公钥验证签名合法性
        public static bool VerifyData(string data, byte[] signature, string publicKeyXml)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKeyXml);
                return rsa.VerifyData(dataBytes, CryptoConfig.MapNameToOID("SHA256"), signature);
            }
        }

        // 构造函数：执行注册校验逻辑
        public LoginForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint, true);
            this.UpdateStyles();

            string data = GetMotherboardAndCpuId();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "RegistrationCode.dat");

            //if (!File.Exists(path))
            //{
            //    // 如果注册文件不存在，则创建并提示注册
            //    File.WriteAllText(path, data, Encoding.UTF8);
            //    MessageBox.Show($"未找到注册文件，请先注册使用该软件。{data}", "限制登录", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    this.Close();
            //    return;
            //}

            //try
            //{
            //    // 读取注册文件中的签名
            //    string readBase64 = File.ReadAllText(path);
            //    byte[] signature = Convert.FromBase64String(readBase64);

            //    // 公钥（硬编码）
            //    string publicKey1 = "<RSAKeyValue><Modulus>8r/dKXr83gjs4TfRl+UzqDjOyMnY0rgj94uqXkwWeOMKYBMOJFzB24/N/V0pLVcld4IiSvHsvXghMDlGXGNT5sp9pg+wKPjEKWAcHeGUOgSLwb2PIkiM7933B6AUQbhRz8veEuKr5AYmZOYuB8BFRKAcdtJcubr0MCW7xgvcT6bdpKYqvKKwM3mQ1WKBBY17us5twGTlI+vIcr+U6lB9SuJhLtP7bJ7ASjq3qz54L9+V4ykGUfllU0+ynlp4V+oTNlUS4a7Jq4psR0C6kd2L+qw9OBJwKFTZl9WP/KlQrm/LQgJX+zOlWfWfqZYlJ/7EjNRz6++SikJVY3/PdneIgQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            //    string publicKey2 = "<RSAKeyValue><Modulus>wfhq2txWrvedzpMQtejut0amzU/x/NskwyvnIFMT90jJ7HZmfFaFI91H0elo5jw33U/HOp/T4sdz8z/qag0RkQf1uyhXkjLTVcI+DIrGQvwfwZE1DH/XGBjvQ09DiJhYPIauhUwg4QzGUn9HPmsMBDAphRTvsySWGiIG8w0kr/9Cy7KOunBaL14sgAUaF2w068m9SXpH3JHXMLgIUFauo/xEAsHA4MxKHQbe6M+V3cA/Qja3x/AItsuVfwTJasm7Pjy14T0k0IVN4K4+drblcOvZ6VC2YlPFYLMwDoY4SuEv6h7gOHmLJC9FynM6GG4ht/2kj0xW7e7d2YXLDUwCAQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            //    string publicKey3 = "<RSAKeyValue><Modulus>u9AnxyAWTl61i4BhNfIB5wr4oC5PLmzrQjMZhnzPr8QKeZ+HY56PIoNH6qm9MksypCLyVAqp5Vd0Qp7y+fcOFw+j05V0wX+GpSXdG+w+FiH/AH5arV0FQRdPuUY3gWeEc8rvculWtQwqywLQtUXNbyaB1oxW0O0bn05kZnWhIr29zGV1jdZFT90dlOUeLVv4EucAqCjZUPJ5aHzYx7QKQd7JOvFC6oCbwvyN9fYloxpEQHRuc+EdkE7o3kuajNKAmFavmbOkr4qnwe2OSwteyCy7xPg21utkZtvWgcRWUhM6QTQJh11nE5kvk5cxL4j6maLPv2Mnjfrg62s3cBgNHQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
                
            //    if (VerifyData(data, signature, publicKey1))
            //    {
            //        version = 0; // 第一个公钥通过
            //    }
            //    else if (VerifyData(data, signature, publicKey2))
            //    {
            //        version = 1; // 第二个公钥通过
            //    }
            //    else if (VerifyData(data, signature, publicKey3))
            //    {
            //        version = 2; // 第三个公钥通过
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // 读取失败异常处理
            //    File.WriteAllText(path, data, Encoding.UTF8);
            //    MessageBox.Show($"读取注册文件出错，请重新注册。{data}\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //    return;
            //}


            // 启动检测是否存在，不存在则创建默认密码
            var existingCredential = CredentialHelper.LoadCredential();
            if (existingCredential == null)
            {
                // 凭据不存在，跳转到修改密码界面
                // 默认密码
                var username = "Admin";
                var password = "12345";
                if (CredentialHelper.SaveCredential(username, password))
                {

                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            }

            // 启动时显示用户名，只需要输入密码即可
            var credential = CredentialHelper.LoadCredential();
            if (credential != null)
            {
                txtName.Text = credential.Value.username;
            }

            // 模拟已登录
            MainForm main = new MainForm(false);
            main.Version = version;
            this.Hide();          // 可选：如果想等 main 关掉后再关闭登录窗体
            main.ShowDialog();
            this.Close();         // 当 main 关闭后，关闭登录窗体
        }


        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // 计算哈希字节数组
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // 转换成十六进制字符串
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // 登录按钮点击事件
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var credential = CredentialHelper.LoadCredential();
            if (credential != null)
            {
                //txtName.Text = credential.Value.username;
                //txtPwd.Text = credential.Value.password;
                //MessageBox.Show("加载成功！");
                //Console.WriteLine($"用户名：{txtName.Text}");
                if (credential.Value.username.Equals(txtName.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    if (credential.Value.password.Equals(txtPwd.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        if (version == -1)
                        {
                            MessageBox.Show("验证失败，注册信息无效！");
                            this.Close();
                            return;
                        }
                        else
                        {
                            MainForm main = new MainForm(false);
                            main.Version = version;
                            this.Hide();          // 可选：如果想等 main 关掉后再关闭登录窗体
                            main.ShowDialog();
                            this.Close();         // 当 main 关闭后，关闭登录窗体
                        }
                    }
                    else
                    {
                        MessageBox.Show("账号或密码错误！");
                    }
                }
                else
                {
                    MessageBox.Show("账号或密码错误！");
                }
            }
            else
            {
                MessageBox.Show("没有找到账户！");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 模拟点击按钮
                btnLogin.PerformClick();

                // 或直接调用你想执行的方法：
                // SavePassword();

                // 防止系统“叮”一声
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 模拟点击按钮
                btnLogin.PerformClick();

                // 或直接调用你想执行的方法：
                // SavePassword();

                // 防止系统“叮”一声
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }


    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public static class CredentialHelper
    {
        private const string Target = "GasFormsApp"; // 给凭据起个唯一的名字

        public static bool SaveCredential(string username, string password)
        {
            using (var cred = new Credential())
            {
                cred.Password = password;
                cred.Username = username;
                cred.Target = Target;
                cred.Type = CredentialType.Generic;
                cred.PersistanceType = PersistanceType.LocalComputer;
                return cred.Save();
            }
        }

        public static (string username, string password)? LoadCredential()
        {
            using (var cred = new Credential { Target = Target })
            {
                if (cred.Load())
                {
                    return (cred.Username, cred.Password);
                }
                else
                {
                    return null;
                }
            }
        }

        public static bool DeleteCredential()
        {
            using (var cred = new Credential { Target = Target })
            {
                return cred.Delete();
            }
        }
    }
}
