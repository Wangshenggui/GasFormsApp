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

            #region 模拟用户输入 tabPage2

            // 模拟用户输入
            MineNameTextBox.Text = "名称";
            SamplingSpotTextBox.Text = "地点";
            BurialDepthTextBox.Text = "456";
            CoalSeamTextBox.Text = "煤层";
            LabAtmPressureTextBox.Text = "101.2";
            UndAtmPressureTextBox.Text = "103.4";
            LabTempTextBox.Text = "25";
            UndTempTextBox.Text = "18";
            MoistureSampleTextBox.Text = "1.2";
            RawCoalMoistureTextBox.Text = "4.1";
            SampleNumTextBox.Text = "M2025";
            SampleWeightTextBox.Text = "105";
            InitialVolumeTextBox.Text = "3";

            t0TextBox.Text = "2";
            DesorbTextBox1.Text = "10";
            DesorbTextBox2.Text = "12";
            DesorbTextBox3.Text = "14";
            DesorbTextBox4.Text = "18";
            DesorbTextBox5.Text = "22";
            //DesorbTextBox6.Text = "62";
            //DesorbTextBox7.Text = "66";
            //DesorbTextBox8.Text = "70";
            //DesorbTextBox9.Text = "74";
            //DesorbTextBox10.Text = "76";
            //DesorbTextBox11.Text = "78";
            //DesorbTextBox12.Text = "82";
            //DesorbTextBox13.Text = "84";
            //DesorbTextBox14.Text = "86";
            //DesorbTextBox15.Text = "88";
            //DesorbTextBox16.Text = "90";
            //DesorbTextBox17.Text = "92";
            //DesorbTextBox18.Text = "94";
            //DesorbTextBox19.Text = "96";
            //DesorbTextBox20.Text = "98";
            //DesorbTextBox21.Text = "100";
            //DesorbTextBox22.Text = "102";
            //DesorbTextBox23.Text = "102";
            //DesorbTextBox24.Text = "102";
            //DesorbTextBox25.Text = "98";
            //DesorbTextBox26.Text = "100";
            //DesorbTextBox27.Text = "102";
            //DesorbTextBox28.Text = "106";
            //DesorbTextBox29.Text = "108";
            //DesorbTextBox30.Text = "110";

            DesorpVolNormalTextBox.Text = "1";
            Sample1WeightTextBox.Text = "100";
            Sample2WeightTextBox.Text = "100";
            S1DesorpVolTextBox.Text = "30";
            S2DesorpVolTextBox.Text = "30";

            AdsorpConstATextBox.Text = "1";
            AdsorpConstBTextBox.Text = "2";
            MadTextBox.Text = "3";
            AadTextBox.Text = "4";
            PorosityTextBox.Text = "5";
            AppDensityTextBox.Text = "6";
            VadTextBox.Text = "7";

            #endregion

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
    }
}
