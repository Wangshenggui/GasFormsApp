using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasFormsApp
{
    public partial class ProjectGroupsForm : Form
    {
        //public string SelectedNodeText { get; private set; }


        public ProjectGroupsForm()
        {
            InitializeComponent();
        }

        private void ProjectGroupsForm_Load(object sender, EventArgs e)
        {
            // 获取屏幕宽高并设置窗体大小为屏幕的54%
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            this.Width = (int)(screenWidth * 0.54);
            this.Height = (int)(screenHeight * 0.54);

            // 窗体居中显示
            this.Left = (screenWidth - this.Width) / 2;
            this.Top = (screenHeight - this.Height) / 2;

            // 获取程序启动目录
            string basePath = Application.StartupPath;

            // 构建目标文件夹路径：SystemData\DataAdministrationForm
            string rootPath = Path.Combine(basePath, "SystemData", "DataAdministrationForm");

            // 如果路径不存在则创建
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            // 加载目录到树控件
            LoadFoldersToTree(rootPath);
        }

        /// <summary>
        /// 将指定根目录及其子目录加载到 TreeView 控件中显示
        /// </summary>
        /// <param name="rootPath">根目录路径</param>
        private void LoadFoldersToTree(string rootPath)
        {
            DirectoryInfo rootDir = new DirectoryInfo(rootPath);

            // 如果目录不存在，则不进行加载
            if (!rootDir.Exists) return;

            // 清空树控件节点
            treeView1.Nodes.Clear();

            // 创建根节点，显示根目录名，Tag属性存储目录完整路径
            TreeNode rootNode = new TreeNode(rootDir.Name) { Tag = rootDir.FullName };

            // 添加根节点到树控件
            treeView1.Nodes.Add(rootNode);

            // 递归添加子目录节点
            AddSubDirectories(rootDir, rootNode);

            // 展开所有节点，方便查看
            treeView1.ExpandAll();
        }
        /// <summary>
        /// 递归添加指定目录的所有子目录到指定父节点下
        /// </summary>
        /// <param name="dir">当前目录</param>
        /// <param name="parentNode">父节点</param>
        private void AddSubDirectories(DirectoryInfo dir, TreeNode parentNode)
        {
            // 遍历当前目录所有子目录
            foreach (var subDir in dir.GetDirectories())
            {
                // 创建子节点，显示子目录名，Tag存储完整路径
                TreeNode childNode = new TreeNode(subDir.Name) { Tag = subDir.FullName };

                // 添加子节点到父节点
                parentNode.Nodes.Add(childNode);

                // 递归调用，添加更深层的子目录
                AddSubDirectories(subDir, childNode);
            }
        }
        /// <summary>
        /// 当树控件节点被选中时触发，加载该节点对应目录的文件到 DataGridView
        /// </summary>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            string selectedPath = selectedNode.Tag?.ToString();

            // 只对“叶子节点”处理（即没有子节点的节点）
            // 并且该节点对应的路径是有效目录
            if (selectedNode.Nodes.Count == 0 && Directory.Exists(selectedPath))
            {
                //// 加载该目录下的文件到表格显示
                //string str = FindTextBox.Text;
                //if (string.IsNullOrEmpty(str))
                //{
                //    全部显示(selectedPath);
                //}
                //else
                //{
                //    查询显示(selectedPath, FindTextBox.Text);
                //}
                //this.DialogResult = DialogResult.OK; // 设置窗体的返回值
            }
            else
            {
                // 非叶子节点或目录不存在，清空表格数据
                //dataGridView1.DataSource = null;
            }
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode clickedNode = treeView1.GetNodeAt(e.X, e.Y);

                if (clickedNode != null)
                {
                    treeView1.SelectedNode = clickedNode; // 选中右键点击的节点
                    contextMenuStrip1.Show(treeView1, e.Location); // 弹出菜单
                }
            }
        }

        private void 新建矿井名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;

            if (selectedNode == null)
            {
                MessageBox.Show("请先选择一个节点！");
                return;
            }

            string selectedPath = selectedNode.Tag?.ToString();

            if (string.IsNullOrEmpty(selectedPath) || !Directory.Exists(selectedPath))
            {
                MessageBox.Show("所选节点的路径无效或不存在！");
                return;
            }

            try
            {
                // 自动生成唯一文件夹名
                string baseName = "新建文件夹";
                int index = 0;
                string newFolderName;
                string newFolderPath;

                do
                {
                    newFolderName = baseName + (index == 0 ? "" : index.ToString());
                    newFolderPath = Path.Combine(selectedPath, newFolderName);
                    index++;
                }
                while (Directory.Exists(newFolderPath));

                // 创建文件夹
                Directory.CreateDirectory(newFolderPath);

                // 添加新节点
                TreeNode newNode = new TreeNode(newFolderName);
                newNode.Tag = newFolderPath;
                selectedNode.Nodes.Add(newNode);
                selectedNode.Expand();

                // 启用编辑
                treeView1.LabelEdit = true;
                treeView1.SelectedNode = newNode;
                newNode.BeginEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建文件夹失败：" + ex.Message);
            }
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;

            if (selectedNode == null)
            {
                MessageBox.Show("请先选择一个节点！");
                return;
            }

            treeView1.LabelEdit = true;
            selectedNode.BeginEdit(); // 启动编辑模式，用户可以输入新名称
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null)
                return; // 用户取消编辑

            string oldPath = e.Node.Tag?.ToString();
            if (string.IsNullOrEmpty(oldPath) || !Directory.Exists(oldPath))
                return;

            string newName = e.Label.Trim();

            // 检查非法字符
            if (string.IsNullOrWhiteSpace(newName) || newName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                MessageBox.Show("名称无效！");
                e.CancelEdit = true;
                return;
            }

            try
            {
                string parentPath = Path.GetDirectoryName(oldPath);
                string newPath = Path.Combine(parentPath, newName);

                if (Directory.Exists(newPath))
                {
                    MessageBox.Show("已存在同名文件夹！");
                    e.CancelEdit = true;
                    return;
                }

                // 重命名文件夹
                Directory.Move(oldPath, newPath);
                e.Node.Tag = newPath; // 更新路径
            }
            catch (Exception ex)
            {
                MessageBox.Show("重命名失败：" + ex.Message);
                e.CancelEdit = true;
            }
        }

        public string ResultData { get; set; }
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (selectedNode != null)
            {
                string path = selectedNode.Tag?.ToString();
                //MessageBox.Show($"你双击了节点：{selectedNode.Text}\n路径：{path}");

                if(selectedNode.Level==2)
                {
                    ResultData = path;
                    this.DialogResult = DialogResult.OK; // 设置窗体的返回值
                    this.Close(); // 关闭窗口
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node == null)
            {
                e.Cancel = true;
                return;
            }

            int level = node.Level;
            // 控制菜单显示
            switch(level)
            {
                case (0):
                    新建矿井名称ToolStripMenuItem.Visible = true;
                    新建项目名称ToolStripMenuItem.Visible = false;
                    重命名ToolStripMenuItem.Visible = true;
                    break;
                case (1):
                    新建矿井名称ToolStripMenuItem.Visible = false;
                    新建项目名称ToolStripMenuItem.Visible = true;
                    重命名ToolStripMenuItem.Visible = true;
                    break;
                case (2):
                    新建矿井名称ToolStripMenuItem.Visible = false;
                    新建项目名称ToolStripMenuItem.Visible = false;
                    重命名ToolStripMenuItem.Visible = true;
                    break;
            }
        }

        private void 新建项目名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            新建矿井名称ToolStripMenuItem_Click(sender,e);
        }

        private void DetermineButton_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;

            if (selectedNode == null)
            {
                MessageBox.Show("请先选择一个项目节点！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selectedNode.Level != 2)
            {
                MessageBox.Show("请选择有效的项目（第三级节点）！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string path = selectedNode.Tag?.ToString();
            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("所选项目无有效路径数据。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ResultData = path;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // 明确返回取消
            this.Close();
        }

    }
}
