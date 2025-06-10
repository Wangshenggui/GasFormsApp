using GasFormsApp.WordPperation;
using System;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

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

        private static readonly Dictionary<(bool, bool), string> resourceMap = new Dictionary<(bool, bool), string>
        {
            { ( true,  true), "GasFormsApp.WordTemplate.docx" },
            { ( true, false), "GasFormsApp.WordTemplate_NoGasComponent.docx" },
            { (false,  true), "GasFormsApp.WordTemplate_NoWc.docx" },
            { (false, false), "GasFormsApp.WordTemplate_NoWcNoGasComponent.docx" }
        };
        //private static readonly Dictionary<(bool, bool), string> resourceMap = new Dictionary<(bool, bool), string>
        //{
        //    { ( true,  true), @"E:\E-Desktop\GitHub\GasFormsApp\WordTemplate.docx" },
        //    { ( true, false), @"E:\E-Desktop\GitHub\GasFormsApp\WordTemplate_NoGasComponent.docx" },
        //    { (false,  true), @"E:\E-Desktop\GitHub\GasFormsApp\WordTemplate_NoWc.docx" },
        //    { (false, false), @"E:\E-Desktop\GitHub\GasFormsApp\WordTemplate_NoWcNoGasComponent.docx" }
        //};

        private string Word_ResourceName(bool wcFlag, bool gasCompFlag)
        {
            if (resourceMap.TryGetValue((wcFlag, gasCompFlag), out var resourceName))
            {
                return resourceName;
            }
            else
            {
                // 万一有意外组合，返回默认值
                return "GasFormsApp.WordTemplate.docx";
            }
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

                // 获取程序集
                var assembly = Assembly.GetExecutingAssembly();

                // 尝试读取嵌入资源
                string Word_resourceName = Word_ResourceName(MainForm.WcOutCheckBoxFlag,MainForm.GasCompCheckBoxFlag);
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
                string Word_resourceName = Word_ResourceName(MainForm.WcOutCheckBoxFlag, MainForm.GasCompCheckBoxFlag);
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
