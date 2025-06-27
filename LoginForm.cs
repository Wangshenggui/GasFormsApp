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
using System.Data.SQLite;

namespace GasFormsApp
{
    public partial class LoginForm : Form
    {
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

            string data = GetMotherboardAndCpuId();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "RegistrationCode.dat");

            if (!File.Exists(path))
            {
                // 如果注册文件不存在，则创建并提示注册
                File.WriteAllText(path, data, Encoding.UTF8);
                MessageBox.Show($"未找到注册文件，请先注册使用该软件。{data}", "限制登录", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            try
            {
                // 读取注册文件中的签名
                string readBase64 = File.ReadAllText(path);
                byte[] signature = Convert.FromBase64String(readBase64);

                // 公钥（硬编码）
                string publicKey = "<RSAKeyValue><Modulus>zMU2qMkOog2AhpAnI39JawR8ag5+u/vuNck17MOvdJoJo0ttI8e4HGIwRf/+lL4eytmdC1l2c+lgX0WpZ0Ggeg8sXB2i68wVpkLXxAGDTDbFGMj7CCJ2DbI1PKUtpcueKeEhOK7H02S9Ru4ssnomvfbf9TGlpb8bj4Diu33Y8f9ennuWy47Pbism350gE0W7btQ0DWYv1zK6u33mBn6InncEJdvkm8teQbQTE4krPCMmV1JGUBMEMTYtRfYTO59EoK1PU8S4xeeYdeNgRodS9pr/QMGJlUD/O4rVngV+09Q23C9BOs/9gRbGCAtaIYJKdJRTuoI5BweONB4BgXD6VQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

                bool verified = VerifyData(data, signature, publicKey);

                if (!verified)
                {
                    // 如果验证失败，写入当前机器码，并提示重新注册
                    File.WriteAllText(path, data, Encoding.UTF8);
                    MessageBox.Show($"注册信息无效，请重新注册。{data}", "限制登录", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                // 读取失败异常处理
                File.WriteAllText(path, data, Encoding.UTF8);
                MessageBox.Show($"读取注册文件出错，请重新注册。{data}\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
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
            string folder = "SystemData";
            string dbFile = Path.Combine(folder, "Account_password.db");

            // 创建目录（如果不存在）
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            // 初始化数据库（如果不存在）
            if (!File.Exists(dbFile))
            {
                try
                {
                    SQLiteConnection.CreateFile(dbFile);

                    using (var conn = new SQLiteConnection($"Data Source={dbFile};Version=3;"))
                    {
                        conn.Open();

                        // 创建用户表，用户名唯一
                        string createTable = @"
                            CREATE TABLE users (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                username TEXT UNIQUE NOT NULL,
                                password TEXT NOT NULL
                            );";
                        var cmd = new SQLiteCommand(createTable, conn);
                        cmd.ExecuteNonQuery();

                        // 插入默认用户 admin / 1234
                        string defaultUser = "admin";
                        string defaultPwdHash = ComputeSha256Hash("1234");

                        string insertUser = "INSERT INTO users (username, password) VALUES (@username, @password);";
                        cmd = new SQLiteCommand(insertUser, conn);
                        cmd.Parameters.AddWithValue("@username", defaultUser);
                        cmd.Parameters.AddWithValue("@password", defaultPwdHash);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据库初始化失败：" + ex.Message);
                    return;
                }
            }

            // 获取用户输入
            string inputUser = txtName.Text.Trim();
            string inputPwd = txtPwd.Text.Trim();

            // 检查是否输入了用户名和密码
            if (string.IsNullOrEmpty(inputUser) || string.IsNullOrEmpty(inputPwd))
            {
                MessageBox.Show("请输入用户名和密码！");
                return;
            }

            string inputPwdHash = ComputeSha256Hash(inputPwd);

            try
            {
                using (var conn = new SQLiteConnection($"Data Source={dbFile};Version=3;"))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password;";
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", inputUser);
                    cmd.Parameters.AddWithValue("@password", inputPwdHash);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        // 登录成功
                        // 判断是否使用默认密码
                        
                        string defaultPwdHash = ComputeSha256Hash("1234");
                        if (inputPwdHash == defaultPwdHash)
                        {
                            DialogResult result = MessageBox.Show(
                                "当前使用的是默认密码，请及时修改密码以保障账户安全！\n是否立即修改密码？",
                                "安全提示",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Warning
                            );
                            if (result == DialogResult.OK)
                            {
                                // 用户点击“确定”，打开修改密码窗口
                                ChangePasswordForm changePwdForm = new ChangePasswordForm(dbFile, inputUser);
                                changePwdForm.ShowDialog();
                            }
                            else
                            {
                                // 用户点击“取消”
                            }
                        }


                        MainForm main = new MainForm(false);
                        this.Hide();
                        main.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录失败：" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
