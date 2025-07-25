﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using GasFormsApp.TabControl;
using GasFormsApp.UI;

namespace GasFormsApp
{
    public partial class MainForm : CustomForm
    {
        // 登录和使用权限
        public int Version { get; set; } = -1;
        // 判断是否初始化
        private bool tabControl1_isInitializing = true;

        // 记录鼠标右键位置
        private Point lastRightClickPosition;
        private Control lastRightClickedControl;

        private bool v;

        //python执行标志
        public static bool python执行标志 = false;

        //Wc选择标志
        public static bool WcOutCheckBoxFlag = false;
        public static int Wc选项数量 = 0;


        //瓦斯含量选择标志
        public static bool GasCompCheckBoxFlag = false;
        public static int Gas选项数量 = 0;

        public static double 井下解吸体积 = 0.0;
        public static double 井下解吸校准体积 = 0.0;
        public static double 瓦斯标态损失量 = 0.0;

        public static double W1 = 0.0;
        public static double W2 = 0.0;
        public static double W3 = 0.0;
        public static double Wa = 0.0;
        public static double Wc = 0.0;
        public static double W = 0.0;
        public static double P = 0.0;
        public static string P_Lable = "";
        public static string P_Data = "";
        public static string P_beizhu = "";

        public static string DownholeTestersLab = "";
        public static string DownholeTestersData = "";

        public static string GasComp_Lab1 = "";
        public static string GasComp_Lab2 = "";
        public static string GasComp_Lab3 = "";
        public static string GasComp_Lab4 = "";
        public static string GasComp_Lab5 = "";
        public static string GasComp_Lab6 = "";
        public static string GasComp_Lab7 = "";
        public static string GasComp_Lab8 = "";
        public static string GasComp_Lab9 = "";
        public static string GasComp_Lab10 = "";
        public static string GasComp_Dat1 = "";
        public static string GasComp_Dat2 = "";
        public static string GasComp_Dat3 = "";
        public static string GasComp_Dat4 = "";
        public static string GasComp_Dat5 = "";
        public static string GasComp_Dat6 = "";
        public static string GasComp_Dat7 = "";
        public static string GasComp_Dat8 = "";
        public static string GasComp_Dat9 = "";
        public static string GasComp_Dat10 = "";

        public static string Wc_Lab1 = "";
        public static string Wc_Lab2 = "";
        public static string Wc_Lab3 = "";
        public static string Wc_Lab4 = "";
        public static string Wc_Lab5 = "";
        public static string Wc_Lab6 = "";
        public static string Wc_Lab7 = "";
        public static string Wc_Lab8 = "";
        public static string Wc_Lab9 = "";
        public static string Wc_Dat1 = "";
        public static string Wc_Dat2 = "";
        public static string Wc_Dat3 = "";
        public static string Wc_Dat4 = "";
        public static string Wc_Dat5 = "";
        public static string Wc_Dat6 = "";
        public static string Wc_Dat7 = "";
        public static string Wc_Dat8 = "";
        public static string Wc_Dat9 = "";

        public static string 登录的用户名 = "";


        private tabControl_1 myTabLogic1;
        private tabControl_2 myTabLogic2;
        private tabControl_3 myTabLogic3;
        private tabControl_4 myTabLogic4;
        private tabControl_5 myTabLogic5;
        private tabControl_6 myTabLogic6;



        private List<TextBox> desorbTextBoxes;

        public void EnableDoubleBufferingForAllControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                // 通过反射设置 DoubleBuffered 属性（私有属性）
                PropertyInfo doubleBufferPropertyInfo = ctrl.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                if (doubleBufferPropertyInfo != null)
                {
                    doubleBufferPropertyInfo.SetValue(ctrl, true, null);
                }

