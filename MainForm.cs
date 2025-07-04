﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
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
        private bool v;
        private ImageList imageList1;

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
        public MainForm(bool v)
        {
            this.v = v;
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint, true);
            this.UpdateStyles();

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
            tabPage5.Text = "归档设置";
            tabPage6.Text = "历史记录";

            // 创建并绑定图像列表到 TabControl
            imageList1 = new ImageList();
            imageList1.ImageSize = new System.Drawing.Size(32, 32);
            tabControl1.ImageList = imageList1;

            // 加载嵌入资源图标
            try
            {
                imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.1.ico").ToBitmap());
                imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.2.ico").ToBitmap());
                imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.3.ico").ToBitmap());
                imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.4.ico").ToBitmap());
                imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.5.ico").ToBitmap());
                imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.6.ico").ToBitmap());
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
            tabPage5.ImageIndex = 4;
            tabPage6.ImageIndex = 5;

            tabControl1.SelectedIndex = 0;


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


            //tabPage5DoubleBufferedFlowLayoutPanel1.Enabled = false;
            //开启定时器
            InputCheckTimer.Enabled = true;
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
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            this.Width = (int)(screenWidth * 0.8);
            this.Height = (int)(screenHeight * 0.8);
            // 居中设置
            this.Left = (screenWidth - this.Width) / 2;
            this.Top = (screenHeight - this.Height) / 2;

            xRatio = screenWidth / 1920f; // 假设设计时是 1920x1080
            yRatio = screenHeight / 1080f;

            EnableDoubleBuffering(this.tabControl1);


            //ResizeControls(this);

            myTabLogic1.TabControl_1_InputCheckTimer_Tick();
            myTabLogic2.TabControl_2_InputCheckTimer_Tick();
            myTabLogic3.TabControl_3_InputCheckTimer_Tick();
            myTabLogic4.TabControl_4_InputCheckTimer_Tick();
            myTabLogic5.TabControl_5_InputCheckTimer_Tick();

            // 动态加载log
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", "log.png");
            Image img = Image.FromFile(imagePath);
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
            string iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", "CompanyName.ini");
            string companyName = ReadValue("CompanyName", "CompanyName", iniPath);
            label2.Text = companyName;
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

            // 计算
            if (e.Control && e.KeyCode == Keys.D)
            {
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
            }
            // 生成
            else if (e.Control && e.KeyCode == Keys.G)
            {
                if (currentTab.Name == "tabPage5")
                {
                    myTabLogic5.GenReportButton_Click(sender, e);
                }
                else if (currentTab.Name == "tabPage6")
                {
                    myTabLogic6.ExportTheDocumentButton_Click(sender, e);
                }

                e.Handled = true;
            }
            // 保存
            else if (e.Control && e.KeyCode == Keys.S)
            {
                if (currentTab.Name == "tabPage5")
                {
                    myTabLogic5._SaveButton_Click(sender, e);
                }

                e.Handled = true;
            }
            // 刷新
            else if (e.Control && e.KeyCode == Keys.R)
            {
                if (currentTab.Name == "tabPage6")
                {
                    myTabLogic6.ReloadDataButton_Click(sender, e);
                }

                e.Handled = true;
            }
            // 查找
            else if (e.Control && e.KeyCode == Keys.F)
            {
                if (currentTab.Name == "tabPage6")
                {
                    //搜索框进入编辑模式
                    FindTextBox.Focus();
                    FindTextBox.SelectAll();
                }

                e.Handled = true;
            }
            // 批量导入数据
            else if(e.Control && e.KeyCode == Keys.I)
            {
                if (currentTab.Name == "tabPage2")
                {
                    myTabLogic2.BulkImportButton_Click(sender, e);
                }

                e.Handled = true;
            }
        }
        // tab5调用tab6的函数
        public void tab5_6_SaveButton(object sender, EventArgs e)
        {
            myTabLogic6.SaveButton_Click(sender, e);
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

        private void doubleBufferedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2DoubleBufferedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
