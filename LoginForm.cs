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

namespace GasFormsApp
{
    public partial class LoginForm : Form
    {
        private const string RegistryKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\SysConfigData";
        private const string FailedLoginValueName = "FailedLoginCount";
        private const int MaxFailedAttempts = 3;

        public LoginForm()
        {
            InitializeComponent();

            //MainForm main = new MainForm(false);
            //this.Hide();

            //main.ShowDialog();

            //this.Close();  // 关闭 LoginForm
        }
        private int GetFailedLoginCount()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, false))
            {
                if (key == null)
                {
                    //MessageBox.Show("注册表路径不存在");
                    SetFailedLoginCount(0);
                    return 0;
                }
                object val = key.GetValue(FailedLoginValueName);
                if (val == null)
                {
                    //MessageBox.Show("注册表值不存在");
                    return 0;
                }
                if (int.TryParse(val.ToString(), out int count))
                {
                    //MessageBox.Show($"读取失败次数：{count}");
                    return count;
                }
                else
                {
                    //MessageBox.Show("注册表值格式错误");
                    return 0;
                }
            }
        }

        private void SetFailedLoginCount(int count)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
            {
                key.SetValue(FailedLoginValueName, count, RegistryValueKind.DWord);
                //MessageBox.Show($"写入失败次数：{count}");
            }
        }


        private void ResetFailedLoginCount()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
            {
                if (key != null)
                {
                    key.DeleteValue(FailedLoginValueName, false);
                }
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            int failedCount = GetFailedLoginCount();

            if (failedCount >= MaxFailedAttempts)
            {
                MessageBox.Show($"登录次数已达最大限制（{MaxFailedAttempts}次），请联系开发者。", "限制登录", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            failedCount++;
            SetFailedLoginCount(failedCount);

            if (txtName.Text.Trim().Equals("admin") && txtPwd.Text.Trim().Equals("1234"))
            {
                //ResetFailedLoginCount();  // 登录成功，清除失败计数

                MainForm main = new MainForm(false);
                this.Hide();

                main.ShowDialog();

                this.Close();
            }
            else
            {
                //failedCount++;
                //SetFailedLoginCount(failedCount);

                //if (failedCount >= MaxFailedAttempts)
                //{
                //    MessageBox.Show($"账号/密码错误！登录失败次数已达最大限制（{MaxFailedAttempts}次），请稍后再试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{
                //    MessageBox.Show($"账号/密码错误！您还有{MaxFailedAttempts - failedCount}次尝试机会。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
        }
    }
}
