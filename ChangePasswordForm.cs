using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GasFormsApp
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btnUpdatePwd_Click(object sender, EventArgs e)
        {
            var credential = CredentialHelper.LoadCredential();

            if (credential == null)
            {
                MessageBox.Show("没有找到凭据！");
                return;
            }

            // 验证原密码
            if (!credential.Value.password.Equals(txtOldPwd.Text.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("原密码错误！");
                return;
            }

            // 验证新用户名
            if (string.IsNullOrWhiteSpace(txtNewUsername.Text))
            {
                MessageBox.Show("用户名不能为空或只包含空格！");
                return;
            }

            string newPwd = txtNewPwd.Text.Trim();
            string confirmPwd = txtConfirmPwd.Text.Trim();

            // 验证新密码和确认密码
            if (string.IsNullOrWhiteSpace(newPwd) || string.IsNullOrWhiteSpace(confirmPwd))
            {
                MessageBox.Show("新密码和确认密码都不能为空！");
                return;
            }

            if (!newPwd.Equals(confirmPwd))
            {
                MessageBox.Show("新密码和确认密码不一致！");
                return;
            }

            // 保存凭据
            bool saved = CredentialHelper.SaveCredential(txtNewUsername.Text, confirmPwd);
            if (saved)
            {
                MessageBox.Show("保存成功！");
                this.Close(); // 保存成功后关闭窗口（可选）
            }
            else
            {
                MessageBox.Show("保存失败！");
            }
        }


        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void ChangePasswordForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 模拟点击按钮
                btnUpdatePwd.PerformClick();

                // 或直接调用你想执行的方法：
                // SavePassword();

                // 防止系统“叮”一声
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
