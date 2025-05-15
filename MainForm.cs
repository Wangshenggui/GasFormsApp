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

namespace GasFormsApp
{
    public partial class MainForm : Form
    {
        private bool v;
        private ImageList imageList1;

        public string MineNameText => MineNameTextBox.Text;
        public string SamplingSpotText => SamplingSpotTextBox.Text;
        //public string SamplingTimeText => SamplingTimeDateTimePicker.Value.ToString("yyyy-MM-dd");
        public string SamplingTimeText;
        public string BurialDepthText => BurialDepthTextBox.Text;
        public string CoalSeamText => CoalSeamTextBox.Text;
        public string SampleNumText => SampleNumTextBox.Text;
        public string UndAtmPressureText => UndAtmPressureTextBox.Text;
        public string LabAtmPressureText => LabAtmPressureTextBox.Text;
        public string UndTempText => UndTempTextBox.Text;
        public string LabTempText => LabTempTextBox.Text;
        public string SampleWeightText => SampleWeightTextBox.Text;
        public string SampleModeText => SampleModeComboBox.Text;
        public string MoistureSampleText => MoistureSampleTextBox.Text;
        public string RawCoalMoistureText => RawCoalMoistureTextBox.Text;
        public string InitialVolumeText => InitialVolumeTextBox.Text;


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
            imageList1.ImageSize = new Size(64, 64);
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
            // 模拟用户输入
            MineNameTextBox.Text = "矿井名称";
            SamplingSpotTextBox.Text = "采样地点";
            BurialDepthTextBox.Text = "埋深";
            CoalSeamTextBox.Text = "煤层";

            LabAtmPressureTextBox.Text = "1.01";
            UndAtmPressureTextBox.Text = "1.05";
            LabTempTextBox.Text = "25";
            UndTempTextBox.Text = "30";
            MoistureSampleTextBox.Text = "水分";
            RawCoalMoistureTextBox.Text = "原水分";
            SampleNumTextBox.Text = "编号";
            InitialVolumeTextBox.Text = "初始体积";
            SampleWeightTextBox.Text = "重量";

            DesorbTextBox1.Text = "14";
            DesorbTextBox2.Text = "20";
            DesorbTextBox3.Text = "26";
            DesorbTextBox4.Text = "32";
            DesorbTextBox5.Text = "36";
            DesorbTextBox6.Text = "42";
            DesorbTextBox7.Text = "46";
            DesorbTextBox8.Text = "48";
            DesorbTextBox9.Text = "54";
            DesorbTextBox10.Text = "58";
            DesorbTextBox11.Text = "60";
            DesorbTextBox12.Text = "64";
            DesorbTextBox13.Text = "66";
            DesorbTextBox14.Text = "70";
            DesorbTextBox15.Text = "72";
            DesorbTextBox16.Text = "76";
            DesorbTextBox17.Text = "80";
            DesorbTextBox18.Text = "82";
            DesorbTextBox19.Text = "84";
            DesorbTextBox20.Text = "86";
            DesorbTextBox21.Text = "90";
            DesorbTextBox22.Text = "92";
            DesorbTextBox23.Text = "94";
            DesorbTextBox24.Text = "96";
            DesorbTextBox25.Text = "98";
            DesorbTextBox26.Text = "100";
            DesorbTextBox27.Text = "102";
            DesorbTextBox28.Text = "106";
            DesorbTextBox29.Text = "108";
            DesorbTextBox30.Text = "110";
            #endregion

            //button2_Click(button2, EventArgs.Empty);
            SamplingTimeText = SamplingTimeDateTimePicker.Value.ToString("yyyy-MM-dd");
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
            string name = SamplingSpotTextBox.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // 选择保存位置
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Word 文件 (*.docx)|*.docx",
                Title = "保存生成的 Word 文件"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string outputPath = saveDialog.FileName;

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
                        BasicInfo basicInfo = new BasicInfo();
                        Console.WriteLine("用户选择了新的时间：" + SamplingTimeText);
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


                        double t0 = 3;
                        double[,] data = new double[DesorbTextBox.Length, 2]; // 数组大小根据 DesorbTextBox 数量来确定

                        for (int i = 0; i < DesorbTextBox.Length; i++) // 循环次数根据 DesorbTextBox 数量确定
                        {
                            double sqrtValue = 0;
                            if (i>20)
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
                        insertChart.InsertChartToWord(outputPath, data);
                    }
                }

                string filePath = @"C:\Users\Mac\Desktop\GitHub\GasFormsApp\1.docx";

                try
                {
                    // 使用默认的程序打开 Word 文档（通常是 Word 或 Office 应用程序）
                    Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("无法打开文件: " + ex.Message);
                }
                this.Close();
                //MessageBox.Show("Word 文件生成成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SamplingTimeDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SamplingTimeText = SamplingTimeDateTimePicker.Value.ToString("yyyy-MM-dd");
            Console.WriteLine("用户选择了新的时间：" + SamplingTimeText);
        }
    }
}
