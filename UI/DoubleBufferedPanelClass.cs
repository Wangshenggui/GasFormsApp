using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasFormsApp.UI
{
    /// <summary>
    /// 自定义的 Panel，开启双缓冲以减少重绘时的闪烁。
    /// 也支持在 Resize 时自动重绘。
    /// </summary>
    public class DoubleBufferedPanel : Panel
    {
        // 声明一个内部的 Panel 控件，但目前用处不大
        private Panel panel1;

        /// <summary>
        /// 构造函数，启用双缓冲和重绘时刷新。
        /// 注释掉了 InitializeComponent 方法调用，避免重复添加子控件。
        /// </summary>
        public DoubleBufferedPanel()
        {
            // 开启双缓冲，减少闪烁
            this.DoubleBuffered = true;

            // 控件大小改变时自动重绘
            this.ResizeRedraw = true;
        }
    }
}
