using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasFormsApp.TabControl
{
    internal class tabControl_2
    {
        private MainForm _mainForm;


        // 构造函数接收 TextBox 控件
        public tabControl_2(MainForm form)
        {
            _mainForm = form;

            // 注册回调函数
            _mainForm.button9.Click += button9_Click;

            //注册KeyPress回调函数
            _mainForm.t0TextBox.KeyPress += NumericTextBox_KeyPress;
            for (int i = 1; i <= 30; i++)
            {
                string controlName = "DesorbTextBox" + i;

                System.Windows.Forms.Control ctl = _mainForm.Controls.Find(controlName, true).FirstOrDefault();

                if (ctl is TextBox tb)
                {
                    tb.KeyPress += NumericTextBox_KeyPress;
                }
            }
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

        /// <summary>
        /// 计算井下解吸校准体积（Desorption Calibrated Volume）
        /// </summary>
        /// <param name="desorptionVolume">井下解吸体积（Desorption Volume）</param>
        /// <param name="pressure">压强（Pressure）</param>
        /// <param name="temperature">温度（Temperature）</param>
        /// <returns>计算得到的校准体积</returns>
        public static double CalculateDesorptionCalibratedVolume(double desorptionVolume, double pressure, double temperature)
        {
            // 保存输入变量，方便理解
            //double num2 = desorptionVolume;
            //double num3 = pressure;
            //double num4 = temperature;

            // 公式部分：
            // ((num2 * 273.2) * ((num3 - (4.905 * (1 - num2/800))) - (0.699 * e^(0.0597 * num4)))) / (101.3 * (273.2 + num4))
            double result = ((desorptionVolume * 273.2) *
                            ((pressure - (4.905 * (1.0 - (desorptionVolume / 800.0)))) - (0.699 * Math.Exp(0.0597 * temperature))))
                            / (101.3 * (273.2 + temperature));

            return result;
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
            if (float.TryParse(_mainForm.t0TextBox.Text, out t0_temp))
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
                using (var tempmmf = MemoryMappedFile.CreateOrOpen(memoryName, temptotalBytes))
                {
                    //等待共享内存有数据
                    // 资源名称通常是 {默认命名空间}.{文件夹}.{文件名}
                    string resourceName = "GasFormsApp.Python.aaa.exe";
                    string tempFilePath = Path.Combine(Environment.CurrentDirectory, "tempProgram.bin");  // 改成 .bin

                    Console.WriteLine($"开始检查临时文件是否存在：{tempFilePath}");
                    if (!File.Exists(tempFilePath))
                    {
                        Console.WriteLine("临时文件不存在，准备从嵌入资源中提取...");
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                        {
                            if (stream == null)
                            {
                                Console.WriteLine($"未找到嵌入资源：{resourceName}");
                                return;
                            }

                            using (FileStream fs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                            {
                                stream.CopyTo(fs);
                                Console.WriteLine("资源写入临时文件完成。");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("临时文件已存在，跳过写入步骤。");
                    }

                    try
                    {
                        Console.WriteLine("启动临时程序...");
                        //Process process = Process.Start(tempFilePath);
                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = "cmd.exe",
                            Arguments = $"/c \"{tempFilePath}\"",
                            UseShellExecute = false,     // 必须设置为 false 才能隐藏窗口
                            CreateNoWindow = true,       // 不显示命令行窗口
                            RedirectStandardOutput = true,  // 如果需要，可以重定向输出
                            RedirectStandardError = true
                        };

                        Process process = Process.Start(psi);
                        process.WaitForExit();
                        Console.WriteLine("临时程序执行完毕。");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"执行程序时发生错误：{ex.Message}");
                    }

                    // 读取共享内存中的数据
                    using (var accessor = tempmmf.CreateViewAccessor(0, temptotalBytes))
                    {
                        double[] values = new double[5];
                        double lastValue = 0;

                        int a = 0;
                        //等待第5个数据不为0（下标4）
                        while (true)
                        {
                            lastValue = accessor.ReadDouble(4 * sizeof(double));
                            if (lastValue != 0 || a++>100 * 10)
                            {
                                break;
                            }

                            Console.WriteLine("等待数据......");
                            Thread.Sleep(10); // 避免忙等待，占用CPU过高
                        }

                        string imageName = "output_image.png";
                        string imagePath = Path.Combine(Environment.CurrentDirectory, imageName);
                        // 设置 PictureBox 的显示模式
                        _mainForm.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        try
                        {
                            if (File.Exists(imagePath))
                            {
                                // 避免文件被锁，使用 Image.FromStream
                                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                                {
                                    _mainForm.pictureBox3.Image = Image.FromStream(fs);
                                }
                            }
                            else
                            {
                                MessageBox.Show("找不到图片文件：" + imagePath);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("加载图片时出错：" + ex.Message);
                        }


                        //double[] values = new double[5];
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
                        if (float.TryParse(_mainForm.InitialVolumeTextBox.Text, out initialVolume))
                        {
                            // 计算井下解吸体积
                            MainForm.井下解吸体积 = maxValue - initialVolume;
                            _mainForm.DesVolUndTextBox.Text = MainForm.井下解吸体积.ToString();


                            int temp1;
                            if (int.TryParse(_mainForm.UndTempTextBox.Text, out temp1))
                            {
                                float temp2;
                                if (float.TryParse(_mainForm.UndAtmPressureTextBox.Text, out temp2))
                                {
                                    MainForm.井下解吸校准体积 = CalculateDesorptionCalibratedVolume(MainForm.井下解吸体积, temp2,temp1);
                                    _mainForm.UndDesorpCalTextBox.Text = MainForm.井下解吸校准体积.ToString("F4");
                                    _mainForm.SampLossVolTextBox.Text = Math.Abs(values[1]).ToString("F4");
                                }
                            }

                        }
                        else
                        {
                            // 转换失败，比如用户输入了非数字
                            MessageBox.Show("请输入有效的数字");
                        }
                        SetWaitCursor(_mainForm, Cursors.Default);
                        // 计算完成提示框
                        MessageBox.Show("计算完成！", "提示：");
                    }
                }
            }
        }
    }
}
