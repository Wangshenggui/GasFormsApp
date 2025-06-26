using System;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace GasFormsApp.TabControl
{
    internal class tabControl_1
    {
        private MainForm _mainForm;


        // 构造函数接收 TextBox 控件
        public tabControl_1(MainForm form)
        {
            _mainForm = form;

            _mainForm.tabPage1DoubleBufferedFlowLayoutPanel1.Paint += tabPage1DoubleBufferedFlowLayoutPanel1_Paint;
            _mainForm.tabPage1TemporarySavingButton.Click += tabPage1TemporarySavingButton_Click;
            _mainForm.tabPage1RecoverDataButton.Click += tabPage1RecoverDataButton_Click;
        }

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

        // 临时保存按钮
        public void tabPage1TemporarySavingButton_Click(object sender, EventArgs e)
        {
            // 构造 TempData 对象并从控件中读取数据
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

            // 获取当前程序目录
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string tempFolder = Path.Combine(currentDir, "TempData");

            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }

            string savePath = Path.Combine(tempFolder, "tabPage1_temp.bin");

            try
            {
                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
#pragma warning disable SYSLIB0011 // 忽略BinaryFormatter过时警告
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
        public void tabPage1RecoverDataButton_Click(object sender, EventArgs e)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string loadPath = Path.Combine(currentDir, "TempData", "tabPage1_temp.bin");

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
                    tab1TempData data = (tab1TempData)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011

                    // 将值恢复到控件
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



        private void tabPage1DoubleBufferedFlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            int newWidth = _mainForm.tabPage1panel1.ClientSize.Width / 1 - _mainForm.tabPage1panel1.ClientSize.Width / 9;
            int newHeight = _mainForm.tabPage1panel1.ClientSize.Height / 1 - _mainForm.tabPage1panel1.ClientSize.Height / 8;

            // 370-705
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
                newWidth = 1055 + 10;
                newHeight = 370;
            }
            _mainForm.tabPage1DoubleBufferedFlowLayoutPanel1.Width = newWidth;
            _mainForm.tabPage1DoubleBufferedFlowLayoutPanel1.Height = newHeight;

            // 居中定位
            _mainForm.tabPage1DoubleBufferedFlowLayoutPanel1.Left = (_mainForm.tabPage1panel1.ClientSize.Width - newWidth) / 2;
            _mainForm.tabPage1DoubleBufferedFlowLayoutPanel1.Top = (_mainForm.tabPage1panel1.ClientSize.Height - newHeight) / 2;


            //Console.WriteLine($"FlowLayoutPanel 宽度: {_mainForm.tabPage1DoubleBufferedFlowLayoutPanel1.Width}, 高度: {_mainForm.tabPage1DoubleBufferedFlowLayoutPanel1.Height}");
            //Console.WriteLine($"主界面 宽度: {_mainForm.Width}, 高度: {_mainForm.Height}");
        }

        private void ValidateEmptyTextBox(TextBox textBox)
        {
            if(textBox == _mainForm.SamplingSpotTextBox)
            {
                string input = textBox.Text;

                // 括号检查
                bool hasEnglishLeft = input.Contains("(");
                bool hasEnglishRight = input.Contains(")");
                bool hasChineseLeft = input.Contains("（");
                bool hasChineseRight = input.Contains("）");

                // 括号成对（英文或中文）
                bool hasBracketPair =
                    (hasEnglishLeft && hasEnglishRight) ||
                    (hasChineseLeft && hasChineseRight);

                // 空内容 -> 蓝/灰 提示
                if (string.IsNullOrWhiteSpace(input))
                {
                    textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
                    _mainForm.errorProvider1.SetError(textBox, "");
                }
                // 非空但括号不完整或缺失 -> 红色
                else if (!hasBracketPair)
                {
                    textBox.BackColor = Color.Tomato;
                    _mainForm.errorProvider1.SetError(textBox, "必须包含括号，例如：(孔号) 或 （孔号）");
                }
                // 括号成对 -> 恢复默认颜色
                else
                {
                    textBox.BackColor = SystemColors.Window;
                    _mainForm.errorProvider1.SetError(textBox, "");
                }

            }
            else
            {
                string input = textBox.Text;

                // 重置背景色
                textBox.BackColor = SystemColors.Window;

                if (string.IsNullOrWhiteSpace(input))
                {
                    textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
                }
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

        public void TabControl_1_InputCheckTimer_Tick()
        {
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


            ValidateEmptyTextBox(_mainForm.MineNameTextBox);
            ValidateEmptyTextBox(_mainForm.SamplingSpotTextBox);
            ValidateEmptyTextBox(_mainForm.CoalSeamTextBox);
            ValidateEmptyTextBox(_mainForm.SampleNumTextBox);
            ValidateEmptyTextBox(_mainForm.SamplingPersonnelTextBox);
        }
    }
}
