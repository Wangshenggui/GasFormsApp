namespace GasFormsApp
{
    partial class ProjectGroupsForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点2", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建矿井名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建项目名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DetermineButton = new GasFormsApp.UI.UCButton();
            this.CancelButton = new GasFormsApp.UI.UCButton();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.treeView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点1";
            treeNode1.Text = "节点1";
            treeNode2.Name = "节点0";
            treeNode2.Text = "节点0";
            treeNode3.Name = "节点3";
            treeNode3.Text = "节点3";
            treeNode4.Name = "节点2";
            treeNode4.Text = "节点2";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(604, 552);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建矿井名称ToolStripMenuItem,
            this.新建项目名称ToolStripMenuItem,
            this.重命名ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 新建矿井名称ToolStripMenuItem
            // 
            this.新建矿井名称ToolStripMenuItem.Name = "新建矿井名称ToolStripMenuItem";
            this.新建矿井名称ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.新建矿井名称ToolStripMenuItem.Text = "新建矿井名称";
            this.新建矿井名称ToolStripMenuItem.Click += new System.EventHandler(this.新建矿井名称ToolStripMenuItem_Click);
            // 
            // 新建项目名称ToolStripMenuItem
            // 
            this.新建项目名称ToolStripMenuItem.Name = "新建项目名称ToolStripMenuItem";
            this.新建项目名称ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.新建项目名称ToolStripMenuItem.Text = "新建项目名称";
            this.新建项目名称ToolStripMenuItem.Click += new System.EventHandler(this.新建项目名称ToolStripMenuItem_Click);
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.DetermineButton);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Location = new System.Drawing.Point(133, 481);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 59);
            this.panel1.TabIndex = 4;
            // 
            // DetermineButton
            // 
            this.DetermineButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DetermineButton.ButtonImage = null;
            this.DetermineButton.FlatAppearance.BorderSize = 0;
            this.DetermineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DetermineButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DetermineButton.HoverColor = System.Drawing.Color.LightBlue;
            this.DetermineButton.Location = new System.Drawing.Point(0, 12);
            this.DetermineButton.Name = "DetermineButton";
            this.DetermineButton.PressedColor = System.Drawing.Color.Silver;
            this.DetermineButton.Radius = 15;
            this.DetermineButton.Size = new System.Drawing.Size(105, 41);
            this.DetermineButton.TabIndex = 2;
            this.DetermineButton.Text = "确定";
            this.DetermineButton.UseVisualStyleBackColor = true;
            this.DetermineButton.Click += new System.EventHandler(this.DetermineButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CancelButton.ButtonImage = null;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CancelButton.HoverColor = System.Drawing.Color.LightBlue;
            this.CancelButton.Location = new System.Drawing.Point(239, 12);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.PressedColor = System.Drawing.Color.Silver;
            this.CancelButton.Radius = 15;
            this.CancelButton.Size = new System.Drawing.Size(105, 41);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "取消";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ProjectGroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 552);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.Name = "ProjectGroupsForm";
            this.Text = "项目归类";
            this.Load += new System.EventHandler(this.ProjectGroupsForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建矿井名称ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建项目名称ToolStripMenuItem;
        public System.Windows.Forms.TreeView treeView1;
        private UI.UCButton DetermineButton;
        private UI.UCButton CancelButton;
        private System.Windows.Forms.Panel panel1;
    }
}