namespace GasFormsApp
{
    partial class ActicateKey
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
            this.CloseButton = new AntdUI.Button();
            this.ActivationButton = new AntdUI.Button();
            this.ActivationCodeInput = new AntdUI.Input();
            this.UniqueIDInput = new AntdUI.Input();
            this.label1 = new AntdUI.Label();
            this.label2 = new AntdUI.Label();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(189)))), ((int)(((byte)(193)))));
            this.CloseButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CloseButton.Location = new System.Drawing.Point(195, 163);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(171, 44);
            this.CloseButton.TabIndex = 33;
            this.CloseButton.Text = "取消";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ActivationButton
            // 
            this.ActivationButton.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(117)))), ((int)(((byte)(197)))));
            this.ActivationButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ActivationButton.Location = new System.Drawing.Point(18, 163);
            this.ActivationButton.Name = "ActivationButton";
            this.ActivationButton.Size = new System.Drawing.Size(171, 44);
            this.ActivationButton.TabIndex = 32;
            this.ActivationButton.Text = "注册";
            this.ActivationButton.Click += new System.EventHandler(this.ActivationButton_Click);
            // 
            // ActivationCodeInput
            // 
            this.ActivationCodeInput.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ActivationCodeInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ActivationCodeInput.Location = new System.Drawing.Point(18, 113);
            this.ActivationCodeInput.Name = "ActivationCodeInput";
            this.ActivationCodeInput.PlaceholderText = "激活码";
            this.ActivationCodeInput.Size = new System.Drawing.Size(348, 40);
            this.ActivationCodeInput.TabIndex = 31;
            // 
            // UniqueIDInput
            // 
            this.UniqueIDInput.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UniqueIDInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UniqueIDInput.Location = new System.Drawing.Point(18, 67);
            this.UniqueIDInput.Name = "UniqueIDInput";
            this.UniqueIDInput.PlaceholderText = "Unique ID";
            this.UniqueIDInput.Size = new System.Drawing.Size(348, 40);
            this.UniqueIDInput.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 23);
            this.label1.TabIndex = 34;
            this.label1.Text = "Unique ID:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(72, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 25);
            this.label2.TabIndex = 35;
            this.label2.Text = "产品密钥认证";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActicateKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(383, 223);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ActivationButton);
            this.Controls.Add(this.ActivationCodeInput);
            this.Controls.Add(this.UniqueIDInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActicateKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "软件激活";
            this.Load += new System.EventHandler(this.ActicateKey_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Button CloseButton;
        private AntdUI.Button ActivationButton;
        private AntdUI.Input ActivationCodeInput;
        private AntdUI.Input UniqueIDInput;
        private AntdUI.Label label1;
        private AntdUI.Label label2;
    }
}