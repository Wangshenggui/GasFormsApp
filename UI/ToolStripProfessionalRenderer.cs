using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GasFormsApp.UI
{
    public class CustomProfessionalRenderer : ToolStripProfessionalRenderer
    {
        private Color _themeColor;

        public CustomProfessionalRenderer(Color themeColor)
        {
            _themeColor = themeColor;
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            // 不绘制图片边距区域
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = e.AffectedBounds;

            using (LinearGradientBrush brush = new LinearGradientBrush(bounds,
                Color.FromArgb(240, 240, 240), _themeColor, LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, bounds);
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // 不绘制边框
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = _themeColor;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (!e.Item.Enabled)
            {
                e.TextColor = Color.Gray;
            }
            else if (e.Item.Selected)
            {
                e.TextColor = Color.White;
            }
            else
            {
                e.TextColor = Color.Black;
            }

            base.OnRenderItemText(e);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);

            // 先调用基类绘制选中背景
            if (e.Item.Selected)
            {
                using (GraphicsPath path = RoundedRect(rect, 6))
                using (LinearGradientBrush brush = new LinearGradientBrush(rect,
                    Color.FromArgb(180, _themeColor),
                    Color.FromArgb(120, _themeColor),
                    LinearGradientMode.Vertical))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.FillPath(brush, path);

                    using (Pen pen = new Pen(Color.FromArgb(200, _themeColor)))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }

            // 绘制左侧竖线（例如宽度3，高度等于菜单项高度，颜色为主题色）
            int lineWidth = 1;
            int lineHeight = (int)(rect.Height * 0.85);
            int lineY = (rect.Height - lineHeight) / 2; // 居中垂直方向
            using (SolidBrush brush = new SolidBrush(_themeColor))
            {
                Rectangle lineRect = new Rectangle(0, lineY, lineWidth, lineHeight);
                g.FillRectangle(brush, lineRect);
            }
        }


        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            Rectangle rect = new Rectangle(0, e.Item.Height / 2, e.Item.Width, 1);
            using (Pen pen = new Pen(Color.FromArgb(150, _themeColor)))
            {
                e.Graphics.DrawLine(pen, rect.Left, rect.Top, rect.Right, rect.Top);
            }
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddLine(bounds.Left + radius, bounds.Top, bounds.Right - radius, bounds.Top);
            path.AddArc(bounds.Right - diameter - 1, bounds.Top, diameter, diameter, 270, 90);
            path.AddLine(bounds.Right, bounds.Top + radius, bounds.Right, bounds.Bottom - radius);
            path.AddArc(bounds.Right - diameter - 1, bounds.Bottom - diameter - 1, diameter, diameter, 0, 90);
            path.AddLine(bounds.Right - radius, bounds.Bottom, bounds.Left + radius, bounds.Bottom);
            path.AddArc(bounds.Left, bounds.Bottom - diameter - 1, diameter, diameter, 90, 90);
            path.AddLine(bounds.Left, bounds.Bottom - radius, bounds.Left, bounds.Top + radius);

            path.CloseFigure();
            return path;
        }
    }

    public class CustomMenuStrip : MenuStrip
    {
        private Color _themeColor = Color.DodgerBlue;

        public CustomMenuStrip()
        {
            this.Renderer = new CustomProfessionalRenderer(_themeColor);
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;

            // 订阅菜单项的 DropDownOpening 事件，调整宽度
            this.ItemAdded += CustomMenuStrip_ItemAdded;
        }

        private void CustomMenuStrip_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item is ToolStripMenuItem menuItem)
            {
                menuItem.DropDownOpening += MenuItem_DropDownOpening;
            }
        }

        private void MenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.DropDown is ToolStripDropDownMenu dropDown)
            {
                int minWidth = 180; // 最小宽度
                if (dropDown.Width < minWidth)
                {
                    dropDown.Width = minWidth;
                }
            }
        }

        public Color ThemeColor
        {
            get { return _themeColor; }
            set
            {
                _themeColor = value;
                this.Renderer = new CustomProfessionalRenderer(_themeColor);
                this.Invalidate();
            }
        }
    }
}
