using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GasFormsApp.TabControl
{
    /// <summary>
    /// 处理主窗体中第三个标签页(tabPage3)的所有功能
    /// 包括实验室解吸数据计算、临时保存和恢复等
    /// </summary>
    internal class tabControl_3
    {
        private MainForm _mainForm; // 主窗体引用

        /// <summary>
        /// 构造函数，初始化与主窗体的关联
        /// </summary>
        /// <param name="form">主窗体实例</param>
        public tabControl_3(MainForm form)
        {
            _mainForm = form;

            // 设置工具提示
            _mainForm.toolTip1.SetToolTip(_mainForm.LabDesorbButton, "计算(Ctrl + D)");

            // 注册事件处理程序
            _mainForm.LabDesorbButton.Click += LabDesorbButton_Click;
            _mainForm.tabPage3TemporarySavingButton.Click += tabPage3TemporarySavingButton_Click;
            _mainForm.tabPage3RecoverDataButton.Click += tabPage3RecoverDataButton_Click;
        }

        /// <summary>
        /// 临时数据序列化类，保存tabPage3的所有相关数据
        /// </summary>
        [Serializable]
        public class tab3TempData
        {
            public string DesorpVolNormalText { get; set; }      // 常规解吸体积
            public string DesorpVolNormalCalText { get; set; }  // 常规解吸校准体积
            public string Sample1WeightText { get; set; }       // 样品1重量
            public string Sample2WeightText { get; set; }       // 样品2重量
            public string S1DesorpVolText { get; set; }         // 样品1解吸体积
            public string S2DesorpVolText { get; set; }         // 样品2解吸体积
            public string S1DesorpVolCalText { get; set; }      // 样品1解吸校准体积
            public string S2DesorpVolCalText { get; set; }      // 样品2解吸校准体积
            public string CrushDesorpTextBox { get; set; }      // 粉碎解吸值
        }

        /// <summary>
        /// 临时保存按钮点击事件处理
        /// </summary>
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

            // 确保临时数据目录存在
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string tempFolder = Path.Combine(currentDir, "TempData");
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }

            string savePath = Path.Combine(tempFolder, "tabPage3_temp.bin");

            try
            {
                // 使用二进制格式化器序列化数据
                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
#pragma warning disable SYSLIB0011 // 忽略BinaryFormatter过时警告
                    formatter.Serialize(fs, data);
#pragma warning restore SYSLIB0011
                }

                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 恢复数据按钮点击事件处理
        /// </summary>
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
                // 从二进制文件反序列化数据
                using (FileStream fs = new FileStream(loadPath, FileMode.Open))
                {
#pragma warning disable SYSLIB0011
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    tab3TempData data = (tab3TempData)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011

                    // 恢复控件值
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

        /// <summary>
        /// 验证数值文本框的输入
        /// </summary>
        /// <param name="textBox">要验证的文本框</param>
        private void ValidateNumericTextBox(TextBox textBox)
        {
            string input = textBox.Text;
            textBox.BackColor = SystemColors.Window; // 重置颜色

            if (input.Contains(" ")) // 包含空格
            {
                textBox.BackColor = Color.Red;
            }
            else if (string.IsNullOrWhiteSpace(input)) // 空值
            {
                textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
            }
            else if (!double.TryParse(input, out double value) || value < 0) // 非数字或负值
            {
                textBox.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// 验证文本框是否为空
        /// </summary>
        /// <param name="textBox">要验证的文本框</param>
        private void ValidateEmptyTextBox(TextBox textBox)
        {
            string input = textBox.Text;
            textBox.BackColor = SystemColors.Window; // 重置背景色

            if (string.IsNullOrWhiteSpace(input)) // 空值
            {
                textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
            }
        }

        /// <summary>
        /// 定时检查输入数据
        /// </summary>
        public void TabControl_3_InputCheckTimer_Tick()
        {
            // 验证关键数值文本框
            ValidateNumericTextBox(_mainForm.DesorpVolNormalTextBox);
            ValidateNumericTextBox(_mainForm.Sample1WeightTextBox);
            ValidateNumericTextBox(_mainForm.Sample2WeightTextBox);
            ValidateNumericTextBox(_mainForm.S1DesorpVolTextBox);
            ValidateNumericTextBox(_mainForm.S2DesorpVolTextBox);
        }

        /// <summary>
        /// 计算并显示最大粉碎解吸值
        /// </summary>
        void getMaxVal()
        {
            try
            {
                // 获取样品重量和解吸校准体积
                decimal one1 = Convert.ToDecimal(_mainForm.Sample1WeightTextBox.Text.Trim());
                decimal two1 = Convert.ToDecimal(_mainForm.Sample2WeightTextBox.Text.Trim());
                decimal one = Convert.ToDecimal(_mainForm.S1DesorpVolCalTextBox.Text.Trim());
                decimal two = Convert.ToDecimal(_mainForm.S2DesorpVolCalTextBox.Text.Trim());
                
                // 计算并比较两个样品的解吸率
                if (one > 0 && two > 0 && one1 > 0 && two1 > 0)
                {
                    // 取两个样品解吸率(解吸体积/重量)中的较大值，保留4位小数，显示2位
                    _mainForm.CrushDesorpTextBox.Text = (Math.Round(one / one1 > two / two1 ? one / one1 : two / two1, 4)).ToString("F2");
                }
            }
            catch 
            { 
                // 忽略转换异常
            }
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
            // 水蒸气分压力（kPa）计算公式: 0.699 * e^(0.0597 * T)
            double P_water = 0.699 * Math.Exp(0.0597 * T);

            // 水柱压力修正（kPa）计算公式: waterColumnFactor * (1 - (V / 2) / volumeDivisor)
            double P_column = waterColumnFactor * (1 - (V / 2) / volumeDivisor);

            // 换算到标准状态体积（101.3 kPa, 0℃）公式: 
            // V0 = V * 273.2 / (273.2 + T) * (P - P_column - P_water) / 101.3
            double V0 = V * 273.2 / (273.2 + T) * (P - P_column - P_water) / 101.3;

            return V0;
        }

        /// <summary>
        /// 实验室解吸计算按钮点击事件
        /// </summary>
        public void LabDesorbButton_Click(object sender, EventArgs e)
        {
            double temp = 0;
            
            // 计算常规解吸校准体积
            temp = CalcStandardVolume(
                (double)Convert.ToDecimal(_mainForm.DesorpVolNormalTextBox.Text),
                (double)Convert.ToDecimal(_mainForm.LabAtmPressureTextBox.Text),
                (double)Convert.ToDecimal(_mainForm.LabTempTextBox.Text),
                5.886,    // 水柱压力修正系数
                1000      // 体积分母
            );
            _mainForm.DesorpVolNormalCalTextBox.Text = temp.ToString("F2");

            // 计算样品1解吸校准体积
            temp = CalcStandardVolume(
                (double)Convert.ToDecimal(_mainForm.S1DesorpVolTextBox.Text),
                (double)Convert.ToDecimal(_mainForm.LabAtmPressureTextBox.Text),
                (double)Convert.ToDecimal(_mainForm.LabTempTextBox.Text),
                5.886,
                1000
            );
            _mainForm.S1DesorpVolCalTextBox.Text = temp.ToString("F2");

            // 计算样品2解吸校准体积
            temp = CalcStandardVolume(
                (double)Convert.ToDecimal(_mainForm.S2DesorpVolTextBox.Text),
                (double)Convert.ToDecimal(_mainForm.LabAtmPressureTextBox.Text),
                (double)Convert.ToDecimal(_mainForm.LabTempTextBox.Text),
                5.886,
                1000
            );
            _mainForm.S2DesorpVolCalTextBox.Text = temp.ToString("F2");
            
            // 计算并显示最大粉碎解吸值
            getMaxVal();
        }
    }
}