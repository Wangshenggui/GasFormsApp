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
        private string dbFile;
        private string currentUsername;
        public ChangePasswordForm(string dbPath, string username)
        {
            InitializeComponent();

            dbFile = dbPath;
            currentUsername = username;
        }

        private void btnUpdatePwd_Click(object sender, EventArgs e)
        {
            string oldPwd = txtOldPwd.Text.Trim();
            string newPwd = txtNewPwd.Text.Trim();
            string confirmPwd = txtConfirmPwd.Text.Trim();

            if (string.IsNullOrEmpty(oldPwd) || string.IsNullOrEmpty(newPwd) || string.IsNullOrEmpty(confirmPwd))
            {
                MessageBox.Show("请填写所有字段！");
                return;
            }

            if (newPwd != confirmPwd)
            {
                MessageBox.Show("新密码和确认密码不一致！");
                return;
            }

            try
            {
                using (var conn = new SQLiteConnection($"Data Source={dbFile};Version=3;"))
                {
                    conn.Open();

                    // 查询当前密码
                    string query = "SELECT password FROM users WHERE username = @username;";
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", currentUsername);
                    var result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("用户不存在！");
                        return;
                    }

                    string storedHash = result.ToString();
                    string oldPwdHash = ComputeSha256Hash(oldPwd);

                    if (storedHash != oldPwdHash)
                    {
                        MessageBox.Show("原密码错误！");
                        return;
                    }

                    // 更新为新密码
                    string newPwdHash = ComputeSha256Hash(newPwd);
                    string update = "UPDATE users SET password = @pwd WHERE username = @username;";
                    cmd = new SQLiteCommand(update, conn);
                    cmd.Parameters.AddWithValue("@pwd", newPwdHash);
                    cmd.Parameters.AddWithValue("@username", currentUsername);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("密码修改成功！");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败：" + ex.Message);
            }
        }

        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
