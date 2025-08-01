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

            // 获取当前用户的 AppData\Roaming 路径
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // 拼接你的程序专用目录，比如：AppData\Roaming\瓦斯含量测定数据分析系统\SystemData\DataAdministrationForm
            string rootPath = Path.Combine(appDataPath, "瓦斯含量测定数据分析系统", "SystemData", "DataAdministrationForm");

            // 如果路径不存在则创建
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            // rootPath 就是最终的可用路径


            treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeView1.DrawNode += treeView1_DrawNode;

            // 加载目录到树控件
            LoadFoldersToTree(rootPath);
            // 回到顶部
            if (treeView1.Nodes.Count > 0)
            {
                treeView1.TopNode = treeView1.Nodes[0];
            }
        }
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            string text = e.Node.Text;
            string keyword = FindMineTextBox.Text ?? "";
            Font font = treeView1.Font;
            int margin = 0;
            int verticalMargin = 8;

            Color textColor = Color.White;

            int matchIndex = -1;
            if (!string.IsNullOrEmpty(keyword))
                matchIndex = text.ToLower().IndexOf(keyword.ToLower());

            // **先用 TreeView 的背景色清理整行区域，避免遗留旧的绘制痕迹**
            e.Graphics.FillRectangle(new SolidBrush(treeView1.BackColor), e.Bounds);

            // 如果选中则绘制高亮背景并设置文字颜色
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                textColor = SystemColors.HighlightText;
            }

            float x = e.Bounds.Left + margin;
            float y = e.Bounds.Top + verticalMargin;

            if (string.IsNullOrEmpty(keyword) || matchIndex < 0)
            {
                TextRenderer.DrawText(e.Graphics, text, font, new Point((int)x, (int)y), textColor, TextFormatFlags.NoPadding);
                return;
            }

            string before = text.Substring(0, matchIndex);
            string matchText = text.Substring(matchIndex, keyword.Length);
            string after = text.Substring(matchIndex + keyword.Length);

            Size beforeSize = TextRenderer.MeasureText(e.Graphics, before, font, e.Bounds.Size, TextFormatFlags.NoPadding);
            TextRenderer.DrawText(e.Graphics, before, font, new Point((int)x, (int)y), textColor, TextFormatFlags.NoPadding);
            x += beforeSize.Width;

            Size matchSize = TextRenderer.MeasureText(e.Graphics, matchText, font, e.Bounds.Size, TextFormatFlags.NoPadding);
            //TextRenderer.DrawText(e.Graphics, matchText, font, new Point((int)x, (int)y),
            //    (e.State & TreeNodeStates.Selected) != 0 ? SystemColors.HighlightText : Color.FromArgb(48, 227, 202),
            //    TextFormatFlags.NoPadding);
            // 绘制文本
            Font boldFont = new Font(font, FontStyle.Bold);
            TextRenderer.DrawText(
                e.Graphics,
                matchText,
                boldFont,
                new Point((int)x, (int)y),
                (e.State & TreeNodeStates.Selected) != 0 ? SystemColors.HighlightText : Color.Red,
                TextFormatFlags.NoPadding
            );
            x += matchSize.Width;

            TextRenderer.DrawText(e.Graphics, after, font, new Point((int)x, (int)y), textColor, TextFormatFlags.NoPadding);
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
            rootNode.ImageKey = "根目录";
            rootNode.SelectedImageKey = "根目录";

            // 添加根节点到树控件
            treeView1.Nodes.Add(rootNode);

            // 递归添加子目录节点
            AddSubDirectories(rootDir, rootNode, 1);

            // 展开上次节点节点，方便查看
            string savedNodeText = GasFormsApp.Settings.Default.Tab6SearchForMinesText;
            //treeView1.ExpandAll();
            foreach (TreeNode node in treeView1.Nodes)
            {
                // 第一级全部展开
                node.Expand();

                TreeNode targetChild = null;

                foreach (TreeNode child in node.Nodes)
                {
                    if (child.Text == savedNodeText)
                    {
                        child.Expand();
                        targetChild = child;  // 记录找到的子节点
                        break;               // 如果确定唯一，找到后可以跳出
                    }
                }

                if (targetChild != null)
                {
                    // 移动 targetChild 到该一级节点的第一个子节点位置
                    node.Nodes.Remove(targetChild);
                    node.Nodes.Insert(0, targetChild);
                }
            }

        }
        /// <summary>
        /// 递归添加指定目录的所有子目录到指定父节点下
        /// </summary>
        /// <param name="dir">当前目录</param>
        /// <param name="parentNode">父节点</param>
        private void AddSubDirectories(DirectoryInfo dir, TreeNode parentNode, int level)
        {
            foreach (var subDir in dir.GetDirectories())
            {
                if (level == 1 && !subDir.Name.ToLower().Contains(FindMineTextBox.Text.ToLower()))
                    continue;

                TreeNode childNode = new TreeNode(subDir.Name)
                {
                    Tag = subDir.FullName
                };

                // 根据层级设置不同图标（示例）
                if (level == 1)
                {
                    childNode.ImageKey = "矿井";
                    childNode.SelectedImageKey = "矿井";
                }
                else if (level == 2)
                {
                    childNode.ImageKey = "项目";
                    childNode.SelectedImageKey = "项目";
                }
                else
                {
                    childNode.ImageKey = "根目录";
                    childNode.SelectedImageKey = "根目录";
                }

                parentNode.Nodes.Add(childNode);

                // 递归调用，层级 +1
                AddSubDirectories(subDir, childNode, level + 1);
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
                    // 获取当前目录的目录信息
                    DirectoryInfo currentDir = new DirectoryInfo(path);
                    // 上一级目录
                    DirectoryInfo parentDir = currentDir.Parent;
                    if (parentDir != null)
                    {
                        Console.WriteLine("当前目录名: " + currentDir.Name);
                        Console.WriteLine("上一级目录名: " + parentDir.Name);

                        GasFormsApp.Settings.Default.SearchForMinesText = parentDir.Name;
                        GasFormsApp.Settings.Default.Save();
                    }
                    else
                    {
                        Console.WriteLine("没有上一级目录");
                    }
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

            // 获取当前目录的目录信息
            DirectoryInfo currentDir = new DirectoryInfo(path);
            // 上一级目录
            DirectoryInfo parentDir = currentDir.Parent;
            if (parentDir != null)
            {
                Console.WriteLine("当前目录名: " + currentDir.Name);
                Console.WriteLine("上一级目录名: " + parentDir.Name);

                GasFormsApp.Settings.Default.SearchForMinesText = parentDir.Name;
                GasFormsApp.Settings.Default.Save();
            }
            else
            {
                Console.WriteLine("没有上一级目录");
            }
            //MessageBox.Show($"牛逼：{parentDir.Name}");
            ResultData = path;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // 明确返回取消
            this.Close();
        }

        //快捷键操作
        private void ProjectGroupsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control) return;

            switch (e.KeyCode)
            {
                case Keys.F: // 查找
                    FindMineTextBox.Focus();

                    
                    e.Handled = true;
                    break;
            }
        }

        private void FindMineTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 回车被按下
                //// 获取程序启动目录
                //string basePath = Application.StartupPath;
                //// 构建目标文件夹路径：SystemData\DataAdministrationForm
                //string rootPath = Path.Combine(basePath, "SystemData", "DataAdministrationForm");

                // 获取当前用户的 AppData\Roaming 路径
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                // 拼接你的程序专用目录，比如：AppData\Roaming\瓦斯含量测定数据分析系统\SystemData\DataAdministrationForm
                string rootPath = Path.Combine(appDataPath, "瓦斯含量测定数据分析系统", "SystemData", "DataAdministrationForm");
                // 如果路径不存在则创建
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }
                treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
                treeView1.DrawNode += treeView1_DrawNode;
                // 加载目录到树控件
                LoadFoldersToTree(rootPath);
                // 回到顶部
                if (treeView1.Nodes.Count > 0)
                {
                    treeView1.TopNode = treeView1.Nodes[0];
                }
                e.Handled = true;
            }
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            treeView1.Invalidate();
        }
    }
}
