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
using System.Management;
using System.Security.Cryptography;
using static GasFormsApp.TabControl.tabControl_6;
using System.Runtime.Serialization.Formatters.Binary;

namespace GasFormsApp
{
    public partial class DataAdministrationForm : Form
    {
        public DataAdministrationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绘制 DataGridView 的行号（行头显示行号）
        /// </summary>
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // 当前行号（从1开始）
            string rowIdx = (e.RowIndex + 1).ToString();

            // 设置绘制用的字体样式
            var font = new Font("宋体", 12F, FontStyle.Bold);

            // 设置字符串格式，使文字水平和垂直居中
            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // 计算行头单元格的区域大小
            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dataGridView1.RowHeadersWidth, e.RowBounds.Height);

            // 在行头绘制行号文字
            e.Graphics.DrawString(rowIdx, font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        /// <summary>
        /// 窗体加载时触发，初始化树形目录
        /// </summary>
        private void DataAdministrationForm_Load(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            this.Width = (int)(screenWidth * 0.64);
            this.Height = (int)(screenHeight * 0.64);
            // 居中设置
            this.Left = (screenWidth - this.Width) / 2;
            this.Top = (screenHeight - this.Height) / 2;

            // 获取当前程序启动的目录路径
            string basePath = Application.StartupPath;

            // 构建目标文件夹路径（相对于启动目录的 SystemData\DataAdministrationForm）
            string rootPath = Path.Combine(basePath, "SystemData", "DataAdministrationForm");

            // 加载该路径下的文件夹结构到树控件
            LoadFoldersToTree(rootPath);

            // 绑定树控件节点选中事件
            treeView1.AfterSelect += treeView1_AfterSelect;
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
                // 加载该目录下的文件到表格显示
                string str = FindTextBox.Text;
                if (string.IsNullOrEmpty(str))
                {
                    全部显示(selectedPath);
                }
                else
                {
                    查询显示(selectedPath, FindTextBox.Text);
                }
            }
            else
            {
                // 非叶子节点或目录不存在，清空表格数据
                dataGridView1.DataSource = null;
            }
        }
        private string _currentKeyword = "";
        private void 全部显示(string SystemDataPath)
        {
            _currentKeyword = "";

            string sortColumnName = null;
            ListSortDirection sortDirection = ListSortDirection.Ascending;
            string selectedUserId = null;

            if (dataGridView1.SortedColumn != null)
            {
                sortColumnName = dataGridView1.SortedColumn.DataPropertyName;
                sortDirection = (dataGridView1.SortOrder == SortOrder.Descending)
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;
            }

            if (dataGridView1.CurrentRow != null &&
                dataGridView1.CurrentRow.DataBoundItem is UserData selectedUser)
            {
                selectedUserId = selectedUser.ID;
            }

            if (!Directory.Exists(SystemDataPath))
            {
                Console.WriteLine("BinData 文件夹不存在！");
                return;
            }

            Task.Run(() =>
            {
                try
                {
                    string[] files = Directory.GetFiles(SystemDataPath, "*.bin");
                    if (files.Length == 0)
                    {
                        Console.WriteLine("没有找到数据文件！");
                        return;
                    }

                    List<UserData> allUsers = new List<UserData>();
                    BinaryFormatter formatter = new BinaryFormatter();

                    foreach (var file in files)
                    {
                        using (FileStream fs = new FileStream(file, FileMode.Open))
                        {
                            UserData user = (UserData)formatter.Deserialize(fs);
                            allUsers.Add(user);
                        }
                    }

                    var sortableList = new SortableBindingList<UserData>(allUsers);

                    // 回到 UI 线程更新 DataGridView
                    dataGridView1.Invoke(new Action(() =>
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = sortableList;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                        // 恢复排序
                        if (sortColumnName != null)
                        {
                            var sortColumn = dataGridView1.Columns
                                .Cast<DataGridViewColumn>()
                                .FirstOrDefault(c => c.DataPropertyName == sortColumnName);

                            if (sortColumn != null)
                            {
                                dataGridView1.Sort(sortColumn, sortDirection);
                            }
                        }

                        // 恢复选中行
                        if (!string.IsNullOrEmpty(selectedUserId))
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.DataBoundItem is UserData user && user.ID == selectedUserId)
                                {
                                    row.Selected = true;
                                    dataGridView1.CurrentCell = row.Cells[0];
                                    break;
                                }
                            }
                        }

                        Console.WriteLine("数据加载完成。");
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("读取失败：" + ex.Message);
                }
            });
        }


        private List<UserData> LoadAllUsers(string SystemDataPath)
        {
            if (!Directory.Exists(SystemDataPath))
            {
                Console.WriteLine("BinData 文件夹不存在！");
                return new List<UserData>();
            }

            string[] files = Directory.GetFiles(SystemDataPath, "*.bin");
            if (files.Length == 0)
            {
                Console.WriteLine("没有找到数据文件！");
                return new List<UserData>();
            }

            List<UserData> allUsers = new List<UserData>();
            BinaryFormatter formatter = new BinaryFormatter();

            foreach (var file in files)
            {
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    UserData user = (UserData)formatter.Deserialize(fs);
                    allUsers.Add(user);
                }
            }
            return allUsers;
        }
        private void 查询显示(string SystemDataPath, string filterKeyword)
        {
            // 记录当前排序列和方向
            string sortColumnName = null;
            ListSortDirection sortDirection = ListSortDirection.Ascending;

            // 记录选中用户ID（假设UserData有ID属性）
            string selectedUserId = null;

            try
            {
                // 先记录排序信息和选中行信息
                if (dataGridView1.SortedColumn != null)
                {
                    sortColumnName = dataGridView1.SortedColumn.DataPropertyName;
                    sortDirection = (dataGridView1.SortOrder == SortOrder.Descending)
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending;
                }

                if (dataGridView1.CurrentRow != null &&
                    dataGridView1.CurrentRow.DataBoundItem is UserData selectedUser)
                {
                    selectedUserId = selectedUser.ID;
                }

                List<UserData> allUsers = LoadAllUsers(SystemDataPath);

                if (allUsers.Count == 0)
                {
                    Console.WriteLine("没有数据，无法筛选！");
                    return;
                }

                _currentKeyword = filterKeyword; // 保存当前关键字，用于高亮

                List<UserData> filteredUsers;
                if (string.IsNullOrEmpty(filterKeyword))
                {
                    filteredUsers = allUsers;
                }
                else
                {
                    filteredUsers = allUsers
                        .Where(u =>
                            u.GetType()
                             .GetProperties()
                             .Where(p => p.PropertyType == typeof(string))
                             .Select(p => p.GetValue(u) as string)
                             .Any(val => !string.IsNullOrEmpty(val) &&
                                         val.IndexOf(filterKeyword, StringComparison.OrdinalIgnoreCase) >= 0)
                        )
                        .ToList();
                }

                var sortableList = new SortableBindingList<UserData>(filteredUsers);

                // 解绑事件，防止刷新时触发 SelectionChanged 等事件
                //dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;
                //dataGridView1.CellPainting -= DataGridView1_CellPainting;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = sortableList;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // 绑定高亮事件
                //dataGridView1.CellPainting += DataGridView1_CellPainting;

                // 延迟恢复排序
                if (sortColumnName != null)
                {
                    dataGridView1.BeginInvoke(new Action(() =>
                    {
                        var sortColumn = dataGridView1.Columns
                            .Cast<DataGridViewColumn>()
                            .FirstOrDefault(c => c.DataPropertyName == sortColumnName);

                        if (sortColumn != null)
                        {
                            dataGridView1.Sort(sortColumn, sortDirection);
                        }
                    }));
                }

                // 延迟恢复选中行
                if (!string.IsNullOrEmpty(selectedUserId))
                {
                    dataGridView1.BeginInvoke(new Action(() =>
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.DataBoundItem is UserData user && user.ID == selectedUserId)
                            {
                                row.Selected = true;
                                dataGridView1.CurrentCell = row.Cells[0];
                                break;
                            }
                        }
                    }));
                }

                // 重新绑定事件
                //dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

                Console.WriteLine($"数据加载完成，筛选关键字：'{filterKeyword}'，结果数：{filteredUsers.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 将指定目录下符合过滤条件的文件加载到 DataGridView 中显示
        /// </summary>
        /// <param name="folderPath">文件夹路径</param>
        /// <param name="filter">文件过滤模式，默认所有文件(*)</param>
        private void LoadFilesToGrid(string folderPath, string filter = "*")
        {
            // 获取符合过滤条件的所有文件
            var files = Directory.GetFiles(folderPath, filter);

            // 如果没有文件，则提示用户并清空表格
            if (files.Length == 0)
            {
                MessageBox.Show("该文件夹下没有任何文件！");
                dataGridView1.DataSource = null;
                return;
            }

            // 创建一个DataTable用于作为DataGridView数据源，包含“文件名”和“完整路径”两列
            DataTable table = new DataTable();
            table.Columns.Add("文件名");
            table.Columns.Add("完整路径");

            // 遍历所有文件，将文件名和完整路径添加到DataTable中
            foreach (var file in files)
            {
                DataRow row = table.NewRow();
                row["文件名"] = Path.GetFileName(file); // 只显示文件名
                row["完整路径"] = file;                 // 保存完整路径备用
                table.Rows.Add(row);
            }

            // 绑定DataTable作为DataGridView的数据源
            dataGridView1.DataSource = table;

            // 隐藏“完整路径”列，避免界面显示多余信息
            if (dataGridView1.Columns["完整路径"] != null)
                dataGridView1.Columns["完整路径"].Visible = false;
        }

        // 搜索框数据变化
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            //TreeNode selectedNode = treeView1.SelectedNode;

            //if (selectedNode != null)
            //{
            //    TreeViewEventArgs args = new TreeViewEventArgs(selectedNode);
            //    treeView1_AfterSelect(treeView1, args); // sender 改为 treeView1 更合理
            //}
        }

        private void FindTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //e.Handled = true; // 阻止系统发出“叮”声（可选）
                e.SuppressKeyPress = true;

                TreeNode selectedNode = treeView1.SelectedNode;
                if (selectedNode != null)
                {
                    TreeViewEventArgs args = new TreeViewEventArgs(selectedNode);
                    treeView1_AfterSelect(treeView1, args); // sender 改为 treeView1 更合理
                }
            }
        }
    }
}
