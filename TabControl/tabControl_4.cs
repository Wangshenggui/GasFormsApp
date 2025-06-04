using System;
using System.Drawing;
using System.Windows.Forms;

namespace GasFormsApp.TabControl
{
    internal class tabControl_4
    {
        private MainForm _mainForm;

        public tabControl_4(
            MainForm form
        )
        {
            _mainForm = form;

            
            _mainForm.toolTip1.SetToolTip(_mainForm.ExpCalcButton, "计算(Ctrl + D)");

            // 注册回调函数
            _mainForm.ExpCalcButton.Click += ExpCalcButton_Click;
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
        public void TabControl_4_InputCheckTimer_Tick()
        {
            ValidateNumericTextBox(_mainForm.AdsorpConstATextBox);
            ValidateNumericTextBox(_mainForm.AdsorpConstBTextBox);
            ValidateNumericTextBox(_mainForm.MadTextBox);
            ValidateNumericTextBox(_mainForm.AadTextBox);
            ValidateNumericTextBox(_mainForm.PorosityTextBox);
            ValidateNumericTextBox(_mainForm.AppDensityTextBox);
            ValidateNumericTextBox(_mainForm.VadTextBox);
        }

        /// <summary>
        /// 计算Wc
        /// </summary>
        /// <returns></returns>
        private double getWc()
        {
            float p = 0.1f;//0.103f
            float AD = Convert.ToSingle(_mainForm.AadTextBox.Text.Trim());//灰分
            float Md = Convert.ToSingle(_mainForm.MadTextBox.Text.Trim());//水分
            float F = Convert.ToSingle(_mainForm.PorosityTextBox.Text.Trim());//孔隙率
            float r = Convert.ToSingle(_mainForm.AppDensityTextBox.Text.Trim());//视密度
            float a = Convert.ToSingle(_mainForm.AdsorpConstATextBox.Text.Trim());// 吸附常数a
            float b = Convert.ToSingle(_mainForm.AdsorpConstBTextBox.Text.Trim());// 吸附常数b
            double x = a * b * p * (100 - AD - Md) / ((1 + b * p) * 100 * (1 + 0.31 * Md)) + F / (100 * r);
            return Math.Round(x, 4);
        }
        public void ExpCalcButton_Click(object sender, EventArgs e)
        {
            //计算Wc
            MainForm.Wc = getWc();
            _mainForm.NonDesorpGasQtyTextBox.Text = MainForm.Wc.ToString();

            // 计算W1
            float SampleWeight = (float)Convert.ToDecimal(_mainForm.SampleWeightTextBox.Text);// 煤样重量
            float SampLossVol = (float)Convert.ToDecimal(_mainForm.SampLossVolTextBox.Text);// 取样损失体积
            float UndDesorpCal = (float)Convert.ToDecimal(_mainForm.UndDesorpCalTextBox.Text);// 井下解吸校准
            MainForm.W1 = (UndDesorpCal + Math.Abs(SampLossVol)) / SampleWeight;
            _mainForm.W1_TextBox.Text = MainForm.W1.ToString("F4");

            // 计算W2
            float DesorpVolNormal = (float)Convert.ToDecimal(_mainForm.DesorpVolNormalCalTextBox.Text);// 实验室解吸
            MainForm.W2 = DesorpVolNormal / SampleWeight;
            _mainForm.W2_TextBox.Text = MainForm.W2.ToString("F4");

            // 计算W3
            float CrushDesorp = (float)Convert.ToDecimal(_mainForm.CrushDesorpTextBox.Text);
            MainForm.W3 = CrushDesorp;
            _mainForm.W3_TextBox.Text = MainForm.W3.ToString("F4");

            // 计算Wa
            MainForm.Wa = MainForm.W1 + MainForm.W2 + MainForm.W3;
            _mainForm.Wa_TextBox.Text = MainForm.Wa.ToString("F4");

            // 计算Wc
            MainForm.Wc = (float)Convert.ToDecimal(_mainForm.NonDesorpGasQtyTextBox.Text);
            _mainForm.Wc_TextBox.Text = MainForm.Wc.ToString("F4");

            // 计算W
            MainForm.W = MainForm.Wa + MainForm.Wc;
            _mainForm.W_TextBox.Text = MainForm.W.ToString("F4");

            /* 
             * AdsorpConstBTextBox -> 吸附常数b 
             * PorosityTextBox -> 孔隙率
             * MadTextBox -> 水分
             * AdsorpConstATextBox -> 吸附常数a
             * AppDensityTextBox -> 视密度
             * AadTextBox -> 灰分
             * W_TextBox -> W
             */
            // 计算P
            double at =
                1000 * Convert.ToDouble(_mainForm.AdsorpConstBTextBox.Text.Trim())
                * (Convert.ToDouble(_mainForm.PorosityTextBox.Text.Trim()) / 100)
                + 310 * Convert.ToDouble(_mainForm.AdsorpConstBTextBox.Text.Trim())
                * Convert.ToDouble(_mainForm.MadTextBox.Text.Trim())
                * (Convert.ToDouble(_mainForm.PorosityTextBox.Text.Trim()) / 100);
            double bt =
                Convert.ToDouble(_mainForm.AdsorpConstATextBox.Text.Trim())
                * Convert.ToDouble(_mainForm.AdsorpConstBTextBox.Text.Trim())
                * Convert.ToDouble(_mainForm.AppDensityTextBox.Text.Trim())
                * (100 - Convert.ToDouble(_mainForm.AadTextBox.Text.Trim()) - Convert.ToDouble(_mainForm.MadTextBox.Text.Trim()))
                + 1000 * (Convert.ToDouble(_mainForm.PorosityTextBox.Text.Trim()) / 100)
                - 100 * Convert.ToDouble(_mainForm.AdsorpConstBTextBox.Text.Trim())
                * Convert.ToDouble(_mainForm.W_TextBox.Text.Trim())
                * Convert.ToDouble(_mainForm.AppDensityTextBox.Text.Trim())
                + 310 * Convert.ToDouble(_mainForm.MadTextBox.Text.Trim())
                * (Convert.ToDouble(_mainForm.PorosityTextBox.Text.Trim()) / 100)
                - 31 * Convert.ToDouble(_mainForm.AdsorpConstBTextBox.Text.Trim())
                * Convert.ToDouble(_mainForm.MadTextBox.Text.Trim())
                * Convert.ToDouble(_mainForm.W_TextBox.Text.Trim())
                * Convert.ToDouble(_mainForm.AppDensityTextBox.Text.Trim());
            double ct =
                -100 * Convert.ToDouble(_mainForm.W_TextBox.Text.Trim())
                * Convert.ToDouble(_mainForm.AppDensityTextBox.Text.Trim())
                - 31 * Convert.ToDouble(_mainForm.MadTextBox.Text.Trim())
                * Convert.ToDouble(_mainForm.W_TextBox.Text.Trim())
                * Convert.ToDouble(_mainForm.AppDensityTextBox.Text.Trim());
            double Pt = Math.Round((-bt + Math.Sqrt(bt * bt - 4 * at * ct)) / (2 * at), 4) - 0.1;
            MainForm.P = Pt;
            _mainForm.P_TextBox.Text = MainForm.P.ToString("F4");
        }
    }
}
