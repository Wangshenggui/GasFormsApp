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
    internal class tabControl_5
    {
        private MainForm _mainForm;

        // 构造函数接收 TextBox 控件
        public tabControl_5(MainForm form)
        {
            _mainForm = form;

            _mainForm.toolTip1.SetToolTip(_mainForm.GenReportButton, "生成报告(Ctrl + G)");
            _mainForm.toolTip1.SetToolTip(_mainForm.SaveButton, "保存数据(Ctrl + S)");

            // 注册回调函数
            _mainForm.GenReportButton.Click += GenReportButton_Click;
            _mainForm.GasCompCheckBox.Click += CheckBox_Click;
            _mainForm.SaveButton.Click += _SaveButton_Click;
        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                // 通过 Name 判断哪个被点击
                string name = checkBox.Name;
                string text = checkBox.Text;
                bool isChecked = checkBox.Checked;

                if (name == "GasCompCheckBox")
                {
                    if (isChecked)
                    {
                        _mainForm.GasCompGroupBox.Enabled = true;

                        MainForm.GasCompCheckBoxFlag = true;
                    }
                    else
                    {
                        _mainForm.GasCompGroupBox.Enabled = false;

                        MainForm.GasCompCheckBoxFlag = false;
                    }
                }
            }
        }

        private static readonly Dictionary<(bool, bool, int, int), string> 
            resourceMap = new Dictionary<(bool, bool, int, int), string>
        {
            { ( true,  true, 1, 1), "GasFormsApp.WordTemplate1_1.docx" },
            { ( true,  true, 1, 2), "GasFormsApp.WordTemplate1_2.docx" },
            { ( true,  true, 2, 1), "GasFormsApp.WordTemplate2_1.docx" },
            { ( true,  true, 2, 2), "GasFormsApp.WordTemplate2_2.docx" },
            { ( true,  true, 3, 1), "GasFormsApp.WordTemplate3_1.docx" },
            { ( true,  true, 3, 2), "GasFormsApp.WordTemplate3_2.docx" },


            //{ ( true, false), "GasFormsApp.WordTemplate_NoGasComponent.docx" },
            //{ (false,  true), "GasFormsApp.WordTemplate_NoWc.docx" },
            //{ (false, false), "GasFormsApp.WordTemplate_NoWcNoGasComponent.docx" }
        };
        //private static readonly Dictionary<(bool, bool), string> resourceMap = new Dictionary<(bool, bool), string>
        //{
        //    { ( true,  true), @"E:\E-Desktop\GitHub\GasFormsApp\WordTemplate.docx" },
        //    { ( true, false), @"E:\E-Desktop\GitHub\GasFormsApp\WordTemplate_NoGasComponent.docx" },
        //    { (false,  true), @"E:\E-Desktop\GitHub\GasFormsApp\WordTemplate_NoWc.docx" },
        //    { (false, false), @"E:\E-Desktop\GitHub\GasFormsApp\WordTemplate_NoWcNoGasComponent.docx" }
        //};

        private string Word_ResourceName(bool wcFlag, bool gasCompFlag, int Wc数量, int Gas数量)
        {
            if (resourceMap.TryGetValue((wcFlag, gasCompFlag, Wc数量, Gas数量), out var resourceName))
            {
                return resourceName;
            }
            else
            {
                // 万一有意外组合，返回默认值
                return "GasFormsApp.WordTemplate.docx";
            }
        }

        int 动态处理Wc选项()
        {
            // Wc
            List<(string Label, string Data)> selectedWc = new List<(string, string)>();
            if (_mainForm.AdsorpConstACheckBox.Checked)
                selectedWc.Add(("吸附常数a值(cm3/g)：", _mainForm.AdsorpConstATextBox.Text));
            if (_mainForm.AdsorpConstBCheckBox.Checked)
                selectedWc.Add(("吸附常数b值(MPa-1)：", _mainForm.AdsorpConstBTextBox.Text));
            if (_mainForm.MadCheckBox.Checked)
                selectedWc.Add(("水分Mad/%：", _mainForm.MadTextBox.Text));
            if (_mainForm.AadCheckBox.Checked)
                selectedWc.Add(("灰分Aad/%：", _mainForm.AadTextBox.Text));
            if (_mainForm.PorosityCheckBox.Checked)
                selectedWc.Add(("孔隙率K/%：", _mainForm.PorosityTextBox.Text));
            if (_mainForm.AppDensityCheckBox.Checked)
                selectedWc.Add(("视密度γ：", _mainForm.AppDensityTextBox.Text));
            if (_mainForm.VadCheckBox.Checked)
                selectedWc.Add(("挥发分Vad/%：", _mainForm.VadTextBox.Text));
            if (_mainForm.NonDesorpGasQtyCheckBox.Checked)
                selectedWc.Add(("不可解吸瓦斯量Wc(m3/t)：", _mainForm.NonDesorpGasQtyTextBox.Text));
            // 2. 清空 8 组槽位
            for (int i = 1; i <= 8; i++)
            {
                typeof(MainForm).GetField($"Wc_Lab{i}").SetValue(null, "");
                typeof(MainForm).GetField($"Wc_Dat{i}").SetValue(null, "");
            }
            // 3. 将选中的数据依次写入槽位（最多8个）
            for (int i = 0; i < selectedWc.Count && i < 8; i++)
            {
                typeof(MainForm).GetField($"Wc_Lab{i + 1}").SetValue(null, selectedWc[i].Item1);
                typeof(MainForm).GetField($"Wc_Dat{i + 1}").SetValue(null, selectedWc[i].Item2);
            }
            // 4. 打印输出（调试用）
            for (int i = 0; i < selectedWc.Count && i < 8; i++)
            {
                Console.WriteLine($"{selectedWc[i].Item1}{selectedWc[i].Item2}");
            }
            var validWc = selectedWc.Where(g => !string.IsNullOrWhiteSpace(g.Data)).ToList();
            Console.WriteLine($"---------有效数据数量：{validWc.Count}");

            if (validWc.Count <= 3)
                return 1;
            else if (validWc.Count <= 6)
                return 2;
            else
                return 3;
        }
        int 动态处理Gas选项()
        {
            // 1. 收集所有选中的气体项
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
            // 2. 清空 10 组槽位
            for (int i = 1; i <= 10; i++)
            {
                typeof(MainForm).GetField($"GasComp_Lab{i}").SetValue(null, "");
                typeof(MainForm).GetField($"GasComp_Dat{i}").SetValue(null, "");
            }
            // 3. 将选中的数据依次写入槽位（最多10个）
            for (int i = 0; i < selectedGases.Count && i < 10; i++)
            {
                typeof(MainForm).GetField($"GasComp_Lab{i + 1}").SetValue(null, selectedGases[i].Item1);
                typeof(MainForm).GetField($"GasComp_Dat{i + 1}").SetValue(null, selectedGases[i].Item2);
            }
            // 4. 打印输出（调试用）
            for (int i = 0; i < selectedGases.Count && i < 10; i++)
            {
                Console.WriteLine($"{selectedGases[i].Item1}{selectedGases[i].Item2}");
            }
            // 获取瓦斯压力
            _mainForm.tab5_4_P瓦斯压力选择();

            var validWc = selectedGases.Where(g => !string.IsNullOrWhiteSpace(g.Data)).ToList();
            Console.WriteLine($"---------有效数据数量：{validWc.Count}");
            if (validWc.Count <= 5)
                return 1;
            else
                return 2;
        }


        // 保存按钮
        public void _SaveButton_Click(object sender, EventArgs e)
        {
            _mainForm.tab5_6_SaveButton(sender, e);
        }
        public void GenReportButton_Click(object sender, EventArgs e)
        {
            // 选择保存位置
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Word 文件 (*.docx)|*.docx",
                Title = "保存生成的 Word 文件"
            };

            string outputPath = "";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // 设置等待状态
                void SetWaitCursor(System.Windows.Forms.Control control, Cursor cursor)
                {
                    control.Cursor = cursor;
                    foreach (System.Windows.Forms.Control child in control.Controls)
                    {
                        SetWaitCursor(child, cursor);
                    }
                }
                // 等待
                SetWaitCursor(_mainForm, Cursors.WaitCursor);

                outputPath = saveDialog.FileName;

                
                MainForm.Wc选项数量 = 动态处理Wc选项();
                MainForm.Gas选项数量 = 动态处理Gas选项();


                // 获取程序集
                var assembly = Assembly.GetExecutingAssembly();

                // 尝试读取嵌入资源
                string Word_resourceName = Word_ResourceName(MainForm.WcOutCheckBoxFlag,MainForm.GasCompCheckBoxFlag, MainForm.Wc选项数量, MainForm.Gas选项数量);
                //using (Stream resourceStream = assembly.GetManifestResourceStream(Word_resourceName))
                using (FileStream resourceStream = new FileStream(Word_resourceName, FileMode.Open))
                {
                    if (resourceStream == null)
                    {
                        MessageBox.Show("模板资源未找到，请检查资源名称是否正确。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 将嵌入资源复制到内存流以便修改
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

                        const string MapName = "Local\\IllustrateMemory";
                        const int Size = 256;  // 固定大小内存，单位字节

                        void WriteString(string value)
                        {
                            var mmf = MemoryMappedFile.CreateOrOpen(MapName, Size);
                            var accessor = mmf.CreateViewAccessor(0, Size);

                            byte[] bytes = Encoding.UTF8.GetBytes(value);

                            if (bytes.Length > Size)
                                throw new ArgumentException($"字符串太长，最大支持 {Size} 字节");

                            // 先写入长度（int，4字节）
                            accessor.Write(0, bytes.Length);

                            // 再写入字符串字节，紧跟长度后面写
                            accessor.WriteArray(4, bytes, 0, bytes.Length);

                            Console.WriteLine($"写入字符串：{value}");
                        }

                        string ReadString()
                        {
                            var mmf = MemoryMappedFile.OpenExisting(MapName);
                            var accessor = mmf.CreateViewAccessor(0, Size);

                            int length = accessor.ReadInt32(0);
                            if (length > Size - 4 || length < 0)
                                throw new InvalidOperationException("读取长度不合理");

                            byte[] bytes = new byte[length];
                            accessor.ReadArray(4, bytes, 0, length);

                            string value = Encoding.UTF8.GetString(bytes);
                            return value;
                        }
                        // 写入一个 int 值
                        WriteString(outputPath);
                        string val = ReadString();
                        Console.WriteLine("读取的值：" + val);

                        try
                        {
                            var pythonPath = @"Python_embed\python.exe"; // 嵌入式解释器路径
                            //var scriptPath = @"Python_embed\Python\bbb.cpython-312.pyc";           // 你实际的 .py 文件路径
                            var scriptPath = @"Python_embed\Python\bbb.py";

                            ProcessStartInfo psi = new ProcessStartInfo
                            {
                                FileName = pythonPath,
                                Arguments = $"\"{scriptPath}\"",         // 加上引号，防止路径带空格
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
                //打开生成的 Word 文件
                try
                {
                    Process.Start("WINWORD.EXE", $"\"{outputPath}\"");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("无法打开文件: " + ex.Message);
                }
                //this.Close();
            }
            else
            {
                return;
            }
        }
        // 生成报告到数据库
        public void GenerateReportToDatabase(string doc_name)
        {
            //// 选择保存位置
            //SaveFileDialog saveDialog = new SaveFileDialog
            //{
            //    Filter = "Word 文件 (*.docx)|*.docx",
            //    Title = "保存生成的 Word 文件"
            //};

            //string outputPath = "";
            //if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // 设置等待状态
                void SetWaitCursor(System.Windows.Forms.Control control, Cursor cursor)
                {
                    control.Cursor = cursor;
                    foreach (System.Windows.Forms.Control child in control.Controls)
                    {
                        SetWaitCursor(child, cursor);
                    }
                }
                // 等待
                SetWaitCursor(_mainForm, Cursors.WaitCursor);

                // 当前程序目录
                string CurrentDir = AppDomain.CurrentDomain.BaseDirectory;

                // 用于存放系统数据的文件夹路径
                string SystemDataPath = Path.Combine(CurrentDir, "SystemData");

                if (!Directory.Exists(SystemDataPath))
                {
                    Directory.CreateDirectory(SystemDataPath);
                    Console.WriteLine("SystemData 文件夹不存在，已创建");
                }

                // 指定最终文件路径
                string outputPath = Path.Combine(SystemDataPath, $"{doc_name}_Doc.docx");



                // 获取程序集
                var assembly = Assembly.GetExecutingAssembly();

                // 尝试读取嵌入资源
                string Word_resourceName = Word_ResourceName(MainForm.WcOutCheckBoxFlag, MainForm.GasCompCheckBoxFlag, MainForm.Wc选项数量, MainForm.Gas选项数量);
                using (Stream resourceStream = assembly.GetManifestResourceStream(Word_resourceName))
                //using (FileStream resourceStream = new FileStream(Word_resourceName, FileMode.Open))
                {
                    if (resourceStream == null)
                    {
                        MessageBox.Show("模板资源未找到，请检查资源名称是否正确。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 将嵌入资源复制到内存流以便修改
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

                        const string MapName = "Local\\IllustrateMemory";
                        const int Size = 256;  // 固定大小内存，单位字节

                        void WriteString(string value)
                        {
                            var mmf = MemoryMappedFile.CreateOrOpen(MapName, Size);
                            var accessor = mmf.CreateViewAccessor(0, Size);

                            byte[] bytes = Encoding.UTF8.GetBytes(value);

                            if (bytes.Length > Size)
                                throw new ArgumentException($"字符串太长，最大支持 {Size} 字节");

                            // 先写入长度（int，4字节）
                            accessor.Write(0, bytes.Length);

                            // 再写入字符串字节，紧跟长度后面写
                            accessor.WriteArray(4, bytes, 0, bytes.Length);

                            Console.WriteLine($"写入字符串：{value}");
                        }

                        string ReadString()
                        {
                            var mmf = MemoryMappedFile.OpenExisting(MapName);
                            var accessor = mmf.CreateViewAccessor(0, Size);

                            int length = accessor.ReadInt32(0);
                            if (length > Size - 4 || length < 0)
                                throw new InvalidOperationException("读取长度不合理");

                            byte[] bytes = new byte[length];
                            accessor.ReadArray(4, bytes, 0, length);

                            string value = Encoding.UTF8.GetString(bytes);
                            return value;
                        }
                        // 写入一个 int 值
                        WriteString(outputPath);
                        string val = ReadString();
                        Console.WriteLine("读取的值：" + val);

                        try
                        {
                            var pythonPath = @"Python_embed\python.exe"; // 嵌入式解释器路径
                            var scriptPath = @"Python_embed\Python\bbb.cpython-312.pyc";           // 你实际的 .py 文件路径

                            ProcessStartInfo psi = new ProcessStartInfo
                            {
                                FileName = pythonPath,
                                Arguments = $"\"{scriptPath}\"",         // 加上引号，防止路径带空格
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
                ////打开生成的 Word 文件
                //try
                //{
                //    Process.Start("WINWORD.EXE", $"\"{outputPath}\"");
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("无法打开文件: " + ex.Message);
                //}
                //this.Close();
            }
            //else
            //{
            //    return;
            //}
        }
    }
}
