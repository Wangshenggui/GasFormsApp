using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasFormsApp.TabControl
{
    internal class tabControl_3
    {
        private MainForm _mainForm;
        private TextBox _DesorpVolNormalTextBox;
        private TextBox _DesorpVolNormalCalTextBox;
        private TextBox _Sample1WeightTextBox;
        private TextBox _Sample2WeightTextBox;
        private TextBox _S1DesorpVolTextBox;
        private TextBox _S1DesorpVolCalTextBox;
        private TextBox _S2DesorpVolTextBox;
        private TextBox _S2DesorpVolCalTextBox;
        private TextBox _CrushDesorpTextBox;


        public tabControl_3(
            MainForm form,
            TextBox DesorpVolNormalTextBox,
            TextBox DesorpVolNormalCalTextBox,
            TextBox Sample1WeightTextBox,
            TextBox Sample2WeightTextBox,
            TextBox S1DesorpVolTextBox,
            TextBox S1DesorpVolCalTextBox,
            TextBox S2DesorpVolTextBox,
            TextBox S2DesorpVolCalTextBox,
            TextBox CrushDesorpTextBox
        )
        {
            _mainForm = form;
            _DesorpVolNormalTextBox = DesorpVolNormalTextBox;
            _DesorpVolNormalCalTextBox = DesorpVolNormalCalTextBox;
            _Sample1WeightTextBox = Sample1WeightTextBox;
            _Sample2WeightTextBox = Sample2WeightTextBox;
            _S1DesorpVolTextBox = S1DesorpVolTextBox;
            _S1DesorpVolCalTextBox = S1DesorpVolCalTextBox;
            _S2DesorpVolTextBox = S2DesorpVolTextBox;
            _S2DesorpVolCalTextBox = S2DesorpVolCalTextBox;
            _CrushDesorpTextBox = CrushDesorpTextBox;

            // 注册回调函数
            _DesorpVolNormalTextBox.TextChanged += TextModificationTriggered;
            //_DesorpVolNormalCalTextBox.TextChanged += TextModificationTriggered;

            _Sample1WeightTextBox.TextChanged += TextModificationTriggered;
            _Sample2WeightTextBox.TextChanged += TextModificationTriggered;
            _S1DesorpVolTextBox.TextChanged += TextModificationTriggered;
            //_S1DesorpVolCalTextBox.TextChanged += TextModificationTriggered;
            _S2DesorpVolTextBox.TextChanged += TextModificationTriggered;
            //_S2DesorpVolCalTextBox.TextChanged += TextModificationTriggered;
            //_CrushDesorpTextBox.TextChanged += TextModificationTriggered;
        }

        void getMaxVal()
        {
            try
            {
                decimal one1 = Convert.ToDecimal(_Sample1WeightTextBox.Text.Trim());
                decimal two1 = Convert.ToDecimal(_Sample2WeightTextBox.Text.Trim());
                decimal one = Convert.ToDecimal(_S1DesorpVolCalTextBox.Text.Trim());
                decimal two = Convert.ToDecimal(_S2DesorpVolCalTextBox.Text.Trim());
                if (one > 0 && two > 0 && one1 > 0 && two1 > 0)
                {
                    _CrushDesorpTextBox.Text = (Math.Round(one / one1 > two / two1 ? one / one1 : two / two1, 4)).ToString();
                }
            }
            catch { }
        }
        private void TextModificationTriggered(object sender, EventArgs e)
        {
            System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;  // 转成 Control 类型（适用于 WinForms）
            if (control != null)
            {
                string controlName = control.Name;
                string controlText = control.Text;
                
                switch (controlName)
                {
                    //常 压 解 吸 体 积(ml):
                    case "DesorpVolNormalTextBox":
                        _DesorpVolNormalCalTextBox.Text = "校准后的值";
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
                        _S1DesorpVolCalTextBox.Text = "校准后的值";
                        getMaxVal();
                        break;

                    //第一份煤样解吸校准值:
                    case "S1DesorpVolCalTextBox":

                        break;

                    //第二份煤样解吸量(ml ）:
                    case "S2DesorpVolTextBox":
                        _S2DesorpVolCalTextBox.Text = "校准后的值";
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
