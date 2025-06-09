using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasFormsApp.WordPperation
{
    internal class BasicInfo
    {
        private MainForm _mainForm;
        InsertChart insertChart = new InsertChart();
        static string maxKey = null;

        public BasicInfo(MainForm form)
        {
            _mainForm = form;
        }
        public void ReplaceWordPlaceholders(MemoryStream memoryStream,
            string MineNameText,
            string SamplingSpotText,
            string BurialDepthText,
            string CoalSeamText,
            string SampleNumText,
            string UndAtmPressureText,
            string LabAtmPressureText,
            string UndTempText,
            string LabTempText,
            string SampleWeightText,
            string SampleModeText,
            string MoistureSampleText,
            string RawCoalMoistureText,
            string InitialVolumeText,
            string SamplingTimeText,
            string ReportTimeText)
        {
            //Console.WriteLine("用户选择了新的时间：" + mainForm.SamplingTimeText);
            // 基本信息替换
            var placeholders = new Dictionary<string, string>
            {
                {"MineName", MineNameText},//矿井名称
                {"SamplingSpot", SamplingSpotText},//取样地点
                {"SamplingTime", SamplingTimeText},//取样时间
                {"BurialDepth", BurialDepthText},//埋深
                {"CoalSeam", CoalSeamText},//煤层
                {"SampleNum", SampleNumText},//煤样编号
                {"UndAtmPressure", UndAtmPressureText},//井下大气压力（KPa）
                {"LabAtmPressure", LabAtmPressureText},//实验室大气压力（KPa）
                {"UndTemp", UndTempText},//井下环境温度(℃)
                {"LabTemp", LabTempText},//实验室温度(℃)
                {"SampleWeight", SampleWeightText},//煤样重量（g）
                {"SampleMode", SampleModeText},//取样方式
                {"MoistureSample", MoistureSampleText},//煤样水分（%）
                {"RawCoalMoisture", RawCoalMoistureText},//原煤水分（%）
                {"InitialVolume", InitialVolumeText},//量管初始体积（ml）
                {"SamplingDepth", _mainForm.SamplingDepthTextBox.Text},//取样深度（m）
                {"UgDesorpVol", Convert.ToDecimal(_mainForm.UndDesorpCalTextBox.Text).ToString("F4")},//井下解吸量W11(ml)
                {"GasLossVol", InsertChart.GetGasLossVolText()},//瓦斯损失量W12(ml)
                {"DesorpVolNormal", _mainForm.DesorpVolNormalCalTextBox.Text},//实验室常压解吸W2(ml)
                {"Sample1WeightText", _mainForm.Sample1WeightTextBox.Text},//粉碎后第1份煤样重(g)
                {"Sample2WeightText", _mainForm.Sample2WeightTextBox.Text},//粉碎后第2份煤样重(g)
                {"S1DesorpVolText", _mainForm.S1DesorpVolCalTextBox.Text},//第1份煤样解吸量-校准(ml)
                {"S2DesorpVolText", _mainForm.S2DesorpVolCalTextBox.Text},//第2份煤样解吸量-校准(ml)
                {"AdsorpConstAText", _mainForm.AdsorpConstATextBox.Text},//煤的吸附常数a值
                {"AdsorpConstBText", _mainForm.AdsorpConstBTextBox.Text},//煤的吸附常数b值
                {"MadText", _mainForm.MadTextBox.Text},//水分
                {"AadText", _mainForm.AadTextBox.Text},//灰分
                {"PorosityText", _mainForm.PorosityTextBox.Text},//孔隙率
                {"AppDensityText", _mainForm.AppDensityTextBox.Text},//视密度
                {"NonDesorpGasQtyText", _mainForm.NonDesorpGasQtyTextBox.Text},//不可解吸瓦斯量Wc
                {"VadText", _mainForm.VadTextBox.Text},//挥发分Vad
                {"W1Text", MainForm.W1.ToString("F4")},//W1
                {"W2Text", MainForm.W2.ToString("F4")},//W2
                {"W3Text", MainForm.W3.ToString("F4")},//W3
                {"WaText", MainForm.Wa.ToString("F4")},//Wa
                {"WcText", MainForm.Wc.ToString("F4")},//不可解吸瓦斯量Wc
                {"WText", MainForm.W.ToString("F4")},//W
                {"PText", MainForm.P.ToString("F4")},//P
                {"CH4Text", _mainForm.CH4TextBox.Text},//CH4
                {"CO2Text", _mainForm.CO2TextBox.Text},//CO2
                {"N2Text", _mainForm.N2TextBox.Text},//N2
                {"O2Text", _mainForm.O2TextBox.Text},//O2
                {"C2H4Text", _mainForm.C2H4TextBox.Text},//C2H4
                {"C3H8Text", _mainForm.C3H8TextBox.Text},//C3H8
                {"C2H6Text", _mainForm.C2H6TextBox.Text},//C2H6
                {"C3H6Text", _mainForm.C3H6TextBox.Text},//C3H6
                {"C2H2Text", _mainForm.C2H2TextBox.Text},//C2H2
                {"COText", _mainForm.COTextBox.Text},//CO
                {"LabTestersText", _mainForm.LabTestersTextBox.Text},//实验室测试人员
                {"AuditorText", _mainForm.AuditorTextBox.Text},//审 核 人 员
                {"ReportTimeText", ReportTimeText},//出报告时间
                {"RemarkText", _mainForm.RemarkTextBox.Text},//备注

                //以下是30分钟以后解吸时间填充
                { "T31", _mainForm.DataNumTextBox31.Text },
                { "T32", _mainForm.DataNumTextBox32.Text },
                { "T33", _mainForm.DataNumTextBox33.Text },
                { "T34", _mainForm.DataNumTextBox34.Text },
                { "T35", _mainForm.DataNumTextBox35.Text },
                { "T36", _mainForm.DataNumTextBox36.Text },
                { "T37", _mainForm.DataNumTextBox37.Text },
                { "T38", _mainForm.DataNumTextBox38.Text },
                { "T39", _mainForm.DataNumTextBox39.Text },
                { "T40", _mainForm.DataNumTextBox40.Text },
                { "T41", _mainForm.DataNumTextBox41.Text },
                { "T42", _mainForm.DataNumTextBox42.Text },
                { "T43", _mainForm.DataNumTextBox43.Text },
                { "T44", _mainForm.DataNumTextBox44.Text },
                { "T45", _mainForm.DataNumTextBox45.Text },
                { "T46", _mainForm.DataNumTextBox46.Text },
                { "T47", _mainForm.DataNumTextBox47.Text },
                { "T48", _mainForm.DataNumTextBox48.Text },
                { "T49", _mainForm.DataNumTextBox49.Text },
                { "T50", _mainForm.DataNumTextBox50.Text },
                { "T51", _mainForm.DataNumTextBox51.Text },
                { "T52", _mainForm.DataNumTextBox52.Text },
                { "T53", _mainForm.DataNumTextBox53.Text },
                { "T54", _mainForm.DataNumTextBox54.Text },
                { "T55", _mainForm.DataNumTextBox55.Text },
                { "T56", _mainForm.DataNumTextBox56.Text },
                { "T57", _mainForm.DataNumTextBox57.Text },
                { "T58", _mainForm.DataNumTextBox58.Text },
                { "T59", _mainForm.DataNumTextBox59.Text },
                { "T60", _mainForm.DataNumTextBox60.Text },

            };
            ReplacePlaceholders(memoryStream, placeholders);

            // 实验数据替换
            placeholders = new Dictionary<string, string>();
            double maxValue = double.MinValue;


            for (int i = 1; i <= 60; i++)
            {
                string key = $"D{i:000}";
                var textBox = _mainForm.Controls.Find($"DesorbTextBox{i}", true).FirstOrDefault() as TextBox;

                if (textBox != null)
                {
                    string text = textBox.Text.Trim();
                    Console.WriteLine($"获取：{text}");
                    placeholders[key] = text;

                    if (double.TryParse(text, out double val))
                    {
                        if (val > maxValue)
                        {
                            maxValue = val;
                            maxKey = key;
                        }
                    }
                }
            }
            ReplacePlaceholders(memoryStream, placeholders);
        }

        public void ReplacePlaceholders(MemoryStream memoryStream, Dictionary<string, string> placeholderValues)
        {
            try
            {
                memoryStream.Position = 0;

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(memoryStream, true))
                {
                    // 获取文档文本
                    string docText;
                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }

                    // 替换所有占位符
                    foreach (var kvp in placeholderValues)
                    {
                        docText = docText.Replace(kvp.Key, kvp.Value);
                    }

                    // 写回文档
                    using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }

                    // 保存修改后的文档
                    wordDoc.MainDocumentPart.Document.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"替换占位符时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
