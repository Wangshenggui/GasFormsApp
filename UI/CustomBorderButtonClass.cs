using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasFormsApp.UI
{
    /// <summary>
    /// 表示按钮四个边的标志枚举，可组合使用。
    /// </summary>
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

    /// <summary>
    /// 自定义按钮控件，支持指定边框绘制、悬停变色等功能。
    /// </summary>
    public class CustomBorderButton : Button
    {
        private bool isHovered = false; // 是否鼠标悬停（备用）

        /// <summary>
        /// 按钮边框颜色，默认白色。
        /// </summary>
        public Color BorderColor { get; set; } = Color.White;

        /// <summary>
        /// 边框宽度，单位为像素，默认 1。
        /// </summary>
        public int BorderWidth { get; set; } = 1;

        /// <summary>
        /// 鼠标悬停时的背景颜色，默认红色。
        /// </summary>
        public Color HoverBackColor { get; set; } = Color.Red;

        /// <summary>
        /// 默认背景颜色（未悬停），默认为深蓝色。
        /// </summary>
        public Color NormalBackColor { get; set; } = Color.FromArgb(17, 45, 78);

        /// <summary>
        /// 指定要绘制哪几条边的边框。
        /// </summary>
        public BorderSides Borders { get; set; } = BorderSides.Top;

        /// <summary>
        /// 构造函数，设置默认外观。
        /// </summary>
        public CustomBorderButton()
        {
            this.BackColor = NormalBackColor;
            this.FlatStyle = FlatStyle.Flat; // 去除默认 3D 边框
            this.FlatAppearance.BorderSize = 0; // 不使用 WinForms 默认边框
        }

        /// <summary>
        /// 重写绘制事件，自定义边框绘制。
        /// </summary>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            using (Pen pen = new Pen(BorderColor, BorderWidth))
            {
                var g = pevent.Graphics;
                int w = this.Width;
                int h = this.Height;
                int bw = BorderWidth;

                // 分别判断每条边是否要绘制
                if (Borders.HasFlag(BorderSides.Top))
                    g.DrawLine(pen, 0, 0, w, 0);
                if (Borders.HasFlag(BorderSides.Bottom))
                    g.DrawLine(pen, 0, h - bw, w, h - bw);
                if (Borders.HasFlag(BorderSides.Left))
                    g.DrawLine(pen, 0, 0, 0, h);
                if (Borders.HasFlag(BorderSides.Right))
                    g.DrawLine(pen, w - bw + 2, 0, w - bw + 2, h);
                // 右边多加 2 像素，防止边框偏移（可根据 UI 调整）
            }
        }

        /// <summary>
        /// 鼠标移入事件，切换为悬停背景色。
        /// </summary>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = HoverBackColor;
        }

        /// <summary>
        /// 鼠标移出事件，恢复默认背景色。
        /// </summary>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = NormalBackColor;
        }
    }
}