                // 递归对子控件继续启用
                if (ctrl.HasChildren)
                {
                    EnableDoubleBufferingForAllControls(ctrl);
                }
            }
        }
        public MainForm(bool v)
        {
            this.v = v;
            this.Opacity = 0;
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // 给整个窗体启用双缓冲（包括所有子控件）
            //EnableDoubleBufferingForAllControls(this);
            //this.DoubleBuffered = true;


            myTabLogic1 = new tabControl_1(
                this
            );

            myTabLogic2 = new tabControl_2(
                this
            );

            myTabLogic3 = new tabControl_3(
                this
                );

            myTabLogic4 = new tabControl_4(
                this
            );

            myTabLogic5 = new tabControl_5(
                this
            );

            myTabLogic6 = new tabControl_6(
                this
            );
        }
        // 特殊处理，为了提高选项卡图标清晰度而设置的图片点击行为
        private void tabControlxPictureBox_Click(object sender, EventArgs e)
        {
            switch (sender)
            {
                case PictureBox pic when pic == tabControl1PictureBox:
                    tabControl1.SelectedIndex = 0;
                    break;
                case PictureBox pic when pic == tabControl2PictureBox:
                    tabControl1.SelectedIndex = 1;
                    break;
                case PictureBox pic when pic == tabControl3PictureBox:
                    tabControl1.SelectedIndex = 2;
                    break;
                case PictureBox pic when pic == tabControl4PictureBox:
                    tabControl1.SelectedIndex = 3;
                    break;
                case PictureBox pic when pic == tabControl5PictureBox:
                    tabControl1.SelectedIndex = 4;
                    break;
                case PictureBox pic when pic == tabControl6PictureBox:
                    tabControl1.SelectedIndex = 5;
                    break;
                default:
                    // 处理其他情况或未知控件
                    break;
            }
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
            Rectangle bounds = e.Bounds;

            // 判断是否是当前选中的标签页
            bool isSelected = (e.Index == tabControl1.SelectedIndex);

            // 渐变背景色（选中：蓝黑渐变，未选中：黑灰渐变）
            Color startColor = isSelected ? Color.Blue : Color.Black;
            Color endColor = isSelected ? Color.Black : Color.DarkGray;

            using (var gradientBrush = new LinearGradientBrush(
                bounds,
                startColor,
                endColor,
                LinearGradientMode.Vertical)) // 渐变方向：垂直
            {
                e.Graphics.FillRectangle(gradientBrush, bounds);
            }

            // 图标大小和位置
            int iconWidth = 64;
            int iconHeight = 64;
            int iconX = bounds.X + (bounds.Width - iconWidth) / 2;
            int iconY = bounds.Y + 5;

            //// 绘制图标（添加白色边框增强对比度）
            //e.Graphics.DrawRectangle(Pens.White, iconX, iconY, iconWidth, iconHeight);
            //e.Graphics.DrawImage(tabImage, iconX, iconY, iconWidth, iconHeight);

            // 文字颜色（白色确保在深色背景下可读）
            Color textColor = Color.White;

            // 文字位置
            SizeF textSize = e.Graphics.MeasureString(tabText, e.Font);
            int textX = bounds.X + (bounds.Width - (int)textSize.Width) / 2;
            int textY = iconY + iconHeight + 4;

            // 绘制文字
            TextRenderer.DrawText(e.Graphics, tabText, e.Font, new System.Drawing.Point(textX, textY), textColor);

            // 可选：选中时添加高亮边框
            if (isSelected)
            {
                using (var highlightPen = new Pen(Color.Cyan, 2))
                {
                    e.Graphics.DrawRectangle(highlightPen, bounds);
                }
            }
        }

        private float xRatio;
        private float yRatio;
        private void ResizeControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Left = (int)(ctrl.Left * xRatio);
                ctrl.Top = (int)(ctrl.Top * yRatio);
                ctrl.Width = (int)(ctrl.Width * xRatio);
                ctrl.Height = (int)(ctrl.Height * yRatio);

                if (ctrl.HasChildren)
                {
                    ResizeControls(ctrl);
                }
            }
        }
        private void EnableDoubleBuffering(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null,
                control,
                new object[] { true });
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show($"版本：{Version}");

            //int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            //int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            //this.Width = (int)(screenWidth * 0.8);
            //this.Height = (int)(screenHeight * 0.8);
            //// 居中设置
            //this.Left = (screenWidth - this.Width) / 2;
            //this.Top = (screenHeight - this.Height) / 2;

            //xRatio = screenWidth / 1920f; // 假设设计时是 1920x1080
            //yRatio = screenHeight / 1080f;
            GasComp_Lab1 = "H₂";      // 氢气
            GasComp_Lab2 = "O₂";      // 氧气
            GasComp_Lab3 = "N₂";      // 氮气
            GasComp_Lab4 = "CO₂";     // 二氧化碳
            GasComp_Lab5 = "CH₄";     // 甲烷
            GasComp_Lab6 = "C₂H₆";    // 乙烷
            GasComp_Lab7 = "C₃H₈";    // 丙烷
            GasComp_Lab8 = "C₄H₁₀";   // 丁烷
            GasComp_Lab9 = "NH₃";     // 氨气
            GasComp_Lab10 = "H₂S";    // 硫化氢

            GasComp_Dat1 = "0.50";   // H₂ 浓度（单位可为 %）
            GasComp_Dat2 = "20.95";  // O₂（空气中含量约 21%）
            GasComp_Dat3 = "78.08";  // N₂（空气中含量约 78%）
            GasComp_Dat4 = "0.04";   // CO₂（空气中约 400 ppm ≈ 0.04%）
            GasComp_Dat5 = "1.20";   // CH₄（例如沼气、天然气）
            GasComp_Dat6 = "0.35";   // C₂H₆
            GasComp_Dat7 = "0.25";   // C₃H₈
            GasComp_Dat8 = "0.18";   // C₄H₁₀
            GasComp_Dat9 = "0.10";   // NH₃
            GasComp_Dat10 = "0.08";  // H₂S



            //this.UseWaitCursor = true;
            //this.UseWaitCursor = false;

            #region 初始化 tabPage1
            //// 设置表头名称
            tabPage1.Text = "基本信息";
            tabPage2.Text = "井下解吸";
            tabPage3.Text = "常压解吸";
            tabPage4.Text = "实验结果";
            tabPage5.Text = "文档输出";
            tabPage6.Text = "数据管理";

            //// 加载嵌入资源图标
            //try
            //{
            //    imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.1.ico").ToBitmap());
            //    imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.2.ico").ToBitmap());
            //    imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.3.ico").ToBitmap());
            //    imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.4.ico").ToBitmap());
            //    imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.5.ico").ToBitmap());
            //    imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.6.ico").ToBitmap());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("加载图标失败: " + ex.Message);
            //}

            // 设置表头图标
            tabPage1.ImageIndex = 0;
            tabPage2.ImageIndex = 1;
            tabPage3.ImageIndex = 2;
            tabPage4.ImageIndex = 3;
            tabPage5.ImageIndex = 4;
            tabPage6.ImageIndex = 5;

            tabControl1.SelectedIndex = 0;

            tabControl1.Selecting += tabControl1_Selecting;


            #endregion


            ////dataGridView1.Columns.Add("Id", "Id");
            ////dataGridView1.Columns.Add("Name", "Name");

            //DataTable table = new DataTable();
            //table.Columns.Add("Id", typeof(int));
            //table.Columns.Add("Name", typeof(string));

            //table.Rows.Add(1, "Alice");
            //table.Rows.Add(2, "Bob");
            //table.Rows.Add(3, "Bob");

            //dataGridView1.DataSource = table;  // 自动生成列，显示数据





            //#region 模拟用户输入 tabPage2

            //// 模拟用户输入
            //MineNameTextBox.Text = "名称";
            //SamplingSpotTextBox.Text = "地点";
            //BurialDepthTextBox.Text = "456";
            //CoalSeamTextBox.Text = "煤层";
            //LabAtmPressureTextBox.Text = "101.2";
            //UndAtmPressureTextBox.Text = "103.4";
            //LabTempTextBox.Text = "25";
            //UndTempTextBox.Text = "18";
            //MoistureSampleTextBox.Text = "1.2";
            //RawCoalMoistureTextBox.Text = "4.1";
            //SampleNumTextBox.Text = "M2025";
            //SampleWeightTextBox.Text = "105";
            //InitialVolumeTextBox.Text = "3";

            //t0TextBox.Text = "2";

            //DesorbTextBox1.Text = "36";
            //DesorbTextBox2.Text = "56";
            //DesorbTextBox3.Text = "76";
            //DesorbTextBox4.Text = "86";
            //DesorbTextBox5.Text = "98";
            //DesorbTextBox6.Text = "106";
            //DesorbTextBox7.Text = "114";
            //DesorbTextBox8.Text = "122";
            //DesorbTextBox9.Text = "128";
            //DesorbTextBox10.Text = "144";
            //DesorbTextBox11.Text = "152";
            //DesorbTextBox12.Text = "166";
            //DesorbTextBox13.Text = "178";
            //DesorbTextBox14.Text = "192";
            //DesorbTextBox15.Text = "200";
            //DesorbTextBox16.Text = "208";
            //DesorbTextBox17.Text = "218";
            //DesorbTextBox18.Text = "232";
            //DesorbTextBox19.Text = "244";
            //DesorbTextBox20.Text = "250";
            ////DesorbTextBox21.Text = "270";
            //DesorbTextBox22.Text = "270";
            ////DesorbTextBox23.Text = "324";
            //DesorbTextBox24.Text = "298";
            ////DesorbTextBox25.Text = "390";
            //DesorbTextBox26.Text = "324";
            ////DesorbTextBox27.Text = "416";
            //DesorbTextBox28.Text = "358";
            ////DesorbTextBox29.Text = "442";
            //DesorbTextBox30.Text = "390";

            //DataNumTextBox31.Text = "35";
            //DataNumTextBox32.Text = "40";
            //DataNumTextBox33.Text = "45";
            //DataNumTextBox34.Text = "50";
            //DataNumTextBox35.Text = "60";

            //// 模拟输入数据
            //for (int i = 31; i <= 60; i++)
            //{
            //    string controlName = "DataNumTextBox" + i;
            //    Control[] foundControls = this.Controls.Find(controlName, true);
            //    if (foundControls.Length > 0 && foundControls[0] is TextBox)
            //    {
            //        ((TextBox)foundControls[0]).Text = i.ToString(); // 可自定义内容
            //    }
            //}


            //DesorpVolNormalTextBox.Text = "1";
            //Sample1WeightTextBox.Text = "100";
            //Sample2WeightTextBox.Text = "100";
            //S1DesorpVolTextBox.Text = "30";
            //S2DesorpVolTextBox.Text = "30";

            //AdsorpConstATextBox.Text = "1";
            //AdsorpConstBTextBox.Text = "2";
            //MadTextBox.Text = "3";
            //AadTextBox.Text = "4";
            //PorosityTextBox.Text = "5";
            //AppDensityTextBox.Text = "6";
            //VadTextBox.Text = "7";

            //#endregion

            //tabPage5DoubleBufferedFlowLayoutPanel1.Enabled = false;


            // 特殊处理，为了提高选项卡图标清晰度而设置的图片点击行为
            this.tabControl1PictureBox.Click += tabControlxPictureBox_Click;
            this.tabControl2PictureBox.Click += tabControlxPictureBox_Click;
            this.tabControl3PictureBox.Click += tabControlxPictureBox_Click;
            this.tabControl4PictureBox.Click += tabControlxPictureBox_Click;
            this.tabControl5PictureBox.Click += tabControlxPictureBox_Click;
            this.tabControl6PictureBox.Click += tabControlxPictureBox_Click;

            //tabControl1.ItemSize = new Size(98, 100);
            //tabControl1.ItemSize = new Size(98, 92);

            var loc = GasFormsApp.Settings.Default.WindowLocation;
            var size = GasFormsApp.Settings.Default.WindowSize;
            var state = GasFormsApp.Settings.Default.WindowState;

            bool isSizeValid = size.Width > 0 && size.Height > 0;
            bool isLocValid = loc.X > 0 && loc.Y > 0; // 简单判断，必要时可以改成屏幕边界检测
            if (isSizeValid && isLocValid)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = loc;
                this.Size = size;
                this.WindowState = state;
            }
            else
            {
                // 没有保存过有效设置，使用默认设置
                int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                int screenHeight = Screen.PrimaryScreen.Bounds.Height;

                this.Width = (int)(screenWidth * .8);
                this.Height = (int)(screenHeight * .8);
                // 居中设置
                this.Left = (screenWidth - this.Width) / 2;
                this.Top = (screenHeight - this.Height) / 2;
            }

            //// 隐藏 tabControl，防止闪烁
            //tabControl1.Visible = false;

            TabPage currentPage = tabControl1.SelectedTab;

            foreach (TabPage page in tabControl1.TabPages)
            {
                tabControl1.SelectedTab = page;
                Application.DoEvents(); // 强制加载控件内容
            }

            tabControl1.SelectedTab = currentPage;
            //tabControl1.Visible = true;

            EnableDoubleBuffering(this.tabControl1);


            //ResizeControls(this);

            myTabLogic1.TabControl_1_InputCheckTimer_Tick();
            myTabLogic2.TabControl_2_InputCheckTimer_Tick();
            myTabLogic3.TabControl_3_InputCheckTimer_Tick();
            myTabLogic4.TabControl_4_InputCheckTimer_Tick();
            myTabLogic5.TabControl_5_InputCheckTimer_Tick();

            // 动态加载log
            //string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", "log.png");
            //Image img = Image.FromFile(imagePath);
            // 1. 获取用户AppData目录
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // 2. 目标文件路径
            string targetDir = Path.Combine(appData, "瓦斯含量测定数据分析系统", "Image");
            string targetFile = Path.Combine(targetDir, "log.png");

            // 3. 程序运行目录下的源文件路径
            string sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", "log.png");

            // 4. 检查目标目录是否存在，不存在则创建
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            // 5. 检查目标文件是否存在，若不存在则复制
            if (!File.Exists(targetFile))
            {
                if (File.Exists(sourceFile))
                {
                    File.Copy(sourceFile, targetFile);
                }
                else
                {
                    MessageBox.Show($"程序目录下源文件不存在：{sourceFile}");
                    return;
                }
            }
            //Image img = Image.FromFile(targetFile);
            Image img;
            using (var tempImg = Image.FromFile(targetFile))
            {
                img = new Bitmap(tempImg);  // 从文件读到内存
            }

            int fixedHeight = 40;
            // 等比例缩放计算新宽度
            int newWidth = (int)(img.Width * (fixedHeight / (float)img.Height));
            // 设置 PictureBox 大小
            pictureBox1.Height = fixedHeight;
            pictureBox1.Width = newWidth;
            // 设置图片和显示模式
            pictureBox1.Image = img;
            // 强制拉满填充
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // 动态修改软件标题（非App上端）
            //string iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", "CompanyName.ini");
            //string companyName = ReadValue("CompanyName", "CompanyName", iniPath);
            //label2.Text = companyName;
            // 1. 获取用户AppData目录
            appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // 2. 目标文件路径
            targetDir = Path.Combine(appData, "瓦斯含量测定数据分析系统", "Image");
            targetFile = Path.Combine(targetDir, "CompanyName.ini");
            // 3. 程序运行目录下的源文件路径
            sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", "CompanyName.ini");
            // 4. 检查目标目录是否存在，不存在则创建
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            // 5. 检查目标文件是否存在，若不存在则复制
            if (!File.Exists(targetFile))
            {
                if (File.Exists(sourceFile))
                {
                    File.Copy(sourceFile, targetFile);
                }
                else
                {
                    MessageBox.Show($"程序目录下源文件不存在：{sourceFile}");
                    return;
                }
            }
            string companyName = ReadValue("CompanyName", "CompanyName", sourceFile);
            label2.Text = companyName;

            // 1. 获取用户AppData目录
            appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // 2. 目标文件路径
            targetDir = Path.Combine(appData, "瓦斯含量测定数据分析系统", "Image");
            targetFile = Path.Combine(targetDir, "ColorConfig.ini");
            // 3. 程序运行目录下的源文件路径
            sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", "ColorConfig.ini");
            // 4. 检查目标目录是否存在，不存在则创建
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            // 5. 检查目标文件是否存在，若不存在则复制
            if (!File.Exists(targetFile))
            {
                if (File.Exists(sourceFile))
                {
                    File.Copy(sourceFile, targetFile);
                }
                else
                {
                    MessageBox.Show($"程序目录下源文件不存在：{sourceFile}");
                    return;
                }
            }

            // 读取Log栏颜色
            //iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", "ColorConfig.ini");
            // 读取字体颜色
            string LogForeColor = ReadValue("ColorConfig", "LogForeColor", targetFile);
            if (LogForeColor.StartsWith("#") && LogForeColor.Length == 9)
            {
                byte a = Convert.ToByte(LogForeColor.Substring(1, 2), 16);
                byte r = Convert.ToByte(LogForeColor.Substring(3, 2), 16);
                byte g = Convert.ToByte(LogForeColor.Substring(5, 2), 16);
                byte b = Convert.ToByte(LogForeColor.Substring(7, 2), 16);
                label2.ForeColor = Color.FromArgb(a, r, g, b);
            }
            else
            {
                label2.ForeColor = Color.Black;
            }

            // 读取背景颜色
            string LogBackColor = ReadValue("ColorConfig", "LogBackColor", targetFile);
            if (LogBackColor.StartsWith("#") && LogBackColor.Length == 9)
            {
                byte a = Convert.ToByte(LogBackColor.Substring(1, 2), 16);
                byte r = Convert.ToByte(LogBackColor.Substring(3, 2), 16);
                byte g = Convert.ToByte(LogBackColor.Substring(5, 2), 16);
                byte b = Convert.ToByte(LogBackColor.Substring(7, 2), 16);
                label2.BackColor = Color.FromArgb(a, r, g, b);
                pictureBox1.BackColor = Color.FromArgb(a, r, g, b);
            }
            else
            {
                label2.BackColor = Color.White;
            }

            if (Version == 0)
            {
                // 只留首页
                //tabControl1.TabPages.Remove(tabPage2);
                //tabControl1.TabPages.Remove(tabPage3);
            }
            else if (Version == 1)
            {
                // 留首页和管理页
                //tabControl1.TabPages.Remove(tabPage3);
            }
            else if (Version == 2)
            {
                // 全部显示，不需要移除
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage6);
                tabControl3PictureBox.Visible = false;
                tabControl4PictureBox.Visible = false;
                tabControl5PictureBox.Visible = false;
                tabControl6PictureBox.Visible = false;
                panel1.Location = new System.Drawing.Point(200,73);
            }
            tabControl1_isInitializing = false;
            //开启定时器
            InputCheckTimer.Enabled = true;
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1_isInitializing) return;

            int targetIndex = tabControl1.TabPages.IndexOf(e.TabPage);

            if (Version == 0)
            {
                //// 假设 Version=0 只能看第0页
                //if (targetIndex > 0)
                //{
                //    e.Cancel = true;
                //    MessageBox.Show("无权限");
                //}
            }
            else if (Version == 1)
            {
                //// 假设 Version=1 可以看第0和第1页
                //if (targetIndex > 1)
                //{
                //    e.Cancel = true;
                //    MessageBox.Show("无权限");
                //}
            }
            else if (Version == 2)
            {
                // 假设 Version=2 可以看第0和第1页
                if (targetIndex > 1)
                {
                    e.Cancel = true;
                    MessageBox.Show("无权限");
                }
            }
        }

        // 动态修改软件标题（非App上端）
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(
            string section, string key, string defaultValue,
            StringBuilder returnValue, int size, string filePath);
        public string ReadValue(string section, string key, string _filePath)
        {
            StringBuilder result = new StringBuilder(1024);
            GetPrivateProfileString(section, key, "", result, result.Capacity, _filePath);
            return result.ToString();
        }

        //文本检测100ms定时器
        int a = 0;
        private void InputCheckTimer_Tick(object sender, EventArgs e)
        {
            if(a++==1)
            {
                if (this.Opacity == 0)
                {
                    this.Opacity = 1;
                }
                
                a = 0;
                TabPage currentTab = tabControl1.SelectedTab;

                switch (currentTab.Name)
                {
                    case "tabPage1":
                        myTabLogic1.TabControl_1_InputCheckTimer_Tick();
                        break;
                    case "tabPage2":
                        myTabLogic2.TabControl_2_InputCheckTimer_Tick();
                        break;
                    case "tabPage3":
                        myTabLogic3.TabControl_3_InputCheckTimer_Tick();
                        break;
                    case "tabPage4":
                        myTabLogic4.TabControl_4_InputCheckTimer_Tick();
                        break;
                    case "tabPage5":
                        myTabLogic5.TabControl_5_InputCheckTimer_Tick();
                        break;
                }
            }
        }

        //快捷键操作
        private void TabControl_KeyDown(object sender, KeyEventArgs e)
        {
            TabPage currentTab = tabControl1.SelectedTab;

            if (!e.Control) return;

            switch (e.KeyCode)
            {
                case Keys.D: // 计算
                    switch (currentTab.Name)
                    {
                        case "tabPage2":
                            myTabLogic2.DrawCurvesButton_Click(sender, e);
                            break;
                        case "tabPage3":
                            myTabLogic3.LabDesorbButton_Click(sender, e);
                            break;
                        case "tabPage4":
                            myTabLogic4.ExpCalcButton_Click(sender, e);
                            break;
                        case "tabPage6":
                            myTabLogic6.DeleteDataButton_Click(sender, e);
                            break;
                    }
                    e.Handled = true;
                    break;

                case Keys.G: // 生成
                    if (e.Shift)
                    {
                        if (currentTab.Name == "tabPage5")
                        {
                            myTabLogic5.GenRecordButton_Click(sender, e);
                        }
                    }
                    else
                    {
                        switch (currentTab.Name)
                        {
                            case "tabPage5":
                                myTabLogic5.GenReportButton_Click(sender, e);
                                break;
                            case "tabPage6":
                                myTabLogic6.ExportTheDocumentButton_Click(sender, e);
                                break;
                        }
                    }
                    e.Handled = true;
                    break;

                case Keys.S: // 保存
                    if (e.Shift)
                    {
                        if (currentTab.Name == "tabPage1")
                        {
                            myTabLogic1.tabPage1TemporarySavingButton_Click(sender, e);
                        }
                        else if (currentTab.Name == "tabPage2")
                        {
                            myTabLogic2.tabPage2TemporarySavingButton_Click(sender, e);
                        }
                        else if (currentTab.Name == "tabPage3")
                        {
                            myTabLogic3.tabPage3TemporarySavingButton_Click(sender, e);
                        }
                        else if (currentTab.Name == "tabPage4")
                        {
                            myTabLogic4.tabPage4TemporarySavingButton_Click(sender, e);
                        }
                        else if (currentTab.Name == "tabPage5")
                        {
                            myTabLogic5.tabPage5TemporarySavingButton_Click(sender, e);
                        }
                    }
                    else
                    {
                        if (currentTab.Name == "tabPage5")
                        {
                            myTabLogic5._SaveButton_Click(sender, e);
                        }
                    }
                    
                    e.Handled = true;
                    break;

                case Keys.R: // 刷新
                    if (currentTab.Name == "tabPage1")
                    {
                        myTabLogic1.tabPage1RecoverDataButton_Click(sender, e);
                    }
                    else if (currentTab.Name == "tabPage2")
                    {
                        myTabLogic2.tabPage2RecoverDataButton_Click(sender, e);
                    }
                    else if (currentTab.Name == "tabPage3")
                    {
                        myTabLogic3.tabPage3RecoverDataButton_Click(sender, e);
                    }
                    else if (currentTab.Name == "tabPage4")
                    {
                        myTabLogic4.tabPage4RecoverDataButton_Click(sender, e);
                    }
                    else if (currentTab.Name == "tabPage5")
                    {
                        myTabLogic5.tabPage5RecoverDataButton_Click(sender, e);
                    }
                    else if (currentTab.Name == "tabPage6")
                    {
                        myTabLogic6.ReloadDataButton_Click(sender, e);
                    }
                    e.Handled = true;
                    break;

                case Keys.F: // 查找
                    if (currentTab.Name == "tabPage6")
                    {
                        FindTextBox.Focus();
                        FindTextBox.SelectAll();
                    }
                    e.Handled = true;
                    break;

                case Keys.I: // 批量导入数据
                    if (currentTab.Name == "tabPage2")
                    {
                        myTabLogic2.BulkImportButton_Click(sender, e);
                    }
                    e.Handled = true;
                    break;
            }
        }
        // tab5调用tab6的函数
        public bool tab5_6_SaveButton(object sender, EventArgs e)
        {
            return myTabLogic6.SaveButton_Click(sender, e);
        }

        // tab6调用tab5的函数
        public void tab6_5_GenerateReportToDatabase(string doc_name)
        {
            myTabLogic5.GenerateReportToDatabase(doc_name);
        }

        // tab5调用tab4的函数
        public void tab5_4_P瓦斯压力选择()
        {
            myTabLogic4.P瓦斯压力选择();
        }

        // tab6调用tab4的函数
        public void tab6_4_ExpCalcButton_Click(object sender, EventArgs e)
        {
            myTabLogic4.ExpCalcButton_Click(sender,e);
        }

        // 系统窗口重绘机制
        private bool _suspendDrawing = false;
        protected override void WndProc(ref Message m)
        {
            const int WM_ENTERSIZEMOVE = 0x0231;
            const int WM_EXITSIZEMOVE = 0x0232;
            const int WM_SIZE = 0x0005;

            const int SIZE_MAXIMIZED = 2;
            const int SIZE_RESTORED = 1;

            switch (m.Msg)
            {
                case WM_ENTERSIZEMOVE:
                    _suspendDrawing = true;
                    SuspendDrawing(this);
                    break;

                case WM_EXITSIZEMOVE:
                    _suspendDrawing = false;
                    ResumeDrawing(this);
                    this.Invalidate();  // 触发重绘
                    break;

                case WM_SIZE:
                    int wParam = m.WParam.ToInt32();
                    if (wParam == SIZE_MAXIMIZED || wParam == SIZE_RESTORED)
                    {
                        // 暂停绘制
                        SuspendDrawing(this);
                        _suspendDrawing = true;

                        // 这里可以延迟一点点再重绘
                        BeginInvoke(new Action(() =>
                        {
                            _suspendDrawing = false;
                            ResumeDrawing(this);
                            this.Invalidate();
                        }));
                    }
                    break;
            }

            base.WndProc(ref m);
        }

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }

        private const int WM_SETREDRAW = 0x000B;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, bool wParam, int lParam);

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lastRightClickPosition = e.Location;  // 相对于控件的坐标
                lastRightClickedControl = sender as Control;
                ChangeColorContextMenuStrip.Show(this, e.Location); // 弹出菜单
            }
        }
        private Control GetDeepChildAtPoint(Control parent, Point point)
        {
            Control child = parent.GetChildAtPoint(point);
            if (child == null)
                return parent;

            Point childPoint = child.PointToClient(parent.PointToScreen(point));
            return GetDeepChildAtPoint(child, childPoint);
        }

        private void 更改背景色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastRightClickedControl == null) return;

            // 如果想获取最具体子控件，可以递归判断
            Control preciseControl = GetDeepChildAtPoint(lastRightClickedControl, lastRightClickPosition);

            // 特殊处理
            if (preciseControl is Label)
            {
                using (ColorDialog colorDialog = new ColorDialog())
                {
                    // 设置初始颜色
                    colorDialog.Color = preciseControl.BackColor;

                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        // 选好颜色后，同时应用到两个控件
                        preciseControl.BackColor = colorDialog.Color;
                        pictureBox1.BackColor = colorDialog.Color;
                    }
                }
            }
            else
                ChooseBackColor(preciseControl);

            //string iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", "ColorConfig.ini");
            // 获取当前用户的 AppData\Roaming 路径
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // 拼接专用目录
            string configDir = Path.Combine(appData, "瓦斯含量测定数据分析系统", "Image");
            // 确保目录存在
            if (!Directory.Exists(configDir))
            {
                Directory.CreateDirectory(configDir);
            }
            // 拼接 INI 文件完整路径
            string iniPath = Path.Combine(configDir, "ColorConfig.ini");
            IniFile ini = new IniFile(iniPath);

            // 保存背景色
            Color backColor = preciseControl.BackColor;
            string backColorStr = $"#{backColor.A:X2}{backColor.R:X2}{backColor.G:X2}{backColor.B:X2}";
            ini.Write("ColorConfig", "LogBackColor", backColorStr);

            // 保存字体色
            Color foreColor = preciseControl.ForeColor;
            string foreColorStr = $"#{foreColor.A:X2}{foreColor.R:X2}{foreColor.G:X2}{foreColor.B:X2}";
            ini.Write("ColorConfig", "LogForeColor", foreColorStr);
        }

        private void 更改字体颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastRightClickedControl == null) return;

            // 如果想获取最具体子控件，可以递归判断
            Control preciseControl = GetDeepChildAtPoint(lastRightClickedControl, lastRightClickPosition);

            ChooseForeColor(preciseControl);

            //string iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", "ColorConfig.ini");
            // 获取当前用户的 AppData\Roaming 路径
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // 拼接专用目录
            string configDir = Path.Combine(appData, "瓦斯含量测定数据分析系统", "Image");
            // 确保目录存在
            if (!Directory.Exists(configDir))
            {
                Directory.CreateDirectory(configDir);
            }
            // 拼接 INI 文件完整路径
            string iniPath = Path.Combine(configDir, "ColorConfig.ini");
            IniFile ini = new IniFile(iniPath);

            // 保存背景色
            Color backColor = preciseControl.BackColor;
            string backColorStr = $"#{backColor.A:X2}{backColor.R:X2}{backColor.G:X2}{backColor.B:X2}";
            ini.Write("ColorConfig", "LogBackColor", backColorStr);

            // 保存字体色
            Color foreColor = preciseControl.ForeColor;
            string foreColorStr = $"#{foreColor.A:X2}{foreColor.R:X2}{foreColor.G:X2}{foreColor.B:X2}";
            ini.Write("ColorConfig", "LogForeColor", foreColorStr);
        }

        private void 更改LogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 获取 AppData\瓦斯含量测定数据分析系统\Image 目录
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string targetDir = Path.Combine(appData, "瓦斯含量测定数据分析系统", "Image");
            string targetFile = Path.Combine(targetDir, "log.png");

            // 确保目标目录存在
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "请选择新的 log.png 文件";
                openFileDialog.Filter = "PNG图片|*.png";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    try
                    {
                        // 覆盖复制到目标目录
                        File.Copy(selectedFilePath, targetFile, true); // true=覆盖

                        //MessageBox.Show("图片替换成功！");

                        // 如果要立即显示新图片（推荐加载到内存，避免锁文件）：
                        using (var tempImg = Image.FromFile(targetFile))
                        {
                            var img = new Bitmap(tempImg);
                            pictureBox1.Image = img;

                            int fixedHeight = 40;
                            int newWidth = (int)(img.Width * (fixedHeight / (float)img.Height));
                            pictureBox1.Height = fixedHeight;
                            pictureBox1.Width = newWidth;
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("复制失败：" + ex.Message);
                    }
                }
            }
        }

        private void ChooseBackColor(Control control)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = control.BackColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    control.BackColor = colorDialog.Color;
                }
            }
        }
        private void ChooseForeColor(Control control)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = control.ForeColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    control.ForeColor = colorDialog.Color;
                }
            }
        }

        // 关闭确认？防止误操作将软件关闭
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] inputs = { tabPage1.Text, tabPage2.Text, tabPage3.Text, tabPage4.Text, tabPage5.Text };
            bool hasAsterisk = inputs.Any(s => s.Contains("*"));
            if (hasAsterisk)
            {
                Console.WriteLine("至少有一个字符串包含 *");

                DialogResult result = MessageBox.Show(
                "数据未保存，确定要退出程序吗？",
                "提示",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

                if (result != DialogResult.Yes)
                {
                    e.Cancel = true; // 取消关闭操作
                }
            }
            else
            {
                Console.WriteLine("所有字符串都不包含 *");
            }

            if (this.WindowState == FormWindowState.Normal)
            {
                GasFormsApp.Settings.Default.WindowLocation = this.Location;
                GasFormsApp.Settings.Default.WindowSize = this.Size;
            }
            else
            {
                // 如果窗口是最大化或最小化，保存正常状态时的位置和大小
                GasFormsApp.Settings.Default.WindowLocation = this.RestoreBounds.Location;
                GasFormsApp.Settings.Default.WindowSize = this.RestoreBounds.Size;
            }
            GasFormsApp.Settings.Default.WindowState = this.WindowState;
            GasFormsApp.Settings.Default.Save();
        }
    }
}
