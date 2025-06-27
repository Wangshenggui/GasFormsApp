using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasFormsApp.UI
{
    /// <summary>
    /// 自定义的 FlowLayoutPanel，启用双缓冲以防止刷新时的闪烁。
    /// 通常用于频繁重绘或动态添加控件的界面。
    /// </summary>
    public class DoubleBufferedFlowLayoutPanel : FlowLayoutPanel
    {
        // 注意：这个字段没有实质用途，在当前类中并不会被调用
        // 是多余的自动生成代码
        private FlowLayoutPanel flowLayoutPanel1;

        /// <summary>
        /// 构造函数，启用双缓冲和重绘时刷新。
        /// </summary>
        public DoubleBufferedFlowLayoutPanel()
        {
            this.DoubleBuffered = true;    // 开启双缓冲，减少闪烁
            this.ResizeRedraw = true;      // 在控件尺寸改变时自动重绘
        }
    }
}
