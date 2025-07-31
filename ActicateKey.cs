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

        //        1.1 硬件相关的唯一标识
        //CPU序列号：部分CPU有唯一序列号，可作为识别依据。

        //硬盘序列号：硬盘的物理序列号，比较稳定。

        //MAC地址：网络适配器的MAC地址，唯一且硬件绑定。

        //主板序列号：主板硬件的唯一标识。

        //组合硬件指纹：结合多个硬件参数生成一个“硬件指纹”，提升唯一性和稳定性。


        private void ActicateKey_Load(object sender, EventArgs e)
        {
            string cpuId = GetCpuId();
            string diskSerial = GetDiskSerialNumber();
            string macAddress = GetMacAddress();
            string motherboardId = GetMotherboardId();

            string combinedInfo = cpuId + diskSerial + macAddress + motherboardId;

            //MessageBox.Show($"设备ID：{combinedInfo}");

            // 生成哈希
            byte[] bytes = Encoding.UTF8.GetBytes(combinedInfo);
            //using (SHA256 sha256 = SHA256.Create())
            //{
            //    byte[] hashBytes = sha256.ComputeHash(bytes);
            //    string base64Hash = Convert.ToBase64String(hashBytes);

            //    Console.WriteLine("硬件组合信息: " + combinedInfo);
            //    Console.WriteLine("Base64 哈希结果: " + base64Hash);

            //    //GasFormsApp.Settings.Default.MachineCode = base64Hash;
            //    //GasFormsApp.Settings.Default.Save();

            //    UniqueIDInput.Text = base64Hash;
            //}
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

        private string GetCpuId()
        {
            try
            {
                using (ManagementClass mc = new ManagementClass("Win32_Processor"))
                {
                    foreach (ManagementObject mo in mc.GetInstances())
                    {
                        return mo["ProcessorId"] != null ? mo["ProcessorId"].ToString() : "";
                    }
                }
            }
            catch { }
            return "";
        }

        private string GetDiskSerialNumber()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_PhysicalMedia"))
                {
                    foreach (ManagementObject mo in searcher.Get())
                    {
                        if (mo["SerialNumber"] != null)
                        {
                            string serial = mo["SerialNumber"].ToString();
                            if (!string.IsNullOrWhiteSpace(serial))
                                return serial.Trim();
                        }
                    }
                }
            }
            catch { }
            return "";
        }

        private string GetMacAddress()
        {
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface nic in nics)
                {
                    if (nic.NetworkInterfaceType != NetworkInterfaceType.Loopback && nic.OperationalStatus == OperationalStatus.Up)
                    {
                        return nic.GetPhysicalAddress().ToString();
                    }
                }
            }
            catch { }
            return "";
        }

        private string GetMotherboardId()
        {
            try
            {
                using (ManagementClass mc = new ManagementClass("Win32_BaseBoard"))
                {
                    foreach (ManagementObject mo in mc.GetInstances())
                    {
                        return mo["SerialNumber"] != null ? mo["SerialNumber"].ToString() : "";
                    }
                }
            }
            catch { }
            return "";
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
