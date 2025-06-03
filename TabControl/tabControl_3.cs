using System;
using System.Collections.Generic;
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

            // 注册回调函数
            _mainForm.DesorpVolNormalTextBox.TextChanged += TextModificationTriggered;
            //_DesorpVolNormalCalTextBox.TextChanged += TextModificationTriggered;

            _mainForm.Sample1WeightTextBox.TextChanged += TextModificationTriggered;
            _mainForm.Sample2WeightTextBox.TextChanged += TextModificationTriggered;
            _mainForm.S1DesorpVolTextBox.TextChanged += TextModificationTriggered;
            //_mainForm.S1DesorpVolCalTextBox.TextChanged += TextModificationTriggered;
            _mainForm.S2DesorpVolTextBox.TextChanged += TextModificationTriggered;
            //_mainForm.S2DesorpVolCalTextBox.TextChanged += TextModificationTriggered;
            //_mainForm.CrushDesorpTextBox.TextChanged += TextModificationTriggered;


            //注册KeyPress回调函数
            _mainForm.DesorpVolNormalTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.Sample1WeightTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.Sample2WeightTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.S1DesorpVolTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.S2DesorpVolTextBox.KeyPress += NumericTextBox_KeyPress;
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
        private void TextModificationTriggered(object sender, EventArgs e)
        {
            Control control = sender as Control;  // 转成 Control 类型（适用于 WinForms）
            if (control != null)
            {
                string controlName = control.Name;
                string controlText = control.Text;

                double temp = 0;
                switch (controlName)
                {
                    //常 压 解 吸 体 积(ml):
                    case "DesorpVolNormalTextBox":
                        temp = CalcStandardVolume(
                            (double)Convert.ToDecimal(_mainForm.DesorpVolNormalTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabAtmPressureTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabTempTextBox.Text),
                            5.886,
                            1000
                            );
                        _mainForm.DesorpVolNormalCalTextBox.Text = temp.ToString("F4");
                        break;



                    //第 一 份 煤 样 重 量(g):
                    case "Sample1WeightTextBox":
                        
                        getMaxVal();
                        break;

                    //第 二 份 煤 样 重 量(g):
                    case "Sample2WeightTextBox":
                        getMaxVal();
                        break;

                    //第一份煤样解吸量(ml ）:
                    case "S1DesorpVolTextBox":
                        temp = CalcStandardVolume(
                            (double)Convert.ToDecimal(_mainForm.S1DesorpVolTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabAtmPressureTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabTempTextBox.Text),
                            5.886,
                            1000
                            );
                        _mainForm.S1DesorpVolCalTextBox.Text = temp.ToString("F4");
                        getMaxVal();
                        break;

                    //第一份煤样解吸校准值:
                    case "S1DesorpVolCalTextBox":

                        break;

                    //第二份煤样解吸量(ml ）:
                    case "S2DesorpVolTextBox":
                        temp = CalcStandardVolume(
                            (double)Convert.ToDecimal(_mainForm.S2DesorpVolTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabAtmPressureTextBox.Text),
                            (double)Convert.ToDecimal(_mainForm.LabTempTextBox.Text),
                            5.886,
                            1000
                            );
                        _mainForm.S2DesorpVolCalTextBox.Text = temp.ToString("F4");
                        getMaxVal();
                        break;

                    //第二份煤样解吸校准值:
                    case "S2DesorpVolCalTextBox":

                        break;

                    case "CrushDesorpTextBox":

                        break;

                    default:
                        Console.WriteLine("未处理的控件");
                        break;
                }
            }
        }
    }
}
