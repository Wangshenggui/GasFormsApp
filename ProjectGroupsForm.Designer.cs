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
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("项目");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("矿井", new System.Windows.Forms.TreeNode[] {
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("根目录", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("节点2", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectGroupsForm));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建矿井名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建项目名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CancelButton = new AntdUI.Button();
            this.DetermineButton = new AntdUI.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.FindMineTextBox = new AntdUI.Input();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(85)))), ((int)(((byte)(128)))));
            this.treeView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 34);
            this.treeView1.Name = "treeView1";
            treeNode6.ImageKey = "项目";
            treeNode6.Name = "项目";
            treeNode6.Text = "项目";
            treeNode7.ImageKey = "矿井";
            treeNode7.Name = "矿井";
            treeNode7.Text = "矿井";
            treeNode8.ImageKey = "根目录";
            treeNode8.Name = "根目录";
            treeNode8.Text = "根目录";
            treeNode9.Name = "节点3";
            treeNode9.Text = "节点3";
            treeNode10.Name = "节点2";
            treeNode10.Text = "节点2";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode10});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(784, 528);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "项目");
            this.imageList1.Images.SetKeyName(1, "根目录");
            this.imageList1.Images.SetKeyName(2, "矿井");
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
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(85)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.DetermineButton);
            this.panel1.Location = new System.Drawing.Point(223, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 59);
            this.panel1.TabIndex = 4;
            // 
            // CancelButton
            // 
            this.CancelButton.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(189)))), ((int)(((byte)(193)))));
            this.CancelButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CancelButton.Location = new System.Drawing.Point(221, 12);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(122, 41);
            this.CancelButton.TabIndex = 41;
            this.CancelButton.Text = "取消";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // DetermineButton
            // 
            this.DetermineButton.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(144)))), ((int)(((byte)(246)))));
            this.DetermineButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DetermineButton.Location = new System.Drawing.Point(1, 12);
            this.DetermineButton.Name = "DetermineButton";
            this.DetermineButton.Size = new System.Drawing.Size(122, 41);
            this.DetermineButton.TabIndex = 41;
            this.DetermineButton.Text = "确定";
            this.DetermineButton.Click += new System.EventHandler(this.DetermineButton_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label17.Location = new System.Drawing.Point(12, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 16);
            this.label17.TabIndex = 39;
            this.label17.Text = "查找矿井：";
            // 
            // FindMineTextBox
            // 
            this.FindMineTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FindMineTextBox.Location = new System.Drawing.Point(84, -1);
            this.FindMineTextBox.Name = "FindMineTextBox";
            this.FindMineTextBox.PlaceholderText = "输入查找内容";
            this.FindMineTextBox.Radius = 1;
            this.FindMineTextBox.Size = new System.Drawing.Size(260, 35);
            this.FindMineTextBox.TabIndex = 40;
            this.FindMineTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindMineTextBox_KeyDown);
            // 
            // ProjectGroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.FindMineTextBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectGroupsForm";
            this.Text = "项目归类";
            this.Load += new System.EventHandler(this.ProjectGroupsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProjectGroupsForm_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建矿井名称ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建项目名称ToolStripMenuItem;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Label label17;
        public AntdUI.Input FindMineTextBox;
        private AntdUI.Button DetermineButton;
        private AntdUI.Button CancelButton;
    }
}