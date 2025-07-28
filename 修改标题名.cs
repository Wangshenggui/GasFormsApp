using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasFormsApp
{
    public partial class 修改标题名 : Form
    {
        public 修改标题名()
        {
            InitializeComponent();
        }

        public string 标题名 { get; set; }
        private void 修改标题名_Load(object sender, EventArgs e)
        {

        }

        private void DetermineButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                MessageBox.Show("标题不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            标题名 = TitleTextBox.Text.Trim();
            this.DialogResult = DialogResult.OK; // 设置窗体的返回值
            this.Close(); // 关闭窗口
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            标题名 = "";
            this.DialogResult = DialogResult.Cancel; // 明确返回取消
            this.Close();
        }

        private void TitleTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
                {
                    MessageBox.Show("标题不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                标题名 = TitleTextBox.Text.Trim();
                this.DialogResult = DialogResult.OK; // 设置窗体的返回值
                this.Close(); // 关闭窗口
            }
        }
    }
}
