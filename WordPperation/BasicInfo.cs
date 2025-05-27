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
        InsertChart insertChart = new InsertChart();
        MainForm mainForm = new MainForm(true);
        static string maxKey = null;

        public BasicInfo(MainForm form)
        {
            this.mainForm = form;
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
                {"UgDesorpVol", MainForm.井下解吸体积.ToString()},//井下解吸量W11(ml)
                {"GasLossVol", InsertChart.GetGasLossVolText()},//瓦斯损失量W12(ml)
                {"DesorpVolNormal", mainForm.DesorpVolNormalText},//实验室常压解吸W2(ml)
                {"Sample1WeightText", mainForm.Sample1WeightText},//粉碎后第1份煤样重(g)
                {"Sample2WeightText", mainForm.Sample2WeightText},//粉碎后第2份煤样重(g)
                {"S1DesorpVolText", mainForm.S1DesorpVolText},//第1份煤样解吸量(ml)
                {"S2DesorpVolText", mainForm.S2DesorpVolText},//第2份煤样解吸量(ml)
                {"AdsorpConstAText", mainForm.AdsorpConstAText},//煤的吸附常数a值
                {"AdsorpConstBText", mainForm.AdsorpConstBText},//煤的吸附常数b值
                {"MadText", mainForm.MadText},//水分
                {"AadText", mainForm.AadText},//灰分
                {"PorosityText", mainForm.PorosityText},//孔隙率
                {"AppDensityText", mainForm.AppDensityText},//视密度
                {"NonDesorpGasQtyText", mainForm.NonDesorpGasQtyText},//不可解吸瓦斯量Wc
                {"VadText", mainForm.VadText},//挥发分Vad
                {"W1Text", MainForm.W1.ToString("F4")},//W1
                {"W2Text", MainForm.W2.ToString("F4")},//W2
                {"W3Text", MainForm.W3.ToString("F4")},//W3
                {"WaText", MainForm.Wa.ToString("F4")},//Wa
                {"WcText", MainForm.Wc.ToString("F4")},//不可解吸瓦斯量Wc
                {"WText", MainForm.W.ToString("F4")},//W
                {"PText", MainForm.P.ToString("F4")},//P
                {"CH4Text", mainForm.CH4Text},//CH4
                {"CO2Text", mainForm.CO2Text},//CO2
                {"N2Text", mainForm.N2Text},//N2
                {"O2Text", mainForm.O2Text},//O2
                {"C2H4Text", mainForm.C2H4Text},//C2H4
                {"C3H8Text", mainForm.C3H8Text},//C3H8
                {"C2H6Text", mainForm.C2H6Text},//C2H6
                {"C3H6Text", mainForm.C3H6Text},//C3H6
                {"C2H2Text", mainForm.C2H2Text},//C2H2
                {"COText", mainForm.COText},//CO
                {"UndTestersText", mainForm.UndTestersText},//井下测试人员
                {"LabTestersText", mainForm.LabTestersText},//实验室测试人员
                {"AuditorText", mainForm.AuditorText},//审 核 人 员
                {"ReportTimeText", ReportTimeText},//出报告时间
                {"RemarkText", mainForm.RemarkText},//备注
                
            };
            Console.WriteLine($"TTTTTTTTTTTTTTTTTTTTTTTT:{MainForm.W1}");
            ReplacePlaceholders(memoryStream, placeholders);

            // 实验数据替换
            placeholders = new Dictionary<string, string>();
            double maxValue = double.MinValue;
            

            for (int i = 1; i <= 60; i++)
            {
                string key = $"D{i:000}";
                var textBox = mainForm.Controls.Find($"DesorbTextBox{i}", true).FirstOrDefault() as TextBox;

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
