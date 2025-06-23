using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace GasFormsApp.UI
{
    [Flags]
    public enum BorderSides
    {
        None = 0,
        Left = 1,
        Top = 2,
        Right = 4,
        Bottom = 8,
        All = Left | Top | Right | Bottom
    }

    public class CustomBorderButton : Button
    {
        private bool isHovered = false;

        public Color BorderColor { get; set; } = Color.White;
        public int BorderWidth { get; set; } = 1;

        public Color HoverBackColor { get; set; } = Color.Red;  // 鼠标悬停背景色
        public Color NormalBackColor { get; set; } = Color.FromArgb(17, 45, 78); // 正常背景色

        public BorderSides Borders { get; set; } = BorderSides.Top;

        public CustomBorderButton()
        {
            this.BackColor = NormalBackColor;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            using (Pen pen = new Pen(BorderColor, BorderWidth))
            {
                var g = pevent.Graphics;
                int w = this.Width;
                int h = this.Height;
                int bw = BorderWidth;

                if (Borders.HasFlag(BorderSides.Top))
                    g.DrawLine(pen, 0, 0, w, 0);
                if (Borders.HasFlag(BorderSides.Bottom))
                    g.DrawLine(pen, 0, h - bw, w, h - bw);
                if (Borders.HasFlag(BorderSides.Left))
                    g.DrawLine(pen, 0, 0, 0, h);
                if (Borders.HasFlag(BorderSides.Right))
                    g.DrawLine(pen, w - bw+2, 0, w - bw+2, h);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = HoverBackColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = NormalBackColor;
        }
    }


    public class CustomForm : Form
    {
        private Panel titleBar;
        private Label titleLabel;
        private Button closeButton;
        private Button minimizeButton;
        private Button maximizeButton;

        private Panel borderLeft;
        private Panel borderRight;
        private Panel borderTop;

        // 工具栏按钮
        private Button 账户管理Button;

        private void InitializeBorder()
        {
            int borderWidth = 2;
            Color borderColor = Color.White;

            // 先加左边框
            borderLeft = new Panel
            {
                BackColor = borderColor,
                Dock = DockStyle.Left,
                Width = borderWidth
            };
            this.Controls.Add(borderLeft);

            // 再加右边框
            borderRight = new Panel
            {
                BackColor = borderColor,
                Dock = DockStyle.Right,
                Width = borderWidth
            };
            this.Controls.Add(borderRight);

            // 最后加上边框
            borderTop = new Panel
            {
                BackColor = borderColor,
                Dock = DockStyle.Top,
                Height = borderWidth
            };
            this.Controls.Add(borderTop);

            // 确保边框都在最顶层（不会被其它控件遮挡）
            borderLeft.BringToFront();
            borderRight.BringToFront();
            borderTop.BringToFront();

            
        }
        private void TitleBar_DoubleClick(object sender, EventArgs e)
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

        public CustomForm()
        {
            this.SetStyle(ControlStyles.StandardDoubleClick, true); // 👈 关键行
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 200);
            this.Padding = new Padding(2);

            InitializeCustomTitleBar();
            InitializeBorder();
        }


        private void InitializeCustomTitleBar()
        {
            // 标题栏背景色黑色
            titleBar = new Panel
            {
                Height = 30,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(17, 45, 78)
            };
            this.Controls.Add(titleBar);

            // 左边白色边框
            var borderLeft = new Panel
            {
                Width = 0,
                Dock = DockStyle.Left,
                BackColor = Color.White
            };
            titleBar.Controls.Add(borderLeft);
            borderLeft.BringToFront();

            // 右边白色边框
            var borderRight = new Panel
            {
                Width = 0,
                Dock = DockStyle.Right,
                BackColor = Color.White
            };
            titleBar.Controls.Add(borderRight);
            borderRight.BringToFront();

            // 上边白色边框
            var borderTop = new Panel
            {
                Height = 0,
                Dock = DockStyle.Top,
                BackColor = Color.White
            };
            titleBar.Controls.Add(borderTop);
            borderTop.BringToFront();

            titleLabel = new Label
            {
                Text = this.Text,
                ForeColor = Color.LightGray,
                AutoSize = false,
                Dock = DockStyle.None,  // 取消填充
                Width = 200,            // 根据需求调整宽度
                Height = 30,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };
            titleLabel.Location = new Point(0, 0);
            titleBar.Controls.Add(titleLabel);

            //账户管理Button
            // 添加标签
            titleBar.Controls.Add(titleLabel);

            // 账户管理按钮
            账户管理Button = new CustomBorderButton
            {
                Text = " 账户管理 ",
                BackColor = Color.FromArgb(17, 45, 78),
                FlatStyle = FlatStyle.Flat,
                Width = 85,
                Borders = BorderSides.Left | 0,
                HoverBackColor = Color.FromArgb(80, 80, 80),
                //Dock = DockStyle.Right,
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BorderColor = Color.White,
                BorderWidth = 2,
                TabStop = false
            };
            账户管理Button.FlatAppearance.BorderSize = 0;

            // 这里计算按钮的位置，紧跟标签后面
            账户管理Button.Location = new Point(titleLabel.Location.X + titleLabel.Width, 3);

            // 添加点击事件
            账户管理Button.Click += (s, e) =>
            {
                MessageBox.Show("你点击了标题栏上的按钮！");
            };

            titleBar.Controls.Add(账户管理Button);


            // 最小化按钮，纯黑背景，悬停变暗灰
            minimizeButton = new CustomBorderButton
            {
                Text = "—",
                BackColor = Color.FromArgb(17, 45, 78),
                FlatStyle = FlatStyle.Flat,
                Width = 45,
                Borders = 0,
                HoverBackColor = Color.FromArgb(80, 80, 80),
                Dock = DockStyle.Right,
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BorderColor = Color.White,
                BorderWidth = 1,
                TabStop = false
            };
            minimizeButton.FlatAppearance.BorderSize = 0; // 禁用默认边框
            minimizeButton.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            titleBar.Controls.Add(minimizeButton);


            // 最大化按钮，纯黑背景，悬停变暗灰，带上边框
            maximizeButton = new CustomBorderButton
            {
                Text = "▢",
                BackColor = Color.FromArgb(17, 45, 78),
                FlatStyle = FlatStyle.Flat,
                Width = 45,
                Borders = 0,
                HoverBackColor = Color.FromArgb(80, 80, 80),
                Dock = DockStyle.Right,
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BorderColor = Color.White,
                BorderWidth = 1,
                TabStop = false
            };
            maximizeButton.FlatAppearance.BorderSize = 0;
            maximizeButton.Click += MaximizeButton_Click;
            titleBar.Controls.Add(maximizeButton);

            // 关闭按钮，纯黑背景，红色悬停，带上边框
            closeButton = new CustomBorderButton
            {
                Text = "X",
                BackColor = Color.FromArgb(17, 45, 78),
                FlatStyle = FlatStyle.Flat,
                Width = 45,
                Borders = 0,
                HoverBackColor = Color.FromArgb(232, 17, 35),
                Dock = DockStyle.Right,
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BorderColor = Color.White,
                BorderWidth = 1,
                TabStop = false
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (s, e) => this.Close();
            titleBar.Controls.Add(closeButton);


            // 拖动
            titleLabel.MouseDown += TitleLabel_MouseDown;
            titleBar.MouseDown += TitleLabel_MouseDown;
        }
        private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 2)
                {
                    // 处理双击最大化/还原
                    TitleBar_DoubleClick(sender, e);
                }
                else
                {
                    // 单击拖动
                    ReleaseCapture();
                    SendMessage(this.Handle, 0xA1, 0x2, 0);
                }
            }
        }
        private void MaximizeButton_Click(object sender, EventArgs e)
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

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (titleLabel != null)
            {
                titleLabel.Text = this.Text;
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTCLIENT = 1;
            const int HTCAPTION = 2;
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
                    int gripSize = 5; // 边缘宽度

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

    }


    public class DoubleBufferedFlowLayoutPanel : FlowLayoutPanel
    {
        private FlowLayoutPanel flowLayoutPanel1;

        public DoubleBufferedFlowLayoutPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            this.ResumeLayout(false);

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class DoubleBufferedPanel : Panel
    {
        private Panel panel1;

        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            //InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.Controls.Add(this.panel1); // ← 加入子控件
            this.ResumeLayout(false);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // 可以在这里进行自定义绘图
        }
    }



    // 定义按钮上图片的对齐方式枚举
    public enum ImageAlign
    {
        Left,
        Center,
        Right
    }

    // 定义按钮背景填充方式枚举
    public enum FillMode
    {
        Solid,      // 纯色填充
        Gradient    // 渐变填充
    }

    // 自定义按钮控件，继承自System.Windows.Forms.Button
    public class UCButton : Button
    {
        #region  公共字段、属性

        private bool _selectedState = false; // 按钮选中状态，私有字段
        private bool _isHover = false;       // 鼠标悬停状态标志
        private Color _pressedColor = Color.Silver; // 鼠标按下时按钮背景色
        private bool _isPressed = false;     // 鼠标按下状态标志
        private FillMode _fillMode = FillMode.Solid; // 按钮背景填充方式，默认纯色

        // 按钮背景填充方式属性（可在属性窗口设置）
        [Category("UserProperty")]
        [Description("按钮背景填充方式")]
        [DefaultValue(FillMode.Solid)]
        public FillMode FillMode
        {
            get => _fillMode;
            set
            {
                _fillMode = value;
                this.Invalidate(); // 属性修改后重绘控件
            }
        }

        private Image _buttonImage;          // 按钮上显示的图片
        private ImageAlign _imageAlign = ImageAlign.Left; // 图片对齐方式，默认左对齐

        // 图片对齐方式属性
        [Category("UserProperty")]
        [Description("图片对齐方式")]
        [DefaultValue(ImageAlign.Left)]
        public ImageAlign ImageAlign
        {
            get => _imageAlign;
            set
            {
                _imageAlign = value;
                this.Invalidate();
            }
        }

        // 按钮图片属性，支持在设计器中编辑
        [Category("UserProperty")]
        [Description("按钮上的图片")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor(typeof(System.Drawing.Design.ImageEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Image ButtonImage
        {
            get => _buttonImage;
            set
            {
                _buttonImage = value;
                this.Invalidate();
            }
        }

        // 鼠标按下时的背景色属性
        [Category("UserProperty")]
        [Description("鼠标按下时的背景色")]
        public Color PressedColor
        {
            get => _pressedColor;
            set
            {
                _pressedColor = value;
                this.Invalidate();
            }
        }

        // 选中状态属性，只读外部不可设置
        [Category("UserProperty")]
        [Description("选中状态")]
        public bool SelectedState
        {
            get => _selectedState;
            private set
            {
                _selectedState = value;
                this.Invalidate();
            }
        }

        private int radius = 15; // 按钮圆角半径，默认15像素

        // 圆角半径属性
        [Category("UserProperty")]
        [Description("圆角半径")]
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                this.Invalidate();
            }
        }

        private Color _defaultColor; // 按钮默认背景色（初始值）

        private Color _hoverColor = Color.LightBlue; // 鼠标悬停时的背景色，默认浅蓝

        // 鼠标悬停时背景色属性
        [Category("UserProperty")]
        [Description("鼠标悬停时的背景色")]
        public Color HoverColor
        {
            get => _hoverColor;
            set => _hoverColor = value;
        }
        #endregion

        // 构造函数，初始化控件
        public UCButton()
        {
            Initialize();
        }

        // 初始化方法，设置控件样式和事件
        private void Initialize()
        {
            this.DoubleBuffered = true; // 双缓冲，减少闪烁
            this.FlatStyle = FlatStyle.Flat; // 扁平化样式
            this.FlatAppearance.BorderSize = 0; // 无边框

            // 设置控件支持自绘等样式
            this.SetStyle(ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.SupportsTransparentBackColor, true);

            _defaultColor = BackColor; // 记录初始背景色

            // 鼠标进入事件，设置悬停标志并重绘
            this.MouseEnter += (s, e) =>
            {
                _isHover = true;
                this.Invalidate();
            };
            // 鼠标离开事件，取消悬停标志并重绘
            this.MouseLeave += (s, e) =>
            {
                _isHover = false;
                this.Invalidate();
            };

            // 鼠标按下事件，设置按下标志并重绘
            this.MouseDown += (s, e) =>
            {
                _isPressed = true;
                this.Invalidate();
            };
            // 鼠标弹起事件，取消按下标志并重绘
            this.MouseUp += (s, e) =>
            {
                _isPressed = false;
                this.Invalidate();
            };
        }

        // 鼠标进入控件时调用，修改背景色为悬停色，触发重绘
        private void UCButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = HoverColor;
            _isHover = true;
            this.Invalidate();
        }

        // 鼠标离开控件时调用，恢复默认背景色，触发重绘
        private void UCButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = _defaultColor;
            _isHover = false;
            this.Invalidate();
        }

        // 重写点击事件处理，可以在这里扩展选中状态逻辑
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            // 这里保留选中状态的切换，注释掉表示暂时不自动切换选中状态
            //_selectedState = !_selectedState;
            this.Invalidate();
        }

        // 控件大小变化时重写，更新圆角区域
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                // 创建四个圆角的路径
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                // 设置控件区域为圆角路径，实现在控件边缘裁剪圆角效果
                this.Region = new Region(path);
            }
        }

        // 重写绘制事件，实现自定义绘制逻辑
        protected override void OnPaint(PaintEventArgs e)
        {
            // 设置高质量绘图参数，抗锯齿等
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // 清除背景，填充父控件背景色，避免闪烁
            e.Graphics.Clear(this.Parent?.BackColor ?? Color.White);

            using (GraphicsPath path = new GraphicsPath())
            {
                int r = radius;
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

                // 构建圆角路径
                path.AddArc(rect.Left, rect.Top, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Top, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.Left, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();

                // 重新设置控件区域为圆角路径
                this.Region = new Region(path);

                Color bgColor = _defaultColor;

                // 根据控件状态决定背景色
                if (_isPressed)
                    bgColor = _pressedColor;
                else if (_selectedState)
                    bgColor = HoverColor;
                else if (_isHover)
                    bgColor = HoverColor;

                Brush brush = null;

                // 根据状态和填充模式选择刷子
                if (_isPressed)
                {
                    if (_fillMode == FillMode.Solid)
                        brush = new SolidBrush(_pressedColor);
                    else
                        brush = new LinearGradientBrush(rect, ControlPaint.Dark(_pressedColor), _pressedColor, 90f);
                }
                else if (_selectedState)
                {
                    if (_fillMode == FillMode.Solid)
                        brush = new SolidBrush(HoverColor);
                    else
                        brush = new LinearGradientBrush(rect, ControlPaint.Light(HoverColor), HoverColor, 45f);
                }
                else if (_isHover)
                {
                    if (_fillMode == FillMode.Solid)
                        brush = new SolidBrush(HoverColor);
                    else
                        brush = new LinearGradientBrush(rect, Color.LightBlue, Color.Blue, 45f);
                }
                else
                {
                    brush = new SolidBrush(_defaultColor);
                }

                // 填充按钮背景
                using (brush)
                {
                    e.Graphics.FillPath(brush, path);
                }

                // 绘制按钮上的图片（如果有）
                if (_buttonImage != null)
                {
                    int imgY = (this.Height - _buttonImage.Height) / 2; // 垂直居中
                    int imgX = 0;

                    // 根据图片对齐方式计算X坐标
                    switch (_imageAlign)
                    {
                        case ImageAlign.Left:
                            imgX = 5; // 左边距5像素
                            break;
                        case ImageAlign.Center:
                            imgX = (this.Width - _buttonImage.Width) / 2;
                            break;
                        case ImageAlign.Right:
                            imgX = this.Width - _buttonImage.Width - 5; // 右边距5像素
                            break;
                    }

                    // 绘制图片
                    e.Graphics.DrawImage(_buttonImage, imgX, imgY, _buttonImage.Width, _buttonImage.Height);
                }

                // 绘制按钮文字，水平和垂直居中显示
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, rect,
                    this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
