using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void ActicateKey_Load(object sender, EventArgs e)
        {
            // 生成 UUID
            Guid newGuid = Guid.NewGuid();
            // 转成字节数组
            byte[] guidBytes = newGuid.ToByteArray();
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(guidBytes);

                // 4. 将哈希结果编码成 Base64
                string base64Hash = Convert.ToBase64String(hashBytes);

                Console.WriteLine("原始 Guid:       " + newGuid);
                Console.WriteLine("Base64 哈希结果: " + base64Hash);

                GasFormsApp.Settings.Default.MachineCode = base64Hash;
                GasFormsApp.Settings.Default.Save();
            }
            UniqueIDInput.Text = GasFormsApp.Settings.Default.MachineCode;
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
