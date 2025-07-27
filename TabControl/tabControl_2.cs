using AntdUI;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Color = System.Drawing.Color;
using ComboBox = System.Windows.Forms.ComboBox;
using Control = System.Windows.Forms.Control;
using Font = System.Drawing.Font;

namespace GasFormsApp.TabControl
{
    /// <summary>
    /// 处理主窗体中第二个标签页(tabPage2)的所有功能
    /// 包括数据导入、计算、图表绘制、临时保存和恢复等
    /// </summary>
    internal class tabControl_2
    {
        private MainForm _mainForm; // 主窗体引用

        // 定义要监控的所有文本框
        private List<Control> _trackedControls = new List<Control>();

        /// <summary>
        /// 构造函数，初始化与主窗体的关联
        /// </summary>
        /// <param name="form">主窗体实例</param>
        public tabControl_2(MainForm form)
        {
            _mainForm = form;

            // 设置工具提示
            _mainForm.toolTip1.SetToolTip(_mainForm.DrawCurvesButton, "计算(Ctrl + D)");
            _mainForm.toolTip1.SetToolTip(_mainForm.BulkImportButton, "批量导入(Ctrl + I)");
            _mainForm.toolTip1.SetToolTip(_mainForm.tabPage2TemporarySavingButton, "临时保存(Ctrl + Shift + S)");
            _mainForm.toolTip1.SetToolTip(_mainForm.tabPage2RecoverDataButton, "恢复数据(Ctrl + R)");
            _mainForm.toolTip1.SetToolTip(_mainForm.pictureBox3, "右键导出图片");
            _mainForm.toolTip1.SetToolTip(_mainForm.DataExportButton, "数据导出(Ctrl + O)");

            // 注册事件处理程序
            _mainForm.DrawCurvesButton.Click += DrawCurvesButton_Click;
            _mainForm.BulkImportButton.Click += BulkImportButton_Click;
            _mainForm.tabPage2DoubleBufferedPanel2.SizeChanged += tabPage2DoubleBufferedPanel2_SizeChanged;
            _mainForm.ExportImageButton.Click += ExportImageButton_Click;
            _mainForm.tabPage2TemporarySavingButton.Click += tabPage2TemporarySavingButton_Click;
            _mainForm.tabPage2RecoverDataButton.Click += tabPage2RecoverDataButton_Click;
            _mainForm.DataExportButton.Click += DataExportButton_Click;

            _mainForm.TypeOfDestructionComboBox3.MouseWheel += TypeOfDestructionComboBox3_MouseWheel;

            _mainForm.pictureBox3.MouseDown += pictureBox3_MouseDown;
            _mainForm.导出图片ToolStripMenuItem.Click += 导出图片ToolStripMenuItem_Click;

            _mainForm.tabPage2DoubleBufferedPanel2.MouseWheel += tabPage2DoubleBufferedPanel2_MouseWheel;

            // 批量注册内容更改事件
            InitializeTextMonitoring();
        }

        private void tabPage2DoubleBufferedPanel2_MouseWheel(object sender, MouseEventArgs e)
        {
            // 目标 FlowLayoutPanel 控件
            var targetPanel = _mainForm.tabPage2DoubleBufferedFlowLayoutPanel1;

            // 计算新的滚动位置
            int newY = -targetPanel.AutoScrollPosition.Y - e.Delta;

            // 设置滚动（只垂直方向，横向可自行加）
            targetPanel.AutoScrollPosition = new Point(0, newY);
        }
        private void InitializeTextMonitoring()
        {
            // 添加所有需要监控的文本框（可通过遍历容器控件自动发现）
            _trackedControls.AddRange(
                new Control[] {
                    _mainForm.dateTimePicker2,
                    _mainForm.dateTimePicker3,
                    _mainForm.TypeOfDestructionComboBox3,
                    _mainForm.dateTimePicker5,
                    _mainForm.dateTimePicker4,
                    _mainForm.t0TextBox,
                }
            );
            // 动态添加 DesorbTextBox1 ~ DesorbTextBox60
            for (int i = 1; i <= 60; i++)
            {
                string controlName = $"DesorbTextBox{i}";
                //Control? textBox = _mainForm.Controls.Find(controlName, true).FirstOrDefault();
                Control textBox = _mainForm.Controls.Find(controlName, true).FirstOrDefault();
                if (textBox != null) // 手动检查 null
                {
                    _trackedControls.Add(textBox);
                }
                else
                {
                    // 如果找不到控件，可以记录日志或抛出异常
                    Debug.WriteLine($"未找到控件: {controlName}");
                }
            }
            // 动态添加 DataNumTextBox31 ~ DataNumTextBox60
            for (int i = 31; i <= 60; i++)
            {
                string controlName = $"DataNumTextBox{i}";
                Control textBox = _mainForm.Controls.Find(controlName, true).FirstOrDefault();

                if (textBox != null)
                {
                    _trackedControls.Add(textBox);
                }
                else
                {
                    Debug.WriteLine($"未找到控件: {controlName}");
                }
            }

            // 批量绑定事件
            foreach (var control in _trackedControls)
            {
                if (control is Input textBox)
                    textBox.TextChanged += Control_TextChanged;
                else if (control is ComboBox comboBox)
                    comboBox.TextChanged += Control_TextChanged;
                else if (control is DateTimePicker dateTimePicker)
                    dateTimePicker.ValueChanged += Control_TextChanged; // 监控日期变化
            }
        }
        // 统一事件处理
        private void Control_TextChanged(object sender, EventArgs e)
        {
            var changedControl = (Control)sender;
            string currentValue;

            if (changedControl is Input textBox)
                currentValue = textBox.Text;
            else if (changedControl is ComboBox comboBox)
                currentValue = comboBox.Text;
            else if (changedControl is DateTimePicker dateTimePicker)
                currentValue = dateTimePicker.Value.ToString("yyyy-MM-dd");
            else
                currentValue = string.Empty;

            Console.WriteLine($"{changedControl.Name} 的值已修改: {currentValue}");

            _mainForm.tabPage2.Text = "*井下解吸*";
        }


