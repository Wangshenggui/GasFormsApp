namespace GasFormsApp
{
    partial class ChangePasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.txtNewUsername = new AntdUI.Input();
            this.txtOldPwd = new AntdUI.Input();
            this.txtNewPwd = new AntdUI.Input();
            this.txtConfirmPwd = new AntdUI.Input();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdatePwd = new AntdUI.Button();
            this.SuspendLayout();
            // 
            // txtNewUsername
            // 
            this.txtNewUsername.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtNewUsername.Location = new System.Drawing.Point(137, 67);
            this.txtNewUsername.Name = "txtNewUsername";
            this.txtNewUsername.PlaceholderText = "新建用户名";
            this.txtNewUsername.Size = new System.Drawing.Size(180, 35);
            this.txtNewUsername.TabIndex = 2;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtOldPwd.Location = new System.Drawing.Point(137, 17);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.PlaceholderText = "旧密码";
            this.txtOldPwd.Size = new System.Drawing.Size(180, 35);
            this.txtOldPwd.TabIndex = 1;
            this.txtOldPwd.UseSystemPasswordChar = true;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtNewPwd.Location = new System.Drawing.Point(137, 113);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.PlaceholderText = "新密码";
            this.txtNewPwd.Size = new System.Drawing.Size(180, 35);
            this.txtNewPwd.TabIndex = 3;
            this.txtNewPwd.UseSystemPasswordChar = true;
            // 
            // txtConfirmPwd
            // 
            this.txtConfirmPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConfirmPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtConfirmPwd.Location = new System.Drawing.Point(137, 149);
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.PasswordChar = '*';
            this.txtConfirmPwd.PlaceholderText = "验证密码";
            this.txtConfirmPwd.Size = new System.Drawing.Size(180, 35);
            this.txtConfirmPwd.TabIndex = 4;
            this.txtConfirmPwd.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(50, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "新建用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(81, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "旧密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(81, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "新密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(66, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "验证密码：";
            // 
            // btnUpdatePwd
            // 
            this.btnUpdatePwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdatePwd.Location = new System.Drawing.Point(141, 210);
            this.btnUpdatePwd.Name = "btnUpdatePwd";
            this.btnUpdatePwd.Size = new System.Drawing.Size(102, 39);
            this.btnUpdatePwd.TabIndex = 30;
            this.btnUpdatePwd.Text = "保存";
            this.btnUpdatePwd.Click += new System.EventHandler(this.btnUpdatePwd_Click);
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.btnUpdatePwd);
            this.Controls.Add(this.txtConfirmPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.txtNewUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.Text = "修改登录信息";
            this.Load += new System.EventHandler(this.ChangePasswordForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangePasswordForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AntdUI.Input txtNewUsername;
        private AntdUI.Input txtOldPwd;
        private AntdUI.Input txtNewPwd;
        private AntdUI.Input txtConfirmPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private AntdUI.Button btnUpdatePwd;
    }
}