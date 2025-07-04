using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GasFormsApp.TabControl.tabControl_2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Control = System.Windows.Forms.Control;
using Font = System.Drawing.Font;
using TextBox = System.Windows.Forms.TextBox;

namespace GasFormsApp.TabControl
{
    internal class tabControl_6
    {
        private MainForm _mainForm;


        public tabControl_6(MainForm form)
        {
            _mainForm = form;

            _mainForm.toolTip1.SetToolTip(_mainForm.FindTextBox, "查 找(Ctrl + F)");
            _mainForm.toolTip1.SetToolTip(_mainForm.label30, "查 找(Ctrl + F)");
            _mainForm.toolTip1.SetToolTip(_mainForm.ReloadDataButton, "刷 新(Ctrl + R)");
            _mainForm.toolTip1.SetToolTip(_mainForm.DeleteDataButton, "删 除(Ctrl + D)");
            _mainForm.toolTip1.SetToolTip(_mainForm.ExportTheDocumentButton, "导出报告(Ctrl + G)");


            // 注册“重新加载数据”按钮的点击事件处理器
            _mainForm.ReloadDataButton.Click += ReloadDataButton_Click;

            // 注册“删除数据”按钮的点击事件处理器
            _mainForm.DeleteDataButton.Click += DeleteDataButton_Click;

            // 注册“导出文档”按钮的点击事件处理器
            _mainForm.ExportTheDocumentButton.Click += ExportTheDocumentButton_Click;

            // 为 DataGridView 的 RowPostPaint 事件注册回调，用于自定义行的绘制（如绘制行号）
            _mainForm.dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;

            // 禁用 DataGridView 的默认剪贴板复制功能（防止用户 Ctrl+C 复制内容）
            _mainForm.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;

            // 注册键盘按下事件（如拦截 Ctrl+C、Delete 等操作）
            _mainForm.dataGridView1.KeyDown += dataGridView1_KeyDown;

            // 注册单元格双击事件（通常用于打开编辑窗口或详情视图）
            _mainForm.dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

            // 注册选中单元格变化事件（可以用于同步其他 UI 状态）
            _mainForm.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            // 注册单元格开始编辑事件的匿名函数，用于调试或日志记录编辑行为
            _mainForm.dataGridView1.CellBeginEdit += (s, e) => {
                Console.WriteLine($"CellBeginEdit at row {e.RowIndex}, col {e.ColumnIndex}");
            };
            _mainForm.dataGridView1.MouseDown += dataGridView1_MouseDown;
            _mainForm.dataGridView1.CellClick += dataGridView1_CellClick;

            _mainForm.恢复历史记录ToolStripMenuItem.Click += 恢复历史记录ToolStripMenuItem_Click;
            


            // 获取当前程序启动的目录路径
            string basePath = Application.StartupPath;
            // 构建目标文件夹路径（相对于启动目录的 SystemData\DataAdministrationForm）
            string rootPath = Path.Combine(basePath, "SystemData", "DataAdministrationForm");
            // 加载该路径下的文件夹结构到树控件
            LoadFoldersToTree(rootPath);
            // 绑定树控件节点选中事件
            _mainForm.treeView1.AfterSelect += treeView1_AfterSelect;
            _mainForm.treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            _mainForm.treeView1.DrawNode += treeView1_DrawNode;
            _mainForm.FindMineTextBox.KeyDown += FindMineTextBox_KeyDown;

            _mainForm.FindTextBox.KeyDown += FindTextBox_KeyDown;
            _mainForm.treeView1.MouseDown += treeView1_MouseDown;
            _mainForm.刷新ToolStripMenuItem.Click += 刷新ToolStripMenuItem_Click;
        }
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            string text = e.Node.Text;
            string keyword = _mainForm.FindMineTextBox.Text ?? "";
            Font font = _mainForm.treeView1.Font;
            int margin = 0;
            int verticalMargin = 8;

            Color textColor = Color.White;

            int matchIndex = -1;
            if (!string.IsNullOrEmpty(keyword))
                matchIndex = text.ToLower().IndexOf(keyword.ToLower());

            // **先用 TreeView 的背景色清理整行区域，避免遗留旧的绘制痕迹**
            e.Graphics.FillRectangle(new SolidBrush(_mainForm.treeView1.BackColor), e.Bounds);

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



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 确保点击的是有效的数据单元格（非表头或无效列）
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = _mainForm.dataGridView1.Rows[e.RowIndex];