        // 禁止滚轮选择破坏类型
        private void TypeOfDestructionComboBox3_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        /// <summary>
        /// 临时数据序列化类，保存tabPage2的所有相关数据
        /// </summary>
        [Serializable]
        public class tab2TempData
        {
            public string _dateTimePicker2 { get; set; } // 日期时间控件2的值
            public string _dateTimePicker5 { get; set; } // 日期时间控件5的值
            public string _dateTimePicker3 { get; set; } // 日期时间控件3的值
            public string _dateTimePicker4 { get; set; } // 日期时间控件4的值
            public string comboBox3 { get; set; }        // 下拉框3的值
            public string t0TextBox { get; set; }        // t0文本框的值

            public List<string> DesorbTextList { get; set; } = new List<string>();  // 解吸量文本框值列表
            public List<string> DataNumTextList { get; set; } = new List<string>(); // 数据编号文本框值列表
            public string SampLossVolText { get; set; }  // 样品损失体积
            public string DesVolUndText { get; set; }    // 井下解吸体积
            public string UndDesorpCalText { get; set; } // 井下解吸校准体积

            public byte[] ImageBytes { get; set; }       // 图表图片的字节数组
        }

        /// <summary>
        /// 将Image转换为字节数组
        /// </summary>
        /// <param name="img">要转换的图像</param>
        /// <returns>图像的字节数组</returns>
        private byte[] ImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 获取指定名称模式的文本框值
        /// </summary>
        /// <param name="parent">父控件</param>
        /// <param name="baseName">基础名称</param>
        /// <param name="end">结束编号</param>
        /// <param name="start">起始编号(默认为1)</param>
        /// <returns>文本框值列表</returns>
        public List<string> GetTextBoxValues(Control parent, string baseName, int end, int start = 1)
        {
            var list = new List<string>();
            for (int i = start; i <= end; i++)
            {
                var ctl = parent.Controls.Find($"{baseName}{i}", true).FirstOrDefault();
                list.Add(ctl is Input tb ? tb.Text : "");
            }
            return list;
        }

        /// <summary>
        /// 临时保存按钮点击事件处理
        /// </summary>
        public void tabPage2TemporarySavingButton_Click(object sender, EventArgs e)
        {
            // 创建临时数据对象并填充当前值
            tab2TempData data = new tab2TempData
            {
                _dateTimePicker2 = _mainForm.dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                _dateTimePicker3 = _mainForm.dateTimePicker3.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                _dateTimePicker4 = _mainForm.dateTimePicker4.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                _dateTimePicker5 = _mainForm.dateTimePicker5.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                comboBox3 = _mainForm.TypeOfDestructionComboBox3.Text,
                t0TextBox = _mainForm.t0TextBox.Text,
                DesorbTextList = GetTextBoxValues(_mainForm, "DesorbTextBox", 60),
                DataNumTextList = GetTextBoxValues(_mainForm, "DataNumTextBox", 60, 31),
                SampLossVolText = _mainForm.SampLossVolTextBox.Text,
                DesVolUndText = _mainForm.DesVolUndTextBox.Text,
                UndDesorpCalText = _mainForm.UndDesorpCalTextBox.Text,
            };
            data.ImageBytes = _mainForm.pictureBox3.Image != null ? ImageToBytes(_mainForm.pictureBox3.Image) : null;

            //// 确保临时数据目录存在
            //string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            //string tempFolder = Path.Combine(currentDir, "TempData");
            //if (!Directory.Exists(tempFolder))
            //{
            //    Directory.CreateDirectory(tempFolder);
            //}

            //string savePath = Path.Combine(tempFolder, "tabPage2_temp.bin");
            // 确保临时数据目录存在
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string tempFolder = Path.Combine(appData, "瓦斯含量测定数据分析系统", "TempData");
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }

            string savePath = Path.Combine(tempFolder, "tabPage2_temp.bin");

            try
            {
                // 使用二进制格式化器序列化数据
                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
#pragma warning disable SYSLIB0011
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    formatter.Serialize(fs, data);
#pragma warning restore SYSLIB0011
                }

                //MessageBox.Show("保存成功！");

