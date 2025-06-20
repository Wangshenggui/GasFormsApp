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

            _mainForm.tabPage1DoubleBufferedFlowLayoutPanel1.Paint += tabPage1DoubleBufferedFlowLayoutPanel1_Paint;
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
            }
            else if (newWidth > 1055)
            {
                newWidth = 1055 + 10;
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
