using System;
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


            // 注册回调函数
            _mainForm.AdsorpConstATextBox.TextChanged += TextModificationTriggered;
            _mainForm.AdsorpConstBTextBox.TextChanged += TextModificationTriggered;
            _mainForm.MadTextBox.TextChanged += TextModificationTriggered;
            _mainForm.AadTextBox.TextChanged += TextModificationTriggered;
            _mainForm.PorosityTextBox.TextChanged += TextModificationTriggered;
            _mainForm.AppDensityTextBox.TextChanged += TextModificationTriggered;
            _mainForm.VadTextBox.TextChanged += TextModificationTriggered;

            //注册KeyPress回调函数
            _mainForm.AdsorpConstATextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.AdsorpConstBTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.MadTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.AadTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.PorosityTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.AppDensityTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.VadTextBox.KeyPress += NumericTextBox_KeyPress;
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;

            // 公共的输入限制代码
            // 允许数字和退格键
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                return;
            }

            // 允许一个小数点
            if (e.KeyChar == '.' && !tb.Text.Contains("."))
            {
                return;
            }

            e.Handled = true;
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
        private void TextModificationTriggered(object sender, EventArgs e)
        {
            Control control = sender as Control;  // 转成 Control 类型（适用于 WinForms）
            if (control != null)
            {
                string controlName = control.Name;
                string controlText = control.Text;

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
}