                // 修改了数据，保存未计算
                if(_mainForm.tabPage2.Text == "*井下解吸*")
                {
                    // 去掉前面一个“*”
                    _mainForm.tabPage2.Text = "井下解吸*";
                }
                else if (_mainForm.tabPage2.Text == "*井下解吸")
                {
                    // 去掉前面一个“*”
                    _mainForm.tabPage2.Text = "井下解吸";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 将字节数组转换为Image
        /// </summary>
        /// <param name="bytes">图像字节数组</param>
        /// <returns>Image对象</returns>
        private Image BytesToImage(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        /// <summary>
        /// 恢复数据按钮点击事件处理
        /// </summary>
        public void tabPage2RecoverDataButton_Click(object sender, EventArgs e)
        {
            //string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            //string loadPath = Path.Combine(currentDir, "TempData", "tabPage2_temp.bin");

            //if (!File.Exists(loadPath))
            //{
            //    MessageBox.Show("找不到临时保存的数据！");
            //    return;
            //}
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string tempFolder = Path.Combine(appData, "瓦斯含量测定数据分析系统", "TempData");
            string loadPath = Path.Combine(tempFolder, "tabPage2_temp.bin");

            if (!File.Exists(loadPath))
            {
                MessageBox.Show("找不到临时保存的数据！");
                return;
            }


            try
            {
                // 从二进制文件反序列化数据
                using (FileStream fs = new FileStream(loadPath, FileMode.Open))
                {
#pragma warning disable SYSLIB0011
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    tab2TempData data = (tab2TempData)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011

                    // 恢复日期时间控件值
                    // 安全赋值，只在值变化时才设置
                    if (DateTime.TryParse(data._dateTimePicker2, out DateTime newValue2))
                    {
                        if (_mainForm.dateTimePicker2.Value != newValue2)
                        {
                            _mainForm.dateTimePicker2.Value = newValue2;
                        }
                    }

                    if (DateTime.TryParse(data._dateTimePicker3, out DateTime newValue3))
                    {
                        if (_mainForm.dateTimePicker3.Value != newValue3)
                        {
                            _mainForm.dateTimePicker3.Value = newValue3;
                        }
                    }

                    if (DateTime.TryParse(data._dateTimePicker4, out DateTime newValue4))
                    {
                        if (_mainForm.dateTimePicker4.Value != newValue4)
                        {
                            _mainForm.dateTimePicker4.Value = newValue4;
                        }
                    }

                    if (DateTime.TryParse(data._dateTimePicker5, out DateTime newValue5))
                    {
                        if (_mainForm.dateTimePicker5.Value != newValue5)
                        {
                            _mainForm.dateTimePicker5.Value = newValue5;
                        }
                    }



                    // 恢复下拉框和文本框值
                    _mainForm.TypeOfDestructionComboBox3.Text = data.comboBox3;
                    _mainForm.t0TextBox.Text = data.t0TextBox;

                    // 恢复解吸量文本框值
                    for (int i = 1; i <= 60; i++)
                    {
                        var ctl = _mainForm.Controls.Find($"DesorbTextBox{i}", true).FirstOrDefault();
                        if (ctl is Input tb && data.DesorbTextList.Count >= i)
                        {
                            tb.Text = data.DesorbTextList[i - 1];
                        }
                    }
                    
                    // 恢复数据编号文本框值(31-60)
                    for (int i = 31; i <= 60; i++)
                    {
                        var ctl = _mainForm.Controls.Find($"DataNumTextBox{i}", true).FirstOrDefault();
                        int index = i - 31;
                        if (ctl is Input tb && data.DataNumTextList.Count > index)
                        {
                            tb.Text = data.DataNumTextList[index];
                        }
                    }
                    
                    // 恢复计算结果值
                    _mainForm.SampLossVolTextBox.Text = data.SampLossVolText;
                    _mainForm.DesVolUndTextBox.Text = data.DesVolUndText;
                    _mainForm.UndDesorpCalTextBox.Text = data.UndDesorpCalText;

                    // 恢复图片
                    if (data.ImageBytes != null)
                    {
                        _mainForm.pictureBox3.Image = BytesToImage(data.ImageBytes);
                        _mainForm.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    MessageBox.Show("数据已恢复！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 面板大小改变事件处理
        /// </summary>
        public void tabPage2DoubleBufferedPanel2_SizeChanged(object sender, EventArgs e)
        {
            // 计算新宽度和高度
            int newWidth = _mainForm.tabPage2DoubleBufferedPanel2.ClientSize.Width / 1 - _mainForm.tabPage2DoubleBufferedPanel2.ClientSize.Width / 100;
            int newHeight = _mainForm.tabPage2DoubleBufferedPanel2.ClientSize.Height / 1 - _mainForm.tabPage2DoubleBufferedPanel2.ClientSize.Height / 10;

            // 调试输出
            //Console.WriteLine($"主界面 宽度: {_mainForm.Width}, 高度: {_mainForm.Height}");
            //Console.WriteLine($"宽度: {newWidth}, 高度: {newHeight}");

            // 重置面板宽度
            _mainForm.tabPage2panel7.Width = 1;
            _mainForm.tabPage2panel8.Width = 1;
            _mainForm.tabPage2panel9.Width = 1;
            _mainForm.tabPage2panel10.Width = 1;

            // 默认布局(大尺寸)
            _mainForm.tabPage2panel6.Width = 806;
            _mainForm.tabPage2panel6.Height = 130;
            _mainForm.BulkImportButton.Location = new Point(399, 13);
            _mainForm.DrawCurvesButton.Location = new Point(671, 13);
            _mainForm.ExportImageButton.Location = new Point(542, 13);
            _mainForm.tabPage2TemporarySavingButton.Location = new Point(542, 78);
            _mainForm.tabPage2RecoverDataButton.Location = new Point(671, 78);
            
            _mainForm.DataExportButton.Location = new Point(399, 78);

            _mainForm.tabPage2panel5.Size = new Size(321, 345);
            _mainForm.tabPage2panel5.Margin = new Padding(3, 3, 3, 3);

            newHeight = _mainForm.tabPage2DoubleBufferedPanel2.Height;
            // 根据宽度调整布局
            if (newWidth <= 840) // 小尺寸布局
            {
                newWidth = 428;
                _mainForm.tabPage2panel6.Width = 403;
                _mainForm.tabPage2panel6.Height = 262;
                _mainForm.BulkImportButton.Location = new Point(7, 133);
                _mainForm.DrawCurvesButton.Location = new Point(279, 133);
                _mainForm.ExportImageButton.Location = new Point(150, 133);
                _mainForm.tabPage2TemporarySavingButton.Location = new Point(150, 203);
                _mainForm.tabPage2RecoverDataButton.Location = new Point(279, 203);

                _mainForm.DataExportButton.Location = new Point(7, 203);

                _mainForm.tabPage2panel5.Size = new Size(509, 345);
                _mainForm.tabPage2panel5.Margin = new Padding(45, 3, 3, 3);
            }
            else if (newWidth > 840 && newWidth <= 1165) // 中尺寸布局
            {
                newWidth = 840;
                _mainForm.tabPage2panel9.Width = 240;
            }
            else if (newWidth > 1165) // 大尺寸布局
            {
                newWidth = 1165;
                
                //if(_mainForm.tabPage2DoubleBufferedPanel2.Height>625)
                //{
                //    newHeight = _mainForm.tabPage2DoubleBufferedPanel2.Height;
                //}
                //else
                //{
                //    newHeight = 630;
                //}
                int a = 161;
                _mainForm.tabPage2panel7.Width = a;
                _mainForm.tabPage2panel8.Width = a;
                _mainForm.tabPage2panel9.Width = 1;
                _mainForm.tabPage2panel10.Width = a;
            }

            Console.WriteLine($"宽度: {_mainForm.tabPage2DoubleBufferedPanel2.Width}, 高度: {_mainForm.tabPage2DoubleBufferedPanel2.Height}");

            if (newHeight > 625) newHeight = 625;

            //509, 345
            //321, 345


            // 设置流式布局面板大小
            _mainForm.tabPage2DoubleBufferedFlowLayoutPanel1.Width = newWidth;
            _mainForm.tabPage2DoubleBufferedFlowLayoutPanel1.Height = newHeight;

            // 居中定位
            _mainForm.tabPage2DoubleBufferedFlowLayoutPanel1.Left = (_mainForm.tabPage2DoubleBufferedPanel2.ClientSize.Width - newWidth) / 2;
            _mainForm.tabPage2DoubleBufferedFlowLayoutPanel1.Top = (_mainForm.tabPage2DoubleBufferedPanel2.ClientSize.Height - newHeight) / 2;

            _mainForm.tabPage2panel1.Width = SystemInformation.VerticalScrollBarWidth;
            _mainForm.tabPage2panel1.Height = newHeight;
            Point location = _mainForm.tabPage2DoubleBufferedFlowLayoutPanel1.Location;
            int x = location.X;
            int y = location.Y;
            _mainForm.tabPage2panel1.Location = new Point(newWidth + x - SystemInformation.VerticalScrollBarWidth, y);

            // 设置 panel1 的高度等于系统水平滚动条的高度
            _mainForm.tabPage2panel2.Height = SystemInformation.HorizontalScrollBarHeight;
            // 设置宽度等于 FlowLayoutPanel 的新宽度
            _mainForm.tabPage2panel2.Width = newWidth;
            // FlowLayoutPanel 的位置
            //Point location = _mainForm.tabPage2DoubleBufferedFlowLayoutPanel1.Location;
             x = location.X;
             y = location.Y;
            // 放到底部：Y 坐标等于 FlowLayoutPanel 的顶部位置 + 高度 - 滚动条高度
            _mainForm.tabPage2panel2.Location = new Point(x, y + newHeight - SystemInformation.HorizontalScrollBarHeight);

        }

        /// <summary>
        /// 验证数据编号文本框(31-60)的输入
        /// </summary>
        /// <param name="textBox">要验证的文本框</param>
        private void ValidateNumericDataNumTextBox31_60(Input textBox)
        {
            string input = textBox.Text;
            textBox.BackColor = Color.FromArgb(192, 192, 255); // 重置颜色

            if (input.Contains(" ")) // 包含空格
            {
                textBox.BackColor = Color.Red;
            }
            else if (string.IsNullOrWhiteSpace(input)) // 空值
            {
                textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
            }
            else if (!double.TryParse(input, out double value) || value < 0 || value <= 30) // 非数字或无效值
            {
                textBox.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// 验证数值文本框的输入
        /// </summary>
        /// <param name="textBox">要验证的文本框</param>
        private void ValidateNumericTextBox(Input textBox)
        {
            string input = textBox.Text;
            textBox.BackColor = SystemColors.Window; // 重置颜色

            if (input.Contains(" ")) // 包含空格
            {
                textBox.BackColor = Color.Red;
            }
            else if (string.IsNullOrWhiteSpace(input)) // 空值
            {
                textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
            }
            else if (!double.TryParse(input, out double value) || value < 0) // 非数字或负值
            {
                textBox.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// 验证文本框是否为空
        /// </summary>
        /// <param name="textBox">要验证的文本框</param>
        private void ValidateEmptyTextBox(Input textBox)
        {
            string input = textBox.Text;
            textBox.BackColor = SystemColors.Window; // 重置背景色

            if (string.IsNullOrWhiteSpace(input)) // 空值
            {
                textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
            }
        }

        /// <summary>
        /// 定时检查输入数据
        /// </summary>
        public void TabControl_2_InputCheckTimer_Tick()
        {
            // 计算时间差并显示在t0TextBox中
            DateTime time1 = _mainForm.dateTimePicker4.Value;
            DateTime time2 = _mainForm.dateTimePicker5.Value;

            TimeSpan diff = time1 - time2;
            double minutes = diff.TotalMinutes;
            // 四舍五入到两位小数
            double roundedMinutes = Math.Round(minutes, 2);
            // 显示
            _mainForm.t0TextBox.Text = roundedMinutes.ToString("F2");



            // 验证t0TextBox输入
            string input = _mainForm.t0TextBox.Text;
            _mainForm.t0TextBox.BackColor = System.Drawing.Color.PeachPuff;
            if (input.Contains(" "))
            {
                _mainForm.t0TextBox.BackColor = Color.Red;
            }
            else if (string.IsNullOrWhiteSpace(input))
            {
                _mainForm.t0TextBox.BackColor = _mainForm.t0TextBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
            }
            else if (!double.TryParse(input, out double value) || value < 0 || value > 5)
            {
                _mainForm.t0TextBox.BackColor = Color.Red;
            }

            // 验证数据编号文本框(31-60)
            for (int i = 31; i <= 60; i++)
            {
                string controlName = "DataNumTextBox" + i;
                Control ctl = _mainForm.Controls.Find(controlName, true).FirstOrDefault();
                if (ctl is Input tb)
                {
                    ValidateNumericDataNumTextBox31_60(tb);
                }
            }

            // 验证解吸量文本框(1-60)
            for (int i = 1; i <= 60; i++)
            {
                string controlName = "DesorbTextBox" + i;
                Control ctl = _mainForm.Controls.Find(controlName, true).FirstOrDefault();
                if (ctl is Input tb)
                {
                    ValidateNumericTextBox(tb);
                }
            }

            // 执行数据合法性验证
            DigitalLegitimacyVerification_Tick();
        }

        /// <summary>
        /// 数据合法性验证
        /// 检查解吸量数据是否单调递增
        /// </summary>
        public void DigitalLegitimacyVerification_Tick()
        {
            List<Input> boxes = new List<Input>();

            // 收集所有解吸量文本框
            for (int i = 1; i <= 60; i++)
            {
                var tb = _mainForm.Controls.Find("DesorbTextBox" + i, true).FirstOrDefault() as Input;
                if (tb != null)
                {
                    boxes.Add(tb);
                    // 恢复默认颜色与样式
                    tb.ForeColor = Color.Black;
                    tb.Font = new Font(tb.Font, FontStyle.Regular);
                }
                else
                {
                    Console.WriteLine($"未找到 DesorbTextBox{i}");
                }
            }

            double lastValue = double.MinValue;
            bool hasLastValue = false;
            bool isValid = true;

            // 检查数据是否单调递增
            for (int i = 0; i < boxes.Count; i++)
            {
                string text = boxes[i].Text.Trim();
                if (string.IsNullOrEmpty(text))
                    continue;

                if (!double.TryParse(text, out double currentValue)) // 非数字
                {
                    boxes[i].ForeColor = Color.Blue;
                    boxes[i].Font = new Font(boxes[i].Font.FontFamily, boxes[i].Font.Size, FontStyle.Bold | FontStyle.Italic);
                    isValid = false;
                    continue;
                }

                if (((int)currentValue) % 2 != 0)
                {
                    boxes[i].BackColor = Color.Green;
                    //boxes[i].ForeColor = Color.Green;
                    //boxes[i].Font = new Font(boxes[i].Font.FontFamily, boxes[i].Font.Size, FontStyle.Bold | FontStyle.Italic);
                    isValid = false;
                    continue;
                }

                if (hasLastValue && currentValue < lastValue) // 非递增
                {
                    var errorFont = new Font(boxes[i].Font.FontFamily, boxes[i].Font.Size, FontStyle.Bold | FontStyle.Italic);
                    boxes[i].ForeColor = Color.Blue;
                    boxes[i].Font = errorFont;

                    // 标记相邻的异常数据
                    if (i - 1 >= 0)
                    {
                        boxes[i - 1].ForeColor = Color.Red;
                        boxes[i - 1].Font = errorFont;
                    }

                    if (i + 1 < boxes.Count)
                    {
                        boxes[i + 1].ForeColor = Color.Red;
                        boxes[i + 1].Font = errorFont;
                    }

                    isValid = false;
                }

                lastValue = currentValue;
                hasLastValue = true;
            }
        }

        /// <summary>
        /// 计算井下解吸校准体积
        /// </summary>
        /// <param name="desorptionVolume">井下解吸体积</param>
        /// <param name="pressure">压强</param>
        /// <param name="temperature">温度</param>
        /// <returns>计算得到的校准体积</returns>
        public static double CalculateDesorptionCalibratedVolume(double desorptionVolume, double pressure, double temperature)
        {
            // 计算公式:
            // ((num2 * 273.2) * ((num3 - (4.905 * (1 - num2/800))) - (0.699 * e^(0.0597 * num4)))) / (101.3 * (273.2 + num4))
            double result = ((desorptionVolume * 273.2) *
                            ((pressure - (4.905 * (1.0 - (desorptionVolume / 800.0)))) - (0.699 * Math.Exp(0.0597 * temperature))))
                            / (101.3 * (273.2 + temperature));

            return result;
        }

        /// <summary>
        /// 读取Excel数据(调试用)
        /// </summary>
        /// <param name="filePath">Excel文件路径</param>
        public void ReadExcel(string filePath)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheets.First(); // 读取第一个sheet
                var rows = worksheet.RangeUsed().RowsUsed();

                // 输出所有单元格值
                foreach (var row in rows)
                {
                    foreach (var cell in row.Cells())
                    {
                        Console.Write(cell.Value.ToString() + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// 从Excel导入数据到文本框
        /// </summary>
        /// <param name="excelPath">Excel文件路径</param>
        public void ImportExcelToTextBoxes(string excelPath)
        {
            var workbook = new XLWorkbook(excelPath);
            var worksheet = workbook.Worksheet(1);

            int desorbIndex = 31; // 解吸量填充起始控件编号
            int dataNumIndex = 31; // 时间填充起始控件编号

            // 遍历Excel行
            for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
            {
                var timeCell = worksheet.Cell(row, 1); // 时间列
                var valueCell = worksheet.Cell(row, 2); // 值列

                _mainForm.X_YTextBox.Text = worksheet.Cell("C2").Value.ToString();
                _mainForm.CoalTypeComboBox.Text = worksheet.Cell("D2").Value.ToString();
                _mainForm.BurialDepthTextBox.Text = worksheet.Cell("E2").Value.ToString();

                if (int.TryParse(timeCell.GetValue<string>(), out int time))
                {
                    string desorbValue = valueCell.GetValue<string>();

                    // 1~30 按时间值匹配控件填充解吸量
                    if (time >= 1 && time <= 30)
                    {
                        string textBoxName = $"DesorbTextBox{time}";
                        var tb = _mainForm.Controls.Find(textBoxName, true).FirstOrDefault() as Input;
                        if (tb != null)
                            tb.Text = desorbValue;
                    }

                    // 31及以上，按顺序填充 DesorbTextBox 和 DataNumTextBox
                    if (time >= 31)
                    {
                        // 解吸量填充
                        string desorbBoxName = $"DesorbTextBox{desorbIndex}";
                        var desorbTb = _mainForm.Controls.Find(desorbBoxName, true).FirstOrDefault() as Input;
                        if (desorbTb != null)
                            desorbTb.Text = desorbValue;

                        // 时间填充
                        string dataNumBoxName = $"DataNumTextBox{dataNumIndex}";
                        var dataTb = _mainForm.Controls.Find(dataNumBoxName, true).FirstOrDefault() as Input;
                        if (dataTb != null)
                            dataTb.Text = time.ToString();

                        desorbIndex++;
                        dataNumIndex++;
                    }
                }
            }

        }

        /// <summary>
        /// 弹出对话框让用户选择Excel文件
        /// </summary>
        /// <returns>选择的文件路径，如果取消则为null</returns>
        public string SelectExcelFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // 设置初始目录
                var lastFolder = GasFormsApp.Settings.Default.LastFolder;
                openFileDialog.InitialDirectory = string.IsNullOrEmpty(lastFolder)
                    ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    : lastFolder;

                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "请选择Excel文件";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 保存最后访问的文件夹
                    GasFormsApp.Settings.Default.LastFolder = Path.GetDirectoryName(openFileDialog.FileName);
                    GasFormsApp.Settings.Default.Save();
                    return openFileDialog.FileName;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 批量导入按钮点击事件
        /// </summary>
        public void BulkImportButton_Click(object sender, EventArgs e)
        {
            string excelPath = SelectExcelFile();
            if (!string.IsNullOrEmpty(excelPath))
            {
                ImportExcelToTextBoxes(excelPath);
            }
            else
            {
                MessageBox.Show("未选择文件");
                return;
            }
        }

        public string SelectSaveExcelFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                var lastFolder = GasFormsApp.Settings.Default.LastFolder;
                saveFileDialog.InitialDirectory = string.IsNullOrEmpty(lastFolder)
                    ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    : lastFolder;

                saveFileDialog.Filter = "Excel 文件 (*.xlsx)|*.xlsx|Excel 97-2003 文件 (*.xls)|*.xls";
                saveFileDialog.Title = "请选择保存位置";
                saveFileDialog.FileName = "新建Excel文件.xlsx"; // 可以根据需要设置默认文件名

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GasFormsApp.Settings.Default.LastFolder = Path.GetDirectoryName(saveFileDialog.FileName);
                    GasFormsApp.Settings.Default.Save();
                    return saveFileDialog.FileName;
                }
                else
                {
                    return null;
                }
            }
        }

        //数据导出

        public void DataExportButton_Click(object sender, EventArgs e)
        {
            string excelPath = SelectSaveExcelFile();
            if (!string.IsNullOrEmpty(excelPath))
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Sheet1");
                        worksheet.Style.Font.FontName = "宋体";

                        // 写标题
                        worksheet.Cell(1, 1).Value = "时间";
                        worksheet.Cell(1, 2).Value = "解吸量";
                        worksheet.Cell(1, 3).Value = "取样地点坐标";
                        worksheet.Cell(1, 4).Value = "煤种";
                        worksheet.Cell(1, 5).Value = "埋深";

                        worksheet.Cell(2, 3).Value = _mainForm.X_YTextBox.Text;
                        worksheet.Cell(2, 4).Value = _mainForm.CoalTypeComboBox.Text;
                        if (double.TryParse(_mainForm.BurialDepthTextBox.Text, out double burialDepth))
                        {
                            worksheet.Cell(2, 5).Value = burialDepth;
                        }
                        else
                        {
                            // 可以根据需要做提示或默认值
                            worksheet.Cell(2, 5).Value = 0; // 或者提示用户输入有误
                        }


                        for (int i = 1; i <= 60; i++)
                        {
                            int row = i + 1; // Excel 第2行开始写数据

                            double timeValue = 0; // 时间列值
                            double desorbValue = 0; // 解吸量值

                            // 前30行（i=1~30）：时间列=固定数字1~30
                            if (i <= 30)
                            {
                                timeValue = i;
                            }
                            else
                            {
                                // 后30行：时间列=从 DataNumTextBox31~DataNumTextBox60 获取
                                var dataNumTextbox = _mainForm.Controls.Find($"DataNumTextBox{i}", true);
                                if (dataNumTextbox.Length > 0 && dataNumTextbox[0] is Input tbTime)
                                {
                                    double.TryParse(tbTime.Text, out timeValue);
                                }
                            }

                            // 解吸量列：从 DesorbTextBox1~DesorbTextBox60 获取
                            var desorbTextbox = _mainForm.Controls.Find($"DesorbTextBox{i}", true);
                            if (desorbTextbox.Length > 0 && desorbTextbox[0] is Input tbDesorb)
                            {
                                double.TryParse(tbDesorb.Text, out desorbValue);
                            }

                            // 写入 Excel
                            worksheet.Cell(row, 1).Value = timeValue;
                            worksheet.Cell(row, 2).Value = desorbValue;
                        }

                        // 自动调整列宽
                        //worksheet.Columns().AdjustToContents();
                        //worksheet.Columns(1, 2).AdjustToContents();
                        worksheet.Column(1).Width = 15; // 设置第一列宽度
                        worksheet.Column(2).Width = 20; // 设置第二列宽度
                        worksheet.Column(3).Width = 20;
                        worksheet.Column(4).Width = 20;
                        worksheet.Column(5).Width = 20;


                        workbook.SaveAs(excelPath);
                    }

                    MessageBox.Show("Excel 文件已成功导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("未选择文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 导出图片按钮点击事件
        /// </summary>
        public void ExportImageButton_Click(object sender, EventArgs e)
        {
            if (_mainForm.pictureBox3.Image == null)
            {
                MessageBox.Show("没有图片！");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "PNG 文件 (*.png)|*.png",
                Title = "导出图片"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _mainForm.pictureBox3.Image.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("图片导出成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出失败: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// 计算按钮点击事件
        /// </summary>
        public void DrawCurvesButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("你干么：" + 45);

            _mainForm.DesVolUndTextBox.Text = "0";
            _mainForm.UndDesorpCalTextBox.Text = "0";
            _mainForm.SampLossVolTextBox.Text = "0";
            
            // 收集所有解吸量文本框
            Input[] DesorbTextBox = new Input[60];
            for (int i = 0; i < 60; i++)
            {
                string controlName = $"DesorbTextBox{i + 1}";
                DesorbTextBox[i] = _mainForm.Controls.Find(controlName, true).FirstOrDefault() as Input;
            }

            // 获取t0值
            float t0_temp;
            float t0 = 0;
            if (float.TryParse(_mainForm.t0TextBox.Text, out t0_temp))
            {
                t0 = t0_temp;
            }
            else
            {
                MessageBox.Show("请输入有效的数字");
                return;
            }

            // 准备数据数组
            double[,] data = new double[DesorbTextBox.Length, 2];

            // 填充数据数组
            for (int i = 0; i < DesorbTextBox.Length; i++)
            {
                int a = i + 1;
                string controlName = "";
                double Sqrt_Value = 0.0;
                
                // 前30个数据点使用固定时间值
                if (i < 30)
                {
                    //controlName = $"DataNumLabel{a}";
                    //var textBox = _mainForm.Controls.Find(controlName, true).FirstOrDefault() as Input;
                    //Console.WriteLine($"取标签值:{controlName}->{textBox.Text}");
                    Sqrt_Value = Math.Sqrt(t0 + a);
                }
                else if (i >= 30) // 后30个数据点使用文本框中的时间值
                {
                    //Console.WriteLine($"{i}");
                    controlName = $"DataNumTextBox{a}";
                    var textBox = _mainForm.Controls.Find(controlName, true).FirstOrDefault() as Input;
                    Console.WriteLine($"取DataNumTextBox:{controlName}->{textBox.Text}");
                    if (!string.IsNullOrEmpty(textBox.Text))
                        Sqrt_Value = Math.Sqrt(t0 + (double)Convert.ToDecimal(textBox.Text.Trim()));
                }

                // 获取解吸量值
                double textBoxValue = 0.0;
                if (!string.IsNullOrWhiteSpace(DesorbTextBox[i].Text) &&
                    double.TryParse(DesorbTextBox[i].Text.Trim(), out double value))
                {
                    textBoxValue = value;
                }
                
                controlName = $"DesorbTextBox{i + 1}";
                Console.WriteLine($"数据框值:{controlName}->{textBoxValue}");

                // 存储数据: 第一列为时间平方根，第二列为解吸量
                data[i, 0] = Sqrt_Value;
                data[i, 1] = textBoxValue;
            }

            // 检查是否有足够的数据(至少5分钟)
            if (data[4, 1] == 0)
            {
                Console.WriteLine($"解吸时间不可少于5分钟");
                MessageBox.Show($"解吸时间不可少于5分钟", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 创建共享内存用于与Python通信
            const string mapName = "Local\\MySharedMemory";
            int totalBytes = DesorbTextBox.Length * 2 * sizeof(double);

            using (var mmf = MemoryMappedFile.CreateOrOpen(mapName, totalBytes))
            {
                // 写入数据到共享内存
                using (var writeAccessor = mmf.CreateViewAccessor(0, totalBytes))
                {
                    Console.WriteLine("[C#] 写入共享内存...");
                    int offset = 0;
                    for (int i = 0; i < DesorbTextBox.Length; i++)
                    {
                        Console.Write($"[C#] 第{i + 1}行: ");
                        for (int j = 0; j < 2; j++)
                        {
                            double val = data[i, j];
                            writeAccessor.Write(offset, val);
                            Console.Write($"{val} ");
                            offset += sizeof(double);
                        }
                        Console.WriteLine();
                    }
                }

                // 创建另一个共享内存用于接收结果
                const string memoryName = "Local\\tempSharedMemory";
                int temptotalBytes = 5 * sizeof(double);

                // 设置等待光标
                void SetWaitCursor(System.Windows.Forms.Control control, Cursor cursor)
                {
                    control.Cursor = cursor;
                    foreach (System.Windows.Forms.Control child in control.Controls)
                    {
                        SetWaitCursor(child, cursor);
                    }
                }
                
                SetWaitCursor(_mainForm, Cursors.WaitCursor);
                
                using (var tempmmf = MemoryMappedFile.CreateOrOpen(memoryName, temptotalBytes))
                {
                    try
                    {
                        // 启动Python进程进行计算
                        var pythonPath = @"Python_embed\python.exe"; // 嵌入式Python解释器
                        var scriptPath = @"Python_embed\Python\aaa.py"; // Python脚本路径

                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = pythonPath,
                            Arguments = $"\"{scriptPath}\"", // 加上引号防止路径带空格
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            CreateNoWindow = true
                        };

                        using (Process process = Process.Start(psi))
                        {
                            // 读取Python输出
                            string output = process.StandardOutput.ReadToEnd();
                            string error = process.StandardError.ReadToEnd();
                            process.WaitForExit();

                            Console.WriteLine("Python output:\n" + output);
                            //MessageBox.Show($"Python output:{output}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (!string.IsNullOrEmpty(error))
                            {
                                Console.WriteLine("Python error:\n" + error);
                                //MessageBox.Show($"Python error:{error}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"执行程序时发生错误：{ex.Message}");
                    }

                    // 读取Python计算的结果
                    using (var accessor = tempmmf.CreateViewAccessor(0, temptotalBytes))
                    {

                        double[] values = new double[5];
                        double lastValue = 0;

                        // 等待Python写入结果
                        int a = 0;
                        while (true)
                        {
                            lastValue = accessor.ReadDouble(4 * sizeof(double));
                            if (lastValue != 0 || a++ > 100 * 5)
                            {
                                break;
                            }
                            Thread.Sleep(10); // 避免忙等待
                        }

                        // 超时处理
                        if (a > 100 * 5)
                        {
                            SetWaitCursor(_mainForm, Cursors.Default);
                            MessageBox.Show($"计算失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // 获取当前用户 AppData\Roaming 路径
                        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                        // 拼接你的程序名和 Image 子目录
                        string imageDir = Path.Combine(appDataPath, "瓦斯含量测定数据分析系统", "Image");

                        // 拼接图片完整路径
                        string imagePath = Path.Combine(imageDir, "output_image.png");

                        // 设置图片显示模式
                        _mainForm.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                        try
                        {
                            if (File.Exists(imagePath))
                            {
                                // 使用流加载图片，避免文件锁定
                                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                                {
                                    _mainForm.pictureBox3.Image = Image.FromStream(fs);
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


                        // 读取所有计算结果
                        for (int i = 0; i < values.Length; i++)
                        {
                            values[i] = accessor.ReadDouble(i * sizeof(double));
                        }

                        // 找出最大解吸量值
                        double maxValue = double.MinValue;
                        for (int i = 1; i <= 60; i++)
                        {
                            string key = $"D{i:000}";
                            var textBox = _mainForm.Controls.Find($"DesorbTextBox{i}", true).FirstOrDefault() as Input;

                            if (textBox != null)
                            {
                                string text = textBox.Text.Trim();
                                if (double.TryParse(text, out double val))
                                {
                                    if (val > maxValue)
                                    {
                                        maxValue = val;
                                    }
                                }
                            }
                        }
                        
                        // 计算并显示各种体积值
                        float initialVolume;
                        if (float.TryParse(_mainForm.InitialVolumeTextBox.Text, out initialVolume))
                        {
                            // 计算井下解吸体积
                            MainForm.井下解吸体积 = maxValue - initialVolume;
                            _mainForm.DesVolUndTextBox.Text = MainForm.井下解吸体积.ToString("F2");

                            // 计算井下解吸校准体积
                            int temp1;
                            if (int.TryParse(_mainForm.UndTempTextBox.Text, out temp1))
                            {
                                float temp2;
                                if (float.TryParse(_mainForm.UndAtmPressureTextBox.Text, out temp2))
                                {
                                    MainForm.井下解吸校准体积 = CalculateDesorptionCalibratedVolume(MainForm.井下解吸体积, temp2, temp1);
                                    _mainForm.UndDesorpCalTextBox.Text = MainForm.井下解吸校准体积.ToString("F2");

                                    // 计算样品损失校准体积
                                    float temp3;
                                    if (float.TryParse(Math.Abs(values[1]).ToString("F2"), out temp3))
                                    {
                                        MainForm.井下解吸校准体积 = CalculateDesorptionCalibratedVolume(temp3, temp2, temp1);
                                        _mainForm.SampLossVolTextBox.Text = MainForm.井下解吸校准体积.ToString("F2");
                                        InsertChart.SetGasLossVolText(MainForm.井下解吸校准体积.ToString("F2"));
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("请输入有效的数字");
                        }
                        
                        // 恢复默认光标
                        SetWaitCursor(_mainForm, Cursors.Default);

                        // 修改了数据，未保存直接计算
                        if (_mainForm.tabPage2.Text == "*井下解吸*")
                        {
                            _mainForm.tabPage2.Text = "*井下解吸";
                        }
                        // 保存未计算
                        else if(_mainForm.tabPage2.Text == "井下解吸*")
                        {
                            _mainForm.tabPage2.Text = "井下解吸";
                        }

                        //// 显示计算完成提示
                        //MessageBox.Show($"计算完成！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _mainForm.tabPage2contextMenuStrip1.Show(_mainForm.pictureBox3, e.Location); // 弹出菜单
            }
        }
        private void 导出图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportImageButton_Click(sender,e);
        }
    }
}