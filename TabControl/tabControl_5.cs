using GasFormsApp.WordPperation;
using System;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace GasFormsApp.TabControl
{
    /// <summary>
    /// 处理主窗体中第五个标签页(tabPage5)的所有功能
    /// 包括报告生成、数据保存、临时数据恢复等
    /// </summary>
    internal class tabControl_5
    {
        private MainForm _mainForm; // 主窗体引用

        // 定义要监控的所有文本框
        private List<Control> _trackedControls = new List<Control>();

        /// <summary>
        /// 构造函数，初始化与主窗体的关联
        /// </summary>
        /// <param name="form">主窗体实例</param>
        public tabControl_5(MainForm form)
        {
            _mainForm = form;

            // 设置工具提示
            _mainForm.toolTip1.SetToolTip(_mainForm.GenReportButton, "生成报告(Ctrl + G)");
            _mainForm.toolTip1.SetToolTip(_mainForm.SaveButton, "保存数据(Ctrl + S)");
            _mainForm.toolTip1.SetToolTip(_mainForm.tabPage5TemporarySavingButton, "临时保存(Ctrl + Shift + S)");
            _mainForm.toolTip1.SetToolTip(_mainForm.tabPage5RecoverDataButton, "恢复数据(Ctrl + R)");

            // 注册事件处理程序
            _mainForm.GenReportButton.Click += GenReportButton_Click;
            _mainForm.GenRecordButton.Click += GenRecordButton_Click;
            _mainForm.SaveButton.Click += _SaveButton_Click;
            _mainForm.tabPage5DoubleBufferedPanel1.SizeChanged += tabPage5DoubleBufferedPanel1_SizeChanged;

            _mainForm.tabPage5TemporarySavingButton.Click += tabPage5TemporarySavingButton_Click;
            _mainForm.tabPage5RecoverDataButton.Click += tabPage5RecoverDataButton_Click;


            // 批量注册内容更改事件
            InitializeTextMonitoring();
        }
        private void InitializeTextMonitoring()
        {
            // 添加所有需要监控的文本框（可通过遍历容器控件自动发现）
            _trackedControls.AddRange(
                new Control[] {
                    _mainForm.CH4TextBox,
                    _mainForm.CO2TextBox,
                    _mainForm.N2TextBox,
                    _mainForm.O2TextBox,
                    _mainForm.C2H4TextBox,
                    _mainForm.C3H8TextBox,
                    _mainForm.C2H6TextBox,
                    _mainForm.C3H6TextBox,
                    _mainForm.C2H2TextBox,
                    _mainForm.COTextBox,
                    _mainForm.dateTimePicker6,
                    _mainForm.dateTimePicker1,
                    _mainForm.DownholeTestersTextBox,
                    _mainForm.LabTestersTextBox,
                    _mainForm.AuditorTextBox,
                    _mainForm.RemarkTextBox,
                }
            );

            // 批量绑定事件
            foreach (var control in _trackedControls)
            {
                if (control is TextBox textBox)
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

            if (changedControl is TextBox textBox)
                currentValue = textBox.Text;
            else if (changedControl is ComboBox comboBox)
                currentValue = comboBox.Text;
            else if (changedControl is DateTimePicker dateTimePicker)
                currentValue = dateTimePicker.Value.ToString("yyyy-MM-dd");
            else
                currentValue = string.Empty;

            Console.WriteLine($"{changedControl.Name} 的值已修改: {currentValue}");

            _mainForm.tabPage5.Text = "*文档输出*";
        }

        /// <summary>
        /// 临时数据序列化类，保存tabPage5的所有相关数据
        /// </summary>
        [Serializable]
        public class tab5TempData
        {
            public string CH4Text { get; set; }       // CH4含量
            public string CO2Text { get; set; }      // CO2含量
            public string N2Text { get; set; }       // N2含量
            public string O2Text { get; set; }       // O2含量
            public string C2H4Text { get; set; }     // C2H4含量
            public string C3H8Text { get; set; }     // C3H8含量
            public string C2H6Text { get; set; }     // C2H6含量
            public string C3H6Text { get; set; }     // C3H6含量
            public string C2H2Text { get; set; }     // C2H2含量
            public string COText { get; set; }       // CO含量

            public string _dateTimePicker6 { get; set; }          // 日期时间控件6的值
            public string _dateTimePicker1 { get; set; }          // 日期时间控件1的值
            public string DownholeTestersText { get; set; }       // 井下测试人员
            public string LabTestersText { get; set; }            // 实验室测试人员
            public string AuditorText { get; set; }                // 审核人
            public string RemarkText { get; set; }                // 备注
        }

        /// <summary>
        /// 临时保存按钮点击事件处理
        /// </summary>
        public void tabPage5TemporarySavingButton_Click(object sender, EventArgs e)
        {
            // 构造TempData对象并从控件中读取数据
            tab5TempData data = new tab5TempData
            {
                CH4Text = _mainForm.CH4TextBox.Text,
                CO2Text = _mainForm.CO2TextBox.Text,
                N2Text = _mainForm.N2TextBox.Text,
                O2Text = _mainForm.O2TextBox.Text,
                C2H4Text = _mainForm.C2H4TextBox.Text,
                C3H8Text = _mainForm.C3H8TextBox.Text,
                C2H6Text = _mainForm.C2H6TextBox.Text,
                C3H6Text = _mainForm.C3H6TextBox.Text,
                C2H2Text = _mainForm.C2H2TextBox.Text,
                COText = _mainForm.COTextBox.Text,

                _dateTimePicker6 = _mainForm.dateTimePicker6.Value.ToString("yyyy-MM-dd"),
                _dateTimePicker1 = _mainForm.dateTimePicker1.Value.ToString("yyyy-MM-dd"),

                DownholeTestersText = _mainForm.DownholeTestersTextBox.Text,
                LabTestersText = _mainForm.LabTestersTextBox.Text,
                AuditorText = _mainForm.AuditorTextBox.Text,
                RemarkText = _mainForm.RemarkTextBox.Text
            };

            // 确保临时数据目录存在
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string tempFolder = Path.Combine(currentDir, "TempData");
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }

            string savePath = Path.Combine(tempFolder, "tabPage5_temp.bin");

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

                //MessageBox.Show("保存成功！");

                if (_mainForm.tabPage5.Text == "*文档输出*")
                {
                    // 去掉前面一个“*”
                    _mainForm.tabPage5.Text = "文档输出*";
                }
                else if (_mainForm.tabPage5.Text == "*文档输出")
                {
                    // 去掉前面一个“*”
                    _mainForm.tabPage5.Text = "文档输出";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 恢复数据按钮点击事件处理
        /// </summary>
        public void tabPage5RecoverDataButton_Click(object sender, EventArgs e)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string loadPath = Path.Combine(currentDir, "TempData", "tabPage5_temp.bin");

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
                    tab5TempData data = (tab5TempData)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011

                    // 恢复控件值
                    _mainForm.CH4TextBox.Text = data.CH4Text;
                    _mainForm.CO2TextBox.Text = data.CO2Text;
                    _mainForm.N2TextBox.Text = data.N2Text;
                    _mainForm.O2TextBox.Text = data.O2Text;
                    _mainForm.C2H4TextBox.Text = data.C2H4Text;
                    _mainForm.C3H8TextBox.Text = data.C3H8Text;
                    _mainForm.C2H6TextBox.Text = data.C2H6Text;
                    _mainForm.C3H6TextBox.Text = data.C3H6Text;
                    _mainForm.C2H2TextBox.Text = data.C2H2Text;
                    _mainForm.COTextBox.Text = data.COText;

                    //_mainForm.dateTimePicker6.Value = DateTime.TryParse(data._dateTimePicker6, out var dt6) ? dt6 : DateTime.Now;
                    //_mainForm.dateTimePicker1.Value = DateTime.TryParse(data._dateTimePicker1, out var dt1) ? dt1 : DateTime.Now;
                    // 安全赋值，只在值变化时才设置
                    DateTime newValue6 = DateTime.Parse(data._dateTimePicker6);
                    if (_mainForm.dateTimePicker6.Value.Date != newValue6.Date)
                    {
                        _mainForm.dateTimePicker6.Value = newValue6;
                    }
                    DateTime newValue1 = DateTime.Parse(data._dateTimePicker1);
                    if (_mainForm.dateTimePicker1.Value.Date != newValue1.Date)
                    {
                        _mainForm.dateTimePicker1.Value = newValue1;
                    }

                    _mainForm.DownholeTestersTextBox.Text = data.DownholeTestersText;
                    _mainForm.LabTestersTextBox.Text = data.LabTestersText;
                    _mainForm.AuditorTextBox.Text = data.AuditorText;
                    _mainForm.RemarkTextBox.Text = data.RemarkText;

                    MessageBox.Show("数据已恢复！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 检查是否有任何气体成分被选中
        /// </summary>
        /// <returns>如果有选中则返回true，否则false</returns>
        public bool IsAnyGasChecked()
        {
            return _mainForm.CH4CheckBox.Checked ||
                   _mainForm.CO2CheckBox.Checked ||
                   _mainForm.N2CheckBox.Checked ||
                   _mainForm.O2CheckBox.Checked ||
                   _mainForm.C2H4CheckBox.Checked ||
                   _mainForm.C3H8CheckBox.Checked ||
                   _mainForm.C2H6CheckBox.Checked ||
                   _mainForm.C3H6CheckBox.Checked ||
                   _mainForm.C2H2CheckBox.Checked ||
                   _mainForm.COCheckBox.Checked;
        }

        /// <summary>
        /// 定时检查输入数据
        /// </summary>
        public void TabControl_5_InputCheckTimer_Tick()
        {
            MainForm.GasCompCheckBoxFlag = IsAnyGasChecked();
        }

        /// <summary>
        /// 面板大小改变事件处理
        /// </summary>
        private void tabPage5DoubleBufferedPanel1_SizeChanged(object sender, EventArgs e)
        {
            // 计算新宽度和高度
            int newWidth = _mainForm.tabPage5DoubleBufferedPanel1.ClientSize.Width / 1 - _mainForm.tabPage5DoubleBufferedPanel1.ClientSize.Width / 7;
            int newHeight = _mainForm.tabPage5DoubleBufferedPanel1.ClientSize.Height / 1 - _mainForm.tabPage5DoubleBufferedPanel1.ClientSize.Height / 10;

            // 根据宽度调整布局
            if (newWidth >= 515 && newWidth <= 566)
            {
                newWidth = 415;
                _mainForm.tabPage5DoubleBufferedFlowLayoutPanel2.Width = newWidth;
                _mainForm.tabPage5DoubleBufferedFlowLayoutPanel2.Height = newHeight;
                _mainForm.tabPage5panel11.Width = newWidth - 23;
                _mainForm.tabPage5panel12.Width = newWidth - 23;
                _mainForm.tabPage5panel13.Width = newWidth - 23;
                _mainForm.tabPage5panel14.Width = newWidth - 23;
                _mainForm.tabPage5panel15.Width = newWidth - 23;
                _mainForm.tabPage5panel16.Width = newWidth - 23;
                _mainForm.tabPage5panel17.Width = newWidth - 23;
            }
            else if (newWidth > 566 && newWidth <= 750)
            {
                newWidth = 600 + 15;
                _mainForm.tabPage5DoubleBufferedFlowLayoutPanel2.Width = newWidth;
                _mainForm.tabPage5DoubleBufferedFlowLayoutPanel2.Height = newHeight;
                _mainForm.tabPage5panel11.Width = newWidth - 28;
                _mainForm.tabPage5panel12.Width = newWidth - 28;
                _mainForm.tabPage5panel13.Width = newWidth - 28;
                _mainForm.tabPage5panel14.Width = newWidth - 28;
                _mainForm.tabPage5panel15.Width = newWidth - 28;
                _mainForm.tabPage5panel16.Width = newWidth - 28;
                _mainForm.tabPage5panel17.Width = newWidth - 28;
            }
            else if (newWidth > 750 && newWidth <= 939)
            {
                newWidth = 800;
                _mainForm.tabPage5DoubleBufferedFlowLayoutPanel2.Width = newWidth;
                _mainForm.tabPage5DoubleBufferedFlowLayoutPanel2.Height = newHeight;
                _mainForm.tabPage5panel11.Width = 415 - 30;
                _mainForm.tabPage5panel12.Width = 415 - 30;
                _mainForm.tabPage5panel13.Width = 415 - 30;
                _mainForm.tabPage5panel14.Width = 415 - 30;
                _mainForm.tabPage5panel15.Width = 415 - 30;
                _mainForm.tabPage5panel16.Width = 415 - 30;
                _mainForm.tabPage5panel17.Width = 415 - 30;
            }
            else if (newWidth > 939)
            {
                newWidth = 1000;
                newHeight = 460;
                int a = 28;
                _mainForm.tabPage5DoubleBufferedFlowLayoutPanel2.Width = newWidth;
                _mainForm.tabPage5DoubleBufferedFlowLayoutPanel2.Height = newHeight;
                _mainForm.tabPage5panel11.Width = 500 + 15 - a;
                _mainForm.tabPage5panel12.Width = 500 + 15 - a;
                _mainForm.tabPage5panel13.Width = 500 + 15 - a;
                _mainForm.tabPage5panel14.Width = 500 + 15 - a;
                _mainForm.tabPage5panel15.Width = 500 + 15 - a;
                _mainForm.tabPage5panel16.Width = 500 + 15 - a;
                _mainForm.tabPage5panel17.Width = 500 + 15 - a;
                newHeight = 460;
            }

            // 居中定位
            _mainForm.tabPage5DoubleBufferedFlowLayoutPanel2.Left = (_mainForm.tabPage5DoubleBufferedPanel1.ClientSize.Width - newWidth) / 2;
            _mainForm.tabPage5DoubleBufferedFlowLayoutPanel2.Top = (_mainForm.tabPage5DoubleBufferedPanel1.ClientSize.Height - newHeight) / 2;
        }

        /// <summary>
        /// 模板资源映射字典
        /// 键: (是否有Wc数据, 是否有气体成分数据, Wc选项数量, Gas选项数量)
        /// 值: 对应的Word模板资源名称
        /// </summary>
        private static readonly Dictionary<(bool, bool, int, int), string>
            resourceMap = new Dictionary<(bool, bool, int, int), string>
        {
            // 无缺失数据
            { ( true,  true, 1, 1), "WPSGasFormsApp.WordTemplate1_1.docx" },
            { ( true,  true, 1, 2), "WPSGasFormsApp.WordTemplate1_2.docx" },
            { ( true,  true, 2, 1), "WPSGasFormsApp.WordTemplate2_1.docx" },
            { ( true,  true, 2, 2), "WPSGasFormsApp.WordTemplate2_2.docx" },
            { ( true,  true, 3, 1), "WPSGasFormsApp.WordTemplate3_1.docx" },
            { ( true,  true, 3, 2), "WPSGasFormsApp.WordTemplate3_2.docx" },

            // 缺失Gas
            { ( true,  false, 1, 1), "WPSGasFormsApp.WordTemplateNoGas1.docx" },
            { ( true,  false, 2, 1), "WPSGasFormsApp.WordTemplateNoGas2.docx" },
            { ( true,  false, 3, 1), "WPSGasFormsApp.WordTemplateNoGas3.docx" },

            // 缺失Wc
            { ( false,  true, 1, 1), "WPSGasFormsApp.WordTemplateNoWc1.docx" },
            { ( false,  true, 1, 2), "WPSGasFormsApp.WordTemplateNoWc2.docx" },

            // 缺失Gas和Wc
            { ( false,  false, 1, 1), "WPSGasFormsApp.WordTemplateNoWcNoGas.docx" },
        };

        /// <summary>
        /// 根据条件获取Word模板资源名称
        /// </summary>
        private string Word_ResourceName(bool wcFlag, bool gasCompFlag, int Wc数量, int Gas数量)
        {
            if (resourceMap.TryGetValue((wcFlag, gasCompFlag, Wc数量, Gas数量), out var resourceName))
            {
                return resourceName;
            }
            else
            {
                // 默认返回一个模板
                return "WPSGasFormsApp.GasFormsApp.WordTemplate3_2.docx";
            }
        }

        /// <summary>
        /// 记录表模板资源映射字典
        /// </summary>
        private static readonly Dictionary<(bool, bool, int, int), string>
            RecordMap = new Dictionary<(bool, bool, int, int), string>
        {
            // 无缺失数据
            { ( true,  true, 1, 1), "WPSGasFormsApp.RecordSheets1_1.docx" },
            { ( true,  true, 1, 2), "WPSGasFormsApp.RecordSheets1_2.docx" },
            { ( true,  true, 2, 1), "WPSGasFormsApp.RecordSheets2_1.docx" },
            { ( true,  true, 2, 2), "WPSGasFormsApp.RecordSheets2_2.docx" },
            { ( true,  true, 3, 1), "WPSGasFormsApp.RecordSheets3_1.docx" },
            { ( true,  true, 3, 2), "WPSGasFormsApp.RecordSheets3_2.docx" },

            // 缺失Gas
            { ( true,  false, 1, 1), "WPSGasFormsApp.RecordSheetsNoGas1.docx" },
            { ( true,  false, 2, 1), "WPSGasFormsApp.RecordSheetsNoGas2.docx" },
            { ( true,  false, 3, 1), "WPSGasFormsApp.RecordSheetsNoGas3.docx" },

            // 缺失Wc
            { ( false,  true, 1, 1), "WPSGasFormsApp.RecordSheetsNoWc1.docx" },
            { ( false,  true, 1, 2), "WPSGasFormsApp.RecordSheetsNoWc2.docx" },

            // 缺失Gas和Wc
            { ( false,  false, 1, 1), "WPSGasFormsApp.RecordSheetsNoWcNoGas.docx" },
        };

        /// <summary>
        /// 根据条件获取记录表模板资源名称
        /// </summary>
        private string Word_RecordName(bool wcFlag, bool gasCompFlag, int Wc数量, int Gas数量)
        {
            if (RecordMap.TryGetValue((wcFlag, gasCompFlag, Wc数量, Gas数量), out var resourceName))
            {
                return resourceName;
            }
            else
            {
                // 默认返回一个模板
                return "WPSGasFormsApp.GasFormsApp.WordTemplate3_2.docx";
            }
        }

        /// <summary>
        /// 动态处理Wc选项并返回选项数量分类(1-3)
        /// </summary>
        int 动态处理Wc选项()
        {
            // 收集选中的Wc选项
            List<(string Label, string Data)> selectedWc = new List<(string, string)>();
            if (_mainForm.AdsorpConstACheckBox.Checked)
                selectedWc.Add(("吸附常数a值(cm3/g)：", _mainForm.AdsorpConstATextBox.Text));
            if (_mainForm.AdsorpConstBCheckBox.Checked)
                selectedWc.Add(("吸附常数b值(MPa-1)：", _mainForm.AdsorpConstBTextBox.Text));
            if (_mainForm.MadCheckBox.Checked)
                selectedWc.Add(("水分Mad/%：", _mainForm.MadTextBox.Text));
            if (_mainForm.AadCheckBox.Checked)
                selectedWc.Add(("灰分Aad/%：", _mainForm.AadTextBox.Text));
            if (_mainForm.VadCheckBox.Checked)
                selectedWc.Add(("挥发分Vad/%：", _mainForm.VadTextBox.Text));
            if (_mainForm.AppDensityCheckBox.Checked)
                selectedWc.Add(("视相对密度γ：", _mainForm.AppDensityTextBox.Text));
            if (_mainForm.TrueDensityCheckBox.Checked)
                selectedWc.Add(("真密度(g/cm3)：", _mainForm.TrueDensityTextBox.Text));
            if (_mainForm.PorosityCheckBox.Checked)
                selectedWc.Add(("孔隙率K/%：", _mainForm.PorosityTextBox.Text));
            if (_mainForm.NonDesorpGasQtyCheckBox.Checked)
                selectedWc.Add(("不可解吸瓦斯量Wc(m3/t)：", _mainForm.NonDesorpGasQtyTextBox.Text));

            // 清空9组槽位
            for (int i = 1; i <= 9; i++)
            {
                typeof(MainForm).GetField($"Wc_Lab{i}").SetValue(null, "");
                typeof(MainForm).GetField($"Wc_Dat{i}").SetValue(null, "");
            }

            // 将选中的数据写入槽位
            for (int i = 0; i < selectedWc.Count && i < 9; i++)
            {
                typeof(MainForm).GetField($"Wc_Lab{i + 1}").SetValue(null, selectedWc[i].Item1);
                typeof(MainForm).GetField($"Wc_Dat{i + 1}").SetValue(null, selectedWc[i].Item2);
            }

            // 统计有效数据数量
            var validWc = selectedWc.Where(g => !string.IsNullOrWhiteSpace(g.Data)).ToList();

            // 根据数量返回分类
            if (validWc.Count <= 3)
                return 1;
            else if (validWc.Count <= 6)
                return 2;
            else
                return 3;
        }

        /// <summary>
        /// 动态处理Gas选项并返回选项数量分类(1-2)
        /// </summary>
        int 动态处理Gas选项()
        {
            // 收集选中的气体成分选项
            List<(string Label, string Data)> selectedGases = new List<(string, string)>();
            if (_mainForm.CH4CheckBox.Checked)
                selectedGases.Add(("CH₄：", _mainForm.CH4TextBox.Text));
            if (_mainForm.CO2CheckBox.Checked)
                selectedGases.Add(("CO₂：", _mainForm.CO2TextBox.Text));
            if (_mainForm.N2CheckBox.Checked)
                selectedGases.Add(("N₂：", _mainForm.N2TextBox.Text));
            if (_mainForm.O2CheckBox.Checked)
                selectedGases.Add(("O₂：", _mainForm.O2TextBox.Text));
            if (_mainForm.C2H4CheckBox.Checked)
                selectedGases.Add(("C₂H₄：", _mainForm.C2H4TextBox.Text));
            if (_mainForm.C3H8CheckBox.Checked)
                selectedGases.Add(("C₃H₈：", _mainForm.C3H8TextBox.Text));
            if (_mainForm.C2H6CheckBox.Checked)
                selectedGases.Add(("C₂H₆：", _mainForm.C2H6TextBox.Text));
            if (_mainForm.C3H6CheckBox.Checked)
                selectedGases.Add(("C₃H₆：", _mainForm.C3H6TextBox.Text));
            if (_mainForm.C2H2CheckBox.Checked)
                selectedGases.Add(("C₂H₂：", _mainForm.C2H2TextBox.Text));
            if (_mainForm.COCheckBox.Checked)
                selectedGases.Add(("CO：", _mainForm.COTextBox.Text));

            // 清空10组槽位
            for (int i = 1; i <= 10; i++)
            {
                typeof(MainForm).GetField($"GasComp_Lab{i}").SetValue(null, "");
                typeof(MainForm).GetField($"GasComp_Dat{i}").SetValue(null, "");
            }

            // 将选中的数据写入槽位
            for (int i = 0; i < selectedGases.Count && i < 10; i++)
            {
                typeof(MainForm).GetField($"GasComp_Lab{i + 1}").SetValue(null, selectedGases[i].Item1);
                typeof(MainForm).GetField($"GasComp_Dat{i + 1}").SetValue(null, selectedGases[i].Item2);
            }

            // 获取瓦斯压力
            _mainForm.tab5_4_P瓦斯压力选择();

            // 统计有效数据数量
            var validWc = selectedGases.Where(g => !string.IsNullOrWhiteSpace(g.Data)).ToList();

            // 根据数量返回分类
            if (validWc.Count <= 5)
                return 1;
            else
                return 2;
        }

        /// <summary>
        /// 保存按钮点击事件
        /// </summary>
        public void _SaveButton_Click(object sender, EventArgs e)
        {
            string[] inputs = { 
                _mainForm.tabPage1.Text, _mainForm.tabPage2.Text, 
                _mainForm.tabPage3.Text, _mainForm.tabPage4.Text 
            };
            bool hasAsterisk = inputs.Any(s => s.Contains("*"));
            if (hasAsterisk)
            {
                Console.WriteLine("至少有一个字符串包含 *");

                DialogResult result = MessageBox.Show(
                "有未保存步骤，是否忽略？",
                "提示",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }
            else
            {
                Console.WriteLine("所有字符串都不包含 *");
            }

            bool flag;
            flag = _mainForm.tab5_6_SaveButton(sender, e);
            if (flag)
            {
                // 修改了数据，未保存直接计算
                if (_mainForm.tabPage5.Text == "*文档输出*")
                {
                    _mainForm.tabPage5.Text = "*文档输出";
                }
                // 保存未计算
                else if (_mainForm.tabPage5.Text == "文档输出*")
                {
                    _mainForm.tabPage5.Text = "文档输出";
                }

                MessageBox.Show("保存成功！", "提示：");
            }
            else
            {
                
            }
        }

        /// <summary>
        /// 生成记录表按钮点击事件
        /// </summary>
        public void GenRecordButton_Click(object sender, EventArgs e)
        {
            string[] inputs = {
                _mainForm.tabPage1.Text, _mainForm.tabPage2.Text,
                _mainForm.tabPage3.Text, _mainForm.tabPage4.Text
            };
            bool hasAsterisk = inputs.Any(s => s.Contains("*"));
            if (hasAsterisk)
            {
                Console.WriteLine("至少有一个字符串包含 *");

                DialogResult result = MessageBox.Show(
                "有未保存步骤，是否忽略？",
                "提示",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }
            else
            {
                Console.WriteLine("所有字符串都不包含 *");
            }

            // 选择保存位置
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Word 文件 (*.docx)|*.docx",
                Title = "保存生成的 Word 文件"
            };

            string outputPath = "";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // 设置等待光标
                void SetWaitCursor(System.Windows.Forms.Control control, Cursor cursor)
                {
                    control.Cursor = cursor;
                    foreach (System.Windows.Forms.Control child in control.Controls)
                    {
                        SetWaitCursor(child, cursor);
                    }
                }
                SetWaitCursor(_mainForm, Cursors.WaitCursor);

                outputPath = saveDialog.FileName;

                // 处理Wc和Gas选项
                MainForm.Wc选项数量 = 动态处理Wc选项();
                MainForm.Gas选项数量 = 动态处理Gas选项();

                // 获取程序集
                var assembly = Assembly.GetExecutingAssembly();

                // 调试输出嵌入资源列表
                string[] resourceNames = assembly.GetManifestResourceNames();
                Console.WriteLine("嵌入的资源列表：");
                foreach (string name in resourceNames)
                {
                    Console.WriteLine(name);
                }

                // 获取记录表模板资源名称
                string Word_resourceName = Word_RecordName(MainForm.WcOutCheckBoxFlag, MainForm.GasCompCheckBoxFlag, MainForm.Wc选项数量, MainForm.Gas选项数量);
                Console.WriteLine($"寻找的记录表文件：{Word_resourceName}");

                // 使用文件流读取模板
                using (FileStream resourceStream = new FileStream(Word_resourceName, FileMode.Open))
                {
                    if (resourceStream == null)
                    {
                        MessageBox.Show("模板资源未找到，请检查资源名称是否正确。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 将模板复制到内存流以便修改
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        resourceStream.CopyTo(memoryStream);

                        // 替换占位符
                        BasicInfo basicInfo = new BasicInfo(_mainForm);
                        string ReportTimeText = _mainForm.dateTimePicker1.Text;

                        basicInfo.ReplaceWordPlaceholders(memoryStream,
                            _mainForm.MineNameTextBox.Text,
                            _mainForm.SamplingSpotTextBox.Text,
                            _mainForm.BurialDepthTextBox.Text,
                            _mainForm.CoalSeamTextBox.Text,
                            _mainForm.SampleNumTextBox.Text,
                            _mainForm.UndAtmPressureTextBox.Text,
                            _mainForm.LabAtmPressureTextBox.Text,
                            _mainForm.UndTempTextBox.Text,
                            _mainForm.LabTempTextBox.Text,
                            _mainForm.SampleWeightTextBox.Text,
                            _mainForm.SampleModeComboBox.Text,
                            _mainForm.MoistureSampleTextBox.Text,
                            _mainForm.RawCoalMoistureTextBox.Text,
                            _mainForm.InitialVolumeTextBox.Text,
                            _mainForm.SamplingTimeDateTimePicker.Value.ToString("yyyy-MM-dd"),
                            ReportTimeText);

                        // 保存到用户指定路径
                        File.WriteAllBytes(outputPath, memoryStream.ToArray());

                        // 使用共享内存传递文件路径给Python处理
                        const string MapName = "Local\\IllustrateMemory";
                        const int Size = 256;  // 共享内存大小

                        // 写入字符串到共享内存
                        void WriteString(string value)
                        {
                            var mmf = MemoryMappedFile.CreateOrOpen(MapName, Size);
                            var accessor = mmf.CreateViewAccessor(0, Size);

                            byte[] bytes = Encoding.UTF8.GetBytes(value);

                            if (bytes.Length > Size)
                                throw new ArgumentException($"字符串太长，最大支持 {Size} 字节");

                            // 先写入长度
                            accessor.Write(0, bytes.Length);
                            // 再写入字符串
                            accessor.WriteArray(4, bytes, 0, bytes.Length);

                            Console.WriteLine($"写入字符串：{value}");
                        }

                        // 从共享内存读取字符串
                        string ReadString()
                        {
                            var mmf = MemoryMappedFile.OpenExisting(MapName);
                            var accessor = mmf.CreateViewAccessor(0, Size);

                            int length = accessor.ReadInt32(0);
                            if (length > Size - 4 || length < 0)
                                throw new InvalidOperationException("读取长度不合理");

                            byte[] bytes = new byte[length];
                            accessor.ReadArray(4, bytes, 0, length);

                            return Encoding.UTF8.GetString(bytes);
                        }

                        // 传递文件路径给Python
                        WriteString(outputPath);
                        string val = ReadString();
                        Console.WriteLine("读取的值：" + val);

                        // 启动Python处理
                        try
                        {
                            var pythonPath = @"Python_embed\python.exe"; // Python解释器路径
                            var scriptPath = @"Python_embed\Python\bbb.cpython-312.pyc"; // Python脚本路径

                            ProcessStartInfo psi = new ProcessStartInfo
                            {
                                FileName = pythonPath,
                                Arguments = $"\"{scriptPath}\"", // 加上引号防止路径带空格
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                RedirectStandardError = true,
                                CreateNoWindow = true
                            };

                            using (Process process = Process.Start(psi))
                            {
                                string output = process.StandardOutput.ReadToEnd();
                                string error = process.StandardError.ReadToEnd();
                                process.WaitForExit();

                                Console.WriteLine("Python output:\n" + output);
                                if (!string.IsNullOrEmpty(error))
                                {
                                    Console.WriteLine("Python error:\n" + error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"执行程序时发生错误：{ex.Message}");
                        }
                    }
                }
                SetWaitCursor(_mainForm, Cursors.Default);
            }
        }

        /// <summary>
        /// 生成报告按钮点击事件
        /// </summary>
        public void GenReportButton_Click(object sender, EventArgs e)
        {
            string[] inputs = {
                _mainForm.tabPage1.Text, _mainForm.tabPage2.Text,
                _mainForm.tabPage3.Text, _mainForm.tabPage4.Text
            };
            bool hasAsterisk = inputs.Any(s => s.Contains("*"));
            if (hasAsterisk)
            {
                Console.WriteLine("至少有一个字符串包含 *");

                DialogResult result = MessageBox.Show(
                "有未保存步骤，是否忽略？",
                "提示",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }
            else
            {
                Console.WriteLine("所有字符串都不包含 *");
            }

            // 选择保存位置
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Word 文件 (*.docx)|*.docx",
                Title = "保存生成的 Word 文件"
            };

            string outputPath = "";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // 设置等待光标
                void SetWaitCursor(System.Windows.Forms.Control control, Cursor cursor)
                {
                    control.Cursor = cursor;
                    foreach (System.Windows.Forms.Control child in control.Controls)
                    {
                        SetWaitCursor(child, cursor);
                    }
                }
                SetWaitCursor(_mainForm, Cursors.WaitCursor);

                outputPath = saveDialog.FileName;

                // 处理Wc和Gas选项
                MainForm.Wc选项数量 = 动态处理Wc选项();
                MainForm.Gas选项数量 = 动态处理Gas选项();

                // 处理井下测试人员信息
                if (_mainForm.DownholeTestersCheckBox.Checked)
                {
                    MainForm.DownholeTestersLab = "井下测试人员：";
                    MainForm.DownholeTestersData = _mainForm.DownholeTestersTextBox.Text;
                }
                else
                {
                    MainForm.DownholeTestersLab = "";
                    MainForm.DownholeTestersData = "";
                }
                Console.WriteLine($"井下测试数据：{MainForm.DownholeTestersLab},{MainForm.DownholeTestersData}");

                // 获取程序集
                var assembly = Assembly.GetExecutingAssembly();

                // 调试输出嵌入资源列表
                string[] resourceNames = assembly.GetManifestResourceNames();
                Console.WriteLine("嵌入的资源列表：");
                foreach (string name in resourceNames)
                {
                    Console.WriteLine(name);
                }

                // 获取报告模板资源名称
                string Word_resourceName = Word_ResourceName(MainForm.WcOutCheckBoxFlag, MainForm.GasCompCheckBoxFlag, MainForm.Wc选项数量, MainForm.Gas选项数量);
                Console.WriteLine($"---------：{Word_resourceName}");

                // 使用文件流读取模板
                using (FileStream resourceStream = new FileStream(Word_resourceName, FileMode.Open))
                {
                    if (resourceStream == null)
                    {
                        MessageBox.Show("模板资源未找到，请检查资源名称是否正确。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 将模板复制到内存流以便修改
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        resourceStream.CopyTo(memoryStream);

                        // 替换占位符
                        BasicInfo basicInfo = new BasicInfo(_mainForm);
                        string ReportTimeText = _mainForm.dateTimePicker1.Text;

                        basicInfo.ReplaceWordPlaceholders(memoryStream,
                            _mainForm.MineNameTextBox.Text,
                            _mainForm.SamplingSpotTextBox.Text,
                            _mainForm.BurialDepthTextBox.Text,
                            _mainForm.CoalSeamTextBox.Text,
                            _mainForm.SampleNumTextBox.Text,
                            _mainForm.UndAtmPressureTextBox.Text,
                            _mainForm.LabAtmPressureTextBox.Text,
                            _mainForm.UndTempTextBox.Text,
                            _mainForm.LabTempTextBox.Text,
                            _mainForm.SampleWeightTextBox.Text,
                            _mainForm.SampleModeComboBox.Text,
                            _mainForm.MoistureSampleTextBox.Text,
                            _mainForm.RawCoalMoistureTextBox.Text,
                            _mainForm.InitialVolumeTextBox.Text,
                            _mainForm.SamplingTimeDateTimePicker.Value.ToString("yyyy-MM-dd"),
                            ReportTimeText);

                        // 保存到用户指定路径
                        File.WriteAllBytes(outputPath, memoryStream.ToArray());

                        // 使用共享内存传递文件路径给Python处理
                        const string MapName = "Local\\IllustrateMemory";
                        const int Size = 256;

                        // 写入字符串到共享内存
                        void WriteString(string value)
                        {
                            var mmf = MemoryMappedFile.CreateOrOpen(MapName, Size);
                            var accessor = mmf.CreateViewAccessor(0, Size);

                            byte[] bytes = Encoding.UTF8.GetBytes(value);

                            if (bytes.Length > Size)
                                throw new ArgumentException($"字符串太长，最大支持 {Size} 字节");

                            accessor.Write(0, bytes.Length);
                            accessor.WriteArray(4, bytes, 0, bytes.Length);

                            Console.WriteLine($"写入字符串：{value}");
                        }

                        // 从共享内存读取字符串
                        string ReadString()
                        {
                            var mmf = MemoryMappedFile.OpenExisting(MapName);
                            var accessor = mmf.CreateViewAccessor(0, Size);

                            int length = accessor.ReadInt32(0);
                            if (length > Size - 4 || length < 0)
                                throw new InvalidOperationException("读取长度不合理");

                            byte[] bytes = new byte[length];
                            accessor.ReadArray(4, bytes, 0, length);

                            return Encoding.UTF8.GetString(bytes);
                        }

                        // 传递文件路径给Python
                        WriteString(outputPath);
                        string val = ReadString();
                        Console.WriteLine("读取的值：" + val);

                        // 启动Python处理
                        try
                        {
                            var pythonPath = @"Python_embed\python.exe";
                            var scriptPath = @"Python_embed\Python\bbb.cpython-312.pyc";

                            ProcessStartInfo psi = new ProcessStartInfo
                            {
                                FileName = pythonPath,
                                Arguments = $"\"{scriptPath}\"",
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                RedirectStandardError = true,
                                CreateNoWindow = true
                            };

                            using (Process process = Process.Start(psi))
                            {
                                string output = process.StandardOutput.ReadToEnd();
                                string error = process.StandardError.ReadToEnd();
                                process.WaitForExit();

                                Console.WriteLine("Python output:\n" + output);
                                if (!string.IsNullOrEmpty(error))
                                {
                                    Console.WriteLine("Python error:\n" + error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"执行程序时发生错误：{ex.Message}");
                        }
                    }
                }
                SetWaitCursor(_mainForm, Cursors.Default);
            }
        }

        /// <summary>
        /// 生成报告到数据库
        /// </summary>
        /// <param name="doc_name">文档名称</param>
        public void GenerateReportToDatabase(string doc_name)
        {
            // 设置等待光标
            void SetWaitCursor(System.Windows.Forms.Control control, Cursor cursor)
            {
                control.Cursor = cursor;
                foreach (System.Windows.Forms.Control child in control.Controls)
                {
                    SetWaitCursor(child, cursor);
                }
            }
            SetWaitCursor(_mainForm, Cursors.WaitCursor);

            // 确定保存路径
            string CurrentDir = AppDomain.CurrentDomain.BaseDirectory;
            string SystemDataPath = Path.Combine(CurrentDir, "SystemData");

            if (!Directory.Exists(SystemDataPath))
            {
                Directory.CreateDirectory(SystemDataPath);
                Console.WriteLine("SystemData 文件夹不存在，已创建");
            }

            string outputPath = Path.Combine(SystemDataPath, $"{doc_name}_Doc.docx");

            // 获取程序集
            var assembly = Assembly.GetExecutingAssembly();

            // 获取报告模板资源名称
            string Word_resourceName = Word_ResourceName(MainForm.WcOutCheckBoxFlag, MainForm.GasCompCheckBoxFlag, MainForm.Wc选项数量, MainForm.Gas选项数量);

            // 使用文件流读取模板
            using (FileStream resourceStream = new FileStream(Word_resourceName, FileMode.Open))
            {
                if (resourceStream == null)
                {
                    MessageBox.Show("模板资源未找到，请检查资源名称是否正确。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 将模板复制到内存流以便修改
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    resourceStream.CopyTo(memoryStream);

                    // 替换占位符
                    BasicInfo basicInfo = new BasicInfo(_mainForm);
                    string ReportTimeText = _mainForm.dateTimePicker1.Text;

                    basicInfo.ReplaceWordPlaceholders(memoryStream,
                        _mainForm.MineNameTextBox.Text,
                        _mainForm.SamplingSpotTextBox.Text,
                        _mainForm.BurialDepthTextBox.Text,
                        _mainForm.CoalSeamTextBox.Text,
                        _mainForm.SampleNumTextBox.Text,
                        _mainForm.UndAtmPressureTextBox.Text,
                        _mainForm.LabAtmPressureTextBox.Text,
                        _mainForm.UndTempTextBox.Text,
                        _mainForm.LabTempTextBox.Text,
                        _mainForm.SampleWeightTextBox.Text,
                        _mainForm.SampleModeComboBox.Text,
                        _mainForm.MoistureSampleTextBox.Text,
                        _mainForm.RawCoalMoistureTextBox.Text,
                        _mainForm.InitialVolumeTextBox.Text,
                        _mainForm.SamplingTimeDateTimePicker.Value.ToString("yyyy-MM-dd"),
                        ReportTimeText);

                    // 保存到指定路径
                    File.WriteAllBytes(outputPath, memoryStream.ToArray());

                    // 使用共享内存传递文件路径给Python处理
                    const string MapName = "Local\\IllustrateMemory";
                    const int Size = 256;

                    // 写入字符串到共享内存
                    void WriteString(string value)
                    {
                        var mmf = MemoryMappedFile.CreateOrOpen(MapName, Size);
                        var accessor = mmf.CreateViewAccessor(0, Size);

                        byte[] bytes = Encoding.UTF8.GetBytes(value);

                        if (bytes.Length > Size)
                            throw new ArgumentException($"字符串太长，最大支持 {Size} 字节");

                        accessor.Write(0, bytes.Length);
                        accessor.WriteArray(4, bytes, 0, bytes.Length);

                        Console.WriteLine($"写入字符串：{value}");
                    }

                    // 从共享内存读取字符串
                    string ReadString()
                    {
                        var mmf = MemoryMappedFile.OpenExisting(MapName);
                        var accessor = mmf.CreateViewAccessor(0, Size);

                        int length = accessor.ReadInt32(0);
                        if (length > Size - 4 || length < 0)
                            throw new InvalidOperationException("读取长度不合理");

                        byte[] bytes = new byte[length];
                        accessor.ReadArray(4, bytes, 0, length);

                        return Encoding.UTF8.GetString(bytes);
                    }

                    // 传递文件路径给Python
                    WriteString(outputPath);
                    string val = ReadString();
                    Console.WriteLine("读取的值：" + val);

                    // 启动Python处理
                    try
                    {
                        var pythonPath = @"Python_embed\python.exe";
                        var scriptPath = @"Python_embed\Python\bbb.cpython-312.pyc";

                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = pythonPath,
                            Arguments = $"\"{scriptPath}\"",
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            CreateNoWindow = true
                        };

                        using (Process process = Process.Start(psi))
                        {
                            string output = process.StandardOutput.ReadToEnd();
                            string error = process.StandardError.ReadToEnd();
                            process.WaitForExit();

                            Console.WriteLine("Python output:\n" + output);
                            if (!string.IsNullOrEmpty(error))
                            {
                                Console.WriteLine("Python error:\n" + error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"执行程序时发生错误：{ex.Message}");
                    }
                }
            }
            SetWaitCursor(_mainForm, Cursors.Default);
        }
    }
}