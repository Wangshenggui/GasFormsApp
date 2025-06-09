using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using GasFormsApp.TabControl;

namespace GasFormsApp
{
    public partial class MainForm : Form
    {
        private bool v;
        private ImageList imageList1;

        //python执行标志
        public static bool python执行标志 = false;

        //Wc选择标志
        public static bool WcOutCheckBoxFlag = true;
        //瓦斯含量选择标志
        public static bool GasCompCheckBoxFlag = false;

        public static double 井下解吸体积 = 0.0;
        public static double 井下解吸校准体积 = 0.0;
        public static double W1 = 0.0;
        public static double W2 = 0.0;
        public static double W3 = 0.0;
        public static double Wa = 0.0;
        public static double Wc = 0.0;
        public static double W = 0.0;
        public static double P = 0.0;

        private tabControl_1 myTabLogic1;
        private tabControl_2 myTabLogic2;
        private tabControl_3 myTabLogic3;
        private tabControl_4 myTabLogic4;
        private tabControl_5 myTabLogic5;


        private List<TextBox> desorbTextBoxes;
        public MainForm(bool v)
        {
            this.v = v;
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            //this.UseWaitCursor = true;
            //this.UseWaitCursor = false;

            #region 初始化 tabPage1
            //// 设置表头名称
            tabPage1.Text = "基本信息";
            tabPage2.Text = "井下解吸";
            tabPage3.Text = "常压解吸";
            tabPage4.Text = "实验结果";
            tabPage5.Text = " 备  注 ";

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
                imageList1.Images.Add(LoadIconFromResource("GasFormsApp.Image.5.ico").ToBitmap());
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

            #endregion

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


            GasCompGroupBox.Enabled = false;
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        //文本检测100ms定时器
        int a = 0;
        private void InputCheckTimer_Tick(object sender, EventArgs e)
        {
            myTabLogic1.TabControl_1_InputCheckTimer_Tick();
            myTabLogic2.TabControl_2_InputCheckTimer_Tick();
            myTabLogic3.TabControl_3_InputCheckTimer_Tick();
            myTabLogic4.TabControl_4_InputCheckTimer_Tick();
        }

        //快捷键操作
        private void TabControl_KeyDown(object sender, KeyEventArgs e)
        {
            TabPage currentTab = tabControl1.SelectedTab;

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
                }

                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                if (currentTab.Name == "tabPage5")
                {
                    myTabLogic5.GenReportButton_Click(sender, e);
                }

                e.Handled = true;
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }
}
