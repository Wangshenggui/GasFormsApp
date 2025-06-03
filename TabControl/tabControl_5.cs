using DocumentFormat.OpenXml.Spreadsheet;
using GasFormsApp.WordPperation;
using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace GasFormsApp.TabControl
{
    internal class tabControl_5
    {
        private MainForm _mainForm;


        // 构造函数接收 TextBox 控件
        public tabControl_5(MainForm form)
        {
            _mainForm = form;

            // 注册回调函数
            _mainForm.button2.Click += button2_Click;
            _mainForm.GasCompCheckBox.Click += CheckBox_Click;

        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;

            //// 可以用控件的名字区分
            //if (tb.Name == "BurialDepthTextBox")
            //{

            //}
            //else if (tb.Name == "MineNameTextBox")
            //{

            //}
            //else
            //{

            //}

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

            // 允许负号，只能第一个字符，且文本中没负号
            //if (e.KeyChar == '-' && tb.SelectionStart == 0 && !tb.Text.Contains("-"))
            //{
            //    return;
            //}

            e.Handled = true;
        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.CheckBox checkBox)
            {
                // 通过 Name 判断哪个被点击
                string name = checkBox.Name;
                string text = checkBox.Text;
                bool isChecked = checkBox.Checked;

                if (name == "GasCompCheckBox")
                {
                    if (isChecked)
                    {
                        Console.WriteLine("勾选");
                        Word_resourceName = "GasFormsApp.WordTemplate.docx";
                        _mainForm.GasCompGroupBox.Enabled = true;
                    }
                    else
                    {
                        Console.WriteLine("取消勾选");
                        Word_resourceName = "GasFormsApp.WordTemplate_1.docx";
                        _mainForm.GasCompGroupBox.Enabled = false;
                    }
                }
            }
        }

        string GetPythonPath()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "where",
                Arguments = "python",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadLine();  // 取第一行输出
                process.WaitForExit();
                return output;  // 返回第一个找到的 python.exe 路径
            }
        }
        static string ExtractPythonScript(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new Exception("资源未找到: " + resourceName);

                string tempPath = Path.Combine(Path.GetTempPath(), "temp_script.py");
                using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }
                return tempPath;
            }
        }
        public void CreateExcelWithChart()
        {
            // 自动获取 Python 可执行文件路径
            string pythonExe = GetPythonPath();

            // 从嵌入资源中提取 Python 脚本，资源名示例 "WindowsFormsApp1.aaa.py"
            string resourceName = "GasFormsApp.Python.aaa.py";  // 注意：一定要改成你项目的资源名，确认见下文
            string scriptPath = ExtractPythonScript(resourceName);

            // 创建进程启动信息
            var psi = new ProcessStartInfo
            {
                FileName = pythonExe,
                Arguments = $"\"{scriptPath}\"",  // 给路径加双引号防止空格问题
                UseShellExecute = false,
                CreateNoWindow = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };

            // 启动进程
            var process = new Process();
            process.StartInfo = psi;
            process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
            process.ErrorDataReceived += (sender, e) => Console.WriteLine("ERR: " + e.Data);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            Console.WriteLine("Python 脚本执行完成。");

            // 可选：运行完删除临时脚本
            try
            {
                if (File.Exists(scriptPath))
                    File.Delete(scriptPath);
            }
            catch { }
        }

        // 默认状态下不勾选 自然瓦斯成分
        string Word_resourceName = "GasFormsApp.WordTemplate_1.docx"; // 注意这个名字必须和实际资源名一致
        private void button2_Click(object sender, EventArgs e)
        {
            //if (MainForm.python执行标志 == true)
            //{
            //    // 写入一个 int 值
            //    MainForm.python执行标志 = false;
            //}
            //else
            //{
            //    MessageBox.Show("请计算井下解吸！", "提示：");
            //    MainForm.python执行标志 = false;
            //    return;
            //}
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
                //string outputPath = @"D:\1.docx";

                // 获取程序集
                var assembly = Assembly.GetExecutingAssembly();
                //string resourceName = "GasFormsApp.WordTemplate.docx"; // 注意这个名字必须和实际资源名一致

                // 尝试读取嵌入资源
                using (Stream resourceStream = assembly.GetManifestResourceStream(Word_resourceName))
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
    }
}
