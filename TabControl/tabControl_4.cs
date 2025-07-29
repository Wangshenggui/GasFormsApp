using AntdUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GasFormsApp.TabControl
{
    internal class tabControl_4
    {
        private MainForm _mainForm;

        // 定义要监控的所有文本框
        private List<Control> _trackedControls = new List<Control>();

        // 构造函数，接收主窗体对象，绑定控件事件和初始化控件状态
        public tabControl_4(MainForm form)
        {
            _mainForm = form;

            // 设置 ExpCalcButton 的悬浮提示文本
            _mainForm.toolTip1.SetToolTip(_mainForm.ExpCalcButton, "计算(Ctrl + D)");
            _mainForm.toolTip1.SetToolTip(_mainForm.tabPage4TemporarySavingButton, "临时保存(Ctrl + Shift + S)");
            _mainForm.toolTip1.SetToolTip(_mainForm.tabPage4RecoverDataButton, "恢复数据(Ctrl + R)");

            // 绑定计算按钮点击事件
            _mainForm.ExpCalcButton.Click += ExpCalcButton_Click;

            // 设置指定的复选框为只读状态（不可交互）
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

            // 绑定 WcOutCheckBox 选中状态变化事件
            _mainForm.WcOutCheckBox.CheckedChanged += WcOutCheckBox_CheckedChanged;

            // 绑定面板大小改变事件，用于动态调整控件大小和位置
            _mainForm.tabPage4DoubleBufferedPanel1.Paint += tabPage4DoubleBufferedPanel1_Paint;

            // 绑定临时保存和数据恢复按钮事件
            _mainForm.tabPage4TemporarySavingButton.Click += tabPage4TemporarySavingButton_Click;
            _mainForm.tabPage4RecoverDataButton.Click += tabPage4RecoverDataButton_Click;

            // 使相关复选框可编辑
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

            _mainForm.tabPage4DoubleBufferedPanel1.MouseWheel += tabPage4DoubleBufferedPanel1_MouseWheel;

            // 批量注册内容更改事件
            InitializeTextMonitoring();
        }

        private void tabPage4DoubleBufferedPanel1_MouseWheel(object sender, MouseEventArgs e)
        {
            // 目标 FlowLayoutPanel 控件
            var targetPanel = _mainForm.tabPage4DoubleBufferedFlowLayoutPanel1;

            // 计算新的滚动位置
            int newY = -targetPanel.AutoScrollPosition.Y - e.Delta;

            // 设置滚动（只垂直方向，横向可自行加）
            targetPanel.AutoScrollPosition = new Point(0, newY);
        }
        private void InitializeTextMonitoring()
        {
            // 添加所有需要监控的文本框（可通过遍历容器控件自动发现）
            _trackedControls.AddRange(
                new Control[] {
                    _mainForm.AdsorpConstATextBox,
                    _mainForm.AdsorpConstBTextBox,
                    _mainForm.MadTextBox,
                    _mainForm.AadTextBox,
                    _mainForm.VadTextBox,
                    _mainForm.AppDensityTextBox,
                    _mainForm.TrueDensityTextBox,
                    _mainForm.PorosityTextBox,
                }
            );

            // 批量绑定事件
            foreach (var control in _trackedControls)
            {
                if (control is Input textBox)
                    textBox.TextChanged += Control_TextChanged;
                else if (control is ComboBox comboBox)
                    comboBox.TextChanged += Control_TextChanged;
                else if (control is DateTimePicker dateTimePicker)
                    dateTimePicker.ValueChanged += Control_TextChanged; // 监控日期变化
            }
        }
        // 统一事件处理
        private void Control_TextChanged(object sender, EventArgs e)
        {
            var changedControl = (Control)sender;
            string currentValue;

            if (changedControl is Input textBox)
                currentValue = textBox.Text;
            else if (changedControl is ComboBox comboBox)
                currentValue = comboBox.Text;
            else if (changedControl is DateTimePicker dateTimePicker)
                currentValue = dateTimePicker.Value.ToString("yyyy-MM-dd");
            else
                currentValue = string.Empty;

            Console.WriteLine($"{changedControl.Name} 的值已修改: {currentValue}");

            _mainForm.tabPage4.Text = "*实验结果*";
        }

        // 用于临时保存界面数据的类，标记为可序列化
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

        // 点击“临时保存”按钮时调用，序列化界面输入的数据并保存到文件
        public void tabPage4TemporarySavingButton_Click(object sender, EventArgs e)
        {
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

            // 获取当前用户的 AppData\Roaming 路径
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // 拼接程序专用目录和 TempData 文件夹
            string tempFolder = Path.Combine(appData, "瓦斯含量测定数据分析系统", "TempData");

            // 如果不存在临时数据目录则创建
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
#pragma warning disable SYSLIB0011 // 忽略 BinaryFormatter 过时警告
                    formatter.Serialize(fs, data);
#pragma warning restore SYSLIB0011
                }
                //MessageBox.Show("保存成功！");

                if (_mainForm.tabPage4.Text == "*实验结果*")
                {
                    // 去掉前面一个“*”
                    _mainForm.tabPage4.Text = "实验结果*";
                }
                else if (_mainForm.tabPage4.Text == "*实验结果")
                {
                    // 去掉前面一个“*”
                    _mainForm.tabPage4.Text = "实验结果";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 点击“恢复数据”按钮时调用，从文件反序列化数据并恢复到控件
        public void tabPage4RecoverDataButton_Click(object sender, EventArgs e)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string tempFolder = Path.Combine(appData, "瓦斯含量测定数据分析系统", "TempData");
            string loadPath = Path.Combine(tempFolder, "tabPage4_temp.bin");

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

                    // 恢复数据到对应控件
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

                    //MessageBox.Show("数据已恢复！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 将指定的复选框设置为只读（禁止用户点击更改）
        /// 实现方式是给复选框绑定点击事件，自动反向取消选中，达到只读效果
        /// </summary>
        private void MakeCheckBoxesReadOnly(params CheckBox[] boxes)
        {
            foreach (var box in boxes)
            {
                // 事件处理器：点击后自动撤销选中状态，防止变更
                EventHandler clickHandler = (s, e) => box.Checked = !box.Checked;

                box.Tag = clickHandler;  // 保存事件处理器以备后续移除
                box.Click += clickHandler;

                box.Cursor = Cursors.Default; // 鼠标形状设为默认，表示不可点击
                box.TabStop = false;          // 取消Tab键焦点
            }
        }

        /// <summary>
        /// 恢复指定复选框的可编辑状态（允许用户点击更改）
        /// </summary>
        private void MakeCheckBoxesEditable(params CheckBox[] boxes)
        {
            foreach (var box in boxes)
            {
                if (box.Tag is EventHandler handler)
                {
                    box.Click -= handler;  // 移除只读时绑定的事件处理器
                    box.Tag = null;
                }

                box.Cursor = Cursors.Hand; // 鼠标变为手型，表示可点击
                box.TabStop = true;        // 恢复Tab键焦点
            }
        }

        // 面板大小变化时调整内部控件大小和居中
        private void tabPage4DoubleBufferedPanel1_Paint(object sender, EventArgs e)
        {
            int newWidth;
            int newHeight;

            // 主窗体宽度大于980时调整宽度，否则使用全宽
            if (_mainForm.tabPage4DoubleBufferedPanel1.Width > 980)
            {
                newWidth = _mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Width;
            }
            else
            {
                newWidth = _mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Width;
            }

            // 高度为面板高度减去十分之一高度
            newHeight = _mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Height - _mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Height / 10;

            // 限制宽度范围，保证最小宽度约为 465 + 10 (即 475)，最大宽度 940
            if (newWidth <= 940)
            {
                newWidth = 480;
            }
            else if (newWidth > 940)
            {
                newWidth = 940;
                newHeight = 610; // 可选固定高度注释掉
            }

            
            if(newHeight> _mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Height)
            {
                newHeight = _mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Height - _mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Height/100;
            }
            // 设置内部 FlowLayoutPanel 宽高
            _mainForm.tabPage4DoubleBufferedFlowLayoutPanel1.Width = newWidth;
            _mainForm.tabPage4DoubleBufferedFlowLayoutPanel1.Height = newHeight;

            Console.WriteLine($"{_mainForm.tabPage4DoubleBufferedFlowLayoutPanel1.Height}--{_mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Height}");

            // 居中定位
            _mainForm.tabPage4DoubleBufferedFlowLayoutPanel1.Left = (_mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Width - _mainForm.tabPage4DoubleBufferedFlowLayoutPanel1.Width) / 2;
            _mainForm.tabPage4DoubleBufferedFlowLayoutPanel1.Top = (_mainForm.tabPage4DoubleBufferedPanel1.ClientSize.Height - _mainForm.tabPage4DoubleBufferedFlowLayoutPanel1.Height) / 2;


            // tabPage4panel1
            _mainForm.tabPage4panel1.Width = SystemInformation.VerticalScrollBarWidth;
            _mainForm.tabPage4panel1.Height = newHeight;
            Point location = _mainForm.tabPage4DoubleBufferedFlowLayoutPanel1.Location;
            int x = location.X;
            int y = location.Y;
            _mainForm.tabPage4panel1.Location = new Point(newWidth + x - SystemInformation.VerticalScrollBarWidth, y);
        }

        // 当 WcOutCheckBox 选中状态改变时调用
        private void WcOutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_mainForm.WcOutCheckBox.Checked)
            {
                _mainForm.WcOutCheckBox.Image = Properties.Resources.打勾;

                // 使相关复选框可编辑
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

                // 取消所有相关复选框的选中状态
                _mainForm.AdsorpConstACheckBox.Checked = false;
                _mainForm.AdsorpConstBCheckBox.Checked = false;
                _mainForm.MadCheckBox.Checked = false;
                _mainForm.AadCheckBox.Checked = false;
                _mainForm.PorosityCheckBox.Checked = false;
                _mainForm.AppDensityCheckBox.Checked = false;
                _mainForm.TrueDensityCheckBox.Checked = false;
                _mainForm.VadCheckBox.Checked = false;
                _mainForm.NonDesorpGasQtyCheckBox.Checked = false;

                // 设置为只读，禁止用户更改
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

        // 验证数值型文本框，检查非空、无空格、有效数字且非负，否则标红
        private void ValidateNumericTextBox(Input textBox)
        {
            string input = textBox.Text;

            // 重置背景色为默认白色
            textBox.BackColor = SystemColors.Window;

            if (input.Contains(" "))
            {
                textBox.BackColor = Color.Red; // 含空格标红
            }
            else if (string.IsNullOrWhiteSpace(input))
            {
                // 空白时，若文本框有焦点，变蓝，否则灰色
                textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
            }
            else if (!double.TryParse(input, out double value) || value < 0)
            {
                // 不是有效非负数字标红
                textBox.BackColor = Color.Red;
            }
        }

        // 验证非空文本框，空时改变背景色提示
        private void ValidateEmptyTextBox(Input textBox)
        {
            string input = textBox.Text;

            textBox.BackColor = SystemColors.Window;

            if (string.IsNullOrWhiteSpace(input))
            {
                textBox.BackColor = textBox.Focused ? SystemColors.MenuHighlight : Color.DarkGray;
            }
        }

        // 定时器触发时调用，对多个关键输入框执行校验
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

        // 处理“P瓦斯压力”复选框选中状态，更新对应的主窗体静态字段
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
        /// 计算 Wc 值，基于多个参数和公式
        /// </summary>
        /// <returns>计算得到的 Wc，保留4位小数</returns>
        private double getWc()
        {
            float p = 0.1f; // 常数，瓦斯压力参数
            float AD = Convert.ToSingle(_mainForm.AadTextBox.Text.Trim());        // 灰分
            float Md = Convert.ToSingle(_mainForm.MadTextBox.Text.Trim());       // 水分
            float F = Convert.ToSingle(_mainForm.PorosityTextBox.Text.Trim());   // 孔隙率
            float r = Convert.ToSingle(_mainForm.AppDensityTextBox.Text.Trim()); // 视密度
            float a = Convert.ToSingle(_mainForm.AdsorpConstATextBox.Text.Trim());// 吸附常数a
            float b = Convert.ToSingle(_mainForm.AdsorpConstBTextBox.Text.Trim());// 吸附常数b

            // 计算公式：见业务逻辑
            double x = a * b * p * (100 - AD - Md) / ((1 + b * p) * 100 * (1 + 0.31 * Md)) + F / (100 * r);

            return Math.Round(x, 4);
        }

        // 计算按钮点击事件处理函数，执行全部相关计算并显示结果
        public void ExpCalcButton_Click(object sender, EventArgs e)
        {
            // 计算Wc
            MainForm.Wc = getWc();
            _mainForm.NonDesorpGasQtyTextBox.Text = MainForm.Wc.ToString("F2");

            // 计算W1
            float SampleWeight = (float)Convert.ToDecimal(_mainForm.SampleWeightTextBox.Text);       // 煤样重量
            float SampLossVol = (float)Convert.ToDecimal(_mainForm.SampLossVolTextBox.Text);         // 取样损失体积
            float UndDesorpCal = (float)Convert.ToDecimal(_mainForm.UndDesorpCalTextBox.Text);       // 井下解吸校准
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

            // 重新读取 Wc 并显示
            MainForm.Wc = (float)Convert.ToDecimal(_mainForm.NonDesorpGasQtyTextBox.Text);
            _mainForm.Wc_TextBox.Text = MainForm.Wc.ToString("F2");

            // 计算 W 总量
            MainForm.W = MainForm.Wa + MainForm.Wc;
            _mainForm.W_TextBox.Text = MainForm.W.ToString("F2");

            /*
             * 以下是计算瓦斯压力 P 的复杂公式，变量含义见注释
             */
            string a = _mainForm.AdsorpConstATextBox.Text.Trim();
            string b = _mainForm.AdsorpConstBTextBox.Text.Trim();
            string Porosity = _mainForm.PorosityTextBox.Text.Trim();// 孔隙率
            string Mad = _mainForm.MadTextBox.Text.Trim();// 水分
            string AppDensity = _mainForm.AppDensityTextBox.Text.Trim();// 相对视密度
            string Aad = _mainForm.AadTextBox.Text.Trim();// 灰分
            string W = _mainForm.W_TextBox.Text.Trim();// W
            double at =
                1000 * Convert.ToDouble(b)
                * (Convert.ToDouble(Porosity) / 100)
                + 310 * Convert.ToDouble(b)
                * Convert.ToDouble(Mad)
                * (Convert.ToDouble(Porosity) / 100);
            double bt =
                Convert.ToDouble(a)
                * Convert.ToDouble(b)
                * Convert.ToDouble(AppDensity)
                * (100 - Convert.ToDouble(Aad) - Convert.ToDouble(Mad))
                + 1000 * (Convert.ToDouble(Porosity) / 100)
                - 100 * Convert.ToDouble(b)
                * Convert.ToDouble(W)
                * Convert.ToDouble(AppDensity)
                + 310 * Convert.ToDouble(Mad)
                * (Convert.ToDouble(Porosity) / 100)
                - 31 * Convert.ToDouble(b)
                * Convert.ToDouble(Mad)
                * Convert.ToDouble(W)
                * Convert.ToDouble(AppDensity);
            double ct =
                -100 * Convert.ToDouble(W)
                * Convert.ToDouble(AppDensity)
                - 31 * Convert.ToDouble(Mad)
                * Convert.ToDouble(W)
                * Convert.ToDouble(AppDensity);

            // 使用二次公式求根，并减去0.1作为最终瓦斯压力 P
            double Pt = Math.Round((-bt + Math.Sqrt(bt * bt - 4 * at * ct)) / (2 * at), 4) - 0.1;
            MainForm.P = Pt;
            _mainForm.P_TextBox.Text = MainForm.P.ToString("F2");

            // 修改了数据，未保存直接计算
            if (_mainForm.tabPage4.Text == "*实验结果*")
            {
                _mainForm.tabPage4.Text = "*实验结果";
            }
            // 保存未计算
            else if (_mainForm.tabPage4.Text == "实验结果*")
            {
                _mainForm.tabPage4.Text = "实验结果";
            }
        }
    }
}
