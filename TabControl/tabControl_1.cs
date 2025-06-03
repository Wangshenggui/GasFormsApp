using System;
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

            // 注册回调函数
            _mainForm.MineNameTextBox.TextChanged += TextModificationTriggered;
            _mainForm.SamplingSpotTextBox.TextChanged += TextModificationTriggered;
            _mainForm.BurialDepthTextBox.TextChanged += TextModificationTriggered;
            _mainForm.CoalSeamTextBox.TextChanged += TextModificationTriggered;
            _mainForm.LabAtmPressureTextBox.TextChanged += TextModificationTriggered;
            _mainForm.UndAtmPressureTextBox.TextChanged += TextModificationTriggered;
            _mainForm.LabTempTextBox.TextChanged += TextModificationTriggered;
            _mainForm.UndTempTextBox.TextChanged += TextModificationTriggered;
            _mainForm.MoistureSampleTextBox.TextChanged += TextModificationTriggered;
            _mainForm.RawCoalMoistureTextBox.TextChanged += TextModificationTriggered;
            _mainForm.SampleNumTextBox.TextChanged += TextModificationTriggered;
            _mainForm.SampleWeightTextBox.TextChanged += TextModificationTriggered;
            _mainForm.InitialVolumeTextBox.TextChanged += TextModificationTriggered;

            //注册KeyPress回调函数
            _mainForm.BurialDepthTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.LabAtmPressureTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.UndAtmPressureTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.LabTempTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.UndTempTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.MoistureSampleTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.RawCoalMoistureTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.SampleWeightTextBox.KeyPress += NumericTextBox_KeyPress;
            _mainForm.InitialVolumeTextBox.KeyPress += NumericTextBox_KeyPress;
        }
        private void TextModificationTriggered(object sender, EventArgs e)
        {
            Control control = sender as Control;  // 转成 Control 类型（适用于 WinForms）
            if (control != null)
            {
                string controlName = control.Name;
                string controlText = control.Text;

                Console.WriteLine($"触发事件的控件名称是：{controlName}");
                Console.WriteLine($"控件的文本内容是：{controlText}");
            }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;

            // 如果文本为空，且输入的是数字或小数点，则先插入0
            if (string.IsNullOrEmpty(tb.Text))
            {
                if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
                {
                    tb.Text = "0";
                    tb.SelectionStart = tb.Text.Length; // 光标移到末尾
                }
            }

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
    }
}
