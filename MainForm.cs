using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Reflection;
using GasFormsApp.WordPperation;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO.MemoryMappedFiles;
using System.Threading;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.Office.Core;
using DocumentFormat.OpenXml.Office2010.PowerPoint;

namespace GasFormsApp
{
    public partial class MainForm : Form
    {
        private bool v;
        private ImageList imageList1;

        public static string MineNameText
        {
            get;
            set;
        }
        public static string SamplingSpotText
        {
            get;
            set;
        }
        public string SamplingTimeText;
        public static string BurialDepthText
        {
            get;
            set;
        }
        public static string CoalSeamText
        {
            get;
            set;
        }
        public static string SampleNumText
        {
            get;
            set;
        }
        public static string UndAtmPressureText
        {
            get;
            set;
        }
        public static string LabAtmPressureText
        {
            get;
            set;
        }
        public static string UndTempText
        {
            get;
            set;
        }
        public static string LabTempText
        {
            get;
            set;
        }
        public static string SampleWeightText
        {
            get;
            set;
        }
        public static string SampleModeText
        {
            get;
            set;
        }
        public static string MoistureSampleText
        {
            get;
            set;
        }
        public static string RawCoalMoistureText
        {
            get;
            set;
        }
        public static string InitialVolumeText
        {
            get;
            set;
        }


        public string DesorpVolNormalText => DesorpVolNormalTextBox.Text;
        public string Sample1WeightText => Sample1WeightTextBox.Text;
        public string Sample2WeightText => Sample2WeightTextBox.Text;
        public string S1DesorpVolText => S1DesorpVolTextBox.Text;
        public string S2DesorpVolText => S2DesorpVolTextBox.Text;
        public string AdsorpConstAText => AdsorpConstATextBox.Text;
        public string AdsorpConstBText => AdsorpConstBTextBox.Text;
        public string MadText => MadTextBox.Text;
        public string AadText => AadTextBox.Text;
        public string PorosityText => PorosityTextBox.Text;
        public string AppDensityText => AppDensityTextBox.Text;
        public string NonDesorpGasQtyText => NonDesorpGasQtyTextBox.Text;
        public string VadText => VadTextBox.Text;
        public string W1_Text
        {
            get => W1_TextBox.Text;
            set => W1_TextBox.Text = value;
        }
        public string W2_Text
        {
            get => W2_TextBox.Text;
            set => W2_TextBox.Text = value;
        }
        public string W3_Text => W3_TextBox.Text;
        public string Wa_Text => Wa_TextBox.Text;
        public string W_Text => W_TextBox.Text;
        public string P_Text => P_TextBox.Text;


        public static double 井下解吸体积 = 0.0;
        public static double W1 = 0.0;
        public static double W2 = 0.0;
        public static double W3 = 0.0;
        public static double Wa = 0.0;
        public static double Wc = 0.0;
        public static double W = 0.0;
        public static double P = 0.0;





        private BasicInfo basicInfo;
        public MainForm(bool v)
        {
            this.v = v;
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);


            #region 初始化 tabPage1
            //// 设置表头名称
            tabPage1.Text = "基本信息";
            tabPage2.Text = "井下解吸";
            tabPage3.Text = "常压解吸";
            tabPage4.Text = "实验结果";

            // 创建并绑定图像列表到 TabControl
            imageList1 = new ImageList();
            imageList1.ImageSize = new System.Drawing.Size(64, 64);
            tabControl1.ImageList = imageList1;

            // 加载嵌入资源图标
            try
            {
                imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.1.ico").ToBitmap());
                imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.2.ico").ToBitmap());
                imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.3.ico").ToBitmap());
                imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.4.ico").ToBitmap());
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载图标失败: " + ex.Message);
            }

            // 设置表头图标
            tabPage1.ImageIndex = 0;
            tabPage2.ImageIndex = 1;
            tabPage3.ImageIndex = 2;
            tabPage4.ImageIndex = 3;

            #endregion

            #region 模拟用户输入 tabPage2
            //// 模拟用户输入
            //MineNameTextBox.Text = "矿井名称";
            //SamplingSpotTextBox.Text = "采样地点";
            //BurialDepthTextBox.Text = "埋深";
            //CoalSeamTextBox.Text = "煤层";

