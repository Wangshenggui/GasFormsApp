using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasFormsApp
{
    public partial class ActicateKey : Form
    {
        public ActicateKey()
        {
            InitializeComponent();
        }

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
        private void ActicateKey_Load(object sender, EventArgs e)
        {
            string combinedInfo = GetWindowsBuild() + GetWindowsInstallDate() + GetSystemUUID();
            //MessageBox.Show($"设备ID：{combinedInfo}");
            //string combinedInfo = cpuId + diskSerial + macAddress + motherboardId;

            //MessageBox.Show($"设备ID：{combinedInfo}");

            // 生成哈希
            byte[] bytes = Encoding.UTF8.GetBytes(combinedInfo);

            //MessageBox.Show($"哈希值：{BitConverter.ToString(bytes).Replace("-", "")}");

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

                UniqueIDInput.Text = formatted;
                Console.WriteLine("激活码: " + formatted);
            }




            //UniqueIDInput.Text = GasFormsApp.Settings.Default.MachineCode;
        }


        public string KeyData { get; set; }

        private void ActivationButton_Click(object sender, EventArgs e)
        {
            KeyData = ActivationCodeInput.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // 明确返回取消
            this.Close();
        }
    }
}
