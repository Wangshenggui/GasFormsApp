using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading;
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
            _mainForm.DrawCurvesButton.Click += DrawCurvesButton_Click;

            //注册KeyPress回调函数
            _mainForm.t0TextBox.KeyPress += NumericTextBox_KeyPress;
            for (int i = 1; i <= 30; i++)
            {
                string controlName = "DesorbTextBox" + i;

                Control ctl = _mainForm.Controls.Find(controlName, true).FirstOrDefault();

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
            // ((num2 * 273.2) * ((num3 - (4.905 * (1 - num2/800))) - (0.699 * e^(0.0597 * num4)))) / (101.3 * (273.2 + num4))
            double result = ((desorptionVolume * 273.2) *
                            ((pressure - (4.905 * (1.0 - (desorptionVolume / 800.0)))) - (0.699 * Math.Exp(0.0597 * temperature))))
                            / (101.3 * (273.2 + temperature));

            return result;
        }


        private void DrawCurvesButton_Click(object sender, EventArgs e)
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
                    
                    try
                    {
                        var pythonPath = @"Python_embed\python.exe"; // 嵌入式解释器路径
                        var scriptPath = @"Python_embed\Python\aaa.cpython-312.pyc";           // 你实际的 .py 文件路径

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
                            if (lastValue != 0 || a++>100 * 5)
                            {
                                break;
                            }

                            Console.WriteLine("等待数据......");
                            Thread.Sleep(10); // 避免忙等待，占用CPU过高
                        }
                        if( a> 100 * 5)
                        {
                            SetWaitCursor(_mainForm, Cursors.Default);
                            MessageBox.Show("计算失败！！！", "错误：");
                            return;
                        }

                        string imageName = "Python_embed\\Python\\images\\output_image.png";
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
