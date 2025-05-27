using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasFormsApp.TabControl
{
    internal class tabControl_1
    {
        private MainForm _mainForm;

        private TextBox _MineNameTextBox;
        private TextBox _SamplingSpotTextBox;
        private TextBox _BurialDepthTextBox;
        private TextBox _CoalSeamTextBox;
        private TextBox _LabAtmPressureTextBox;
        private TextBox _UndAtmPressureTextBox;
        private TextBox _LabTempTextBox;
        private TextBox _UndTempTextBox;
        private TextBox _MoistureSampleTextBox;
        private TextBox _RawCoalMoistureTextBox;
        private TextBox _SampleNumTextBox;
        private TextBox _SampleWeightTextBox;
        private TextBox _InitialVolumeTextBox;


        // 构造函数接收 TextBox 控件
        public tabControl_1(MainForm form,
            TextBox MineNameTextBox,
            TextBox SamplingSpotTextBox,
            TextBox BurialDepthTextBox,
            TextBox CoalSeamTextBox,
            TextBox LabAtmPressureTextBox,
            TextBox UndAtmPressureTextBox,
            TextBox LabTempTextBox,
            TextBox UndTempTextBox,
            TextBox MoistureSampleTextBox,
            TextBox RawCoalMoistureTextBox,
            TextBox SampleNumTextBox,
            TextBox SampleWeightTextBox,
            TextBox InitialVolumeTextBox)
        {
            _mainForm = form;
            _MineNameTextBox = MineNameTextBox;
            _SamplingSpotTextBox = SamplingSpotTextBox;
            _BurialDepthTextBox = BurialDepthTextBox;
            _CoalSeamTextBox = CoalSeamTextBox;
            _LabAtmPressureTextBox = LabAtmPressureTextBox;
            _UndAtmPressureTextBox = UndAtmPressureTextBox;
            _LabTempTextBox = LabTempTextBox;
            _UndTempTextBox = UndTempTextBox;
            _MoistureSampleTextBox = MoistureSampleTextBox;
            _RawCoalMoistureTextBox = RawCoalMoistureTextBox;
            _SampleNumTextBox = SampleNumTextBox;
            _SampleWeightTextBox = SampleWeightTextBox;
            _InitialVolumeTextBox = InitialVolumeTextBox;

            // 注册回调函数
            _MineNameTextBox.TextChanged += TextModificationTriggered;
            _SamplingSpotTextBox.TextChanged += TextModificationTriggered;
            _BurialDepthTextBox.TextChanged += TextModificationTriggered;
            _CoalSeamTextBox.TextChanged += TextModificationTriggered;
            _LabAtmPressureTextBox.TextChanged += TextModificationTriggered;
            _UndAtmPressureTextBox.TextChanged += TextModificationTriggered;
            _LabTempTextBox.TextChanged += TextModificationTriggered;
            _UndTempTextBox.TextChanged += TextModificationTriggered;
            _MoistureSampleTextBox.TextChanged += TextModificationTriggered;
            _RawCoalMoistureTextBox.TextChanged += TextModificationTriggered;
            _SampleNumTextBox.TextChanged += TextModificationTriggered;
            _SampleWeightTextBox.TextChanged += TextModificationTriggered;
            _InitialVolumeTextBox.TextChanged += TextModificationTriggered;
        }
        private void TextModificationTriggered(object sender, EventArgs e)
        {
            System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;  // 转成 Control 类型（适用于 WinForms）
            if (control != null)
            {
                string controlName = control.Name;
                string controlText = control.Text;

                Console.WriteLine($"触发事件的控件名称是：{controlName}");
                Console.WriteLine($"控件的文本内容是：{controlText}");
            }
        }

        // 示例方法：设置文本
        public void SetText(string text)
        {
            _MineNameTextBox.Text = text;
        }

        public string GetText(TextBox textBox)
        {
            return textBox.Text;
        }
    }
}
