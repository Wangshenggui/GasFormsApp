using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = System.Drawing.Font;

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
            

            //注册回调函数
            _mainForm.ReloadDataButton.Click += ReloadDataButton_Click;
            _mainForm.DeleteDataButton.Click += DeleteDataButton_Click;
            _mainForm.ExportTheDocumentButton.Click += ExportTheDocumentButton_Click;


            _mainForm.dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;

            //禁用默认复制模式
            _mainForm.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            _mainForm.dataGridView1.KeyDown += dataGridView1_KeyDown;

            _mainForm.dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            _mainForm.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            _mainForm.dataGridView1.CellBeginEdit += (s, e) => {
                Console.WriteLine($"CellBeginEdit at row {e.RowIndex}, col {e.ColumnIndex}");
            };
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (_mainForm.dataGridView1.CurrentRow != null)
            {
                string name = _mainForm.dataGridView1.CurrentRow.Cells["ID"].Value?.ToString();
                Console.WriteLine("当前选中名称：" + name);

                // E:\E-Desktop\GitHub\GasFormsApp\bin\Release\SystemData
                
                string newImageName = $"{name}_Image.png";
                string imagePath = Path.Combine("SystemData", newImageName);
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
            public string 取样时间 { get; set; }
            public string 埋深 { get; set; }
            public string 煤层 { get; set; }
            public string 煤样编号 { get; set; }
            public string 实验室大气压力 { get; set; }
            public string 实验室温度 { get; set; }
            public string 取样方式 { get; set; }
            public string 原煤水分 { get; set; }
            public string 取样深度 { get; set; }
            public string 井下大气压力 { get; set; }
            public string 井下环境温度 { get; set; }
            public string 煤样重量 { get; set; }
            public string 煤样水分 { get; set; }
            public string 量管初始体积 { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 井下解吸量W11 { get; set; }
            public string 瓦斯损失量W12 { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 实验室常压解吸W2 { get; set; }
            public string 粉碎后第1份煤样重 { get; set; }
            public string 第1份煤样解吸量 { get; set; }
            public string 粉碎后第2份煤样重 { get; set; }
            public string 第2份煤样解吸量 { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string a { get; set; }
            public string b { get; set; }
            //public string Wc { get; set; }    // 和下面的重复
            public string Mad { get; set; }
            public string Aad { get; set; }
            public string Vad { get; set; }
            public string K { get; set; }
            public string r { get; set; }
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
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
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
            public string 实验室测试人员 { get; set; }
            public string 审核人员 { get; set; }
            public string 出报告时间 { get; set; }
            public string 备注 { get; set; }
        }

        // 当前程序目录
        static string CurrentDir = AppDomain.CurrentDomain.BaseDirectory;

        // 用于存放系统数据的文件夹路径
        string SystemDataPath = Path.Combine(CurrentDir, "SystemData");

        /// <summary>
        /// 按钮1点击事件：复制图片并保存用户数据为二进制文件
        /// </summary>
        public void SaveButton_Click(object sender, EventArgs e)
        {
            // 生成时间戳，用于命名文件
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // 如果 SystemData 文件夹不存在，则创建
            if (!Directory.Exists(SystemDataPath))
            {
                Directory.CreateDirectory(SystemDataPath);
                Console.WriteLine("SystemData 文件夹不存在，已创建");
            }

            // === 复制图片 ===
            // 定义原始图片路径
            string imageSourcePath = Path.Combine(CurrentDir, "Python_embed", "Python", "images", "output_image.png");

            // 定义新的图片名称和路径
            string newImageName = $"{timestamp}_Image.png";
            string imageTargetPath = Path.Combine(SystemDataPath, newImageName);

            // 将图片复制到目标路径，若已存在则覆盖
            File.Copy(imageSourcePath, imageTargetPath, true);
            Console.WriteLine($"图片已复制到：{imageTargetPath}");

            // 生成文档
            _mainForm.tab6_5_GenerateReportToDatabase(timestamp);

            // === 保存用户数据 ===
            try
            {
                // 创建用户数据对象，这里是模拟数据，也可以从界面控件读取
                var user = new UserData
                {
                    ID = timestamp.ToString(),

                    矿井名称 = _mainForm.MineNameTextBox.Text,
                    取样地点 = _mainForm.SamplingSpotTextBox.Text,
                    取样时间 = _mainForm.SamplingTimeDateTimePicker.Text,
                    埋深 = _mainForm.BurialDepthTextBox.Text,
                    煤层 = _mainForm.CoalSeamTextBox.Text,
                    煤样编号 = _mainForm.SampleNumTextBox.Text,
                    实验室大气压力 = _mainForm.LabAtmPressureTextBox.Text,
                    实验室温度 = _mainForm.LabTempTextBox.Text,
                    取样方式 = _mainForm.SampleModeComboBox.Text,
                    原煤水分 = _mainForm.RawCoalMoistureTextBox.Text,
                    取样深度 = _mainForm.SamplingDepthTextBox.Text,
                    井下大气压力 = _mainForm.UndAtmPressureTextBox.Text,
                    井下环境温度 = _mainForm.UndTempTextBox.Text,
                    煤样重量 = _mainForm.SampleWeightTextBox.Text,
                    煤样水分 = _mainForm.MoistureSampleTextBox.Text,
                    量管初始体积 = _mainForm.InitialVolumeTextBox.Text,

                    井下解吸量W11 = _mainForm.UndDesorpCalTextBox.Text,
                    瓦斯损失量W12 = _mainForm.SampLossVolTextBox.Text,

                    实验室常压解吸W2 = _mainForm.DesorpVolNormalCalTextBox.Text,
                    粉碎后第1份煤样重 = _mainForm.Sample1WeightTextBox.Text,
                    第1份煤样解吸量 = _mainForm.S1DesorpVolCalTextBox.Text,
                    粉碎后第2份煤样重 = _mainForm.Sample2WeightTextBox.Text,
                    第2份煤样解吸量 = _mainForm.S2DesorpVolCalTextBox.Text,

                    a = _mainForm.AdsorpConstATextBox.Text,
                    b = _mainForm.AdsorpConstBTextBox.Text,
                    Mad = _mainForm.MadTextBox.Text,
                    Aad = _mainForm.AadTextBox.Text,
                    Vad = _mainForm.VadTextBox.Text,
                    K = _mainForm.PorosityTextBox.Text,
                    r = _mainForm.AppDensityTextBox.Text,

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

                    W1 = _mainForm.W1_TextBox.Text,
                    W2 = _mainForm.W2_TextBox.Text,
                    W3 = _mainForm.W3_TextBox.Text,
                    Wa = _mainForm.Wa_TextBox.Text,
                    Wc = _mainForm.Wc_TextBox.Text,
                    W = _mainForm.W_TextBox.Text,
                    P = _mainForm.P_TextBox.Text,

                    实验室测试人员 = _mainForm.LabTestersTextBox.Text,
                    审核人员 = _mainForm.AuditorTextBox.Text,
                    出报告时间 = _mainForm.dateTimePicker1.Text,
                    备注 = _mainForm.RemarkTextBox.Text,
                };


                // 定义要保存的二进制数据文件路径
                string dataFilePath = Path.Combine(SystemDataPath, $"{timestamp}_BinData.bin");

                // 使用二进制格式化器将对象序列化保存到文件中
                using (FileStream fs = new FileStream(dataFilePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, user);
                }

                Console.WriteLine($"二进制保存成功，文件路径：{dataFilePath}");
                MessageBox.Show("保存成功！", "提示：");
            }
            catch (Exception ex)
            {
                Console.WriteLine("保存失败：" + ex.Message);
                MessageBox.Show("保存失败：" + ex.Message, "提示：");
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
                全部显示();
            }
            else
            {
                查询显示(Keyword);
            }
        }

        private void ReloadTableData()
        {
            // 解绑事件，避免触发 SelectionChanged
            _mainForm.dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;

            try
            {
                List<UserData> filteredUsers = LoadAllUsers();
                var sortableList = new SortableBindingList<UserData>(filteredUsers);

                _mainForm.dataGridView1.DataSource = null;
                _mainForm.dataGridView1.DataSource = sortableList;
                _mainForm.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            finally
            {
                // 绑定事件
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
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string systemDataPath = Path.Combine(currentDir, "SystemData");

            if (!Directory.Exists(systemDataPath))
            {
                Directory.CreateDirectory(systemDataPath);
                Console.WriteLine("[Log] SystemData 文件夹不存在，已创建。");
            }

            string outputPath = Path.Combine(systemDataPath, $"{name}_Doc.docx");
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

                ReloadTableData();

                //MessageBox.Show("文件已移动到回收目录！");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"移动文件时发生错误：{ex.Message}");
            }
        }


        private string _currentKeyword = "";
        void 全部显示()
        {
            _currentKeyword = "";
            try
            {
                // 如果 SystemData 文件夹不存在，则提示并退出
                if (!Directory.Exists(SystemDataPath))
                {
                    Console.WriteLine("BinData 文件夹不存在！");
                    return;
                }

                // 获取所有以 .bin 结尾的用户数据文件
                string[] files = Directory.GetFiles(SystemDataPath, "*.bin");
                if (files.Length == 0)
                {
                    Console.WriteLine("没有找到数据文件！");
                    return;
                }

                // 用于保存所有反序列化后的用户数据
                List<UserData> allUsers = new List<UserData>();
                BinaryFormatter formatter = new BinaryFormatter();

                // 遍历每个数据文件，反序列化并添加到列表中
                foreach (var file in files)
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        UserData user = (UserData)formatter.Deserialize(fs);
                        allUsers.Add(user);
                    }
                }

                // 将数据绑定到主窗体的 DataGridView 控件上
                var sortableList = new SortableBindingList<UserData>(allUsers);
                _mainForm.dataGridView1.DataSource = null;              // 先清空数据源
                _mainForm.dataGridView1.DataSource = sortableList;      // 设置新数据源
                //自动调节宽度
                _mainForm.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                Console.WriteLine("数据加载完成，已绑定到dataGridView1。");
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取失败：" + ex.Message);
            }
        }
        
        private List<UserData> LoadAllUsers()
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
        private void 查询显示(string filterKeyword)
        {
            try
            {
                List<UserData> allUsers = LoadAllUsers();

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
                _mainForm.dataGridView1.DataSource = null;
                _mainForm.dataGridView1.DataSource = sortableList;
                _mainForm.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // 绑定高亮事件（防止重复绑定）
                _mainForm.dataGridView1.CellPainting -= DataGridView1_CellPainting;
                _mainForm.dataGridView1.CellPainting += DataGridView1_CellPainting;

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



    }
}
