using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GasFormsApp.TabControl
{
    internal class tabControl_3
    {
        private MainForm _mainForm;

        public tabControl_3(
            MainForm form
        )
        {
            _mainForm = form;

            _mainForm.toolTip1.SetToolTip(_mainForm.LabDesorbButton, "计算(Ctrl + D)");

            _mainForm.LabDesorbButton.Click += LabDesorbButton_Click;
            _mainForm.tabPage3TemporarySavingButton.Click += tabPage3TemporarySavingButton_Click;
            _mainForm.tabPage3RecoverDataButton.Click += tabPage3RecoverDataButton_Click;
        }

        [Serializable]
        public class tab3TempData
        {
            public string DesorpVolNormalText { get; set; }
            public string DesorpVolNormalCalText { get; set; }
            public string Sample1WeightText { get; set; }
            public string Sample2WeightText { get; set; }
            public string S1DesorpVolText { get; set; }
            public string S2DesorpVolText { get; set; }
            public string S1DesorpVolCalText { get; set; }
            public string S2DesorpVolCalText { get; set; }
            public string CrushDesorpTextBox { get; set; }
        }

        // 临时保存按钮
        public void tabPage3TemporarySavingButton_Click(object sender, EventArgs e)
        {
            // 构造 TempData 对象并从控件中读取数据
            tab3TempData data = new tab3TempData
            {
                DesorpVolNormalText = _mainForm.DesorpVolNormalTextBox.Text,
                DesorpVolNormalCalText = _mainForm.DesorpVolNormalCalTextBox.Text,
                Sample1WeightText = _mainForm.Sample1WeightTextBox.Text,
                Sample2WeightText = _mainForm.Sample2WeightTextBox.Text,
                S1DesorpVolText = _mainForm.S1DesorpVolTextBox.Text,
                S2DesorpVolText = _mainForm.S2DesorpVolTextBox.Text,
                S1DesorpVolCalText = _mainForm.S1DesorpVolCalTextBox.Text,
                S2DesorpVolCalText = _mainForm.S2DesorpVolCalTextBox.Text,
                CrushDesorpTextBox = _mainForm.CrushDesorpTextBox.Text
            };

            // 获取当前程序目录
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string tempFolder = Path.Combine(currentDir, "TempData");

            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }

            string savePath = Path.Combine(tempFolder, "tabPage3_temp.bin");

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
        public void tabPage3RecoverDataButton_Click(object sender, EventArgs e)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string loadPath = Path.Combine(currentDir, "TempData", "tabPage3_temp.bin");

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
                    tab3TempData data = (tab3TempData)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011

                    _mainForm.DesorpVolNormalTextBox.Text = data.DesorpVolNormalText;
                    _mainForm.DesorpVolNormalCalTextBox.Text = data.DesorpVolNormalCalText;
                    _mainForm.Sample1WeightTextBox.Text = data.Sample1WeightText;
                    _mainForm.Sample2WeightTextBox.Text = data.Sample2WeightText;
                    _mainForm.S1DesorpVolTextBox.Text = data.S1DesorpVolText;
                    _mainForm.S2DesorpVolTextBox.Text = data.S2DesorpVolText;
                    _mainForm.S1DesorpVolCalTextBox.Text = data.S1DesorpVolCalText;
                    _mainForm.S2DesorpVolCalTextBox.Text = data.S2DesorpVolCalText;
                    _mainForm.CrushDesorpTextBox.Text = data.CrushDesorpTextBox;

                    MessageBox.Show("数据已恢复！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void TabControl_3_InputCheckTimer_Tick()
        {
            ValidateNumericTextBox(_mainForm.DesorpVolNormalTextBox);

            ValidateNumericTextBox(_mainForm.Sample1WeightTextBox);
            ValidateNumericTextBox(_mainForm.Sample2WeightTextBox);
            ValidateNumericTextBox(_mainForm.S1DesorpVolTextBox);
            ValidateNumericTextBox(_mainForm.S2DesorpVolTextBox);
        }

        void getMaxVal()
        {
            try
            {
                decimal one1 = Convert.ToDecimal(_mainForm.Sample1WeightTextBox.Text.Trim());
                decimal two1 = Convert.ToDecimal(_mainForm.Sample2WeightTextBox.Text.Trim());
                decimal one = Convert.ToDecimal(_mainForm.S1DesorpVolCalTextBox.Text.Trim());
                decimal two = Convert.ToDecimal(_mainForm.S2DesorpVolCalTextBox.Text.Trim());
                if (one > 0 && two > 0 && one1 > 0 && two1 > 0)
                {
                    _mainForm.CrushDesorpTextBox.Text = (Math.Round(one / one1 > two / two1 ? one / one1 : two / two1, 4)).ToString("F2");
                }
            }
            catch { }
        }
        
        /// <summary>
        /// 计算换算到标准状态（101.3 kPa，0℃）的体积
        /// </summary>
        /// <param name="V">测量体积（单位：任意，保持一致即可）</param>
        /// <param name="P">压强（kPa）</param>
        /// <param name="T">温度（℃）</param>
        /// <param name="waterColumnFactor">水柱压力修正系数（kPa）</param>
        /// <param name="volumeDivisor">体积分母，用于计算水柱压力修正中的体积比例</param>
        /// <returns>换算后的标准状态体积（V0）</returns>
        static double CalcStandardVolume(
            double V,
            double P,
            double T,
            double waterColumnFactor,
            double volumeDivisor)
        {
            // 水蒸气分压力（kPa）
            double P_water = 0.699 * Math.Exp(0.0597 * T);

            // 水柱压力修正（kPa）
            double P_column = waterColumnFactor * (1 - (V / 2) / volumeDivisor);

            // 换算到标准状态体积（101.3 kPa, 0℃）
            double V0 = V * 273.2 / (273.2 + T) * (P - P_column - P_water) / 101.3;

            return V0;
        }
        public void LabDesorbButton_Click(object sender, EventArgs e)
        {
            double temp = 0;
            temp = CalcStandardVolume(
                            (double)Convert.ToDecimal(_mainForm.DesorpVolNormalTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabAtmPressureTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabTempTextBox.Text),
                            5.886,
                            1000
                            );
            _mainForm.DesorpVolNormalCalTextBox.Text = temp.ToString("F2");

            temp = CalcStandardVolume(
                            (double)Convert.ToDecimal(_mainForm.S1DesorpVolTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabAtmPressureTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabTempTextBox.Text),
                            5.886,
                            1000
                            );
            _mainForm.S1DesorpVolCalTextBox.Text = temp.ToString("F2");

            temp = CalcStandardVolume(
                            (double)Convert.ToDecimal(_mainForm.S2DesorpVolTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabAtmPressureTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabTempTextBox.Text),
                            5.886,
                            1000
                            );
            _mainForm.S2DesorpVolCalTextBox.Text = temp.ToString("F2");
            getMaxVal();
        }
    }
}
