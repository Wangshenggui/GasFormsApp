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
        public void ReplaceWordPlaceholders(MemoryStream memoryStream,string SamplingTimeText)
        {
            Console.WriteLine("用户选择了新的时间：" + mainForm.SamplingTimeText);
            // 基本信息替换
            var placeholders = new Dictionary<string, string>
            {
                {"MineName", mainForm.MineNameText},//矿井名称
                {"SamplingSpot", mainForm.SamplingSpotText},//取样地点
                {"SamplingTime", SamplingTimeText},//取样时间
                {"BurialDepth", mainForm.BurialDepthText},//埋深
                {"CoalSeam", mainForm.CoalSeamText},//煤层
                {"SampleNum", mainForm.SampleNumText},//煤样编号
                {"UndAtmPressure", mainForm.UndAtmPressureText},//井下大气压力（KPa）
                {"LabAtmPressure", mainForm.LabAtmPressureText},//实验室大气压力（KPa）
                {"UndTemp", mainForm.UndTempText},//井下环境温度(℃)
                {"LabTemp", mainForm.LabTempText},//实验室温度(℃)
                {"SampleWeight", mainForm.SampleWeightText},//煤样重量（g）
                {"SampleMode", mainForm.SampleModeText},//取样方式
                {"MoistureSample", mainForm.MoistureSampleText},//煤样水分（%）
                {"RawCoalMoisture", mainForm.RawCoalMoistureText},//原煤水分（%）
                {"InitialVolume", mainForm.InitialVolumeText},//量管初始体积（ml）
                {"UgDesorpVol", maxKey},//井下解吸量W11(ml)
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
                {"W1Text", mainForm.W1_Text},//W1
                {"W2Text", mainForm.W2_Text},//W2
                {"W3Text", mainForm.W3_Text},//W3
                {"WaText", mainForm.Wa_Text},//Wa
                {"WcText", mainForm.NonDesorpGasQtyText},//不可解吸瓦斯量Wc
                {"WText", mainForm.W_Text},//W
                {"PText", mainForm.P_Text},//P

            };
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
