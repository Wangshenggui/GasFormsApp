using System.Windows.Forms;

namespace GasFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("项目");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("矿井", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("根目录", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage1panel1 = new System.Windows.Forms.Panel();
            this.tabPage1panel2 = new AntdUI.Panel();
            this.tabPage1DoubleBufferedFlowLayoutPanel1 = new GasFormsApp.UI.DoubleBufferedFlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.MineNameTextBox = new AntdUI.Input();
            this.label6 = new System.Windows.Forms.Label();
            this.SamplingSpotTextBox = new AntdUI.Input();
            this.label39 = new System.Windows.Forms.Label();
            this.X_YTextBox = new AntdUI.Input();
            this.label7 = new System.Windows.Forms.Label();
            this.BurialDepthTextBox = new AntdUI.Input();
            this.label3 = new System.Windows.Forms.Label();
            this.CoalSeamTextBox = new AntdUI.Input();
            this.label9 = new System.Windows.Forms.Label();
            this.UndAtmPressureTextBox = new AntdUI.Input();
            this.label10 = new System.Windows.Forms.Label();
            this.UndTempTextBox = new AntdUI.Input();
            this.label11 = new System.Windows.Forms.Label();
            this.LabAtmPressureTextBox = new AntdUI.Input();
            this.label12 = new System.Windows.Forms.Label();
            this.LabTempTextBox = new AntdUI.Input();
            this.label14 = new System.Windows.Forms.Label();
            this.MoistureSampleTextBox = new AntdUI.Input();
            this.label15 = new System.Windows.Forms.Label();
            this.SampleModeComboBox = new AntdUI.Select();
            this.label20 = new System.Windows.Forms.Label();
            this.SampleNumTextBox = new AntdUI.Input();
            this.label16 = new System.Windows.Forms.Label();
            this.RawCoalMoistureTextBox = new AntdUI.Input();
            this.label19 = new System.Windows.Forms.Label();
            this.InitialVolumeTextBox = new AntdUI.Input();
            this.label13 = new System.Windows.Forms.Label();
            this.SampleWeightTextBox = new AntdUI.Input();
            this.label4 = new System.Windows.Forms.Label();
            this.SamplingDepthTextBox = new AntdUI.Input();
            this.label8 = new System.Windows.Forms.Label();
            this.SamplingTimeDateTimePicker = new AntdUI.DatePicker();
            this.label37 = new System.Windows.Forms.Label();
            this.DrillInclinationTextBox = new AntdUI.Input();
            this.label38 = new System.Windows.Forms.Label();
            this.AzimuthTextBox = new AntdUI.Input();
            this.label41 = new System.Windows.Forms.Label();
            this.SamplingPersonnelTextBox = new AntdUI.Input();
            this.label36 = new System.Windows.Forms.Label();
            this.CoalTypeComboBox = new AntdUI.Select();
            this.tabPage1TemporarySavingButton = new GasFormsApp.UI.UCButton();
            this.tabPage1RecoverDataButton = new GasFormsApp.UI.UCButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage2DoubleBufferedPanel2 = new GasFormsApp.UI.DoubleBufferedPanel();
            this.tabPage2panel2 = new System.Windows.Forms.Panel();
            this.tabPage2panel1 = new System.Windows.Forms.Panel();
            this.tabPage2DoubleBufferedFlowLayoutPanel1 = new GasFormsApp.UI.DoubleBufferedFlowLayoutPanel();
            this.tabPage2panel7 = new GasFormsApp.UI.DoubleBufferedPanel();
            this.tabPage2DoubleBufferedPanel1 = new GasFormsApp.UI.DoubleBufferedPanel();
            this.TypeOfDestructionComboBox3 = new AntdUI.Select();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label35 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.doubleBufferedPanel1 = new GasFormsApp.UI.DoubleBufferedPanel();
            this.t0TextBox = new AntdUI.Input();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.label34 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tabPage2panel8 = new GasFormsApp.UI.DoubleBufferedPanel();
            this.tabPage2panel3 = new System.Windows.Forms.Panel();
            this.DesorbTextBox30 = new AntdUI.Input();
            this.DesorbTextBox29 = new AntdUI.Input();
            this.DesorbTextBox28 = new AntdUI.Input();
            this.DesorbTextBox27 = new AntdUI.Input();
            this.DesorbTextBox26 = new AntdUI.Input();
            this.DesorbTextBox25 = new AntdUI.Input();
            this.DesorbTextBox24 = new AntdUI.Input();
            this.DesorbTextBox23 = new AntdUI.Input();
            this.DesorbTextBox22 = new AntdUI.Input();
            this.DesorbTextBox21 = new AntdUI.Input();
            this.DesorbTextBox20 = new AntdUI.Input();
            this.DesorbTextBox19 = new AntdUI.Input();
            this.DesorbTextBox18 = new AntdUI.Input();
            this.DesorbTextBox17 = new AntdUI.Input();
            this.DesorbTextBox16 = new AntdUI.Input();
            this.DesorbTextBox15 = new AntdUI.Input();
            this.DesorbTextBox14 = new AntdUI.Input();
            this.DesorbTextBox13 = new AntdUI.Input();
            this.DesorbTextBox12 = new AntdUI.Input();
            this.DesorbTextBox11 = new AntdUI.Input();
            this.DesorbTextBox10 = new AntdUI.Input();
            this.DesorbTextBox9 = new AntdUI.Input();
            this.DesorbTextBox8 = new AntdUI.Input();
            this.DesorbTextBox7 = new AntdUI.Input();
            this.DesorbTextBox6 = new AntdUI.Input();
            this.DesorbTextBox5 = new AntdUI.Input();
            this.DesorbTextBox4 = new AntdUI.Input();
            this.DesorbTextBox3 = new AntdUI.Input();
            this.DesorbTextBox2 = new AntdUI.Input();
            this.DesorbTextBox1 = new AntdUI.Input();
            this.label24 = new System.Windows.Forms.Label();
            this.DataNumLabel26 = new System.Windows.Forms.Label();
            this.DataNumLabel16 = new System.Windows.Forms.Label();
            this.DataNumLabel6 = new System.Windows.Forms.Label();
            this.DataNumLabel7 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.DataNumLabel17 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.DataNumLabel25 = new System.Windows.Forms.Label();
            this.DataNumLabel27 = new System.Windows.Forms.Label();
            this.DataNumLabel15 = new System.Windows.Forms.Label();
            this.DataNumLabel5 = new System.Windows.Forms.Label();
            this.DataNumLabel8 = new System.Windows.Forms.Label();
            this.DataNumLabel18 = new System.Windows.Forms.Label();
            this.DataNumLabel24 = new System.Windows.Forms.Label();
            this.DataNumLabel28 = new System.Windows.Forms.Label();
            this.DataNumLabel14 = new System.Windows.Forms.Label();
            this.DataNumLabel4 = new System.Windows.Forms.Label();
            this.DataNumLabel9 = new System.Windows.Forms.Label();
            this.DataNumLabel19 = new System.Windows.Forms.Label();
            this.DataNumLabel23 = new System.Windows.Forms.Label();
            this.DataNumLabel29 = new System.Windows.Forms.Label();
            this.DataNumLabel13 = new System.Windows.Forms.Label();
            this.DataNumLabel3 = new System.Windows.Forms.Label();
            this.DataNumLabel10 = new System.Windows.Forms.Label();
            this.DataNumLabel20 = new System.Windows.Forms.Label();
            this.DataNumLabel22 = new System.Windows.Forms.Label();
            this.DataNumLabel12 = new System.Windows.Forms.Label();
            this.DataNumLabel30 = new System.Windows.Forms.Label();
            this.DataNumLabel2 = new System.Windows.Forms.Label();
            this.DataNumLabel21 = new System.Windows.Forms.Label();
            this.DataNumLabel11 = new System.Windows.Forms.Label();
            this.DataNumLabel1 = new System.Windows.Forms.Label();
            this.tabPage2panel4 = new System.Windows.Forms.Panel();
            this.DataNumTextBox60 = new AntdUI.Input();
            this.DataNumTextBox50 = new AntdUI.Input();
            this.DataNumTextBox40 = new AntdUI.Input();
            this.DataNumTextBox59 = new AntdUI.Input();
            this.DesorbTextBox60 = new AntdUI.Input();
            this.DataNumTextBox49 = new AntdUI.Input();
            this.DataNumTextBox58 = new AntdUI.Input();
            this.label27 = new System.Windows.Forms.Label();
            this.DataNumTextBox39 = new AntdUI.Input();
            this.DataNumTextBox57 = new AntdUI.Input();
            this.DataNumTextBox48 = new AntdUI.Input();
            this.DesorbTextBox59 = new AntdUI.Input();
            this.DataNumTextBox56 = new AntdUI.Input();
            this.label29 = new System.Windows.Forms.Label();
            this.DataNumTextBox47 = new AntdUI.Input();
            this.DataNumTextBox55 = new AntdUI.Input();
            this.DataNumTextBox38 = new AntdUI.Input();
            this.DesorbTextBox58 = new AntdUI.Input();
            this.DataNumTextBox54 = new AntdUI.Input();
            this.DataNumTextBox46 = new AntdUI.Input();
            this.label28 = new System.Windows.Forms.Label();
            this.DataNumTextBox53 = new AntdUI.Input();
            this.DataNumTextBox37 = new AntdUI.Input();
            this.DataNumTextBox45 = new AntdUI.Input();
            this.DataNumTextBox52 = new AntdUI.Input();
            this.DesorbTextBox57 = new AntdUI.Input();
            this.DataNumTextBox51 = new AntdUI.Input();
            this.DesorbTextBox56 = new AntdUI.Input();
            this.DataNumTextBox44 = new AntdUI.Input();
            this.DataNumTextBox36 = new AntdUI.Input();
            this.DesorbTextBox55 = new AntdUI.Input();
            this.DataNumTextBox43 = new AntdUI.Input();
            this.DataNumTextBox35 = new AntdUI.Input();
            this.DataNumTextBox42 = new AntdUI.Input();
            this.DesorbTextBox54 = new AntdUI.Input();
            this.DataNumTextBox41 = new AntdUI.Input();
            this.DataNumTextBox34 = new AntdUI.Input();
            this.DesorbTextBox53 = new AntdUI.Input();
            this.DataNumTextBox33 = new AntdUI.Input();
            this.DesorbTextBox52 = new AntdUI.Input();
            this.DesorbTextBox50 = new AntdUI.Input();
            this.DataNumTextBox32 = new AntdUI.Input();
            this.DesorbTextBox51 = new AntdUI.Input();
            this.DesorbTextBox49 = new AntdUI.Input();
            this.DataNumTextBox31 = new AntdUI.Input();
            this.DesorbTextBox48 = new AntdUI.Input();
            this.DesorbTextBox47 = new AntdUI.Input();
            this.DesorbTextBox46 = new AntdUI.Input();
            this.DesorbTextBox45 = new AntdUI.Input();
            this.DesorbTextBox44 = new AntdUI.Input();
            this.DesorbTextBox43 = new AntdUI.Input();
            this.DesorbTextBox42 = new AntdUI.Input();
            this.DesorbTextBox41 = new AntdUI.Input();
            this.DesorbTextBox40 = new AntdUI.Input();
            this.DesorbTextBox39 = new AntdUI.Input();
            this.DesorbTextBox38 = new AntdUI.Input();
            this.DesorbTextBox37 = new AntdUI.Input();
            this.DesorbTextBox36 = new AntdUI.Input();
            this.DesorbTextBox35 = new AntdUI.Input();
            this.DesorbTextBox34 = new AntdUI.Input();
            this.DesorbTextBox33 = new AntdUI.Input();
            this.DesorbTextBox32 = new AntdUI.Input();
            this.DesorbTextBox31 = new AntdUI.Input();
            this.tabPage2panel9 = new GasFormsApp.UI.DoubleBufferedPanel();
            this.tabPage2panel5 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabPage2panel10 = new GasFormsApp.UI.DoubleBufferedPanel();
            this.tabPage2panel6 = new System.Windows.Forms.Panel();
            this.SampLossVolTextBox = new AntdUI.Input();
            this.UndDesorpCalTextBox = new AntdUI.Input();
            this.DesVolUndTextBox = new AntdUI.Input();
            this.DataExportButton = new GasFormsApp.UI.UCButton();
            this.ExportImageButton = new GasFormsApp.UI.UCButton();
            this.BulkImportButton = new GasFormsApp.UI.UCButton();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.DrawCurvesButton = new GasFormsApp.UI.UCButton();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPage2TemporarySavingButton = new GasFormsApp.UI.UCButton();
            this.tabPage2RecoverDataButton = new GasFormsApp.UI.UCButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage3panel1 = new System.Windows.Forms.Panel();
            this.tabPage3panel4 = new System.Windows.Forms.Panel();
            this.tabPage3panel2 = new System.Windows.Forms.Panel();
            this.tabPage3panel3 = new System.Windows.Forms.Panel();
            this.CrushDesorpTextBox = new AntdUI.Input();
            this.S2DesorpVolCalTextBox = new AntdUI.Input();
            this.S1DesorpVolCalTextBox = new AntdUI.Input();
            this.S2DesorpVolTextBox = new AntdUI.Input();
            this.S1DesorpVolTextBox = new AntdUI.Input();
            this.Sample2WeightTextBox = new AntdUI.Input();
            this.Sample1WeightTextBox = new AntdUI.Input();
            this.DesorpVolNormalCalTextBox = new AntdUI.Input();
            this.DesorpVolNormalTextBox = new AntdUI.Input();
            this.label89 = new System.Windows.Forms.Label();
            this.tabPage3TemporarySavingButton = new GasFormsApp.UI.UCButton();
            this.label83 = new System.Windows.Forms.Label();
            this.tabPage3RecoverDataButton = new GasFormsApp.UI.UCButton();
            this.label101 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.LabDesorbButton = new GasFormsApp.UI.UCButton();
            this.label122 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage4DoubleBufferedPanel1 = new GasFormsApp.UI.DoubleBufferedPanel();
            this.tabPage4panel1 = new System.Windows.Forms.Panel();
            this.tabPage4DoubleBufferedFlowLayoutPanel1 = new GasFormsApp.UI.DoubleBufferedFlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.NonDesorpGasQtyTextBox = new AntdUI.Input();
            this.PorosityTextBox = new AntdUI.Input();
            this.TrueDensityTextBox = new AntdUI.Input();
            this.AppDensityTextBox = new AntdUI.Input();
            this.VadTextBox = new AntdUI.Input();
            this.AadTextBox = new AntdUI.Input();
            this.MadTextBox = new AntdUI.Input();
            this.AdsorpConstBTextBox = new AntdUI.Input();
            this.AdsorpConstATextBox = new AntdUI.Input();
            this.PorosityCheckBox = new System.Windows.Forms.CheckBox();
            this.TrueDensityCheckBox = new System.Windows.Forms.CheckBox();
            this.NonDesorpGasQtyCheckBox = new System.Windows.Forms.CheckBox();
            this.VadCheckBox = new System.Windows.Forms.CheckBox();
            this.AppDensityCheckBox = new System.Windows.Forms.CheckBox();
            this.AadCheckBox = new System.Windows.Forms.CheckBox();
            this.MadCheckBox = new System.Windows.Forms.CheckBox();
            this.AdsorpConstBCheckBox = new System.Windows.Forms.CheckBox();
            this.AdsorpConstACheckBox = new System.Windows.Forms.CheckBox();
            this.WcOutCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.P_TextBox = new AntdUI.Input();
            this.W_TextBox = new AntdUI.Input();
            this.Wc_TextBox = new AntdUI.Input();
            this.Wa_TextBox = new AntdUI.Input();
            this.W3_TextBox = new AntdUI.Input();
            this.W2_TextBox = new AntdUI.Input();
            this.W1_TextBox = new AntdUI.Input();
            this.tabPage4TemporarySavingButton = new GasFormsApp.UI.UCButton();
            this.tabPage4RecoverDataButton = new GasFormsApp.UI.UCButton();
            this.label95 = new System.Windows.Forms.Label();
            this.ExpCalcButton = new GasFormsApp.UI.UCButton();
            this.label94 = new System.Windows.Forms.Label();
            this.P_CheckBox = new System.Windows.Forms.CheckBox();
            this.label93 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage5DoubleBufferedPanel1 = new GasFormsApp.UI.DoubleBufferedPanel();
            this.tabPage5panel18 = new System.Windows.Forms.Panel();
            this.tabPage5DoubleBufferedFlowLayoutPanel2 = new GasFormsApp.UI.DoubleBufferedFlowLayoutPanel();
            this.tabPage5DoubleBufferedFlowLayoutPanel1 = new GasFormsApp.UI.DoubleBufferedFlowLayoutPanel();
            this.tabPage5panel1 = new System.Windows.Forms.Panel();
            this.CH4CheckBox = new System.Windows.Forms.CheckBox();
            this.CH4TextBox = new AntdUI.Input();
            this.tabPage5panel2 = new System.Windows.Forms.Panel();
            this.CO2CheckBox = new System.Windows.Forms.CheckBox();
            this.CO2TextBox = new AntdUI.Input();
            this.tabPage5panel3 = new System.Windows.Forms.Panel();
            this.N2CheckBox = new System.Windows.Forms.CheckBox();
            this.N2TextBox = new AntdUI.Input();
            this.tabPage5panel4 = new System.Windows.Forms.Panel();
            this.O2CheckBox = new System.Windows.Forms.CheckBox();
            this.O2TextBox = new AntdUI.Input();
            this.tabPage5panel5 = new System.Windows.Forms.Panel();
            this.C2H4CheckBox = new System.Windows.Forms.CheckBox();
            this.C2H4TextBox = new AntdUI.Input();
            this.tabPage5panel6 = new System.Windows.Forms.Panel();
            this.C3H8CheckBox = new System.Windows.Forms.CheckBox();
            this.C3H8TextBox = new AntdUI.Input();
            this.tabPage5panel7 = new System.Windows.Forms.Panel();
            this.C2H6CheckBox = new System.Windows.Forms.CheckBox();
            this.C2H6TextBox = new AntdUI.Input();
            this.tabPage5panel8 = new System.Windows.Forms.Panel();
            this.C3H6CheckBox = new System.Windows.Forms.CheckBox();
            this.C3H6TextBox = new AntdUI.Input();
            this.tabPage5panel9 = new System.Windows.Forms.Panel();
            this.C2H2CheckBox = new System.Windows.Forms.CheckBox();
            this.C2H2TextBox = new AntdUI.Input();
            this.tabPage5panel10 = new System.Windows.Forms.Panel();
            this.COCheckBox = new System.Windows.Forms.CheckBox();
            this.COTextBox = new AntdUI.Input();
            this.tabPage5panel11 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new AntdUI.DatePicker();
            this.label119 = new System.Windows.Forms.Label();
            this.tabPage5panel12 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker6 = new AntdUI.DatePicker();
            this.tabPage5panel14 = new System.Windows.Forms.Panel();
            this.LabTestersTextBox = new AntdUI.Input();
            this.label117 = new System.Windows.Forms.Label();
            this.tabPage5panel13 = new System.Windows.Forms.Panel();
            this.DownholeTestersTextBox = new AntdUI.Input();
            this.DownholeTestersCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage5panel16 = new System.Windows.Forms.Panel();
            this.RemarkTextBox = new AntdUI.Input();
            this.label120 = new System.Windows.Forms.Label();
            this.tabPage5panel15 = new System.Windows.Forms.Panel();
            this.AuditorTextBox = new AntdUI.Input();
            this.label118 = new System.Windows.Forms.Label();
            this.tabPage5panel17 = new System.Windows.Forms.Panel();
            this.WPSorOfficeLabel = new System.Windows.Forms.Label();
            this.tabPage5TemporarySavingButton = new GasFormsApp.UI.UCButton();
            this.tabPage5RecoverDataButton = new GasFormsApp.UI.UCButton();
            this.GenReportButton = new GasFormsApp.UI.UCButton();
            this.GenRecordButton = new GasFormsApp.UI.UCButton();
            this.SaveButton = new GasFormsApp.UI.UCButton();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label17 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.FindMineTextBox = new System.Windows.Forms.TextBox();
            this.tabPage6panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label30 = new System.Windows.Forms.Label();
            this.FindTextBox = new System.Windows.Forms.TextBox();
            this.ExportTheDocumentButton = new System.Windows.Forms.Button();
            this.DeleteDataButton = new System.Windows.Forms.Button();
            this.ReloadDataButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.shapeContainer3 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.shapeContainer4 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.InputCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage6contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出矿井Excel统计表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出矿井数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.合并矿井数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除煤矿及项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage6contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.恢复历史记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeColorContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.背景颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.字体颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更换LogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更改标题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabPage2contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导出图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tab6Timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl6PictureBox = new System.Windows.Forms.PictureBox();
            this.tabControl5PictureBox = new System.Windows.Forms.PictureBox();
            this.tabControl4PictureBox = new System.Windows.Forms.PictureBox();
            this.tabControl3PictureBox = new System.Windows.Forms.PictureBox();
            this.tabControl2PictureBox = new System.Windows.Forms.PictureBox();
            this.tabControl1PictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ToolBarMenuStrip = new GasFormsApp.UI.CustomMenuStrip();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.恢复上次编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.账户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新登录密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重置产品认证密钥ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage1panel1.SuspendLayout();
            this.tabPage1DoubleBufferedFlowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage2DoubleBufferedPanel2.SuspendLayout();
            this.tabPage2DoubleBufferedFlowLayoutPanel1.SuspendLayout();
            this.tabPage2DoubleBufferedPanel1.SuspendLayout();
            this.doubleBufferedPanel1.SuspendLayout();
            this.tabPage2panel3.SuspendLayout();
            this.tabPage2panel4.SuspendLayout();
            this.tabPage2panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabPage2panel6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage3panel1.SuspendLayout();
            this.tabPage3panel2.SuspendLayout();
            this.tabPage3panel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage4DoubleBufferedPanel1.SuspendLayout();
            this.tabPage4DoubleBufferedFlowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage5DoubleBufferedPanel1.SuspendLayout();
            this.tabPage5DoubleBufferedFlowLayoutPanel2.SuspendLayout();
            this.tabPage5DoubleBufferedFlowLayoutPanel1.SuspendLayout();
            this.tabPage5panel1.SuspendLayout();
            this.tabPage5panel2.SuspendLayout();
            this.tabPage5panel3.SuspendLayout();
            this.tabPage5panel4.SuspendLayout();
            this.tabPage5panel5.SuspendLayout();
            this.tabPage5panel6.SuspendLayout();
            this.tabPage5panel7.SuspendLayout();
            this.tabPage5panel8.SuspendLayout();
            this.tabPage5panel9.SuspendLayout();
            this.tabPage5panel10.SuspendLayout();
            this.tabPage5panel11.SuspendLayout();
            this.tabPage5panel12.SuspendLayout();
            this.tabPage5panel14.SuspendLayout();
            this.tabPage5panel13.SuspendLayout();
            this.tabPage5panel16.SuspendLayout();
            this.tabPage5panel15.SuspendLayout();
            this.tabPage5panel17.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage6panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage6contextMenuStrip1.SuspendLayout();
            this.tabPage6contextMenuStrip2.SuspendLayout();
            this.ChangeColorContextMenuStrip.SuspendLayout();
            this.tabPage2contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl6PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl5PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl4PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl3PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ToolBarMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(98, 92);
            this.tabControl1.Location = new System.Drawing.Point(0, 73);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(783, 489);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabControl_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Controls.Add(this.tabPage1panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 96);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(775, 389);
            this.tabPage1.TabIndex = 0;
            // 
            // tabPage1panel1
            // 
            this.tabPage1panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage1panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage1panel1.Controls.Add(this.tabPage1panel2);
            this.tabPage1panel1.Controls.Add(this.tabPage1DoubleBufferedFlowLayoutPanel1);
            this.tabPage1panel1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1panel1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1panel1.Name = "tabPage1panel1";
            this.tabPage1panel1.Size = new System.Drawing.Size(776, 390);
            this.tabPage1panel1.TabIndex = 2;
            // 
            // tabPage1panel2
            // 
            this.tabPage1panel2.Back = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage1panel2.Location = new System.Drawing.Point(652, 39);
            this.tabPage1panel2.Name = "tabPage1panel2";
            this.tabPage1panel2.Size = new System.Drawing.Size(47, 251);
            this.tabPage1panel2.TabIndex = 2;
            this.tabPage1panel2.Text = "panel2";
            // 
            // tabPage1DoubleBufferedFlowLayoutPanel1
            // 
            this.tabPage1DoubleBufferedFlowLayoutPanel1.AutoScroll = true;
            this.tabPage1DoubleBufferedFlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label1);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.MineNameTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label6);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.SamplingSpotTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label39);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.X_YTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label7);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.BurialDepthTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label3);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.CoalSeamTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label9);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.UndAtmPressureTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label10);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.UndTempTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label11);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.LabAtmPressureTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label12);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.LabTempTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label14);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.MoistureSampleTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label15);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.SampleModeComboBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label20);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.SampleNumTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label16);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.RawCoalMoistureTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label19);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.InitialVolumeTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label13);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.SampleWeightTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label4);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.SamplingDepthTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label8);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.SamplingTimeDateTimePicker);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label37);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.DrillInclinationTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label38);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.AzimuthTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label41);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.SamplingPersonnelTextBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.label36);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.CoalTypeComboBox);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage1TemporarySavingButton);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage1RecoverDataButton);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Location = new System.Drawing.Point(14, 6);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Name = "tabPage1DoubleBufferedFlowLayoutPanel1";
            this.tabPage1DoubleBufferedFlowLayoutPanel1.Size = new System.Drawing.Size(394, 357);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 14, 0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "矿   井    名   称 :";
            // 
            // MineNameTextBox
            // 
            this.MineNameTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MineNameTextBox.Location = new System.Drawing.Point(180, 3);
            this.MineNameTextBox.Name = "MineNameTextBox";
            this.MineNameTextBox.PlaceholderText = "矿井名称";
            this.MineNameTextBox.Size = new System.Drawing.Size(167, 35);
            this.MineNameTextBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label6.Location = new System.Drawing.Point(10, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 14, 0, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "取   样    地   点 :";
            // 
            // SamplingSpotTextBox
            // 
            this.SamplingSpotTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SamplingSpotTextBox.Location = new System.Drawing.Point(180, 44);
            this.SamplingSpotTextBox.Name = "SamplingSpotTextBox";
            this.SamplingSpotTextBox.PlaceholderText = "取样地点";
            this.SamplingSpotTextBox.Size = new System.Drawing.Size(167, 35);
            this.SamplingSpotTextBox.TabIndex = 2;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label39.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label39.Location = new System.Drawing.Point(10, 96);
            this.label39.Margin = new System.Windows.Forms.Padding(10, 14, 0, 3);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(167, 16);
            this.label39.TabIndex = 1007;
            this.label39.Text = "取 样 地 点 坐 标  :";
            // 
            // X_YTextBox
            // 
            this.X_YTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.X_YTextBox.Location = new System.Drawing.Point(180, 85);
            this.X_YTextBox.Name = "X_YTextBox";
            this.X_YTextBox.PlaceholderText = "取样坐标";
            this.X_YTextBox.SelectionStart = 5;
            this.X_YTextBox.Size = new System.Drawing.Size(167, 35);
            this.X_YTextBox.TabIndex = 3;
            this.X_YTextBox.Text = "X=,Y=";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label7.Location = new System.Drawing.Point(10, 143);
            this.label7.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "埋           深 (m):";
            // 
            // BurialDepthTextBox
            // 
            this.BurialDepthTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BurialDepthTextBox.Location = new System.Drawing.Point(180, 131);
            this.BurialDepthTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.BurialDepthTextBox.Name = "BurialDepthTextBox";
            this.BurialDepthTextBox.PlaceholderText = "埋深";
            this.BurialDepthTextBox.Size = new System.Drawing.Size(167, 35);
            this.BurialDepthTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label3.Location = new System.Drawing.Point(10, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "煤               层:";
            // 
            // CoalSeamTextBox
            // 
            this.CoalSeamTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CoalSeamTextBox.Location = new System.Drawing.Point(180, 177);
            this.CoalSeamTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.CoalSeamTextBox.Name = "CoalSeamTextBox";
            this.CoalSeamTextBox.PlaceholderText = "煤层";
            this.CoalSeamTextBox.Size = new System.Drawing.Size(167, 35);
            this.CoalSeamTextBox.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label9.Location = new System.Drawing.Point(10, 235);
            this.label9.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "井下大气压力 (KPa) :";
            // 
            // UndAtmPressureTextBox
            // 
            this.UndAtmPressureTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UndAtmPressureTextBox.Location = new System.Drawing.Point(180, 223);
            this.UndAtmPressureTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.UndAtmPressureTextBox.Name = "UndAtmPressureTextBox";
            this.UndAtmPressureTextBox.PlaceholderText = "井下大气压力";
            this.UndAtmPressureTextBox.Size = new System.Drawing.Size(167, 35);
            this.UndAtmPressureTextBox.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label10.Location = new System.Drawing.Point(10, 281);
            this.label10.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "井下环境温度 (℃ ) :";
            // 
            // UndTempTextBox
            // 
            this.UndTempTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UndTempTextBox.Location = new System.Drawing.Point(180, 269);
            this.UndTempTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.UndTempTextBox.Name = "UndTempTextBox";
            this.UndTempTextBox.PlaceholderText = "井下温度";
            this.UndTempTextBox.Size = new System.Drawing.Size(167, 35);
            this.UndTempTextBox.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label11.Location = new System.Drawing.Point(10, 327);
            this.label11.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "实验室大气压力(KPa):";
            // 
            // LabAtmPressureTextBox
            // 
            this.LabAtmPressureTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabAtmPressureTextBox.Location = new System.Drawing.Point(180, 315);
            this.LabAtmPressureTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.LabAtmPressureTextBox.Name = "LabAtmPressureTextBox";
            this.LabAtmPressureTextBox.PlaceholderText = "实验室大气压力";
            this.LabAtmPressureTextBox.Size = new System.Drawing.Size(167, 35);
            this.LabAtmPressureTextBox.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label12.Location = new System.Drawing.Point(10, 373);
            this.label12.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(167, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "实 验 室 温 度 (℃):";
            // 
            // LabTempTextBox
            // 
            this.LabTempTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabTempTextBox.Location = new System.Drawing.Point(180, 361);
            this.LabTempTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.LabTempTextBox.Name = "LabTempTextBox";
            this.LabTempTextBox.PlaceholderText = "实验室温度";
            this.LabTempTextBox.Size = new System.Drawing.Size(167, 35);
            this.LabTempTextBox.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label14.Location = new System.Drawing.Point(10, 419);
            this.label14.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(167, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "煤  样  水  分 (%) :";
            // 
            // MoistureSampleTextBox
            // 
            this.MoistureSampleTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MoistureSampleTextBox.Location = new System.Drawing.Point(180, 407);
            this.MoistureSampleTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.MoistureSampleTextBox.Name = "MoistureSampleTextBox";
            this.MoistureSampleTextBox.PlaceholderText = "煤样水分";
            this.MoistureSampleTextBox.Size = new System.Drawing.Size(167, 35);
            this.MoistureSampleTextBox.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label15.Location = new System.Drawing.Point(10, 465);
            this.label15.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(167, 16);
            this.label15.TabIndex = 2;
            this.label15.Text = "取    样    方   式:";
            // 
            // SampleModeComboBox
            // 
            this.SampleModeComboBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SampleModeComboBox.Items.AddRange(new object[] {
            "定点风排渣",
            "风排渣",
            "水排渣",
            "取芯钻杆"});
            this.SampleModeComboBox.Location = new System.Drawing.Point(180, 453);
            this.SampleModeComboBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.SampleModeComboBox.Name = "SampleModeComboBox";
            this.SampleModeComboBox.SelectionStart = 5;
            this.SampleModeComboBox.Size = new System.Drawing.Size(167, 35);
            this.SampleModeComboBox.TabIndex = 11;
            this.SampleModeComboBox.Text = "定点风排渣";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label20.Location = new System.Drawing.Point(10, 511);
            this.label20.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(167, 16);
            this.label20.TabIndex = 20;
            this.label20.Text = "煤   样    编   号 :";
            // 
            // SampleNumTextBox
            // 
            this.SampleNumTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SampleNumTextBox.Location = new System.Drawing.Point(180, 499);
            this.SampleNumTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.SampleNumTextBox.Name = "SampleNumTextBox";
            this.SampleNumTextBox.PlaceholderText = "煤样编号";
            this.SampleNumTextBox.Size = new System.Drawing.Size(167, 35);
            this.SampleNumTextBox.TabIndex = 12;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label16.Location = new System.Drawing.Point(10, 557);
            this.label16.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(167, 16);
            this.label16.TabIndex = 2;
            this.label16.Text = "原   煤   水  分(%):";
            // 
            // RawCoalMoistureTextBox
            // 
            this.RawCoalMoistureTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RawCoalMoistureTextBox.Location = new System.Drawing.Point(180, 545);
            this.RawCoalMoistureTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.RawCoalMoistureTextBox.Name = "RawCoalMoistureTextBox";
            this.RawCoalMoistureTextBox.PlaceholderText = "原煤水分";
            this.RawCoalMoistureTextBox.Size = new System.Drawing.Size(167, 35);
            this.RawCoalMoistureTextBox.TabIndex = 13;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label19.Location = new System.Drawing.Point(10, 603);
            this.label19.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(167, 16);
            this.label19.TabIndex = 4;
            this.label19.Text = "量管初始体积  (ml) :";
            // 
            // InitialVolumeTextBox
            // 
            this.InitialVolumeTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InitialVolumeTextBox.Location = new System.Drawing.Point(180, 591);
            this.InitialVolumeTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.InitialVolumeTextBox.Name = "InitialVolumeTextBox";
            this.InitialVolumeTextBox.PlaceholderText = "量管初始体积";
            this.InitialVolumeTextBox.SelectionStart = 1;
            this.InitialVolumeTextBox.Size = new System.Drawing.Size(167, 35);
            this.InitialVolumeTextBox.TabIndex = 14;
            this.InitialVolumeTextBox.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label13.Location = new System.Drawing.Point(10, 649);
            this.label13.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(167, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "样  品  重  量  (g):";
            // 
            // SampleWeightTextBox
            // 
            this.SampleWeightTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SampleWeightTextBox.Location = new System.Drawing.Point(180, 637);
            this.SampleWeightTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.SampleWeightTextBox.Name = "SampleWeightTextBox";
            this.SampleWeightTextBox.PlaceholderText = "样品重量";
            this.SampleWeightTextBox.Size = new System.Drawing.Size(167, 35);
            this.SampleWeightTextBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label4.Location = new System.Drawing.Point(10, 695);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "取  样  深  度 (m) :";
            // 
            // SamplingDepthTextBox
            // 
            this.SamplingDepthTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SamplingDepthTextBox.Location = new System.Drawing.Point(180, 683);
            this.SamplingDepthTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.SamplingDepthTextBox.Name = "SamplingDepthTextBox";
            this.SamplingDepthTextBox.PlaceholderText = "取样深度";
            this.SamplingDepthTextBox.Size = new System.Drawing.Size(167, 35);
            this.SamplingDepthTextBox.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label8.Location = new System.Drawing.Point(10, 741);
            this.label8.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "取   样    时   间 :";
            // 
            // SamplingTimeDateTimePicker
            // 
            this.SamplingTimeDateTimePicker.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SamplingTimeDateTimePicker.Format = "yyyy年 MM月dd日";
            this.SamplingTimeDateTimePicker.Location = new System.Drawing.Point(180, 729);
            this.SamplingTimeDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.SamplingTimeDateTimePicker.Name = "SamplingTimeDateTimePicker";
            this.SamplingTimeDateTimePicker.Placement = AntdUI.TAlignFrom.Top;
            this.SamplingTimeDateTimePicker.Size = new System.Drawing.Size(167, 35);
            this.SamplingTimeDateTimePicker.TabIndex = 17;
            this.SamplingTimeDateTimePicker.ValueTimeHorizontal = true;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label37.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label37.Location = new System.Drawing.Point(10, 787);
            this.label37.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(167, 16);
            this.label37.TabIndex = 34;
            this.label37.Text = "钻  孔  倾  角 (°):";
            // 
            // DrillInclinationTextBox
            // 
            this.DrillInclinationTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DrillInclinationTextBox.Location = new System.Drawing.Point(180, 775);
            this.DrillInclinationTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.DrillInclinationTextBox.Name = "DrillInclinationTextBox";
            this.DrillInclinationTextBox.PlaceholderText = "钻孔倾角";
            this.DrillInclinationTextBox.Size = new System.Drawing.Size(167, 35);
            this.DrillInclinationTextBox.TabIndex = 18;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label38.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label38.Location = new System.Drawing.Point(10, 833);
            this.label38.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(167, 16);
            this.label38.TabIndex = 36;
            this.label38.Text = "方    位    角 (°):";
            // 
            // AzimuthTextBox
            // 
            this.AzimuthTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AzimuthTextBox.Location = new System.Drawing.Point(180, 821);
            this.AzimuthTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.AzimuthTextBox.Name = "AzimuthTextBox";
            this.AzimuthTextBox.PlaceholderText = "方位角";
            this.AzimuthTextBox.Size = new System.Drawing.Size(167, 35);
            this.AzimuthTextBox.TabIndex = 19;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label41.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label41.Location = new System.Drawing.Point(10, 879);
            this.label41.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(167, 16);
            this.label41.TabIndex = 38;
            this.label41.Text = "取   样    人   员 :";
            // 
            // SamplingPersonnelTextBox
            // 
            this.SamplingPersonnelTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SamplingPersonnelTextBox.Location = new System.Drawing.Point(180, 867);
            this.SamplingPersonnelTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.SamplingPersonnelTextBox.Name = "SamplingPersonnelTextBox";
            this.SamplingPersonnelTextBox.PlaceholderText = "取样人员";
            this.SamplingPersonnelTextBox.Size = new System.Drawing.Size(167, 35);
            this.SamplingPersonnelTextBox.TabIndex = 20;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label36.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label36.Location = new System.Drawing.Point(10, 925);
            this.label36.Margin = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(167, 16);
            this.label36.TabIndex = 1005;
            this.label36.Text = "     煤     种     :";
            // 
            // CoalTypeComboBox
            // 
            this.CoalTypeComboBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CoalTypeComboBox.Items.AddRange(new object[] {
            "烟煤",
            "无烟煤",
            "褐煤"});
            this.CoalTypeComboBox.Location = new System.Drawing.Point(180, 913);
            this.CoalTypeComboBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.CoalTypeComboBox.Name = "CoalTypeComboBox";
            this.CoalTypeComboBox.SelectionStart = 2;
            this.CoalTypeComboBox.Size = new System.Drawing.Size(167, 35);
            this.CoalTypeComboBox.TabIndex = 21;
            this.CoalTypeComboBox.Text = "烟煤";
            // 
            // tabPage1TemporarySavingButton
            // 
            this.tabPage1TemporarySavingButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tabPage1TemporarySavingButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1TemporarySavingButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("tabPage1TemporarySavingButton.ButtonImage")));
            this.tabPage1TemporarySavingButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.tabPage1TemporarySavingButton.FlatAppearance.BorderSize = 0;
            this.tabPage1TemporarySavingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabPage1TemporarySavingButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1TemporarySavingButton.HoverColor = System.Drawing.Color.LightBlue;
            this.tabPage1TemporarySavingButton.Location = new System.Drawing.Point(40, 954);
            this.tabPage1TemporarySavingButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.tabPage1TemporarySavingButton.Name = "tabPage1TemporarySavingButton";
            this.tabPage1TemporarySavingButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage1TemporarySavingButton.Radius = 15;
            this.tabPage1TemporarySavingButton.Size = new System.Drawing.Size(116, 42);
            this.tabPage1TemporarySavingButton.TabIndex = 1003;
            this.tabPage1TemporarySavingButton.Text = "     临时保存";
            this.tabPage1TemporarySavingButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabPage1TemporarySavingButton.UseVisualStyleBackColor = false;
            // 
            // tabPage1RecoverDataButton
            // 
            this.tabPage1RecoverDataButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tabPage1RecoverDataButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1RecoverDataButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("tabPage1RecoverDataButton.ButtonImage")));
            this.tabPage1RecoverDataButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.tabPage1RecoverDataButton.FlatAppearance.BorderSize = 0;
            this.tabPage1RecoverDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabPage1RecoverDataButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1RecoverDataButton.HoverColor = System.Drawing.Color.LightBlue;
            this.tabPage1RecoverDataButton.Location = new System.Drawing.Point(199, 954);
            this.tabPage1RecoverDataButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.tabPage1RecoverDataButton.Name = "tabPage1RecoverDataButton";
            this.tabPage1RecoverDataButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage1RecoverDataButton.Radius = 15;
            this.tabPage1RecoverDataButton.Size = new System.Drawing.Size(116, 42);
            this.tabPage1RecoverDataButton.TabIndex = 1004;
            this.tabPage1RecoverDataButton.Text = "     恢复数据";
            this.tabPage1RecoverDataButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabPage1RecoverDataButton.UseVisualStyleBackColor = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2.Controls.Add(this.tabPage2DoubleBufferedPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 96);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(775, 389);
            this.tabPage2.TabIndex = 1;
            // 
            // tabPage2DoubleBufferedPanel2
            // 
            this.tabPage2DoubleBufferedPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage2DoubleBufferedPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage2DoubleBufferedPanel2.Controls.Add(this.tabPage2panel2);
            this.tabPage2DoubleBufferedPanel2.Controls.Add(this.tabPage2panel1);
            this.tabPage2DoubleBufferedPanel2.Controls.Add(this.tabPage2DoubleBufferedFlowLayoutPanel1);
            this.tabPage2DoubleBufferedPanel2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2DoubleBufferedPanel2.Name = "tabPage2DoubleBufferedPanel2";
            this.tabPage2DoubleBufferedPanel2.Size = new System.Drawing.Size(776, 390);
            this.tabPage2DoubleBufferedPanel2.TabIndex = 1002;
            // 
            // tabPage2panel2
            // 
            this.tabPage2panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage2panel2.Location = new System.Drawing.Point(1239, 250);
            this.tabPage2panel2.Name = "tabPage2panel2";
            this.tabPage2panel2.Size = new System.Drawing.Size(77, 100);
            this.tabPage2panel2.TabIndex = 1;
            // 
            // tabPage2panel1
            // 
            this.tabPage2panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage2panel1.Location = new System.Drawing.Point(641, 80);
            this.tabPage2panel1.Name = "tabPage2panel1";
            this.tabPage2panel1.Size = new System.Drawing.Size(77, 100);
            this.tabPage2panel1.TabIndex = 0;
            // 
            // tabPage2DoubleBufferedFlowLayoutPanel1
            // 
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage2DoubleBufferedFlowLayoutPanel1.AutoScroll = true;
            this.tabPage2DoubleBufferedFlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage2panel7);
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage2DoubleBufferedPanel1);
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Controls.Add(this.doubleBufferedPanel1);
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage2panel8);
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage2panel3);
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage2panel4);
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage2panel9);
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage2panel5);
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage2panel10);
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage2panel6);
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Location = new System.Drawing.Point(57, 32);
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Name = "tabPage2DoubleBufferedFlowLayoutPanel1";
            this.tabPage2DoubleBufferedFlowLayoutPanel1.Size = new System.Drawing.Size(507, 316);
            this.tabPage2DoubleBufferedFlowLayoutPanel1.TabIndex = 1002;
            // 
            // tabPage2panel7
            // 
            this.tabPage2panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage2panel7.Location = new System.Drawing.Point(0, 3);
            this.tabPage2panel7.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tabPage2panel7.Name = "tabPage2panel7";
            this.tabPage2panel7.Size = new System.Drawing.Size(1, 103);
            this.tabPage2panel7.TabIndex = 1003;
            // 
            // tabPage2DoubleBufferedPanel1
            // 
            this.tabPage2DoubleBufferedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage2DoubleBufferedPanel1.Controls.Add(this.TypeOfDestructionComboBox3);
            this.tabPage2DoubleBufferedPanel1.Controls.Add(this.dateTimePicker3);
            this.tabPage2DoubleBufferedPanel1.Controls.Add(this.dateTimePicker2);
            this.tabPage2DoubleBufferedPanel1.Controls.Add(this.label35);
            this.tabPage2DoubleBufferedPanel1.Controls.Add(this.label33);
            this.tabPage2DoubleBufferedPanel1.Controls.Add(this.label31);
            this.tabPage2DoubleBufferedPanel1.Location = new System.Drawing.Point(4, 3);
            this.tabPage2DoubleBufferedPanel1.Name = "tabPage2DoubleBufferedPanel1";
            this.tabPage2DoubleBufferedPanel1.Size = new System.Drawing.Size(403, 103);
            this.tabPage2DoubleBufferedPanel1.TabIndex = 1002;
            // 
            // TypeOfDestructionComboBox3
            // 
            this.TypeOfDestructionComboBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TypeOfDestructionComboBox3.Items.AddRange(new object[] {
            "Ⅰ 类",
            "Ⅱ 类",
            "Ⅲ 类",
            "Ⅳ 类",
            "Ⅴ 类"});
            this.TypeOfDestructionComboBox3.Location = new System.Drawing.Point(140, 68);
            this.TypeOfDestructionComboBox3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.TypeOfDestructionComboBox3.Name = "TypeOfDestructionComboBox3";
            this.TypeOfDestructionComboBox3.SelectionStart = 3;
            this.TypeOfDestructionComboBox3.Size = new System.Drawing.Size(230, 35);
            this.TypeOfDestructionComboBox3.TabIndex = 5;
            this.TypeOfDestructionComboBox3.Text = "Ⅰ 类";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker3.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker3.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(141, 38);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(230, 29);
            this.dateTimePicker3.TabIndex = 3;
            this.dateTimePicker3.TabStop = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(140, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(230, 29);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.TabStop = false;
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.label35.Location = new System.Drawing.Point(32, 9);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(111, 16);
            this.label35.TabIndex = 44;
            this.label35.Text = "打钻开始时间:";
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.label33.Location = new System.Drawing.Point(32, 45);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(111, 16);
            this.label33.TabIndex = 50;
            this.label33.Text = "取芯结束时间:";
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.label31.Location = new System.Drawing.Point(32, 79);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(111, 16);
            this.label31.TabIndex = 52;
            this.label31.Text = "煤的破坏类型:";
            // 
            // doubleBufferedPanel1
            // 
            this.doubleBufferedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.doubleBufferedPanel1.Controls.Add(this.t0TextBox);
            this.doubleBufferedPanel1.Controls.Add(this.dateTimePicker5);
            this.doubleBufferedPanel1.Controls.Add(this.dateTimePicker4);
            this.doubleBufferedPanel1.Controls.Add(this.label34);
            this.doubleBufferedPanel1.Controls.Add(this.label90);
            this.doubleBufferedPanel1.Controls.Add(this.label32);
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(3, 112);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(403, 103);
            this.doubleBufferedPanel1.TabIndex = 1003;
            // 
            // t0TextBox
            // 
            this.t0TextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.t0TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t0TextBox.Location = new System.Drawing.Point(141, 68);
            this.t0TextBox.Name = "t0TextBox";
            this.t0TextBox.PlaceholderText = "";
            this.t0TextBox.ReadOnly = true;
            this.t0TextBox.SelectionStart = 4;
            this.t0TextBox.Size = new System.Drawing.Size(230, 35);
            this.t0TextBox.TabIndex = 6;
            this.t0TextBox.TabStop = false;
            this.t0TextBox.Text = "0.00";
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker5.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker5.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker5.Location = new System.Drawing.Point(141, 3);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.Size = new System.Drawing.Size(230, 29);
            this.dateTimePicker5.TabIndex = 2;
            this.dateTimePicker5.TabStop = false;
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker4.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker4.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Location = new System.Drawing.Point(141, 38);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(230, 29);
            this.dateTimePicker4.TabIndex = 4;
            this.dateTimePicker4.TabStop = false;
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.label34.Location = new System.Drawing.Point(32, 9);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(111, 16);
            this.label34.TabIndex = 49;
            this.label34.Text = "取芯开始时间:";
            // 
            // label90
            // 
            this.label90.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label90.AutoSize = true;
            this.label90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label90.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label90.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.label90.Location = new System.Drawing.Point(72, 78);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(71, 16);
            this.label90.TabIndex = 109;
            this.label90.Text = "t0(min):";
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.label32.Location = new System.Drawing.Point(32, 44);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(111, 16);
            this.label32.TabIndex = 51;
            this.label32.Text = "解吸开始时间:";
            // 
            // tabPage2panel8
            // 
            this.tabPage2panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage2panel8.Location = new System.Drawing.Point(409, 112);
            this.tabPage2panel8.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tabPage2panel8.Name = "tabPage2panel8";
            this.tabPage2panel8.Size = new System.Drawing.Size(1, 103);
            this.tabPage2panel8.TabIndex = 1004;
            // 
            // tabPage2panel3
            // 
            this.tabPage2panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox30);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox29);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox28);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox27);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox26);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox25);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox24);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox23);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox22);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox21);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox20);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox19);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox18);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox17);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox16);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox15);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox14);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox13);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox12);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox11);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox10);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox9);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox8);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox7);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox6);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox5);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox4);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox3);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox2);
            this.tabPage2panel3.Controls.Add(this.DesorbTextBox1);
            this.tabPage2panel3.Controls.Add(this.label24);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel26);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel16);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel6);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel7);
            this.tabPage2panel3.Controls.Add(this.label26);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel17);
            this.tabPage2panel3.Controls.Add(this.label25);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel25);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel27);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel15);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel5);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel8);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel18);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel24);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel28);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel14);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel4);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel9);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel19);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel23);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel29);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel13);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel3);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel10);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel20);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel22);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel12);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel30);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel2);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel21);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel11);
            this.tabPage2panel3.Controls.Add(this.DataNumLabel1);
            this.tabPage2panel3.Location = new System.Drawing.Point(3, 221);
            this.tabPage2panel3.Name = "tabPage2panel3";
            this.tabPage2panel3.Size = new System.Drawing.Size(403, 346);
            this.tabPage2panel3.TabIndex = 1;
            // 
            // DesorbTextBox30
            // 
            this.DesorbTextBox30.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox30.Location = new System.Drawing.Point(317, 309);
            this.DesorbTextBox30.Name = "DesorbTextBox30";
            this.DesorbTextBox30.PlaceholderText = "";
            this.DesorbTextBox30.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox30.TabIndex = 36;
            // 
            // DesorbTextBox29
            // 
            this.DesorbTextBox29.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox29.Location = new System.Drawing.Point(317, 277);
            this.DesorbTextBox29.Name = "DesorbTextBox29";
            this.DesorbTextBox29.PlaceholderText = "";
            this.DesorbTextBox29.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox29.TabIndex = 35;
            // 
            // DesorbTextBox28
            // 
            this.DesorbTextBox28.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox28.Location = new System.Drawing.Point(317, 245);
            this.DesorbTextBox28.Name = "DesorbTextBox28";
            this.DesorbTextBox28.PlaceholderText = "";
            this.DesorbTextBox28.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox28.TabIndex = 34;
            // 
            // DesorbTextBox27
            // 
            this.DesorbTextBox27.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox27.Location = new System.Drawing.Point(317, 213);
            this.DesorbTextBox27.Name = "DesorbTextBox27";
            this.DesorbTextBox27.PlaceholderText = "";
            this.DesorbTextBox27.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox27.TabIndex = 33;
            // 
            // DesorbTextBox26
            // 
            this.DesorbTextBox26.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox26.Location = new System.Drawing.Point(317, 181);
            this.DesorbTextBox26.Name = "DesorbTextBox26";
            this.DesorbTextBox26.PlaceholderText = "";
            this.DesorbTextBox26.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox26.TabIndex = 32;
            // 
            // DesorbTextBox25
            // 
            this.DesorbTextBox25.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox25.Location = new System.Drawing.Point(317, 149);
            this.DesorbTextBox25.Name = "DesorbTextBox25";
            this.DesorbTextBox25.PlaceholderText = "";
            this.DesorbTextBox25.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox25.TabIndex = 31;
            // 
            // DesorbTextBox24
            // 
            this.DesorbTextBox24.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox24.Location = new System.Drawing.Point(317, 117);
            this.DesorbTextBox24.Name = "DesorbTextBox24";
            this.DesorbTextBox24.PlaceholderText = "";
            this.DesorbTextBox24.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox24.TabIndex = 30;
            // 
            // DesorbTextBox23
            // 
            this.DesorbTextBox23.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox23.Location = new System.Drawing.Point(317, 85);
            this.DesorbTextBox23.Name = "DesorbTextBox23";
            this.DesorbTextBox23.PlaceholderText = "";
            this.DesorbTextBox23.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox23.TabIndex = 29;
            // 
            // DesorbTextBox22
            // 
            this.DesorbTextBox22.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox22.Location = new System.Drawing.Point(317, 53);
            this.DesorbTextBox22.Name = "DesorbTextBox22";
            this.DesorbTextBox22.PlaceholderText = "";
            this.DesorbTextBox22.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox22.TabIndex = 28;
            // 
            // DesorbTextBox21
            // 
            this.DesorbTextBox21.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox21.Location = new System.Drawing.Point(317, 21);
            this.DesorbTextBox21.Name = "DesorbTextBox21";
            this.DesorbTextBox21.PlaceholderText = "";
            this.DesorbTextBox21.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox21.TabIndex = 27;
            // 
            // DesorbTextBox20
            // 
            this.DesorbTextBox20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox20.Location = new System.Drawing.Point(183, 309);
            this.DesorbTextBox20.Name = "DesorbTextBox20";
            this.DesorbTextBox20.PlaceholderText = "";
            this.DesorbTextBox20.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox20.TabIndex = 26;
            // 
            // DesorbTextBox19
            // 
            this.DesorbTextBox19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox19.Location = new System.Drawing.Point(183, 277);
            this.DesorbTextBox19.Name = "DesorbTextBox19";
            this.DesorbTextBox19.PlaceholderText = "";
            this.DesorbTextBox19.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox19.TabIndex = 25;
            // 
            // DesorbTextBox18
            // 
            this.DesorbTextBox18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox18.Location = new System.Drawing.Point(183, 245);
            this.DesorbTextBox18.Name = "DesorbTextBox18";
            this.DesorbTextBox18.PlaceholderText = "";
            this.DesorbTextBox18.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox18.TabIndex = 24;
            // 
            // DesorbTextBox17
            // 
            this.DesorbTextBox17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox17.Location = new System.Drawing.Point(183, 213);
            this.DesorbTextBox17.Name = "DesorbTextBox17";
            this.DesorbTextBox17.PlaceholderText = "";
            this.DesorbTextBox17.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox17.TabIndex = 23;
            // 
            // DesorbTextBox16
            // 
            this.DesorbTextBox16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox16.Location = new System.Drawing.Point(183, 181);
            this.DesorbTextBox16.Name = "DesorbTextBox16";
            this.DesorbTextBox16.PlaceholderText = "";
            this.DesorbTextBox16.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox16.TabIndex = 22;
            // 
            // DesorbTextBox15
            // 
            this.DesorbTextBox15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox15.Location = new System.Drawing.Point(183, 149);
            this.DesorbTextBox15.Name = "DesorbTextBox15";
            this.DesorbTextBox15.PlaceholderText = "";
            this.DesorbTextBox15.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox15.TabIndex = 21;
            // 
            // DesorbTextBox14
            // 
            this.DesorbTextBox14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox14.Location = new System.Drawing.Point(183, 117);
            this.DesorbTextBox14.Name = "DesorbTextBox14";
            this.DesorbTextBox14.PlaceholderText = "";
            this.DesorbTextBox14.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox14.TabIndex = 20;
            // 
            // DesorbTextBox13
            // 
            this.DesorbTextBox13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox13.Location = new System.Drawing.Point(183, 85);
            this.DesorbTextBox13.Name = "DesorbTextBox13";
            this.DesorbTextBox13.PlaceholderText = "";
            this.DesorbTextBox13.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox13.TabIndex = 19;
            // 
            // DesorbTextBox12
            // 
            this.DesorbTextBox12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox12.Location = new System.Drawing.Point(183, 53);
            this.DesorbTextBox12.Name = "DesorbTextBox12";
            this.DesorbTextBox12.PlaceholderText = "";
            this.DesorbTextBox12.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox12.TabIndex = 18;
            // 
            // DesorbTextBox11
            // 
            this.DesorbTextBox11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox11.Location = new System.Drawing.Point(183, 21);
            this.DesorbTextBox11.Name = "DesorbTextBox11";
            this.DesorbTextBox11.PlaceholderText = "";
            this.DesorbTextBox11.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox11.TabIndex = 17;
            // 
            // DesorbTextBox10
            // 
            this.DesorbTextBox10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox10.Location = new System.Drawing.Point(44, 309);
            this.DesorbTextBox10.Name = "DesorbTextBox10";
            this.DesorbTextBox10.PlaceholderText = "";
            this.DesorbTextBox10.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox10.TabIndex = 16;
            // 
            // DesorbTextBox9
            // 
            this.DesorbTextBox9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox9.Location = new System.Drawing.Point(44, 277);
            this.DesorbTextBox9.Name = "DesorbTextBox9";
            this.DesorbTextBox9.PlaceholderText = "";
            this.DesorbTextBox9.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox9.TabIndex = 15;
            // 
            // DesorbTextBox8
            // 
            this.DesorbTextBox8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox8.Location = new System.Drawing.Point(44, 245);
            this.DesorbTextBox8.Name = "DesorbTextBox8";
            this.DesorbTextBox8.PlaceholderText = "";
            this.DesorbTextBox8.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox8.TabIndex = 14;
            // 
            // DesorbTextBox7
            // 
            this.DesorbTextBox7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox7.Location = new System.Drawing.Point(44, 213);
            this.DesorbTextBox7.Name = "DesorbTextBox7";
            this.DesorbTextBox7.PlaceholderText = "";
            this.DesorbTextBox7.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox7.TabIndex = 13;
            // 
            // DesorbTextBox6
            // 
            this.DesorbTextBox6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox6.Location = new System.Drawing.Point(44, 181);
            this.DesorbTextBox6.Name = "DesorbTextBox6";
            this.DesorbTextBox6.PlaceholderText = "";
            this.DesorbTextBox6.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox6.TabIndex = 12;
            // 
            // DesorbTextBox5
            // 
            this.DesorbTextBox5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox5.Location = new System.Drawing.Point(44, 149);
            this.DesorbTextBox5.Name = "DesorbTextBox5";
            this.DesorbTextBox5.PlaceholderText = "";
            this.DesorbTextBox5.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox5.TabIndex = 11;
            // 
            // DesorbTextBox4
            // 
            this.DesorbTextBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox4.Location = new System.Drawing.Point(44, 117);
            this.DesorbTextBox4.Name = "DesorbTextBox4";
            this.DesorbTextBox4.PlaceholderText = "";
            this.DesorbTextBox4.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox4.TabIndex = 10;
            // 
            // DesorbTextBox3
            // 
            this.DesorbTextBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox3.Location = new System.Drawing.Point(44, 85);
            this.DesorbTextBox3.Name = "DesorbTextBox3";
            this.DesorbTextBox3.PlaceholderText = "";
            this.DesorbTextBox3.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox3.TabIndex = 9;
            // 
            // DesorbTextBox2
            // 
            this.DesorbTextBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox2.Location = new System.Drawing.Point(44, 53);
            this.DesorbTextBox2.Name = "DesorbTextBox2";
            this.DesorbTextBox2.PlaceholderText = "";
            this.DesorbTextBox2.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox2.TabIndex = 8;
            // 
            // DesorbTextBox1
            // 
            this.DesorbTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox1.Location = new System.Drawing.Point(44, 21);
            this.DesorbTextBox1.Name = "DesorbTextBox1";
            this.DesorbTextBox1.PlaceholderText = "";
            this.DesorbTextBox1.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox1.TabIndex = 7;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label24.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(234)))), ((int)(((byte)(251)))));
            this.label24.Location = new System.Drawing.Point(3, 3);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(119, 16);
            this.label24.TabIndex = 143;
            this.label24.Text = "时间   解吸量 ";
            // 
            // DataNumLabel26
            // 
            this.DataNumLabel26.AutoSize = true;
            this.DataNumLabel26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel26.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel26.Location = new System.Drawing.Point(289, 188);
            this.DataNumLabel26.Name = "DataNumLabel26";
            this.DataNumLabel26.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel26.TabIndex = 3;
            this.DataNumLabel26.Text = "26";
            // 
            // DataNumLabel16
            // 
            this.DataNumLabel16.AutoSize = true;
            this.DataNumLabel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel16.Location = new System.Drawing.Point(155, 188);
            this.DataNumLabel16.Name = "DataNumLabel16";
            this.DataNumLabel16.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel16.TabIndex = 3;
            this.DataNumLabel16.Text = "16";
            // 
            // DataNumLabel6
            // 
            this.DataNumLabel6.AutoSize = true;
            this.DataNumLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel6.Location = new System.Drawing.Point(24, 188);
            this.DataNumLabel6.Name = "DataNumLabel6";
            this.DataNumLabel6.Size = new System.Drawing.Size(15, 16);
            this.DataNumLabel6.TabIndex = 3;
            this.DataNumLabel6.Text = "6";
            // 
            // DataNumLabel7
            // 
            this.DataNumLabel7.AutoSize = true;
            this.DataNumLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel7.Location = new System.Drawing.Point(24, 220);
            this.DataNumLabel7.Name = "DataNumLabel7";
            this.DataNumLabel7.Size = new System.Drawing.Size(15, 16);
            this.DataNumLabel7.TabIndex = 3;
            this.DataNumLabel7.Text = "7";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label26.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(234)))), ((int)(((byte)(251)))));
            this.label26.Location = new System.Drawing.Point(278, 3);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(119, 16);
            this.label26.TabIndex = 145;
            this.label26.Text = "时间   解吸量 ";
            // 
            // DataNumLabel17
            // 
            this.DataNumLabel17.AutoSize = true;
            this.DataNumLabel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel17.Location = new System.Drawing.Point(155, 220);
            this.DataNumLabel17.Name = "DataNumLabel17";
            this.DataNumLabel17.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel17.TabIndex = 3;
            this.DataNumLabel17.Text = "17";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label25.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(234)))), ((int)(((byte)(251)))));
            this.label25.Location = new System.Drawing.Point(142, 3);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(119, 16);
            this.label25.TabIndex = 144;
            this.label25.Text = "时间   解吸量 ";
            // 
            // DataNumLabel25
            // 
            this.DataNumLabel25.AutoSize = true;
            this.DataNumLabel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel25.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel25.Location = new System.Drawing.Point(289, 156);
            this.DataNumLabel25.Name = "DataNumLabel25";
            this.DataNumLabel25.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel25.TabIndex = 3;
            this.DataNumLabel25.Text = "25";
            // 
            // DataNumLabel27
            // 
            this.DataNumLabel27.AutoSize = true;
            this.DataNumLabel27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel27.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel27.Location = new System.Drawing.Point(289, 220);
            this.DataNumLabel27.Name = "DataNumLabel27";
            this.DataNumLabel27.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel27.TabIndex = 3;
            this.DataNumLabel27.Text = "27";
            // 
            // DataNumLabel15
            // 
            this.DataNumLabel15.AutoSize = true;
            this.DataNumLabel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel15.Location = new System.Drawing.Point(155, 156);
            this.DataNumLabel15.Name = "DataNumLabel15";
            this.DataNumLabel15.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel15.TabIndex = 3;
            this.DataNumLabel15.Text = "15";
            // 
            // DataNumLabel5
            // 
            this.DataNumLabel5.AutoSize = true;
            this.DataNumLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel5.Location = new System.Drawing.Point(24, 156);
            this.DataNumLabel5.Name = "DataNumLabel5";
            this.DataNumLabel5.Size = new System.Drawing.Size(15, 16);
            this.DataNumLabel5.TabIndex = 3;
            this.DataNumLabel5.Text = "5";
            // 
            // DataNumLabel8
            // 
            this.DataNumLabel8.AutoSize = true;
            this.DataNumLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel8.Location = new System.Drawing.Point(24, 252);
            this.DataNumLabel8.Name = "DataNumLabel8";
            this.DataNumLabel8.Size = new System.Drawing.Size(15, 16);
            this.DataNumLabel8.TabIndex = 3;
            this.DataNumLabel8.Text = "8";
            // 
            // DataNumLabel18
            // 
            this.DataNumLabel18.AutoSize = true;
            this.DataNumLabel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel18.Location = new System.Drawing.Point(155, 252);
            this.DataNumLabel18.Name = "DataNumLabel18";
            this.DataNumLabel18.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel18.TabIndex = 3;
            this.DataNumLabel18.Text = "18";
            // 
            // DataNumLabel24
            // 
            this.DataNumLabel24.AutoSize = true;
            this.DataNumLabel24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel24.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel24.Location = new System.Drawing.Point(289, 124);
            this.DataNumLabel24.Name = "DataNumLabel24";
            this.DataNumLabel24.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel24.TabIndex = 3;
            this.DataNumLabel24.Text = "24";
            // 
            // DataNumLabel28
            // 
            this.DataNumLabel28.AutoSize = true;
            this.DataNumLabel28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel28.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel28.Location = new System.Drawing.Point(289, 252);
            this.DataNumLabel28.Name = "DataNumLabel28";
            this.DataNumLabel28.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel28.TabIndex = 3;
            this.DataNumLabel28.Text = "28";
            // 
            // DataNumLabel14
            // 
            this.DataNumLabel14.AutoSize = true;
            this.DataNumLabel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel14.Location = new System.Drawing.Point(155, 124);
            this.DataNumLabel14.Name = "DataNumLabel14";
            this.DataNumLabel14.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel14.TabIndex = 3;
            this.DataNumLabel14.Text = "14";
            // 
            // DataNumLabel4
            // 
            this.DataNumLabel4.AutoSize = true;
            this.DataNumLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel4.Location = new System.Drawing.Point(24, 124);
            this.DataNumLabel4.Name = "DataNumLabel4";
            this.DataNumLabel4.Size = new System.Drawing.Size(15, 16);
            this.DataNumLabel4.TabIndex = 3;
            this.DataNumLabel4.Text = "4";
            // 
            // DataNumLabel9
            // 
            this.DataNumLabel9.AutoSize = true;
            this.DataNumLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel9.Location = new System.Drawing.Point(24, 284);
            this.DataNumLabel9.Name = "DataNumLabel9";
            this.DataNumLabel9.Size = new System.Drawing.Size(15, 16);
            this.DataNumLabel9.TabIndex = 3;
            this.DataNumLabel9.Text = "9";
            // 
            // DataNumLabel19
            // 
            this.DataNumLabel19.AutoSize = true;
            this.DataNumLabel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel19.Location = new System.Drawing.Point(155, 284);
            this.DataNumLabel19.Name = "DataNumLabel19";
            this.DataNumLabel19.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel19.TabIndex = 3;
            this.DataNumLabel19.Text = "19";
            // 
            // DataNumLabel23
            // 
            this.DataNumLabel23.AutoSize = true;
            this.DataNumLabel23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel23.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel23.Location = new System.Drawing.Point(289, 92);
            this.DataNumLabel23.Name = "DataNumLabel23";
            this.DataNumLabel23.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel23.TabIndex = 3;
            this.DataNumLabel23.Text = "23";
            // 
            // DataNumLabel29
            // 
            this.DataNumLabel29.AutoSize = true;
            this.DataNumLabel29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel29.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel29.Location = new System.Drawing.Point(289, 284);
            this.DataNumLabel29.Name = "DataNumLabel29";
            this.DataNumLabel29.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel29.TabIndex = 3;
            this.DataNumLabel29.Text = "29";
            // 
            // DataNumLabel13
            // 
            this.DataNumLabel13.AutoSize = true;
            this.DataNumLabel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel13.Location = new System.Drawing.Point(155, 92);
            this.DataNumLabel13.Name = "DataNumLabel13";
            this.DataNumLabel13.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel13.TabIndex = 3;
            this.DataNumLabel13.Text = "13";
            // 
            // DataNumLabel3
            // 
            this.DataNumLabel3.AutoSize = true;
            this.DataNumLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel3.Location = new System.Drawing.Point(24, 92);
            this.DataNumLabel3.Name = "DataNumLabel3";
            this.DataNumLabel3.Size = new System.Drawing.Size(15, 16);
            this.DataNumLabel3.TabIndex = 3;
            this.DataNumLabel3.Text = "3";
            // 
            // DataNumLabel10
            // 
            this.DataNumLabel10.AutoSize = true;
            this.DataNumLabel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel10.Location = new System.Drawing.Point(16, 316);
            this.DataNumLabel10.Name = "DataNumLabel10";
            this.DataNumLabel10.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel10.TabIndex = 3;
            this.DataNumLabel10.Text = "10";
            // 
            // DataNumLabel20
            // 
            this.DataNumLabel20.AutoSize = true;
            this.DataNumLabel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel20.Location = new System.Drawing.Point(155, 316);
            this.DataNumLabel20.Name = "DataNumLabel20";
            this.DataNumLabel20.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel20.TabIndex = 3;
            this.DataNumLabel20.Text = "20";
            // 
            // DataNumLabel22
            // 
            this.DataNumLabel22.AutoSize = true;
            this.DataNumLabel22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel22.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel22.Location = new System.Drawing.Point(289, 60);
            this.DataNumLabel22.Name = "DataNumLabel22";
            this.DataNumLabel22.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel22.TabIndex = 3;
            this.DataNumLabel22.Text = "22";
            // 
            // DataNumLabel12
            // 
            this.DataNumLabel12.AutoSize = true;
            this.DataNumLabel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel12.Location = new System.Drawing.Point(155, 60);
            this.DataNumLabel12.Name = "DataNumLabel12";
            this.DataNumLabel12.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel12.TabIndex = 3;
            this.DataNumLabel12.Text = "12";
            // 
            // DataNumLabel30
            // 
            this.DataNumLabel30.AutoSize = true;
            this.DataNumLabel30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel30.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel30.Location = new System.Drawing.Point(289, 316);
            this.DataNumLabel30.Name = "DataNumLabel30";
            this.DataNumLabel30.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel30.TabIndex = 3;
            this.DataNumLabel30.Text = "30";
            // 
            // DataNumLabel2
            // 
            this.DataNumLabel2.AutoSize = true;
            this.DataNumLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel2.Location = new System.Drawing.Point(24, 60);
            this.DataNumLabel2.Name = "DataNumLabel2";
            this.DataNumLabel2.Size = new System.Drawing.Size(15, 16);
            this.DataNumLabel2.TabIndex = 3;
            this.DataNumLabel2.Text = "2";
            // 
            // DataNumLabel21
            // 
            this.DataNumLabel21.AutoSize = true;
            this.DataNumLabel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel21.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel21.Location = new System.Drawing.Point(289, 28);
            this.DataNumLabel21.Name = "DataNumLabel21";
            this.DataNumLabel21.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel21.TabIndex = 3;
            this.DataNumLabel21.Text = "21";
            // 
            // DataNumLabel11
            // 
            this.DataNumLabel11.AutoSize = true;
            this.DataNumLabel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel11.Location = new System.Drawing.Point(155, 28);
            this.DataNumLabel11.Name = "DataNumLabel11";
            this.DataNumLabel11.Size = new System.Drawing.Size(23, 16);
            this.DataNumLabel11.TabIndex = 3;
            this.DataNumLabel11.Text = "11";
            // 
            // DataNumLabel1
            // 
            this.DataNumLabel1.AutoSize = true;
            this.DataNumLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DataNumLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.DataNumLabel1.Location = new System.Drawing.Point(24, 28);
            this.DataNumLabel1.Name = "DataNumLabel1";
            this.DataNumLabel1.Size = new System.Drawing.Size(15, 16);
            this.DataNumLabel1.TabIndex = 3;
            this.DataNumLabel1.Text = "1";
            // 
            // tabPage2panel4
            // 
            this.tabPage2panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox60);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox50);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox40);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox59);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox60);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox49);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox58);
            this.tabPage2panel4.Controls.Add(this.label27);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox39);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox57);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox48);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox59);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox56);
            this.tabPage2panel4.Controls.Add(this.label29);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox47);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox55);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox38);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox58);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox54);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox46);
            this.tabPage2panel4.Controls.Add(this.label28);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox53);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox37);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox45);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox52);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox57);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox51);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox56);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox44);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox36);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox55);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox43);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox35);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox42);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox54);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox41);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox34);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox53);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox33);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox52);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox50);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox32);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox51);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox49);
            this.tabPage2panel4.Controls.Add(this.DataNumTextBox31);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox48);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox47);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox46);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox45);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox44);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox43);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox42);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox41);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox40);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox39);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox38);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox37);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox36);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox35);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox34);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox33);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox32);
            this.tabPage2panel4.Controls.Add(this.DesorbTextBox31);
            this.tabPage2panel4.Location = new System.Drawing.Point(3, 573);
            this.tabPage2panel4.Name = "tabPage2panel4";
            this.tabPage2panel4.Size = new System.Drawing.Size(403, 346);
            this.tabPage2panel4.TabIndex = 2;
            // 
            // DataNumTextBox60
            // 
            this.DataNumTextBox60.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox60.Location = new System.Drawing.Point(273, 313);
            this.DataNumTextBox60.Name = "DataNumTextBox60";
            this.DataNumTextBox60.PlaceholderText = "";
            this.DataNumTextBox60.Radius = 2;
            this.DataNumTextBox60.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox60.TabIndex = 95;
            // 
            // DataNumTextBox50
            // 
            this.DataNumTextBox50.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox50.Location = new System.Drawing.Point(138, 313);
            this.DataNumTextBox50.Name = "DataNumTextBox50";
            this.DataNumTextBox50.PlaceholderText = "";
            this.DataNumTextBox50.Radius = 2;
            this.DataNumTextBox50.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox50.TabIndex = 75;
            // 
            // DataNumTextBox40
            // 
            this.DataNumTextBox40.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox40.Location = new System.Drawing.Point(-1, 313);
            this.DataNumTextBox40.Name = "DataNumTextBox40";
            this.DataNumTextBox40.PlaceholderText = "";
            this.DataNumTextBox40.Radius = 2;
            this.DataNumTextBox40.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox40.TabIndex = 55;
            // 
            // DataNumTextBox59
            // 
            this.DataNumTextBox59.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox59.Location = new System.Drawing.Point(273, 281);
            this.DataNumTextBox59.Name = "DataNumTextBox59";
            this.DataNumTextBox59.PlaceholderText = "";
            this.DataNumTextBox59.Radius = 2;
            this.DataNumTextBox59.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox59.TabIndex = 93;
            // 
            // DesorbTextBox60
            // 
            this.DesorbTextBox60.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox60.Location = new System.Drawing.Point(317, 311);
            this.DesorbTextBox60.Name = "DesorbTextBox60";
            this.DesorbTextBox60.PlaceholderText = "";
            this.DesorbTextBox60.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox60.TabIndex = 96;
            // 
            // DataNumTextBox49
            // 
            this.DataNumTextBox49.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox49.Location = new System.Drawing.Point(138, 281);
            this.DataNumTextBox49.Name = "DataNumTextBox49";
            this.DataNumTextBox49.PlaceholderText = "";
            this.DataNumTextBox49.Radius = 2;
            this.DataNumTextBox49.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox49.TabIndex = 73;
            // 
            // DataNumTextBox58
            // 
            this.DataNumTextBox58.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox58.Location = new System.Drawing.Point(273, 249);
            this.DataNumTextBox58.Name = "DataNumTextBox58";
            this.DataNumTextBox58.PlaceholderText = "";
            this.DataNumTextBox58.Radius = 2;
            this.DataNumTextBox58.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox58.TabIndex = 91;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label27.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(234)))), ((int)(((byte)(251)))));
            this.label27.Location = new System.Drawing.Point(3, 5);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(119, 16);
            this.label27.TabIndex = 146;
            this.label27.Text = "时间   解吸量 ";
            // 
            // DataNumTextBox39
            // 
            this.DataNumTextBox39.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox39.Location = new System.Drawing.Point(-1, 281);
            this.DataNumTextBox39.Name = "DataNumTextBox39";
            this.DataNumTextBox39.PlaceholderText = "";
            this.DataNumTextBox39.Radius = 2;
            this.DataNumTextBox39.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox39.TabIndex = 53;
            // 
            // DataNumTextBox57
            // 
            this.DataNumTextBox57.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox57.Location = new System.Drawing.Point(273, 217);
            this.DataNumTextBox57.Name = "DataNumTextBox57";
            this.DataNumTextBox57.PlaceholderText = "";
            this.DataNumTextBox57.Radius = 2;
            this.DataNumTextBox57.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox57.TabIndex = 89;
            // 
            // DataNumTextBox48
            // 
            this.DataNumTextBox48.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox48.Location = new System.Drawing.Point(138, 249);
            this.DataNumTextBox48.Name = "DataNumTextBox48";
            this.DataNumTextBox48.PlaceholderText = "";
            this.DataNumTextBox48.Radius = 2;
            this.DataNumTextBox48.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox48.TabIndex = 71;
            // 
            // DesorbTextBox59
            // 
            this.DesorbTextBox59.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox59.Location = new System.Drawing.Point(317, 279);
            this.DesorbTextBox59.Name = "DesorbTextBox59";
            this.DesorbTextBox59.PlaceholderText = "";
            this.DesorbTextBox59.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox59.TabIndex = 94;
            // 
            // DataNumTextBox56
            // 
            this.DataNumTextBox56.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox56.Location = new System.Drawing.Point(273, 185);
            this.DataNumTextBox56.Name = "DataNumTextBox56";
            this.DataNumTextBox56.PlaceholderText = "";
            this.DataNumTextBox56.Radius = 2;
            this.DataNumTextBox56.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox56.TabIndex = 87;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label29.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(234)))), ((int)(((byte)(251)))));
            this.label29.Location = new System.Drawing.Point(276, 5);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(119, 16);
            this.label29.TabIndex = 148;
            this.label29.Text = "时间   解吸量 ";
            // 
            // DataNumTextBox47
            // 
            this.DataNumTextBox47.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox47.Location = new System.Drawing.Point(138, 217);
            this.DataNumTextBox47.Name = "DataNumTextBox47";
            this.DataNumTextBox47.PlaceholderText = "";
            this.DataNumTextBox47.Radius = 2;
            this.DataNumTextBox47.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox47.TabIndex = 69;
            // 
            // DataNumTextBox55
            // 
            this.DataNumTextBox55.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox55.Location = new System.Drawing.Point(273, 153);
            this.DataNumTextBox55.Name = "DataNumTextBox55";
            this.DataNumTextBox55.PlaceholderText = "";
            this.DataNumTextBox55.Radius = 2;
            this.DataNumTextBox55.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox55.TabIndex = 85;
            // 
            // DataNumTextBox38
            // 
            this.DataNumTextBox38.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox38.Location = new System.Drawing.Point(-1, 249);
            this.DataNumTextBox38.Name = "DataNumTextBox38";
            this.DataNumTextBox38.PlaceholderText = "";
            this.DataNumTextBox38.Radius = 2;
            this.DataNumTextBox38.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox38.TabIndex = 51;
            // 
            // DesorbTextBox58
            // 
            this.DesorbTextBox58.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox58.Location = new System.Drawing.Point(317, 247);
            this.DesorbTextBox58.Name = "DesorbTextBox58";
            this.DesorbTextBox58.PlaceholderText = "";
            this.DesorbTextBox58.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox58.TabIndex = 92;
            // 
            // DataNumTextBox54
            // 
            this.DataNumTextBox54.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox54.Location = new System.Drawing.Point(273, 121);
            this.DataNumTextBox54.Name = "DataNumTextBox54";
            this.DataNumTextBox54.PlaceholderText = "";
            this.DataNumTextBox54.Radius = 2;
            this.DataNumTextBox54.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox54.TabIndex = 83;
            // 
            // DataNumTextBox46
            // 
            this.DataNumTextBox46.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox46.Location = new System.Drawing.Point(138, 185);
            this.DataNumTextBox46.Name = "DataNumTextBox46";
            this.DataNumTextBox46.PlaceholderText = "";
            this.DataNumTextBox46.Radius = 2;
            this.DataNumTextBox46.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox46.TabIndex = 67;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label28.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(234)))), ((int)(((byte)(251)))));
            this.label28.Location = new System.Drawing.Point(142, 5);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(119, 16);
            this.label28.TabIndex = 147;
            this.label28.Text = "时间   解吸量 ";
            // 
            // DataNumTextBox53
            // 
            this.DataNumTextBox53.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox53.Location = new System.Drawing.Point(273, 89);
            this.DataNumTextBox53.Name = "DataNumTextBox53";
            this.DataNumTextBox53.PlaceholderText = "";
            this.DataNumTextBox53.Radius = 2;
            this.DataNumTextBox53.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox53.TabIndex = 81;
            // 
            // DataNumTextBox37
            // 
            this.DataNumTextBox37.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox37.Location = new System.Drawing.Point(-1, 217);
            this.DataNumTextBox37.Name = "DataNumTextBox37";
            this.DataNumTextBox37.PlaceholderText = "";
            this.DataNumTextBox37.Radius = 2;
            this.DataNumTextBox37.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox37.TabIndex = 49;
            // 
            // DataNumTextBox45
            // 
            this.DataNumTextBox45.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox45.Location = new System.Drawing.Point(138, 153);
            this.DataNumTextBox45.Name = "DataNumTextBox45";
            this.DataNumTextBox45.PlaceholderText = "";
            this.DataNumTextBox45.Radius = 2;
            this.DataNumTextBox45.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox45.TabIndex = 65;
            // 
            // DataNumTextBox52
            // 
            this.DataNumTextBox52.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox52.Location = new System.Drawing.Point(273, 57);
            this.DataNumTextBox52.Name = "DataNumTextBox52";
            this.DataNumTextBox52.PlaceholderText = "";
            this.DataNumTextBox52.Radius = 2;
            this.DataNumTextBox52.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox52.TabIndex = 79;
            // 
            // DesorbTextBox57
            // 
            this.DesorbTextBox57.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox57.Location = new System.Drawing.Point(317, 215);
            this.DesorbTextBox57.Name = "DesorbTextBox57";
            this.DesorbTextBox57.PlaceholderText = "";
            this.DesorbTextBox57.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox57.TabIndex = 90;
            // 
            // DataNumTextBox51
            // 
            this.DataNumTextBox51.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox51.Location = new System.Drawing.Point(273, 25);
            this.DataNumTextBox51.Name = "DataNumTextBox51";
            this.DataNumTextBox51.PlaceholderText = "";
            this.DataNumTextBox51.Radius = 2;
            this.DataNumTextBox51.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox51.TabIndex = 77;
            // 
            // DesorbTextBox56
            // 
            this.DesorbTextBox56.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox56.Location = new System.Drawing.Point(317, 183);
            this.DesorbTextBox56.Name = "DesorbTextBox56";
            this.DesorbTextBox56.PlaceholderText = "";
            this.DesorbTextBox56.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox56.TabIndex = 88;
            // 
            // DataNumTextBox44
            // 
            this.DataNumTextBox44.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox44.Location = new System.Drawing.Point(138, 121);
            this.DataNumTextBox44.Name = "DataNumTextBox44";
            this.DataNumTextBox44.PlaceholderText = "";
            this.DataNumTextBox44.Radius = 2;
            this.DataNumTextBox44.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox44.TabIndex = 63;
            // 
            // DataNumTextBox36
            // 
            this.DataNumTextBox36.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox36.Location = new System.Drawing.Point(-1, 185);
            this.DataNumTextBox36.Name = "DataNumTextBox36";
            this.DataNumTextBox36.PlaceholderText = "";
            this.DataNumTextBox36.Radius = 2;
            this.DataNumTextBox36.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox36.TabIndex = 47;
            // 
            // DesorbTextBox55
            // 
            this.DesorbTextBox55.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox55.Location = new System.Drawing.Point(317, 151);
            this.DesorbTextBox55.Name = "DesorbTextBox55";
            this.DesorbTextBox55.PlaceholderText = "";
            this.DesorbTextBox55.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox55.TabIndex = 86;
            // 
            // DataNumTextBox43
            // 
            this.DataNumTextBox43.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox43.Location = new System.Drawing.Point(138, 89);
            this.DataNumTextBox43.Name = "DataNumTextBox43";
            this.DataNumTextBox43.PlaceholderText = "";
            this.DataNumTextBox43.Radius = 2;
            this.DataNumTextBox43.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox43.TabIndex = 61;
            // 
            // DataNumTextBox35
            // 
            this.DataNumTextBox35.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox35.Location = new System.Drawing.Point(-1, 153);
            this.DataNumTextBox35.Name = "DataNumTextBox35";
            this.DataNumTextBox35.PlaceholderText = "";
            this.DataNumTextBox35.Radius = 2;
            this.DataNumTextBox35.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox35.TabIndex = 45;
            // 
            // DataNumTextBox42
            // 
            this.DataNumTextBox42.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox42.Location = new System.Drawing.Point(138, 57);
            this.DataNumTextBox42.Name = "DataNumTextBox42";
            this.DataNumTextBox42.PlaceholderText = "";
            this.DataNumTextBox42.Radius = 2;
            this.DataNumTextBox42.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox42.TabIndex = 59;
            // 
            // DesorbTextBox54
            // 
            this.DesorbTextBox54.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox54.Location = new System.Drawing.Point(317, 119);
            this.DesorbTextBox54.Name = "DesorbTextBox54";
            this.DesorbTextBox54.PlaceholderText = "";
            this.DesorbTextBox54.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox54.TabIndex = 84;
            // 
            // DataNumTextBox41
            // 
            this.DataNumTextBox41.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox41.Location = new System.Drawing.Point(138, 25);
            this.DataNumTextBox41.Name = "DataNumTextBox41";
            this.DataNumTextBox41.PlaceholderText = "";
            this.DataNumTextBox41.Radius = 2;
            this.DataNumTextBox41.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox41.TabIndex = 57;
            // 
            // DataNumTextBox34
            // 
            this.DataNumTextBox34.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox34.Location = new System.Drawing.Point(-1, 121);
            this.DataNumTextBox34.Name = "DataNumTextBox34";
            this.DataNumTextBox34.PlaceholderText = "";
            this.DataNumTextBox34.Radius = 2;
            this.DataNumTextBox34.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox34.TabIndex = 43;
            // 
            // DesorbTextBox53
            // 
            this.DesorbTextBox53.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox53.Location = new System.Drawing.Point(317, 87);
            this.DesorbTextBox53.Name = "DesorbTextBox53";
            this.DesorbTextBox53.PlaceholderText = "";
            this.DesorbTextBox53.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox53.TabIndex = 82;
            // 
            // DataNumTextBox33
            // 
            this.DataNumTextBox33.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox33.Location = new System.Drawing.Point(-1, 89);
            this.DataNumTextBox33.Name = "DataNumTextBox33";
            this.DataNumTextBox33.PlaceholderText = "";
            this.DataNumTextBox33.Radius = 2;
            this.DataNumTextBox33.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox33.TabIndex = 41;
            // 
            // DesorbTextBox52
            // 
            this.DesorbTextBox52.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox52.Location = new System.Drawing.Point(317, 55);
            this.DesorbTextBox52.Name = "DesorbTextBox52";
            this.DesorbTextBox52.PlaceholderText = "";
            this.DesorbTextBox52.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox52.TabIndex = 80;
            // 
            // DesorbTextBox50
            // 
            this.DesorbTextBox50.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox50.Location = new System.Drawing.Point(183, 311);
            this.DesorbTextBox50.Name = "DesorbTextBox50";
            this.DesorbTextBox50.PlaceholderText = "";
            this.DesorbTextBox50.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox50.TabIndex = 76;
            // 
            // DataNumTextBox32
            // 
            this.DataNumTextBox32.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox32.Location = new System.Drawing.Point(-1, 57);
            this.DataNumTextBox32.Name = "DataNumTextBox32";
            this.DataNumTextBox32.PlaceholderText = "";
            this.DataNumTextBox32.Radius = 2;
            this.DataNumTextBox32.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox32.TabIndex = 39;
            // 
            // DesorbTextBox51
            // 
            this.DesorbTextBox51.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox51.Location = new System.Drawing.Point(317, 23);
            this.DesorbTextBox51.Name = "DesorbTextBox51";
            this.DesorbTextBox51.PlaceholderText = "";
            this.DesorbTextBox51.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox51.TabIndex = 78;
            // 
            // DesorbTextBox49
            // 
            this.DesorbTextBox49.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox49.Location = new System.Drawing.Point(183, 279);
            this.DesorbTextBox49.Name = "DesorbTextBox49";
            this.DesorbTextBox49.PlaceholderText = "";
            this.DesorbTextBox49.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox49.TabIndex = 74;
            // 
            // DataNumTextBox31
            // 
            this.DataNumTextBox31.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataNumTextBox31.Location = new System.Drawing.Point(-1, 25);
            this.DataNumTextBox31.Name = "DataNumTextBox31";
            this.DataNumTextBox31.PlaceholderText = "";
            this.DataNumTextBox31.Radius = 2;
            this.DataNumTextBox31.Size = new System.Drawing.Size(46, 30);
            this.DataNumTextBox31.TabIndex = 37;
            // 
            // DesorbTextBox48
            // 
            this.DesorbTextBox48.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox48.Location = new System.Drawing.Point(183, 247);
            this.DesorbTextBox48.Name = "DesorbTextBox48";
            this.DesorbTextBox48.PlaceholderText = "";
            this.DesorbTextBox48.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox48.TabIndex = 72;
            // 
            // DesorbTextBox47
            // 
            this.DesorbTextBox47.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox47.Location = new System.Drawing.Point(183, 215);
            this.DesorbTextBox47.Name = "DesorbTextBox47";
            this.DesorbTextBox47.PlaceholderText = "";
            this.DesorbTextBox47.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox47.TabIndex = 70;
            // 
            // DesorbTextBox46
            // 
            this.DesorbTextBox46.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox46.Location = new System.Drawing.Point(183, 183);
            this.DesorbTextBox46.Name = "DesorbTextBox46";
            this.DesorbTextBox46.PlaceholderText = "";
            this.DesorbTextBox46.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox46.TabIndex = 68;
            // 
            // DesorbTextBox45
            // 
            this.DesorbTextBox45.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox45.Location = new System.Drawing.Point(183, 151);
            this.DesorbTextBox45.Name = "DesorbTextBox45";
            this.DesorbTextBox45.PlaceholderText = "";
            this.DesorbTextBox45.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox45.TabIndex = 66;
            // 
            // DesorbTextBox44
            // 
            this.DesorbTextBox44.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox44.Location = new System.Drawing.Point(183, 119);
            this.DesorbTextBox44.Name = "DesorbTextBox44";
            this.DesorbTextBox44.PlaceholderText = "";
            this.DesorbTextBox44.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox44.TabIndex = 64;
            // 
            // DesorbTextBox43
            // 
            this.DesorbTextBox43.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox43.Location = new System.Drawing.Point(183, 87);
            this.DesorbTextBox43.Name = "DesorbTextBox43";
            this.DesorbTextBox43.PlaceholderText = "";
            this.DesorbTextBox43.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox43.TabIndex = 62;
            // 
            // DesorbTextBox42
            // 
            this.DesorbTextBox42.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox42.Location = new System.Drawing.Point(183, 55);
            this.DesorbTextBox42.Name = "DesorbTextBox42";
            this.DesorbTextBox42.PlaceholderText = "";
            this.DesorbTextBox42.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox42.TabIndex = 60;
            // 
            // DesorbTextBox41
            // 
            this.DesorbTextBox41.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox41.Location = new System.Drawing.Point(183, 23);
            this.DesorbTextBox41.Name = "DesorbTextBox41";
            this.DesorbTextBox41.PlaceholderText = "";
            this.DesorbTextBox41.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox41.TabIndex = 58;
            // 
            // DesorbTextBox40
            // 
            this.DesorbTextBox40.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox40.Location = new System.Drawing.Point(44, 311);
            this.DesorbTextBox40.Name = "DesorbTextBox40";
            this.DesorbTextBox40.PlaceholderText = "";
            this.DesorbTextBox40.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox40.TabIndex = 56;
            // 
            // DesorbTextBox39
            // 
            this.DesorbTextBox39.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox39.Location = new System.Drawing.Point(44, 279);
            this.DesorbTextBox39.Name = "DesorbTextBox39";
            this.DesorbTextBox39.PlaceholderText = "";
            this.DesorbTextBox39.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox39.TabIndex = 54;
            // 
            // DesorbTextBox38
            // 
            this.DesorbTextBox38.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox38.Location = new System.Drawing.Point(44, 247);
            this.DesorbTextBox38.Name = "DesorbTextBox38";
            this.DesorbTextBox38.PlaceholderText = "";
            this.DesorbTextBox38.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox38.TabIndex = 52;
            // 
            // DesorbTextBox37
            // 
            this.DesorbTextBox37.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox37.Location = new System.Drawing.Point(44, 215);
            this.DesorbTextBox37.Name = "DesorbTextBox37";
            this.DesorbTextBox37.PlaceholderText = "";
            this.DesorbTextBox37.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox37.TabIndex = 50;
            // 
            // DesorbTextBox36
            // 
            this.DesorbTextBox36.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox36.Location = new System.Drawing.Point(44, 183);
            this.DesorbTextBox36.Name = "DesorbTextBox36";
            this.DesorbTextBox36.PlaceholderText = "";
            this.DesorbTextBox36.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox36.TabIndex = 48;
            // 
            // DesorbTextBox35
            // 
            this.DesorbTextBox35.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox35.Location = new System.Drawing.Point(44, 151);
            this.DesorbTextBox35.Name = "DesorbTextBox35";
            this.DesorbTextBox35.PlaceholderText = "";
            this.DesorbTextBox35.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox35.TabIndex = 46;
            // 
            // DesorbTextBox34
            // 
            this.DesorbTextBox34.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox34.Location = new System.Drawing.Point(44, 119);
            this.DesorbTextBox34.Name = "DesorbTextBox34";
            this.DesorbTextBox34.PlaceholderText = "";
            this.DesorbTextBox34.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox34.TabIndex = 44;
            // 
            // DesorbTextBox33
            // 
            this.DesorbTextBox33.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox33.Location = new System.Drawing.Point(44, 87);
            this.DesorbTextBox33.Name = "DesorbTextBox33";
            this.DesorbTextBox33.PlaceholderText = "";
            this.DesorbTextBox33.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox33.TabIndex = 42;
            // 
            // DesorbTextBox32
            // 
            this.DesorbTextBox32.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox32.Location = new System.Drawing.Point(44, 55);
            this.DesorbTextBox32.Name = "DesorbTextBox32";
            this.DesorbTextBox32.PlaceholderText = "";
            this.DesorbTextBox32.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox32.TabIndex = 40;
            // 
            // DesorbTextBox31
            // 
            this.DesorbTextBox31.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorbTextBox31.Location = new System.Drawing.Point(44, 23);
            this.DesorbTextBox31.Name = "DesorbTextBox31";
            this.DesorbTextBox31.PlaceholderText = "";
            this.DesorbTextBox31.Size = new System.Drawing.Size(85, 35);
            this.DesorbTextBox31.TabIndex = 38;
            // 
            // tabPage2panel9
            // 
            this.tabPage2panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage2panel9.Location = new System.Drawing.Point(409, 573);
            this.tabPage2panel9.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tabPage2panel9.Name = "tabPage2panel9";
            this.tabPage2panel9.Size = new System.Drawing.Size(1, 103);
            this.tabPage2panel9.TabIndex = 1004;
            // 
            // tabPage2panel5
            // 
            this.tabPage2panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage2panel5.Controls.Add(this.label23);
            this.tabPage2panel5.Controls.Add(this.pictureBox3);
            this.tabPage2panel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2panel5.Location = new System.Drawing.Point(413, 573);
            this.tabPage2panel5.Name = "tabPage2panel5";
            this.tabPage2panel5.Size = new System.Drawing.Size(321, 345);
            this.tabPage2panel5.TabIndex = 1001;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label23.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.label23.Location = new System.Drawing.Point(3, 5);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(89, 19);
            this.label23.TabIndex = 142;
            this.label23.Text = "图像预览";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Location = new System.Drawing.Point(3, 26);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(314, 314);
            this.pictureBox3.TabIndex = 34;
            this.pictureBox3.TabStop = false;
            // 
            // tabPage2panel10
            // 
            this.tabPage2panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage2panel10.Location = new System.Drawing.Point(737, 573);
            this.tabPage2panel10.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tabPage2panel10.Name = "tabPage2panel10";
            this.tabPage2panel10.Size = new System.Drawing.Size(1, 103);
            this.tabPage2panel10.TabIndex = 1005;
            // 
            // tabPage2panel6
            // 
            this.tabPage2panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(109)))));
            this.tabPage2panel6.Controls.Add(this.SampLossVolTextBox);
            this.tabPage2panel6.Controls.Add(this.UndDesorpCalTextBox);
            this.tabPage2panel6.Controls.Add(this.DesVolUndTextBox);
            this.tabPage2panel6.Controls.Add(this.DataExportButton);
            this.tabPage2panel6.Controls.Add(this.ExportImageButton);
            this.tabPage2panel6.Controls.Add(this.BulkImportButton);
            this.tabPage2panel6.Controls.Add(this.label53);
            this.tabPage2panel6.Controls.Add(this.label54);
            this.tabPage2panel6.Controls.Add(this.DrawCurvesButton);
            this.tabPage2panel6.Controls.Add(this.label18);
            this.tabPage2panel6.Controls.Add(this.tabPage2TemporarySavingButton);
            this.tabPage2panel6.Controls.Add(this.tabPage2RecoverDataButton);
            this.tabPage2panel6.Location = new System.Drawing.Point(3, 925);
            this.tabPage2panel6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.tabPage2panel6.Name = "tabPage2panel6";
            this.tabPage2panel6.Size = new System.Drawing.Size(806, 160);
            this.tabPage2panel6.TabIndex = 1000;
            // 
            // SampLossVolTextBox
            // 
            this.SampLossVolTextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.SampLossVolTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SampLossVolTextBox.Location = new System.Drawing.Point(159, 90);
            this.SampLossVolTextBox.Name = "SampLossVolTextBox";
            this.SampLossVolTextBox.PlaceholderText = "";
            this.SampLossVolTextBox.ReadOnly = true;
            this.SampLossVolTextBox.SelectionStart = 1;
            this.SampLossVolTextBox.Size = new System.Drawing.Size(222, 35);
            this.SampLossVolTextBox.TabIndex = 1013;
            this.SampLossVolTextBox.TabStop = false;
            this.SampLossVolTextBox.Text = "0";
            // 
            // UndDesorpCalTextBox
            // 
            this.UndDesorpCalTextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.UndDesorpCalTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UndDesorpCalTextBox.Location = new System.Drawing.Point(159, 48);
            this.UndDesorpCalTextBox.Name = "UndDesorpCalTextBox";
            this.UndDesorpCalTextBox.PlaceholderText = "";
            this.UndDesorpCalTextBox.ReadOnly = true;
            this.UndDesorpCalTextBox.SelectionStart = 1;
            this.UndDesorpCalTextBox.Size = new System.Drawing.Size(222, 35);
            this.UndDesorpCalTextBox.TabIndex = 1012;
            this.UndDesorpCalTextBox.TabStop = false;
            this.UndDesorpCalTextBox.Text = "0";
            // 
            // DesVolUndTextBox
            // 
            this.DesVolUndTextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.DesVolUndTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesVolUndTextBox.Location = new System.Drawing.Point(159, 7);
            this.DesVolUndTextBox.Name = "DesVolUndTextBox";
            this.DesVolUndTextBox.PlaceholderText = "";
            this.DesVolUndTextBox.ReadOnly = true;
            this.DesVolUndTextBox.SelectionStart = 1;
            this.DesVolUndTextBox.Size = new System.Drawing.Size(222, 35);
            this.DesVolUndTextBox.TabIndex = 1011;
            this.DesVolUndTextBox.TabStop = false;
            this.DesVolUndTextBox.Text = "0";
            // 
            // DataExportButton
            // 
            this.DataExportButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DataExportButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DataExportButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("DataExportButton.ButtonImage")));
            this.DataExportButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.DataExportButton.FlatAppearance.BorderSize = 0;
            this.DataExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataExportButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataExportButton.HoverColor = System.Drawing.Color.LightBlue;
            this.DataExportButton.Location = new System.Drawing.Point(399, 78);
            this.DataExportButton.Name = "DataExportButton";
            this.DataExportButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DataExportButton.Radius = 15;
            this.DataExportButton.Size = new System.Drawing.Size(132, 42);
            this.DataExportButton.TabIndex = 1007;
            this.DataExportButton.Text = "     数据导出";
            this.DataExportButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DataExportButton.UseVisualStyleBackColor = false;
            // 
            // ExportImageButton
            // 
            this.ExportImageButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ExportImageButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ExportImageButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("ExportImageButton.ButtonImage")));
            this.ExportImageButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.ExportImageButton.FlatAppearance.BorderSize = 0;
            this.ExportImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportImageButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExportImageButton.HoverColor = System.Drawing.Color.LightBlue;
            this.ExportImageButton.Location = new System.Drawing.Point(542, 13);
            this.ExportImageButton.Name = "ExportImageButton";
            this.ExportImageButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ExportImageButton.Radius = 15;
            this.ExportImageButton.Size = new System.Drawing.Size(116, 42);
            this.ExportImageButton.TabIndex = 1002;
            this.ExportImageButton.Text = "     导出图像";
            this.ExportImageButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExportImageButton.UseVisualStyleBackColor = false;
            this.ExportImageButton.Visible = false;
            // 
            // BulkImportButton
            // 
            this.BulkImportButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BulkImportButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BulkImportButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("BulkImportButton.ButtonImage")));
            this.BulkImportButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.BulkImportButton.FlatAppearance.BorderSize = 0;
            this.BulkImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BulkImportButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BulkImportButton.HoverColor = System.Drawing.Color.LightBlue;
            this.BulkImportButton.Location = new System.Drawing.Point(399, 13);
            this.BulkImportButton.Name = "BulkImportButton";
            this.BulkImportButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BulkImportButton.Radius = 15;
            this.BulkImportButton.Size = new System.Drawing.Size(132, 42);
            this.BulkImportButton.TabIndex = 1001;
            this.BulkImportButton.Text = "     批量导入";
            this.BulkImportButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BulkImportButton.UseVisualStyleBackColor = false;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label53.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.label53.Location = new System.Drawing.Point(16, 15);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(143, 16);
            this.label53.TabIndex = 3;
            this.label53.Text = "井下解吸体积(ml):";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.label54.Location = new System.Drawing.Point(16, 99);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(143, 16);
            this.label54.TabIndex = 3;
            this.label54.Text = "取样损失体积(ml):";
            // 
            // DrawCurvesButton
            // 
            this.DrawCurvesButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DrawCurvesButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DrawCurvesButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("DrawCurvesButton.ButtonImage")));
            this.DrawCurvesButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.DrawCurvesButton.FlatAppearance.BorderSize = 0;
            this.DrawCurvesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DrawCurvesButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DrawCurvesButton.HoverColor = System.Drawing.Color.LightBlue;
            this.DrawCurvesButton.Location = new System.Drawing.Point(671, 13);
            this.DrawCurvesButton.Name = "DrawCurvesButton";
            this.DrawCurvesButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DrawCurvesButton.Radius = 15;
            this.DrawCurvesButton.Size = new System.Drawing.Size(116, 42);
            this.DrawCurvesButton.TabIndex = 1000;
            this.DrawCurvesButton.Text = "     计   算";
            this.DrawCurvesButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DrawCurvesButton.UseVisualStyleBackColor = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(109)))));
            this.label18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.label18.Location = new System.Drawing.Point(17, 57);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(143, 16);
            this.label18.TabIndex = 111;
            this.label18.Text = "井下解吸校准(ml):";
            // 
            // tabPage2TemporarySavingButton
            // 
            this.tabPage2TemporarySavingButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tabPage2TemporarySavingButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2TemporarySavingButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("tabPage2TemporarySavingButton.ButtonImage")));
            this.tabPage2TemporarySavingButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.tabPage2TemporarySavingButton.FlatAppearance.BorderSize = 0;
            this.tabPage2TemporarySavingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabPage2TemporarySavingButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2TemporarySavingButton.HoverColor = System.Drawing.Color.LightBlue;
            this.tabPage2TemporarySavingButton.Location = new System.Drawing.Point(542, 78);
            this.tabPage2TemporarySavingButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.tabPage2TemporarySavingButton.Name = "tabPage2TemporarySavingButton";
            this.tabPage2TemporarySavingButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage2TemporarySavingButton.Radius = 15;
            this.tabPage2TemporarySavingButton.Size = new System.Drawing.Size(116, 42);
            this.tabPage2TemporarySavingButton.TabIndex = 1004;
            this.tabPage2TemporarySavingButton.Text = "     临时保存";
            this.tabPage2TemporarySavingButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabPage2TemporarySavingButton.UseVisualStyleBackColor = false;
            // 
            // tabPage2RecoverDataButton
            // 
            this.tabPage2RecoverDataButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tabPage2RecoverDataButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2RecoverDataButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("tabPage2RecoverDataButton.ButtonImage")));
            this.tabPage2RecoverDataButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.tabPage2RecoverDataButton.FlatAppearance.BorderSize = 0;
            this.tabPage2RecoverDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabPage2RecoverDataButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2RecoverDataButton.HoverColor = System.Drawing.Color.LightBlue;
            this.tabPage2RecoverDataButton.Location = new System.Drawing.Point(671, 78);
            this.tabPage2RecoverDataButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.tabPage2RecoverDataButton.Name = "tabPage2RecoverDataButton";
            this.tabPage2RecoverDataButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage2RecoverDataButton.Radius = 15;
            this.tabPage2RecoverDataButton.Size = new System.Drawing.Size(116, 42);
            this.tabPage2RecoverDataButton.TabIndex = 1006;
            this.tabPage2RecoverDataButton.Text = "     恢复数据";
            this.tabPage2RecoverDataButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabPage2RecoverDataButton.UseVisualStyleBackColor = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage3.Controls.Add(this.tabPage3panel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 96);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(775, 389);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // tabPage3panel1
            // 
            this.tabPage3panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tabPage3panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage3panel1.Controls.Add(this.tabPage3panel4);
            this.tabPage3panel1.Controls.Add(this.tabPage3panel2);
            this.tabPage3panel1.Controls.Add(this.label42);
            this.tabPage3panel1.Controls.Add(this.label96);
            this.tabPage3panel1.Location = new System.Drawing.Point(46, 6);
            this.tabPage3panel1.Name = "tabPage3panel1";
            this.tabPage3panel1.Size = new System.Drawing.Size(631, 352);
            this.tabPage3panel1.TabIndex = 1002;
            // 
            // tabPage3panel4
            // 
            this.tabPage3panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage3panel4.Location = new System.Drawing.Point(535, 31);
            this.tabPage3panel4.Name = "tabPage3panel4";
            this.tabPage3panel4.Size = new System.Drawing.Size(77, 100);
            this.tabPage3panel4.TabIndex = 1010;
            // 
            // tabPage3panel2
            // 
            this.tabPage3panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabPage3panel2.AutoScroll = true;
            this.tabPage3panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage3panel2.Controls.Add(this.tabPage3panel3);
            this.tabPage3panel2.Location = new System.Drawing.Point(99, 0);
            this.tabPage3panel2.Name = "tabPage3panel2";
            this.tabPage3panel2.Size = new System.Drawing.Size(410, 352);
            this.tabPage3panel2.TabIndex = 1003;
            // 
            // tabPage3panel3
            // 
            this.tabPage3panel3.AutoScroll = true;
            this.tabPage3panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage3panel3.Controls.Add(this.CrushDesorpTextBox);
            this.tabPage3panel3.Controls.Add(this.S2DesorpVolCalTextBox);
            this.tabPage3panel3.Controls.Add(this.S1DesorpVolCalTextBox);
            this.tabPage3panel3.Controls.Add(this.S2DesorpVolTextBox);
            this.tabPage3panel3.Controls.Add(this.S1DesorpVolTextBox);
            this.tabPage3panel3.Controls.Add(this.Sample2WeightTextBox);
            this.tabPage3panel3.Controls.Add(this.Sample1WeightTextBox);
            this.tabPage3panel3.Controls.Add(this.DesorpVolNormalCalTextBox);
            this.tabPage3panel3.Controls.Add(this.DesorpVolNormalTextBox);
            this.tabPage3panel3.Controls.Add(this.label89);
            this.tabPage3panel3.Controls.Add(this.tabPage3TemporarySavingButton);
            this.tabPage3panel3.Controls.Add(this.label83);
            this.tabPage3panel3.Controls.Add(this.tabPage3RecoverDataButton);
            this.tabPage3panel3.Controls.Add(this.label101);
            this.tabPage3panel3.Controls.Add(this.label82);
            this.tabPage3panel3.Controls.Add(this.label121);
            this.tabPage3panel3.Controls.Add(this.label22);
            this.tabPage3panel3.Controls.Add(this.label87);
            this.tabPage3panel3.Controls.Add(this.label85);
            this.tabPage3panel3.Controls.Add(this.LabDesorbButton);
            this.tabPage3panel3.Controls.Add(this.label122);
            this.tabPage3panel3.Controls.Add(this.label86);
            this.tabPage3panel3.Controls.Add(this.label88);
            this.tabPage3panel3.Controls.Add(this.label84);
            this.tabPage3panel3.Location = new System.Drawing.Point(4, 56);
            this.tabPage3panel3.Name = "tabPage3panel3";
            this.tabPage3panel3.Size = new System.Drawing.Size(375, 532);
            this.tabPage3panel3.TabIndex = 1003;
            // 
            // CrushDesorpTextBox
            // 
            this.CrushDesorpTextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.CrushDesorpTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CrushDesorpTextBox.Location = new System.Drawing.Point(213, 388);
            this.CrushDesorpTextBox.Name = "CrushDesorpTextBox";
            this.CrushDesorpTextBox.PlaceholderText = "";
            this.CrushDesorpTextBox.ReadOnly = true;
            this.CrushDesorpTextBox.SelectionStart = 1;
            this.CrushDesorpTextBox.Size = new System.Drawing.Size(155, 35);
            this.CrushDesorpTextBox.TabIndex = 1018;
            this.CrushDesorpTextBox.TabStop = false;
            this.CrushDesorpTextBox.Text = "0";
            // 
            // S2DesorpVolCalTextBox
            // 
            this.S2DesorpVolCalTextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.S2DesorpVolCalTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.S2DesorpVolCalTextBox.Location = new System.Drawing.Point(213, 347);
            this.S2DesorpVolCalTextBox.Name = "S2DesorpVolCalTextBox";
            this.S2DesorpVolCalTextBox.PlaceholderText = "";
            this.S2DesorpVolCalTextBox.ReadOnly = true;
            this.S2DesorpVolCalTextBox.SelectionStart = 1;
            this.S2DesorpVolCalTextBox.Size = new System.Drawing.Size(155, 35);
            this.S2DesorpVolCalTextBox.TabIndex = 1017;
            this.S2DesorpVolCalTextBox.TabStop = false;
            this.S2DesorpVolCalTextBox.Text = "0";
            // 
            // S1DesorpVolCalTextBox
            // 
            this.S1DesorpVolCalTextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.S1DesorpVolCalTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.S1DesorpVolCalTextBox.Location = new System.Drawing.Point(213, 306);
            this.S1DesorpVolCalTextBox.Name = "S1DesorpVolCalTextBox";
            this.S1DesorpVolCalTextBox.PlaceholderText = "";
            this.S1DesorpVolCalTextBox.ReadOnly = true;
            this.S1DesorpVolCalTextBox.SelectionStart = 1;
            this.S1DesorpVolCalTextBox.Size = new System.Drawing.Size(155, 35);
            this.S1DesorpVolCalTextBox.TabIndex = 1016;
            this.S1DesorpVolCalTextBox.TabStop = false;
            this.S1DesorpVolCalTextBox.Text = "0";
            // 
            // S2DesorpVolTextBox
            // 
            this.S2DesorpVolTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.S2DesorpVolTextBox.Location = new System.Drawing.Point(213, 262);
            this.S2DesorpVolTextBox.Name = "S2DesorpVolTextBox";
            this.S2DesorpVolTextBox.PlaceholderText = "第二份煤样解吸量";
            this.S2DesorpVolTextBox.Size = new System.Drawing.Size(155, 35);
            this.S2DesorpVolTextBox.TabIndex = 5;
            // 
            // S1DesorpVolTextBox
            // 
            this.S1DesorpVolTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.S1DesorpVolTextBox.Location = new System.Drawing.Point(213, 222);
            this.S1DesorpVolTextBox.Name = "S1DesorpVolTextBox";
            this.S1DesorpVolTextBox.PlaceholderText = "第一份煤样解吸量";
            this.S1DesorpVolTextBox.Size = new System.Drawing.Size(155, 35);
            this.S1DesorpVolTextBox.TabIndex = 4;
            // 
            // Sample2WeightTextBox
            // 
            this.Sample2WeightTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Sample2WeightTextBox.Location = new System.Drawing.Point(213, 179);
            this.Sample2WeightTextBox.Name = "Sample2WeightTextBox";
            this.Sample2WeightTextBox.PlaceholderText = "第二份煤样重量";
            this.Sample2WeightTextBox.Size = new System.Drawing.Size(155, 35);
            this.Sample2WeightTextBox.TabIndex = 3;
            // 
            // Sample1WeightTextBox
            // 
            this.Sample1WeightTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Sample1WeightTextBox.Location = new System.Drawing.Point(213, 137);
            this.Sample1WeightTextBox.Name = "Sample1WeightTextBox";
            this.Sample1WeightTextBox.PlaceholderText = "第一份煤样重量";
            this.Sample1WeightTextBox.Size = new System.Drawing.Size(155, 35);
            this.Sample1WeightTextBox.TabIndex = 2;
            // 
            // DesorpVolNormalCalTextBox
            // 
            this.DesorpVolNormalCalTextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.DesorpVolNormalCalTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorpVolNormalCalTextBox.Location = new System.Drawing.Point(213, 46);
            this.DesorpVolNormalCalTextBox.Name = "DesorpVolNormalCalTextBox";
            this.DesorpVolNormalCalTextBox.PlaceholderText = "";
            this.DesorpVolNormalCalTextBox.ReadOnly = true;
            this.DesorpVolNormalCalTextBox.SelectionStart = 1;
            this.DesorpVolNormalCalTextBox.Size = new System.Drawing.Size(155, 35);
            this.DesorpVolNormalCalTextBox.TabIndex = 1011;
            this.DesorpVolNormalCalTextBox.TabStop = false;
            this.DesorpVolNormalCalTextBox.Text = "0";
            // 
            // DesorpVolNormalTextBox
            // 
            this.DesorpVolNormalTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesorpVolNormalTextBox.Location = new System.Drawing.Point(213, 15);
            this.DesorpVolNormalTextBox.Name = "DesorpVolNormalTextBox";
            this.DesorpVolNormalTextBox.PlaceholderText = "常压解吸体积";
            this.DesorpVolNormalTextBox.Size = new System.Drawing.Size(155, 35);
            this.DesorpVolNormalTextBox.TabIndex = 1;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label89.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label89.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label89.Location = new System.Drawing.Point(9, 145);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(207, 16);
            this.label89.TabIndex = 22;
            this.label89.Text = " 第 一 份 煤 样 重 量(g):";
            // 
            // tabPage3TemporarySavingButton
            // 
            this.tabPage3TemporarySavingButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tabPage3TemporarySavingButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage3TemporarySavingButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("tabPage3TemporarySavingButton.ButtonImage")));
            this.tabPage3TemporarySavingButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.tabPage3TemporarySavingButton.FlatAppearance.BorderSize = 0;
            this.tabPage3TemporarySavingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabPage3TemporarySavingButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage3TemporarySavingButton.HoverColor = System.Drawing.Color.LightBlue;
            this.tabPage3TemporarySavingButton.Location = new System.Drawing.Point(68, 483);
            this.tabPage3TemporarySavingButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.tabPage3TemporarySavingButton.Name = "tabPage3TemporarySavingButton";
            this.tabPage3TemporarySavingButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage3TemporarySavingButton.Radius = 15;
            this.tabPage3TemporarySavingButton.Size = new System.Drawing.Size(116, 42);
            this.tabPage3TemporarySavingButton.TabIndex = 1007;
            this.tabPage3TemporarySavingButton.Text = "     临时保存";
            this.tabPage3TemporarySavingButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabPage3TemporarySavingButton.UseVisualStyleBackColor = false;
            // 
            // label83
            // 
            this.label83.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label83.AutoSize = true;
            this.label83.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label83.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(239)))));
            this.label83.Location = new System.Drawing.Point(3, 4);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(178, 20);
            this.label83.TabIndex = 26;
            this.label83.Text = "实验室解吸测试->";
            // 
            // tabPage3RecoverDataButton
            // 
            this.tabPage3RecoverDataButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tabPage3RecoverDataButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage3RecoverDataButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("tabPage3RecoverDataButton.ButtonImage")));
            this.tabPage3RecoverDataButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.tabPage3RecoverDataButton.FlatAppearance.BorderSize = 0;
            this.tabPage3RecoverDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabPage3RecoverDataButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage3RecoverDataButton.HoverColor = System.Drawing.Color.LightBlue;
            this.tabPage3RecoverDataButton.Location = new System.Drawing.Point(197, 483);
            this.tabPage3RecoverDataButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.tabPage3RecoverDataButton.Name = "tabPage3RecoverDataButton";
            this.tabPage3RecoverDataButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage3RecoverDataButton.Radius = 15;
            this.tabPage3RecoverDataButton.Size = new System.Drawing.Size(116, 42);
            this.tabPage3RecoverDataButton.TabIndex = 1008;
            this.tabPage3RecoverDataButton.Text = "     恢复数据";
            this.tabPage3RecoverDataButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabPage3RecoverDataButton.UseVisualStyleBackColor = false;
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.ForeColor = System.Drawing.Color.Red;
            this.label101.Location = new System.Drawing.Point(134, 107);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(0, 12);
            this.label101.TabIndex = 30;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label82.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(239)))));
            this.label82.Location = new System.Drawing.Point(3, 107);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(199, 20);
            this.label82.TabIndex = 27;
            this.label82.Text = "密封粉碎解吸测试->";
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label121.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label121.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label121.Location = new System.Drawing.Point(9, 313);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(207, 16);
            this.label121.TabIndex = 33;
            this.label121.Text = "第一份煤样解吸校准值(ml):";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label22.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(150)))), ((int)(((byte)(241)))));
            this.label22.Location = new System.Drawing.Point(17, 59);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(199, 16);
            this.label22.TabIndex = 32;
            this.label22.Text = "       解 吸 校 准 (ml):";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label87.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label87.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label87.Location = new System.Drawing.Point(9, 270);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(207, 16);
            this.label87.TabIndex = 20;
            this.label87.Text = "    第二份煤样解吸量(ml):";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label85.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label85.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label85.Location = new System.Drawing.Point(9, 186);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(207, 16);
            this.label85.TabIndex = 17;
            this.label85.Text = " 第 二 份 煤 样 重 量(g):";
            // 
            // LabDesorbButton
            // 
            this.LabDesorbButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LabDesorbButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("LabDesorbButton.ButtonImage")));
            this.LabDesorbButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.LabDesorbButton.FlatAppearance.BorderSize = 0;
            this.LabDesorbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabDesorbButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabDesorbButton.HoverColor = System.Drawing.Color.LightBlue;
            this.LabDesorbButton.Location = new System.Drawing.Point(108, 425);
            this.LabDesorbButton.Name = "LabDesorbButton";
            this.LabDesorbButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LabDesorbButton.Radius = 15;
            this.LabDesorbButton.Size = new System.Drawing.Size(172, 42);
            this.LabDesorbButton.TabIndex = 1001;
            this.LabDesorbButton.Text = "      计    算";
            this.LabDesorbButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabDesorbButton.UseVisualStyleBackColor = false;
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label122.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label122.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label122.Location = new System.Drawing.Point(9, 355);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(207, 16);
            this.label122.TabIndex = 35;
            this.label122.Text = "第二份煤样解吸校准值(ml):";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label86.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label86.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label86.Location = new System.Drawing.Point(9, 396);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(207, 16);
            this.label86.TabIndex = 21;
            this.label86.Text = "最 终 粉 碎 解 吸 量(ml):";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label88.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label88.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label88.Location = new System.Drawing.Point(9, 229);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(207, 16);
            this.label88.TabIndex = 18;
            this.label88.Text = "    第一份煤样解吸量(ml):";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label84.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label84.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(150)))), ((int)(((byte)(241)))));
            this.label84.Location = new System.Drawing.Point(17, 27);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(199, 16);
            this.label84.TabIndex = 25;
            this.label84.Text = " 常 压 解 吸 体 积 (ml):";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label42.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.Location = new System.Drawing.Point(314, 613);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(0, 16);
            this.label42.TabIndex = 1002;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.ForeColor = System.Drawing.Color.Red;
            this.label96.Location = new System.Drawing.Point(88, -8);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(0, 12);
            this.label96.TabIndex = 29;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage4.Controls.Add(this.tabPage4DoubleBufferedPanel1);
            this.tabPage4.Location = new System.Drawing.Point(4, 96);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(775, 389);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            // 
            // tabPage4DoubleBufferedPanel1
            // 
            this.tabPage4DoubleBufferedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage4DoubleBufferedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage4DoubleBufferedPanel1.Controls.Add(this.tabPage4panel1);
            this.tabPage4DoubleBufferedPanel1.Controls.Add(this.tabPage4DoubleBufferedFlowLayoutPanel1);
            this.tabPage4DoubleBufferedPanel1.Location = new System.Drawing.Point(0, 0);
            this.tabPage4DoubleBufferedPanel1.Name = "tabPage4DoubleBufferedPanel1";
            this.tabPage4DoubleBufferedPanel1.Size = new System.Drawing.Size(776, 387);
            this.tabPage4DoubleBufferedPanel1.TabIndex = 1003;
            // 
            // tabPage4panel1
            // 
            this.tabPage4panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage4panel1.Location = new System.Drawing.Point(628, 87);
            this.tabPage4panel1.Name = "tabPage4panel1";
            this.tabPage4panel1.Size = new System.Drawing.Size(77, 100);
            this.tabPage4panel1.TabIndex = 1011;
            // 
            // tabPage4DoubleBufferedFlowLayoutPanel1
            // 
            this.tabPage4DoubleBufferedFlowLayoutPanel1.AutoScroll = true;
            this.tabPage4DoubleBufferedFlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage4DoubleBufferedFlowLayoutPanel1.Controls.Add(this.groupBox3);
            this.tabPage4DoubleBufferedFlowLayoutPanel1.Controls.Add(this.groupBox1);
            this.tabPage4DoubleBufferedFlowLayoutPanel1.Location = new System.Drawing.Point(14, 17);
            this.tabPage4DoubleBufferedFlowLayoutPanel1.Name = "tabPage4DoubleBufferedFlowLayoutPanel1";
            this.tabPage4DoubleBufferedFlowLayoutPanel1.Size = new System.Drawing.Size(530, 306);
            this.tabPage4DoubleBufferedFlowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.NonDesorpGasQtyTextBox);
            this.groupBox3.Controls.Add(this.PorosityTextBox);
            this.groupBox3.Controls.Add(this.TrueDensityTextBox);
            this.groupBox3.Controls.Add(this.AppDensityTextBox);
            this.groupBox3.Controls.Add(this.VadTextBox);
            this.groupBox3.Controls.Add(this.AadTextBox);
            this.groupBox3.Controls.Add(this.MadTextBox);
            this.groupBox3.Controls.Add(this.AdsorpConstBTextBox);
            this.groupBox3.Controls.Add(this.AdsorpConstATextBox);
            this.groupBox3.Controls.Add(this.PorosityCheckBox);
            this.groupBox3.Controls.Add(this.TrueDensityCheckBox);
            this.groupBox3.Controls.Add(this.NonDesorpGasQtyCheckBox);
            this.groupBox3.Controls.Add(this.VadCheckBox);
            this.groupBox3.Controls.Add(this.AppDensityCheckBox);
            this.groupBox3.Controls.Add(this.AadCheckBox);
            this.groupBox3.Controls.Add(this.MadCheckBox);
            this.groupBox3.Controls.Add(this.AdsorpConstBCheckBox);
            this.groupBox3.Controls.Add(this.AdsorpConstACheckBox);
            this.groupBox3.Controls.Add(this.WcOutCheckBox);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(453, 592);
            this.groupBox3.TabIndex = 61;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "不可解吸瓦斯量";
            // 
            // NonDesorpGasQtyTextBox
            // 
            this.NonDesorpGasQtyTextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.NonDesorpGasQtyTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NonDesorpGasQtyTextBox.Location = new System.Drawing.Point(310, 551);
            this.NonDesorpGasQtyTextBox.Name = "NonDesorpGasQtyTextBox";
            this.NonDesorpGasQtyTextBox.PlaceholderText = "";
            this.NonDesorpGasQtyTextBox.ReadOnly = true;
            this.NonDesorpGasQtyTextBox.SelectionStart = 1;
            this.NonDesorpGasQtyTextBox.Size = new System.Drawing.Size(102, 35);
            this.NonDesorpGasQtyTextBox.TabIndex = 1019;
            this.NonDesorpGasQtyTextBox.TabStop = false;
            this.NonDesorpGasQtyTextBox.Text = "0";
            // 
            // PorosityTextBox
            // 
            this.PorosityTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PorosityTextBox.Location = new System.Drawing.Point(233, 488);
            this.PorosityTextBox.Name = "PorosityTextBox";
            this.PorosityTextBox.PlaceholderText = "常压解吸体积";
            this.PorosityTextBox.Size = new System.Drawing.Size(179, 35);
            this.PorosityTextBox.TabIndex = 8;
            // 
            // TrueDensityTextBox
            // 
            this.TrueDensityTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TrueDensityTextBox.Location = new System.Drawing.Point(233, 427);
            this.TrueDensityTextBox.Name = "TrueDensityTextBox";
            this.TrueDensityTextBox.PlaceholderText = "常压解吸体积";
            this.TrueDensityTextBox.Size = new System.Drawing.Size(179, 35);
            this.TrueDensityTextBox.TabIndex = 7;
            // 
            // AppDensityTextBox
            // 
            this.AppDensityTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AppDensityTextBox.Location = new System.Drawing.Point(233, 359);
            this.AppDensityTextBox.Name = "AppDensityTextBox";
            this.AppDensityTextBox.PlaceholderText = "常压解吸体积";
            this.AppDensityTextBox.Size = new System.Drawing.Size(179, 35);
            this.AppDensityTextBox.TabIndex = 6;
            // 
            // VadTextBox
            // 
            this.VadTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VadTextBox.Location = new System.Drawing.Point(233, 291);
            this.VadTextBox.Name = "VadTextBox";
            this.VadTextBox.PlaceholderText = "常压解吸体积";
            this.VadTextBox.Size = new System.Drawing.Size(179, 35);
            this.VadTextBox.TabIndex = 5;
            // 
            // AadTextBox
            // 
            this.AadTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AadTextBox.Location = new System.Drawing.Point(233, 227);
            this.AadTextBox.Name = "AadTextBox";
            this.AadTextBox.PlaceholderText = "常压解吸体积";
            this.AadTextBox.Size = new System.Drawing.Size(179, 35);
            this.AadTextBox.TabIndex = 4;
            // 
            // MadTextBox
            // 
            this.MadTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MadTextBox.Location = new System.Drawing.Point(233, 167);
            this.MadTextBox.Name = "MadTextBox";
            this.MadTextBox.PlaceholderText = "常压解吸体积";
            this.MadTextBox.Size = new System.Drawing.Size(179, 35);
            this.MadTextBox.TabIndex = 3;
            // 
            // AdsorpConstBTextBox
            // 
            this.AdsorpConstBTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AdsorpConstBTextBox.Location = new System.Drawing.Point(233, 96);
            this.AdsorpConstBTextBox.Name = "AdsorpConstBTextBox";
            this.AdsorpConstBTextBox.PlaceholderText = "常压解吸体积";
            this.AdsorpConstBTextBox.Size = new System.Drawing.Size(179, 35);
            this.AdsorpConstBTextBox.TabIndex = 2;
            // 
            // AdsorpConstATextBox
            // 
            this.AdsorpConstATextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AdsorpConstATextBox.Location = new System.Drawing.Point(233, 38);
            this.AdsorpConstATextBox.Name = "AdsorpConstATextBox";
            this.AdsorpConstATextBox.PlaceholderText = "常压解吸体积";
            this.AdsorpConstATextBox.Size = new System.Drawing.Size(179, 35);
            this.AdsorpConstATextBox.TabIndex = 1;
            // 
            // PorosityCheckBox
            // 
            this.PorosityCheckBox.AutoSize = true;
            this.PorosityCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.PorosityCheckBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PorosityCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.PorosityCheckBox.Location = new System.Drawing.Point(76, 503);
            this.PorosityCheckBox.Name = "PorosityCheckBox";
            this.PorosityCheckBox.Size = new System.Drawing.Size(162, 20);
            this.PorosityCheckBox.TabIndex = 64;
            this.PorosityCheckBox.TabStop = false;
            this.PorosityCheckBox.Text = "孔  隙  率 (K/%):";
            this.PorosityCheckBox.UseVisualStyleBackColor = false;
            // 
            // TrueDensityCheckBox
            // 
            this.TrueDensityCheckBox.AutoSize = true;
            this.TrueDensityCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.TrueDensityCheckBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TrueDensityCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.TrueDensityCheckBox.Location = new System.Drawing.Point(76, 436);
            this.TrueDensityCheckBox.Name = "TrueDensityCheckBox";
            this.TrueDensityCheckBox.Size = new System.Drawing.Size(162, 20);
            this.TrueDensityCheckBox.TabIndex = 70;
            this.TrueDensityCheckBox.TabStop = false;
            this.TrueDensityCheckBox.Text = "真 密 度 (g/cm³):";
            this.TrueDensityCheckBox.UseVisualStyleBackColor = false;
            // 
            // NonDesorpGasQtyCheckBox
            // 
            this.NonDesorpGasQtyCheckBox.AutoSize = true;
            this.NonDesorpGasQtyCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.NonDesorpGasQtyCheckBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NonDesorpGasQtyCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.NonDesorpGasQtyCheckBox.Location = new System.Drawing.Point(76, 559);
            this.NonDesorpGasQtyCheckBox.Name = "NonDesorpGasQtyCheckBox";
            this.NonDesorpGasQtyCheckBox.Size = new System.Drawing.Size(234, 20);
            this.NonDesorpGasQtyCheckBox.TabIndex = 67;
            this.NonDesorpGasQtyCheckBox.TabStop = false;
            this.NonDesorpGasQtyCheckBox.Text = "不可解吸瓦斯量 [Wc(m³/t)]:";
            this.NonDesorpGasQtyCheckBox.UseVisualStyleBackColor = false;
            // 
            // VadCheckBox
            // 
            this.VadCheckBox.AutoSize = true;
            this.VadCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.VadCheckBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VadCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.VadCheckBox.Location = new System.Drawing.Point(76, 303);
            this.VadCheckBox.Name = "VadCheckBox";
            this.VadCheckBox.Size = new System.Drawing.Size(162, 20);
            this.VadCheckBox.TabIndex = 66;
            this.VadCheckBox.TabStop = false;
            this.VadCheckBox.Text = "挥 发 分 (Vad/%):";
            this.VadCheckBox.UseVisualStyleBackColor = false;
            // 
            // AppDensityCheckBox
            // 
            this.AppDensityCheckBox.AutoSize = true;
            this.AppDensityCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AppDensityCheckBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AppDensityCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.AppDensityCheckBox.Location = new System.Drawing.Point(76, 370);
            this.AppDensityCheckBox.Name = "AppDensityCheckBox";
            this.AppDensityCheckBox.Size = new System.Drawing.Size(162, 20);
            this.AppDensityCheckBox.TabIndex = 65;
            this.AppDensityCheckBox.TabStop = false;
            this.AppDensityCheckBox.Text = "视相对密度  (γ):";
            this.AppDensityCheckBox.UseVisualStyleBackColor = false;
            // 
            // AadCheckBox
            // 
            this.AadCheckBox.AutoSize = true;
            this.AadCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AadCheckBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AadCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.AadCheckBox.Location = new System.Drawing.Point(76, 235);
            this.AadCheckBox.Name = "AadCheckBox";
            this.AadCheckBox.Size = new System.Drawing.Size(162, 20);
            this.AadCheckBox.TabIndex = 63;
            this.AadCheckBox.TabStop = false;
            this.AadCheckBox.Text = "灰     分(Aad/%):";
            this.AadCheckBox.UseVisualStyleBackColor = false;
            // 
            // MadCheckBox
            // 
            this.MadCheckBox.AutoSize = true;
            this.MadCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.MadCheckBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MadCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.MadCheckBox.Location = new System.Drawing.Point(76, 171);
            this.MadCheckBox.Name = "MadCheckBox";
            this.MadCheckBox.Size = new System.Drawing.Size(162, 20);
            this.MadCheckBox.TabIndex = 62;
            this.MadCheckBox.TabStop = false;
            this.MadCheckBox.Text = "水     分(Mad/%):";
            this.MadCheckBox.UseVisualStyleBackColor = false;
            // 
            // AdsorpConstBCheckBox
            // 
            this.AdsorpConstBCheckBox.AutoSize = true;
            this.AdsorpConstBCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AdsorpConstBCheckBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AdsorpConstBCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.AdsorpConstBCheckBox.Location = new System.Drawing.Point(76, 106);
            this.AdsorpConstBCheckBox.Name = "AdsorpConstBCheckBox";
            this.AdsorpConstBCheckBox.Size = new System.Drawing.Size(158, 20);
            this.AdsorpConstBCheckBox.TabIndex = 61;
            this.AdsorpConstBCheckBox.TabStop = false;
            this.AdsorpConstBCheckBox.Text = "吸附常数b(MPa⁻¹):";
            this.AdsorpConstBCheckBox.UseVisualStyleBackColor = false;
            // 
            // AdsorpConstACheckBox
            // 
            this.AdsorpConstACheckBox.AutoSize = true;
            this.AdsorpConstACheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AdsorpConstACheckBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AdsorpConstACheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.AdsorpConstACheckBox.Location = new System.Drawing.Point(76, 43);
            this.AdsorpConstACheckBox.Name = "AdsorpConstACheckBox";
            this.AdsorpConstACheckBox.Size = new System.Drawing.Size(162, 20);
            this.AdsorpConstACheckBox.TabIndex = 10;
            this.AdsorpConstACheckBox.TabStop = false;
            this.AdsorpConstACheckBox.Text = "吸附常数a(cm³/g):";
            this.AdsorpConstACheckBox.UseVisualStyleBackColor = false;
            // 
            // WcOutCheckBox
            // 
            this.WcOutCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.WcOutCheckBox.AutoSize = true;
            this.WcOutCheckBox.Enabled = false;
            this.WcOutCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WcOutCheckBox.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WcOutCheckBox.Image = global::GasFormsApp.Properties.Resources.打叉;
            this.WcOutCheckBox.Location = new System.Drawing.Point(20, 28);
            this.WcOutCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.WcOutCheckBox.Name = "WcOutCheckBox";
            this.WcOutCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WcOutCheckBox.Size = new System.Drawing.Size(38, 38);
            this.WcOutCheckBox.TabIndex = 10;
            this.WcOutCheckBox.TabStop = false;
            this.WcOutCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WcOutCheckBox.UseVisualStyleBackColor = true;
            this.WcOutCheckBox.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.P_TextBox);
            this.groupBox1.Controls.Add(this.W_TextBox);
            this.groupBox1.Controls.Add(this.Wc_TextBox);
            this.groupBox1.Controls.Add(this.Wa_TextBox);
            this.groupBox1.Controls.Add(this.W3_TextBox);
            this.groupBox1.Controls.Add(this.W2_TextBox);
            this.groupBox1.Controls.Add(this.W1_TextBox);
            this.groupBox1.Controls.Add(this.tabPage4TemporarySavingButton);
            this.groupBox1.Controls.Add(this.tabPage4RecoverDataButton);
            this.groupBox1.Controls.Add(this.label95);
            this.groupBox1.Controls.Add(this.ExpCalcButton);
            this.groupBox1.Controls.Add(this.label94);
            this.groupBox1.Controls.Add(this.P_CheckBox);
            this.groupBox1.Controls.Add(this.label93);
            this.groupBox1.Controls.Add(this.label92);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label91);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(227)))), ((int)(((byte)(202)))));
            this.groupBox1.Location = new System.Drawing.Point(3, 601);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 592);
            this.groupBox1.TabIndex = 1004;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "实验结果：";
            // 
            // P_TextBox
            // 
            this.P_TextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.P_TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.P_TextBox.Location = new System.Drawing.Point(238, 421);
            this.P_TextBox.Name = "P_TextBox";
            this.P_TextBox.PlaceholderText = "";
            this.P_TextBox.ReadOnly = true;
            this.P_TextBox.SelectionStart = 1;
            this.P_TextBox.Size = new System.Drawing.Size(179, 35);
            this.P_TextBox.TabIndex = 1018;
            this.P_TextBox.TabStop = false;
            this.P_TextBox.Text = "0";
            // 
            // W_TextBox
            // 
            this.W_TextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.W_TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.W_TextBox.Location = new System.Drawing.Point(238, 368);
            this.W_TextBox.Name = "W_TextBox";
            this.W_TextBox.PlaceholderText = "";
            this.W_TextBox.ReadOnly = true;
            this.W_TextBox.SelectionStart = 1;
            this.W_TextBox.Size = new System.Drawing.Size(179, 35);
            this.W_TextBox.TabIndex = 1017;
            this.W_TextBox.TabStop = false;
            this.W_TextBox.Text = "0";
            // 
            // Wc_TextBox
            // 
            this.Wc_TextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.Wc_TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Wc_TextBox.Location = new System.Drawing.Point(238, 306);
            this.Wc_TextBox.Name = "Wc_TextBox";
            this.Wc_TextBox.PlaceholderText = "";
            this.Wc_TextBox.ReadOnly = true;
            this.Wc_TextBox.SelectionStart = 1;
            this.Wc_TextBox.Size = new System.Drawing.Size(179, 35);
            this.Wc_TextBox.TabIndex = 1016;
            this.Wc_TextBox.TabStop = false;
            this.Wc_TextBox.Text = "0";
            // 
            // Wa_TextBox
            // 
            this.Wa_TextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.Wa_TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Wa_TextBox.Location = new System.Drawing.Point(238, 242);
            this.Wa_TextBox.Name = "Wa_TextBox";
            this.Wa_TextBox.PlaceholderText = "";
            this.Wa_TextBox.ReadOnly = true;
            this.Wa_TextBox.SelectionStart = 1;
            this.Wa_TextBox.Size = new System.Drawing.Size(179, 35);
            this.Wa_TextBox.TabIndex = 1015;
            this.Wa_TextBox.TabStop = false;
            this.Wa_TextBox.Text = "0";
            // 
            // W3_TextBox
            // 
            this.W3_TextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.W3_TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.W3_TextBox.Location = new System.Drawing.Point(238, 176);
            this.W3_TextBox.Name = "W3_TextBox";
            this.W3_TextBox.PlaceholderText = "";
            this.W3_TextBox.ReadOnly = true;
            this.W3_TextBox.SelectionStart = 1;
            this.W3_TextBox.Size = new System.Drawing.Size(179, 35);
            this.W3_TextBox.TabIndex = 1014;
            this.W3_TextBox.TabStop = false;
            this.W3_TextBox.Text = "0";
            // 
            // W2_TextBox
            // 
            this.W2_TextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.W2_TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.W2_TextBox.Location = new System.Drawing.Point(238, 106);
            this.W2_TextBox.Name = "W2_TextBox";
            this.W2_TextBox.PlaceholderText = "";
            this.W2_TextBox.ReadOnly = true;
            this.W2_TextBox.SelectionStart = 1;
            this.W2_TextBox.Size = new System.Drawing.Size(179, 35);
            this.W2_TextBox.TabIndex = 1013;
            this.W2_TextBox.TabStop = false;
            this.W2_TextBox.Text = "0";
            // 
            // W1_TextBox
            // 
            this.W1_TextBox.BackColor = System.Drawing.Color.PeachPuff;
            this.W1_TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.W1_TextBox.Location = new System.Drawing.Point(238, 43);
            this.W1_TextBox.Name = "W1_TextBox";
            this.W1_TextBox.PlaceholderText = "";
            this.W1_TextBox.ReadOnly = true;
            this.W1_TextBox.SelectionStart = 1;
            this.W1_TextBox.Size = new System.Drawing.Size(179, 35);
            this.W1_TextBox.TabIndex = 1012;
            this.W1_TextBox.TabStop = false;
            this.W1_TextBox.Text = "0";
            // 
            // tabPage4TemporarySavingButton
            // 
            this.tabPage4TemporarySavingButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tabPage4TemporarySavingButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage4TemporarySavingButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("tabPage4TemporarySavingButton.ButtonImage")));
            this.tabPage4TemporarySavingButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.tabPage4TemporarySavingButton.FlatAppearance.BorderSize = 0;
            this.tabPage4TemporarySavingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabPage4TemporarySavingButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage4TemporarySavingButton.ForeColor = System.Drawing.Color.Navy;
            this.tabPage4TemporarySavingButton.HoverColor = System.Drawing.Color.LightBlue;
            this.tabPage4TemporarySavingButton.Location = new System.Drawing.Point(116, 537);
            this.tabPage4TemporarySavingButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.tabPage4TemporarySavingButton.Name = "tabPage4TemporarySavingButton";
            this.tabPage4TemporarySavingButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage4TemporarySavingButton.Radius = 15;
            this.tabPage4TemporarySavingButton.Size = new System.Drawing.Size(116, 42);
            this.tabPage4TemporarySavingButton.TabIndex = 1009;
            this.tabPage4TemporarySavingButton.Text = "     临时保存";
            this.tabPage4TemporarySavingButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabPage4TemporarySavingButton.UseVisualStyleBackColor = false;
            // 
            // tabPage4RecoverDataButton
            // 
            this.tabPage4RecoverDataButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tabPage4RecoverDataButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage4RecoverDataButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("tabPage4RecoverDataButton.ButtonImage")));
            this.tabPage4RecoverDataButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.tabPage4RecoverDataButton.FlatAppearance.BorderSize = 0;
            this.tabPage4RecoverDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabPage4RecoverDataButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage4RecoverDataButton.ForeColor = System.Drawing.Color.Navy;
            this.tabPage4RecoverDataButton.HoverColor = System.Drawing.Color.LightBlue;
            this.tabPage4RecoverDataButton.Location = new System.Drawing.Point(245, 537);
            this.tabPage4RecoverDataButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.tabPage4RecoverDataButton.Name = "tabPage4RecoverDataButton";
            this.tabPage4RecoverDataButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage4RecoverDataButton.Radius = 15;
            this.tabPage4RecoverDataButton.Size = new System.Drawing.Size(116, 42);
            this.tabPage4RecoverDataButton.TabIndex = 1010;
            this.tabPage4RecoverDataButton.Text = "     恢复数据";
            this.tabPage4RecoverDataButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabPage4RecoverDataButton.UseVisualStyleBackColor = false;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.BackColor = System.Drawing.Color.Transparent;
            this.label95.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label95.Location = new System.Drawing.Point(145, 52);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(79, 16);
            this.label95.TabIndex = 45;
            this.label95.Text = "W1(m³/t):";
            // 
            // ExpCalcButton
            // 
            this.ExpCalcButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ExpCalcButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("ExpCalcButton.ButtonImage")));
            this.ExpCalcButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.ExpCalcButton.FlatAppearance.BorderSize = 0;
            this.ExpCalcButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExpCalcButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExpCalcButton.ForeColor = System.Drawing.Color.Black;
            this.ExpCalcButton.HoverColor = System.Drawing.Color.LightBlue;
            this.ExpCalcButton.Location = new System.Drawing.Point(178, 481);
            this.ExpCalcButton.Name = "ExpCalcButton";
            this.ExpCalcButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ExpCalcButton.Radius = 35;
            this.ExpCalcButton.Size = new System.Drawing.Size(130, 42);
            this.ExpCalcButton.TabIndex = 1002;
            this.ExpCalcButton.Text = "      计    算";
            this.ExpCalcButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExpCalcButton.UseVisualStyleBackColor = false;
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.BackColor = System.Drawing.Color.Transparent;
            this.label94.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label94.Location = new System.Drawing.Point(145, 181);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(79, 16);
            this.label94.TabIndex = 46;
            this.label94.Text = "W3(m³/t):";
            // 
            // P_CheckBox
            // 
            this.P_CheckBox.AutoSize = true;
            this.P_CheckBox.BackColor = System.Drawing.Color.Transparent;
            this.P_CheckBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.P_CheckBox.Location = new System.Drawing.Point(140, 430);
            this.P_CheckBox.Name = "P_CheckBox";
            this.P_CheckBox.Size = new System.Drawing.Size(82, 20);
            this.P_CheckBox.TabIndex = 68;
            this.P_CheckBox.Text = "P(MPa):";
            this.P_CheckBox.UseVisualStyleBackColor = false;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.BackColor = System.Drawing.Color.Transparent;
            this.label93.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label93.Location = new System.Drawing.Point(145, 373);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(71, 16);
            this.label93.TabIndex = 49;
            this.label93.Text = "W(m³/t):";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.BackColor = System.Drawing.Color.Transparent;
            this.label92.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label92.Location = new System.Drawing.Point(145, 115);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(79, 16);
            this.label92.TabIndex = 50;
            this.label92.Text = "W2(m³/t):";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(145, 310);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 16);
            this.label21.TabIndex = 58;
            this.label21.Text = "Wc(m³/t):";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.BackColor = System.Drawing.Color.Transparent;
            this.label91.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label91.Location = new System.Drawing.Point(145, 246);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(79, 16);
            this.label91.TabIndex = 47;
            this.label91.Text = "Wa(m³/t):";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage5.Controls.Add(this.tabPage5DoubleBufferedPanel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 96);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(775, 389);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            // 
            // tabPage5DoubleBufferedPanel1
            // 
            this.tabPage5DoubleBufferedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage5DoubleBufferedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage5DoubleBufferedPanel1.Controls.Add(this.tabPage5panel18);
            this.tabPage5DoubleBufferedPanel1.Controls.Add(this.tabPage5DoubleBufferedFlowLayoutPanel2);
            this.tabPage5DoubleBufferedPanel1.Location = new System.Drawing.Point(0, 0);
            this.tabPage5DoubleBufferedPanel1.Name = "tabPage5DoubleBufferedPanel1";
            this.tabPage5DoubleBufferedPanel1.Size = new System.Drawing.Size(776, 387);
            this.tabPage5DoubleBufferedPanel1.TabIndex = 1006;
            // 
            // tabPage5panel18
            // 
            this.tabPage5panel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage5panel18.Location = new System.Drawing.Point(618, 76);
            this.tabPage5panel18.Name = "tabPage5panel18";
            this.tabPage5panel18.Size = new System.Drawing.Size(77, 100);
            this.tabPage5panel18.TabIndex = 1012;
            // 
            // tabPage5DoubleBufferedFlowLayoutPanel2
            // 
            this.tabPage5DoubleBufferedFlowLayoutPanel2.AutoScroll = true;
            this.tabPage5DoubleBufferedFlowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage5DoubleBufferedFlowLayoutPanel2.Controls.Add(this.tabPage5DoubleBufferedFlowLayoutPanel1);
            this.tabPage5DoubleBufferedFlowLayoutPanel2.Controls.Add(this.tabPage5panel11);
            this.tabPage5DoubleBufferedFlowLayoutPanel2.Controls.Add(this.tabPage5panel12);
            this.tabPage5DoubleBufferedFlowLayoutPanel2.Controls.Add(this.tabPage5panel14);
            this.tabPage5DoubleBufferedFlowLayoutPanel2.Controls.Add(this.tabPage5panel13);
            this.tabPage5DoubleBufferedFlowLayoutPanel2.Controls.Add(this.tabPage5panel16);
            this.tabPage5DoubleBufferedFlowLayoutPanel2.Controls.Add(this.tabPage5panel15);
            this.tabPage5DoubleBufferedFlowLayoutPanel2.Controls.Add(this.tabPage5panel17);
            this.tabPage5DoubleBufferedFlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.tabPage5DoubleBufferedFlowLayoutPanel2.Location = new System.Drawing.Point(25, 21);
            this.tabPage5DoubleBufferedFlowLayoutPanel2.Name = "tabPage5DoubleBufferedFlowLayoutPanel2";
            this.tabPage5DoubleBufferedFlowLayoutPanel2.Size = new System.Drawing.Size(567, 335);
            this.tabPage5DoubleBufferedFlowLayoutPanel2.TabIndex = 1006;
            // 
            // tabPage5DoubleBufferedFlowLayoutPanel1
            // 
            this.tabPage5DoubleBufferedFlowLayoutPanel1.AutoScroll = true;
            this.tabPage5DoubleBufferedFlowLayoutPanel1.AutoSize = true;
            this.tabPage5DoubleBufferedFlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tabPage5DoubleBufferedFlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.tabPage5DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage5panel1);
            this.tabPage5DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage5panel2);
            this.tabPage5DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage5panel3);
            this.tabPage5DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage5panel4);
            this.tabPage5DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage5panel5);
            this.tabPage5DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage5panel6);
            this.tabPage5DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage5panel7);
            this.tabPage5DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage5panel8);
            this.tabPage5DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage5panel9);
            this.tabPage5DoubleBufferedFlowLayoutPanel1.Controls.Add(this.tabPage5panel10);
            this.tabPage5DoubleBufferedFlowLayoutPanel1.Location = new System.Drawing.Point(155, 3);
            this.tabPage5DoubleBufferedFlowLayoutPanel1.Name = "tabPage5DoubleBufferedFlowLayoutPanel1";
            this.tabPage5DoubleBufferedFlowLayoutPanel1.Size = new System.Drawing.Size(392, 230);
            this.tabPage5DoubleBufferedFlowLayoutPanel1.TabIndex = 71;
            // 
            // tabPage5panel1
            // 
            this.tabPage5panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.tabPage5panel1.Controls.Add(this.CH4CheckBox);
            this.tabPage5panel1.Controls.Add(this.CH4TextBox);
            this.tabPage5panel1.Location = new System.Drawing.Point(8, 8);
            this.tabPage5panel1.Margin = new System.Windows.Forms.Padding(8);
            this.tabPage5panel1.Name = "tabPage5panel1";
            this.tabPage5panel1.Size = new System.Drawing.Size(180, 30);
            this.tabPage5panel1.TabIndex = 61;
            // 
            // CH4CheckBox
            // 
            this.CH4CheckBox.AutoSize = true;
            this.CH4CheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.CH4CheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CH4CheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(236)))));
            this.CH4CheckBox.Location = new System.Drawing.Point(3, 3);
            this.CH4CheckBox.Name = "CH4CheckBox";
            this.CH4CheckBox.Size = new System.Drawing.Size(93, 24);
            this.CH4CheckBox.TabIndex = 50;
            this.CH4CheckBox.TabStop = false;
            this.CH4CheckBox.Text = "CH₄(%):";
            this.CH4CheckBox.UseVisualStyleBackColor = false;
            // 
            // CH4TextBox
            // 
            this.CH4TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CH4TextBox.Location = new System.Drawing.Point(99, -2);
            this.CH4TextBox.Name = "CH4TextBox";
            this.CH4TextBox.PlaceholderText = "CH₄";
            this.CH4TextBox.Size = new System.Drawing.Size(79, 35);
            this.CH4TextBox.TabIndex = 1;
            // 
            // tabPage5panel2
            // 
            this.tabPage5panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.tabPage5panel2.Controls.Add(this.CO2CheckBox);
            this.tabPage5panel2.Controls.Add(this.CO2TextBox);
            this.tabPage5panel2.Location = new System.Drawing.Point(204, 8);
            this.tabPage5panel2.Margin = new System.Windows.Forms.Padding(8);
            this.tabPage5panel2.Name = "tabPage5panel2";
            this.tabPage5panel2.Size = new System.Drawing.Size(180, 30);
            this.tabPage5panel2.TabIndex = 62;
            // 
            // CO2CheckBox
            // 
            this.CO2CheckBox.AutoSize = true;
            this.CO2CheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CO2CheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(236)))));
            this.CO2CheckBox.Location = new System.Drawing.Point(3, 3);
            this.CO2CheckBox.Name = "CO2CheckBox";
            this.CO2CheckBox.Size = new System.Drawing.Size(93, 24);
            this.CO2CheckBox.TabIndex = 54;
            this.CO2CheckBox.TabStop = false;
            this.CO2CheckBox.Text = "CO₂(%):";
            this.CO2CheckBox.UseVisualStyleBackColor = true;
            // 
            // CO2TextBox
            // 
            this.CO2TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CO2TextBox.Location = new System.Drawing.Point(99, -2);
            this.CO2TextBox.Name = "CO2TextBox";
            this.CO2TextBox.PlaceholderText = "CO₂";
            this.CO2TextBox.Size = new System.Drawing.Size(79, 35);
            this.CO2TextBox.TabIndex = 2;
            // 
            // tabPage5panel3
            // 
            this.tabPage5panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.tabPage5panel3.Controls.Add(this.N2CheckBox);
            this.tabPage5panel3.Controls.Add(this.N2TextBox);
            this.tabPage5panel3.Location = new System.Drawing.Point(8, 54);
            this.tabPage5panel3.Margin = new System.Windows.Forms.Padding(8);
            this.tabPage5panel3.Name = "tabPage5panel3";
            this.tabPage5panel3.Size = new System.Drawing.Size(180, 30);
            this.tabPage5panel3.TabIndex = 63;
            // 
            // N2CheckBox
            // 
            this.N2CheckBox.AutoSize = true;
            this.N2CheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.N2CheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(236)))));
            this.N2CheckBox.Location = new System.Drawing.Point(3, 3);
            this.N2CheckBox.Name = "N2CheckBox";
            this.N2CheckBox.Size = new System.Drawing.Size(83, 24);
            this.N2CheckBox.TabIndex = 58;
            this.N2CheckBox.TabStop = false;
            this.N2CheckBox.Text = "N₂(%):";
            this.N2CheckBox.UseVisualStyleBackColor = true;
            // 
            // N2TextBox
            // 
            this.N2TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.N2TextBox.Location = new System.Drawing.Point(99, -2);
            this.N2TextBox.Name = "N2TextBox";
            this.N2TextBox.PlaceholderText = "N₂";
            this.N2TextBox.Size = new System.Drawing.Size(79, 35);
            this.N2TextBox.TabIndex = 3;
            // 
            // tabPage5panel4
            // 
            this.tabPage5panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.tabPage5panel4.Controls.Add(this.O2CheckBox);
            this.tabPage5panel4.Controls.Add(this.O2TextBox);
            this.tabPage5panel4.Location = new System.Drawing.Point(204, 54);
            this.tabPage5panel4.Margin = new System.Windows.Forms.Padding(8);
            this.tabPage5panel4.Name = "tabPage5panel4";
            this.tabPage5panel4.Size = new System.Drawing.Size(180, 30);
            this.tabPage5panel4.TabIndex = 64;
            // 
            // O2CheckBox
            // 
            this.O2CheckBox.AutoSize = true;
            this.O2CheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.O2CheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(236)))));
            this.O2CheckBox.Location = new System.Drawing.Point(3, 3);
            this.O2CheckBox.Name = "O2CheckBox";
            this.O2CheckBox.Size = new System.Drawing.Size(83, 24);
            this.O2CheckBox.TabIndex = 51;
            this.O2CheckBox.TabStop = false;
            this.O2CheckBox.Text = "O₂(%):";
            this.O2CheckBox.UseVisualStyleBackColor = true;
            // 
            // O2TextBox
            // 
            this.O2TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.O2TextBox.Location = new System.Drawing.Point(99, -2);
            this.O2TextBox.Name = "O2TextBox";
            this.O2TextBox.PlaceholderText = "O₂";
            this.O2TextBox.Size = new System.Drawing.Size(79, 35);
            this.O2TextBox.TabIndex = 4;
            // 
            // tabPage5panel5
            // 
            this.tabPage5panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.tabPage5panel5.Controls.Add(this.C2H4CheckBox);
            this.tabPage5panel5.Controls.Add(this.C2H4TextBox);
            this.tabPage5panel5.Location = new System.Drawing.Point(8, 100);
            this.tabPage5panel5.Margin = new System.Windows.Forms.Padding(8);
            this.tabPage5panel5.Name = "tabPage5panel5";
            this.tabPage5panel5.Size = new System.Drawing.Size(180, 30);
            this.tabPage5panel5.TabIndex = 65;
            // 
            // C2H4CheckBox
            // 
            this.C2H4CheckBox.AutoSize = true;
            this.C2H4CheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C2H4CheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(236)))));
            this.C2H4CheckBox.Location = new System.Drawing.Point(3, 3);
            this.C2H4CheckBox.Name = "C2H4CheckBox";
            this.C2H4CheckBox.Size = new System.Drawing.Size(98, 24);
            this.C2H4CheckBox.TabIndex = 55;
            this.C2H4CheckBox.TabStop = false;
            this.C2H4CheckBox.Text = "C₂H₄(%):";
            this.C2H4CheckBox.UseVisualStyleBackColor = true;
            // 
            // C2H4TextBox
            // 
            this.C2H4TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C2H4TextBox.Location = new System.Drawing.Point(99, -2);
            this.C2H4TextBox.Name = "C2H4TextBox";
            this.C2H4TextBox.PlaceholderText = "C₂H₄";
            this.C2H4TextBox.Size = new System.Drawing.Size(79, 35);
            this.C2H4TextBox.TabIndex = 5;
            // 
            // tabPage5panel6
            // 
            this.tabPage5panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.tabPage5panel6.Controls.Add(this.C3H8CheckBox);
            this.tabPage5panel6.Controls.Add(this.C3H8TextBox);
            this.tabPage5panel6.Location = new System.Drawing.Point(204, 100);
            this.tabPage5panel6.Margin = new System.Windows.Forms.Padding(8);
            this.tabPage5panel6.Name = "tabPage5panel6";
            this.tabPage5panel6.Size = new System.Drawing.Size(180, 30);
            this.tabPage5panel6.TabIndex = 66;
            // 
            // C3H8CheckBox
            // 
            this.C3H8CheckBox.AutoSize = true;
            this.C3H8CheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C3H8CheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(236)))));
            this.C3H8CheckBox.Location = new System.Drawing.Point(3, 3);
            this.C3H8CheckBox.Name = "C3H8CheckBox";
            this.C3H8CheckBox.Size = new System.Drawing.Size(98, 24);
            this.C3H8CheckBox.TabIndex = 59;
            this.C3H8CheckBox.TabStop = false;
            this.C3H8CheckBox.Text = "C₃H₈(%):";
            this.C3H8CheckBox.UseVisualStyleBackColor = true;
            // 
            // C3H8TextBox
            // 
            this.C3H8TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C3H8TextBox.Location = new System.Drawing.Point(99, -2);
            this.C3H8TextBox.Name = "C3H8TextBox";
            this.C3H8TextBox.PlaceholderText = "C₃H₈";
            this.C3H8TextBox.Size = new System.Drawing.Size(79, 35);
            this.C3H8TextBox.TabIndex = 6;
            // 
            // tabPage5panel7
            // 
            this.tabPage5panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.tabPage5panel7.Controls.Add(this.C2H6CheckBox);
            this.tabPage5panel7.Controls.Add(this.C2H6TextBox);
            this.tabPage5panel7.Location = new System.Drawing.Point(8, 146);
            this.tabPage5panel7.Margin = new System.Windows.Forms.Padding(8);
            this.tabPage5panel7.Name = "tabPage5panel7";
            this.tabPage5panel7.Size = new System.Drawing.Size(180, 30);
            this.tabPage5panel7.TabIndex = 67;
            // 
            // C2H6CheckBox
            // 
            this.C2H6CheckBox.AutoSize = true;
            this.C2H6CheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C2H6CheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(236)))));
            this.C2H6CheckBox.Location = new System.Drawing.Point(3, 3);
            this.C2H6CheckBox.Name = "C2H6CheckBox";
            this.C2H6CheckBox.Size = new System.Drawing.Size(98, 24);
            this.C2H6CheckBox.TabIndex = 52;
            this.C2H6CheckBox.TabStop = false;
            this.C2H6CheckBox.Text = "C₂H₆(%):";
            this.C2H6CheckBox.UseVisualStyleBackColor = true;
            // 
            // C2H6TextBox
            // 
            this.C2H6TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C2H6TextBox.Location = new System.Drawing.Point(99, -3);
            this.C2H6TextBox.Name = "C2H6TextBox";
            this.C2H6TextBox.PlaceholderText = "C₂H₆";
            this.C2H6TextBox.Size = new System.Drawing.Size(79, 35);
            this.C2H6TextBox.TabIndex = 7;
            // 
            // tabPage5panel8
            // 
            this.tabPage5panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.tabPage5panel8.Controls.Add(this.C3H6CheckBox);
            this.tabPage5panel8.Controls.Add(this.C3H6TextBox);
            this.tabPage5panel8.Location = new System.Drawing.Point(204, 146);
            this.tabPage5panel8.Margin = new System.Windows.Forms.Padding(8);
            this.tabPage5panel8.Name = "tabPage5panel8";
            this.tabPage5panel8.Size = new System.Drawing.Size(180, 30);
            this.tabPage5panel8.TabIndex = 68;
            // 
            // C3H6CheckBox
            // 
            this.C3H6CheckBox.AutoSize = true;
            this.C3H6CheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C3H6CheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(236)))));
            this.C3H6CheckBox.Location = new System.Drawing.Point(3, 3);
            this.C3H6CheckBox.Name = "C3H6CheckBox";
            this.C3H6CheckBox.Size = new System.Drawing.Size(98, 24);
            this.C3H6CheckBox.TabIndex = 56;
            this.C3H6CheckBox.TabStop = false;
            this.C3H6CheckBox.Text = "C₃H₆(%):";
            this.C3H6CheckBox.UseVisualStyleBackColor = true;
            // 
            // C3H6TextBox
            // 
            this.C3H6TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C3H6TextBox.Location = new System.Drawing.Point(99, -2);
            this.C3H6TextBox.Name = "C3H6TextBox";
            this.C3H6TextBox.PlaceholderText = "C₃H₆";
            this.C3H6TextBox.Size = new System.Drawing.Size(79, 35);
            this.C3H6TextBox.TabIndex = 8;
            // 
            // tabPage5panel9
            // 
            this.tabPage5panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.tabPage5panel9.Controls.Add(this.C2H2CheckBox);
            this.tabPage5panel9.Controls.Add(this.C2H2TextBox);
            this.tabPage5panel9.Location = new System.Drawing.Point(8, 192);
            this.tabPage5panel9.Margin = new System.Windows.Forms.Padding(8);
            this.tabPage5panel9.Name = "tabPage5panel9";
            this.tabPage5panel9.Size = new System.Drawing.Size(180, 30);
            this.tabPage5panel9.TabIndex = 69;
            // 
            // C2H2CheckBox
            // 
            this.C2H2CheckBox.AutoSize = true;
            this.C2H2CheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C2H2CheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(236)))));
            this.C2H2CheckBox.Location = new System.Drawing.Point(3, 3);
            this.C2H2CheckBox.Name = "C2H2CheckBox";
            this.C2H2CheckBox.Size = new System.Drawing.Size(98, 24);
            this.C2H2CheckBox.TabIndex = 60;
            this.C2H2CheckBox.TabStop = false;
            this.C2H2CheckBox.Text = "C₂H₂(%):";
            this.C2H2CheckBox.UseVisualStyleBackColor = true;
            // 
            // C2H2TextBox
            // 
            this.C2H2TextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C2H2TextBox.Location = new System.Drawing.Point(99, -2);
            this.C2H2TextBox.Name = "C2H2TextBox";
            this.C2H2TextBox.PlaceholderText = "C₂H₂";
            this.C2H2TextBox.Size = new System.Drawing.Size(79, 35);
            this.C2H2TextBox.TabIndex = 9;
            // 
            // tabPage5panel10
            // 
            this.tabPage5panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.tabPage5panel10.Controls.Add(this.COCheckBox);
            this.tabPage5panel10.Controls.Add(this.COTextBox);
            this.tabPage5panel10.Location = new System.Drawing.Point(204, 192);
            this.tabPage5panel10.Margin = new System.Windows.Forms.Padding(8);
            this.tabPage5panel10.Name = "tabPage5panel10";
            this.tabPage5panel10.Size = new System.Drawing.Size(180, 30);
            this.tabPage5panel10.TabIndex = 70;
            // 
            // COCheckBox
            // 
            this.COCheckBox.AutoSize = true;
            this.COCheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.COCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(236)))));
            this.COCheckBox.Location = new System.Drawing.Point(3, 3);
            this.COCheckBox.Name = "COCheckBox";
            this.COCheckBox.Size = new System.Drawing.Size(88, 24);
            this.COCheckBox.TabIndex = 53;
            this.COCheckBox.TabStop = false;
            this.COCheckBox.Text = "CO(%):";
            this.COCheckBox.UseVisualStyleBackColor = true;
            // 
            // COTextBox
            // 
            this.COTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.COTextBox.Location = new System.Drawing.Point(99, -2);
            this.COTextBox.Name = "COTextBox";
            this.COTextBox.PlaceholderText = "CO";
            this.COTextBox.Size = new System.Drawing.Size(79, 35);
            this.COTextBox.TabIndex = 10;
            // 
            // tabPage5panel11
            // 
            this.tabPage5panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage5panel11.Controls.Add(this.dateTimePicker1);
            this.tabPage5panel11.Controls.Add(this.label119);
            this.tabPage5panel11.Location = new System.Drawing.Point(180, 246);
            this.tabPage5panel11.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.tabPage5panel11.Name = "tabPage5panel11";
            this.tabPage5panel11.Size = new System.Drawing.Size(367, 32);
            this.tabPage5panel11.TabIndex = 71;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Format = "yyyy年 MM月dd日";
            this.dateTimePicker1.Location = new System.Drawing.Point(96, -2);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Placement = AntdUI.TAlignFrom.Top;
            this.dateTimePicker1.Size = new System.Drawing.Size(261, 35);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.ValueTimeHorizontal = true;
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label119.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.label119.Location = new System.Drawing.Point(3, 8);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(95, 16);
            this.label119.TabIndex = 46;
            this.label119.Text = "出报告时间:";
            // 
            // tabPage5panel12
            // 
            this.tabPage5panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage5panel12.Controls.Add(this.label5);
            this.tabPage5panel12.Controls.Add(this.dateTimePicker6);
            this.tabPage5panel12.Location = new System.Drawing.Point(180, 298);
            this.tabPage5panel12.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.tabPage5panel12.Name = "tabPage5panel12";
            this.tabPage5panel12.Size = new System.Drawing.Size(367, 32);
            this.tabPage5panel12.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 46;
            this.label5.Text = "测试时间:";
            // 
            // dateTimePicker6
            // 
            this.dateTimePicker6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker6.Format = "yyyy年 MM月dd日";
            this.dateTimePicker6.Location = new System.Drawing.Point(79, -2);
            this.dateTimePicker6.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.dateTimePicker6.Name = "dateTimePicker6";
            this.dateTimePicker6.Placement = AntdUI.TAlignFrom.Top;
            this.dateTimePicker6.Size = new System.Drawing.Size(277, 35);
            this.dateTimePicker6.TabIndex = 12;
            this.dateTimePicker6.ValueTimeHorizontal = true;
            // 
            // tabPage5panel14
            // 
            this.tabPage5panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage5panel14.Controls.Add(this.LabTestersTextBox);
            this.tabPage5panel14.Controls.Add(this.label117);
            this.tabPage5panel14.Location = new System.Drawing.Point(180, 350);
            this.tabPage5panel14.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.tabPage5panel14.Name = "tabPage5panel14";
            this.tabPage5panel14.Size = new System.Drawing.Size(367, 32);
            this.tabPage5panel14.TabIndex = 73;
            // 
            // LabTestersTextBox
            // 
            this.LabTestersTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabTestersTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabTestersTextBox.Location = new System.Drawing.Point(125, -2);
            this.LabTestersTextBox.Name = "LabTestersTextBox";
            this.LabTestersTextBox.PlaceholderText = "实验室测试人员";
            this.LabTestersTextBox.Size = new System.Drawing.Size(232, 35);
            this.LabTestersTextBox.TabIndex = 13;
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label117.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label117.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.label117.Location = new System.Drawing.Point(3, 8);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(127, 16);
            this.label117.TabIndex = 42;
            this.label117.Text = "实验室测试人员:";
            // 
            // tabPage5panel13
            // 
            this.tabPage5panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage5panel13.Controls.Add(this.DownholeTestersTextBox);
            this.tabPage5panel13.Controls.Add(this.DownholeTestersCheckBox);
            this.tabPage5panel13.Location = new System.Drawing.Point(180, 402);
            this.tabPage5panel13.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.tabPage5panel13.Name = "tabPage5panel13";
            this.tabPage5panel13.Size = new System.Drawing.Size(367, 32);
            this.tabPage5panel13.TabIndex = 72;
            // 
            // DownholeTestersTextBox
            // 
            this.DownholeTestersTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownholeTestersTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DownholeTestersTextBox.Location = new System.Drawing.Point(127, -1);
            this.DownholeTestersTextBox.Name = "DownholeTestersTextBox";
            this.DownholeTestersTextBox.PlaceholderText = "井下测试人员";
            this.DownholeTestersTextBox.Size = new System.Drawing.Size(229, 35);
            this.DownholeTestersTextBox.TabIndex = 14;
            // 
            // DownholeTestersCheckBox
            // 
            this.DownholeTestersCheckBox.AutoSize = true;
            this.DownholeTestersCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.DownholeTestersCheckBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DownholeTestersCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.DownholeTestersCheckBox.Location = new System.Drawing.Point(3, 6);
            this.DownholeTestersCheckBox.Name = "DownholeTestersCheckBox";
            this.DownholeTestersCheckBox.Size = new System.Drawing.Size(130, 20);
            this.DownholeTestersCheckBox.TabIndex = 61;
            this.DownholeTestersCheckBox.TabStop = false;
            this.DownholeTestersCheckBox.Text = "井下测试人员:";
            this.DownholeTestersCheckBox.UseVisualStyleBackColor = false;
            // 
            // tabPage5panel16
            // 
            this.tabPage5panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage5panel16.Controls.Add(this.RemarkTextBox);
            this.tabPage5panel16.Controls.Add(this.label120);
            this.tabPage5panel16.Location = new System.Drawing.Point(180, 454);
            this.tabPage5panel16.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.tabPage5panel16.Name = "tabPage5panel16";
            this.tabPage5panel16.Size = new System.Drawing.Size(367, 64);
            this.tabPage5panel16.TabIndex = 75;
            // 
            // RemarkTextBox
            // 
            this.RemarkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RemarkTextBox.AutoScroll = true;
            this.RemarkTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RemarkTextBox.Location = new System.Drawing.Point(73, 2);
            this.RemarkTextBox.Multiline = true;
            this.RemarkTextBox.Name = "RemarkTextBox";
            this.RemarkTextBox.PlaceholderText = "备注";
            this.RemarkTextBox.Size = new System.Drawing.Size(284, 60);
            this.RemarkTextBox.TabIndex = 15;
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label120.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.label120.Location = new System.Drawing.Point(3, 6);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(79, 16);
            this.label120.TabIndex = 48;
            this.label120.Text = "备   注：";
            // 
            // tabPage5panel15
            // 
            this.tabPage5panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.tabPage5panel15.Controls.Add(this.AuditorTextBox);
            this.tabPage5panel15.Controls.Add(this.label118);
            this.tabPage5panel15.Location = new System.Drawing.Point(180, 538);
            this.tabPage5panel15.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.tabPage5panel15.Name = "tabPage5panel15";
            this.tabPage5panel15.Size = new System.Drawing.Size(367, 32);
            this.tabPage5panel15.TabIndex = 74;
            // 
            // AuditorTextBox
            // 
            this.AuditorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuditorTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AuditorTextBox.Location = new System.Drawing.Point(79, -1);
            this.AuditorTextBox.Name = "AuditorTextBox";
            this.AuditorTextBox.PlaceholderText = "审核人员";
            this.AuditorTextBox.Size = new System.Drawing.Size(277, 35);
            this.AuditorTextBox.TabIndex = 16;
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label118.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label118.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.label118.Location = new System.Drawing.Point(3, 8);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(79, 16);
            this.label118.TabIndex = 44;
            this.label118.Text = "审核人员:";
            // 
            // tabPage5panel17
            // 
            this.tabPage5panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.tabPage5panel17.Controls.Add(this.WPSorOfficeLabel);
            this.tabPage5panel17.Controls.Add(this.tabPage5TemporarySavingButton);
            this.tabPage5panel17.Controls.Add(this.tabPage5RecoverDataButton);
            this.tabPage5panel17.Controls.Add(this.GenReportButton);
            this.tabPage5panel17.Controls.Add(this.GenRecordButton);
            this.tabPage5panel17.Controls.Add(this.SaveButton);
            this.tabPage5panel17.Location = new System.Drawing.Point(180, 583);
            this.tabPage5panel17.Name = "tabPage5panel17";
            this.tabPage5panel17.Size = new System.Drawing.Size(367, 134);
            this.tabPage5panel17.TabIndex = 76;
            // 
            // WPSorOfficeLabel
            // 
            this.WPSorOfficeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WPSorOfficeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WPSorOfficeLabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WPSorOfficeLabel.ForeColor = System.Drawing.Color.White;
            this.WPSorOfficeLabel.Location = new System.Drawing.Point(4, 68);
            this.WPSorOfficeLabel.Name = "WPSorOfficeLabel";
            this.WPSorOfficeLabel.Size = new System.Drawing.Size(116, 42);
            this.WPSorOfficeLabel.TabIndex = 1013;
            this.WPSorOfficeLabel.Text = "WPS";
            this.WPSorOfficeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage5TemporarySavingButton
            // 
            this.tabPage5TemporarySavingButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tabPage5TemporarySavingButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage5TemporarySavingButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("tabPage5TemporarySavingButton.ButtonImage")));
            this.tabPage5TemporarySavingButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.tabPage5TemporarySavingButton.FlatAppearance.BorderSize = 0;
            this.tabPage5TemporarySavingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabPage5TemporarySavingButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage5TemporarySavingButton.ForeColor = System.Drawing.Color.Navy;
            this.tabPage5TemporarySavingButton.HoverColor = System.Drawing.Color.LightBlue;
            this.tabPage5TemporarySavingButton.Location = new System.Drawing.Point(125, 68);
            this.tabPage5TemporarySavingButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.tabPage5TemporarySavingButton.Name = "tabPage5TemporarySavingButton";
            this.tabPage5TemporarySavingButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage5TemporarySavingButton.Radius = 15;
            this.tabPage5TemporarySavingButton.Size = new System.Drawing.Size(116, 42);
            this.tabPage5TemporarySavingButton.TabIndex = 1011;
            this.tabPage5TemporarySavingButton.Text = "     临时保存";
            this.tabPage5TemporarySavingButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabPage5TemporarySavingButton.UseVisualStyleBackColor = false;
            // 
            // tabPage5RecoverDataButton
            // 
            this.tabPage5RecoverDataButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tabPage5RecoverDataButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage5RecoverDataButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("tabPage5RecoverDataButton.ButtonImage")));
            this.tabPage5RecoverDataButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.tabPage5RecoverDataButton.FlatAppearance.BorderSize = 0;
            this.tabPage5RecoverDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabPage5RecoverDataButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage5RecoverDataButton.ForeColor = System.Drawing.Color.Navy;
            this.tabPage5RecoverDataButton.HoverColor = System.Drawing.Color.LightBlue;
            this.tabPage5RecoverDataButton.Location = new System.Drawing.Point(249, 68);
            this.tabPage5RecoverDataButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.tabPage5RecoverDataButton.Name = "tabPage5RecoverDataButton";
            this.tabPage5RecoverDataButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage5RecoverDataButton.Radius = 15;
            this.tabPage5RecoverDataButton.Size = new System.Drawing.Size(116, 42);
            this.tabPage5RecoverDataButton.TabIndex = 1012;
            this.tabPage5RecoverDataButton.Text = "     恢复数据";
            this.tabPage5RecoverDataButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabPage5RecoverDataButton.UseVisualStyleBackColor = false;
            // 
            // GenReportButton
            // 
            this.GenReportButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.GenReportButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("GenReportButton.ButtonImage")));
            this.GenReportButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.GenReportButton.FlatAppearance.BorderSize = 0;
            this.GenReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenReportButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GenReportButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(48)))), ((int)(((byte)(78)))));
            this.GenReportButton.HoverColor = System.Drawing.Color.LightBlue;
            this.GenReportButton.Location = new System.Drawing.Point(3, 4);
            this.GenReportButton.Name = "GenReportButton";
            this.GenReportButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GenReportButton.Radius = 35;
            this.GenReportButton.Size = new System.Drawing.Size(117, 50);
            this.GenReportButton.TabIndex = 1003;
            this.GenReportButton.Tag = "";
            this.GenReportButton.Text = "    生成报告单";
            this.GenReportButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GenReportButton.UseVisualStyleBackColor = false;
            // 
            // GenRecordButton
            // 
            this.GenRecordButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.GenRecordButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("GenRecordButton.ButtonImage")));
            this.GenRecordButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.GenRecordButton.FlatAppearance.BorderSize = 0;
            this.GenRecordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenRecordButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GenRecordButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(48)))), ((int)(((byte)(78)))));
            this.GenRecordButton.HoverColor = System.Drawing.Color.LightBlue;
            this.GenRecordButton.Location = new System.Drawing.Point(125, 4);
            this.GenRecordButton.Name = "GenRecordButton";
            this.GenRecordButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GenRecordButton.Radius = 35;
            this.GenRecordButton.Size = new System.Drawing.Size(117, 50);
            this.GenRecordButton.TabIndex = 1004;
            this.GenRecordButton.Text = "    生成记录表";
            this.GenRecordButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GenRecordButton.UseVisualStyleBackColor = false;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SaveButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("SaveButton.ButtonImage")));
            this.SaveButton.FillMode = GasFormsApp.UI.FillMode.Gradient;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(48)))), ((int)(((byte)(78)))));
            this.SaveButton.HoverColor = System.Drawing.Color.LightBlue;
            this.SaveButton.Location = new System.Drawing.Point(248, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.SaveButton.Radius = 35;
            this.SaveButton.Size = new System.Drawing.Size(117, 50);
            this.SaveButton.TabIndex = 1005;
            this.SaveButton.Text = "    保存数据";
            this.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.UseVisualStyleBackColor = false;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage6.Controls.Add(this.splitContainer1);
            this.tabPage6.Location = new System.Drawing.Point(4, 96);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(775, 389);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.splitContainer1.Panel1.Controls.Add(this.label17);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.FindMineTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabPage6panel1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(776, 387);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 37;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.label17.Location = new System.Drawing.Point(3, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 16);
            this.label17.TabIndex = 38;
            this.label17.Text = "查找矿井：";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.treeView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.Color.White;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList2;
            this.treeView1.Location = new System.Drawing.Point(1, 61);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageKey = "项目";
            treeNode1.Name = "项目";
            treeNode1.SelectedImageKey = "项目";
            treeNode1.Text = "项目";
            treeNode2.ImageKey = "矿井.png";
            treeNode2.Name = "矿井";
            treeNode2.SelectedImageKey = "矿井.png";
            treeNode2.Text = "矿井";
            treeNode3.ImageKey = "根目录";
            treeNode3.Name = "根目录";
            treeNode3.SelectedImageKey = "根目录";
            treeNode3.Text = "根目录";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(160, 325);
            this.treeView1.TabIndex = 1;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "项目");
            this.imageList2.Images.SetKeyName(1, "根目录");
            this.imageList2.Images.SetKeyName(2, "矿井");
            // 
            // FindMineTextBox
            // 
            this.FindMineTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FindMineTextBox.Location = new System.Drawing.Point(6, 29);
            this.FindMineTextBox.Name = "FindMineTextBox";
            this.FindMineTextBox.Size = new System.Drawing.Size(266, 26);
            this.FindMineTextBox.TabIndex = 37;
            // 
            // tabPage6panel1
            // 
            this.tabPage6panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage6panel1.AutoScroll = true;
            this.tabPage6panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.tabPage6panel1.Controls.Add(this.pictureBox2);
            this.tabPage6panel1.Controls.Add(this.label30);
            this.tabPage6panel1.Controls.Add(this.FindTextBox);
            this.tabPage6panel1.Controls.Add(this.ExportTheDocumentButton);
            this.tabPage6panel1.Controls.Add(this.DeleteDataButton);
            this.tabPage6panel1.Controls.Add(this.ReloadDataButton);
            this.tabPage6panel1.Location = new System.Drawing.Point(285, 0);
            this.tabPage6panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.tabPage6panel1.Name = "tabPage6panel1";
            this.tabPage6panel1.Size = new System.Drawing.Size(324, 387);
            this.tabPage6panel1.TabIndex = 37;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 300);
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.ForeColor = System.Drawing.SystemColors.Window;
            this.label30.Location = new System.Drawing.Point(29, 341);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(87, 16);
            this.label30.TabIndex = 7;
            this.label30.Text = "查找内容：";
            // 
            // FindTextBox
            // 
            this.FindTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FindTextBox.Location = new System.Drawing.Point(32, 360);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(266, 26);
            this.FindTextBox.TabIndex = 6;
            // 
            // ExportTheDocumentButton
            // 
            this.ExportTheDocumentButton.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExportTheDocumentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExportTheDocumentButton.Location = new System.Drawing.Point(3, 392);
            this.ExportTheDocumentButton.Name = "ExportTheDocumentButton";
            this.ExportTheDocumentButton.Size = new System.Drawing.Size(53, 21);
            this.ExportTheDocumentButton.TabIndex = 4;
            this.ExportTheDocumentButton.Text = "导 出 报 告      ";
            this.ExportTheDocumentButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExportTheDocumentButton.UseVisualStyleBackColor = true;
            this.ExportTheDocumentButton.Visible = false;
            // 
            // DeleteDataButton
            // 
            this.DeleteDataButton.BackColor = System.Drawing.Color.Red;
            this.DeleteDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteDataButton.Font = new System.Drawing.Font("宋体", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeleteDataButton.ForeColor = System.Drawing.Color.White;
            this.DeleteDataButton.Location = new System.Drawing.Point(32, 554);
            this.DeleteDataButton.Name = "DeleteDataButton";
            this.DeleteDataButton.Size = new System.Drawing.Size(266, 46);
            this.DeleteDataButton.TabIndex = 36;
            this.DeleteDataButton.Text = "删    除";
            this.DeleteDataButton.UseVisualStyleBackColor = false;
            // 
            // ReloadDataButton
            // 
            this.ReloadDataButton.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReloadDataButton.Location = new System.Drawing.Point(32, 415);
            this.ReloadDataButton.Name = "ReloadDataButton";
            this.ReloadDataButton.Size = new System.Drawing.Size(266, 46);
            this.ReloadDataButton.TabIndex = 2;
            this.ReloadDataButton.Text = "刷新列表";
            this.ReloadDataButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(212)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(279, 387);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "常压解吸.jpg");
            this.imageList1.Images.SetKeyName(1, "基本信息.png");
            this.imageList1.Images.SetKeyName(2, "井下解吸.jpg");
            this.imageList1.Images.SetKeyName(3, "实验结果.jpg");
            this.imageList1.Images.SetKeyName(4, "数据管理.jpg");
            this.imageList1.Images.SetKeyName(5, "数据归档.jpg");
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.label2.Font = new System.Drawing.Font("楷体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(2, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(780, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "瓦斯含量测定实验报告生成系统";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDown);
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(3, 25);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer1";
            this.shapeContainer2.Size = new System.Drawing.Size(1029, 563);
            this.shapeContainer2.TabIndex = 28;
            this.shapeContainer2.TabStop = false;
            // 
            // shapeContainer3
            // 
            this.shapeContainer3.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer3.Name = "shapeContainer2";
            this.shapeContainer3.Size = new System.Drawing.Size(1275, 713);
            this.shapeContainer3.TabIndex = 7;
            this.shapeContainer3.TabStop = false;
            // 
            // shapeContainer4
            // 
            this.shapeContainer4.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer4.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer4.Name = "shapeContainer3";
            this.shapeContainer4.Size = new System.Drawing.Size(1275, 713);
            this.shapeContainer4.TabIndex = 9;
            this.shapeContainer4.TabStop = false;
            // 
            // InputCheckTimer
            // 
            this.InputCheckTimer.Tick += new System.EventHandler(this.InputCheckTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.panel1.Location = new System.Drawing.Point(606, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 96);
            this.panel1.TabIndex = 1003;
            // 
            // tabPage6contextMenuStrip1
            // 
            this.tabPage6contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.导出矿井Excel统计表ToolStripMenuItem,
            this.导出矿井数据ToolStripMenuItem,
            this.合并矿井数据ToolStripMenuItem,
            this.删除项目ToolStripMenuItem,
            this.删除煤矿及项目ToolStripMenuItem,
            this.重命名ToolStripMenuItem});
            this.tabPage6contextMenuStrip1.Name = "tabPage6contextMenuStrip1";
            this.tabPage6contextMenuStrip1.Size = new System.Drawing.Size(190, 158);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            // 
            // 导出矿井Excel统计表ToolStripMenuItem
            // 
            this.导出矿井Excel统计表ToolStripMenuItem.Name = "导出矿井Excel统计表ToolStripMenuItem";
            this.导出矿井Excel统计表ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.导出矿井Excel统计表ToolStripMenuItem.Text = "导出矿井Excel统计表";
            // 
            // 导出矿井数据ToolStripMenuItem
            // 
            this.导出矿井数据ToolStripMenuItem.Name = "导出矿井数据ToolStripMenuItem";
            this.导出矿井数据ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.导出矿井数据ToolStripMenuItem.Text = "导出矿井数据";
            // 
            // 合并矿井数据ToolStripMenuItem
            // 
            this.合并矿井数据ToolStripMenuItem.Name = "合并矿井数据ToolStripMenuItem";
            this.合并矿井数据ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.合并矿井数据ToolStripMenuItem.Text = "合并矿井数据";
            // 
            // 删除项目ToolStripMenuItem
            // 
            this.删除项目ToolStripMenuItem.Name = "删除项目ToolStripMenuItem";
            this.删除项目ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.删除项目ToolStripMenuItem.Text = "删除项目";
            // 
            // 删除煤矿及项目ToolStripMenuItem
            // 
            this.删除煤矿及项目ToolStripMenuItem.Name = "删除煤矿及项目ToolStripMenuItem";
            this.删除煤矿及项目ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.删除煤矿及项目ToolStripMenuItem.Text = "删除煤矿及项目";
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            // 
            // tabPage6contextMenuStrip2
            // 
            this.tabPage6contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.恢复历史记录ToolStripMenuItem});
            this.tabPage6contextMenuStrip2.Name = "tabPage6contextMenuStrip1";
            this.tabPage6contextMenuStrip2.Size = new System.Drawing.Size(149, 26);
            // 
            // 恢复历史记录ToolStripMenuItem
            // 
            this.恢复历史记录ToolStripMenuItem.Name = "恢复历史记录ToolStripMenuItem";
            this.恢复历史记录ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.恢复历史记录ToolStripMenuItem.Text = "恢复历史记录";
            // 
            // ChangeColorContextMenuStrip
            // 
            this.ChangeColorContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.背景颜色ToolStripMenuItem,
            this.字体颜色ToolStripMenuItem,
            this.更换LogToolStripMenuItem,
            this.更改标题ToolStripMenuItem});
            this.ChangeColorContextMenuStrip.Name = "contextMenuStrip1";
            this.ChangeColorContextMenuStrip.Size = new System.Drawing.Size(125, 92);
            // 
            // 背景颜色ToolStripMenuItem
            // 
            this.背景颜色ToolStripMenuItem.Name = "背景颜色ToolStripMenuItem";
            this.背景颜色ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.背景颜色ToolStripMenuItem.Text = "背景颜色";
            this.背景颜色ToolStripMenuItem.Click += new System.EventHandler(this.更改背景色ToolStripMenuItem_Click);
            // 
            // 字体颜色ToolStripMenuItem
            // 
            this.字体颜色ToolStripMenuItem.Name = "字体颜色ToolStripMenuItem";
            this.字体颜色ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.字体颜色ToolStripMenuItem.Text = "字体颜色";
            this.字体颜色ToolStripMenuItem.Click += new System.EventHandler(this.更改字体颜色ToolStripMenuItem_Click);
            // 
            // 更换LogToolStripMenuItem
            // 
            this.更换LogToolStripMenuItem.Name = "更换LogToolStripMenuItem";
            this.更换LogToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.更换LogToolStripMenuItem.Text = "更换Log";
            this.更换LogToolStripMenuItem.Click += new System.EventHandler(this.更改LogToolStripMenuItem_Click);
            // 
            // 更改标题ToolStripMenuItem
            // 
            this.更改标题ToolStripMenuItem.Name = "更改标题ToolStripMenuItem";
            this.更改标题ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.更改标题ToolStripMenuItem.Text = "更改标题";
            this.更改标题ToolStripMenuItem.Click += new System.EventHandler(this.更改标题ToolStripMenuItem_Click);
            // 
            // tabPage2contextMenuStrip1
            // 
            this.tabPage2contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出图片ToolStripMenuItem});
            this.tabPage2contextMenuStrip1.Name = "tabPage6contextMenuStrip1";
            this.tabPage2contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 导出图片ToolStripMenuItem
            // 
            this.导出图片ToolStripMenuItem.Name = "导出图片ToolStripMenuItem";
            this.导出图片ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.导出图片ToolStripMenuItem.Text = "导出图片";
            // 
            // tab6Timer1
            // 
            this.tab6Timer1.Interval = 1000;
            // 
            // tabControl6PictureBox
            // 
            this.tabControl6PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("tabControl6PictureBox.Image")));
            this.tabControl6PictureBox.Location = new System.Drawing.Point(522, 83);
            this.tabControl6PictureBox.Name = "tabControl6PictureBox";
            this.tabControl6PictureBox.Size = new System.Drawing.Size(64, 64);
            this.tabControl6PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tabControl6PictureBox.TabIndex = 1009;
            this.tabControl6PictureBox.TabStop = false;
            // 
            // tabControl5PictureBox
            // 
            this.tabControl5PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("tabControl5PictureBox.Image")));
            this.tabControl5PictureBox.Location = new System.Drawing.Point(421, 83);
            this.tabControl5PictureBox.Name = "tabControl5PictureBox";
            this.tabControl5PictureBox.Size = new System.Drawing.Size(64, 64);
            this.tabControl5PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tabControl5PictureBox.TabIndex = 1008;
            this.tabControl5PictureBox.TabStop = false;
            // 
            // tabControl4PictureBox
            // 
            this.tabControl4PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("tabControl4PictureBox.Image")));
            this.tabControl4PictureBox.Location = new System.Drawing.Point(320, 83);
            this.tabControl4PictureBox.Name = "tabControl4PictureBox";
            this.tabControl4PictureBox.Size = new System.Drawing.Size(64, 64);
            this.tabControl4PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabControl4PictureBox.TabIndex = 1007;
            this.tabControl4PictureBox.TabStop = false;
            // 
            // tabControl3PictureBox
            // 
            this.tabControl3PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("tabControl3PictureBox.Image")));
            this.tabControl3PictureBox.Location = new System.Drawing.Point(219, 83);
            this.tabControl3PictureBox.Name = "tabControl3PictureBox";
            this.tabControl3PictureBox.Size = new System.Drawing.Size(64, 64);
            this.tabControl3PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabControl3PictureBox.TabIndex = 1006;
            this.tabControl3PictureBox.TabStop = false;
            // 
            // tabControl2PictureBox
            // 
            this.tabControl2PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("tabControl2PictureBox.Image")));
            this.tabControl2PictureBox.Location = new System.Drawing.Point(119, 83);
            this.tabControl2PictureBox.Name = "tabControl2PictureBox";
            this.tabControl2PictureBox.Size = new System.Drawing.Size(64, 64);
            this.tabControl2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tabControl2PictureBox.TabIndex = 1005;
            this.tabControl2PictureBox.TabStop = false;
            // 
            // tabControl1PictureBox
            // 
            this.tabControl1PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("tabControl1PictureBox.Image")));
            this.tabControl1PictureBox.Location = new System.Drawing.Point(18, 83);
            this.tabControl1PictureBox.Name = "tabControl1PictureBox";
            this.tabControl1PictureBox.Size = new System.Drawing.Size(64, 64);
            this.tabControl1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tabControl1PictureBox.TabIndex = 1004;
            this.tabControl1PictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.pictureBox1.Location = new System.Drawing.Point(2, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ToolBarMenuStrip
            // 
            this.ToolBarMenuStrip.BackColor = System.Drawing.Color.White;
            this.ToolBarMenuStrip.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ToolBarMenuStrip.ForeColor = System.Drawing.Color.Black;
            this.ToolBarMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem,
            this.账户ToolStripMenuItem});
            this.ToolBarMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolBarMenuStrip.Name = "ToolBarMenuStrip";
            this.ToolBarMenuStrip.Size = new System.Drawing.Size(784, 27);
            this.ToolBarMenuStrip.TabIndex = 1010;
            this.ToolBarMenuStrip.Text = "customMenuStrip1";
            this.ToolBarMenuStrip.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.恢复上次编辑ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.编辑ToolStripMenuItem.Text = "  编辑  ";
            // 
            // 恢复上次编辑ToolStripMenuItem
            // 
            this.恢复上次编辑ToolStripMenuItem.Name = "恢复上次编辑ToolStripMenuItem";
            this.恢复上次编辑ToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.恢复上次编辑ToolStripMenuItem.Text = "恢复上次编辑";
            // 
            // 账户ToolStripMenuItem
            // 
            this.账户ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新登录密码ToolStripMenuItem,
            this.重置产品认证密钥ToolStripMenuItem});
            this.账户ToolStripMenuItem.Name = "账户ToolStripMenuItem";
            this.账户ToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.账户ToolStripMenuItem.Text = "  账户  ";
            // 
            // 更新登录密码ToolStripMenuItem
            // 
            this.更新登录密码ToolStripMenuItem.Name = "更新登录密码ToolStripMenuItem";
            this.更新登录密码ToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.更新登录密码ToolStripMenuItem.Text = "更新登录密码";
            // 
            // 重置产品认证密钥ToolStripMenuItem
            // 
            this.重置产品认证密钥ToolStripMenuItem.Name = "重置产品认证密钥ToolStripMenuItem";
            this.重置产品认证密钥ToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.重置产品认证密钥ToolStripMenuItem.Text = "重置产品认证密钥";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ToolBarMenuStrip);
            this.Controls.Add(this.tabControl6PictureBox);
            this.Controls.Add(this.tabControl5PictureBox);
            this.Controls.Add(this.tabControl4PictureBox);
            this.Controls.Add(this.tabControl3PictureBox);
            this.Controls.Add(this.tabControl2PictureBox);
            this.Controls.Add(this.tabControl1PictureBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ToolBarMenuStrip;
            this.MinimumSize = new System.Drawing.Size(625, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "瓦斯含量测定数据分析系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1panel1.ResumeLayout(false);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.ResumeLayout(false);
            this.tabPage1DoubleBufferedFlowLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2DoubleBufferedPanel2.ResumeLayout(false);
            this.tabPage2DoubleBufferedFlowLayoutPanel1.ResumeLayout(false);
            this.tabPage2DoubleBufferedPanel1.ResumeLayout(false);
            this.tabPage2DoubleBufferedPanel1.PerformLayout();
            this.doubleBufferedPanel1.ResumeLayout(false);
            this.doubleBufferedPanel1.PerformLayout();
            this.tabPage2panel3.ResumeLayout(false);
            this.tabPage2panel3.PerformLayout();
            this.tabPage2panel4.ResumeLayout(false);
            this.tabPage2panel4.PerformLayout();
            this.tabPage2panel5.ResumeLayout(false);
            this.tabPage2panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabPage2panel6.ResumeLayout(false);
            this.tabPage2panel6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3panel1.ResumeLayout(false);
            this.tabPage3panel1.PerformLayout();
            this.tabPage3panel2.ResumeLayout(false);
            this.tabPage3panel3.ResumeLayout(false);
            this.tabPage3panel3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4DoubleBufferedPanel1.ResumeLayout(false);
            this.tabPage4DoubleBufferedFlowLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5DoubleBufferedPanel1.ResumeLayout(false);
            this.tabPage5DoubleBufferedFlowLayoutPanel2.ResumeLayout(false);
            this.tabPage5DoubleBufferedFlowLayoutPanel2.PerformLayout();
            this.tabPage5DoubleBufferedFlowLayoutPanel1.ResumeLayout(false);
            this.tabPage5panel1.ResumeLayout(false);
            this.tabPage5panel1.PerformLayout();
            this.tabPage5panel2.ResumeLayout(false);
            this.tabPage5panel2.PerformLayout();
            this.tabPage5panel3.ResumeLayout(false);
            this.tabPage5panel3.PerformLayout();
            this.tabPage5panel4.ResumeLayout(false);
            this.tabPage5panel4.PerformLayout();
            this.tabPage5panel5.ResumeLayout(false);
            this.tabPage5panel5.PerformLayout();
            this.tabPage5panel6.ResumeLayout(false);
            this.tabPage5panel6.PerformLayout();
            this.tabPage5panel7.ResumeLayout(false);
            this.tabPage5panel7.PerformLayout();
            this.tabPage5panel8.ResumeLayout(false);
            this.tabPage5panel8.PerformLayout();
            this.tabPage5panel9.ResumeLayout(false);
            this.tabPage5panel9.PerformLayout();
            this.tabPage5panel10.ResumeLayout(false);
            this.tabPage5panel10.PerformLayout();
            this.tabPage5panel11.ResumeLayout(false);
            this.tabPage5panel11.PerformLayout();
            this.tabPage5panel12.ResumeLayout(false);
            this.tabPage5panel12.PerformLayout();
            this.tabPage5panel14.ResumeLayout(false);
            this.tabPage5panel14.PerformLayout();
            this.tabPage5panel13.ResumeLayout(false);
            this.tabPage5panel13.PerformLayout();
            this.tabPage5panel16.ResumeLayout(false);
            this.tabPage5panel16.PerformLayout();
            this.tabPage5panel15.ResumeLayout(false);
            this.tabPage5panel15.PerformLayout();
            this.tabPage5panel17.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage6panel1.ResumeLayout(false);
            this.tabPage6panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage6contextMenuStrip1.ResumeLayout(false);
            this.tabPage6contextMenuStrip2.ResumeLayout(false);
            this.ChangeColorContextMenuStrip.ResumeLayout(false);
            this.tabPage2contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl6PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl5PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl4PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl3PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ToolBarMenuStrip.ResumeLayout(false);
            this.ToolBarMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Label label101;
        private Label label96;
        private Label label82;
        private Label label83;
        private Label label84;
        private Label label85;
        private Label label86;
        private Label label87;
        private Label label88;
        private Label label89;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer3;
        private Label label91;
        private Label label92;
        private Label label93;
        private Label label94;
        private Label label95;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer4;
        private Label label21;
        private Label label119;
        private Label label118;
        private Label label117;
        private Label label120;
        private Label label22;
        private Label label121;
        private Label label122;
        private Timer InputCheckTimer;
        public ToolTip toolTip1;
        public CheckBox WcOutCheckBox;
        private GroupBox groupBox3;
        private TabPage tabPage6;
        public DataGridView dataGridView1;
        public Button ReloadDataButton;
        public TextBox FindTextBox;
        public PictureBox pictureBox2;
        public Button DeleteDataButton;
        public Label label30;
        public Button ExportTheDocumentButton;
        public CheckBox AdsorpConstACheckBox;
        public CheckBox VadCheckBox;
        public CheckBox AppDensityCheckBox;
        public CheckBox PorosityCheckBox;
        public CheckBox AadCheckBox;
        public CheckBox MadCheckBox;
        public CheckBox AdsorpConstBCheckBox;
        public CheckBox NonDesorpGasQtyCheckBox;
        public CheckBox C2H2CheckBox;
        public CheckBox C3H8CheckBox;
        public CheckBox N2CheckBox;
        public CheckBox C3H6CheckBox;
        public CheckBox C2H4CheckBox;
        public CheckBox CO2CheckBox;
        public CheckBox COCheckBox;
        public CheckBox C2H6CheckBox;
        public CheckBox O2CheckBox;
        public CheckBox CH4CheckBox;
        public CheckBox P_CheckBox;
        public CheckBox TrueDensityCheckBox;
        public CheckBox DownholeTestersCheckBox;
        public UI.UCButton LabDesorbButton;
        public UI.UCButton ExpCalcButton;
        public UI.UCButton GenReportButton;
        public UI.UCButton SaveButton;
        public UI.UCButton GenRecordButton;
        private PictureBox pictureBox1;
        private Label label42;
        public Panel tabPage1panel1;
        public DateTimePicker dateTimePicker3;
        public DateTimePicker dateTimePicker2;
        public Label label35;
        public Label label32;
        public DateTimePicker dateTimePicker5;
        public Label label33;
        public Label label34;
        public DateTimePicker dateTimePicker4;
        public Label label31;
        private Label label90;
        private Panel tabPage2panel4;
        private Label label27;
        private Label label29;
        private Label label28;
        private Panel tabPage2panel3;
        private Label label24;
        private Label DataNumLabel26;
        private Label DataNumLabel16;
        private Label DataNumLabel6;
        private Label DataNumLabel7;
        private Label label26;
        private Label DataNumLabel17;
        private Label label25;
        private Label DataNumLabel25;
        private Label DataNumLabel27;
        private Label DataNumLabel15;
        private Label DataNumLabel5;
        private Label DataNumLabel8;
        private Label DataNumLabel18;
        private Label DataNumLabel24;
        private Label DataNumLabel28;
        private Label DataNumLabel14;
        private Label DataNumLabel4;
        private Label DataNumLabel9;
        private Label DataNumLabel19;
        private Label DataNumLabel23;
        private Label DataNumLabel29;
        private Label DataNumLabel13;
        private Label DataNumLabel3;
        private Label DataNumLabel10;
        private Label DataNumLabel20;
        private Label DataNumLabel22;
        private Label DataNumLabel12;
        private Label DataNumLabel30;
        private Label DataNumLabel2;
        private Label DataNumLabel21;
        private Label DataNumLabel11;
        private Label DataNumLabel1;
        private Label label23;
        public PictureBox pictureBox3;
        private Label label53;
        private Label label54;
        public UI.UCButton DrawCurvesButton;
        private Label label18;
        public UI.DoubleBufferedPanel tabPage2DoubleBufferedPanel2;
        public UI.DoubleBufferedFlowLayoutPanel tabPage2DoubleBufferedFlowLayoutPanel1;
        public Panel tabPage2panel6;
        public UI.DoubleBufferedPanel tabPage2DoubleBufferedPanel1;
        private Label label2;
        public UI.UCButton BulkImportButton;
        private GroupBox groupBox1;
        public UI.DoubleBufferedPanel tabPage4DoubleBufferedPanel1;
        public UI.DoubleBufferedFlowLayoutPanel tabPage4DoubleBufferedFlowLayoutPanel1;
        private Panel tabPage5panel1;
        private Panel tabPage5panel3;
        private Panel tabPage5panel2;
        private Panel tabPage5panel5;
        private Panel tabPage5panel4;
        private Panel tabPage5panel7;
        private Panel tabPage5panel6;
        private Panel tabPage5panel9;
        private Panel tabPage5panel8;
        private Panel tabPage5panel10;
        public UI.DoubleBufferedFlowLayoutPanel tabPage5DoubleBufferedFlowLayoutPanel1;
        public UI.DoubleBufferedFlowLayoutPanel tabPage5DoubleBufferedFlowLayoutPanel2;
        public UI.DoubleBufferedPanel tabPage5DoubleBufferedPanel1;
        private Label label5;
        public Panel tabPage5panel11;
        public Panel tabPage5panel12;
        public Panel tabPage5panel13;
        public Panel tabPage5panel16;
        public Panel tabPage5panel14;
        public Panel tabPage5panel15;
        public Panel tabPage5panel17;
        private UI.DoubleBufferedPanel doubleBufferedPanel1;
        public UI.DoubleBufferedPanel tabPage2panel7;
        public UI.DoubleBufferedPanel tabPage2panel8;
        public Panel panel1;
        public System.Windows.Forms.TabControl tabControl1;
        public UI.DoubleBufferedPanel tabPage2panel9;
        public UI.DoubleBufferedPanel tabPage2panel10;
        public UI.UCButton ExportImageButton;
        public UI.UCButton tabPage2TemporarySavingButton;
        public UI.UCButton tabPage2RecoverDataButton;
        public UI.UCButton tabPage3TemporarySavingButton;
        public UI.UCButton tabPage3RecoverDataButton;
        public UI.UCButton tabPage4TemporarySavingButton;
        public UI.UCButton tabPage4RecoverDataButton;
        public UI.UCButton tabPage5TemporarySavingButton;
        public UI.UCButton tabPage5RecoverDataButton;
        private SplitContainer splitContainer1;
        private Panel tabPage6panel1;
        public TreeView treeView1;
        public ContextMenuStrip tabPage6contextMenuStrip1;
        public ToolStripMenuItem 刷新ToolStripMenuItem;
        public ContextMenuStrip tabPage6contextMenuStrip2;
        public ToolStripMenuItem 恢复历史记录ToolStripMenuItem;
        private ContextMenuStrip ChangeColorContextMenuStrip;
        private ToolStripMenuItem 背景颜色ToolStripMenuItem;
        private ToolStripMenuItem 字体颜色ToolStripMenuItem;
        private ColorDialog colorDialog1;
        private ImageList imageList2;
        public Label label17;
        public TextBox FindMineTextBox;
        private ImageList imageList1;
        private PictureBox tabControl2PictureBox;
        private PictureBox tabControl3PictureBox;
        private PictureBox tabControl4PictureBox;
        private PictureBox tabControl5PictureBox;
        private PictureBox tabControl6PictureBox;
        private PictureBox tabControl1PictureBox;
        public TabPage tabPage1;
        public TabPage tabPage2;
        public TabPage tabPage3;
        public TabPage tabPage4;
        public TabPage tabPage5;
        public Panel tabPage3panel1;
        public Panel tabPage3panel2;
        public Panel tabPage3panel3;
        public ContextMenuStrip tabPage2contextMenuStrip1;
        public ToolStripMenuItem 导出图片ToolStripMenuItem;
        public UI.UCButton DataExportButton;
        public Label WPSorOfficeLabel;
        public ToolStripMenuItem 导出矿井Excel统计表ToolStripMenuItem;
        private ToolStripMenuItem 更换LogToolStripMenuItem;
        public UI.DoubleBufferedFlowLayoutPanel tabPage1DoubleBufferedFlowLayoutPanel1;
        private Label label1;
        private Label label6;
        private Label label39;
        private Label label7;
        private Label label3;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label14;
        private Label label15;
        private Label label20;
        private Label label16;
        private Label label19;
        private Label label13;
        private Label label4;
        private Label label8;
        private Label label37;
        private Label label38;
        private Label label41;
        private Label label36;
        public UI.UCButton tabPage1TemporarySavingButton;
        public UI.UCButton tabPage1RecoverDataButton;
        public AntdUI.Panel tabPage1panel2;
        public AntdUI.Input MineNameTextBox;
        public AntdUI.Input SamplingSpotTextBox;
        public AntdUI.Input X_YTextBox;
        public AntdUI.Input BurialDepthTextBox;
        public AntdUI.Input CoalSeamTextBox;
        public AntdUI.Input UndAtmPressureTextBox;
        public AntdUI.Input UndTempTextBox;
        public AntdUI.Input LabAtmPressureTextBox;
        public AntdUI.Input LabTempTextBox;
        public AntdUI.Input MoistureSampleTextBox;
        public AntdUI.Input SampleNumTextBox;
        public AntdUI.Input RawCoalMoistureTextBox;
        public AntdUI.Input InitialVolumeTextBox;
        public AntdUI.Input SampleWeightTextBox;
        public AntdUI.Input SamplingDepthTextBox;
        public AntdUI.Input DrillInclinationTextBox;
        public AntdUI.Input AzimuthTextBox;
        public AntdUI.Input SamplingPersonnelTextBox;
        public AntdUI.Select SampleModeComboBox;
        public AntdUI.Select CoalTypeComboBox;
        public AntdUI.DatePicker SamplingTimeDateTimePicker;
        public Panel tabPage2panel1;
        public Panel tabPage2panel5;
        public Panel tabPage2panel2;
        public AntdUI.Input DesorbTextBox1;
        public AntdUI.Input DesorbTextBox10;
        public AntdUI.Input DesorbTextBox9;
        public AntdUI.Input DesorbTextBox8;
        public AntdUI.Input DesorbTextBox7;
        public AntdUI.Input DesorbTextBox6;
        public AntdUI.Input DesorbTextBox5;
        public AntdUI.Input DesorbTextBox4;
        public AntdUI.Input DesorbTextBox3;
        public AntdUI.Input DesorbTextBox2;
        public AntdUI.Input DesorbTextBox20;
        public AntdUI.Input DesorbTextBox19;
        public AntdUI.Input DesorbTextBox18;
        public AntdUI.Input DesorbTextBox17;
        public AntdUI.Input DesorbTextBox16;
        public AntdUI.Input DesorbTextBox15;
        public AntdUI.Input DesorbTextBox14;
        public AntdUI.Input DesorbTextBox13;
        public AntdUI.Input DesorbTextBox12;
        public AntdUI.Input DesorbTextBox11;
        public AntdUI.Input DesorbTextBox30;
        public AntdUI.Input DesorbTextBox29;
        public AntdUI.Input DesorbTextBox28;
        public AntdUI.Input DesorbTextBox27;
        public AntdUI.Input DesorbTextBox26;
        public AntdUI.Input DesorbTextBox25;
        public AntdUI.Input DesorbTextBox24;
        public AntdUI.Input DesorbTextBox23;
        public AntdUI.Input DesorbTextBox22;
        public AntdUI.Input DesorbTextBox21;
        public AntdUI.Input DesorbTextBox60;
        public AntdUI.Input DesorbTextBox59;
        public AntdUI.Input DesorbTextBox58;
        public AntdUI.Input DesorbTextBox57;
        public AntdUI.Input DesorbTextBox56;
        public AntdUI.Input DesorbTextBox55;
        public AntdUI.Input DesorbTextBox54;
        public AntdUI.Input DesorbTextBox53;
        public AntdUI.Input DesorbTextBox52;
        public AntdUI.Input DesorbTextBox51;
        public AntdUI.Input DesorbTextBox50;
        public AntdUI.Input DesorbTextBox49;
        public AntdUI.Input DesorbTextBox48;
        public AntdUI.Input DesorbTextBox47;
        public AntdUI.Input DesorbTextBox46;
        public AntdUI.Input DesorbTextBox45;
        public AntdUI.Input DesorbTextBox44;
        public AntdUI.Input DesorbTextBox43;
        public AntdUI.Input DesorbTextBox42;
        public AntdUI.Input DesorbTextBox41;
        public AntdUI.Input DesorbTextBox40;
        public AntdUI.Input DesorbTextBox39;
        public AntdUI.Input DesorbTextBox38;
        public AntdUI.Input DesorbTextBox37;
        public AntdUI.Input DesorbTextBox36;
        public AntdUI.Input DesorbTextBox35;
        public AntdUI.Input DesorbTextBox34;
        public AntdUI.Input DesorbTextBox33;
        public AntdUI.Input DesorbTextBox32;
        public AntdUI.Input DesorbTextBox31;
        public AntdUI.Input DataNumTextBox40;
        public AntdUI.Input DataNumTextBox39;
        public AntdUI.Input DataNumTextBox38;
        public AntdUI.Input DataNumTextBox37;
        public AntdUI.Input DataNumTextBox36;
        public AntdUI.Input DataNumTextBox35;
        public AntdUI.Input DataNumTextBox34;
        public AntdUI.Input DataNumTextBox33;
        public AntdUI.Input DataNumTextBox32;
        public AntdUI.Input DataNumTextBox31;
        public AntdUI.Input DataNumTextBox60;
        public AntdUI.Input DataNumTextBox50;
        public AntdUI.Input DataNumTextBox59;
        public AntdUI.Input DataNumTextBox49;
        public AntdUI.Input DataNumTextBox58;
        public AntdUI.Input DataNumTextBox57;
        public AntdUI.Input DataNumTextBox48;
        public AntdUI.Input DataNumTextBox56;
        public AntdUI.Input DataNumTextBox47;
        public AntdUI.Input DataNumTextBox55;
        public AntdUI.Input DataNumTextBox54;
        public AntdUI.Input DataNumTextBox46;
        public AntdUI.Input DataNumTextBox53;
        public AntdUI.Input DataNumTextBox45;
        public AntdUI.Input DataNumTextBox52;
        public AntdUI.Input DataNumTextBox51;
        public AntdUI.Input DataNumTextBox44;
        public AntdUI.Input DataNumTextBox43;
        public AntdUI.Input DataNumTextBox42;
        public AntdUI.Input DataNumTextBox41;
        public AntdUI.Select TypeOfDestructionComboBox3;
        public AntdUI.Input t0TextBox;
        public AntdUI.Input DesVolUndTextBox;
        public AntdUI.Input SampLossVolTextBox;
        public AntdUI.Input UndDesorpCalTextBox;
        public AntdUI.Input DesorpVolNormalTextBox;
        public AntdUI.Input CrushDesorpTextBox;
        public AntdUI.Input S2DesorpVolCalTextBox;
        public AntdUI.Input S1DesorpVolCalTextBox;
        public AntdUI.Input S2DesorpVolTextBox;
        public AntdUI.Input S1DesorpVolTextBox;
        public AntdUI.Input Sample2WeightTextBox;
        public AntdUI.Input Sample1WeightTextBox;
        public AntdUI.Input DesorpVolNormalCalTextBox;
        public Panel tabPage3panel4;
        public AntdUI.Input PorosityTextBox;
        public AntdUI.Input TrueDensityTextBox;
        public AntdUI.Input AppDensityTextBox;
        public AntdUI.Input VadTextBox;
        public AntdUI.Input AadTextBox;
        public AntdUI.Input MadTextBox;
        public AntdUI.Input AdsorpConstBTextBox;
        public AntdUI.Input AdsorpConstATextBox;
        public AntdUI.Input W1_TextBox;
        public AntdUI.Input Wa_TextBox;
        public AntdUI.Input W3_TextBox;
        public AntdUI.Input W2_TextBox;
        public AntdUI.Input P_TextBox;
        public AntdUI.Input W_TextBox;
        public AntdUI.Input Wc_TextBox;
        public AntdUI.Input NonDesorpGasQtyTextBox;
        public Panel tabPage4panel1;
        public AntdUI.Input CH4TextBox;
        public AntdUI.Input CO2TextBox;
        public AntdUI.Input N2TextBox;
        public AntdUI.Input O2TextBox;
        public AntdUI.Input C2H4TextBox;
        public AntdUI.Input C3H8TextBox;
        public AntdUI.Input C2H6TextBox;
        public AntdUI.Input C3H6TextBox;
        public AntdUI.Input C2H2TextBox;
        public AntdUI.Input COTextBox;
        public AntdUI.Input DownholeTestersTextBox;
        public AntdUI.Input LabTestersTextBox;
        public AntdUI.Input AuditorTextBox;
        public Panel tabPage5panel18;
        public AntdUI.Input RemarkTextBox;
        public AntdUI.DatePicker dateTimePicker6;
        public AntdUI.DatePicker dateTimePicker1;
        public Timer tab6Timer1;
        private ToolStripMenuItem 更改标题ToolStripMenuItem;
        public ToolStripMenuItem 导出矿井数据ToolStripMenuItem;
        private UI.CustomMenuStrip ToolBarMenuStrip;
        private ToolStripMenuItem 编辑ToolStripMenuItem;
        private ToolStripMenuItem 恢复上次编辑ToolStripMenuItem;
        private ToolStripMenuItem 账户ToolStripMenuItem;
        private ToolStripMenuItem 更新登录密码ToolStripMenuItem;
        private ToolStripMenuItem 重置产品认证密钥ToolStripMenuItem;
        public ToolStripMenuItem 合并矿井数据ToolStripMenuItem;
        public ToolStripMenuItem 删除项目ToolStripMenuItem;
        public ToolStripMenuItem 删除煤矿及项目ToolStripMenuItem;
        public ToolStripMenuItem 重命名ToolStripMenuItem;
    }
}