            //LabAtmPressureTextBox.Text = "1.01";
            //UndAtmPressureTextBox.Text = "1.05";
            //LabTempTextBox.Text = "25";
            //UndTempTextBox.Text = "30";
            //MoistureSampleTextBox.Text = "水分";
            //RawCoalMoistureTextBox.Text = "原水分";
            //SampleNumTextBox.Text = "编号";
            //InitialVolumeTextBox.Text = "初始体积";
            //SampleWeightTextBox.Text = "95";

            //DesorbTextBox1.Text = "1";
            //DesorbTextBox2.Text = "2";
            //DesorbTextBox3.Text = "3";
            //DesorbTextBox4.Text = "4";
            //DesorbTextBox5.Text = "5";
            //DesorbTextBox6.Text = "6";
            //DesorbTextBox7.Text = "7";
            //DesorbTextBox8.Text = "8";
            //DesorbTextBox9.Text = "9";
            //DesorbTextBox10.Text = "10";

            //DesorpVolNormalTextBox.Text = "123";
            //Sample1WeightTextBox.Text = "111";
            //Sample2WeightTextBox.Text = "222";
            //S1DesorpVolTextBox.Text = "333";
            //S2DesorpVolTextBox.Text = "444";

            //AdsorpConstATextBox.Text = "38.0";
            //AdsorpConstBTextBox.Text = "0.9";
            //MadTextBox.Text = "2.9";
            //AadTextBox.Text = "11.5";
            //PorosityTextBox.Text = "6.21";
            //AppDensityTextBox.Text = "1.34";
            //NonDesorpGasQtyTextBox.Text = "1.9254";
            //VadTextBox.Text = "18.444";

            //W1_TextBox.Text = "w1fasd";
            //W2_TextBox.Text = "w2nhrt";
            //W3_TextBox.Text = "w3shrt";
            //Wa_TextBox.Text = "wa270";
            //W_TextBox.Text = "WWW";
            //P_TextBox.Text = "PPP";
            #endregion


            //button2_Click(button2, EventArgs.Empty);
            SamplingTimeText = SamplingTimeDateTimePicker.Value.ToString("yyyy-MM-dd");
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
            string resourceName = "GasFormsApp.aaa.py";  // 注意：一定要改成你项目的资源名，确认见下文
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


