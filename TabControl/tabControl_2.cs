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
using Control = System.Windows.Forms.Control;
using Font = System.Drawing.Font;
using TextBox = System.Windows.Forms.TextBox;

namespace GasFormsApp.TabControl
{
    internal class tabControl_2
    {
        private MainForm _mainForm;


        // 构造函数接收 TextBox 控件
        public tabControl_2(MainForm form)
        {
            _mainForm = form;


            _mainForm.toolTip1.SetToolTip(_mainForm.DrawCurvesButton, "计算(Ctrl + D)");
            _mainForm.toolTip1.SetToolTip(_mainForm.BulkImportButton, "批量导入(Ctrl + I)");

            // 注册回调函数
            _mainForm.DrawCurvesButton.Click += DrawCurvesButton_Click;
            _mainForm.BulkImportButton.Click += BulkImportButton_Click;
            _mainForm.tabPage2DoubleBufferedPanel2.SizeChanged += tabPage2DoubleBufferedPanel2_SizeChanged;
            _mainForm.ExportImageButton.Click += ExportImageButton_Click;

            _mainForm.tabPage2TemporarySavingButton.Click += tabPage2TemporarySavingButton_Click;
            _mainForm.tabPage2RecoverDataButton.Click += tabPage2RecoverDataButton_Click;
        }

        [Serializable]
        public class tab2TempData
        {
            public string _dateTimePicker2 { get; set; }
            public string _dateTimePicker5 { get; set; }
            public string _dateTimePicker3 { get; set; }
            public string _dateTimePicker4 { get; set; }
            public string comboBox3 { get; set; }
            public string t0TextBox { get; set; }

            public List<string> DesorbTextList { get; set; } = new List<string>();
            public List<string> DataNumTextList { get; set; } = new List<string>();
            public string SampLossVolText { get; set; }
            public string DesVolUndText { get; set; }
            public string UndDesorpCalText { get; set; }

            // 图片字段（序列化为 byte[]）
            public byte[] ImageBytes { get; set; }
        }

        private byte[] ImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

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


        // 临时保存按钮
        public void tabPage2TemporarySavingButton_Click(object sender, EventArgs e)
        {
            tab2TempData data = new tab2TempData
            {
                _dateTimePicker2 = _mainForm.dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                _dateTimePicker3 = _mainForm.dateTimePicker3.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                _dateTimePicker4 = _mainForm.dateTimePicker4.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                _dateTimePicker5 = _mainForm.dateTimePicker5.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                comboBox3 = _mainForm.comboBox3.Text,
                t0TextBox = _mainForm.t0TextBox.Text,
                DesorbTextList = GetTextBoxValues(_mainForm, "DesorbTextBox", 60),
                DataNumTextList = GetTextBoxValues(_mainForm, "DataNumTextBox", 60, 31),
                SampLossVolText = _mainForm.SampLossVolTextBox.Text,
                DesVolUndText = _mainForm.DesVolUndTextBox.Text,
                UndDesorpCalText = _mainForm.UndDesorpCalTextBox.Text,
            };
            data.ImageBytes = _mainForm.pictureBox3.Image != null ? ImageToBytes(_mainForm.pictureBox3.Image) : null;

            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string tempFolder = Path.Combine(currentDir, "TempData");

            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }

            string savePath = Path.Combine(tempFolder, "tabPage2_temp.bin");

            try
            {
                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
#pragma warning disable SYSLIB0011
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    formatter.Serialize(fs, data);
#pragma warning restore SYSLIB0011
                }

