using System;
using System.Drawing;
using System.IO;
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

            MakeCheckBoxesReadOnly(
                _mainForm.AdsorpConstACheckBox,
                _mainForm.AdsorpConstBCheckBox,
                _mainForm.MadCheckBox,
                _mainForm.AadCheckBox,
                _mainForm.PorosityCheckBox,
                _mainForm.AppDensityCheckBox,
                _mainForm.TrueDensityCheckBox,
                _mainForm.VadCheckBox,
                _mainForm.NonDesorpGasQtyCheckBox
            );

            _mainForm.WcOutCheckBox.CheckedChanged += WcOutCheckBox_CheckedChanged;

            _mainForm.tabPage4DoubleBufferedPanel1.SizeChanged += tabPage4DoubleBufferedPanel1_SizeChanged;
            _mainForm.tabPage4TemporarySavingButton.Click += tabPage4TemporarySavingButton_Click;
            _mainForm.tabPage4RecoverDataButton.Click += tabPage4RecoverDataButton_Click;
        }

        [Serializable]
        public class tab4TempData
        {
            public string AdsorpConstATextBox { get; set; }
            public string AdsorpConstBTextBox { get; set; }
            public string MadTextBox { get; set; }
            public string AadTextBox { get; set; }
            public string PorosityTextBox { get; set; }
            public string AppDensityTextBox { get; set; }
            public string TrueDensityTextBox { get; set; }
            public string VadTextBox { get; set; }
            public string NonDesorpGasQtyTextBox { get; set; }
            public string W1_TextBox { get; set; }
            public string W2_TextBox { get; set; }
            public string W3_TextBox { get; set; }
            public string Wa_TextBox { get; set; }
            public string Wc_TextBox { get; set; }
            public string W_TextBox { get; set; }
            public string P_TextBox { get; set; }
        }

        // 临时保存按钮
        public void tabPage4TemporarySavingButton_Click(object sender, EventArgs e)
        {
            // 构造 TempData 对象并从控件中读取数据
            tab4TempData data = new tab4TempData
            {
                AdsorpConstATextBox = _mainForm.AdsorpConstATextBox.Text,
                AdsorpConstBTextBox = _mainForm.AdsorpConstBTextBox.Text,
                MadTextBox = _mainForm.MadTextBox.Text,
                AadTextBox = _mainForm.AadTextBox.Text,
                PorosityTextBox = _mainForm.PorosityTextBox.Text,
                AppDensityTextBox = _mainForm.AppDensityTextBox.Text,
                TrueDensityTextBox = _mainForm.TrueDensityTextBox.Text,
                VadTextBox = _mainForm.VadTextBox.Text,
                NonDesorpGasQtyTextBox = _mainForm.NonDesorpGasQtyTextBox.Text,
                W1_TextBox = _mainForm.W1_TextBox.Text,
                W2_TextBox = _mainForm.W2_TextBox.Text,
                W3_TextBox = _mainForm.W3_TextBox.Text,
                Wa_TextBox = _mainForm.Wa_TextBox.Text,
                Wc_TextBox = _mainForm.Wc_TextBox.Text,
                W_TextBox = _mainForm.W_TextBox.Text,
                P_TextBox = _mainForm.P_TextBox.Text
            };

            // 获取当前程序目录
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string tempFolder = Path.Combine(currentDir, "TempData");

            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }

            string savePath = Path.Combine(tempFolder, "tabPage4_temp.bin");

            try
            {
                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
#pragma warning disable SYSLIB0011 // 忽略BinaryFormatter过时警告
                    formatter.Serialize(fs, data);
#pragma warning restore SYSLIB0011
                }

                MessageBox.Show("以二进制格式保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void tabPage4RecoverDataButton_Click(object sender, EventArgs e)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string loadPath = Path.Combine(currentDir, "TempData", "tabPage4_temp.bin");

            if (!File.Exists(loadPath))
            {
                MessageBox.Show("找不到临时保存的数据！");
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(loadPath, FileMode.Open))
                {
#pragma warning disable SYSLIB0011
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    tab4TempData data = (tab4TempData)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011

                    // 将值恢复到控件
                    _mainForm.AdsorpConstATextBox.Text = data.AdsorpConstATextBox;
                    _mainForm.AdsorpConstBTextBox.Text = data.AdsorpConstBTextBox;
                    _mainForm.MadTextBox.Text = data.MadTextBox;
                    _mainForm.AadTextBox.Text = data.AadTextBox;
                    _mainForm.PorosityTextBox.Text = data.PorosityTextBox;
                    _mainForm.AppDensityTextBox.Text = data.AppDensityTextBox;
                    _mainForm.TrueDensityTextBox.Text = data.TrueDensityTextBox;
                    _mainForm.VadTextBox.Text = data.VadTextBox;
                    _mainForm.NonDesorpGasQtyTextBox.Text = data.NonDesorpGasQtyTextBox;
                    _mainForm.W1_TextBox.Text = data.W1_TextBox;
                    _mainForm.W2_TextBox.Text = data.W2_TextBox;
                    _mainForm.W3_TextBox.Text = data.W3_TextBox;
                    _mainForm.Wa_TextBox.Text = data.Wa_TextBox;
                    _mainForm.Wc_TextBox.Text = data.Wc_TextBox;
                    _mainForm.W_TextBox.Text = data.W_TextBox;
                    _mainForm.P_TextBox.Text = data.P_TextBox;

                    MessageBox.Show("数据已恢复！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MakeCheckBoxesReadOnly(params CheckBox[] boxes)
        {
            foreach (var box in boxes)
            {
                // 保存事件处理器引用
                EventHandler clickHandler = (s, e) => box.Checked = !box.Checked;

                // 存储到 Tag 中方便以后移除
                box.Tag = clickHandler;
                box.Click += clickHandler;

                box.Cursor = Cursors.Default;
                box.TabStop = false;
            }
        }
        private void MakeCheckBoxesEditable(params CheckBox[] boxes)
        {
            foreach (var box in boxes)
            {
                if (box.Tag is EventHandler handler)
                {
                    box.Click -= handler;  // 移除之前的处理器
                    box.Tag = null;
                }

                box.Cursor = Cursors.Hand;   // 或你默认的鼠标样式
                box.TabStop = true;
            }
        }



        private void tabPage4DoubleBufferedPanel1_SizeChanged(object sender, EventArgs e)
        {
            int newWidth;
            int newHeight;
            if (_mainForm.Width > 980)
            {
                newWidth = _mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Width / 1 - 0;
            }
            else
            {
                newWidth = _mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Width / 1;
            }
            newHeight = _mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Height / 1 - _mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Height / 10;


            // 840-1165
            if (newWidth <= 940)
            {
                newWidth = 940/2 + 10;
            }
            else if (newWidth > 940)
            {
                newWidth = 940;
                //newHeight = 610;
            }

            Console.WriteLine($"{_mainForm.Width}--{_mainForm.Height}");

            _mainForm.tabPage4DoubleBufferedFlowLayoutPanel1.Width = newWidth;
            _mainForm.tabPage4DoubleBufferedFlowLayoutPanel1.Height = newHeight;

            // 居中定位
            _mainForm.tabPage4DoubleBufferedFlowLayoutPanel1.Left = (_mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Width - newWidth) / 2;
            _mainForm.tabPage4DoubleBufferedFlowLayoutPanel1.Top = (_mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Height - newHeight) / 2;
        }
        private void WcOutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_mainForm.WcOutCheckBox.Checked)
            {
                _mainForm.WcOutCheckBox.Image = Properties.Resources.打勾;

                MakeCheckBoxesEditable(
                    _mainForm.AdsorpConstACheckBox,
                    _mainForm.AdsorpConstBCheckBox,
                    _mainForm.MadCheckBox,
                    _mainForm.AadCheckBox,
                    _mainForm.PorosityCheckBox,
                    _mainForm.AppDensityCheckBox,
                    _mainForm.TrueDensityCheckBox,
                    _mainForm.VadCheckBox,
                    _mainForm.NonDesorpGasQtyCheckBox
                );

                MainForm.WcOutCheckBoxFlag = true;
            }
            else
            {
                _mainForm.WcOutCheckBox.Image = Properties.Resources.打叉;

                _mainForm.AdsorpConstACheckBox.Checked = false;
                _mainForm.AdsorpConstBCheckBox.Checked = false;
                _mainForm.MadCheckBox.Checked = false;
                _mainForm.AadCheckBox.Checked = false;
                _mainForm.PorosityCheckBox.Checked = false;
                _mainForm.AppDensityCheckBox.Checked = false;
                _mainForm.TrueDensityCheckBox.Checked = false;
                _mainForm.VadCheckBox.Checked = false;
                _mainForm.NonDesorpGasQtyCheckBox.Checked = false;

                MakeCheckBoxesReadOnly(
                    _mainForm.AdsorpConstACheckBox,
                    _mainForm.AdsorpConstBCheckBox,
                    _mainForm.MadCheckBox,
                    _mainForm.AadCheckBox,
                    _mainForm.PorosityCheckBox,
                    _mainForm.AppDensityCheckBox,
                    _mainForm.TrueDensityCheckBox,
                    _mainForm.VadCheckBox,
                    _mainForm.NonDesorpGasQtyCheckBox
                );

                MainForm.WcOutCheckBoxFlag = false;
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
            ValidateNumericTextBox(_mainForm.TrueDensityTextBox);
            ValidateNumericTextBox(_mainForm.VadTextBox);
        }

        public void P瓦斯压力选择()
        {
            if (_mainForm.P_CheckBox.Checked)
            {
                MainForm.P_Lable = "P(MPa)：";
                MainForm.P_Data = _mainForm.P_TextBox.Text;
                MainForm.P_beizhu = "P-瓦斯压力";
            }
            else
            {
                MainForm.P_Lable = "";
                MainForm.P_Data = "";
                MainForm.P_beizhu = "";
            }
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
            _mainForm.NonDesorpGasQtyTextBox.Text = MainForm.Wc.ToString("F2");

            // 计算W1
            float SampleWeight = (float)Convert.ToDecimal(_mainForm.SampleWeightTextBox.Text);// 煤样重量
            float SampLossVol = (float)Convert.ToDecimal(_mainForm.SampLossVolTextBox.Text);// 取样损失体积
            float UndDesorpCal = (float)Convert.ToDecimal(_mainForm.UndDesorpCalTextBox.Text);// 井下解吸校准
            MainForm.W1 = (UndDesorpCal + Math.Abs(SampLossVol)) / SampleWeight;
            _mainForm.W1_TextBox.Text = MainForm.W1.ToString("F2");

            // 计算W2
            float DesorpVolNormal = (float)Convert.ToDecimal(_mainForm.DesorpVolNormalCalTextBox.Text);// 实验室解吸
            MainForm.W2 = DesorpVolNormal / SampleWeight;
            _mainForm.W2_TextBox.Text = MainForm.W2.ToString("F2");

            // 计算W3
            float CrushDesorp = (float)Convert.ToDecimal(_mainForm.CrushDesorpTextBox.Text);
            MainForm.W3 = CrushDesorp;
            _mainForm.W3_TextBox.Text = MainForm.W3.ToString("F2");

            // 计算Wa
            MainForm.Wa = MainForm.W1 + MainForm.W2 + MainForm.W3;
            _mainForm.Wa_TextBox.Text = MainForm.Wa.ToString("F2");

            // 计算Wc
            MainForm.Wc = (float)Convert.ToDecimal(_mainForm.NonDesorpGasQtyTextBox.Text);
            _mainForm.Wc_TextBox.Text = MainForm.Wc.ToString("F2");

            // 计算W
            MainForm.W = MainForm.Wa + MainForm.Wc;
            _mainForm.W_TextBox.Text = MainForm.W.ToString("F2");

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
            _mainForm.P_TextBox.Text = MainForm.P.ToString("F2");
        }
    }
}
