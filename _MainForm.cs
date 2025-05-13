using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Reflection;


namespace GasFormsApp
{
    public partial class _MainForm : Form
    {
        private bool v;

        //public Form1()
        //{
        //    InitializeComponent();
        //}

        public _MainForm(bool v)
        {
            this.v = v;
            InitializeComponent();
        }

        void Button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 选择保存位置
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Word 文件 (*.docx)|*.docx",
                Title = "保存生成的 Word 文件"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string outputPath = saveDialog.FileName;

                // 获取程序集
                var assembly = Assembly.GetExecutingAssembly();
                string resourceName = "GasFormsApp.WordTemplate.docx"; // 注意这个名字必须和实际资源名一致

                // 尝试读取嵌入资源
                using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (resourceStream == null)
                    {
                        MessageBox.Show("模板资源未找到，请检查资源名称是否正确。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 将嵌入资源复制到用户指定路径
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        resourceStream.CopyTo(fileStream);
                    }
                }

                // 替换文档中的占位符内容
                using (WordprocessingDocument doc = WordprocessingDocument.Open(outputPath, true))
                {
                    var body = doc.MainDocumentPart.Document.Body;

                    var replacements = new Dictionary<string, string>();
                    Random random = new Random();
                    for (int i = 1; i <= 135; i++)
                    {
                        string placeholder = $"D{(i < 10 ? "00" : i < 100 ? "0" : "")}{i}";
                        int randomValue = random.Next(1, 101);
                        replacements[placeholder] = randomValue.ToString();
                    }

                    foreach (var text in body.Descendants<Text>())
                    {
                        foreach (var placeholder in replacements.Keys)
                        {
                            if (text.Text.Contains(placeholder))
                            {
                                text.Text = text.Text.Replace(placeholder, replacements[placeholder]);
                            }
                        }
                    }

                    doc.MainDocumentPart.Document.Save();
                }

                //// 插入图表
                //InsertChart insertChart = new InsertChart();
                //insertChart.InsertChartToWord(outputPath);

                //System.Windows.Forms.Application.Exit();
                MessageBox.Show("Word 文件生成成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
