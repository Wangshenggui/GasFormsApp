using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GasFormsApp.TabControl
{
    // tabControl_1 类，用于管理主窗体中 tabPage1 页面的逻辑
    internal class tabControl_1
    {
        private MainForm _mainForm;  // 持有主窗体引用，访问控件


        // 定义要监控的所有文本框
        private List<Control> _trackedControls = new List<Control>();

        // 构造函数，传入主窗体对象，绑定相关事件
        public tabControl_1(MainForm form)
        {
            _mainForm = form;

            // 设置工具提示
            _mainForm.toolTip1.SetToolTip(_mainForm.tabPage1TemporarySavingButton, "临时保存(Ctrl + Shift + S)");
            _mainForm.toolTip1.SetToolTip(_mainForm.tabPage1RecoverDataButton, "恢复数据(Ctrl + R)");

            // 绑定 FlowLayoutPanel 的 Paint 事件，用于动态调整大小和位置
            _mainForm.tabPage1DoubleBufferedFlowLayoutPanel1.Paint += tabPage1DoubleBufferedFlowLayoutPanel1_Paint;

            // 绑定“临时保存”按钮点击事件
            _mainForm.tabPage1TemporarySavingButton.Click += tabPage1TemporarySavingButton_Click;

            // 绑定“恢复数据”按钮点击事件
            _mainForm.tabPage1RecoverDataButton.Click += tabPage1RecoverDataButton_Click;

            _mainForm.SampleModeComboBox.MouseWheel += SampleModeComboBox_MouseWheel;

            // 批量注册内容更改事件
            InitializeTextMonitoring();
        }
        // 批量注册事件
        private void InitializeTextMonitoring()
        {
            // 添加所有需要监控的文本框（可通过遍历容器控件自动发现）
            _trackedControls.AddRange(
                new Control[] {
                    _mainForm.MineNameTextBox,
                    _mainForm.SamplingSpotTextBox,
                    _mainForm.BurialDepthTextBox,
                    _mainForm.CoalSeamTextBox,
                    _mainForm.UndAtmPressureTextBox,
                    _mainForm.UndTempTextBox,
                    _mainForm.LabAtmPressureTextBox,
                    _mainForm.LabTempTextBox,
                    _mainForm.MoistureSampleTextBox,
                    _mainForm.SampleModeComboBox,
                    _mainForm.SampleNumTextBox,
                    _mainForm.RawCoalMoistureTextBox,
                    _mainForm.InitialVolumeTextBox,
                    _mainForm.SampleWeightTextBox,
                    _mainForm.SamplingDepthTextBox,
                    _mainForm.SamplingTimeDateTimePicker,
                    _mainForm.DrillInclinationTextBox,
                    _mainForm.AzimuthTextBox,
                    _mainForm.SamplingPersonnelTextBox,
                }
            );

            // 批量绑定事件
            foreach (var control in _trackedControls)
            {
                if (control is TextBox textBox)
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

            if (changedControl is TextBox textBox)
                currentValue = textBox.Text;
            else if (changedControl is ComboBox comboBox)
                currentValue = comboBox.Text;
            else if (changedControl is DateTimePicker dateTimePicker)
                currentValue = dateTimePicker.Value.ToString("yyyy-MM-dd");
            else
                currentValue = string.Empty;

            Console.WriteLine($"{changedControl.Name} 的值已修改: {currentValue}");

            _mainForm.tabPage1.Text = "*基本信息";
        }

        // 禁止滚轮选择取样方式
        private void SampleModeComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        // 定义序列化保存的临时数据结构，存储 tabPage1 中各控件的数据
        [Serializable]
        public class tab1TempData
        {
            public string MineNameText { get; set; }
            public string SamplingSpotText { get; set; }
            public string BurialDepthText { get; set; }
            public string CoalSeamText { get; set; }
            public string UndAtmPressureText { get; set; }
            public string LabAtmPressureText { get; set; }
            public string UndTempText { get; set; }
            public string LabTempText { get; set; }
            public string MoistureSampleText { get; set; }
            public string SampleModeCombo { get; set; }
            public string SampleNumText { get; set; }
            public string RawCoalMoistureText { get; set; }
            public string InitialVolumeText { get; set; }
            public string SampleWeightText { get; set; }
            public string SamplingDepthText { get; set; }
            public string _SamplingTimeDateTimePicker { get; set; }
            public string DrillInclinationText { get; set; }
            public string AzimuthText { get; set; }
            public string SamplingPersonnelText { get; set; }
        }

        // “临时保存”按钮点击事件处理函数
        public void tabPage1TemporarySavingButton_Click(object sender, EventArgs e)
        {
            // 从主窗体的控件中读取当前数据，封装到 tab1TempData 实例中
            tab1TempData data = new tab1TempData
            {
                MineNameText = _mainForm.MineNameTextBox.Text,
                SamplingSpotText = _mainForm.SamplingSpotTextBox.Text,
                BurialDepthText = _mainForm.BurialDepthTextBox.Text,
                CoalSeamText = _mainForm.CoalSeamTextBox.Text,
                UndAtmPressureText = _mainForm.UndAtmPressureTextBox.Text,
                LabAtmPressureText = _mainForm.LabAtmPressureTextBox.Text,
                UndTempText = _mainForm.UndTempTextBox.Text,
                LabTempText = _mainForm.LabTempTextBox.Text,
                MoistureSampleText = _mainForm.MoistureSampleTextBox.Text,
                SampleModeCombo = _mainForm.SampleModeComboBox.Text,
                SampleNumText = _mainForm.SampleNumTextBox.Text,
                RawCoalMoistureText = _mainForm.RawCoalMoistureTextBox.Text,
                InitialVolumeText = _mainForm.InitialVolumeTextBox.Text,
                SampleWeightText = _mainForm.SampleWeightTextBox.Text,
                SamplingDepthText = _mainForm.SamplingDepthTextBox.Text,
                _SamplingTimeDateTimePicker = _mainForm.SamplingTimeDateTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                DrillInclinationText = _mainForm.DrillInclinationTextBox.Text,
                AzimuthText = _mainForm.AzimuthTextBox.Text,
                SamplingPersonnelText = _mainForm.SamplingPersonnelTextBox.Text
            };

            // 获取当前程序运行目录
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;

            // 拼接临时数据存储文件夹路径
            string tempFolder = Path.Combine(currentDir, "TempData");

            // 如果文件夹不存在则创建
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }

            // 定义保存文件路径
            string savePath = Path.Combine(tempFolder, "tabPage1_temp.bin");

            try
            {
                // 使用 FileStream 和 BinaryFormatter 进行二进制序列化保存数据
                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
#pragma warning disable SYSLIB0011 // 忽略 BinaryFormatter 过时警告
                    formatter.Serialize(fs, data);
#pragma warning restore SYSLIB0011
                }

                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                // 异常处理，弹出错误提示
                MessageBox.Show("保存失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 恢复成为未修改
            _mainForm.tabPage1.Text = "基本信息";
        }

        // “恢复数据”按钮点击事件处理函数
        public void tabPage1RecoverDataButton_Click(object sender, EventArgs e)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string loadPath = Path.Combine(currentDir, "TempData", "tabPage1_temp.bin");

            // 如果保存文件不存在，提示找不到数据
            if (!File.Exists(loadPath))
            {
                MessageBox.Show("找不到临时保存的数据！");
                return;
            }

            try
            {
                // 打开文件并进行反序列化恢复数据
                using (FileStream fs = new FileStream(loadPath, FileMode.Open))
                {
#pragma warning disable SYSLIB0011
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    tab1TempData data = (tab1TempData)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011

                    // 恢复数据到对应的控件上
                    _mainForm.MineNameTextBox.Text = data.MineNameText;
                    _mainForm.SamplingSpotTextBox.Text = data.SamplingSpotText;
                    _mainForm.BurialDepthTextBox.Text = data.BurialDepthText;
                    _mainForm.CoalSeamTextBox.Text = data.CoalSeamText;
                    _mainForm.UndAtmPressureTextBox.Text = data.UndAtmPressureText;
                    _mainForm.LabAtmPressureTextBox.Text = data.LabAtmPressureText;
                    _mainForm.UndTempTextBox.Text = data.UndTempText;
                    _mainForm.LabTempTextBox.Text = data.LabTempText;
                    _mainForm.MoistureSampleTextBox.Text = data.MoistureSampleText;
                    _mainForm.SampleModeComboBox.Text = data.SampleModeCombo;
                    _mainForm.SampleNumTextBox.Text = data.SampleNumText;
                    _mainForm.RawCoalMoistureTextBox.Text = data.RawCoalMoistureText;
                    _mainForm.InitialVolumeTextBox.Text = data.InitialVolumeText;
                    _mainForm.SampleWeightTextBox.Text = data.SampleWeightText;
                    _mainForm.SamplingDepthTextBox.Text = data.SamplingDepthText;
                    _mainForm.SamplingTimeDateTimePicker.Value = DateTime.Parse(data._SamplingTimeDateTimePicker);
                    _mainForm.DrillInclinationTextBox.Text = data.DrillInclinationText;
                    _mainForm.AzimuthTextBox.Text = data.AzimuthText;
                    _mainForm.SamplingPersonnelTextBox.Text = data.SamplingPersonnelText;

                    MessageBox.Show("数据已恢复！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // tabPage1DoubleBufferedFlowLayoutPanel1 的 Paint 事件处理，用于动态调整其大小和位置，实现居中显示
        private void tabPage1DoubleBufferedFlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // 计算新的宽高，参考主面板尺寸，带一定比例缩放
            int newWidth = _mainForm.tabPage1panel1.ClientSize.Width - _mainForm.tabPage1panel1.ClientSize.Width / 9;
            int newHeight = _mainForm.tabPage1panel1.ClientSize.Height - _mainForm.tabPage1panel1.ClientSize.Height / 8;

            // 限定宽度范围，避免过大或过小
            if (newWidth >= 370 && newWidth <= 705)
            {
                newWidth = 370;
            }
            else if (newWidth > 705 && newWidth <= 1055)
            {
                newWidth = 720;
                newHeight = 480;
            }
            else if (newWidth > 1055)
            {
                newWidth = 1065;
                newHeight = 370;
            }

            // 应用计算得到的宽高
            _mainForm.tabPage1DoubleBufferedFlowLayoutPanel1.Width = newWidth;
            _mainForm.tabPage1DoubleBufferedFlowLayoutPanel1.Height = newHeight;

            // 居中控件
            _mainForm.tabPage1DoubleBufferedFlowLayoutPanel1.Left = (_mainForm.tabPage1panel1.ClientSize.Width - newWidth) / 2;
            _mainForm.tabPage1DoubleBufferedFlowLayoutPanel1.Top = (_mainForm.tabPage1panel1.ClientSize.Height - newHeight) / 2;
        }

        // 验证文本框非空及特定格式的辅助方法
        private void ValidateEmptyTextBox(TextBox textBox)
        {
            if (textBox == _mainForm.SamplingSpotTextBox)
            {
                string input = textBox.Text;

                // 检查是否包含括号（英文和中文）
                bool hasEnglishLeft = input.Contains("(");
                bool hasEnglishRight = input.Contains(")");
                bool hasChineseLeft = input.Contains("（");
                bool hasChineseRight = input.Contains("）");

                // 判断括号是否成对出现
                bool hasBracketPair =
                    (hasEnglishLeft && hasEnglishRight) ||
                    (hasChineseLeft && hasChineseRight);

                // 空内容时，设置背景为蓝色或灰色提示
                if (string.IsNullOrWhiteSpace(input))
                {
                    textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
                    _mainForm.errorProvider1.SetError(textBox, "");
                }
                // 非空但括号不完整时，背景变红色提示错误
                else if (!hasBracketPair)
                {
                    textBox.BackColor = Color.Tomato;
                    _mainForm.errorProvider1.SetError(textBox, "必须包含括号，例如：(孔号) 或 （孔号）");
                }
                // 括号成对时恢复默认颜色，清除错误提示
                else
                {
                    textBox.BackColor = SystemColors.Window;
                    _mainForm.errorProvider1.SetError(textBox, "");
                }
            }
            else
            {
                // 其他文本框，空时设置提示色，非空时恢复默认颜色
                string input = textBox.Text;
                textBox.BackColor = SystemColors.Window;

                if (string.IsNullOrWhiteSpace(input))
                {
                    textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
                }
            }
        }

        // 验证文本框内容是否为非负数字的辅助方法
        private void ValidateNumericTextBox(TextBox textBox)
        {
            string input = textBox.Text;
            textBox.BackColor = SystemColors.Window;

            // 含空格 → 错
            if (input.Contains(" "))
            {
                textBox.BackColor = Color.Red;
                return;
            }

            // 空文本 → 蓝或灰提示
            if (string.IsNullOrWhiteSpace(input))
            {
                textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
                return;
            }

            // 判断是否允许负号的控件
            bool allowNegative = (textBox == _mainForm.DrillInclinationTextBox);
            // === 允许负号的校验 ===
            if (allowNegative)
            {
                int minusCount = input.Count(c => c == '-');
                if (minusCount > 1 || (minusCount == 1 && !input.StartsWith("-")))
                {
                    textBox.BackColor = Color.Red;
                    return;
                }

                if (!double.TryParse(input, out _))
                {
                    textBox.BackColor = Color.Red;
                    return;
                }
            }
            // === 不允许负号的校验 ===
            else
            {
                // 开头是负号 → 错
                if (input.StartsWith("-"))
                {
                    textBox.BackColor = Color.Red;
                    return;
                }

                if (!double.TryParse(input, out double value) || value < 0)
                {
                    textBox.BackColor = Color.Red;
                    return;
                }
            }

            // 一切正常
            textBox.BackColor = SystemColors.Window;
        }


        // 定时器触发的输入校验方法，周期性检查所有相关控件的内容合法性
        public void TabControl_1_InputCheckTimer_Tick()
        {
            // 数值型控件校验
            ValidateNumericTextBox(_mainForm.BurialDepthTextBox);
            ValidateNumericTextBox(_mainForm.LabAtmPressureTextBox);
            ValidateNumericTextBox(_mainForm.UndAtmPressureTextBox);
            ValidateNumericTextBox(_mainForm.LabTempTextBox);
            ValidateNumericTextBox(_mainForm.UndTempTextBox);
            ValidateNumericTextBox(_mainForm.MoistureSampleTextBox);
            ValidateNumericTextBox(_mainForm.RawCoalMoistureTextBox);
            ValidateNumericTextBox(_mainForm.SampleWeightTextBox);
            ValidateNumericTextBox(_mainForm.InitialVolumeTextBox);
            ValidateNumericTextBox(_mainForm.SamplingDepthTextBox);
            ValidateNumericTextBox(_mainForm.DrillInclinationTextBox);
            ValidateNumericTextBox(_mainForm.AzimuthTextBox);

            // 文本非空校验
            ValidateEmptyTextBox(_mainForm.MineNameTextBox);
            ValidateEmptyTextBox(_mainForm.SamplingSpotTextBox);
            ValidateEmptyTextBox(_mainForm.CoalSeamTextBox);
            ValidateEmptyTextBox(_mainForm.SampleNumTextBox);
            ValidateEmptyTextBox(_mainForm.SamplingPersonnelTextBox);
        }
    }
}
