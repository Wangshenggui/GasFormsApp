using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GasFormsApp
{
    internal class InsertChart
    {
        public void InsertChartToWord(string outputPath, double[,] data)
        {
            // 创建一个 Excel 应用实例来生成图表
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application
            {
                Visible = true  // 设置为 false，这样不会弹出 Excel 窗口
            };

            // 创建一个新的工作簿并添加图表数据
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Worksheets[1];

            worksheet.Cells[1, 1] = "X 值";
            worksheet.Cells[1, 2] = "Y 值";
            //worksheet.Cells[2, 1] = 1;
            //worksheet.Cells[2, 2] = -10;
            //worksheet.Cells[3, 1] = 2;
            //worksheet.Cells[3, 2] = 10;
            //worksheet.Cells[4, 1] = 3;
            //worksheet.Cells[4, 2] = 25;
            //worksheet.Cells[5, 1] = 4;
            //worksheet.Cells[5, 2] = 35;
            //worksheet.Cells[6, 1] = 5;
            //worksheet.Cells[6, 2] = 25;
            // 填充数据，从第二行开始
            for (int i = 0; i < data.GetLength(0); i++)
            {
                worksheet.Cells[i + 2, 1] = data[i, 0]; // X 值
                worksheet.Cells[i + 2, 2] = data[i, 1]; // Y 值
            }


            // 创建图表（不自动绑定数据源）
            Microsoft.Office.Interop.Excel.Chart chart = (Microsoft.Office.Interop.Excel.Chart)workbook.Charts.Add();
            // 带连线的散点图
            chart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlXYScatter;
            chart.HasTitle = true;
            chart.ChartTitle.Text = "姓名与数据曲线";
            chart.HasLegend = false;
            chart.ChartTitle.Font.Name = "Arial Narrow";         // 设置字体
            chart.ChartTitle.Font.Size = 10;              // 设置字体大小
            chart.ChartTitle.Font.Bold = true;            // 加粗
            chart.ChartTitle.Font.Italic = false;          // 斜体

            chart.ChartTitle.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red); // 设置颜色
            // 把标题往上移动，紧贴图表上方
            chart.ChartTitle.IncludeInLayout = false;
            chart.ChartTitle.Top = 0;

            // 清除所有现有系列（确保从空白开始）
            while (chart.SeriesCollection().Count > 0)
            {
                chart.SeriesCollection(1).Delete();
            }

            // 手动添加唯一系列
            Microsoft.Office.Interop.Excel.Series series = (Microsoft.Office.Interop.Excel.Series)chart.SeriesCollection().NewSeries();
            int lastRow = worksheet.Cells[worksheet.Rows.Count, 1].End(Microsoft.Office.Interop.Excel.XlDirection.xlUp).Row;
            series.XValues = worksheet.Range["A2:A" +lastRow.ToString()]; // X值范围（不含标题）
            series.Values = worksheet.Range["B2:B" + lastRow.ToString()];  // Y值范围（不含标题）
            series.Name = "数据系列"; // 可选命名
            // 设置点样式为圆形
            series.MarkerStyle = Microsoft.Office.Interop.Excel.XlMarkerStyle.xlMarkerStyleCircle;
            // 设置点的大小（建议值 2~5，默认是5）
            series.MarkerSize = 2;
            // 设置点颜色（边框和填充）
            series.MarkerForegroundColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);      // 点边框色
            series.MarkerBackgroundColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);      // 点填充色


            //// 添加一个新系列，只包含前5个数据点
            //var fitSeries = chart.SeriesCollection().NewSeries();
            //fitSeries.XValues = worksheet.Range["A2", "A6"]; // 前5个X
            //fitSeries.Values = worksheet.Range["B2", "B6"];  // 前5个Y
            //fitSeries.Name = "前5点拟合";

            //// 设置点样式为圆形
            //fitSeries.MarkerStyle = Microsoft.Office.Interop.Excel.XlMarkerStyle.xlMarkerStyleCircle;
            //// 设置点的大小（建议值 2~5，默认是5）
            //fitSeries.MarkerSize = 2;
            //// 设置点的边框颜色（前景色）
            //fitSeries.MarkerForegroundColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            //// 设置点的填充颜色（背景色）
            //fitSeries.MarkerBackgroundColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);

            //// 添加线性趋势线（拟合直线）
            //Microsoft.Office.Interop.Excel.Trendline trendline = fitSeries.Trendlines().Add(Microsoft.Office.Interop.Excel.XlTrendlineType.xlLinear);
            //trendline.DisplayEquation = true; // 显示拟合直线方程
            //trendline.DisplayRSquared = true; // 显示 R² 值
            //// 图标顶部标题
            //chart.ChartTitle.Text = trendline.DataLabel.Text;
            //trendline.DisplayEquation = false;

            //trendline.DisplayRSquared = false;

            //trendline.Forward = 0;   // 向前延伸5个单位（根据需要调整）
            //trendline.Backward = 2;  // 向后延伸2个单位（根据需要调整）

            double maxR2 = double.MinValue;  // 初始化最大 R² 值
            int totalDataRows = 18; // 假设有18行数据
            List<(double r2Value, int startRow, int endRow, Microsoft.Office.Interop.Excel.Series series, Microsoft.Office.Interop.Excel.Trendline trendline)> bestFitLines = new List<(double, int, int, Microsoft.Office.Interop.Excel.Series, Microsoft.Office.Interop.Excel.Trendline)>();

            // 记录 R² 最大的拟合曲线
            (double r2Value, int startRow, int endRow, Microsoft.Office.Interop.Excel.Series series, Microsoft.Office.Interop.Excel.Trendline trendline) bestFitLine = (double.MinValue, 0, 0, null, null);

            for (int startRow = 2; startRow <= 2; startRow++) // 起始点必须能保证至少5个点
            {
                for (int length = 5; length <= 12; length++)
                {
                    int endRow = startRow + length - 1;
                    if (endRow > totalDataRows)
                        continue;

                    Microsoft.Office.Interop.Excel.Series tempSeries = chart.SeriesCollection().NewSeries();
                    tempSeries.XValues = worksheet.Range[$"A{startRow}", $"A{endRow}"];
                    tempSeries.Values = worksheet.Range[$"B{startRow}", $"B{endRow}"];
                    tempSeries.Name = $"第{startRow - 1}到{endRow - 1}点";

                    Microsoft.Office.Interop.Excel.Trendline tempTrendline = tempSeries.Trendlines().Add(
                        Microsoft.Office.Interop.Excel.XlTrendlineType.xlLinear);

                    tempTrendline.DisplayRSquared = true;
                    tempTrendline.DisplayEquation = true; // 显示拟合方程

                    chart.Refresh(); // 强制更新图表

                    // 延迟一小段时间确保更新完成
                    System.Threading.Thread.Sleep(500);  // 适当增加延迟时间，确保图表数据和标签更新

                    double r2Value = 0.0;
                    try
                    {
                        string r2Text = tempTrendline.DataLabel.Text;
                        if (!string.IsNullOrEmpty(r2Text))  // 确保读取到有效的 R² 值
                        {
                            var match = Regex.Match(r2Text, @"R²\s*=\s*([0-9.]+)");
                            if (match.Success)
                            {
                                r2Value = double.Parse(match.Groups[1].Value);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing R² value: {ex.Message}");
                    }

                    // 检查当前拟合线的 R² 是否大于当前最大值
                    if (r2Value > maxR2)
                    {
                        // 删除上一条“最佳”的旧拟合线和系列
                        if (bestFitLine.series != null)
                        {
                            bestFitLine.series.Delete(); // 会自动删除对应 trendline
                        }
                        maxR2 = r2Value;  // 更新最大 R² 值
                        bestFitLine = (r2Value, startRow, endRow, tempSeries, tempTrendline);  // 更新最佳拟合线
                    }
                    else
                    {
                        // 删除非最佳系列
                        tempSeries.Delete();
                    }
                }
            }

            // 输出最大 R² 值的拟合曲线信息
            if (bestFitLine.series != null)
            {
                var bestSeries = bestFitLine.series;
                var bestTrendline = bestFitLine.trendline;

                Console.WriteLine($"最大 R² 值: {bestFitLine.r2Value}");
                Console.WriteLine($"最佳拟合曲线的范围: 第{bestFitLine.startRow}到{bestFitLine.endRow}点");
                Console.WriteLine($"拟合方程: {bestTrendline.DataLabel.Text}");

                // 设置最佳拟合曲线的样式
                bestSeries.MarkerStyle = Microsoft.Office.Interop.Excel.XlMarkerStyle.xlMarkerStyleCircle;
                bestSeries.MarkerSize = 5;
                bestSeries.MarkerForegroundColor = ColorTranslator.ToOle(Color.DarkBlue);
                bestSeries.MarkerBackgroundColor = ColorTranslator.ToOle(Color.DarkBlue);

                bestTrendline.DisplayEquation = true;
                bestTrendline.DisplayRSquared = true;
                bestTrendline.Forward = 10;   // 向前延伸5个单位（根据需要调整）
                bestTrendline.Backward = 2;  // 向后延伸2个单位（根据需要调整）

                // 在图表标题中显示最佳拟合的范围以及拟合方程
                //chart.ChartTitle.Text += $"最佳拟合: 第{bestFitLine.startRow}到{bestFitLine.endRow}点\n" +
                //                         $"{bestTrendline.DataLabel.Text}\n";
                chart.ChartTitle.Text = $"{bestTrendline.DataLabel.Text}";

                bestTrendline.DisplayEquation = false;
                bestTrendline.DisplayRSquared = false;
            }
            else
            {
                Console.WriteLine("没有找到任何拟合曲线");
            }





            // 获取 Y 轴并设置范围
            var yAxis = chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue);
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue).MajorUnit = 20;
            yAxis.MinimumScale = -60;  // 设置 Y 轴最小值为负数
            yAxis.MaximumScale = 140 - 1;   // 可选：设置 Y 轴最大值


            // 禁用主纵轴（Y轴）上的主网格线
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue).HasMajorGridlines = false;
            // 去掉图表边框
            chart.ChartArea.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
            // 设置 Y 轴刻度字体大小为 10
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue).TickLabels.Font.Size = 10;
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue).TickLabels.Font.Bold = true;            // 加粗
            // 禁用 Y 轴刻度线
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue).MajorTickMark = Microsoft.Office.Interop.Excel.XlTickMark.xlTickMarkNone;
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue).MinorTickMark = Microsoft.Office.Interop.Excel.XlTickMark.xlTickMarkNone;
            // 设置 X 轴刻度字体大小为 10
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).TickLabels.Font.Size = 10;
            // 设置 X轴从 0 开始（默认是从0开始的）
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).MinimumScale = 0;
            // 设置步长为1，确保显示1, 2, 3, 4, 5, 6...
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).MajorUnit = 1;
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).MaximumScale = 10 - 0.01;
            // 使用自定义格式隐藏0
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).TickLabels.NumberFormat = "0;0;;@";
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).TickLabels.Font.Bold = true;            // 加粗
            // 禁用 X 轴刻度线
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).MajorTickMark = Microsoft.Office.Interop.Excel.XlTickMark.xlTickMarkNone;
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).MinorTickMark = Microsoft.Office.Interop.Excel.XlTickMark.xlTickMarkNone;
            // 加粗 Y 轴
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue).Format.Line.Weight = 1.25f;
            // 设置坐标轴线条颜色为黑色
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue).Format.Line.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            // 加粗 X 轴
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).Format.Line.Weight = 1.25f;
            // 设置坐标轴线条颜色为黑色
            chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).Format.Line.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            // 获取 Y 轴 LineFormat
            var yAxisLineFormat = chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue).Format.Line;
            // 为 Y 轴添加箭头
            yAxisLineFormat.EndArrowheadStyle = Microsoft.Office.Core.MsoArrowheadStyle.msoArrowheadTriangle;

            // 获取 X 轴 LineFormat
            var xAxisLineFormat = chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).Format.Line;
            // 为 X 轴添加箭头
            xAxisLineFormat.EndArrowheadStyle = Microsoft.Office.Core.MsoArrowheadStyle.msoArrowheadTriangle;

            // 获取 X 轴的垂直位置和高度
            var xAxis = chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory);


            //float xAxisTop = (float)xAxis.Top;
            //float xAxisHeight = (float)xAxis.Height;
            //// 设置文本框的位置
            //var x_textBox = chart.Shapes.AddTextbox(
            //    Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,
            //    (float)(xAxisTop + xAxisHeight + 200),  // 垂直位置：X轴下方位置
            //    (float)(xAxisTop), // X轴位置的底部
            //    50, // 宽度
            //    36  // 高度
            //);
            //// 设置文本框内容为 "abc"
            //x_textBox.TextFrame2.TextRange.Text = "abc";
            //// 设置字体大小、加粗等样式
            //x_textBox.TextFrame2.TextRange.Font.Size = 10;
            //x_textBox.TextFrame2.TextRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
            //x_textBox.TextFrame2.TextRange.Font.Name = "Arial";
            //x_textBox.Fill.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);

            //// 设置文本框的位置
            //var y_textBox = chart.Shapes.AddTextbox(
            //    Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,
            //    0,  // 垂直位置：X轴下方位置
            //    0, // X轴位置的底部
            //    70, // 宽度
            //    45  // 高度
            //);
            //// 设置文本框内容为 "abc"
            //y_textBox.TextFrame2.TextRange.Text = "ml";
            //// 设置字体大小、加粗等样式
            //y_textBox.TextFrame2.TextRange.Font.Size = 10;
            //y_textBox.TextFrame2.TextRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
            //y_textBox.TextFrame2.TextRange.Font.Name = "Times New Roman";
            //y_textBox.TextFrame2.MarginTop = 0;
            //y_textBox.TextFrame2.MarginBottom = 0;
            //y_textBox.TextFrame2.MarginLeft = 0;
            //y_textBox.TextFrame2.MarginRight = 0;
            //// 设置对齐方式
            //y_textBox.TextFrame2.TextRange.ParagraphFormat.Alignment =
            //    Microsoft.Office.Core.MsoParagraphAlignment.msoAlignCenter; // 靠右

            //y_textBox.TextFrame2.VerticalAnchor =
            //    Microsoft.Office.Core.MsoVerticalAnchor.msoAnchorMiddle; // 垂直居中
            //y_textBox.Fill.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.BlueViolet);




            // 复制图表
            chart.ChartArea.Copy(); // 更稳定于 CopyPicture



            // 使用别名创建 Word 应用实例
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            // 打开生成的 Word 文件
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(outputPath);
            wordApp.Visible = false;
            Microsoft.Office.Interop.Word.Range bookmarkRange = doc.Bookmarks["ChartPlaceholder"].Range;
            Microsoft.Office.Interop.Word.Bookmarks bookmarks = doc.Bookmarks;
            // 插入到 Word 书签位置
            if (doc.Bookmarks.Exists("ChartPlaceholder"))
            {
                bookmarkRange.Paste();
            }
            else
            {
                MessageBox.Show("未找到书签 'ChartPlaceholder'，请检查 Word 模板！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 插入图表完毕后释放 Word 中用到的所有对象
            if (bookmarkRange != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(bookmarkRange);
            if (bookmarks != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(bookmarks);

            doc.Save();
            doc.Close(false);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);

            wordApp.Quit(false);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);

            // 清理 Excel
            workbook.Close(false);
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(chart);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            // 强制进行垃圾收集，确保所有 COM 被释放
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
    }
}
