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
using DialogResult = System.Windows.Forms.DialogResult;
using System.Security.Cryptography.X509Certificates;
using System.Net.NetworkInformation;

namespace GasFormsApp
{
    public partial class LoginForm : Form
    {
        int version = -1;  // -1表示验证失败

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
        // 定义三个公钥（最好提到类的静态字段或配置里）
        readonly string[] PublicKeys = new string[]
        {
            "<RSAKeyValue><Modulus>8r/dKXr83gjs4TfRl+UzqDjOyMnY0rgj94uqXkwWeOMKYBMOJFzB24/N/V0pLVcld4IiSvHsvXghMDlGXGNT5sp9pg+wKPjEKWAcHeGUOgSLwb2PIkiM7933B6AUQbhRz8veEuKr5AYmZOYuB8BFRKAcdtJcubr0MCW7xgvcT6bdpKYqvKKwM3mQ1WKBBY17us5twGTlI+vIcr+U6lB9SuJhLtP7bJ7ASjq3qz54L9+V4ykGUfllU0+ynlp4V+oTNlUS4a7Jq4psR0C6kd2L+qw9OBJwKFTZl9WP/KlQrm/LQgJX+zOlWfWfqZYlJ/7EjNRz6++SikJVY3/PdneIgQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>",
            "<RSAKeyValue><Modulus>wfhq2txWrvedzpMQtejut0amzU/x/NskwyvnIFMT90jJ7HZmfFaFI91H0elo5jw33U/HOp/T4sdz8z/qag0RkQf1uyhXkjLTVcI+DIrGQvwfwZE1DH/XGBjvQ09DiJhYPIauhUwg4QzGUn9HPmsMBDAphRTvsySWGiIG8w0kr/9Cy7KOunBaL14sgAUaF2w068m9SXpH3JHXMLgIUFauo/xEAsHA4MxKHQbe6M+V3cA/Qja3x/AItsuVfwTJasm7Pjy14T0k0IVN4K4+drblcOvZ6VC2YlPFYLMwDoY4SuEv6h7gOHmLJC9FynM6GG4ht/2kj0xW7e7d2YXLDUwCAQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>",
            "<RSAKeyValue><Modulus>u9AnxyAWTl61i4BhNfIB5wr4oC5PLmzrQjMZhnzPr8QKeZ+HY56PIoNH6qm9MksypCLyVAqp5Vd0Qp7y+fcOFw+j05V0wX+GpSXdG+w+FiH/AH5arV0FQRdPuUY3gWeEc8rvculWtQwqywLQtUXNbyaB1oxW0O0bn05kZnWhIr29zGV1jdZFT90dlOUeLVv4EucAqCjZUPJ5aHzYx7QKQd7JOvFC6oCbwvyN9fYloxpEQHRuc+EdkE7o3kuajNKAmFavmbOkr4qnwe2OSwteyCy7xPg21utkZtvWgcRWUhM6QTQJh11nE5kvk5cxL4j6maLPv2Mnjfrg62s3cBgNHQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
        };

        string GetWindowsInstallDate()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT InstallDate FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string installDateStr = obj["InstallDate"]?.ToString();
                        if (!string.IsNullOrEmpty(installDateStr))
                        {
                            // 格式：20221102113045.000000+480
                            DateTime installDate = ManagementDateTimeConverter.ToDateTime(installDateStr);
                            return installDate.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                    }
                }
            }
            catch { }
            return "UNKNOWN";
        }
        // 获取系统构建版本
        public static string GetWindowsBuild()
        {
            try
            {
                using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    return key?.GetValue("CurrentBuild")?.ToString() ?? "Unknown";
                }
            }
            catch { }
            return "Unknown";
        }
        public static string GetSystemUUID()
        {
            try
            {
                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProduct");
                foreach (var item in searcher.Get())
                {
                    return item["UUID"]?.ToString();
                }
                return "Unknown";
            }
            catch
            {
                return "Unknown";
            }
        }
        private void CheckActivation()
        {
            string combinedInfo = GetWindowsBuild() + GetWindowsInstallDate() + GetSystemUUID();
            //MessageBox.Show($"设备ID：{combinedInfo}");


            var code = "";
            // 生成哈希
            byte[] bytes = Encoding.UTF8.GetBytes(combinedInfo);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 5; i++) // 取前5字节，每个字节2位，共10位
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                // raw: e.g., "1A2B3C4D5E"
                string raw = sb.ToString().ToUpper();

                // 格式化：XXXXX-XXXXX
                string formatted = string.Format("{0}-{1}",
                    raw.Substring(0, 5),
                    raw.Substring(5, 5));

                code = formatted;
                Console.WriteLine("激活码: " + formatted);
            }


            //var code = GasFormsApp.Settings.Default.MachineCode;
            byte[] signature = null;

            if (string.IsNullOrEmpty(code))
            {
                // 没有 MachineCode，直接弹窗注册
                if (!PromptForActivation(out signature))
                {
                    this.Close();
                    return;
                }
            }
            else
            {
                // 有 MachineCode，先尝试验证当前激活码
                try
                {
                    signature = Convert.FromBase64String(GasFormsApp.Settings.Default.ActivateKey);
                }
                catch
                {
                    signature = null;
                }

                version = -1;
                if (signature != null)
                {
                    version = VerifyAndGetVersion(code, signature);
                }

                if (version == -1)
                {
                    // 当前激活码不对，再提示用户输入新的激活码
                    if (!PromptForActivation(out signature))
                    {
                        this.Close();
                        return;
                    }
                }
            }

            // 最后再验证一遍新输入的激活码（或原始的）
            version = VerifyAndGetVersion(code, signature);
            if (version == -1)
            {
                MessageBox.Show("激活码无效！");
                this.Close();
                return;
            }

            // 验证成功，可根据 version 做不同处理
            // version = 0, 1, 2 ...
        }
        // 弹窗让用户输入激活码，并保存
        private bool PromptForActivation(out byte[] signature)
        {
            signature = null;
            ActicateKey aKey = new ActicateKey();
            aKey.KeyData = null;
            DialogResult result = aKey.ShowDialog();

            if (result == DialogResult.OK)
            {
                string data = aKey.KeyData;
                try
                {
                    signature = Convert.FromBase64String(data);
                    GasFormsApp.Settings.Default.ActivateKey = data;
                    GasFormsApp.Settings.Default.Save();
                    return true;
                }
                catch
                {
                    MessageBox.Show("激活码格式错误！");
                    this.Close();
                    return false;
                }
            }

            return false;
        }


        // 验证签名，返回通过的版本号或 -1
        private int VerifyAndGetVersion(string machineCode, byte[] signature)
        {
            for (int i = 0; i < PublicKeys.Length; i++)
            {
                if (VerifyData(machineCode, signature, PublicKeys[i]))
                {
                    return i;
                }
            }
            return -1;
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

            CheckActivation();
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
            //MainForm main = new MainForm(false);
            //main.Version = version;
            //this.Hide();          // 可选：如果想等 main 关掉后再关闭登录窗体
            //main.ShowDialog();
            //this.Close();         // 当 main 关闭后，关闭登录窗体
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
