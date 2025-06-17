using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Win32;  // 需要引用此命名空间

using System;
using System.Security.Cryptography;
using System.Text;
using System.Net.Http;
using System.Net.Sockets;
using System.Net;

namespace GasFormsApp
{
    public partial class LoginForm : Form
    {
        //private const string RegistryKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\SysConfigData";
        //private const string FailedLoginValueName = "FailedLoginCount";
        //private const int MaxFailedAttempts = 3;


        private static readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(5)
        };

        static async Task<bool> CheckInternetConnection()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://www.baidu.com");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        private async void LoginForm_Load(object sender, EventArgs e)
        {
            bool isOnline = await CheckInternetConnection();

            if (!isOnline)
            {
                MessageBox.Show("未检测到网络，程序无法登录。", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                Application.Exit();  // 确保程序彻底退出
                return;
            }
        }

        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;

            //MainForm main = new MainForm(false);
            //this.Hide();

            //main.ShowDialog();

            //this.Close();
        }

        //private int GetFailedLoginCount()
        //{
        //    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, false))
        //    {
        //        if (key == null)
        //        {
        //            SetFailedLoginCount(0);
        //            return 0;
        //        }
        //        object val = key.GetValue(FailedLoginValueName);
        //        if (val == null)
        //        {
        //            return 0;
        //        }
        //        if (int.TryParse(val.ToString(), out int count))
        //        {
        //            return count;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //}

        //private void SetFailedLoginCount(int count)
        //{
        //    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
        //    {
        //        key.SetValue(FailedLoginValueName, count, RegistryValueKind.DWord);
        //    }
        //}

        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                          ((x & 0x0000ff00) << 8) +
                          ((x & 0x00ff0000) >> 8) +
                          ((x & 0xff000000) >> 24));
        }
        public static Task<DateTime> GetNetworkTimeAsync()
        {
            return Task.Run(() =>
            {
                const string ntpServer = "pool.ntp.org";
                var ntpData = new byte[48];
                ntpData[0] = 0x1B;

                var addresses = Dns.GetHostEntry(ntpServer).AddressList;
                var ipEndPoint = new IPEndPoint(addresses[0], 123);

                using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    socket.Connect(ipEndPoint);
                    socket.Send(ntpData);
                    socket.Receive(ntpData);
                }

                const byte serverReplyTime = 40;
                ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);
                ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

                intPart = SwapEndianness(intPart);
                fractPart = SwapEndianness(fractPart);

                var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
                var networkDateTime = new DateTime(1900, 1, 1).AddMilliseconds((long)milliseconds);

                return networkDateTime.ToLocalTime();
            });
        }
        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Equals("admin"))
            {
                DateTime now = await GetNetworkTimeAsync();  // 异步调用，不阻塞UI

                int minute = now.Minute;
                int roundedMinute;

                if (minute < 15)
                    roundedMinute = 0;
                else if (minute < 30)
                    roundedMinute = 15;
                else if (minute < 45)
                    roundedMinute = 30;
                else
                    roundedMinute = 45;

                int hour = now.Hour;
                int year = now.Year;
                int month = now.Month;
                int day = now.Day;

                DateTime roundedTime = new DateTime(year, month, day, hour, roundedMinute, 0);

                //Console.WriteLine($"当前时间: {now}");
                //Console.WriteLine($"区间取整后的时间节点: {roundedTime}");

                string keySource = now.ToString("yyyyMMdd"); // 只精确到天
                string oddDigits = new string(keySource.Where(c => {
                    int digit = c - '0';
                    return digit % 2 == 1 || digit == 0;  // 只取奇数数字
                }).ToArray());
                string key = GenerateAes256KeyFromTime(keySource);

                Console.WriteLine("用于AES-256的密钥: " + key);

                string repeated2 = new string(key.Reverse().ToArray());
                Console.WriteLine("加密的明文: " + repeated2);
                string encrypted = EncryptECB(repeated2, key);

                Console.WriteLine("AES-256 ECB 加密结果: " + encrypted);

                // 1. Base64解码成字节数组
                byte[] bytes = Convert.FromBase64String(encrypted);
                // 2. 字节数组转16进制字符串
                string hexString = BitConverter.ToString(bytes).Replace("-", "");
                Console.WriteLine($"校验：{hexString}\r\n输入：{txtPwd.Text}");

                if (txtPwd.Text.Trim().Equals(hexString))
                {
                    MainForm main = new MainForm(false);
                    this.Hide();

                    main.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show($"密码已过期，请联系开发者。", "限制登录", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        static string GenerateAes256KeyFromTime(string timeString)
        {
            // 这里简单做法：重复拼接时间字符串，截取32字符
            StringBuilder sb = new StringBuilder();
            while (sb.Length < 32)
            {
                sb.Append(timeString);
            }
            return sb.ToString(0, 32);
        }
        static string EncryptECB(string plainText, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.Mode = CipherMode.ECB;   // 电子密码本模式
                aes.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
