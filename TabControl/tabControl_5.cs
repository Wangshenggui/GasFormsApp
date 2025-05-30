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
            // 选择保存位置
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Word 文件 (*.docx)|*.docx",
                Title = "保存生成的 Word 文件"
            };

            string outputPath = "";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
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



                        // 使用别名创建 Word 应用实例
                        Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                        // 打开生成的 Word 文件
                        Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(outputPath);
                        wordApp.Visible = false;
                        Microsoft.Office.Interop.Word.Range bookmarkRange = doc.Bookmarks["ChartPlaceholder"].Range;
                        Microsoft.Office.Interop.Word.Bookmarks bookmarks = doc.Bookmarks;
                        // 插入到 Word 书签位置
                        if (doc.Bookmarks.Exists("ChartPlaceholder"))
                        {
                            // 获取当前目录下的图片路径
                            string imagePath = Path.Combine(Environment.CurrentDirectory, "output_image.png");

                            // 插入图片作为 InlineShape
                            InlineShape insertedImage = doc.InlineShapes.AddPicture(
                                FileName: imagePath,
                                LinkToFile: false,
                                SaveWithDocument: true,
                                Range: bookmarkRange
                            );

                            // 设置图片大小
                            insertedImage.LockAspectRatio = MsoTriState.msoFalse;
                            float k = 32;
                            insertedImage.Width = 6 * k;
                            insertedImage.Height = 6 * k;

                            // 重新添加书签（如果插入后书签被清除）
                            if (!doc.Bookmarks.Exists("ChartPlaceholder"))
                            {
                                doc.Bookmarks.Add("ChartPlaceholder", insertedImage.Range);
                            }
                        }

                        else
                        {
                            MessageBox.Show("未找到书签 'ChartPlaceholder'，请检查 Word 模板！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // 插入图表完毕后释放 Word 中用到的所有对象
                        if (bookmarkRange != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(bookmarkRange);
                        if (bookmarks != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(bookmarks);


                        // 保存并关闭 Word 文档
                        doc.Save();
                        // 导出为PDF，参数依次为：输出文件路径，导出格式
                        string pdfPath = Path.ChangeExtension(outputPath, ".pdf");
                        doc.ExportAsFixedFormat(pdfPath, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
                        doc.Close(false);
                        Marshal.ReleaseComObject(doc);
                        wordApp.Quit(false);
                        Marshal.ReleaseComObject(wordApp);
                    }
                }
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
