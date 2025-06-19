using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace GasFormsApp.UI
{
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
