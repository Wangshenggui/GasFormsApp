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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            MainForm main = new MainForm(false);
            this.Hide();

            main.ShowDialog();

            this.Close();  // 关闭 LoginForm
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Equals("admin") && txtPwd.Text.Trim().Equals("1234"))
            {
                //MainForm main = new MainForm(false);
                MainForm main = new MainForm(false);
                this.Hide();

                main.ShowDialog();

                this.Close();  // 关闭 LoginForm
            }
            else
            {
                MessageBox.Show("账号/密码错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(null, null);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