                // 确保列索引没有超出单元格数量（防御性写法）
                if (e.ColumnIndex < row.Cells.Count)
                {
                    string cellValue = row.Cells[e.ColumnIndex].Value?.ToString();

                    // 可选：显示点击信息
                    // MessageBox.Show($"你点击了第 {e.RowIndex} 行，第 {e.ColumnIndex} 列，值为：{cellValue}");

                    // 触发切换行刷新图片
                    dataGridView1_SelectionChanged(sender, e);
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _mainForm.dataGridView1.Rows.Count > 0)
            {
                // 获取点击位置对应的行索引
                DataGridView.HitTestInfo hit = _mainForm.dataGridView1.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    // 判断该行是否已被选中
                    if (_mainForm.dataGridView1.Rows[hit.RowIndex].Selected)
                    {
                        // 在选中行上右键，弹出菜单
                        _mainForm.tabPage6contextMenuStrip2.Show(_mainForm.dataGridView1, e.Location);
                    }
                    else
                    {
                        // 如果点击的是没选中的行，可以选择先选中它（可选）
                        _mainForm.dataGridView1.ClearSelection();
                        _mainForm.dataGridView1.Rows[hit.RowIndex].Selected = true;

                        // 然后再弹出菜单
                        _mainForm.tabPage6contextMenuStrip2.Show(_mainForm.dataGridView1, e.Location);
                    }
                }
            }
        }

        void SetTextBoxValues(Form form, string baseName, List<string> values, int startIndex = 1)
        {
            for (int i = 0; i < values.Count; i++)
            {
                string name = $"{baseName}{i + startIndex}";
                var ctl = form.Controls.Find(name, true).FirstOrDefault();
                if (ctl is TextBox tb)
                {
                    tb.Text = values[i];
                }
            }
        }
        private void 恢复历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
            if (selectedNode != null && selectedNode.Tag is string path)
            {
                string name = _mainForm.dataGridView1.CurrentRow.Cells["ID"].Value?.ToString();
                
                // 你可以在这里使用 path 做后续操作，比如打开文件、修改、加载等
                string currentDir = AppDomain.CurrentDomain.BaseDirectory;
                string loadPath = Path.Combine(currentDir, path, name + "_BinData.bin");
                string imagePath = Path.Combine(currentDir, path, name + "_Image.png");  // 图片路径
                //MessageBox.Show("选中节点的路径是：" + loadPath);
                if (!File.Exists(loadPath))
                {
                    MessageBox.Show("找不到已保存的数据！");
                    return;
                }

                try
                {
                    using (FileStream fs = new FileStream(loadPath, FileMode.Open))
                    {
#pragma warning disable SYSLIB0011
                        var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        UserData data = (UserData)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011

                        _mainForm.MineNameTextBox.Text = data.矿井名称;
                        _mainForm.MineNameTextBox.Text = data.矿井名称;
                        _mainForm.SamplingSpotTextBox.Text = data.取样地点;
                        _mainForm.BurialDepthTextBox.Text = data.埋深;
                        _mainForm.CoalSeamTextBox.Text = data.煤层;
                        _mainForm.UndAtmPressureTextBox.Text = data.井下大气压力;
                        _mainForm.LabAtmPressureTextBox.Text = data.实验室大气压力;
                        _mainForm.UndTempTextBox.Text = data.井下环境温度;
                        _mainForm.LabTempTextBox.Text = data.实验室温度;
                        _mainForm.MoistureSampleTextBox.Text = data.煤样水分;
                        _mainForm.SampleModeComboBox.Text = data.取样方式;
                        _mainForm.SampleNumTextBox.Text = data.煤样编号;
                        _mainForm.RawCoalMoistureTextBox.Text = data.原煤水分;
                        _mainForm.InitialVolumeTextBox.Text = data.量管初始体积;
                        _mainForm.SampleWeightTextBox.Text = data.煤样重量;
                        _mainForm.SamplingDepthTextBox.Text = data.取样深度;
                        _mainForm.SamplingTimeDateTimePicker.Value = DateTime.Parse(data.取样时间);
                        _mainForm.DrillInclinationTextBox.Text = data.钻孔倾角;
                        _mainForm.AzimuthTextBox.Text = data.方位角;
                        _mainForm.SamplingPersonnelTextBox.Text = data.取样人员;

                        _mainForm.dateTimePicker2.Value = DateTime.Parse(data.打钻开始时间);
                        _mainForm.dateTimePicker5.Value = DateTime.Parse(data.取芯开始时间);
                        _mainForm.dateTimePicker3.Value = DateTime.Parse(data.取芯结束时间);
                        _mainForm.dateTimePicker4.Value = DateTime.Parse(data.解吸开始时间);
                        _mainForm.TypeOfDestructionComboBox3.Text = data.煤的破坏类型;
                        _mainForm.t0TextBox.Text = data.t0;

                        SetTextBoxValues(_mainForm, "DesorbTextBox", data.DesorbTextList);
                        SetTextBoxValues(_mainForm, "DataNumTextBox", data.DataNumTextList, 31);

                        _mainForm.DesVolUndTextBox.Text = data.井下解吸量体积;
                        _mainForm.UndDesorpCalTextBox.Text = data.井下解吸量校准W11;
                        _mainForm.SampLossVolTextBox.Text = data.瓦斯损失量W12;

                        _mainForm.DesorpVolNormalTextBox.Text = data.实验室常压解吸;
                        _mainForm.DesorpVolNormalCalTextBox.Text = data.实验室常压解吸校准W2;
                        _mainForm.Sample1WeightTextBox.Text = data.粉碎后第1份煤样重;
                        _mainForm.Sample2WeightTextBox.Text = data.粉碎后第2份煤样重;
                        _mainForm.S1DesorpVolTextBox.Text = data.第1份煤样解吸量;
                        _mainForm.S1DesorpVolCalTextBox.Text = data.第1份煤样解吸量校准;
                        _mainForm.S2DesorpVolTextBox.Text = data.第2份煤样解吸量;
                        _mainForm.S2DesorpVolCalTextBox.Text = data.第2份煤样解吸量校准;
                        _mainForm.CrushDesorpTextBox.Text = data.最终粉碎解吸量;

                        _mainForm.AdsorpConstATextBox.Text = data.吸附常数a;
                        _mainForm.AdsorpConstBTextBox.Text = data.吸附常数b;
                        _mainForm.MadTextBox.Text = data.水分;
                        _mainForm.AadTextBox.Text = data.灰分;
                        _mainForm.PorosityTextBox.Text = data.孔隙率;
                        _mainForm.AppDensityTextBox.Text = data.视相对密度;
                        _mainForm.TrueDensityTextBox.Text = data.真密度;
                        _mainForm.VadTextBox.Text = data.挥发分;
                        _mainForm.W1_TextBox.Text = data.W1;
                        _mainForm.W2_TextBox.Text = data.W2;
                        _mainForm.W3_TextBox.Text = data.W3;
                        _mainForm.Wa_TextBox.Text = data.Wa;
                        _mainForm.Wc_TextBox.Text = data.Wc;
                        _mainForm.W_TextBox.Text = data.W;
                        _mainForm.P_TextBox.Text = data.P;

                        _mainForm.CH4TextBox.Text = data.CH4;
                        _mainForm.CO2TextBox.Text = data.CO2;
                        _mainForm.N2TextBox.Text = data.N2;
                        _mainForm.O2TextBox.Text = data.O2;
                        _mainForm.C2H4TextBox.Text = data.C2H4;
                        _mainForm.C3H8TextBox.Text = data.C3H8;
                        _mainForm.C2H6TextBox.Text = data.C2H6;
                        _mainForm.C3H6TextBox.Text = data.C3H6;
                        _mainForm.C2H2TextBox.Text = data.C2H2;
                        _mainForm.COTextBox.Text = data.CO;

                        _mainForm.dateTimePicker6.Value = DateTime.Parse(data.测试时间);
                        _mainForm.dateTimePicker1.Value = DateTime.Parse(data.出报告时间);
                        _mainForm.DownholeTestersTextBox.Text = data.井下测试人员;
                        _mainForm.LabTestersTextBox.Text = data.实验室测试人员;
                        _mainForm.AuditorTextBox.Text = data.审核人员;
                        _mainForm.RemarkTextBox.Text = data.备注;

                        
                        if (File.Exists(imagePath))
                        {
                            Image img = Image.FromFile(imagePath);
                            _mainForm.pictureBox3.Image = img;
                            _mainForm.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage; // 可选：拉伸填满
                        }
                        else
                        {
                            MessageBox.Show("找不到图片文件：" + imagePath);
                        }
                        // 调用计算函数，防止tab4数据输出为0
                        _mainForm.tab6_4_ExpCalcButton_Click(sender,e);

                        MessageBox.Show("已恢复历史记录！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("未选中有效节点或节点没有路径信息！");
            }
        }
        // 矿井搜索
        private void FindMineTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  // 判断是否按下了回车键（Enter）
            {
                // e.Handled = true;  // （可选）告诉系统事件已经处理，阻止系统发出“叮”声
                e.SuppressKeyPress = true; // 阻止回车键被进一步处理，避免输入框响铃或换行

                // 获取当前程序启动的目录路径
                string basePath = Application.StartupPath;
                // 构建目标文件夹路径（相对于启动目录的 SystemData\DataAdministrationForm）
                string rootPath = Path.Combine(basePath, "SystemData", "DataAdministrationForm");
                // 加载该路径下的文件夹结构到树控件
                LoadFoldersToTree(rootPath);
            }
        }

        // 信息搜索
        private void FindTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //e.Handled = true; // 阻止系统发出“叮”声（可选）
                e.SuppressKeyPress = true;

                TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
                if (selectedNode != null)
                {
                    TreeViewEventArgs args = new TreeViewEventArgs(selectedNode);
                    treeView1_AfterSelect(_mainForm.treeView1, args); // sender 改为 treeView1 更合理
                }
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
                string str = _mainForm.FindTextBox.Text;
                if (string.IsNullOrEmpty(str))
                {
                    全部显示(selectedPath);
                }
                else
                {
                    查询显示(selectedPath, _mainForm.FindTextBox.Text);
                }
            }
            else
            {
                // 非叶子节点或目录不存在，清空表格数据
                _mainForm.dataGridView1.DataSource = null;
            }
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
            _mainForm.treeView1.Nodes.Clear();

            // 创建根节点，显示根目录名，Tag属性存储目录完整路径
            TreeNode rootNode = new TreeNode(rootDir.Name) { Tag = rootDir.FullName };
            rootNode.ImageKey = "根目录";
            rootNode.SelectedImageKey = "根目录";

            // 添加根节点到树控件
            _mainForm.treeView1.Nodes.Add(rootNode);

            // 递归添加子目录节点
            AddSubDirectories(rootDir, rootNode, 1);

            // 展开所有节点，方便查看
            _mainForm.treeView1.ExpandAll();
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
                if (level == 1 && !subDir.Name.ToLower().Contains(_mainForm.FindMineTextBox.Text.ToLower()))
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (_mainForm.dataGridView1.CurrentRow != null)
            {
                string name = _mainForm.dataGridView1.CurrentRow.Cells["ID"].Value?.ToString();
                Console.WriteLine("当前选中名称：" + name);

                // E:\E-Desktop\GitHub\GasFormsApp\bin\Release\SystemData

                TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
                if (selectedNode == null)
                {
                    MessageBox.Show("请先选择一个节点！");
                    return;
                }
                string selectedPath = selectedNode.Tag?.ToString();
                string newImageName = $"{name}_Image.png";
                string imagePath = Path.Combine("", newImageName);
                if (selectedNode.Nodes.Count == 0 && Directory.Exists(selectedPath))
                {
                    newImageName = $"{name}_Image.png";
                    imagePath = Path.Combine(selectedPath, newImageName);
                }
                else
                {
                    return;
                }

                // 设置 PictureBox 的显示模式
                _mainForm.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                try
                {
                    if (File.Exists(imagePath))
                    {
                        // 避免文件被锁，使用 Image.FromStream
                        using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                        {
                            _mainForm.pictureBox2.Image = Image.FromStream(fs);
                        }
                    }
                    else
                    {
                        MessageBox.Show("找不到图片文件：" + imagePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图片时出错：" + ex.Message);
                }
            }
        }

        // 解决一些问题
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("双击：" + e.RowIndex + e.ColumnIndex);
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _mainForm.dataGridView1.CurrentCell = _mainForm.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                _mainForm.dataGridView1.BeginEdit(true); // 手动进入编辑
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (_mainForm.dataGridView1.CurrentCell != null)
                {
                    Clipboard.SetText(_mainForm.dataGridView1.CurrentCell.Value?.ToString() ?? "");
                    e.Handled = true;
                }
            }
        }
        
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;

            // 获取行号（从 1 开始）
            string rowNumber = (e.RowIndex + 1).ToString();

            // 设置字体（可省略）
            //Font font = dgv.RowHeadersDefaultCellStyle.Font ?? dgv.DefaultCellStyle.Font;
            Font font = new Font("宋体", 12, FontStyle.Bold);

            // 计算绘制区域
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);

            // 居中绘制行号
            TextRenderer.DrawText(e.Graphics, rowNumber, font, headerBounds, Color.Black,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }


        // 标记该类可被序列化为二进制格式
        [Serializable]
        public class UserData
        {
            public string ID { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 矿井名称 { get; set; }
            public string 取样地点 { get; set; }
            public string 埋深 { get; set; }
            public string 煤层 { get; set; }
            public string 井下大气压力 { get; set; }
            public string 实验室大气压力 { get; set; }
            public string 井下环境温度 { get; set; }
            public string 实验室温度 { get; set; }
            public string 煤样水分 { get; set; }
            public string 取样方式 { get; set; }
            public string 煤样编号 { get; set; }
            public string 原煤水分 { get; set; }
            public string 量管初始体积 { get; set; }
            public string 煤样重量 { get; set; }
            public string 取样深度 { get; set; }
            public string 取样时间 { get; set; }
            // 新加++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            public string 钻孔倾角 { get; set; }
            public string 方位角 { get; set; }
            public string 取样人员 { get; set; }

            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 打钻开始时间 { get; set; }
            public string 取芯开始时间 { get; set; }
            public string 取芯结束时间 { get; set; }
            public string 解吸开始时间 { get; set; }
            public string 煤的破坏类型 { get; set; }
            public string t0 { get; set; }
            public List<string> DesorbTextList { get; set; } = new List<string>();
            public List<string> DataNumTextList { get; set; } = new List<string>();
            public string 井下解吸量体积 { get; set; }
            public string 井下解吸量校准W11 { get; set; }
            public string 瓦斯损失量W12 { get; set; }

            public string 解吸量
            {
                get => string.Join(", ", DesorbTextList);
                        set => DesorbTextList = value?
                    .Split(new[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).ToList() ?? new List<string>();
            }
            public string 解吸时间
            {
                get => string.Join(", ", DataNumTextList);
                set => DataNumTextList = value?
                    .Split(new[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).ToList() ?? new List<string>();
            }

            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 实验室常压解吸 { get; set; }
            public string 实验室常压解吸校准W2 { get; set; }
            public string 粉碎后第1份煤样重 { get; set; }
            public string 第1份煤样解吸量 { get; set; }
            public string 第1份煤样解吸量校准 { get; set; }
            public string 粉碎后第2份煤样重 { get; set; }
            public string 第2份煤样解吸量 { get; set; }
            public string 第2份煤样解吸量校准 { get; set; }
            public string 最终粉碎解吸量 { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 吸附常数a { get; set; }
            public string 吸附常数b { get; set; }
            public string 水分 { get; set; }
            public string 灰分 { get; set; }
            public string 孔隙率 { get; set; }
            public string 视相对密度 { get; set; }
            public string 真密度 { get; set; }
            public string 挥发分 { get; set; }
            //public string Wc { get; set; }    // 和下面的重复
            public string W1 { get; set; }
            public string W2 { get; set; }
            public string W3 { get; set; }
            public string Wa { get; set; }
            public string Wc { get; set; }
            public string W { get; set; }
            public string P { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string CH4 { get; set; }
            public string CO2 { get; set; }
            public string N2 { get; set; }
            public string O2 { get; set; }
            public string C2H4 { get; set; }
            public string C3H8 { get; set; }
            public string C2H6 { get; set; }
            public string C3H6 { get; set; }
            public string C2H2 { get; set; }
            public string CO { get; set; }

            public string 测试时间 { get; set; }
            public string 出报告时间 { get; set; }
            public string 井下测试人员 { get; set; }
            public string 实验室测试人员 { get; set; }
            public string 审核人员 { get; set; }
            public string 备注 { get; set; }
        }

        //// 当前程序目录
        //static string CurrentDir = AppDomain.CurrentDomain.BaseDirectory;

        //// 用于存放系统数据的文件夹路径
        //string SystemDataPath = Path.Combine(CurrentDir, "SystemData");

        public List<string> GetTextBoxValues(Control parent, string baseName, int end, int start = 1)
        {
            var list = new List<string>();
            for (int i = start; i <= end; i++)
            {
                var ctl = parent.Controls.Find($"{baseName}{i}", true).FirstOrDefault();
                list.Add(ctl is TextBox tb ? tb.Text : "");
            }
            return list;
        }
        /// <summary>
        /// 按钮1点击事件：复制图片并保存用户数据为二进制文件
        /// </summary>
        public bool SaveButton_Click(object sender, EventArgs e)
        {
            ProjectGroupsForm newForm = new ProjectGroupsForm();
            newForm.ResultData = null;
            DialogResult result = newForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                string data = newForm.ResultData;
            }
            else
            {
                MessageBox.Show($"已取消");
                return false;
            }
            string selectedPath = newForm.ResultData;
            if (Directory.Exists(selectedPath))
            {
                // 如果 SystemData 文件夹不存在，则创建
                if (!Directory.Exists(selectedPath))
                {
                    MessageBox.Show($"创建路径：{selectedPath}");
                    Directory.CreateDirectory(selectedPath);
                    Console.WriteLine($"{selectedPath} 文件夹不存在，已创建");
                }
            }
            else
            {
                return false;
            }
            //MessageBox.Show($"窗口已关闭！{selectedPath}");

            // 生成时间戳，用于命名文件
            //string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            string input = _mainForm.SamplingSpotTextBox.Text;
            // 匹配中英文括号内的内容
            Match match = Regex.Match(input, @"[（(](.*?)[）)]");
            string timestamp = match.Success ? match.Groups[1].Value : "";  // 没有括号就返回空字符串
            timestamp = timestamp + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            // === 复制图片 ===
            // 定义原始图片路径
            string imageSourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Python_embed", "Python", "images", "output_image.png");

            // 定义新的图片名称和路径
            string newImageName = $"{timestamp}_Image.png";
            string imageTargetPath = Path.Combine(selectedPath, newImageName);

            // 将图片复制到目标路径，若已存在则覆盖
            File.Copy(imageSourcePath, imageTargetPath, true);
            Console.WriteLine($"图片已复制到：{imageTargetPath}");

            //// 生成文档
            //_mainForm.tab6_5_GenerateReportToDatabase(timestamp);

            // === 保存用户数据 ===
            try
            {
                // 创建用户数据对象，这里是模拟数据，也可以从界面控件读取
                var user = new UserData
                {
                    ID = timestamp.ToString(),

                    // tab1
                    矿井名称 = _mainForm.MineNameTextBox.Text,
                    取样地点 = _mainForm.SamplingSpotTextBox.Text,
                    埋深 = _mainForm.BurialDepthTextBox.Text,
                    煤层 = _mainForm.CoalSeamTextBox.Text,
                    井下大气压力 = _mainForm.UndAtmPressureTextBox.Text,
                    实验室大气压力 = _mainForm.LabAtmPressureTextBox.Text,
                    井下环境温度 = _mainForm.UndTempTextBox.Text,
                    实验室温度 = _mainForm.LabTempTextBox.Text,
                    煤样水分 = _mainForm.MoistureSampleTextBox.Text,
                    取样方式 = _mainForm.SampleModeComboBox.Text,
                    煤样编号 = _mainForm.SampleNumTextBox.Text,
                    原煤水分 = _mainForm.RawCoalMoistureTextBox.Text,
                    量管初始体积 = _mainForm.InitialVolumeTextBox.Text,
                    煤样重量 = _mainForm.SampleWeightTextBox.Text,
                    取样深度 = _mainForm.SamplingDepthTextBox.Text,
                    取样时间 = _mainForm.SamplingTimeDateTimePicker.Text,
                    // 新加++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    钻孔倾角 =_mainForm.DrillInclinationTextBox.Text,
                    方位角 = _mainForm.AzimuthTextBox.Text,
                    取样人员 =_mainForm.SamplingPersonnelTextBox.Text,

                    // tab2
                    打钻开始时间 = _mainForm.dateTimePicker2.Text,
                    取芯开始时间 = _mainForm.dateTimePicker5.Text,
                    取芯结束时间 = _mainForm.dateTimePicker3.Text,
                    解吸开始时间 = _mainForm.dateTimePicker4.Text,
                    煤的破坏类型 = _mainForm.TypeOfDestructionComboBox3.Text,
                    t0 = _mainForm.t0TextBox.Text,
                    DesorbTextList = GetTextBoxValues(_mainForm, "DesorbTextBox", 60),
                    DataNumTextList = GetTextBoxValues(_mainForm, "DataNumTextBox", 60, 31),
                    井下解吸量体积 = _mainForm.DesVolUndTextBox.Text,
                    井下解吸量校准W11 = _mainForm.UndDesorpCalTextBox.Text,
                    瓦斯损失量W12 = _mainForm.SampLossVolTextBox.Text,

                    // tab3
                    实验室常压解吸 = _mainForm.DesorpVolNormalTextBox.Text,
                    实验室常压解吸校准W2 = _mainForm.DesorpVolNormalCalTextBox.Text,
                    粉碎后第1份煤样重 = _mainForm.Sample1WeightTextBox.Text,
                    第1份煤样解吸量 = _mainForm.S1DesorpVolTextBox.Text,
                    第1份煤样解吸量校准 = _mainForm.S1DesorpVolCalTextBox.Text,
                    粉碎后第2份煤样重 = _mainForm.Sample2WeightTextBox.Text,
                    第2份煤样解吸量 = _mainForm.S2DesorpVolTextBox.Text,
                    第2份煤样解吸量校准 = _mainForm.S2DesorpVolCalTextBox.Text,
                    最终粉碎解吸量 = _mainForm.CrushDesorpTextBox.Text,

                    // tab4
                    吸附常数a =_mainForm.AdsorpConstATextBox.Text,
                    吸附常数b =_mainForm.AdsorpConstBTextBox.Text,
                    水分 =_mainForm.MadTextBox.Text,
                    灰分 =_mainForm.AadTextBox.Text,
                    孔隙率 =_mainForm.PorosityTextBox.Text,
                    视相对密度 =_mainForm.AppDensityTextBox.Text,
                    真密度 =_mainForm.TrueDensityTextBox.Text,
                    挥发分 =_mainForm.VadTextBox.Text,
                    W1 = _mainForm.W1_TextBox.Text,
                    W2 = _mainForm.W2_TextBox.Text,
                    W3 = _mainForm.W3_TextBox.Text,
                    Wa = _mainForm.Wa_TextBox.Text,
                    Wc = _mainForm.Wc_TextBox.Text,
                    W = _mainForm.W_TextBox.Text,
                    P = _mainForm.P_TextBox.Text,

                    // tab5
                    CH4 = _mainForm.CH4TextBox.Text,
                    CO2 = _mainForm.CO2TextBox.Text,
                    N2 = _mainForm.N2TextBox.Text,
                    O2 = _mainForm.O2TextBox.Text,
                    C2H4 = _mainForm.C2H4TextBox.Text,
                    C3H8 = _mainForm.C3H8TextBox.Text,
                    C2H6 = _mainForm.C2H6TextBox.Text,
                    C3H6 = _mainForm.C3H6TextBox.Text,
                    C2H2 = _mainForm.C2H2TextBox.Text,
                    CO = _mainForm.COTextBox.Text,
                    测试时间 = _mainForm.dateTimePicker6.Text,
                    出报告时间 = _mainForm.dateTimePicker1.Text,
                    井下测试人员 = _mainForm.DownholeTestersTextBox.Text,
                    实验室测试人员 = _mainForm.LabTestersTextBox.Text,
                    审核人员 = _mainForm.AuditorTextBox.Text,
                    备注 = _mainForm.RemarkTextBox.Text,
                };


                // 定义要保存的二进制数据文件路径
                string dataFilePath = Path.Combine(selectedPath, $"{timestamp}_BinData.bin");

                // 使用二进制格式化器将对象序列化保存到文件中
                using (FileStream fs = new FileStream(dataFilePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, user);
                }

                Console.WriteLine($"二进制保存成功，文件路径：{dataFilePath}");
                //MessageBox.Show("保存成功！", "提示：");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("保存失败：" + ex.Message);
                MessageBox.Show("保存失败：" + ex.Message, "提示：");
                return false;
            }
        }

        /// <summary>
        /// 按钮2点击事件：读取所有保存的用户数据并绑定到 DataGridView
        /// </summary>
        public void ReloadDataButton_Click(object sender, EventArgs e)
        {
            // 设置筛选关键字
            string Keyword = _mainForm.FindTextBox.Text;
            if (string.IsNullOrEmpty(Keyword))
            {
                TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
                if (selectedNode != null)
                {
                    TreeViewEventArgs args = new TreeViewEventArgs(selectedNode);
                    treeView1_AfterSelect(_mainForm.treeView1, args); // sender 改为 treeView1 更合理
                }
            }
            else
            {
                TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
                if (selectedNode != null)
                {
                    TreeViewEventArgs args = new TreeViewEventArgs(selectedNode);
                    treeView1_AfterSelect(_mainForm.treeView1, args); // sender 改为 treeView1 更合理
                }
            }
        }

        private void ReloadTableData(string path)
        {
            // 解绑事件，避免触发 SelectionChanged
            _mainForm.dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;

            string sortColumnName = null;
            ListSortDirection sortDirection = ListSortDirection.Ascending;
            string selectedUserId = null;

            if (_mainForm.dataGridView1.CurrentRow != null)
            {
                int currentIndex = _mainForm.dataGridView1.CurrentRow.Index;
                int nextIndex = currentIndex + 1;
                int prevIndex = currentIndex - 1;

                if (nextIndex < _mainForm.dataGridView1.Rows.Count)
                {
                    // 下一行存在，选下一行ID
                    var nextRow = _mainForm.dataGridView1.Rows[nextIndex];
                    if (nextRow.DataBoundItem is UserData nextUser)
                    {
                        selectedUserId = nextUser.ID;
                    }
                }
                else if (prevIndex >= 0)
                {
                    // 下一行不存在，上一行存在，选上一行ID
                    var prevRow = _mainForm.dataGridView1.Rows[prevIndex];
                    if (prevRow.DataBoundItem is UserData prevUser)
                    {
                        selectedUserId = prevUser.ID;
                    }
                }
                else
                {
                    // 只有当前行，没有下一行和上一行，不选中任何行
                    selectedUserId = null;
                }
            }

            if (_mainForm.dataGridView1.SortedColumn != null)
            {
                sortColumnName = _mainForm.dataGridView1.SortedColumn.DataPropertyName;
                sortDirection = (_mainForm.dataGridView1.SortOrder == SortOrder.Descending)
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;
            }

            try
            {
                List<UserData> filteredUsers = LoadAllUsers(path);
                Console.WriteLine($"刷新数据，条数：{filteredUsers.Count}, 尝试恢复选中ID：{selectedUserId}");

                var sortableList = new SortableBindingList<UserData>(filteredUsers);
                _mainForm.dataGridView1.DataSource = null;
                _mainForm.dataGridView1.DataSource = sortableList;
                _mainForm.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // 恢复排序
                if (sortColumnName != null)
                {
                    var sortColumn = _mainForm.dataGridView1.Columns
                        .Cast<DataGridViewColumn>()
                        .FirstOrDefault(c => c.DataPropertyName == sortColumnName);
                    if (sortColumn != null)
                    {
                        _mainForm.dataGridView1.Sort(sortColumn, sortDirection);
                    }
                }

                // 延迟恢复选中行，确保DataGridView刷新完成
                if (!string.IsNullOrEmpty(selectedUserId))
                {
                    _mainForm.dataGridView1.BeginInvoke(new Action(() =>
                    {
                        bool found = false;
                        foreach (DataGridViewRow row in _mainForm.dataGridView1.Rows)
                        {
                            if (row.DataBoundItem is UserData user && user.ID == selectedUserId)
                            {
                                row.Selected = true;
                                _mainForm.dataGridView1.CurrentCell = row.Cells[0];
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("没有找到之前选中的用户ID。");
                        }
                    }));
                }
            }
            finally
            {
                _mainForm.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            }
        }


        // 导出word文档
        public void ExportTheDocumentButton_Click(object sender, EventArgs e)
        {
            // 获取当前行的 ID 作为文件名
            string name = _mainForm.dataGridView1.CurrentRow?.Cells["ID"]?.Value?.ToString();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("无法获取文档名称，请确认表格中有选中行。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 构建系统内部文件路径
            //string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            //string systemDataPath = Path.Combine(currentDir, "SystemData");

            TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("请先选择一个节点！");
                return;
            }
            string selectedPath = selectedNode.Tag?.ToString();
            if (selectedNode.Nodes.Count == 0 && Directory.Exists(selectedPath))
            {
                if (!Directory.Exists(selectedPath))
                {
                    Directory.CreateDirectory(selectedPath);
                    Console.WriteLine("[Log] SystemData 文件夹不存在，已创建。");
                }
            }
            else
            {
                return;
            }
                

            string outputPath = Path.Combine(selectedPath, $"{name}_Doc.docx");
            Console.WriteLine($"[Log] 原始文档路径：{outputPath}");

            // 弹出保存对话框让用户选择目标路径
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Word 文件 (*.docx)|*.docx",
                Title = "导出 Word 文件",
                FileName = $"{name}_Doc.docx" // 设置默认文件名
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string userSelectedPath = saveDialog.FileName;
                Console.WriteLine($"[Log] 用户选择保存路径：{userSelectedPath}");

                try
                {
                    // 判断源文件是否存在
                    if (!File.Exists(outputPath))
                    {
                        MessageBox.Show($"源文件不存在：{outputPath}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    File.Copy(outputPath, userSelectedPath, overwrite: true);
                    MessageBox.Show("文件导出成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 删除数据
        public void DeleteDataButton_Click(object sender, EventArgs e)
        {
            // 获取当前行的 ID 作为文件名
            string name = _mainForm.dataGridView1.CurrentRow?.Cells["ID"]?.Value?.ToString();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("无法获取文档名称，请确认表格中有选中行。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请选择要处理的行。");
                return;
            }

            string sourceFolder = "SystemData";
            string recycleFolder = "DataReclamation";

            // 确保回收目录存在
            if (!Directory.Exists(recycleFolder))
            {
                Directory.CreateDirectory(recycleFolder);
            }

            string imagePath = Path.Combine(sourceFolder, $"{name}_Image.png");
            string binPath = Path.Combine(sourceFolder, $"{name}_BinData.bin");
            string docPath = Path.Combine(sourceFolder, $"{name}_Doc.docx");  // 添加 Word 文件路径

            TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("请先选择一个节点！");
                return;
            }
            string selectedPath = selectedNode.Tag?.ToString();
            if (selectedNode.Nodes.Count == 0 && Directory.Exists(selectedPath))
            {
                //ReloadTableData(selectedPath);
                //MessageBox.Show($"所选节点路径：{selectedPath}");
                imagePath = Path.Combine(selectedPath, $"{name}_Image.png");
                binPath = Path.Combine(selectedPath, $"{name}_BinData.bin");
                docPath = Path.Combine(selectedPath, $"{name}_Doc.docx");
            }

            try
            {
                // 移动文件方法
                void MoveFileToRecycle(string sourceFile)
                {
                    if (File.Exists(sourceFile))
                    {
                        string destFile = Path.Combine(recycleFolder, Path.GetFileName(sourceFile));

                        // 如果目标文件已存在，可以选择覆盖或者改名，这里用覆盖
                        if (File.Exists(destFile))
                            File.Delete(destFile);

                        File.Move(sourceFile, destFile);
                        Console.WriteLine($"已移动文件：{sourceFile} -> {destFile}");
                    }
                    else
                    {
                        Console.WriteLine($"文件不存在：{sourceFile}");
                    }
                }

                MoveFileToRecycle(imagePath);
                MoveFileToRecycle(binPath);
                MoveFileToRecycle(docPath);  // 处理 Word 文件

                selectedNode = _mainForm.treeView1.SelectedNode;
                if (selectedNode == null)
                {
                    MessageBox.Show("请先选择一个节点！");
                    return;
                }
                selectedPath = selectedNode.Tag?.ToString();
                if (selectedNode.Nodes.Count == 0 && Directory.Exists(selectedPath))
                {
                    ReloadTableData(selectedPath);
                }

                //MessageBox.Show("文件已移动到回收目录！");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"移动文件时发生错误：{ex.Message}");
            }
        }


        private string _currentKeyword = "";
        void 全部显示(string path)
        {
            _currentKeyword = "";

            // 记录当前排序列和方向
            string sortColumnName = null;
            ListSortDirection sortDirection = ListSortDirection.Ascending;

            // 记录选中用户ID
            string selectedUserId = null;

            try
            {
                // 先保存排序信息和选中行信息
                if (_mainForm.dataGridView1.SortedColumn != null)
                {
                    sortColumnName = _mainForm.dataGridView1.SortedColumn.DataPropertyName;
                    sortDirection = (_mainForm.dataGridView1.SortOrder == SortOrder.Descending)
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending;
                }

                if (_mainForm.dataGridView1.CurrentRow != null &&
                    _mainForm.dataGridView1.CurrentRow.DataBoundItem is UserData selectedUser)
                {
                    selectedUserId = selectedUser.ID;
                }

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("BinData 文件夹不存在！");
                    return;
                }

                string[] files = Directory.GetFiles(path, "*.bin");
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

                // 解绑事件，避免刷新时触发选中变化事件等
                _mainForm.dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;

                _mainForm.dataGridView1.DataSource = null;
                _mainForm.dataGridView1.DataSource = sortableList;
                _mainForm.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // 延迟恢复排序，避免排序没有立即生效
                if (sortColumnName != null)
                {
                    _mainForm.dataGridView1.BeginInvoke(new Action(() =>
                    {
                        var sortColumn = _mainForm.dataGridView1.Columns
                            .Cast<DataGridViewColumn>()
                            .FirstOrDefault(c => c.DataPropertyName == sortColumnName);

                        if (sortColumn != null)
                        {
                            _mainForm.dataGridView1.Sort(sortColumn, sortDirection);
                        }
                    }));
                }

                // 延迟恢复选中行
                if (!string.IsNullOrEmpty(selectedUserId))
                {
                    _mainForm.dataGridView1.BeginInvoke(new Action(() =>
                    {
                        foreach (DataGridViewRow row in _mainForm.dataGridView1.Rows)
                        {
                            if (row.DataBoundItem is UserData user && user.ID == selectedUserId)
                            {
                                row.Selected = true;
                                _mainForm.dataGridView1.CurrentCell = row.Cells[0];
                                break;
                            }
                        }
                    }));
                }

                // 重新绑定事件
                _mainForm.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

                Console.WriteLine("数据加载完成，已绑定到 dataGridView1。");
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取失败：" + ex.Message);
            }
        }



        private List<UserData> LoadAllUsers(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("BinData 文件夹不存在！");
                return new List<UserData>();
            }

            string[] files = Directory.GetFiles(path, "*.bin");
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
        private void 查询显示(string path,string filterKeyword)
        {
            // 记录当前排序列和方向
            string sortColumnName = null;
            ListSortDirection sortDirection = ListSortDirection.Ascending;

            // 记录选中用户ID（假设UserData有ID属性）
            string selectedUserId = null;

            try
            {
                // 先记录排序信息和选中行信息
                if (_mainForm.dataGridView1.SortedColumn != null)
                {
                    sortColumnName = _mainForm.dataGridView1.SortedColumn.DataPropertyName;
                    sortDirection = (_mainForm.dataGridView1.SortOrder == SortOrder.Descending)
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending;
                }

                if (_mainForm.dataGridView1.CurrentRow != null &&
                    _mainForm.dataGridView1.CurrentRow.DataBoundItem is UserData selectedUser)
                {
                    selectedUserId = selectedUser.ID;
                }

                List<UserData> allUsers = LoadAllUsers(path);

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
                _mainForm.dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;
                _mainForm.dataGridView1.CellPainting -= DataGridView1_CellPainting;

                _mainForm.dataGridView1.DataSource = null;
                _mainForm.dataGridView1.DataSource = sortableList;
                _mainForm.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // 绑定高亮事件
                _mainForm.dataGridView1.CellPainting += DataGridView1_CellPainting;

                // 延迟恢复排序
                if (sortColumnName != null)
                {
                    _mainForm.dataGridView1.BeginInvoke(new Action(() =>
                    {
                        var sortColumn = _mainForm.dataGridView1.Columns
                            .Cast<DataGridViewColumn>()
                            .FirstOrDefault(c => c.DataPropertyName == sortColumnName);

                        if (sortColumn != null)
                        {
                            _mainForm.dataGridView1.Sort(sortColumn, sortDirection);
                        }
                    }));
                }

                // 延迟恢复选中行
                if (!string.IsNullOrEmpty(selectedUserId))
                {
                    _mainForm.dataGridView1.BeginInvoke(new Action(() =>
                    {
                        foreach (DataGridViewRow row in _mainForm.dataGridView1.Rows)
                        {
                            if (row.DataBoundItem is UserData user && user.ID == selectedUserId)
                            {
                                row.Selected = true;
                                _mainForm.dataGridView1.CurrentCell = row.Cells[0];
                                break;
                            }
                        }
                    }));
                }

                // 重新绑定事件
                _mainForm.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

                Console.WriteLine($"数据加载完成，筛选关键字：'{filterKeyword}'，结果数：{filteredUsers.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取失败：" + ex.Message);
            }
        }

        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var dgv = sender as DataGridView;

            string cellText = e.FormattedValue?.ToString();
            if (string.IsNullOrEmpty(cellText) || string.IsNullOrEmpty(_currentKeyword))
                return;

            int matchIndex = cellText.IndexOf(_currentKeyword, StringComparison.OrdinalIgnoreCase);
            if (matchIndex < 0)
                return;

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);

            using (var normalBrush = new SolidBrush(dgv.DefaultCellStyle.ForeColor))
            using (var highlightBrush = new SolidBrush(Color.Red))
            using (var boldFont = new Font(e.CellStyle.Font, FontStyle.Bold))
            {
                var g = e.Graphics;
                var font = e.CellStyle.Font;
                var bounds = e.CellBounds;

                string before = cellText.Substring(0, matchIndex);
                string match = cellText.Substring(matchIndex, _currentKeyword.Length);
                string after = cellText.Substring(matchIndex + _currentKeyword.Length);

                float x = bounds.X;
                float y = bounds.Y + (bounds.Height - font.Height) / 2 + 1;

                Size sizeBefore = TextRenderer.MeasureText(before, font);
                Size sizeMatch = TextRenderer.MeasureText(match, boldFont);

                // 普通文字
                g.DrawString(before, font, normalBrush, x, y);
                x += (matchIndex == 0) ? sizeBefore.Width : sizeBefore.Width - 8;

                // 加粗红色高亮文字
                g.DrawString(match, boldFont, highlightBrush, x, y);
                x += sizeMatch.Width - 8;

                // 普通文字
                g.DrawString(after, font, normalBrush, x, y);
            }
        }


        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _mainForm.tabPage6contextMenuStrip1.Show(_mainForm.treeView1, e.Location); // 弹出菜单
            }
        }
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 获取当前程序启动的目录路径
            string basePath = Application.StartupPath;
            // 构建目标文件夹路径（相对于启动目录的 SystemData\DataAdministrationForm）
            string rootPath = Path.Combine(basePath, "SystemData", "DataAdministrationForm");
            // 加载该路径下的文件夹结构到树控件
            LoadFoldersToTree(rootPath);
        }
    }
}
