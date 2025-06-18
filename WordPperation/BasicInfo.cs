using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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
                {"UgDesorpVol", Convert.ToDecimal(_mainForm.UndDesorpCalTextBox.Text).ToString("F2")},//井下解吸量W11(ml)
                {"GasLossVol", InsertChart.GetGasLossVolText()},//瓦斯损失量W12(ml)
                {"DesorpVolNormal", _mainForm.DesorpVolNormalCalTextBox.Text},//实验室常压解吸W2(ml)
                {"Sample1WeightText", _mainForm.Sample1WeightTextBox.Text},//粉碎后第1份煤样重(g)
                {"Sample2WeightText", _mainForm.Sample2WeightTextBox.Text},//粉碎后第2份煤样重(g)
                {"S1DesorpVolText", _mainForm.S1DesorpVolCalTextBox.Text},//第1份煤样解吸量-校准(ml)
                {"S2DesorpVolText", _mainForm.S2DesorpVolCalTextBox.Text},//第2份煤样解吸量-校准(ml)

                //{"AdsorpConstAText", _mainForm.AdsorpConstATextBox.Text},//煤的吸附常数a值
                //{"AdsorpConstBText", _mainForm.AdsorpConstBTextBox.Text},//煤的吸附常数b值
                //{"MadText", _mainForm.MadTextBox.Text},//水分
                //{"AadText", _mainForm.AadTextBox.Text},//灰分
                //{"PorosityText", _mainForm.PorosityTextBox.Text},//孔隙率
                //{"AppDensityText", _mainForm.AppDensityTextBox.Text},//视密度
                //{"NonDesorpGasQtyText", _mainForm.NonDesorpGasQtyTextBox.Text},//不可解吸瓦斯量Wc
                //{"VadText", _mainForm.VadTextBox.Text},//挥发分Vad

                // 使用特殊的填充方式，确保上下标正常显示
                //{ "Wc_Lab01", MainForm.Wc_Lab1 },
                //{ "Wc_Lab02", MainForm.Wc_Lab2 },
                //{ "Wc_Lab03", MainForm.Wc_Lab3 },
                //{ "Wc_Lab04", MainForm.Wc_Lab4 },
                //{ "Wc_Lab05", MainForm.Wc_Lab5 },
                //{ "Wc_Lab06", MainForm.Wc_Lab6 },
                //{ "Wc_Lab07", MainForm.Wc_Lab7 },
                //{ "Wc_Lab08", MainForm.Wc_Lab8 },

                { "Wc_Dat01", MainForm.Wc_Dat1 },
                { "Wc_Dat02", MainForm.Wc_Dat2 },
                { "Wc_Dat03", MainForm.Wc_Dat3 },
                { "Wc_Dat04", MainForm.Wc_Dat4 },
                { "Wc_Dat05", MainForm.Wc_Dat5 },
                { "Wc_Dat06", MainForm.Wc_Dat6 },
                { "Wc_Dat07", MainForm.Wc_Dat7 },
                { "Wc_Dat08", MainForm.Wc_Dat8 },
                { "Wc_Dat09", MainForm.Wc_Dat9 },




                {"W1Text", MainForm.W1.ToString("F2")},//W1
                {"W2Text", MainForm.W2.ToString("F2")},//W2
                {"W3Text", MainForm.W3.ToString("F2")},//W3
                {"WaText", MainForm.Wa.ToString("F2")},//Wa
                {"WcText", MainForm.Wc.ToString("F2")},//不可解吸瓦斯量Wc
                {"WText", MainForm.W.ToString("F2")},//W

                
                {"PText", MainForm.P_Data},//P
                {"P_Lable",MainForm.P_Lable},
                {"P_beizhu",MainForm.P_beizhu},

                //{"CH4Text", _mainForm.CH4TextBox.Text},//CH4
                //{"CO2Text", _mainForm.CO2TextBox.Text},//CO2
                //{"N2Text", _mainForm.N2TextBox.Text},//N2
                //{"O2Text", _mainForm.O2TextBox.Text},//O2
                //{"C2H4Text", _mainForm.C2H4TextBox.Text},//C2H4
                //{"C3H8Text", _mainForm.C3H8TextBox.Text},//C3H8
                //{"C2H6Text", _mainForm.C2H6TextBox.Text},//C2H6
                //{"C3H6Text", _mainForm.C3H6TextBox.Text},//C3H6
                //{"C2H2Text", _mainForm.C2H2TextBox.Text},//C2H2
                //{"COText", _mainForm.COTextBox.Text},//CO

                // 使用特殊的填充方式，确保上下标正常显示
                //{ "GasComp_Lab01", MainForm.GasComp_Lab1 },
                //{ "GasComp_Lab02", MainForm.GasComp_Lab2 },
                //{ "GasComp_Lab03", MainForm.GasComp_Lab3 },
                //{ "GasComp_Lab04", MainForm.GasComp_Lab4 },
                //{ "GasComp_Lab05", MainForm.GasComp_Lab5 },
                //{ "GasComp_Lab06", MainForm.GasComp_Lab6 },
                //{ "GasComp_Lab07", MainForm.GasComp_Lab7 },
                //{ "GasComp_Lab08", MainForm.GasComp_Lab8 },
                //{ "GasComp_Lab09", MainForm.GasComp_Lab9 },
                //{ "GasComp_Lab10", MainForm.GasComp_Lab10 },

                { "GasComp_Dat01", MainForm.GasComp_Dat1 },
                { "GasComp_Dat02", MainForm.GasComp_Dat2 },
                { "GasComp_Dat03", MainForm.GasComp_Dat3 },
                { "GasComp_Dat04", MainForm.GasComp_Dat4 },
                { "GasComp_Dat05", MainForm.GasComp_Dat5 },
                { "GasComp_Dat06", MainForm.GasComp_Dat6 },
                { "GasComp_Dat07", MainForm.GasComp_Dat7 },
                { "GasComp_Dat08", MainForm.GasComp_Dat8 },
                { "GasComp_Dat09", MainForm.GasComp_Dat9 },
                { "GasComp_Dat10", MainForm.GasComp_Dat10 },




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

                // 记录表添加的部分内容
                { "DrillInclination", _mainForm.DrillInclinationTextBox.Text },// 钻孔倾角
                { "Azimuth", _mainForm.AzimuthTextBox.Text },// 方位角
                { "DrillingEndTime", _mainForm.dateTimePicker2.Text },// 打钻结束时间
                { "CoringEndTime", _mainForm.dateTimePicker3.Text },// 取芯结束时间
                { "CoringStartTime", _mainForm.dateTimePicker5.Text },// 取芯开始时间
                { "DesorptionStartTime", _mainForm.dateTimePicker4.Text },// 解吸开始时间
                { "SamplingPersonnel", _mainForm.SamplingPersonnelTextBox.Text },// 取样人员

                { "DownholeTesters", _mainForm.DownholeTestersTextBox.Text },// 井下测试人员
                { "TestTime", _mainForm.dateTimePicker6.Text },// 测试时间
                
            };
            ReplacePlaceholders(memoryStream, placeholders);
            //var subscriptPositions = new List<int> { 2 ,4 ,6};  // 让第3个字符 '6' 下标
            //ReplacePlaceholderWithCustomSubscripts(memoryStream, "RemarkText", "你好6你干嘛45", 11, subscriptPositions);
            //if (string.Equals(MainForm.Wc_Lab1, "吸附常数a值(cm3/g)："))
            //{
            //    var subscriptPositions = new List<int> { 2, 4, 6 };
            //    ReplacePlaceholderWithCustomSuperscripts(memoryStream, "Wc_Lab01", "吸附常数a值(cm3/g)：", 11, subscriptPositions);
            //}
              void Log(string message)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {message}");
            }

            var superscriptMap = new Dictionary<string, List<int>>
            {
                ["吸附常数a值(cm3/g)："] = new List<int> { 9 },
                ["吸附常数b值(MPa-1)："] = new List<int> { 10, 11 },
                ["不可解吸瓦斯量Wc(m3/t)："] = new List<int> { 11 },
                ["真密度(g/cm3)："] = new List<int> { 8 },
                
                // 这些不需要上标
                ["水分Mad/%："] = new List<int>(),
                ["灰分Aad/%："] = new List<int>(),
                ["孔隙率K/%："] = new List<int>(),
                ["相对视密度γ："] = new List<int>(),
                ["挥发分Vad/%："] = new List<int>()
            };
            for (int i = 1; i <= 9; i++)
            {
                string placeholderName = $"Wc_Lab0{i}";

                var prop = typeof(MainForm).GetField($"Wc_Lab{i}");
                string labelText = prop?.GetValue(null)?.ToString() ?? "";

                Log($"[Wc] Field: Wc_Lab{i}, Placeholder: {placeholderName}, Text: \"{labelText}\"");

                superscriptMap.TryGetValue(labelText, out var superscriptPositions);
                if (superscriptPositions == null)
                {
                    superscriptPositions = new List<int>();
                }

                Log($"[Wc] Superscript positions: {string.Join(",", superscriptPositions)}");

                if (labelText == "不可解吸瓦斯量Wc(m3/t)：")
                {
                    _ReplacePlaceholderWithCustomSuperscripts(
                        memoryStream,
                        placeholderName,
                        labelText,
                        11,
                        superscriptPositions
                    );
                }
                else
                {
                    ReplacePlaceholderWithCustomSuperscripts(
                        memoryStream,
                        placeholderName,
                        labelText,
                        11,
                        superscriptPositions
                    );
                }
            }


            var GasCompsuperscriptMap = new Dictionary<string, List<int>>
            {
                ["CH4："] = new List<int> { 2 },
                ["CO2："] = new List<int> { 2 },
                ["N2："] = new List<int> { 1 },

                ["O2："] = new List<int> { 1 },
                ["C2H4："] = new List<int> { 1,3 },
                ["C3H8："] = new List<int> { 1,3 },
                ["C2H6："] = new List<int> { 1,3 },
                ["C3H6："] = new List<int> { 1,3 },
                ["C2H2："] = new List<int> { 1,3 },
                ["CO："] = new List<int> {  },
            };
            //for (int i = 1; i <= 10; i++)
            //{
            //    string placeholderName = $"GasComp_Lab{i:D2}";

            //    var prop = typeof(MainForm).GetField($"GasComp_Lab{i}");
            //    string labelText = prop?.GetValue(null)?.ToString() ?? "";

            //    Log($"[GasComp] Field: GasComp_Lab{i}, Placeholder: {placeholderName}, Text: \"{labelText}\"");

            //    GasCompsuperscriptMap.TryGetValue(labelText, out var superscriptPositions);
            //    if (superscriptPositions == null)
            //    {
            //        superscriptPositions = new List<int>();
            //    }

            //    Log($"[GasComp] Superscript positions: {string.Join(",", superscriptPositions)}");

            //    ReplacePlaceholderWithCustomSuperscripts(
            //        memoryStream,
            //        placeholderName,
            //        labelText,
            //        11,
            //        superscriptPositions
            //    );
            //}
            for (int i = 1; i <= 10; i++)
            {
                string placeholderName = $"GasComp_Lab{i:D2}"; // 占位符名称

                // 反射获取 MainForm 中的静态字段值
                var prop = typeof(MainForm).GetField($"GasComp_Lab{i}");
                string labelText = prop?.GetValue(null)?.ToString() ?? "";

                GasCompsuperscriptMap.TryGetValue(labelText, out var superscriptPositions);
                if (superscriptPositions == null)
                {
                    superscriptPositions = new List<int>();
                }

                ReplacePlaceholderWithCustomSuperscripts(
                    memoryStream,
                    placeholderName,
                    labelText,
                    11,
                    superscriptPositions
                );
            }


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
                    //Console.WriteLine($"获取：{text}");
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

        public void ReplacePlaceholderWithCustomSubscripts(
            MemoryStream memoryStream, string placeholder, string newText, int fontSizePt, List<int> subscriptIndices)
        {
            memoryStream.Position = 0;

            using (var wordDoc = WordprocessingDocument.Open(memoryStream, true))
            {
                var body = wordDoc.MainDocumentPart.Document.Body;

                // 找到包含占位符文本的Run
                var runs = body.Descendants<Run>()
                    .Where(r => r.InnerText.Contains(placeholder))
                    .ToList();

                foreach (var run in runs)
                {
                    // 清空Run内容
                    run.RemoveAllChildren();

                    // 遍历newText的每个字符
                    for (int i = 0; i < newText.Length; i++)
                    {
                        char ch = newText[i];

                        // 新建Run和RunProperties
                        var newRun = new Run();
                        var runProperties = new RunProperties();

                        // 字号，单位是半磅，11pt = 22
                        runProperties.FontSize = new FontSize() { Val = (fontSizePt * 2).ToString() };

                        // 判断是否中文
                        if (Regex.IsMatch(ch.ToString(), @"[\u4e00-\u9fa5]"))
                        {
                            // 中文宋体
                            runProperties.RunFonts = new RunFonts() { EastAsia = "宋体" };
                        }
                        else
                        {
                            // 非中文 Times New Roman
                            runProperties.RunFonts = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman" };
                        }

                        // 判断该字符索引是否在下标列表中
                        if (subscriptIndices.Contains(i))
                        {
                            runProperties.VerticalTextAlignment = new VerticalTextAlignment() { Val = VerticalPositionValues.Subscript };
                        }

                        newRun.AppendChild(runProperties);
                        newRun.AppendChild(new Text(ch.ToString()));

                        // 添加新Run到原Run父元素（Run的父是 Paragraph或者其他）
                        run.Parent.InsertBefore(newRun, run);
                    }

                    // 删除原占位符Run
                    run.Remove();
                }

                wordDoc.MainDocumentPart.Document.Save();
            }
        }
        public void ReplacePlaceholderWithCustomSuperscripts(
            MemoryStream memoryStream, string placeholder, string newText, int fontSizePt, List<int> superscriptIndices)
        {
            memoryStream.Position = 0;

            using (var wordDoc = WordprocessingDocument.Open(memoryStream, true))
            {
                var body = wordDoc.MainDocumentPart.Document.Body;

                var runs = body.Descendants<Run>()
                    .Where(r => r.InnerText.Contains(placeholder))
                    .ToList();

                foreach (var run in runs)
                {
                    run.RemoveAllChildren();

                    for (int i = 0; i < newText.Length; i++)
                    {
                        char ch = newText[i];

                        var newRun = new Run();
                        var runProperties = new RunProperties();

                        runProperties.FontSize = new FontSize() { Val = (fontSizePt * 2).ToString() };

                        if (Regex.IsMatch(ch.ToString(), @"[\u4e00-\u9fa5]"))
                        {
                            runProperties.RunFonts = new RunFonts() { EastAsia = "宋体" };
                        }
                        else
                        {
                            runProperties.RunFonts = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman" };
                        }

                        // 这里改成 Superscript
                        if (superscriptIndices.Contains(i))
                        {
                            runProperties.VerticalTextAlignment = new VerticalTextAlignment() { Val = VerticalPositionValues.Superscript };
                        }

                        newRun.AppendChild(runProperties);
                        newRun.AppendChild(new Text(ch.ToString()));

                        run.Parent.InsertBefore(newRun, run);
                    }

                    run.Remove();
                }

                wordDoc.MainDocumentPart.Document.Save();
            }
        }

        public void _ReplacePlaceholderWithCustomSuperscripts(
    MemoryStream memoryStream, string placeholder, string newText, int fontSizePt, List<int> superscriptIndices)
        {
            memoryStream.Position = 0;

            using (var wordDoc = WordprocessingDocument.Open(memoryStream, true))
            {
                var body = wordDoc.MainDocumentPart.Document.Body;

                var runs = body.Descendants<Run>()
                    .Where(r => r.InnerText.Contains(placeholder))
                    .ToList();

                foreach (var run in runs)
                {
                    run.RemoveAllChildren();

                    for (int i = 0; i < newText.Length; i++)
                    {
                        char ch = newText[i];

                        var newRun = new Run();
                        var runProperties = new RunProperties();

                        // 设置字体大小
                        runProperties.FontSize = new FontSize() { Val = (fontSizePt * 2).ToString() };

                        // 设置字符间距（单位是 1/20 磅，20 = 1 磅）
                        runProperties.Spacing = new Spacing() { Val = -6 };

                        // 设置字体（中文用宋体，其它用 Times New Roman）
                        if (Regex.IsMatch(ch.ToString(), @"[\u4e00-\u9fa5]"))
                        {
                            runProperties.RunFonts = new RunFonts() { EastAsia = "宋体" };
                        }
                        else
                        {
                            runProperties.RunFonts = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman" };
                        }

                        // 设置上标
                        if (superscriptIndices.Contains(i))
                        {
                            runProperties.VerticalTextAlignment = new VerticalTextAlignment()
                            {
                                Val = VerticalPositionValues.Superscript
                            };
                        }

                        newRun.AppendChild(runProperties);
                        newRun.AppendChild(new Text(ch.ToString()));

                        run.Parent.InsertBefore(newRun, run);
                    }

                    run.Remove();
                }

                wordDoc.MainDocumentPart.Document.Save();
            }
        }

    }
}
