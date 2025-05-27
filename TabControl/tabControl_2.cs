using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasFormsApp.TabControl
{
    internal class tabControl_2
    {
        private MainForm _mainForm;
        private Button _button;
        private TextBox _t0TextBox;
        private TextBox _InitialVolumeTextBox;
        private TextBox _DesVolUndTextBox;
        private TextBox _UndTempTextBox;
        private TextBox _UndAtmPressureTextBox;
        private TextBox _UndDesorpCalTextBox;
        private TextBox _SampLossVolTextBox;


        // 构造函数接收 TextBox 控件
        public tabControl_2(
            MainForm form,
            Button button9,
            TextBox t0TextBox,
            TextBox InitialVolumeTextBox,
            TextBox DesVolUndTextBox,
            TextBox UndTempTextBox,
            TextBox UndAtmPressureTextBox,
            TextBox UndDesorpCalTextBox,
            TextBox SampLossVolTextBox)
        {
            _mainForm = form;
            _button = button9;
            _t0TextBox = t0TextBox;
            _InitialVolumeTextBox = InitialVolumeTextBox;
            _DesVolUndTextBox = DesVolUndTextBox;
            _UndTempTextBox = UndTempTextBox;
            _UndAtmPressureTextBox = UndAtmPressureTextBox;
            _UndDesorpCalTextBox = UndDesorpCalTextBox;
            _SampLossVolTextBox = SampLossVolTextBox;

            // 注册回调函数
            _button.Click += button9_Click;
            
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

        private void button9_Click(object sender, EventArgs e)
        {
            Console.WriteLine("你干么：" + 45);
            // 从文本框或其他地方获取数据，并将其传入函数
            // 假设这些是你窗体上的 TextBox 控件
            TextBox[] DesorbTextBox = new TextBox[60];
            for (int i = 0; i < 60; i++)
            {
                string controlName = $"DesorbTextBox{i + 1}";
                DesorbTextBox[i] = _mainForm.Controls.Find(controlName, true).FirstOrDefault() as TextBox;
            }

            float t0_temp;
            float t0 = 0;
            if (float.TryParse(_t0TextBox.Text, out t0_temp))
            {
                t0 = t0_temp;
            }
            else
            {
                // 转换失败，比如用户输入了非数字
                MessageBox.Show("请输入有效的数字");
            }
            double[,] data = new double[DesorbTextBox.Length, 2]; // 数组大小根据 DesorbTextBox 数量来确定

            for (int i = 0; i < DesorbTextBox.Length; i++) // 循环次数根据 DesorbTextBox 数量确定
            {
                double textBoxValue = 0.0;
                if (!string.IsNullOrWhiteSpace(DesorbTextBox[i].Text) &&
                    double.TryParse(DesorbTextBox[i].Text.Trim(), out double value))
                {
                    textBoxValue = value;
                }
                else
                {
                    textBoxValue = 0;
                }

                double sqrtValue = 0.0;
                int j = i + 1;
                // 定义映射数组，存储31~45对应的a值
                int[] map31to45 = { 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60 };
                // 定义映射数组，存储46~60对应的a值
                int[] map46to60 = { 65, 70, 75, 80, 85, 90, 95, 100, 105, 110, 115, 120, 125, 130, 135 };

                if (j >= 1 && j <= 30)
                {
                    sqrtValue = Math.Sqrt(t0 + j);
                }
                else if (j >= 31 && j <= 45)
                {
                    int a = map31to45[j - 31];  // j-31对应数组索引0~14
                    sqrtValue = Math.Sqrt(t0 + a);
                }
                else if (j >= 46 && j <= 60)
                {
                    int a = map46to60[j - 46];  // j-46对应数组索引0~14
                    sqrtValue = Math.Sqrt(t0 + a);
                }
                Console.WriteLine($"sqrtValue:{sqrtValue}>>>---{j}");

                data[i, 0] = sqrtValue; // 将平方根值存储在第一列
                data[i, 1] = textBoxValue; // 将文本框值存储在第二列
            }
            //insertChart.InsertChartToWord(outputPath, data);

            const string mapName = "Local\\MySharedMemory";
            int totalBytes = DesorbTextBox.Length * 2 * sizeof(double);

            using (var mmf = MemoryMappedFile.CreateOrOpen(mapName, totalBytes))
            {
                using (var writeAccessor = mmf.CreateViewAccessor(0, totalBytes))
                {
                    Console.WriteLine("[C#] 写入共享内存...");
                    int offset = 0;
                    for (int i = 0; i < DesorbTextBox.Length; i++)
                    {
                        Console.Write($"[C#] 第{i + 1}行: ");
                        for (int j = 0; j < 2; j++)
                        {
                            double val = data[i, j];
                            writeAccessor.Write(offset, val);
                            Console.Write($"{val} ");
                            offset += sizeof(double);
                        }
                        Console.WriteLine();
                    }
                }


                const string memoryName = "Local\\tempSharedMemory";
                int temptotalBytes = 5 * sizeof(double);

                using (var tempmmf = MemoryMappedFile.CreateOrOpen(memoryName, temptotalBytes))
                {
                    // 调用 Python 脚本写入共享内存
                    CreateExcelWithChart();  // 实际是执行 Python 写入数据

                    // 等待 Python 写入（你也可以用事件或信号同步更优雅地替代）
                    //Thread.Sleep(1000);

                    // 读取共享内存中的数据
                    using (var accessor = tempmmf.CreateViewAccessor(0, temptotalBytes))
                    {
                        double[] values = new double[5];
                        for (int i = 0; i < values.Length; i++)
                        {
                            values[i] = accessor.ReadDouble(i * sizeof(double));
                        }
                        InsertChart.SetGasLossVolText(Math.Abs(values[1]).ToString("F3"));

                        // 找出最大数据
                        double maxValue = double.MinValue;
                        for (int i = 1; i <= 60; i++)
                        {
                            string key = $"D{i:000}";
                            var textBox = _mainForm.Controls.Find($"DesorbTextBox{i}", true).FirstOrDefault() as TextBox;

                            if (textBox != null)
                            {
                                string text = textBox.Text.Trim();
                                if (double.TryParse(text, out double val))
                                {
                                    if (val > maxValue)
                                    {
                                        maxValue = val;
                                    }
                                }
                            }
                        }
                        // 查表函数：传入索引，返回对应值（查不到返回 -1 或抛异常，根据需求可改）
                        double GetValueFromTable(int index)
                        {
                            Dictionary<int, double> lookupTable = new Dictionary<int, double>()
                            {
                                {  0, 0.6105 },{  1, 0.6567 },{  2, 0.7057 },{  3, 0.7579 },{  4, 0.8134 },
                                {  5, 0.8723 },{  6, 0.9350 },{  7, 1.0016 },{  8, 1.0726 },{  9, 1.1478 },
                                { 10, 1.2277 },{ 11, 1.3124 },{ 12, 1.4023 },{ 13, 1.4973 },{ 14, 1.5981 },
                                { 15, 1.7049 },{ 16, 1.8177 },{ 17, 1.9371 },{ 18, 2.0634 },{ 19, 2.1967 },
                                { 20, 2.3378 },{ 21, 2.4684 },{ 22, 2.6433 },{ 23, 2.8088 },{ 24, 2.9833 },
                                { 25, 3.1683 },{ 26, 3.3609 },{ 27, 3.5648 },{ 28, 3.7795 },{ 29, 4.0053 },
                                { 30, 4.2428 },{ 31, 4.4922 },{ 32, 4.7546 },{ 33, 5.0300 },{ 34, 5.3192 },
                                { 35, 5.6228 },{ 36, 5.9411 },{ 37, 6.2750 },{ 38, 6.6248 },{ 39, 6.9916 },
                                { 40, 7.3758 },{ 41, 7.7779 },{ 42, 8.1992 },{ 43, 8.6391 },{ 44, 9.1004 },
                                { 45, 9.5830 },{ 46, 10.0857 },{ 47, 10.6123 },{ 48, 11.1602 },{ 49, 11.7348 },
                                { 50, 12.3334 }
                            };

                            if (lookupTable.TryGetValue(index, out double value))
                            {
                                return value;
                            }
                            else
                            {
                                throw new ArgumentOutOfRangeException(nameof(index), "索引不在查找表中。");
                                // 或者：return -1; // 如果你希望返回默认值而不是抛异常
                            }
                        }
                        // 量管初始体积
                        float initialVolume;
                        if (float.TryParse(_InitialVolumeTextBox.Text, out initialVolume))
                        {
                            // 计算井下解吸体积
                            MainForm.井下解吸体积 = maxValue - initialVolume;
                            _DesVolUndTextBox.Text = MainForm.井下解吸体积.ToString();


                            int temp1;
                            if (int.TryParse(_UndTempTextBox.Text, out temp1))
                            {
                                float temp2;
                                if (float.TryParse(_UndAtmPressureTextBox.Text, out temp2))
                                {
                                    MainForm.井下解吸校准体积 =
                                        (273.2 / (101.3 * (273.2 + temp1)))
                                        * (temp2 - 0.00981 * 800.0 - GetValueFromTable(temp1))
                                        * MainForm.井下解吸体积;
                                    _UndDesorpCalTextBox.Text = MainForm.井下解吸校准体积.ToString();
                                    _SampLossVolTextBox.Text = Math.Abs(values[1]).ToString();
                                }
                            }

                        }
                        else
                        {
                            // 转换失败，比如用户输入了非数字
                            MessageBox.Show("请输入有效的数字");
                        }

                    }
                }
            }
        }
    }
}
