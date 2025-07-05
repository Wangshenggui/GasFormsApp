using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GasFormsApp.UI
{
    public class DoubleBufferedFlowLayoutPanel : FlowLayoutPanel
    {
        //private int _cornerRadius = 12;

        //public int CornerRadius
        //{
        //    get => _cornerRadius;
        //    set { _cornerRadius = value; UpdateRegion(); Invalidate(); }
        //}

        public DoubleBufferedFlowLayoutPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.SupportsTransparentBackColor, true);

            this.DoubleBuffered = true;
            //this.BackColor = Color.White; // 背景色不要用 Transparent
        }

        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        //    using (GraphicsPath path = GetRoundedRectPath(this.ClientRectangle, _cornerRadius))
        //    using (Brush brush = new SolidBrush(this.BackColor))
        //    {
        //        e.Graphics.FillPath(brush, path);
        //    }
        //}

        //protected override void OnResize(EventArgs e)
        //{
        //    base.OnResize(e);
        //    UpdateRegion();
        //}

        //private void UpdateRegion()
        //{
        //    Rectangle rect = this.ClientRectangle;

        //    if (rect.Width > 0 && rect.Height > 0)
        //    {
        //        using (GraphicsPath path = GetRoundedRectPath(rect, _cornerRadius))
        //        {
        //            this.Region?.Dispose();
        //            this.Region = new Region(path);
        //        }
        //    }
        //}

        //private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius, int offset = 1)
        //{
        //    int diameter = radius * 2;
        //    GraphicsPath path = new GraphicsPath();

        //    path.StartFigure();
        //    path.AddArc(rect.X - offset, rect.Y - offset, diameter, diameter, 180, 90);                         // 左上
        //    path.AddArc(rect.Right - diameter + offset, rect.Y - offset, diameter, diameter, 270, 90);          // 右上
        //    path.AddArc(rect.Right - diameter + offset, rect.Bottom - diameter + offset, diameter, diameter, 0, 90); // 右下
        //    path.AddArc(rect.X - offset, rect.Bottom - diameter + offset, diameter, diameter, 90, 90);          // 左下
        //    path.CloseFigure();

        //    return path;
        //}

    }
}
