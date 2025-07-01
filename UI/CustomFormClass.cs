using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasFormsApp.UI
{
    /// <summary>
    /// 自定义无边框窗体，带自绘边框和标题栏，支持拖动、最大化、关闭等行为。
    /// </summary>
    public class CustomForm : Form
    {
        // 自定义标题栏及边框控件
        private Panel titleBar;
        private Label titleLabel;
        private Button closeButton;
        private Button minimizeButton;
        private Button maximizeButton;

        // 左、右、上边框
        private Panel borderLeft;
        private Panel borderRight;
        private Panel borderTop;

        // 示例中的自定义工具栏按钮
        private Button 信息管理Button;

        /// <summary>
        /// 初始化边框控件（三边：左、右、上），模拟原始窗口边框。
        /// </summary>
        private void InitializeBorder()
        {
            int borderWidth = 2;
            Color borderColor = Color.White;

            borderLeft = new Panel
            {
                BackColor = borderColor,
                Dock = DockStyle.Left,
                Width = borderWidth
            };
            this.Controls.Add(borderLeft);

            borderRight = new Panel
            {
                BackColor = borderColor,
                Dock = DockStyle.Right,
                Width = borderWidth
            };
            this.Controls.Add(borderRight);

            borderTop = new Panel
            {
                BackColor = borderColor,
                Dock = DockStyle.Top,
                Height = borderWidth
            };
            this.Controls.Add(borderTop);

            // 确保边框在最上层（防止被其他控件遮挡）
            borderLeft.BringToFront();
            borderRight.BringToFront();
            borderTop.BringToFront();
        }

        /// <summary>
        /// 双击标题栏切换最大化和还原状态。
        /// </summary>
        private void TitleBar_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                maximizeButton.Text = "❐"; // 恢复图标
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                maximizeButton.Text = "▢";
            }
        }

        /// <summary>
        /// 构造函数：初始化窗体外观和控件。
        /// </summary>
        public CustomForm()
        {
            // 允许窗体支持双击事件（必须）
            this.SetStyle(ControlStyles.StandardDoubleClick, true);

            // 设置为无边框窗体
            this.FormBorderStyle = FormBorderStyle.None;

            // 初始位置
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 200);
            this.Padding = new Padding(2);

            InitializeCustomTitleBar(); // 自定义标题栏
            InitializeBorder();         // 自定义边框
        }

        private void 信息管理Button_Click(object sender, EventArgs e)
        {
            //string folder = "SystemData";
            //string dbFile = Path.Combine(folder, "Account_password.db");

            //MessageBox.Show("登录的用户名：" + MainForm.登录的用户名);

            //ChangePasswordForm changePwdForm = new ChangePasswordForm(dbFile, MainForm.登录的用户名);
            //changePwdForm.ShowDialog();
        }

        /// <summary>
        /// 初始化自定义标题栏，包括：标题、按钮等。
        /// </summary>
        private void InitializeCustomTitleBar()
        {
            titleBar = new Panel
            {
                Height = 30,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(17, 45, 78)
            };
            this.Controls.Add(titleBar);

            // 虽然设置了左右/上边框，但宽高为 0，保留结构可能用于后续视觉细节
            titleBar.Controls.Add(new Panel { Width = 0, Dock = DockStyle.Left, BackColor = Color.White });
            titleBar.Controls.Add(new Panel { Width = 0, Dock = DockStyle.Right, BackColor = Color.White });
            titleBar.Controls.Add(new Panel { Height = 0, Dock = DockStyle.Top, BackColor = Color.White });

            // 标题文本标签
            titleLabel = new Label
            {
                Text = this.Text,
                ForeColor = Color.LightGray,
                AutoSize = false,
                Dock = DockStyle.None,
                Width = 200,
                Height = 30,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Location = new Point(0, 0)
            };
            titleBar.Controls.Add(titleLabel);

            //// 信息管理Button（示例）
            //信息管理Button = new CustomBorderButton
            //{
            //    Text = " 数据管理 ",
            //    BackColor = Color.FromArgb(17, 45, 78),
            //    FlatStyle = FlatStyle.Flat,
            //    Width = 85,
            //    Borders = BorderSides.Left,
            //    HoverBackColor = Color.FromArgb(80, 80, 80),
            //    ForeColor = Color.LightGray,
            //    Font = new Font("Segoe UI", 9, FontStyle.Bold),
            //    BorderColor = Color.White,
            //    BorderWidth = 2,
            //    TabStop = false,
            //    Location = new Point(titleLabel.Location.X + titleLabel.Width, 3)
            //};
            //信息管理Button.FlatAppearance.BorderSize = 0;
            //titleBar.Controls.Add(信息管理Button);
            //信息管理Button.Click += 信息管理Button_Click;


            // 你注释掉了最小化、最大化、关闭按钮部分，
            // 如果想恢复，解开注释即可

            //// 拖动标题栏：启用拖动行为
            //titleLabel.MouseDown += TitleLabel_MouseDown;
            //titleBar.MouseDown += TitleBar_MouseDown;
        }

        /// <summary>
        /// 标题栏双击或鼠标按下：支持最大化/拖动功能。
        /// </summary>
        private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 2)
                {
                    TitleBar_DoubleClick(sender, e); // 双击切换大小
                }
                else
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, 0xA1, 0x2, 0); // 拖动窗口
                }
            }
        }

        /// <summary>
        /// 最大化按钮点击事件
        /// </summary>
        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                maximizeButton.Text = "❐";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                maximizeButton.Text = "▢";
            }
        }

        // 拖动窗体的原生支持（Win32 API）
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        /// <summary>
        /// 窗体标题改变时同步更新标题栏文本
        /// </summary>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (titleLabel != null)
                titleLabel.Text = this.Text;
        }

        /// <summary>
        /// 重写窗口消息，支持边框缩放（模拟 Windows 原生窗口边框行为）
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTCLIENT = 1;
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);

                if ((int)m.Result == HTCLIENT)
                {
                    Point cursor = PointToClient(Cursor.Position);
                    int gripSize = 5;

                    if (cursor.Y <= gripSize)
                    {
                        if (cursor.X <= gripSize)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (cursor.X >= this.ClientSize.Width - gripSize)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else
                            m.Result = (IntPtr)HTTOP;
                    }
                    else if (cursor.Y >= this.ClientSize.Height - gripSize)
                    {
                        if (cursor.X <= gripSize)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else if (cursor.X >= this.ClientSize.Width - gripSize)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else
                            m.Result = (IntPtr)HTBOTTOM;
                    }
                    else if (cursor.X <= gripSize)
                    {
                        m.Result = (IntPtr)HTLEFT;
                    }
                    else if (cursor.X >= this.ClientSize.Width - gripSize)
                    {
                        m.Result = (IntPtr)HTRIGHT;
                    }
                }
                return;
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// 默认生成方法（保留，不影响主逻辑）
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "CustomForm";
            this.Load += new System.EventHandler(this.CustomForm_Load);
            this.ResumeLayout(false);
        }

        private void CustomForm_Load(object sender, EventArgs e)
        {
            // 可放置初始化逻辑
        }
    }
}
