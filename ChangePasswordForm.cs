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
            if (credential != null)
            {
                // 判断密码
                if (credential.Value.password.Equals(txtOldPwd.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {

                }
                else
                {
                    MessageBox.Show("原密码错误！");
                }
            }
            else
            {
                MessageBox.Show("没有找到凭据！");
            }


            //var existingCredential = CredentialHelper.LoadCredential();
            //if (existingCredential == null)
            //{
            //    var username = "Admi";
            //    var password = "1234";
            //    if (CredentialHelper.SaveCredential(username, password))
            //    {
            //        MessageBox.Show("保存成功！");
            //    }
            //    else
            //    {
            //        MessageBox.Show("保存失败！");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("凭据已经存在，不能重复保存！");
            //}
        }
    }
}
