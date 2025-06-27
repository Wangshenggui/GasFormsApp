using DocumentFormat.OpenXml.Office.SpreadSheetML.Y2023.MsForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GasFormsApp.UI
{
    // 定义按钮上图片的对齐方式
    public enum ImageAlign
    {
        Left,   // 左对齐
        Center, // 居中
        Right   // 右对齐
    }

    // 定义按钮背景填充的模式
    public enum FillMode
    {
        Solid,      // 纯色填充
        Gradient    // 渐变填充
    }

    /// <summary>
    /// 自定义按钮控件，支持圆角、图片显示、渐变填充及鼠标交互效果
    /// </summary>
    public class UCButton : Button
    {
        #region 公共字段和属性

        private bool _selectedState = false;       // 记录按钮是否处于选中状态（只读）
        private bool _isHover = false;             // 鼠标是否悬停
        private Color _pressedColor = Color.Silver;// 鼠标按下时背景色
        private bool _isPressed = false;           // 鼠标是否按下
        private FillMode _fillMode = FillMode.Solid; // 背景填充方式，默认纯色填充

        // 按钮背景填充方式属性，支持设计器设置
        [Category("UserProperty")]
        [Description("按钮背景填充方式")]
        [DefaultValue(FillMode.Solid)]
        public FillMode FillMode
        {
            get => _fillMode;
            set
            {
                _fillMode = value;
                this.Invalidate(); // 变更时重绘控件
            }
        }

        private Image _buttonImage;                 // 按钮上显示的图片
        private ImageAlign _imageAlign = ImageAlign.Left; // 图片对齐方式，默认左对齐

        // 图片对齐方式属性，支持设计器
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

        // 按钮上的图片属性，支持设计器设置
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

        // 只读的选中状态属性，外部无法设置
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

        private int radius = 15; // 圆角半径，默认15像素

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

        private Color _defaultColor;           // 按钮默认背景色，初始化时保存
        private Color _hoverColor = Color.LightBlue;  // 鼠标悬停时的背景色

        // 鼠标悬停背景色属性
        [Category("UserProperty")]
        [Description("鼠标悬停时的背景色")]
        public Color HoverColor
        {
            get => _hoverColor;
            set => _hoverColor = value;
        }

        #endregion

        /// <summary>
        /// 构造函数，初始化按钮样式和事件
        /// </summary>
        public UCButton()
        {
            Initialize();
        }

        /// <summary>
        /// 初始化方法，设置控件样式和事件
        /// </summary>
        private void Initialize()
        {
            this.DoubleBuffered = true; // 双缓冲减少闪烁
            this.FlatStyle = FlatStyle.Flat; // 扁平化按钮风格
            this.FlatAppearance.BorderSize = 0; // 无边框

            // 设置支持自定义绘制和透明背景
            this.SetStyle(ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.SupportsTransparentBackColor, true);

            _defaultColor = BackColor; // 保存默认背景色

            // 鼠标事件，设置对应状态并重绘
            this.MouseEnter += (s, e) =>
            {
                _isHover = true;
                this.Invalidate();
            };
            this.MouseLeave += (s, e) =>
            {
                _isHover = false;
                this.Invalidate();
            };
            this.MouseDown += (s, e) =>
            {
                _isPressed = true;
                this.Invalidate();
            };
            this.MouseUp += (s, e) =>
            {
                _isPressed = false;
                this.Invalidate();
            };
        }

        /// <summary>
        /// 重写点击事件，可用于切换选中状态
        /// 当前切换逻辑被注释，可根据需要打开
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            // _selectedState = !_selectedState;
            this.Invalidate();
        }

        /// <summary>
        /// 控件大小变化时，重新设置圆角区域
        /// </summary>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                // 创建圆角路径，四个角分别绘制圆弧
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                // 设置控件的裁剪区域，实现圆角效果
                this.Region = new Region(path);
            }
        }

        /// <summary>
        /// 重写绘制事件，实现自定义的按钮绘制
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // 设置高质量绘图参数，防止锯齿和模糊
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // 清除绘图表面，填充父控件背景色，避免闪烁
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

                // 重新设置控件区域，确保裁剪区域与大小一致
                this.Region = new Region(path);

                Color bgColor = _defaultColor;

                // 根据不同状态设置背景颜色
                if (_isPressed)
                    bgColor = _pressedColor;
                else if (_selectedState)
                    bgColor = HoverColor;
                else if (_isHover)
                    bgColor = HoverColor;

                Brush brush = null;

                // 根据当前状态和填充模式选择画刷
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

                    // 根据图片对齐方式计算横坐标
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

                // 绘制按钮文字，水平垂直居中显示
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, rect,
                    this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
