using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 工具栏逻辑处理
namespace GasFormsApp.TabControl
{
    internal class ToolBarClass
    {
        private MainForm _mainForm;  // 持有主窗体引用，访问控件

        private MenuStrip _ToolBarMenuStrip;

        // 构造函数，传入主窗体对象，绑定相关事件
        public ToolBarClass(MainForm form, MenuStrip _MenuStrip)
        {
            _mainForm = form;
            _ToolBarMenuStrip = _MenuStrip;

            // 假设菜单里已经有若干菜单项，我们给它们绑定事件
            foreach (ToolStripItem item in _ToolBarMenuStrip.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Click += MenuItem_Click;

                    // 如果有子菜单，递归绑定
                    BindClickRecursive(menuItem);
                }
            }
        }
        private void BindClickRecursive(ToolStripMenuItem parent)
        {
            foreach (ToolStripItem item in parent.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Click += MenuItem_Click;
                    BindClickRecursive(menuItem);
                }
            }
        }
        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem clickedItem)
            {
                // 根据Text判断
                if (clickedItem.Text.Trim() == "恢复上次编辑")
                {
                    // 获取当前用户的 AppData\Roaming 目录
                    string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    // 拼接程序专用目录
                    string tempFolder = Path.Combine(appData, "瓦斯含量测定数据分析系统", "TempData");

                    // 目标文件路径
                    string loadPath = Path.Combine(tempFolder, "tabPage1_temp.bin");
                    if (!File.Exists(loadPath))
                    {
                        // 文件不存在时的处理（可选）
                    }
                    else
                    {
                        _mainForm.Tool_tab1_tabPage1RecoverDataButton(sender, e);
                    }

                    // 目标文件路径
                    loadPath = Path.Combine(tempFolder, "tabPage2_temp.bin");
                    if (!File.Exists(loadPath))
                    {
                        // 文件不存在时的处理（可选）
                    }
                    else
                    {
                        _mainForm.Tool_tab2_tabPage2RecoverDataButton(sender, e);
                    }

                    // 目标文件路径
                    loadPath = Path.Combine(tempFolder, "tabPage3_temp.bin");
                    if (!File.Exists(loadPath))
                    {
                        // 文件不存在时的处理（可选）
                    }
                    else
                    {
                        _mainForm.Tool_tab3_tabPage3RecoverDataButton(sender, e);
                    }

                    // 目标文件路径
                    loadPath = Path.Combine(tempFolder, "tabPage4_temp.bin");
                    if (!File.Exists(loadPath))
                    {
                        // 文件不存在时的处理（可选）
                    }
                    else
                    {
                        _mainForm.Tool_tab4_tabPage4RecoverDataButton(sender, e);
                    }

                    // 目标文件路径
                    loadPath = Path.Combine(tempFolder, "tabPage5_temp.bin");
                    if (!File.Exists(loadPath))
                    {
                        // 文件不存在时的处理（可选）
                    }
                    else
                    {
                        _mainForm.Tool_tab5_tabPage5RecoverDataButton(sender, e);
                    }


                }
            }
        }
    }
}
