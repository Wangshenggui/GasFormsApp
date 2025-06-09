using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasFormsApp.TabControl
{
    internal class tabControl_6
    {
        private MainForm _mainForm;


        public tabControl_6(MainForm form)
        {
            _mainForm = form;

            //注册回调函数
            _mainForm.button1.Click += button1_Click;
            _mainForm.button2.Click += button2_Click;

            _mainForm.dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;

        }
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;

            // 获取行号（从 1 开始）
            string rowNumber = (e.RowIndex + 1).ToString();

            // 设置字体（可省略）
            //Font font = dgv.RowHeadersDefaultCellStyle.Font ?? dgv.DefaultCellStyle.Font;
            Font font = new Font("宋体", 12, FontStyle.Bold);

            // 计算绘制区域
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);

            // 居中绘制行号
            TextRenderer.DrawText(e.Graphics, rowNumber, font, headerBounds, Color.Black,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }


        // 标记该类可被序列化为二进制格式
        [Serializable]
        public class UserData
        {
            public string ID { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 矿井名称 { get; set; }
            public string 取样地点 { get; set; }
            public string 取样时间 { get; set; }
            public string 埋深 { get; set; }
            public string 煤层 { get; set; }
            public string 煤样编号 { get; set; }
            public string 实验室大气压力 { get; set; }
            public string 实验室温度 { get; set; }
            public string 取样方式 { get; set; }
            public string 原煤水分 { get; set; }
            public string 取样深度 { get; set; }
            public string 井下大气压力 { get; set; }
            public string 井下环境温度 { get; set; }
            public string 煤样重量 { get; set; }
            public string 煤样水分 { get; set; }
            public string 量管初始体积 { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 井下解吸量W11 { get; set; }
            public string 瓦斯损失量W12 { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 实验室常压解吸W2 { get; set; }
            public string 粉碎后第1份煤样重 { get; set; }
            public string 第1份煤样解吸量 { get; set; }
            public string 粉碎后第2份煤样重 { get; set; }
            public string 第2份煤样解吸量 { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string a { get; set; }
            public string b { get; set; }
            //public string Wc { get; set; }    // 和下面的重复
            public string Mad { get; set; }
            public string Aad { get; set; }
            public string Vad { get; set; }
            public string K { get; set; }
            public string r { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string CH4 { get; set; }
            public string CO2 { get; set; }
            public string N2 { get; set; }
            public string O2 { get; set; }
            public string C2H4 { get; set; }
            public string C3H8 { get; set; }
            public string C2H6 { get; set; }
            public string C3H6 { get; set; }
            public string C2H2 { get; set; }
            public string CO { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string W1 { get; set; }
            public string W2 { get; set; }
            public string W3 { get; set; }
            public string Wa { get; set; }
            public string Wc { get; set; }
            public string W { get; set; }
            public string P { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 实验室测试人员 { get; set; }
            public string 审核人员 { get; set; }
            public string 出报告时间 { get; set; }
            public string 备注 { get; set; }
        }

        // 当前程序目录
        static string CurrentDir = AppDomain.CurrentDomain.BaseDirectory;

        // 用于存放系统数据的文件夹路径
        string SystemDataPath = Path.Combine(CurrentDir, "SystemData");

        /// <summary>
        /// 按钮1点击事件：复制图片并保存用户数据为二进制文件
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // 生成时间戳，用于命名文件
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // 如果 SystemData 文件夹不存在，则创建
            if (!Directory.Exists(SystemDataPath))
            {
                Directory.CreateDirectory(SystemDataPath);
                Console.WriteLine("SystemData 文件夹不存在，已创建");
            }

            // === 复制图片 ===
            // 定义原始图片路径
            string imageSourcePath = Path.Combine(CurrentDir, "Python_embed", "Python", "images", "output_image.png");

            // 定义新的图片名称和路径
            string newImageName = $"{timestamp}_Image.png";
            string imageTargetPath = Path.Combine(SystemDataPath, newImageName);

            // 将图片复制到目标路径，若已存在则覆盖
            File.Copy(imageSourcePath, imageTargetPath, true);
            Console.WriteLine($"图片已复制到：{imageTargetPath}");

            // === 保存用户数据 ===
            try
            {
                // 创建用户数据对象，这里是模拟数据，也可以从界面控件读取
                var user = new UserData
                {
                    ID = "001",
                    矿井名称 = "某矿井",
                    取样地点 = "某工作面",
                    取样时间 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    埋深 = "500m",
                    煤层 = "3#煤",
                    煤样编号 = "CY202506",
                    实验室大气压力 = "101.3kPa",
                    实验室温度 = "25°C",
                    取样方式 = "钻探",
                    原煤水分 = "2.5%",
                    取样深度 = "5m",
                    井下大气压力 = "102kPa",
                    井下环境温度 = "27°C",
                    煤样重量 = "1.2kg",
                    煤样水分 = "1.8%",
                    量管初始体积 = "100ml",

                    井下解吸量W11 = "0.5",
                    瓦斯损失量W12 = "0.1",

                    实验室常压解吸W2 = "0.3",
                    粉碎后第1份煤样重 = "0.6",
                    第1份煤样解吸量 = "0.15",
                    粉碎后第2份煤样重 = "0.5",
                    第2份煤样解吸量 = "0.12",

                    a = "0.98",
                    b = "1.05",
                    Mad = "3.2%",
                    Aad = "12%",
                    Vad = "30%",
                    K = "0.7",
                    r = "1.0",

                    CH4 = "85%",
                    CO2 = "10%",
                    N2 = "3%",
                    O2 = "1%",
                    C2H4 = "0.2%",
                    C3H8 = "0.1%",
                    C2H6 = "0.05%",
                    C3H6 = "0.01%",
                    C2H2 = "0.03%",
                    CO = "0.02%",

                    W1 = "0.5",
                    W2 = "0.3",
                    W3 = "0.2",
                    Wa = "1.0",
                    Wc = "0.9",
                    W = "2.2",
                    P = "0.8",

                    实验室测试人员 = "张三",
                    审核人员 = "李四",
                    出报告时间 = DateTime.Now.ToString("yyyy-MM-dd"),
                    备注 = "数据自动生成"
                };


                // 定义要保存的二进制数据文件路径
                string dataFilePath = Path.Combine(SystemDataPath, $"{timestamp}_BinData.bin");

                // 使用二进制格式化器将对象序列化保存到文件中
                using (FileStream fs = new FileStream(dataFilePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, user);
                }

                Console.WriteLine($"二进制保存成功，文件路径：{dataFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("保存失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 按钮2点击事件：读取所有保存的用户数据并绑定到 DataGridView
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 如果 SystemData 文件夹不存在，则提示并退出
                if (!Directory.Exists(SystemDataPath))
                {
                    Console.WriteLine("BinData 文件夹不存在！");
                    return;
                }

                // 获取所有以 .bin 结尾的用户数据文件
                string[] files = Directory.GetFiles(SystemDataPath, "*.bin");
                if (files.Length == 0)
                {
                    Console.WriteLine("没有找到数据文件！");
                    return;
                }

                // 用于保存所有反序列化后的用户数据
                List<UserData> allUsers = new List<UserData>();
                BinaryFormatter formatter = new BinaryFormatter();

                // 遍历每个数据文件，反序列化并添加到列表中
                foreach (var file in files)
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        UserData user = (UserData)formatter.Deserialize(fs);
                        allUsers.Add(user);
                    }
                }

                // 将数据绑定到主窗体的 DataGridView 控件上
                var sortableList = new SortableBindingList<UserData>(allUsers);
                _mainForm.dataGridView1.DataSource = null;              // 先清空数据源
                _mainForm.dataGridView1.DataSource = sortableList;      // 设置新数据源
                //自动调节宽度
                _mainForm.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                Console.WriteLine("数据加载完成，已绑定到dataGridView1。");
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取失败：" + ex.Message);
            }
        }
    }
}
