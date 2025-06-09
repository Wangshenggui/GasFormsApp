using System;
using System.Drawing;
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

            ValidateEmptyTextBox(_mainForm.MineNameTextBox);
            ValidateEmptyTextBox(_mainForm.SamplingSpotTextBox);
            ValidateEmptyTextBox(_mainForm.CoalSeamTextBox);
            ValidateEmptyTextBox(_mainForm.SampleNumTextBox);
        }
    }
}