                MessageBox.Show("以二进制格式保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Image BytesToImage(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        public void tabPage2RecoverDataButton_Click(object sender, EventArgs e)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string loadPath = Path.Combine(currentDir, "TempData", "tabPage2_temp.bin");

            if (!File.Exists(loadPath))
            {
                MessageBox.Show("找不到临时保存的数据！");
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(loadPath, FileMode.Open))
                {
#pragma warning disable SYSLIB0011
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    tab2TempData data = (tab2TempData)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011

                    _mainForm.dateTimePicker2.Value = DateTime.Parse(data._dateTimePicker2);
                    _mainForm.dateTimePicker3.Value = DateTime.Parse(data._dateTimePicker3);
                    _mainForm.dateTimePicker4.Value = DateTime.Parse(data._dateTimePicker4);
                    _mainForm.dateTimePicker5.Value = DateTime.Parse(data._dateTimePicker5);
                    _mainForm.comboBox3.Text = data.comboBox3;
                    _mainForm.t0TextBox.Text = data.t0TextBox;

                    for (int i = 1; i <= 60; i++)
                    {
                        var ctl = _mainForm.Controls.Find($"DesorbTextBox{i}", true).FirstOrDefault();
                        if (ctl is TextBox tb && data.DesorbTextList.Count >= i)
                        {
                            tb.Text = data.DesorbTextList[i - 1];
                        }
                    }
                    // 恢复 DataNumTextBox31 ~ 60
                    for (int i = 31; i <= 60; i++)
                    {
                        var ctl = _mainForm.Controls.Find($"DataNumTextBox{i}", true).FirstOrDefault();
                        int index = i - 31;
                        if (ctl is TextBox tb && data.DataNumTextList.Count > index)
                        {
                            tb.Text = data.DataNumTextList[index];
                        }
                    }
                    _mainForm.SampLossVolTextBox.Text = data.SampLossVolText;
                    _mainForm.DesVolUndTextBox.Text = data.DesVolUndText;
                    _mainForm.UndDesorpCalTextBox.Text = data.UndDesorpCalText;

                    if (data.ImageBytes != null)
                    {
                        _mainForm.pictureBox3.Image = BytesToImage(data.ImageBytes);
                        //_mainForm.pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void tabPage2DoubleBufferedPanel2_SizeChanged(object sender, EventArgs e)
        {
            int newWidth;
            int newHeight;

            newWidth = _mainForm.tabPage2DoubleBufferedPanel2.ClientSize.Width / 1 - _mainForm.tabPage2DoubleBufferedPanel2.ClientSize.Width / 100;
            newHeight = _mainForm.tabPage2DoubleBufferedPanel2.ClientSize.Height / 1 - _mainForm.tabPage2DoubleBufferedPanel2.ClientSize.Height / 10;

            Console.WriteLine($"主界面 宽度: {_mainForm.Width}, 高度: {_mainForm.Height}");
            Console.WriteLine($"宽度: {newWidth}, 高度: {newHeight}");

            _mainForm.tabPage2panel7.Width = 1;
            _mainForm.tabPage2panel8.Width = 1;
            _mainForm.tabPage2panel9.Width = 1;
            _mainForm.tabPage2panel10.Width = 1;


            _mainForm.tabPage2panel6.Width = 806;
            _mainForm.tabPage2panel6.Height = 130;
            _mainForm.BulkImportButton.Location = new Point(399, 13);
            _mainForm.DrawCurvesButton.Location = new Point(671, 13);
            _mainForm.ExportImageButton.Location = new Point(542, 13);
            _mainForm.tabPage2TemporarySavingButton.Location = new Point(542, 78);
            _mainForm.tabPage2RecoverDataButton.Location = new Point(671, 78);
            // 840-1165
            if (newWidth <= 840)
            {
                newWidth = 428;

                _mainForm.tabPage2panel6.Width = 403;
                _mainForm.tabPage2panel6.Height = 202;
                _mainForm.BulkImportButton.Location = new Point(7, 133);
                _mainForm.DrawCurvesButton.Location = new Point(279, 133);
                _mainForm.ExportImageButton.Location = new Point(150, 133);
                _mainForm.tabPage2TemporarySavingButton.Location = new Point(150, 203);
                _mainForm.tabPage2RecoverDataButton.Location = new Point(279, 203);
            }
            else if (newWidth > 840 && newWidth <=1165)
            {
                newWidth = 840;
                _mainForm.tabPage2panel9.Width = 240;
            }
            else if (newWidth > 1165)
            {
                newWidth = 1165;
                newHeight = 630;

                int a = 161;
                _mainForm.tabPage2panel7.Width = a;
                _mainForm.tabPage2panel8.Width = a;

                _mainForm.tabPage2panel9.Width = 1;
                _mainForm.tabPage2panel10.Width = a;
            }

            _mainForm.tabPage2DoubleBufferedFlowLayoutPanel1.Width = newWidth;
            _mainForm.tabPage2DoubleBufferedFlowLayoutPanel1.Height = newHeight;

            // 居中定位
            _mainForm.tabPage2DoubleBufferedFlowLayoutPanel1.Left = (_mainForm.tabPage2DoubleBufferedPanel2.ClientSize.Width - newWidth) / 2;
            _mainForm.tabPage2DoubleBufferedFlowLayoutPanel1.Top = (_mainForm.tabPage2DoubleBufferedPanel2.ClientSize.Height - newHeight) / 2;

        }
        private void ValidateNumericDataNumTextBox31_60(TextBox textBox)
        {
            string input = textBox.Text;

            // 重置颜色
            textBox.BackColor = Color.FromArgb(192, 192, 255);

            if(input.Contains(" "))
            {
                textBox.BackColor = Color.Red;
            }
            else if (string.IsNullOrWhiteSpace(input))
            {
                textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
            }
            else if (!double.TryParse(input, out double value) || value < 0 || value <= 30)
            {
                textBox.BackColor = Color.Red;
            }
        }
        private void ValidateNumericTextBox(TextBox textBox)
        {
            string input = textBox.Text;

            // 重置颜色
            textBox.BackColor = SystemColors.Window;

            if (input.Contains(" "))
            {
                textBox.BackColor = Color.Red;
            }
            else if (string.IsNullOrWhiteSpace(input))
            {
                textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
            }
            else if (!double.TryParse(input, out double value) || value < 0)
            {
                textBox.BackColor = Color.Red;
            }
        }
        private void ValidateEmptyTextBox(TextBox textBox)
        {
            string input = textBox.Text;

            // 重置背景色
            textBox.BackColor = SystemColors.Window;

            if (string.IsNullOrWhiteSpace(input))
            {
                textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
            }
        }
        
        public void TabControl_2_InputCheckTimer_Tick()
        {
            DateTime time1 = _mainForm.dateTimePicker4.Value;
            DateTime time2 = _mainForm.dateTimePicker5.Value;

            // 去除秒和毫秒，只保留到分钟
            time1 = new DateTime(time1.Year, time1.Month, time1.Day, time1.Hour, time1.Minute, 0);
            time2 = new DateTime(time2.Year, time2.Month, time2.Day, time2.Hour, time2.Minute, 0);

            TimeSpan diff = time1 - time2;
            int minutes = (int)diff.TotalMinutes;
            _mainForm.t0TextBox.Text = minutes.ToString();

            string input = _mainForm.t0TextBox.Text;
            // 重置颜色
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


            for (int i = 31; i <= 60; i++)
            {
                string controlName = "DataNumTextBox" + i;
                Control ctl = _mainForm.Controls.Find(controlName, true).FirstOrDefault();
                if (ctl is TextBox tb)
                {
                    ValidateNumericDataNumTextBox31_60(tb);
                }
            }

            for (int i = 1; i <= 60; i++)
            {
                string controlName = "DesorbTextBox" + i;

                Control ctl = _mainForm.Controls.Find(controlName, true).FirstOrDefault();

                if (ctl is TextBox tb)
                {
                    ValidateNumericTextBox(tb);
                }
            }

            DigitalLegitimacyVerification_Tick();
        }
        // 数据合法性校验
        public void DigitalLegitimacyVerification_Tick()
        {
            List<TextBox> boxes = new List<TextBox>();

            for (int i = 1; i <= 60; i++)
            {
                var tb = _mainForm.Controls.Find("DesorbTextBox" + i, true).FirstOrDefault() as TextBox;
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

            for (int i = 0; i < boxes.Count; i++)
            {
                string text = boxes[i].Text.Trim();

                if (string.IsNullOrEmpty(text))
                    continue;

                if (!double.TryParse(text, out double currentValue))
                {
                    boxes[i].ForeColor = Color.Blue;
                    boxes[i].Font = new Font(boxes[i].Font.FontFamily, boxes[i].Font.Size, FontStyle.Bold | FontStyle.Italic);
                    isValid = false;
                    continue;
                }

                if (hasLastValue && currentValue < lastValue)
                {
                    var errorFont = new Font(boxes[i].Font.FontFamily, boxes[i].Font.Size, FontStyle.Bold | FontStyle.Italic);

                    boxes[i].ForeColor = Color.Blue;
                    boxes[i].Font = errorFont;

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
        /// 计算井下解吸校准体积（Desorption Calibrated Volume）
        /// </summary>
        /// <param name="desorptionVolume">井下解吸体积（Desorption Volume）</param>
        /// <param name="pressure">压强（Pressure）</param>
        /// <param name="temperature">温度（Temperature）</param>
        /// <returns>计算得到的校准体积</returns>
        public static double CalculateDesorptionCalibratedVolume(double desorptionVolume, double pressure, double temperature)
        {
            // ((num2 * 273.2) * ((num3 - (4.905 * (1 - num2/800))) - (0.699 * e^(0.0597 * num4)))) / (101.3 * (273.2 + num4))
            double result = ((desorptionVolume * 273.2) *
                            ((pressure - (4.905 * (1.0 - (desorptionVolume / 800.0)))) - (0.699 * Math.Exp(0.0597 * temperature))))
                            / (101.3 * (273.2 + temperature));

            return result;
        }


        // 读取excel数据
        public void ReadExcel(string filePath)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheets.First(); // 读取第一个 sheet
                var rows = worksheet.RangeUsed().RowsUsed();

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
        public void ImportExcelToTextBoxes(string excelPath)
        {
            var workbook = new XLWorkbook(excelPath);
            var worksheet = workbook.Worksheet(1);

            int desorbIndex = 31; // 解吸量填充起始控件编号
            int dataNumIndex = 31; // 时间填充起始控件编号

            for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
            {
                var timeCell = worksheet.Cell(row, 1);
                var valueCell = worksheet.Cell(row, 2);

                if (int.TryParse(timeCell.GetValue<string>(), out int time))
                {
                    string desorbValue = valueCell.GetValue<string>();

                    // 1~30 按时间值匹配控件填充解吸量
                    if (time >= 1 && time <= 30)
                    {
                        string textBoxName = $"DesorbTextBox{time}";
                        var tb = _mainForm.Controls.Find(textBoxName, true).FirstOrDefault() as TextBox;
                        if (tb != null)
                            tb.Text = desorbValue;
                    }

                    // 31及以上，按顺序填充 DesorbTextBox 和 DataNumTextBox
                    if (time >= 31)
                    {
                        // 解吸量填充 DesorbTextBox{desorbIndex}
                        string desorbBoxName = $"DesorbTextBox{desorbIndex}";
                        var desorbTb = _mainForm.Controls.Find(desorbBoxName, true).FirstOrDefault() as TextBox;
                        if (desorbTb != null)
                            desorbTb.Text = desorbValue;

                        // 时间填充 DataNumTextBox{dataNumIndex}
                        string dataNumBoxName = $"DataNumTextBox{dataNumIndex}";
                        var dataTb = _mainForm.Controls.Find(dataNumBoxName, true).FirstOrDefault() as TextBox;
                        if (dataTb != null)
                            dataTb.Text = time.ToString();

                        desorbIndex++;
                        dataNumIndex++;
                    }
                }
            }
        }


        // 弹出对话框让用户选择 Excel 文件
        public string SelectExcelFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                var lastFolder = GasFormsApp.Settings.Default.LastFolder;
                openFileDialog.InitialDirectory = string.IsNullOrEmpty(lastFolder)
                    ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    : lastFolder;

                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "请选择Excel文件";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GasFormsApp.Settings.Default.LastFolder = Path.GetDirectoryName(openFileDialog.FileName);
                    GasFormsApp.Settings.Default.Save();  // 这里改成和赋值一致的类
                    return openFileDialog.FileName;
                }
                else
                {
                    return null;
                }
            }
        }


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
        public void ExportImageButton_Click(object sender, EventArgs e)
        {
            // 选择保存位置
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "PNG 文件 (*.png)|*.png",
                Title = "保存生成的 PNG 文件"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // 当前程序目录
                string CurrentDir = AppDomain.CurrentDomain.BaseDirectory;
                // 用于存放系统数据的文件夹路径
                string SystemDataPath = Path.Combine(CurrentDir, "Python_embed\\Python\\images\\output_image.png");

                string outputPath = saveDialog.FileName;
                string sourcePath = SystemDataPath;  // 你的固定图片路径

                try
                {
                    // 复制文件，若目标文件已存在则覆盖
                    System.IO.File.Copy(sourcePath, outputPath, true);
                    MessageBox.Show("图片复制成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("复制图片出错: " + ex.Message);
                }
            }
        }
        public void DrawCurvesButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("你干么：" + 45);
            // 从文本框或其他地方获取数据，并将其传入函数
            // 假设这些是你窗体上的 TextBox 控件
            TextBox[] DesorbTextBox = new TextBox[60];
            for (int i = 0; i < 60; i++)
            {
                string controlName = $"DesorbTextBox{i + 1}";
                DesorbTextBox[i] = _mainForm.Controls.Find(controlName, true).FirstOrDefault() as TextBox;
            }

            float t0_temp;
            float t0 = 0;
            if (float.TryParse(_mainForm.t0TextBox.Text, out t0_temp))
            {
                t0 = t0_temp;
            }
            else
            {
                // 转换失败，比如用户输入了非数字
                MessageBox.Show("请输入有效的数字");
            }
            double[,] data = new double[DesorbTextBox.Length, 2]; // 数组大小根据 DesorbTextBox 数量来确定

            for (int i = 0; i < DesorbTextBox.Length; i++) // 循环次数根据 DesorbTextBox 数量确定
            {
                int a = i + 1;
                string controlName = "";
                double Sqrt_Value = 0.0;
                if(i<30)
                {
                    controlName = $"DataNumLabel{a}";
                    var textBox = _mainForm.Controls.Find(controlName, true).FirstOrDefault() as Label;
                    Console.WriteLine($"取标签值:{controlName}->{textBox.Text}");
                    //直接取标签文本作为横坐标
                    Sqrt_Value = Math.Sqrt(t0 + a);
                }
                else if (i >= 30)
                {
                    controlName = $"DataNumTextBox{a}";
                    var textBox = _mainForm.Controls.Find(controlName, true).FirstOrDefault() as TextBox;
                    Console.WriteLine($"取DataNumTextBox:{controlName}->{textBox.Text}");
                    //直接取标签文本作为横坐标
                    if (!string.IsNullOrEmpty(textBox.Text))
                        Sqrt_Value = Math.Sqrt(t0 + (double)Convert.ToDecimal(textBox.Text.Trim()));
                }

                double textBoxValue = 0.0;
                if (!string.IsNullOrWhiteSpace(DesorbTextBox[i].Text) &&
                    double.TryParse(DesorbTextBox[i].Text.Trim(), out double value))
                {
                    textBoxValue = value;
                }
                else
                {
                    textBoxValue = 0;
                }
                controlName = $"DesorbTextBox{i + 1}";
                Console.WriteLine($"数据框值:{controlName}->{textBoxValue}");

                data[i, 0] = Sqrt_Value; // 将平方根值存储在第一列
                data[i, 1] = textBoxValue; // 将文本框值存储在第二列
            }
            if(data[4, 1] == 0)
            {
                Console.WriteLine($"解吸时间不可少于5分钟");
                MessageBox.Show($"解吸时间不可少于5分钟", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //insertChart.InsertChartToWord(outputPath, data);

            const string mapName = "Local\\MySharedMemory";
            int totalBytes = DesorbTextBox.Length * 2 * sizeof(double);

            using (var mmf = MemoryMappedFile.CreateOrOpen(mapName, totalBytes))
            {
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


                const string memoryName = "Local\\tempSharedMemory";
                int temptotalBytes = 5 * sizeof(double);


                // 设置等待状态
                void SetWaitCursor(System.Windows.Forms.Control control, Cursor cursor)
                {
                    control.Cursor = cursor;
                    foreach (System.Windows.Forms.Control child in control.Controls)
                    {
                        SetWaitCursor(child, cursor);
                    }
                }
                // 等待
                SetWaitCursor(_mainForm, Cursors.WaitCursor);
                using (var tempmmf = MemoryMappedFile.CreateOrOpen(memoryName, temptotalBytes))
                {
                    //等待共享内存有数据
                    
                    try
                    {
                        var pythonPath = @"Python_embed\python.exe"; // 嵌入式解释器路径
                        //var scriptPath = @"Python_embed\Python\aaa.cpython-312.pyc";           // 你实际的 .py 文件路径
                        var scriptPath = @"Python_embed\Python\aaa.py";

                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = pythonPath,
                            Arguments = $"\"{scriptPath}\"",         // 加上引号，防止路径带空格
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            CreateNoWindow = true
                        };

                        using (Process process = Process.Start(psi))
                        {
                            string output = process.StandardOutput.ReadToEnd();
                            string error = process.StandardError.ReadToEnd();
                            process.WaitForExit();

                            Console.WriteLine("Python output:\n" + output);
                            if (!string.IsNullOrEmpty(error))
                            {
                                Console.WriteLine("Python error:\n" + error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"执行程序时发生错误：{ex.Message}");
                    }

                    // 读取共享内存中的数据
                    using (var accessor = tempmmf.CreateViewAccessor(0, temptotalBytes))
                    {
                        double[] values = new double[5];
                        double lastValue = 0;

                        int a = 0;
                        //等待第5个数据不为0（下标4）
                        while (true)
                        {
                            lastValue = accessor.ReadDouble(4 * sizeof(double));
                            if (lastValue != 0 || a++>100 * 5)
                            {
                                break;
                            }

                            //Console.WriteLine("等待数据......");
                            Thread.Sleep(10); // 避免忙等待，占用CPU过高
                        }
                        if( a> 100 * 5)
                        {
                            SetWaitCursor(_mainForm, Cursors.Default);
                            MessageBox.Show($"计算失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string imageName = "Python_embed\\Python\\images\\output_image.png";
                        string imagePath = Path.Combine(Environment.CurrentDirectory, imageName);
                        // 设置 PictureBox 的显示模式
                        _mainForm.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        try
                        {
                            if (File.Exists(imagePath))
                            {
                                // 避免文件被锁，使用 Image.FromStream
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


                        //double[] values = new double[5];
                        for (int i = 0; i < values.Length; i++)
                        {
                            values[i] = accessor.ReadDouble(i * sizeof(double));
                        }
                        //InsertChart.SetGasLossVolText(Math.Abs(values[1]).ToString("F2"));

                        // 找出最大数据
                        double maxValue = double.MinValue;
                        for (int i = 1; i <= 60; i++)
                        {
                            string key = $"D{i:000}";
                            var textBox = _mainForm.Controls.Find($"DesorbTextBox{i}", true).FirstOrDefault() as TextBox;

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
                        
                        // 量管初始体积
                        float initialVolume;
                        if (float.TryParse(_mainForm.InitialVolumeTextBox.Text, out initialVolume))
                        {
                            // 计算井下解吸体积
                            MainForm.井下解吸体积 = maxValue - initialVolume;
                            _mainForm.DesVolUndTextBox.Text = MainForm.井下解吸体积.ToString("F2");


                            int temp1;
                            if (int.TryParse(_mainForm.UndTempTextBox.Text, out temp1))
                            {
                                float temp2;
                                if (float.TryParse(_mainForm.UndAtmPressureTextBox.Text, out temp2))
                                {
                                    MainForm.井下解吸校准体积 = CalculateDesorptionCalibratedVolume(MainForm.井下解吸体积, temp2,temp1);
                                    _mainForm.UndDesorpCalTextBox.Text = MainForm.井下解吸校准体积.ToString("F2");


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
                            // 转换失败，比如用户输入了非数字
                            MessageBox.Show("请输入有效的数字");
                        }
                        SetWaitCursor(_mainForm, Cursors.Default);
                        // 计算完成提示框
                        //MessageBox.Show("计算完成！", "提示：");
                        MessageBox.Show($"计算完成！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
