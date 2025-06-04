using System;
using System.Collections.Generic;
using System.Drawing;
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
        }

        private void ValidateNumericTextBox(TextBox textBox)
        {
            string input = textBox.Text;

            // 重置颜色
            textBox.BackColor = SystemColors.Window;

            if (string.IsNullOrWhiteSpace(input))
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
                    _mainForm.CrushDesorpTextBox.Text = (Math.Round(one / one1 > two / two1 ? one / one1 : two / two1, 4)).ToString();
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
            _mainForm.DesorpVolNormalCalTextBox.Text = temp.ToString("F4");

            temp = CalcStandardVolume(
                            (double)Convert.ToDecimal(_mainForm.S1DesorpVolTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabAtmPressureTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabTempTextBox.Text),
                            5.886,
                            1000
                            );
            _mainForm.S1DesorpVolCalTextBox.Text = temp.ToString("F4");

            temp = CalcStandardVolume(
                            (double)Convert.ToDecimal(_mainForm.S2DesorpVolTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabAtmPressureTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabTempTextBox.Text),
                            5.886,
                            1000
                            );
            _mainForm.S2DesorpVolCalTextBox.Text = temp.ToString("F4");
            getMaxVal();
        }
    }
}