        // 从嵌入的资源中加载图标
        private Icon LoadIconFromResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException("未能找到资源: " + resourceName);
                }
                return new Icon(stream);
            }
        }


        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl1.TabPages[e.Index];
            string tabText = tabPage.Text;
            Image tabImage = imageList1.Images[e.Index];
            System.Drawing.Rectangle bounds = e.Bounds;

            // 判断是否是当前选中的标签页
            bool isSelected = (e.Index == tabControl1.SelectedIndex);

            // 背景色
            System.Drawing.Color backColor = isSelected ? System.Drawing.Color.LightBlue : SystemColors.Control;
            System.Drawing.Color textColor = isSelected ? System.Drawing.Color.Black : System.Drawing.Color.Gray;

            // 填充背景
            using (SolidBrush backgroundBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, bounds);
            }

            // 图标大小和位置
            int iconWidth = 64;
            int iconHeight = 64;
            int iconX = bounds.X + (bounds.Width - iconWidth) / 2;
            int iconY = bounds.Y + 5;

            // 绘制图标
            e.Graphics.DrawImage(tabImage, iconX, iconY, iconWidth, iconHeight);

            // 文字位置
            SizeF textSize = e.Graphics.MeasureString(tabText, e.Font);
            int textX = bounds.X + (bounds.Width - (int)textSize.Width) / 2;
            int textY = iconY + iconHeight + 4;

            // 绘制文字
            TextRenderer.DrawText(e.Graphics, tabText, e.Font, new System.Drawing.Point(textX, textY), textColor);
        }

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
                string resourceName = "GasFormsApp.WordTemplate.docx"; // 注意这个名字必须和实际资源名一致

                // 尝试读取嵌入资源
                using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
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
                        BasicInfo basicInfo = new BasicInfo(this);
                        Console.WriteLine("用户选择了新的时间：" + SamplingTimeText);
                        SampleModeText = SampleModeComboBox.Text;
                        Console.WriteLine("用户选择了新取样方式：" + SampleModeText);

                        basicInfo.ReplaceWordPlaceholders(memoryStream, SamplingTimeText);

                        // 保存到用户指定路径
                        File.WriteAllBytes(outputPath, memoryStream.ToArray());

                        // 插入图表
                        InsertChart insertChart = new InsertChart();

                        // 从文本框或其他地方获取数据，并将其传入函数
                        // 假设这些是你窗体上的 TextBox 控件
                        TextBox[] DesorbTextBox = new TextBox[60];
                        for (int i = 0; i < 60; i++)
                        {
                            string controlName = $"DesorbTextBox{i + 1}";
                            DesorbTextBox[i] = this.Controls.Find(controlName, true).FirstOrDefault() as TextBox;
                        }


                        double t0 = 2;
                        double[,] data = new double[DesorbTextBox.Length, 2]; // 数组大小根据 DesorbTextBox 数量来确定

                        for (int i = 0; i < DesorbTextBox.Length; i++) // 循环次数根据 DesorbTextBox 数量确定
                        {
                            double sqrtValue = 0;
                            if (i > 20)
                            {
                                switch (i)
                                {
                                    case (21):
                                        sqrtValue = Math.Sqrt(t0 + 22); // 计算平方根
                                        break;
                                    case (22):
                                        sqrtValue = Math.Sqrt(t0 + 24);
                                        break;
                                    case (23):
                                        sqrtValue = Math.Sqrt(t0 + 26);
                                        break;
                                    case (24):
                                        sqrtValue = Math.Sqrt(t0 + 28);
                                        break;
                                    case (25):
                                        sqrtValue = Math.Sqrt(t0 + 30);
                                        break;
                                    case (26):
                                        sqrtValue = Math.Sqrt(t0 + 35);
                                        break;
                                    case (27):
                                        sqrtValue = Math.Sqrt(t0 + 40);
                                        break;
                                    case (28):
                                        sqrtValue = Math.Sqrt(t0 + 45);
                                        break;
                                    case (29):
                                        sqrtValue = Math.Sqrt(t0 + 50);
                                        break;
                                    case (30):
                                        sqrtValue = Math.Sqrt(t0 + 60);
                                        break;
                                }
                            }
                            else
                            {
                                sqrtValue = Math.Sqrt(t0 + (i + 1));
                            }
                            //double textBoxValue = double.Parse(DesorbTextBox[i].Text.Trim()); // 获取每个文本框的值并转换为 double
                            double textBoxValue = 0.0;

                            if (!string.IsNullOrWhiteSpace(DesorbTextBox[i].Text) &&
                                double.TryParse(DesorbTextBox[i].Text.Trim(), out double value))
                            {
                                textBoxValue = value;
                            }
                            else
                            {
                                // 你可以选择：
                                // 1. 保持 textBoxValue 为 0.0（默认）
                                // 2. 给出提示
                                // 3. 跳过这一项
                                // 4. 抛出异常，自定义消息
                                textBoxValue = 0;
                            }

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
                                        var textBox = Controls.Find($"DesorbTextBox{i}", true).FirstOrDefault() as TextBox;

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
                                    if (float.TryParse(InitialVolumeTextBox.Text, out initialVolume))
                                    {
                                        // 计算井下解吸体积
                                        井下解吸体积 = maxValue - initialVolume;
                                    }
                                    else
                                    {
                                        // 转换失败，比如用户输入了非数字
                                        MessageBox.Show("请输入有效的数字");
                                    }
                                    Console.WriteLine($"井下解析体积:{井下解吸体积}");
                                    Console.WriteLine($"瓦斯损失量:{values[1]}");

                                    // 计算W1
                                    // 量管初始体积
                                    float SampleWeight;
                                    if (float.TryParse(SampleWeightTextBox.Text, out SampleWeight))
                                    {
                                        // 计算W1
                                        W1 = (井下解吸体积 + Math.Abs(values[1])) / SampleWeight;
                                    }
                                    else
                                    {
                                        // 转换失败，比如用户输入了非数字
                                        MessageBox.Show("请输入有效的数字");
                                    }
                                    W1_TextBox.Text = W1.ToString();
                                    Console.WriteLine($"W1(m^3/t):{W1_TextBox.Text}");

                                    // 计算W2
                                    // 常压解吸体积
                                    float DesorpVolNormal;
                                    if (float.TryParse(DesorpVolNormalTextBox.Text, out DesorpVolNormal))
                                    {
                                        // 计算W2
                                        W2 = DesorpVolNormal / SampleWeight;
                                    }
                                    else
                                    {
                                        // 转换失败，比如用户输入了非数字
                                        MessageBox.Show("请输入有效的数字");
                                    }
                                    W2_TextBox.Text = W2.ToString();
                                    Console.WriteLine($"W2(m^3/t):{W2_TextBox.Text}");

                                    // 计算W3
                                    // 密封粉碎解析量
                                    float CrushDesorp;
                                    if (float.TryParse(CrushDesorpTextBox.Text, out CrushDesorp))
                                    {
                                        // 计算W3
                                        W3 = CrushDesorp;
                                    }
                                    else
                                    {
                                        // 转换失败，比如用户输入了非数字
                                        MessageBox.Show("请输入有效的数字");
                                    }
                                    W3_TextBox.Text = W3.ToString();
                                    Console.WriteLine($"W3(m^3/t):{W3_TextBox.Text}");

                                    // 计算Wa
                                    Wa = W1 + W2 + W3;
                                    Wa_TextBox.Text = Wa.ToString();
                                    Console.WriteLine($"Wa(m^3/t):{Wa_TextBox.Text}");

                                    // 计算Wc
                                    Wc = getWc();
                                    Wc_TextBox.Text = Wc.ToString();
                                    NonDesorpGasQtyTextBox.Text = Wc.ToString();
                                    Console.WriteLine($"Wc(m^3/t):{Wc_TextBox.Text}");

                                    // 计算W
                                    W = Wa + Wc;
                                    W_TextBox.Text = W.ToString();
                                    Console.WriteLine($"W(m^3/t):{W_TextBox.Text}");

                                    // 计算P
                                    double at = 1000 * Convert.ToDouble(AdsorpConstBTextBox.Text.Trim()) * (Convert.ToDouble(PorosityTextBox.Text.Trim()) / 100) + 310 * Convert.ToDouble(AdsorpConstBTextBox.Text.Trim()) * Convert.ToDouble(MadTextBox.Text.Trim()) * (Convert.ToDouble(PorosityTextBox.Text.Trim()) / 100);
                                    double bt = Convert.ToDouble(AdsorpConstATextBox.Text.Trim()) * Convert.ToDouble(AdsorpConstBTextBox.Text.Trim()) * Convert.ToDouble(AppDensityTextBox.Text.Trim()) * (100 - Convert.ToDouble(AadTextBox.Text.Trim()) - Convert.ToDouble(MadTextBox.Text.Trim())) + 1000 * (Convert.ToDouble(PorosityTextBox.Text.Trim()) / 100) - 100 * Convert.ToDouble(AdsorpConstBTextBox.Text.Trim()) * Convert.ToDouble(W_TextBox.Text.Trim()) * Convert.ToDouble(AppDensityTextBox.Text.Trim()) + 310 * Convert.ToDouble(MadTextBox.Text.Trim()) * (Convert.ToDouble(PorosityTextBox.Text.Trim()) / 100) - 31 * Convert.ToDouble(AdsorpConstBTextBox.Text.Trim()) * Convert.ToDouble(MadTextBox.Text.Trim()) * Convert.ToDouble(W_TextBox.Text.Trim()) * Convert.ToDouble(AppDensityTextBox.Text.Trim());
                                    double ct = -100 * Convert.ToDouble(W_TextBox.Text.Trim()) * Convert.ToDouble(AppDensityTextBox.Text.Trim()) - 31 * Convert.ToDouble(MadTextBox.Text.Trim()) * Convert.ToDouble(W_TextBox.Text.Trim()) * Convert.ToDouble(AppDensityTextBox.Text.Trim());
                                    double Pt = Math.Round((-bt + Math.Sqrt(bt * bt - 4 * at * ct)) / (2 * at), 4) - 0.1;
                                    P = Pt;
                                    P_TextBox.Text = Convert.ToString(Pt);
                                    Console.WriteLine($"P(MPa):{P_TextBox.Text}");

                                    //Console.WriteLine("读取共享内存数据:");
                                    //foreach (var v in values)
                                    //{
                                    //    Console.WriteLine(v);
                                    //}
                                }
                            }
                        }

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
                            bookmarkRange = doc.Bookmarks["ChartPlaceholder"].Range;

                            // 粘贴图片
                            bookmarkRange.Paste();

                            // 获取刚插入的 InlineShape（剪贴板内容必须是图片）
                            if (bookmarkRange.InlineShapes.Count > 0)
                            {
                                var pastedImage = bookmarkRange.InlineShapes[1];

                                pastedImage.LockAspectRatio = MsoTriState.msoFalse;  // 不锁比例
                                float k = 33;
                                pastedImage.Width = 6*k;
                                pastedImage.Height = 4*k;  // 高度也设置为20磅
                            }

                            // 可选：重新添加书签（如果被清除）
                            if (!doc.Bookmarks.Exists("ChartPlaceholder"))
                            {
                                doc.Bookmarks.Add("ChartPlaceholder", bookmarkRange);
                            }
                        }
                        else
                        {
                            MessageBox.Show("未找到书签 'ChartPlaceholder'，请检查 Word 模板！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // 插入图表完毕后释放 Word 中用到的所有对象
                        if (bookmarkRange != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(bookmarkRange);
                        if (bookmarks != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(bookmarks);

                        doc.Save();
                        doc.Close(false);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                    }
                }
                ////打开生成的 Word 文件
                //try
                //{
                //    Process.Start("WINWORD.EXE", $"\"{outputPath}\"");
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("无法打开文件: " + ex.Message);
                //}
            }


            // 使用上面的路径
            //if (saveDialog.ShowDialog() == DialogResult.OK)
            //if (false)
            {
                //string outputPath = saveDialog.FileName;
                //string outputPath = @"D:\1.docx";

                // 获取程序集中的 Word 模板资源
                var assembly = Assembly.GetExecutingAssembly();
                string resourceName = "GasFormsApp.WordTemplate.docx";

                using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (resourceStream == null)
                    {
                        MessageBox.Show("模板资源未找到，请检查资源名称是否正确。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 复制模板到内存
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        resourceStream.CopyTo(memoryStream);

                        // 替换占位符
                        BasicInfo basicInfo = new BasicInfo(this);
                        basicInfo.ReplaceWordPlaceholders(memoryStream, SamplingTimeText);

                        // 写入替换后的 Word 文件到磁盘（必须先写到 outputPath）
                        File.WriteAllBytes(outputPath, memoryStream.ToArray());
                    }
                }

                // === 确保图表已经复制到剪贴板 ===
                //chart.Copy();

                // 打开 Word 插入图表
                var wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Visible = false;

                var doc = wordApp.Documents.Open(outputPath);

                if (doc.Bookmarks.Exists("ChartPlaceholder"))
                {
                    var bookmarkRange = doc.Bookmarks["ChartPlaceholder"].Range;

                    bookmarkRange.Paste(); // 粘贴剪贴板内容（图表）

                    // 粘贴后书签可能丢失，建议重新添加
                    doc.Bookmarks.Add("ChartPlaceholder", bookmarkRange);

                    Marshal.ReleaseComObject(bookmarkRange);
                }
                else
                {
                    MessageBox.Show("未找到书签 'ChartPlaceholder'，请检查 Word 模板！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // 保存并关闭 Word 文档
                doc.Save();

                // 导出为PDF，参数依次为：输出文件路径，导出格式
                string pdfPath = Path.ChangeExtension(outputPath, ".pdf");
                doc.ExportAsFixedFormat(pdfPath, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);

                doc.Close(false);
                Marshal.ReleaseComObject(doc);

                wordApp.Quit(false);
                Marshal.ReleaseComObject(wordApp);

                // 打开生成的 Word 文件
                try
                {
                    Process.Start("WINWORD.EXE", $"\"{outputPath}\"");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("无法打开文件: " + ex.Message);
                }

                this.Close();
            }

        }

        private void SamplingTimeDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SamplingTimeText = SamplingTimeDateTimePicker.Value.ToString("yyyy-MM-dd");
            Console.WriteLine("用户选择了新的时间：" + SamplingTimeText);
        }

        void getMaxVal()
        {
            try
            {
                decimal one1 = Convert.ToDecimal(Sample1WeightTextBox.Text.Trim());
                decimal two1 = Convert.ToDecimal(Sample2WeightTextBox.Text.Trim());
                decimal one = Convert.ToDecimal(S1DesorpVolTextBox.Text.Trim());
                decimal two = Convert.ToDecimal(S2DesorpVolTextBox.Text.Trim());
                if (one > 0 && two > 0 && one1 > 0 && two1 > 0)
                {
                    CrushDesorpTextBox.Text = (Math.Round(one / one1 > two / two1 ? one / one1 : two / two1, 4)).ToString();
                }
            }
            catch { }
        }
        /// <summary>
        /// 计算Wc
        /// </summary>
        /// <returns></returns>
        private double getWc()
        {
            float p = 0.1f;//0.103f
            float AD = Convert.ToSingle(AadTextBox.Text.Trim());//灰分
            float Md = Convert.ToSingle(MadTextBox.Text.Trim());//水分
            float F = Convert.ToSingle(PorosityTextBox.Text.Trim());//孔隙率
            float r = Convert.ToSingle(AppDensityTextBox.Text.Trim());//视密度
            float a = Convert.ToSingle(AdsorpConstATextBox.Text.Trim());// 吸附常数a
            float b = Convert.ToSingle(AdsorpConstBTextBox.Text.Trim());// 吸附常数b
            double x = a * b * p * (100 - AD - Md) / ((1 + b * p) * 100 * (1 + 0.31 * Md)) + F / (100 * r);
            return Math.Round(x, 4);
        }

        private void Sample1WeightTextBox_TextChanged(object sender, EventArgs e)
        {
            getMaxVal();
        }

        private void Sample2WeightTextBox_TextChanged(object sender, EventArgs e)
        {
            getMaxVal();
        }

        private void S1DesorpVolTextBox_TextChanged(object sender, EventArgs e)
        {
            getMaxVal();
        }

        private void S2DesorpVolTextBox_TextChanged(object sender, EventArgs e)
        {
            getMaxVal();
        }


        //public string SamplingTimeText;



        private void TextModificationTriggered(object sender, EventArgs e)
        {
            MineNameText = MineNameTextBox.Text;
            SamplingSpotText = SamplingSpotTextBox.Text;
            BurialDepthText = BurialDepthTextBox.Text;
            CoalSeamText = CoalSeamTextBox.Text;
            SampleNumText = SampleNumTextBox.Text;
            UndAtmPressureText = UndAtmPressureTextBox.Text;
            LabAtmPressureText = LabAtmPressureTextBox.Text;
            UndTempText = UndTempTextBox.Text;
            LabTempText = LabTempTextBox.Text;
            SampleWeightText = SampleWeightTextBox.Text;
            MoistureSampleText = MoistureSampleTextBox.Text;
            RawCoalMoistureText = RawCoalMoistureTextBox.Text;
            InitialVolumeText = InitialVolumeTextBox.Text;

            System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;  // 转成Control类型（适用于WinForms）
            if (control != null)
            {
                string controlName = control.Name;
                Console.WriteLine($"触发事件的控件名称是：{controlName}");
            }
        }

        private void SampleModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SampleModeText = SampleModeComboBox.Text;
            Console.WriteLine("用户选择了新取样方式：" + SampleModeText);
        }

    }
}
