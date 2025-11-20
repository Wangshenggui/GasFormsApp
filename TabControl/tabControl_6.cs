using AntdUI;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Presentation;
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static GasFormsApp.TabControl.tabControl_2;
using static Google.Protobuf.Reflection.FieldDescriptorProto.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using Control = System.Windows.Forms.Control;
using FolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;
using Font = System.Drawing.Font;
using Image = System.Drawing.Image;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using Microsoft.VisualBasic.FileIO;
using SearchOption = System.IO.SearchOption;

namespace GasFormsApp.TabControl
{
    internal class tabControl_6
    {
        private MainForm _mainForm;


        public tabControl_6(MainForm form)
        {
            _mainForm = form;

            _mainForm.toolTip1.SetToolTip(_mainForm.FindTextBox, "查 找(Ctrl + F)");
            _mainForm.toolTip1.SetToolTip(_mainForm.label30, "查 找(Ctrl + F)");
            _mainForm.toolTip1.SetToolTip(_mainForm.ReloadDataButton, "刷 新(Ctrl + R)");
            _mainForm.toolTip1.SetToolTip(_mainForm.DeleteDataButton, "删 除(Ctrl + D)");
            _mainForm.toolTip1.SetToolTip(_mainForm.ExportTheDocumentButton, "导出报告(Ctrl + G)");


            // 注册“重新加载数据”按钮的点击事件处理器
            _mainForm.ReloadDataButton.Click += ReloadDataButton_Click;

            // 注册“删除数据”按钮的点击事件处理器
            _mainForm.DeleteDataButton.Click += DeleteDataButton_Click;

            // 注册“导出文档”按钮的点击事件处理器
            _mainForm.ExportTheDocumentButton.Click += ExportTheDocumentButton_Click;

            // 为 DataGridView 的 RowPostPaint 事件注册回调，用于自定义行的绘制（如绘制行号）
            _mainForm.dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;

            // 禁用 DataGridView 的默认剪贴板复制功能（防止用户 Ctrl+C 复制内容）
            _mainForm.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;

            // 注册键盘按下事件（如拦截 Ctrl+C、Delete 等操作）
            _mainForm.dataGridView1.KeyDown += dataGridView1_KeyDown;

            // 注册单元格双击事件（通常用于打开编辑窗口或详情视图）
            _mainForm.dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

            // 注册选中单元格变化事件（可以用于同步其他 UI 状态）
            _mainForm.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            // 注册单元格开始编辑事件的匿名函数，用于调试或日志记录编辑行为
            _mainForm.dataGridView1.CellBeginEdit += (s, e) =>
            {
                Console.WriteLine($"CellBeginEdit at row {e.RowIndex}, col {e.ColumnIndex}");
            };
            _mainForm.dataGridView1.MouseDown += dataGridView1_MouseDown;
            _mainForm.dataGridView1.CellClick += dataGridView1_CellClick;

            _mainForm.恢复历史记录ToolStripMenuItem.Click += 恢复历史记录ToolStripMenuItem_Click;



            // 获取当前用户的 AppData\Roaming 路径
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // 拼接程序专用目录：AppData\Roaming\瓦斯含量测定数据分析系统\SystemData\DataAdministrationForm
            string rootPath = Path.Combine(appDataPath, "瓦斯含量测定数据分析系统", "SystemData", "DataAdministrationForm");

            // 如果路径不存在则创建
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            // 加载该路径下的文件夹结构到树控件
            LoadFoldersToTree(rootPath);
            // 绑定树控件节点选中事件
            _mainForm.treeView1.AfterSelect += treeView1_AfterSelect;
            _mainForm.treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            _mainForm.treeView1.DrawNode += treeView1_DrawNode;
            _mainForm.treeView1.AfterLabelEdit += treeView1_AfterLabelEdit;
            _mainForm.FindMineTextBox.KeyDown += FindMineTextBox_KeyDown;

            _mainForm.FindTextBox.KeyDown += FindTextBox_KeyDown;
            _mainForm.treeView1.MouseDown += treeView1_MouseDown;
            _mainForm.treeView1.AfterExpand += treeView1_AfterExpand;
            //_mainForm.treeView1.ItemDrag += treeView1_ItemDrag;
            //_mainForm.treeView1.DragEnter += treeView1_DragEnter;
            //_mainForm.treeView1.DragOver += treeView1_DragOver;
            _mainForm.treeView1.ItemDrag += treeView1_ItemDrag;
            _mainForm.treeView1.DragEnter += treeView1_DragEnter;
            _mainForm.treeView1.DragOver += treeView1_DragOver;
            _mainForm.treeView1.DragLeave += treeView1_DragLeave;
            _mainForm.treeView1.DragDrop += treeView1_DragDrop;

            _mainForm.刷新ToolStripMenuItem.Click += 刷新ToolStripMenuItem_Click;
            _mainForm.导出矿井Excel统计表ToolStripMenuItem.Click += 导出矿井Excel统计表ToolStripMenuItem_Click;
            _mainForm.导出矿井数据ToolStripMenuItem.Click += 导出矿井数据ToolStripMenuItem_Click;
            _mainForm.合并矿井数据ToolStripMenuItem.Click += 合并矿井数据ToolStripMenuItem_Click;
            _mainForm.删除项目ToolStripMenuItem.Click += 删除项目ToolStripMenuItem_Click;
            _mainForm.删除煤矿及项目ToolStripMenuItem.Click += 删除煤矿及项目ToolStripMenuItem_Click;
            _mainForm.重命名ToolStripMenuItem.Click += 重命名ToolStripMenuItem_Click;

            // 检测数据是否有变化
            InitFileSystemWatcher();
        }

        private ImageList dragImageList;
        private Bitmap SetImageOpacity(Image image, float opacity)
        {
            // opacity 范围0-1，0完全透明，1不透明
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;  // 设置透明度

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.Clear(Color.Transparent);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        // 假设你有个方法通过节点获取路径
        private string GetFilePath(TreeNode node)
        {
            // 这里根据你的实际存储路径方式改写
            // 例如：node.Tag 存了路径
            return node?.Tag as string ?? "(无路径)";
        }
        // 需要一个字段存开始拖动路径
        private string startDragPath = null;
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (!(e.Item is TreeNode node)) return;

            // 打印开始拖动日志
            startDragPath = GetFilePath(node);
            Console.WriteLine($"开始拖动节点: {node.Text}, 路径: {startDragPath}");


            // --- 你的原拖动代码 ---
            Image icon = Properties.Resources.项目;

            Font font = _mainForm.treeView1.Font;
            Size textSize = TextRenderer.MeasureText(node.Text, font);

            int padding = 4;
            int bmpWidth = icon.Width + padding + textSize.Width;
            int bmpHeight = Math.Max(icon.Height, textSize.Height);

            int maxSize = 256;
            bmpWidth = Math.Min(bmpWidth, maxSize);
            bmpHeight = Math.Min(bmpHeight, maxSize);

            Bitmap bmp = new Bitmap(bmpWidth, bmpHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.DrawImage(icon, 0, (bmpHeight - icon.Height) / 2);
                TextRenderer.DrawText(g, node.Text, font, new Point(icon.Width + padding, (bmpHeight - textSize.Height) / 2), Color.FromArgb(255, 255, 0));
            }
            bmp = SetImageOpacity(bmp, 0.99f);

            dragImageList?.Dispose();
            dragImageList = new ImageList();
            dragImageList.ColorDepth = ColorDepth.Depth32Bit;
            dragImageList.ImageSize = new Size(bmpWidth, bmpHeight);
            dragImageList.TransparentColor = Color.Transparent;

            dragImageList.Images.Add(bmp);

            IntPtr himl = dragImageList.Handle;
            Point cursorPos = Cursor.Position;

            ImageList_BeginDrag(himl, 0, 0, 0);
            ImageList_DragEnter(_mainForm.treeView1.Handle, cursorPos.X, cursorPos.Y);

            DragDropEffects effect = _mainForm.treeView1.DoDragDrop(node, DragDropEffects.Move);

            ImageList_EndDrag();
            ImageList_DragLeave(_mainForm.treeView1.Handle);

            if (dragImageList != null)
            {
                dragImageList.Dispose();
                dragImageList = null;
            }
        }
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        private static extern bool ImageList_DragShowNolock(bool fShow);

        // 拖动影像是否被隐藏
        private bool dragImageHidden = false;

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            Point pt = _mainForm.treeView1.PointToClient(new Point(e.X, e.Y));

            // 判断是否有有效的拖动数据和节点
            if (!e.Data.GetDataPresent(typeof(TreeNode)) || dragImageList == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            TreeNode targetNode = _mainForm.treeView1.GetNodeAt(pt);
            if (targetNode == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            string targetPath = GetFilePath(targetNode);
            Console.WriteLine("当前鼠标所处的节点路径：" + targetPath);

            // 获取拖拽节点
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // 禁止拖到自身或子目录
            if (string.Equals(startDragPath, targetPath, StringComparison.OrdinalIgnoreCase) ||
                targetPath.StartsWith(startDragPath + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
            {
                e.Effect = DragDropEffects.None;
                ImageList_DragShowNolock(false);
                dragImageHidden = true;
                return;
            }

            // 新增：禁止树级别1拖到级别2
            if (draggedNode.Level == 1 && targetNode.Level == 2)
            {
                e.Effect = DragDropEffects.None;
                ImageList_DragShowNolock(false);
                dragImageHidden = true;
                return;
            }

            // 新增：禁止拖到上级目录
            if (startDragPath.StartsWith(targetPath + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
            {
                e.Effect = DragDropEffects.None;
                ImageList_DragShowNolock(false);
                dragImageHidden = true;
                return;
            }

            //// 禁止拖动 Level 2 节点
            //if (draggedNode.Level == 2)
            //{
            //    e.Effect = DragDropEffects.None;
            //    ImageList_DragShowNolock(false);
            //    dragImageHidden = true;
            //    return;
            //}


            // 允许拖动
            e.Effect = DragDropEffects.Move;
            if (dragImageHidden)
                ImageList_DragShowNolock(true);

            ImageList_DragMove(pt.X, pt.Y);
            dragImageHidden = false;
        }


        // 封装：隐藏拖动影像（彻底清除残影）
        private void HideDragImage()
        {
            if (!dragImageHidden)
            {
                ImageList_DragShowNolock(false);
                ImageList_EndDrag();
                dragImageHidden = true;
            }
        }

        // 封装：恢复拖动影像并跟随鼠标
        private void ShowDragImage(Point pt)
        {
            if (dragImageList == null)
                return;

            if (dragImageHidden)
            {
                IntPtr himl = dragImageList.Handle;
                ImageList_BeginDrag(himl, 0, 0, 0);
                ImageList_DragEnter(_mainForm.treeView1.Handle, pt.X, pt.Y);
                ImageList_DragShowNolock(true);
                dragImageHidden = false;
            }

            ImageList_DragMove(pt.X, pt.Y);
        }



        private void treeView1_DragLeave(object sender, EventArgs e)
        {
            if (dragImageList != null)
                ImageList_DragLeave(_mainForm.treeView1.Handle);
        }

        // 只复制文件（不递归复制子目录）
        private void CopyFilesToDirectory(string sourceDir, string targetDir)
        {
            // 确保目标目录存在
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            // 复制文件（仅复制文件，不包括子目录）
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(targetDir, Path.GetFileName(file));
                try
                {
                    File.Copy(file, destFile, true); // true 表示覆盖同名文件
                    Console.WriteLine($"文件复制: {file} -> {destFile}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"复制文件失败: {ex.Message}");
                }
            }
        }


        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            Point pt = _mainForm.treeView1.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = _mainForm.treeView1.GetNodeAt(pt);

            if (targetNode != null)
            {
                string targetPath = GetFilePath(targetNode);
                Console.WriteLine($"拖动放下节点到: {targetNode.Text}, 路径: {targetPath}");

                // 检查起始路径和目标路径是否有效
                if (!string.IsNullOrEmpty(startDragPath) && Directory.Exists(startDragPath)
                    && !string.IsNullOrEmpty(targetPath) && Directory.Exists(targetPath))
                {
                    // 添加确认框
                    DialogResult result = MessageBox.Show(
                        $"是否将 “{Path.GetFileName(startDragPath)}” 合并到 “{targetNode.Text}”？",
                        "确认合并",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // 获取拖动的节点
                        TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

                        // 检查从 Level 2 拖动到 Level 1
                        if (draggedNode.Level == 2 && targetNode.Level == 1)
                        {
                            // 在目标 Level 1 目录下创建一个新的子目录
                            string newDirPath = Path.Combine(targetPath, draggedNode.Text); // 使用 Level 2 节点的名字作为新目录名
                            if (!Directory.Exists(newDirPath))
                            {
                                Directory.CreateDirectory(newDirPath);
                                Console.WriteLine($"创建新的子目录: {newDirPath}");
                            }

                            // 复制 Level 2 目录下的所有内容到新的子目录
                            try
                            {
                                CopyAllFilesAndDirectories(startDragPath, newDirPath);
                                Console.WriteLine("复制完成");

                                // 如果需要，删除源目录及其内容
                                Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(
                                    startDragPath,
                                    UIOption.OnlyErrorDialogs,
                                    RecycleOption.SendToRecycleBin
                                );
                                Console.WriteLine("源目录已删除");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"操作失败: {ex.Message}");
                            }
                        }
                        // 从 Level 1 拖动到 Level 1
                        else if (draggedNode.Level == 1 && targetNode.Level == 1)
                        {
                            // 如果源目录和目标目录不同，则执行复制
                            if (string.Compare(startDragPath, targetPath, StringComparison.OrdinalIgnoreCase) != 0)
                            {
                                // 复制 Level 1 目录下的所有内容到目标目录
                                try
                                {
                                    CopyAllFilesAndDirectories(startDragPath, targetPath);
                                    Console.WriteLine("复制完成");

                                    // 如果需要，删除源目录及其内容
                                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(
                                        startDragPath,
                                        UIOption.OnlyErrorDialogs,
                                        RecycleOption.SendToRecycleBin
                                    );
                                    Console.WriteLine("源目录已删除");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"操作失败: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("不能将目录拖动到自身，操作被取消。");
                            }
                        }
                        // 从 Level 2 拖动到 Level 2
                        else if (draggedNode.Level == 2 && targetNode.Level == 2)
                        {
                            // 在目标 Level 2 目录下，复制源 Level 2 目录下的所有文件
                            try
                            {
                                // 复制第一个 Level 2 目录下的所有文件到目标 Level 2 目录
                                CopyAllFilesAndDirectories(startDragPath, targetPath);
                                Console.WriteLine("复制完成");

                                // 如果需要，删除源目录及其内容
                                Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(
                                    startDragPath,
                                    UIOption.OnlyErrorDialogs,
                                    RecycleOption.SendToRecycleBin
                                );
                                Console.WriteLine("源目录已删除");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"操作失败: {ex.Message}");
                            }
                        }

                        else
                        {
                            Console.WriteLine("不允许此拖动操作：仅允许从 Level 2 拖动到 Level 1 或者 Level 1 到 Level 1 或 Level 2 到 Level 2");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("起始路径或目标路径无效，无法复制文件");
                }
            }
            else
            {
                Console.WriteLine("拖动放下节点到: 空白区域");
            }

            // 结束拖动操作，清理拖动状态
            ImageList_EndDrag();
            dragImageList?.Dispose();
            dragImageList = null;

            // 清空记录
            startDragPath = null;
        }


        private void CopyAllFilesAndDirectories(string sourceDir, string targetDir)
        {
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            // 复制所有文件
            string[] files = Directory.GetFiles(sourceDir);
            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                string destFile = Path.Combine(targetDir, fileName);

                // 检查目标文件是否已存在
                if (File.Exists(destFile))
                {
                    // 询问用户是否覆盖
                    DialogResult overwriteResult = MessageBox.Show(
                        $"文件 “{fileName}” 已存在，是否覆盖？",
                        "确认覆盖",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (overwriteResult == DialogResult.No)
                    {
                        continue; // 跳过当前文件
                    }
                }

                // 执行复制
                File.Copy(filePath, destFile, overwrite: true);
            }

            // 递归复制子目录
            string[] directories = Directory.GetDirectories(sourceDir);
            foreach (string dirPath in directories)
            {
                string dirName = Path.GetFileName(dirPath);
                string destSubDir = Path.Combine(targetDir, dirName);
                CopyAllFilesAndDirectories(dirPath, destSubDir);
            }
        }


        #region WinAPI 导入

        [DllImport("comctl32.dll")]
        private static extern bool ImageList_BeginDrag(IntPtr himlTrack, int iTrack, int dxHotspot, int dyHotspot);

        [DllImport("comctl32.dll")]
        private static extern void ImageList_EndDrag();

        [DllImport("comctl32.dll")]
        private static extern bool ImageList_DragEnter(IntPtr hwndLock, int x, int y);

        [DllImport("comctl32.dll")]
        private static extern bool ImageList_DragMove(int x, int y);

        [DllImport("comctl32.dll")]
        private static extern bool ImageList_DragLeave(IntPtr hwndLock);
        #endregion



        private FileSystemWatcher _watcher;
        private string _rootPath;
        private string _lastDirectoryHash = string.Empty;
        private System.Timers.Timer _debounceTimer;
        private void InitFileSystemWatcher()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _rootPath = Path.Combine(appDataPath, "瓦斯含量测定数据分析系统", "SystemData", "DataAdministrationForm");

            if (!Directory.Exists(_rootPath))
            {
                Directory.CreateDirectory(_rootPath);
            }

            _watcher = new FileSystemWatcher
            {
                Path = _rootPath,
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite
            };

            // 注册事件
            _watcher.Changed += Watcher_Changed;
            _watcher.Created += Watcher_Changed;
            _watcher.Deleted += Watcher_Changed;
            _watcher.Renamed += Watcher_Renamed;

            _watcher.EnableRaisingEvents = true;

            // 初始化防抖定时器，300ms 内只执行一次
            _debounceTimer = new System.Timers.Timer(500);
            _debounceTimer.AutoReset = false; // 只触发一次
            _debounceTimer.Elapsed += (s, e) => RefreshTreeIfChanged();
        }
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"[FileSystemWatcher] Changed: {e.ChangeType} - {e.FullPath}");
            // 重启防抖定时器
            _debounceTimer.Stop();
            _debounceTimer.Start();
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"[FileSystemWatcher] Renamed: {e.OldFullPath} -> {e.FullPath}");
            _debounceTimer.Stop();
            _debounceTimer.Start();
        }
        private string GetDirectoryStructureHash(string rootPath)
        {
            if (!Directory.Exists(rootPath)) return string.Empty;

            List<string> dirs = new List<string>();

            try
            {
                foreach (var dir in Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories))
                {
                    DirectoryInfo di = new DirectoryInfo(dir);
                    // 拼接路径 + 最后修改时间
                    dirs.Add(dir + di.LastWriteTimeUtc.Ticks);
                }
            }
            catch
            {
                // 忽略异常，比如访问权限问题
            }

            // 排序，保证顺序一致
            dirs.Sort();

            // 拼成一个字符串
            string combined = string.Join("|", dirs);

            // 返回哈希
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(combined);
                byte[] hashBytes = md5.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }
        private void RefreshTreeIfChanged()
        {
            string currentHash = GetDirectoryStructureHash(_rootPath);
            if (currentHash != _lastDirectoryHash)
            {
                _lastDirectoryHash = currentHash;

                _mainForm.Invoke((MethodInvoker)delegate
                {
                    Console.WriteLine("[TreeView] 目录结构变化，更新树视图");
                    LoadFoldersToTree(_rootPath);
                });
            }
            else
            {
                Console.WriteLine("[TreeView] 目录结构哈希未变化，无需更新");
            }
        }



        // 防止展开节点出现残影
        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            _mainForm.treeView1.Invalidate();
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            string text = e.Node.Text;
            string keyword = _mainForm.FindMineTextBox.Text ?? "";
            Font font = _mainForm.treeView1.Font;
            int margin = 0;
            int verticalMargin = 8;

            bool isSelected = (e.Node == _mainForm.treeView1.SelectedNode);
            bool treeViewFocused = _mainForm.treeView1.Focused;

            Color textColor = _mainForm.treeView1.ForeColor;

            if (isSelected)
            {
                Color bgColor = treeViewFocused ? SystemColors.Highlight : Color.LightGray;
                Color fgColor = treeViewFocused ? SystemColors.HighlightText : Color.Black;

                e.Graphics.FillRectangle(new SolidBrush(bgColor), e.Bounds);
                textColor = fgColor;
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(_mainForm.treeView1.BackColor), e.Bounds);
            }

            int matchIndex = -1;
            if (!string.IsNullOrEmpty(keyword))
                matchIndex = text.ToLower().IndexOf(keyword.ToLower());

            float x = e.Bounds.Left + margin;
            float y = e.Bounds.Top + verticalMargin;

            if (string.IsNullOrEmpty(keyword) || matchIndex < 0)
            {
                TextRenderer.DrawText(e.Graphics, text, font, new Point((int)x, (int)y), textColor, TextFormatFlags.NoPadding);
                return;
            }

            string before = text.Substring(0, matchIndex);
            string matchText = text.Substring(matchIndex, keyword.Length);
            string after = text.Substring(matchIndex + keyword.Length);

            Size beforeSize = TextRenderer.MeasureText(e.Graphics, before, font, e.Bounds.Size, TextFormatFlags.NoPadding);
            TextRenderer.DrawText(e.Graphics, before, font, new Point((int)x, (int)y), textColor, TextFormatFlags.NoPadding);
            x += beforeSize.Width;

            Font boldFont = new Font(font, FontStyle.Bold);
            TextRenderer.DrawText(
                e.Graphics,
                matchText,
                boldFont,
                new Point((int)x, (int)y),
                textColor, // 用同样的 textColor，不用再分开判断
                TextFormatFlags.NoPadding
            );
            x += TextRenderer.MeasureText(e.Graphics, matchText, boldFont, e.Bounds.Size, TextFormatFlags.NoPadding).Width;

            TextRenderer.DrawText(e.Graphics, after, font, new Point((int)x, (int)y), textColor, TextFormatFlags.NoPadding);
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 确保点击的是有效的数据单元格（非表头或无效列）
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = _mainForm.dataGridView1.Rows[e.RowIndex];

                // 确保列索引没有超出单元格数量（防御性写法）
                if (e.ColumnIndex < row.Cells.Count)
                {
                    string cellValue = row.Cells[e.ColumnIndex].Value?.ToString();

                    // 可选：显示点击信息
                    // MessageBox.Show($"你点击了第 {e.RowIndex} 行，第 {e.ColumnIndex} 列，值为：{cellValue}");

                    // 触发切换行刷新图片
                    dataGridView1_SelectionChanged(sender, e);
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _mainForm.dataGridView1.Rows.Count > 0)
            {
                // 获取点击位置对应的行索引
                DataGridView.HitTestInfo hit = _mainForm.dataGridView1.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    // 判断该行是否已被选中
                    if (_mainForm.dataGridView1.Rows[hit.RowIndex].Selected)
                    {
                        // 在选中行上右键，弹出菜单
                        _mainForm.tabPage6contextMenuStrip2.Show(_mainForm.dataGridView1, e.Location);
                    }
                    else
                    {
                        // 如果点击的是没选中的行，可以选择先选中它（可选）
                        _mainForm.dataGridView1.ClearSelection();
                        _mainForm.dataGridView1.Rows[hit.RowIndex].Selected = true;

                        // 然后再弹出菜单
                        _mainForm.tabPage6contextMenuStrip2.Show(_mainForm.dataGridView1, e.Location);
                    }
                }
            }
        }

        void SetTextBoxValues(Form form, string baseName, List<string> values, int startIndex = 1)
        {
            for (int i = 0; i < values.Count; i++)
            {
                string name = $"{baseName}{i + startIndex}";
                var ctl = form.Controls.Find(name, true).FirstOrDefault();
                if (ctl is Input tb)
                {
                    tb.Text = values[i];
                }
            }
        }
        /// <summary>
        /// 从字符串中提取数字字符串和布尔值
        /// 输入格式应为: 数字[True] 或 数字[False]
        /// 返回 (数字字符串, bool)；如果格式不匹配，返回 null
        /// </summary>
        static (string numberPart, bool boolPart)? ParseNumberAndBool(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            int bracketIndex = input.IndexOf('[');
            int endBracketIndex = input.IndexOf(']');

            if (bracketIndex < 0 || endBracketIndex <= bracketIndex) return null;

            string numberPart = input.Substring(0, bracketIndex).Trim();
            string boolPartStr = input.Substring(bracketIndex + 1, endBracketIndex - bracketIndex - 1).Trim();

            if (!bool.TryParse(boolPartStr, out bool boolPart)) return null;

            return (numberPart, boolPart);
        }
        // 解析并赋值给文本框和复选框（如果有）
        void ParseAndAssign(string input, Input textBox, System.Windows.Forms.CheckBox checkBox = null)
        {
            var result = ParseNumberAndBool(input);
            if (result != null)
            {
                textBox.Text = result.Value.numberPart;
                if (checkBox != null)
                    checkBox.Checked = result.Value.boolPart;
            }
            else
            {
                // 没有复选框的，或者格式无效时，全部原样赋值到文本框
                textBox.Text = input ?? "";
                if (checkBox != null)
                    checkBox.Checked = false;
            }
        }
//        private void 恢复历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
//            if (selectedNode != null && selectedNode.Tag is string path)
//            {
//                string name = _mainForm.dataGridView1.CurrentRow.Cells["ID"].Value?.ToString();

//                // 获取当前用户的 AppData\Roaming 路径
//                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

//                // 拼接程序专用目录：AppData\Roaming\瓦斯含量测定数据分析系统
//                string programDataDir = Path.Combine(appDataPath, "瓦斯含量测定数据分析系统");

//                // 拼接最终的文件路径
//                string loadPath = Path.Combine(programDataDir, path, name + "_BinData.bin");
//                string imagePath = Path.Combine(programDataDir, path, name + "_Image.png");  // 图片路径

//                // MessageBox.Show("选中节点的路径是：" + loadPath);
//                if (!File.Exists(loadPath))
//                {
//                    MessageBox.Show("找不到已保存的数据！");
//                    return;
//                }


//                try
//                {
//                    using (FileStream fs = new FileStream(loadPath, FileMode.Open))
//                    {
//#pragma warning disable SYSLIB0011
//                        var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
//                        UserData data = (UserData)formatter.Deserialize(fs);
//#pragma warning restore SYSLIB0011

//                        _mainForm.MineNameTextBox.Text = data.矿井名称;
//                        _mainForm.MineNameTextBox.Text = data.矿井名称;
//                        _mainForm.SamplingSpotTextBox.Text = data.取样地点;
//                        _mainForm.X_YTextBox.Text = data.取样地点坐标;
//                        _mainForm.CoalTypeComboBox.Text = data.煤种;
//                        _mainForm.BurialDepthTextBox.Text = data.埋深;
//                        _mainForm.CoalSeamTextBox.Text = data.煤层;
//                        _mainForm.UndAtmPressureTextBox.Text = data.井下大气压力;
//                        _mainForm.LabAtmPressureTextBox.Text = data.实验室大气压力;
//                        _mainForm.UndTempTextBox.Text = data.井下环境温度;
//                        _mainForm.LabTempTextBox.Text = data.实验室温度;
//                        _mainForm.MoistureSampleTextBox.Text = data.煤样水分;
//                        _mainForm.SampleModeComboBox.Text = data.取样方式;
//                        _mainForm.SampleNumTextBox.Text = data.煤样编号;
//                        _mainForm.RawCoalMoistureTextBox.Text = data.原煤水分;
//                        _mainForm.InitialVolumeTextBox.Text = data.量管初始体积;
//                        _mainForm.SampleWeightTextBox.Text = data.煤样重量;
//                        _mainForm.SamplingDepthTextBox.Text = data.取样深度;
//                        _mainForm.SamplingTimeDateTimePicker.Value = DateTime.Parse(data.取样时间);
//                        _mainForm.DrillInclinationTextBox.Text = data.钻孔倾角;
//                        _mainForm.AzimuthTextBox.Text = data.方位角;
//                        _mainForm.SamplingPersonnelTextBox.Text = data.取样人员;

//                        _mainForm.dateTimePicker2.Value = DateTime.Parse(data.打钻开始时间);
//                        _mainForm.dateTimePicker5.Value = DateTime.Parse(data.取芯开始时间);
//                        _mainForm.dateTimePicker3.Value = DateTime.Parse(data.取芯结束时间);
//                        _mainForm.dateTimePicker4.Value = DateTime.Parse(data.解吸开始时间);
//                        _mainForm.TypeOfDestructionComboBox3.Text = data.煤的破坏类型;
//                        _mainForm.t0TextBox.Text = data.t0;

//                        SetTextBoxValues(_mainForm, "DesorbTextBox", data.DesorbTextList);
//                        SetTextBoxValues(_mainForm, "DataNumTextBox", data.DataNumTextList, 31);

//                        _mainForm.DesVolUndTextBox.Text = data.井下解吸量体积;
//                        _mainForm.UndDesorpCalTextBox.Text = data.井下解吸量校准W11;
//                        _mainForm.SampLossVolTextBox.Text = data.瓦斯损失量W12;

//                        _mainForm.DesorpVolNormalTextBox.Text = data.实验室常压解吸;
//                        _mainForm.DesorpVolNormalCalTextBox.Text = data.实验室常压解吸校准W2;
//                        _mainForm.Sample1WeightTextBox.Text = data.粉碎后第1份煤样重;
//                        _mainForm.Sample2WeightTextBox.Text = data.粉碎后第2份煤样重;
//                        _mainForm.S1DesorpVolTextBox.Text = data.第1份煤样解吸量;
//                        _mainForm.S1DesorpVolCalTextBox.Text = data.第1份煤样解吸量校准;
//                        _mainForm.S2DesorpVolTextBox.Text = data.第2份煤样解吸量;
//                        _mainForm.S2DesorpVolCalTextBox.Text = data.第2份煤样解吸量校准;
//                        _mainForm.CrushDesorpTextBox.Text = data.最终粉碎解吸量;


//                        //string input = data.吸附常数a;
//                        //var result = ParseNumberAndBool(input);
//                        //if (result != null)
//                        //{
//                        //    Console.WriteLine($"数字字符串: \"{result.Value.numberPart}\"");
//                        //    Console.WriteLine($"布尔值: {result.Value.boolPart}");

//                        //    _mainForm.AdsorpConstATextBox.Text = result.Value.numberPart;
//                        //    _mainForm.AdsorpConstACheckBox.Checked = result.Value.boolPart;
//                        //}
//                        //else
//                        //{
//                        //    Console.WriteLine("输入格式无效！");
//                        //}

//                        ParseAndAssign(data.吸附常数a, _mainForm.AdsorpConstATextBox, _mainForm.AdsorpConstACheckBox);
//                        ParseAndAssign(data.吸附常数b, _mainForm.AdsorpConstBTextBox, _mainForm.AdsorpConstBCheckBox); // 如果有复选框
//                        ParseAndAssign(data.水分, _mainForm.MadTextBox, _mainForm.MadCheckBox); // 如果有复选框，没有就传null
//                        ParseAndAssign(data.灰分, _mainForm.AadTextBox, _mainForm.AadCheckBox);
//                        ParseAndAssign(data.孔隙率, _mainForm.PorosityTextBox, _mainForm.PorosityCheckBox);
//                        ParseAndAssign(data.视相对密度, _mainForm.AppDensityTextBox, _mainForm.AppDensityCheckBox);
//                        ParseAndAssign(data.真密度, _mainForm.TrueDensityTextBox, _mainForm.TrueDensityCheckBox);
//                        ParseAndAssign(data.挥发分, _mainForm.VadTextBox, _mainForm.VadCheckBox);

//                        //_mainForm.AdsorpConstBTextBox.Text = data.吸附常数b;
//                        //_mainForm.MadTextBox.Text = data.水分;
//                        //_mainForm.AadTextBox.Text = data.灰分;
//                        //_mainForm.PorosityTextBox.Text = data.孔隙率;
//                        //_mainForm.AppDensityTextBox.Text = data.视相对密度;
//                        //_mainForm.TrueDensityTextBox.Text = data.真密度;
//                        //_mainForm.VadTextBox.Text = data.挥发分;
//                        _mainForm.W1_TextBox.Text = data.W1;
//                        _mainForm.W2_TextBox.Text = data.W2;
//                        _mainForm.W3_TextBox.Text = data.W3;
//                        _mainForm.Wa_TextBox.Text = data.Wa;
//                        _mainForm.Wc_TextBox.Text = data.Wc;
//                        var result = ParseNumberAndBool(data.Wc);
//                        if (result != null)
//                        {
//                            _mainForm.Wc_TextBox.Text = result.Value.numberPart;
//                        }
//                        //_mainForm.NonDesorpGasQtyTextBox.Text = data.Wc;// 这两个一样
//                        ParseAndAssign(data.Wc, _mainForm.NonDesorpGasQtyTextBox, _mainForm.NonDesorpGasQtyCheckBox);
//                        _mainForm.W_TextBox.Text = data.W;
//                        //_mainForm.P_TextBox.Text = data.P;
//                        ParseAndAssign(data.P, _mainForm.P_TextBox, _mainForm.P_CheckBox);

//                        //_mainForm.CH4TextBox.Text = data.CH4;
//                        //_mainForm.CO2TextBox.Text = data.CO2;
//                        //_mainForm.N2TextBox.Text = data.N2;
//                        //_mainForm.O2TextBox.Text = data.O2;
//                        //_mainForm.C2H4TextBox.Text = data.C2H4;
//                        //_mainForm.C3H8TextBox.Text = data.C3H8;
//                        //_mainForm.C2H6TextBox.Text = data.C2H6;
//                        //_mainForm.C3H6TextBox.Text = data.C3H6;
//                        //_mainForm.C2H2TextBox.Text = data.C2H2;
//                        //_mainForm.COTextBox.Text = data.CO;
//                        ParseAndAssign(data.CH4, _mainForm.CH4TextBox, _mainForm.CH4CheckBox);
//                        ParseAndAssign(data.CO2, _mainForm.CO2TextBox, _mainForm.CO2CheckBox);
//                        ParseAndAssign(data.N2, _mainForm.N2TextBox, _mainForm.N2CheckBox);
//                        ParseAndAssign(data.O2, _mainForm.O2TextBox, _mainForm.O2CheckBox);
//                        ParseAndAssign(data.C2H4, _mainForm.C2H4TextBox, _mainForm.C2H4CheckBox);
//                        ParseAndAssign(data.C3H8, _mainForm.C3H8TextBox, _mainForm.C3H8CheckBox);
//                        ParseAndAssign(data.C2H6, _mainForm.C2H6TextBox, _mainForm.C2H6CheckBox);
//                        ParseAndAssign(data.C3H6, _mainForm.C3H6TextBox, _mainForm.C3H6CheckBox);
//                        ParseAndAssign(data.C2H2, _mainForm.C2H2TextBox, _mainForm.C2H2CheckBox);
//                        ParseAndAssign(data.CO, _mainForm.COTextBox, _mainForm.COCheckBox);


//                        _mainForm.dateTimePicker6.Value = DateTime.Parse(data.测试时间);
//                        _mainForm.dateTimePicker1.Value = DateTime.Parse(data.出报告时间);
//                        //_mainForm.DownholeTestersTextBox.Text = data.井下测试人员;
//                        ParseAndAssign(data.井下测试人员, _mainForm.DownholeTestersTextBox, _mainForm.DownholeTestersCheckBox);
//                        _mainForm.LabTestersTextBox.Text = data.实验室测试人员;
//                        _mainForm.AuditorTextBox.Text = data.审核人员;
//                        _mainForm.RemarkTextBox.Text = data.备注;



//                        // 获取当前用户的 AppData\Roaming 路径
//                        //string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

//                        // 拼接程序专用目录：AppData\Roaming\瓦斯含量测定数据分析系统\images
//                        var targetFolder = Path.Combine(appDataPath, "瓦斯含量测定数据分析系统", "Image");

//                        // 确保目标文件夹存在
//                        if (!Directory.Exists(targetFolder))
//                        {
//                            Directory.CreateDirectory(targetFolder);
//                        }

//                        if (File.Exists(imagePath))
//                        {
//                            // 将图片复制到 AppData 下的目标文件夹
//                            var targetPath = Path.Combine(targetFolder, "output_image.png");
//                            try
//                            {
//                                File.Copy(imagePath, targetPath, overwrite: true); // 如果已存在就覆盖
//                            }
//                            catch (Exception ex)
//                            {
//                                MessageBox.Show("复制图片文件时出错: " + ex.Message);
//                            }

//                            using (var imgStream = new MemoryStream(File.ReadAllBytes(imagePath)))
//                            {
//                                using (var imgTemp = Image.FromStream(imgStream))
//                                {
//                                    // 复制一份 Bitmap，断开对流的依赖
//                                    _mainForm.pictureBox3.Image = new Bitmap(imgTemp);
//                                }
//                            }
//                            _mainForm.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
//                        }
//                        else
//                        {
//                            MessageBox.Show("找不到图片文件：" + imagePath);
//                        }



//                        // 调用计算函数，防止tab4数据输出为0
//                        //_mainForm.tab6_4_ExpCalcButton_Click(sender,e);

//                        MessageBox.Show("已恢复历史记录！");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("加载失败:W " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    Console.WriteLine("[EXCEPTION] 加载失败：" + ex.ToString());  // 打印完整堆栈信息
//                }
//            }
//            else
//            {
//                MessageBox.Show("未选中有效节点或节点没有路径信息！");
//            }
//        }
        private void 恢复历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
            if (selectedNode != null && selectedNode.Tag is string path)
            {
                string name = _mainForm.dataGridView1.CurrentRow?.Cells["ID"].Value?.ToString();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("请选择有效的用户！");
                    return;
                }

                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string programDataDir = Path.Combine(appDataPath, "瓦斯含量测定数据分析系统");

                string dataFileName = $"{name}_Data.WSHL";
                string dataFilePath = Path.Combine(programDataDir, path, dataFileName);

                if (!File.Exists(dataFilePath))
                {
                    MessageBox.Show("找不到已保存的数据文件：" + dataFilePath);
                    return;
                }

                try
                {
                    UserData data;
                    using (FileStream fs = new FileStream(dataFilePath, FileMode.Open, FileAccess.Read))
                    {
#pragma warning disable SYSLIB0011
                        var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        data = (UserData)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011
                    }

                    if (data == null)
                    {
                        MessageBox.Show("数据文件内容为空！");
                        return;
                    }

                    // 赋值控件，保持你原来代码不变，这里示例
                    _mainForm.MineNameTextBox.Text = data.矿井名称;
                    _mainForm.MineNameTextBox.Text = data.矿井名称;
                    _mainForm.SamplingSpotTextBox.Text = data.取样地点;
                    _mainForm.X_YTextBox.Text = data.取样地点坐标;
                    _mainForm.CoalTypeComboBox.Text = data.煤种;
                    _mainForm.BurialDepthTextBox.Text = data.埋深;
                    _mainForm.CoalSeamTextBox.Text = data.煤层;
                    _mainForm.UndAtmPressureTextBox.Text = data.井下大气压力;
                    _mainForm.LabAtmPressureTextBox.Text = data.实验室大气压力;
                    _mainForm.UndTempTextBox.Text = data.井下环境温度;
                    _mainForm.LabTempTextBox.Text = data.实验室温度;
                    _mainForm.MoistureSampleTextBox.Text = data.煤样水分;
                    _mainForm.SampleModeComboBox.Text = data.取样方式;
                    _mainForm.SampleNumTextBox.Text = data.煤样编号;
                    _mainForm.RawCoalMoistureTextBox.Text = data.原煤水分;
                    _mainForm.InitialVolumeTextBox.Text = data.量管初始体积;
                    _mainForm.SampleWeightTextBox.Text = data.煤样重量;
                    _mainForm.SamplingDepthTextBox.Text = data.取样深度;
                    _mainForm.SamplingTimeDateTimePicker.Value = DateTime.Parse(data.取样时间);
                    _mainForm.DrillInclinationTextBox.Text = data.钻孔倾角;
                    _mainForm.AzimuthTextBox.Text = data.方位角;
                    _mainForm.SamplingPersonnelTextBox.Text = data.取样人员;

                    _mainForm.dateTimePicker2.Value = DateTime.Parse(data.打钻开始时间);
                    _mainForm.dateTimePicker5.Value = DateTime.Parse(data.取芯开始时间);
                    _mainForm.dateTimePicker3.Value = DateTime.Parse(data.取芯结束时间);
                    _mainForm.dateTimePicker4.Value = DateTime.Parse(data.解吸开始时间);
                    _mainForm.TypeOfDestructionComboBox3.Text = data.煤的破坏类型;
                    _mainForm.t0TextBox.Text = data.t0;

                    SetTextBoxValues(_mainForm, "DesorbTextBox", data.DesorbTextList);
                    SetTextBoxValues(_mainForm, "DataNumTextBox", data.DataNumTextList, 31);

                    _mainForm.DesVolUndTextBox.Text = data.井下解吸量体积;
                    _mainForm.UndDesorpCalTextBox.Text = data.井下解吸量校准W11;
                    _mainForm.SampLossVolTextBox.Text = data.瓦斯损失量W12;

                    _mainForm.DesorpVolNormalTextBox.Text = data.实验室常压解吸;
                    _mainForm.DesorpVolNormalCalTextBox.Text = data.实验室常压解吸校准W2;
                    _mainForm.Sample1WeightTextBox.Text = data.粉碎后第1份煤样重;
                    _mainForm.Sample2WeightTextBox.Text = data.粉碎后第2份煤样重;
                    _mainForm.S1DesorpVolTextBox.Text = data.第1份煤样解吸量;
                    _mainForm.S1DesorpVolCalTextBox.Text = data.第1份煤样解吸量校准;
                    _mainForm.S2DesorpVolTextBox.Text = data.第2份煤样解吸量;
                    _mainForm.S2DesorpVolCalTextBox.Text = data.第2份煤样解吸量校准;
                    _mainForm.CrushDesorpTextBox.Text = data.最终粉碎解吸量;


                    //string input = data.吸附常数a;
                    //var result = ParseNumberAndBool(input);
                    //if (result != null)
                    //{
                    //    Console.WriteLine($"数字字符串: \"{result.Value.numberPart}\"");
                    //    Console.WriteLine($"布尔值: {result.Value.boolPart}");

                    //    _mainForm.AdsorpConstATextBox.Text = result.Value.numberPart;
                    //    _mainForm.AdsorpConstACheckBox.Checked = result.Value.boolPart;
                    //}
                    //else
                    //{
                    //    Console.WriteLine("输入格式无效！");
                    //}

                    ParseAndAssign(data.吸附常数a, _mainForm.AdsorpConstATextBox, _mainForm.AdsorpConstACheckBox);
                    ParseAndAssign(data.吸附常数b, _mainForm.AdsorpConstBTextBox, _mainForm.AdsorpConstBCheckBox); // 如果有复选框
                    ParseAndAssign(data.水分, _mainForm.MadTextBox, _mainForm.MadCheckBox); // 如果有复选框，没有就传null
                    ParseAndAssign(data.灰分, _mainForm.AadTextBox, _mainForm.AadCheckBox);
                    ParseAndAssign(data.孔隙率, _mainForm.PorosityTextBox, _mainForm.PorosityCheckBox);
                    ParseAndAssign(data.视相对密度, _mainForm.AppDensityTextBox, _mainForm.AppDensityCheckBox);
                    ParseAndAssign(data.真密度, _mainForm.TrueDensityTextBox, _mainForm.TrueDensityCheckBox);
                    ParseAndAssign(data.挥发分, _mainForm.VadTextBox, _mainForm.VadCheckBox);

                    //_mainForm.AdsorpConstBTextBox.Text = data.吸附常数b;
                    //_mainForm.MadTextBox.Text = data.水分;
                    //_mainForm.AadTextBox.Text = data.灰分;
                    //_mainForm.PorosityTextBox.Text = data.孔隙率;
                    //_mainForm.AppDensityTextBox.Text = data.视相对密度;
                    //_mainForm.TrueDensityTextBox.Text = data.真密度;
                    //_mainForm.VadTextBox.Text = data.挥发分;
                    _mainForm.W1_TextBox.Text = data.W1;
                    _mainForm.W2_TextBox.Text = data.W2;
                    _mainForm.W3_TextBox.Text = data.W3;
                    _mainForm.Wa_TextBox.Text = data.Wa;
                    _mainForm.Wc_TextBox.Text = data.Wc;
                    var result = ParseNumberAndBool(data.Wc);
                    if (result != null)
                    {
                        _mainForm.Wc_TextBox.Text = result.Value.numberPart;
                    }
                    //_mainForm.NonDesorpGasQtyTextBox.Text = data.Wc;// 这两个一样
                    ParseAndAssign(data.Wc, _mainForm.NonDesorpGasQtyTextBox, _mainForm.NonDesorpGasQtyCheckBox);
                    _mainForm.W_TextBox.Text = data.W;
                    //_mainForm.P_TextBox.Text = data.P;
                    ParseAndAssign(data.P, _mainForm.P_TextBox, _mainForm.P_CheckBox);

                    //_mainForm.CH4TextBox.Text = data.CH4;
                    //_mainForm.CO2TextBox.Text = data.CO2;
                    //_mainForm.N2TextBox.Text = data.N2;
                    //_mainForm.O2TextBox.Text = data.O2;
                    //_mainForm.C2H4TextBox.Text = data.C2H4;
                    //_mainForm.C3H8TextBox.Text = data.C3H8;
                    //_mainForm.C2H6TextBox.Text = data.C2H6;
                    //_mainForm.C3H6TextBox.Text = data.C3H6;
                    //_mainForm.C2H2TextBox.Text = data.C2H2;
                    //_mainForm.COTextBox.Text = data.CO;
                    ParseAndAssign(data.CH4, _mainForm.CH4TextBox, _mainForm.CH4CheckBox);
                    ParseAndAssign(data.CO2, _mainForm.CO2TextBox, _mainForm.CO2CheckBox);
                    ParseAndAssign(data.N2, _mainForm.N2TextBox, _mainForm.N2CheckBox);
                    ParseAndAssign(data.O2, _mainForm.O2TextBox, _mainForm.O2CheckBox);
                    ParseAndAssign(data.C2H4, _mainForm.C2H4TextBox, _mainForm.C2H4CheckBox);
                    ParseAndAssign(data.C3H8, _mainForm.C3H8TextBox, _mainForm.C3H8CheckBox);
                    ParseAndAssign(data.C2H6, _mainForm.C2H6TextBox, _mainForm.C2H6CheckBox);
                    ParseAndAssign(data.C3H6, _mainForm.C3H6TextBox, _mainForm.C3H6CheckBox);
                    ParseAndAssign(data.C2H2, _mainForm.C2H2TextBox, _mainForm.C2H2CheckBox);
                    ParseAndAssign(data.CO, _mainForm.COTextBox, _mainForm.COCheckBox);


                    _mainForm.dateTimePicker6.Value = DateTime.Parse(data.测试时间);
                    //_mainForm.dateTimePicker1.Value = DateTime.Parse(data.出报告时间);
                    if (DateTime.TryParse(data.出报告时间, out DateTime reportDate))
                    {
                        _mainForm.dateTimePicker1.Value = reportDate;
                    }
                    else
                    {
                        // 格式不对或者空白，给一个默认值，比如当前时间，或者不改
                        _mainForm.dateTimePicker1.Value = DateTime.Now;
                    }

                    //_mainForm.DownholeTestersTextBox.Text = data.井下测试人员;
                    ParseAndAssign(data.井下测试人员, _mainForm.DownholeTestersTextBox, _mainForm.DownholeTestersCheckBox);
                    _mainForm.LabTestersTextBox.Text = data.实验室测试人员;
                    _mainForm.AuditorTextBox.Text = data.审核人员;
                    _mainForm.RemarkTextBox.Text = data.备注;

                    // 从内存加载图片
                    if (data.ImageData != null && data.ImageData.Length > 0)
                    {
                        using (var ms = new MemoryStream(data.ImageData))
                        {
                            _mainForm.pictureBox3.Image?.Dispose();
                            _mainForm.pictureBox3.Image = Image.FromStream(ms);
                        }
                        _mainForm.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                        // 保存图片到 AppData 下的“Image”文件夹
                        string imageFolder = Path.Combine(programDataDir, "Image");
                        if (!Directory.Exists(imageFolder))
                        {
                            Directory.CreateDirectory(imageFolder);
                        }

                        string imageFilePath = Path.Combine(imageFolder, "output_image.png");
                        try
                        {
                            File.WriteAllBytes(imageFilePath, data.ImageData);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("保存图片文件时出错: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("数据文件中没有图片数据！");
                    }

                    MessageBox.Show("已恢复历史记录！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("[EXCEPTION] 加载失败：" + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("未选中有效节点或节点没有路径信息！");
            }
        }

        // 矿井搜索
        private void FindMineTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  // 判断是否按下了回车键（Enter）
            {
                // e.Handled = true;  // （可选）告诉系统事件已经处理，阻止系统发出“叮”声
                e.SuppressKeyPress = true; // 阻止回车键被进一步处理，避免输入框响铃或换行

                // 获取当前用户的 AppData\Roaming 路径
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                // 构建目标文件夹路径：AppData\Roaming\瓦斯含量测定数据分析系统\SystemData\DataAdministrationForm
                string rootPath = Path.Combine(appDataPath, "瓦斯含量测定数据分析系统", "SystemData", "DataAdministrationForm");

                // 如果路径不存在则创建
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                // 加载该路径下的文件夹结构到树控件
                LoadFoldersToTree(rootPath);
                if (_mainForm.treeView1.Nodes.Count > 0)
                {
                    _mainForm.treeView1.TopNode = _mainForm.treeView1.Nodes[0];
                }
            }
        }

        // 信息搜索
        private void FindTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //e.Handled = true; // 阻止系统发出“叮”声（可选）
                e.SuppressKeyPress = true;

                TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
                if (selectedNode != null)
                {
                    TreeViewEventArgs args = new TreeViewEventArgs(selectedNode);
                    treeView1_AfterSelect(_mainForm.treeView1, args); // sender 改为 treeView1 更合理
                }
            }
        }
        /// <summary>
        /// 当树控件节点被选中时触发，加载该节点对应目录的文件到 DataGridView
        /// </summary>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            string selectedPath = selectedNode.Tag?.ToString();

            // 只对“叶子节点”处理（即没有子节点的节点）
            // 并且该节点对应的路径是有效目录
            if (selectedNode.Nodes.Count == 0 && Directory.Exists(selectedPath))
            {
                // 加载该目录下的文件到表格显示
                string str = _mainForm.FindTextBox.Text;
                if (string.IsNullOrEmpty(str))
                {
                    全部显示(selectedPath);
                }
                else
                {
                    查询显示(selectedPath, _mainForm.FindTextBox.Text);
                }
            }
            else
            {
                // 非叶子节点或目录不存在，清空表格数据
                _mainForm.dataGridView1.DataSource = null;
            }
            // 触发列表选中
            dataGridView1_SelectionChanged(_mainForm.dataGridView1, EventArgs.Empty);
        }

        /// <summary>
        /// 将指定根目录及其子目录加载到 TreeView 控件中显示
        /// </summary>
        /// <param name="rootPath">根目录路径</param>
        private void LoadFoldersToTree(string rootPath)
        {
            DirectoryInfo rootDir = new DirectoryInfo(rootPath);
            if (!rootDir.Exists) return;

            // === 1. 更新前：保存当前选中节点路径 ===
            string prevSelectedPath = null;
            if (_mainForm.treeView1.SelectedNode != null && _mainForm.treeView1.SelectedNode.Tag is string tag)
            {
                prevSelectedPath = tag;
            }

            // === 2. 清空并重新加载节点 ===
            _mainForm.treeView1.Nodes.Clear();

            TreeNode rootNode = new TreeNode(rootDir.Name) { Tag = rootDir.FullName };
            rootNode.ImageKey = "根目录";
            rootNode.SelectedImageKey = "根目录";

            _mainForm.treeView1.Nodes.Add(rootNode);

            AddSubDirectories(rootDir, rootNode, 1);

            // === 3. 展开并尝试选中之前选中的节点 ===
            string savedNodeText = GasFormsApp.Settings.Default.Tab6SearchForMinesText;

            foreach (TreeNode node in _mainForm.treeView1.Nodes)
            {
                node.Expand();

                TreeNode targetChild = null;
                foreach (TreeNode child in node.Nodes)
                {
                    if (child.Text == savedNodeText)
                    {
                        child.Expand();
                        targetChild = child;
                        break;
                    }
                }

                if (targetChild != null)
                {
                    node.Nodes.Remove(targetChild);
                    node.Nodes.Insert(0, targetChild);
                }
            }

            // === 4. 如果记住了之前选中的路径，就在新树中找到并选中 ===
            if (!string.IsNullOrEmpty(prevSelectedPath))
            {
                TreeNode found = FindNodeByTag(_mainForm.treeView1.Nodes, prevSelectedPath);
                if (found != null)
                {
                    _mainForm.treeView1.SelectedNode = found;
                    found.EnsureVisible(); // 滚动到可见
                }
            }

            if (_mainForm.treeView1.Nodes.Count > 0)
            {
                _mainForm.treeView1.TopNode = _mainForm.treeView1.Nodes[0];
            }
        }
        /// <summary>
        /// 根据节点 Tag（目录路径）递归查找 TreeNode
        /// </summary>
        private TreeNode FindNodeByTag(TreeNodeCollection nodes, string targetTag)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag as string == targetTag)
                    return node;

                TreeNode foundInChild = FindNodeByTag(node.Nodes, targetTag);
                if (foundInChild != null)
                    return foundInChild;
            }
            return null;
        }

        /// <summary>
        /// 递归添加指定目录的所有子目录到指定父节点下
        /// </summary>
        /// <param name="dir">当前目录</param>
        /// <param name="parentNode">父节点</param>
        private void AddSubDirectories(DirectoryInfo dir, TreeNode parentNode, int level)
        {
            foreach (var subDir in dir.GetDirectories())
            {
                if (level == 1 && !subDir.Name.ToLower().Contains(_mainForm.FindMineTextBox.Text.ToLower()))
                    continue;

                TreeNode childNode = new TreeNode(subDir.Name)
                {
                    Tag = subDir.FullName
                };

                // 根据层级设置不同图标（示例）
                if (level == 1)
                {
                    childNode.ImageKey = "矿井";
                    childNode.SelectedImageKey = "矿井";
                }
                else if (level == 2)
                {
                    childNode.ImageKey = "项目";
                    childNode.SelectedImageKey = "项目";
                }
                else
                {
                    childNode.ImageKey = "根目录";
                    childNode.SelectedImageKey = "根目录";
                }

                parentNode.Nodes.Add(childNode);

                // 递归调用，层级 +1
                AddSubDirectories(subDir, childNode, level + 1);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (_mainForm.dataGridView1.CurrentRow != null)
            {
                string name = _mainForm.dataGridView1.CurrentRow.Cells["ID"].Value?.ToString();
                Console.WriteLine("当前选中名称：" + name);

                TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
                if (selectedNode == null)
                {
                    MessageBox.Show("请先选择一个节点！");
                    return;
                }
                string selectedPath = selectedNode.Tag?.ToString();
                if (string.IsNullOrEmpty(selectedPath) || !Directory.Exists(selectedPath))
                {
                    MessageBox.Show("节点路径无效！");
                    return;
                }

                // 新的文件路径，改成 xxx_Data.WSHL
                string dataFileName = $"{name}_Data.WSHL";
                string dataFilePath = Path.Combine(selectedPath, dataFileName);

                if (!File.Exists(dataFilePath))
                {
                    // 临时解决方案
                    //MessageBox.Show("找不到数据文件：" + dataFilePath);
                    return;
                }

                // 设置 PictureBox 显示模式
                _mainForm.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                try
                {
                    UserData userData = null;
                    using (FileStream fs = new FileStream(dataFilePath, FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        userData = (UserData)formatter.Deserialize(fs);
                    }

                    if (userData?.ImageData != null && userData.ImageData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(userData.ImageData))
                        {
                            if (_mainForm.pictureBox2.Image != null)
                            {
                                _mainForm.pictureBox2.Image.Dispose();
                                _mainForm.pictureBox2.Image = null;
                            }
                            _mainForm.pictureBox2.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("数据文件中没有图片数据！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图片时出错：" + ex.Message);
                }
            }
        }



        // 解决一些问题
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("双击：" + e.RowIndex + e.ColumnIndex);
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _mainForm.dataGridView1.CurrentCell = _mainForm.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                _mainForm.dataGridView1.BeginEdit(true); // 手动进入编辑
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (_mainForm.dataGridView1.CurrentCell != null)
                {
                    Clipboard.SetText(_mainForm.dataGridView1.CurrentCell.Value?.ToString() ?? "");
                    e.Handled = true;
                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;

            // 获取行号（从 1 开始）
            string rowNumber = (e.RowIndex + 1).ToString();

            // 设置字体（可省略）
            //Font font = dgv.RowHeadersDefaultCellStyle.Font ?? dgv.DefaultCellStyle.Font;
            Font font = new Font("宋体", 12, FontStyle.Bold);

            // 计算绘制区域
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);

            // 居中绘制行号
            TextRenderer.DrawText(e.Graphics, rowNumber, font, headerBounds, Color.Black,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }


        // 标记该类可被序列化为二进制格式
        [Serializable]
        public class UserData
        {
            public string ID { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 矿井名称 { get; set; }
            public string 取样地点 { get; set; }
            public string 取样地点坐标 { get; set; }
            public string 煤种 { get; set; }
            public string 埋深 { get; set; }
            public string 煤层 { get; set; }
            public string 井下大气压力 { get; set; }
            public string 实验室大气压力 { get; set; }
            public string 井下环境温度 { get; set; }
            public string 实验室温度 { get; set; }
            public string 煤样水分 { get; set; }
            public string 取样方式 { get; set; }
            public string 煤样编号 { get; set; }
            public string 原煤水分 { get; set; }
            public string 量管初始体积 { get; set; }
            public string 煤样重量 { get; set; }
            public string 取样深度 { get; set; }
            public string 取样时间 { get; set; }
            // 新加++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            public string 钻孔倾角 { get; set; }
            public string 方位角 { get; set; }
            public string 取样人员 { get; set; }

            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 打钻开始时间 { get; set; }
            public string 取芯开始时间 { get; set; }
            public string 取芯结束时间 { get; set; }
            public string 解吸开始时间 { get; set; }
            public string 煤的破坏类型 { get; set; }
            public string t0 { get; set; }
            public List<string> DesorbTextList { get; set; } = new List<string>();
            public List<string> DataNumTextList { get; set; } = new List<string>();
            public string 井下解吸量体积 { get; set; }
            public string 井下解吸量校准W11 { get; set; }
            public string 瓦斯损失量W12 { get; set; }

            public string 解吸量
            {
                get => string.Join(", ", DesorbTextList);
                set => DesorbTextList = value?
            .Split(new[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim()).ToList() ?? new List<string>();
            }
            public string 解吸时间
            {
                get => string.Join(", ", DataNumTextList);
                set => DataNumTextList = value?
                    .Split(new[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).ToList() ?? new List<string>();
            }

            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 实验室常压解吸 { get; set; }
            public string 实验室常压解吸校准W2 { get; set; }
            public string 粉碎后第1份煤样重 { get; set; }
            public string 第1份煤样解吸量 { get; set; }
            public string 第1份煤样解吸量校准 { get; set; }
            public string 粉碎后第2份煤样重 { get; set; }
            public string 第2份煤样解吸量 { get; set; }
            public string 第2份煤样解吸量校准 { get; set; }
            public string 最终粉碎解吸量 { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string 吸附常数a { get; set; }
            public string 吸附常数b { get; set; }
            public string 水分 { get; set; }
            public string 灰分 { get; set; }
            public string 孔隙率 { get; set; }
            public string 视相对密度 { get; set; }
            public string 真密度 { get; set; }
            public string 挥发分 { get; set; }
            //public string Wc { get; set; }    // 和下面的重复
            public string W1 { get; set; }
            public string W2 { get; set; }
            public string W3 { get; set; }
            public string Wa { get; set; }
            public string Wc { get; set; }
            public string W { get; set; }
            public string P { get; set; }
            /// <summary>
            /// ///////////////////////////////
            /// </summary>
            public string CH4 { get; set; }
            public string CO2 { get; set; }
            public string N2 { get; set; }
            public string O2 { get; set; }
            public string C2H4 { get; set; }
            public string C3H8 { get; set; }
            public string C2H6 { get; set; }
            public string C3H6 { get; set; }
            public string C2H2 { get; set; }
            public string CO { get; set; }

            public string 测试时间 { get; set; }
            public string 出报告时间 { get; set; }
            public string 井下测试人员 { get; set; }
            public string 实验室测试人员 { get; set; }
            public string 审核人员 { get; set; }
            public string 备注 { get; set; }

            public byte[] ImageData;   // 用于保存图片
        }

        //// 当前程序目录
        //static string CurrentDir = AppDomain.CurrentDomain.BaseDirectory;

        //// 用于存放系统数据的文件夹路径
        //string SystemDataPath = Path.Combine(CurrentDir, "SystemData");

        public List<string> GetTextBoxValues(Control parent, string baseName, int end, int start = 1)
        {
            var list = new List<string>();
            for (int i = start; i <= end; i++)
            {
                var ctl = parent.Controls.Find($"{baseName}{i}", true).FirstOrDefault();
                list.Add(ctl is Input tb ? tb.Text : "");
            }
            return list;
        }
        /// <summary>
        /// 按钮1点击事件：复制图片并保存用户数据为二进制文件
        /// </summary>
        public bool SaveButton_Click(object sender, EventArgs e)
        {
            ProjectGroupsForm newForm = new ProjectGroupsForm();
            newForm.ResultData = null;
            DialogResult result = newForm.ShowDialog();

            if (result != DialogResult.OK)
            {
                // 用户取消了操作
                return false;
            }

            string selectedPath = newForm.ResultData;
            if (string.IsNullOrEmpty(selectedPath))
            {
                MessageBox.Show("请选择有效的保存路径！");
                return false;
            }

            // 如果目录不存在，创建之
            if (!Directory.Exists(selectedPath))
            {
                try
                {
                    Directory.CreateDirectory(selectedPath);
                    Console.WriteLine($"目录不存在，已创建：{selectedPath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("创建目录失败：" + ex.Message);
                    return false;
                }
            }

            // 获取保存时用的ID，作为文件名关键部分
            string IdName = _mainForm.SampleNumTextBox.Text?.Trim();
            if (string.IsNullOrEmpty(IdName))
            {
                MessageBox.Show("请输入有效的煤样编号！");
                return false;
            }
            // 构造完整文件路径
            string fileName = $"{IdName}_Data.WSHL";
            string fullFilePath = Path.Combine(selectedPath, fileName);

            // 检查文件是否存在
            if (File.Exists(fullFilePath))
            {
                DialogResult overwriteResult = MessageBox.Show(
                    $"文件已存在：{fileName}\n是否覆盖？",
                    "文件已存在",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (overwriteResult == DialogResult.No)
                {
                    // 用户选择不覆盖
                    return false;
                }
                // 如果用户选择 Yes，则继续保存，会覆盖文件
            }


            // === 读取图片数据 ===
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string imageFolderPath = Path.Combine(appDataPath, "瓦斯含量测定数据分析系统", "Image");
            string imageSourcePath = Path.Combine(imageFolderPath, "output_image.png");

            if (!File.Exists(imageSourcePath))
            {
                MessageBox.Show("未找到要保存的图片文件：" + imageSourcePath);
                return false;
            }

            byte[] imageData;
            try
            {
                imageData = File.ReadAllBytes(imageSourcePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取图片文件失败：" + ex.Message);
                return false;
            }

            // === 创建并填充 UserData 对象 ===
            try
            {
                var user = new UserData
                {
                    ID = IdName,

                    // tab1
                    矿井名称 = _mainForm.MineNameTextBox.Text,
                    取样地点 = _mainForm.SamplingSpotTextBox.Text,
                    取样地点坐标 = _mainForm.X_YTextBox.Text,
                    煤种 = _mainForm.CoalTypeComboBox.Text,
                    埋深 = _mainForm.BurialDepthTextBox.Text,
                    煤层 = _mainForm.CoalSeamTextBox.Text,
                    井下大气压力 = _mainForm.UndAtmPressureTextBox.Text,
                    实验室大气压力 = _mainForm.LabAtmPressureTextBox.Text,
                    井下环境温度 = _mainForm.UndTempTextBox.Text,
                    实验室温度 = _mainForm.LabTempTextBox.Text,
                    煤样水分 = _mainForm.MoistureSampleTextBox.Text,
                    取样方式 = _mainForm.SampleModeComboBox.Text,
                    煤样编号 = _mainForm.SampleNumTextBox.Text,
                    原煤水分 = _mainForm.RawCoalMoistureTextBox.Text,
                    量管初始体积 = _mainForm.InitialVolumeTextBox.Text,
                    煤样重量 = _mainForm.SampleWeightTextBox.Text,
                    取样深度 = _mainForm.SamplingDepthTextBox.Text,
                    取样时间 = _mainForm.SamplingTimeDateTimePicker.Text,
                    钻孔倾角 = _mainForm.DrillInclinationTextBox.Text,
                    方位角 = _mainForm.AzimuthTextBox.Text,
                    取样人员 = _mainForm.SamplingPersonnelTextBox.Text,

                    // tab2
                    打钻开始时间 = _mainForm.dateTimePicker2.Text,
                    取芯开始时间 = _mainForm.dateTimePicker5.Text,
                    取芯结束时间 = _mainForm.dateTimePicker3.Text,
                    解吸开始时间 = _mainForm.dateTimePicker4.Text,
                    煤的破坏类型 = _mainForm.TypeOfDestructionComboBox3.Text,
                    t0 = _mainForm.t0TextBox.Text,
                    DesorbTextList = GetTextBoxValues(_mainForm, "DesorbTextBox", 60),
                    DataNumTextList = GetTextBoxValues(_mainForm, "DataNumTextBox", 60, 31),
                    井下解吸量体积 = _mainForm.DesVolUndTextBox.Text,
                    井下解吸量校准W11 = _mainForm.UndDesorpCalTextBox.Text,
                    瓦斯损失量W12 = _mainForm.SampLossVolTextBox.Text,

                    // tab3
                    实验室常压解吸 = _mainForm.DesorpVolNormalTextBox.Text,
                    实验室常压解吸校准W2 = _mainForm.DesorpVolNormalCalTextBox.Text,
                    粉碎后第1份煤样重 = _mainForm.Sample1WeightTextBox.Text,
                    第1份煤样解吸量 = _mainForm.S1DesorpVolTextBox.Text,
                    第1份煤样解吸量校准 = _mainForm.S1DesorpVolCalTextBox.Text,
                    粉碎后第2份煤样重 = _mainForm.Sample2WeightTextBox.Text,
                    第2份煤样解吸量 = _mainForm.S2DesorpVolTextBox.Text,
                    第2份煤样解吸量校准 = _mainForm.S2DesorpVolCalTextBox.Text,
                    最终粉碎解吸量 = _mainForm.CrushDesorpTextBox.Text,

                    // tab4
                    吸附常数a = _mainForm.AdsorpConstATextBox.Text + $"[{_mainForm.AdsorpConstACheckBox.Checked}]",
                    吸附常数b = _mainForm.AdsorpConstBTextBox.Text + $"[{_mainForm.AdsorpConstBCheckBox.Checked}]",
                    水分 = _mainForm.MadTextBox.Text + $"[{_mainForm.MadCheckBox.Checked}]",
                    灰分 = _mainForm.AadTextBox.Text + $"[{_mainForm.AadCheckBox.Checked}]",
                    孔隙率 = _mainForm.PorosityTextBox.Text + $"[{_mainForm.PorosityCheckBox.Checked}]",
                    视相对密度 = _mainForm.AppDensityTextBox.Text + $"[{_mainForm.AppDensityCheckBox.Checked}]",
                    真密度 = _mainForm.TrueDensityTextBox.Text + $"[{_mainForm.TrueDensityCheckBox.Checked}]",
                    挥发分 = _mainForm.VadTextBox.Text + $"[{_mainForm.VadCheckBox.Checked}]",
                    W1 = _mainForm.W1_TextBox.Text,
                    W2 = _mainForm.W2_TextBox.Text,
                    W3 = _mainForm.W3_TextBox.Text,
                    Wa = _mainForm.Wa_TextBox.Text,
                    Wc = _mainForm.Wc_TextBox.Text + $"[{_mainForm.NonDesorpGasQtyCheckBox.Checked}]",
                    W = _mainForm.W_TextBox.Text,
                    P = _mainForm.P_TextBox.Text + $"[{_mainForm.P_CheckBox.Checked}]",

                    // tab5
                    CH4 = _mainForm.CH4TextBox.Text + $"[{_mainForm.CH4CheckBox.Checked}]",
                    CO2 = _mainForm.CO2TextBox.Text + $"[{_mainForm.CO2CheckBox.Checked}]",
                    N2 = _mainForm.N2TextBox.Text + $"[{_mainForm.N2CheckBox.Checked}]",
                    O2 = _mainForm.O2TextBox.Text + $"[{_mainForm.O2CheckBox.Checked}]",
                    C2H4 = _mainForm.C2H4TextBox.Text + $"[{_mainForm.C2H4CheckBox.Checked}]",
                    C3H8 = _mainForm.C3H8TextBox.Text + $"[{_mainForm.C3H8CheckBox.Checked}]",
                    C2H6 = _mainForm.C2H6TextBox.Text + $"[{_mainForm.C2H6CheckBox.Checked}]",
                    C3H6 = _mainForm.C3H6TextBox.Text + $"[{_mainForm.C3H6CheckBox.Checked}]",
                    C2H2 = _mainForm.C2H2TextBox.Text + $"[{_mainForm.C2H2CheckBox.Checked}]",
                    CO = _mainForm.COTextBox.Text + $"[{_mainForm.COCheckBox.Checked}]",
                    测试时间 = _mainForm.dateTimePicker6.Text,
                    出报告时间 = _mainForm.dateTimePicker1.Text,
                    井下测试人员 = _mainForm.DownholeTestersTextBox.Text + $"[{_mainForm.DownholeTestersCheckBox.Checked}]",
                    实验室测试人员 = _mainForm.LabTestersTextBox.Text,
                    审核人员 = _mainForm.AuditorTextBox.Text,
                    备注 = _mainForm.RemarkTextBox.Text,

                    // 保存图片字节
                    ImageData = imageData
                };
                //string timeInfo =
                //    $"取样时间: {user.取样时间}\n" +
                //    $"打钻开始时间: {user.打钻开始时间}\n" +
                //    $"取芯开始时间: {user.取芯开始时间}\n" +
                //    $"取芯结束时间: {user.取芯结束时间}\n" +
                //    $"解吸开始时间: {user.解吸开始时间}\n" +
                //    $"测试时间: {user.测试时间}\n" +
                //    $"出报告时间: {user.出报告时间}";
                //MessageBox.Show(timeInfo);
                int CheckTimeFields(UserData u)
                {
                    var times = new Dictionary<string, string>
                    {
                        { "取样时间", u.取样时间 },
                        { "打钻开始时间", u.打钻开始时间 },
                        { "取芯开始时间", u.取芯开始时间 },
                        { "取芯结束时间", u.取芯结束时间 },
                        { "解吸开始时间", u.解吸开始时间 },
                        { "测试时间", u.测试时间 },
                        { "出报告时间", u.出报告时间 }
                    };

                    var emptyFields = times.Where(kv => string.IsNullOrWhiteSpace(kv.Value))
                                           .Select(kv => kv.Key)
                                           .ToList();

                    if (emptyFields.Count > 0)
                    {
                        string msg = "以下时间字段为空，请填写：\n" + string.Join("\n", emptyFields);
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return -1;  // 有空字段，返回 -1
                    }

                    return 0; // 全部都有值，返回0
                }

                int checkResult = CheckTimeFields(user);
                if (checkResult == -1)
                {
                    // 时间字段有空，直接退出函数
                    return false;
                }


                string dataFilePath = Path.Combine(selectedPath, $"{IdName}_Data.WSHL");

                using (FileStream fs = new FileStream(dataFilePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, user);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败：" + ex.Message);
                Console.WriteLine("保存失败：" + ex.ToString());
                return false;
            }
        }


        /// <summary>
        /// 按钮2点击事件：读取所有保存的用户数据并绑定到 DataGridView
        /// </summary>
        public void ReloadDataButton_Click(object sender, EventArgs e)
        {
            // 设置筛选关键字
            string Keyword = _mainForm.FindTextBox.Text;
            if (string.IsNullOrEmpty(Keyword))
            {
                TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
                if (selectedNode != null)
                {
                    TreeViewEventArgs args = new TreeViewEventArgs(selectedNode);
                    treeView1_AfterSelect(_mainForm.treeView1, args); // sender 改为 treeView1 更合理
                }
            }
            else
            {
                TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
                if (selectedNode != null)
                {
                    TreeViewEventArgs args = new TreeViewEventArgs(selectedNode);
                    treeView1_AfterSelect(_mainForm.treeView1, args); // sender 改为 treeView1 更合理
                }
            }
        }

        private void ReloadTableData(string path)
        {
            // 解绑事件，避免触发 SelectionChanged
            _mainForm.dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;

            string sortColumnName = null;
            ListSortDirection sortDirection = ListSortDirection.Ascending;
            string selectedUserId = null;

            if (_mainForm.dataGridView1.CurrentRow != null)
            {
                int currentIndex = _mainForm.dataGridView1.CurrentRow.Index;
                int nextIndex = currentIndex + 1;
                int prevIndex = currentIndex - 1;

                if (nextIndex < _mainForm.dataGridView1.Rows.Count)
                {
                    // 下一行存在，选下一行ID
                    var nextRow = _mainForm.dataGridView1.Rows[nextIndex];
                    if (nextRow.DataBoundItem is UserData nextUser)
                    {
                        selectedUserId = nextUser.ID;
                    }
                }
                else if (prevIndex >= 0)
                {
                    // 下一行不存在，上一行存在，选上一行ID
                    var prevRow = _mainForm.dataGridView1.Rows[prevIndex];
                    if (prevRow.DataBoundItem is UserData prevUser)
                    {
                        selectedUserId = prevUser.ID;
                    }
                }
                else
                {
                    // 只有当前行，没有下一行和上一行，不选中任何行
                    selectedUserId = null;
                }
            }

            if (_mainForm.dataGridView1.SortedColumn != null)
            {
                sortColumnName = _mainForm.dataGridView1.SortedColumn.DataPropertyName;
                sortDirection = (_mainForm.dataGridView1.SortOrder == SortOrder.Descending)
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;
            }

            try
            {
                List<UserData> filteredUsers = LoadAllUsers(path);
                Console.WriteLine($"刷新数据，条数：{filteredUsers.Count}, 尝试恢复选中ID：{selectedUserId}");

                var sortableList = new SortableBindingList<UserData>(filteredUsers);
                _mainForm.dataGridView1.DataSource = null;
                _mainForm.dataGridView1.DataSource = sortableList;
                _mainForm.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // 恢复排序
                if (sortColumnName != null)
                {
                    var sortColumn = _mainForm.dataGridView1.Columns
                        .Cast<DataGridViewColumn>()
                        .FirstOrDefault(c => c.DataPropertyName == sortColumnName);
                    if (sortColumn != null)
                    {
                        _mainForm.dataGridView1.Sort(sortColumn, sortDirection);
                    }
                }

                // 延迟恢复选中行，确保DataGridView刷新完成
                if (!string.IsNullOrEmpty(selectedUserId))
                {
                    _mainForm.dataGridView1.BeginInvoke(new Action(() =>
                    {
                        bool found = false;
                        foreach (DataGridViewRow row in _mainForm.dataGridView1.Rows)
                        {
                            if (row.DataBoundItem is UserData user && user.ID == selectedUserId)
                            {
                                row.Selected = true;
                                _mainForm.dataGridView1.CurrentCell = row.Cells[0];
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("没有找到之前选中的用户ID。");
                        }
                    }));
                }
            }
            finally
            {
                _mainForm.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            }
        }


        // 导出word文档
        public void ExportTheDocumentButton_Click(object sender, EventArgs e)
        {
            // 获取当前行的 ID 作为文件名
            string name = _mainForm.dataGridView1.CurrentRow?.Cells["ID"]?.Value?.ToString();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("无法获取文档名称，请确认表格中有选中行。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 构建系统内部文件路径
            //string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            //string systemDataPath = Path.Combine(currentDir, "SystemData");

            TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("请先选择一个节点！");
                return;
            }
            string selectedPath = selectedNode.Tag?.ToString();
            if (selectedNode.Nodes.Count == 0 && Directory.Exists(selectedPath))
            {
                if (!Directory.Exists(selectedPath))
                {
                    Directory.CreateDirectory(selectedPath);
                    Console.WriteLine("[Log] SystemData 文件夹不存在，已创建。");
                }
            }
            else
            {
                return;
            }


            string outputPath = Path.Combine(selectedPath, $"{name}_Doc.docx");
            Console.WriteLine($"[Log] 原始文档路径：{outputPath}");

            // 弹出保存对话框让用户选择目标路径
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Word 文件 (*.docx)|*.docx",
                Title = "导出 Word 文件",
                FileName = $"{name}_Doc.docx" // 设置默认文件名
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string userSelectedPath = saveDialog.FileName;
                Console.WriteLine($"[Log] 用户选择保存路径：{userSelectedPath}");

                try
                {
                    // 判断源文件是否存在
                    if (!File.Exists(outputPath))
                    {
                        MessageBox.Show($"源文件不存在：{outputPath}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    File.Copy(outputPath, userSelectedPath, overwrite: true);
                    MessageBox.Show("文件导出成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 删除数据
        public void DeleteDataButton_Click(object sender, EventArgs e)
        {
            // 获取当前行的 ID 作为文件名
            string name = _mainForm.dataGridView1.CurrentRow?.Cells["ID"]?.Value?.ToString();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("无法获取文档名称，请确认表格中有选中行。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 获取当前用户 AppData\Roaming\瓦斯含量测定数据分析系统 下的路径
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string baseFolder = Path.Combine(appDataPath, "瓦斯含量测定数据分析系统");
            string sourceFolder = Path.Combine(baseFolder, "SystemData");
            string recycleFolder = Path.Combine(baseFolder, "DataReclamation");

            // 确保回收目录存在
            if (!Directory.Exists(recycleFolder))
            {
                Directory.CreateDirectory(recycleFolder);
            }

            string binPath = Path.Combine(sourceFolder, $"{name}_Data.WSHL");

            TreeNode selectedNode = _mainForm.treeView1.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("请先选择一个节点！");
                return;
            }

            string selectedPath = selectedNode.Tag?.ToString();
            if (selectedNode.Nodes.Count == 0 && Directory.Exists(selectedPath))
            {
                // 如果选中叶子节点，就用该节点路径作为 sourceFolder
                binPath = Path.Combine(selectedPath, $"{name}_Data.WSHL");
            }

            try
            {
                // 移动文件方法（避免覆盖：目标已存在时自动改名）
                void MoveFileToRecycle(string sourceFile)
                {
                    if (File.Exists(sourceFile))
                    {
                        string fileName = Path.GetFileNameWithoutExtension(sourceFile);
                        string extension = Path.GetExtension(sourceFile);
                        string destFile = Path.Combine(recycleFolder, fileName + extension);

                        int count = 1;
                        // 如果已存在，就加上序号
                        while (File.Exists(destFile))
                        {
                            destFile = Path.Combine(
                                recycleFolder,
                                $"{fileName}_{count}{extension}"
                            );
                            count++;
                        }

                        File.Move(sourceFile, destFile);
                        Console.WriteLine($"已移动文件：{sourceFile} -> {destFile}");
                    }
                    else
                    {
                        Console.WriteLine($"文件不存在：{sourceFile}");
                    }
                }


                MoveFileToRecycle(binPath);

                // 刷新表格数据
                if (selectedNode.Nodes.Count == 0 && Directory.Exists(selectedPath))
                {
                    ReloadTableData(selectedPath);
                }

                //MessageBox.Show("文件已移动到回收目录！");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"移动文件时发生错误：{ex.Message}");
            }
        }



        private string _currentKeyword = "";
        void 全部显示(string path)
        {
            _currentKeyword = "";

            string sortColumnName = null;
            ListSortDirection sortDirection = ListSortDirection.Ascending;

            string selectedUserId = null;

            try
            {
                if (_mainForm.dataGridView1.SortedColumn != null)
                {
                    sortColumnName = _mainForm.dataGridView1.SortedColumn.DataPropertyName;
                    sortDirection = (_mainForm.dataGridView1.SortOrder == SortOrder.Descending)
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending;
                }

                if (_mainForm.dataGridView1.CurrentRow != null &&
                    _mainForm.dataGridView1.CurrentRow.DataBoundItem is UserData selectedUser)
                {
                    selectedUserId = selectedUser.ID;
                }

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("数据文件夹不存在！");

                    // 清空dataGridView1数据
                    _mainForm.dataGridView1.DataSource = null;
                    _mainForm.dataGridView1.Rows.Clear();
                    return;
                }

                // 读取所有 _Data.WSHL 文件
                string[] files = Directory.GetFiles(path, "*_Data.WSHL", SearchOption.TopDirectoryOnly);
                if (files.Length == 0)
                {
                    Console.WriteLine("没有找到数据文件！");
                    _mainForm.dataGridView1.DataSource = null; // 清空绑定的数据
                    return;
                }

                List<UserData> allUsers = new List<UserData>();
                BinaryFormatter formatter = new BinaryFormatter();

                foreach (var file in files)
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        UserData user = (UserData)formatter.Deserialize(fs);
                        allUsers.Add(user);
                    }
                }

                var sortableList = new SortableBindingList<UserData>(allUsers);

                _mainForm.dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;

                _mainForm.dataGridView1.DataSource = null;
                _mainForm.dataGridView1.DataSource = sortableList;

                _mainForm.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                if (sortColumnName != null)
                {
                    _mainForm.dataGridView1.BeginInvoke(new Action(() =>
                    {
                        var sortColumn = _mainForm.dataGridView1.Columns
                            .Cast<DataGridViewColumn>()
                            .FirstOrDefault(c => c.DataPropertyName == sortColumnName);

                        if (sortColumn != null)
                        {
                            _mainForm.dataGridView1.Sort(sortColumn, sortDirection);
                        }
                    }));
                }

                if (!string.IsNullOrEmpty(selectedUserId))
                {
                    _mainForm.dataGridView1.BeginInvoke(new Action(() =>
                    {
                        foreach (DataGridViewRow row in _mainForm.dataGridView1.Rows)
                        {
                            if (row.DataBoundItem is UserData user && user.ID == selectedUserId)
                            {
                                row.Selected = true;
                                _mainForm.dataGridView1.CurrentCell = row.Cells[0];
                                break;
                            }
                        }
                    }));
                }

                _mainForm.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

                Console.WriteLine("数据加载完成，已绑定到 dataGridView1。");
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取失败：" + ex.Message);
            }
        }




        // 读取指定目录下所有 *_Data.WSHL 文件，反序列化成 UserData 列表
        List<UserData> LoadAllUsers(string folderPath)
        {
            List<UserData> allUsers = new List<UserData>();

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("目录不存在：" + folderPath);
                return allUsers;
            }

            string[] files = Directory.GetFiles(folderPath, "*_Data.WSHL", SearchOption.TopDirectoryOnly);
            if (files.Length == 0)
            {
                Console.WriteLine("没有找到数据文件！");
                return allUsers;
            }

            BinaryFormatter formatter = new BinaryFormatter();

            foreach (var file in files)
            {
                try
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        UserData user = (UserData)formatter.Deserialize(fs);
                        allUsers.Add(user);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"读取文件失败：{file}，原因：{ex.Message}");
                }
            }

            return allUsers;
        }

        private void 查询显示(string path, string filterKeyword)
        {
            string sortColumnName = null;
            ListSortDirection sortDirection = ListSortDirection.Ascending;
            string selectedUserId = null;

            try
            {
                if (_mainForm.dataGridView1.SortedColumn != null)
                {
                    sortColumnName = _mainForm.dataGridView1.SortedColumn.DataPropertyName;
                    sortDirection = (_mainForm.dataGridView1.SortOrder == SortOrder.Descending)
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending;
                }

                if (_mainForm.dataGridView1.CurrentRow != null &&
                    _mainForm.dataGridView1.CurrentRow.DataBoundItem is UserData selectedUser)
                {
                    selectedUserId = selectedUser.ID;
                }

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("数据文件夹不存在！");
                    ClearDataGridView();
                    return;
                }

                List<UserData> allUsers = LoadAllUsers(path);  // 调用新版读取方法

                if (allUsers.Count == 0)
                {
                    Console.WriteLine("没有数据，无法筛选！");
                    ClearDataGridView();
                    return;
                }

                _currentKeyword = filterKeyword;

                List<UserData> filteredUsers;
                if (string.IsNullOrEmpty(filterKeyword))
                {
                    filteredUsers = allUsers;
                }
                else
                {
                    filteredUsers = allUsers
                        .Where(u =>
                            u.GetType()
                             .GetProperties()
                             .Where(p => p.PropertyType == typeof(string))
                             .Select(p => p.GetValue(u) as string)
                             .Any(val => !string.IsNullOrEmpty(val) &&
                                         val.IndexOf(filterKeyword, StringComparison.OrdinalIgnoreCase) >= 0)
                        )
                        .ToList();
                }

                if (filteredUsers.Count == 0)
                {
                    Console.WriteLine("筛选结果为空！");
                    ClearDataGridView();
                    return;
                }

                var sortableList = new SortableBindingList<UserData>(filteredUsers);

                _mainForm.dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;
                _mainForm.dataGridView1.CellPainting -= DataGridView1_CellPainting;

                _mainForm.dataGridView1.DataSource = null;
                _mainForm.dataGridView1.DataSource = sortableList;

                if (_mainForm.FindTextBox.Text.Contains("X=") || _mainForm.FindTextBox.Text.Contains("Y="))
                {
                    string[] visibleColumns = { "取样地点", "取样地点坐标", "埋深" };
                    foreach (DataGridViewColumn col in _mainForm.dataGridView1.Columns)
                    {
                        col.Visible = visibleColumns.Contains(col.DataPropertyName);
                    }
                }
                else
                {
                    // 确保其他情况全部列都可见
                    foreach (DataGridViewColumn col in _mainForm.dataGridView1.Columns)
                    {
                        col.Visible = true;
                    }
                }

                _mainForm.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                _mainForm.dataGridView1.CellPainting += DataGridView1_CellPainting;

                if (sortColumnName != null)
                {
                    _mainForm.dataGridView1.BeginInvoke(new Action(() =>
                    {
                        var sortColumn = _mainForm.dataGridView1.Columns
                            .Cast<DataGridViewColumn>()
                            .FirstOrDefault(c => c.DataPropertyName == sortColumnName);

                        if (sortColumn != null)
                        {
                            _mainForm.dataGridView1.Sort(sortColumn, sortDirection);
                        }
                    }));
                }

                if (!string.IsNullOrEmpty(selectedUserId))
                {
                    _mainForm.dataGridView1.BeginInvoke(new Action(() =>
                    {
                        foreach (DataGridViewRow row in _mainForm.dataGridView1.Rows)
                        {
                            if (row.DataBoundItem is UserData user && user.ID == selectedUserId)
                            {
                                DataGridViewCell firstVisibleCell = row.Cells.Cast<DataGridViewCell>()
                                    .FirstOrDefault(c => c.Visible);

                                if (firstVisibleCell != null)
                                {
                                    _mainForm.dataGridView1.CurrentCell = firstVisibleCell;
                                }

                                break;
                            }
                        }
                    }));
                }

                _mainForm.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

                Console.WriteLine($"数据加载完成，筛选关键字：'{filterKeyword}'，结果数：{filteredUsers.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取失败：" + ex.Message);
                ClearDataGridView();
            }
        }

        private void ClearDataGridView()
        {
            _mainForm.dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;
            _mainForm.dataGridView1.CellPainting -= DataGridView1_CellPainting;

            _mainForm.dataGridView1.DataSource = null;
            _mainForm.dataGridView1.Rows.Clear();

            _mainForm.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            _mainForm.dataGridView1.CellPainting += DataGridView1_CellPainting;
        }



        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var dgv = sender as DataGridView;

            string cellText = e.FormattedValue?.ToString();
            if (string.IsNullOrEmpty(cellText) || string.IsNullOrEmpty(_currentKeyword))
                return;

            int matchIndex = cellText.IndexOf(_currentKeyword, StringComparison.OrdinalIgnoreCase);
            if (matchIndex < 0)
                return;

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);

            using (var normalBrush = new SolidBrush(dgv.DefaultCellStyle.ForeColor))
            using (var highlightBrush = new SolidBrush(Color.Red))
            using (var boldFont = new Font(e.CellStyle.Font, FontStyle.Bold))
            {
                var g = e.Graphics;
                var font = e.CellStyle.Font;
                var bounds = e.CellBounds;

                string before = cellText.Substring(0, matchIndex);
                string match = cellText.Substring(matchIndex, _currentKeyword.Length);
                string after = cellText.Substring(matchIndex + _currentKeyword.Length);

                float x = bounds.X;
                float y = bounds.Y + (bounds.Height - font.Height) / 2 + 1;

                Size sizeBefore = TextRenderer.MeasureText(before, font);
                Size sizeMatch = TextRenderer.MeasureText(match, boldFont);

                // 普通文字
                g.DrawString(before, font, normalBrush, x, y);
                x += (matchIndex == 0) ? sizeBefore.Width : sizeBefore.Width - 8;

                // 加粗红色高亮文字
                g.DrawString(match, boldFont, highlightBrush, x, y);
                x += sizeMatch.Width - 8;

                // 普通文字
                g.DrawString(after, font, normalBrush, x, y);
            }
        }


        private TreeNode _rightClickedNode;  // 定义一个字段
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode clickedNode = _mainForm.treeView1.GetNodeAt(e.X, e.Y);
            _rightClickedNode = _mainForm.treeView1.GetNodeAt(e.X, e.Y);

            if (e.Button == MouseButtons.Right)
            {
                if (clickedNode != null)
                {
                    // 自动选中右键点击的节点
                    _mainForm.treeView1.SelectedNode = clickedNode;

                    int level = clickedNode.Level;       // 当前层级（0,1,2...）
                    string text = clickedNode.Text;      // 当前节点显示的名字

                    // 判断是否点击到节点文本上（Bounds 区域）
                    Rectangle nodeTextBounds = clickedNode.Bounds;
                    bool isOnText = (e.X >= nodeTextBounds.Left && e.X <= nodeTextBounds.Right);

                    // 判断是否当前节点已被选中
                    bool isSelected = (_mainForm.treeView1.SelectedNode == clickedNode);

                    // 点击根目录
                    if (level == 0 && isOnText && isSelected)
                    {
                        _mainForm.tabPage6contextMenuStrip1.Items["刷新ToolStripMenuItem"].Visible = true;
                        _mainForm.tabPage6contextMenuStrip1.Items["导出矿井Excel统计表ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["导出矿井数据ToolStripMenuItem"].Visible = true;
                        _mainForm.tabPage6contextMenuStrip1.Items["合并矿井数据ToolStripMenuItem"].Visible = true;
                        _mainForm.tabPage6contextMenuStrip1.Items["删除项目ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["删除煤矿及项目ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["重命名ToolStripMenuItem"].Visible = false;
                    }
                    else if (level == 1 && isOnText && isSelected)
                    {
                        //MessageBox.Show($"当前点击层级：{level},{text}");
                        // 导出煤矿数据
                        _mainForm.tabPage6contextMenuStrip1.Items["刷新ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["导出矿井Excel统计表ToolStripMenuItem"].Visible = true;
                        _mainForm.tabPage6contextMenuStrip1.Items["导出矿井数据ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["合并矿井数据ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["删除项目ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["删除煤矿及项目ToolStripMenuItem"].Visible = true;
                        _mainForm.tabPage6contextMenuStrip1.Items["重命名ToolStripMenuItem"].Visible = true;
                    }
                    // 点击项目
                    else if (level == 2 && isOnText && isSelected)
                    {
                        _mainForm.tabPage6contextMenuStrip1.Items["刷新ToolStripMenuItem"].Visible = true;
                        _mainForm.tabPage6contextMenuStrip1.Items["导出矿井Excel统计表ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["导出矿井数据ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["合并矿井数据ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["删除项目ToolStripMenuItem"].Visible = true;
                        _mainForm.tabPage6contextMenuStrip1.Items["删除煤矿及项目ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["重命名ToolStripMenuItem"].Visible = true;
                    }
                    else
                    {
                        _mainForm.tabPage6contextMenuStrip1.Items["刷新ToolStripMenuItem"].Visible = true;
                        _mainForm.tabPage6contextMenuStrip1.Items["导出矿井Excel统计表ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["导出矿井数据ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["合并矿井数据ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["删除项目ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["删除煤矿及项目ToolStripMenuItem"].Visible = false;
                        _mainForm.tabPage6contextMenuStrip1.Items["重命名ToolStripMenuItem"].Visible = false;
                    }
                }
                // 点击空白处
                else
                {
                    _mainForm.tabPage6contextMenuStrip1.Items["刷新ToolStripMenuItem"].Visible = true;
                    _mainForm.tabPage6contextMenuStrip1.Items["导出矿井Excel统计表ToolStripMenuItem"].Visible = false;
                    _mainForm.tabPage6contextMenuStrip1.Items["导出矿井数据ToolStripMenuItem"].Visible = true;
                    _mainForm.tabPage6contextMenuStrip1.Items["合并矿井数据ToolStripMenuItem"].Visible = true;
                    _mainForm.tabPage6contextMenuStrip1.Items["删除项目ToolStripMenuItem"].Visible = false;
                    _mainForm.tabPage6contextMenuStrip1.Items["删除煤矿及项目ToolStripMenuItem"].Visible = false;
                    _mainForm.tabPage6contextMenuStrip1.Items["重命名ToolStripMenuItem"].Visible = false;
                }
                _mainForm.tabPage6contextMenuStrip1.Show(_mainForm.treeView1, e.Location); // 弹出菜单
            }
        }
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 获取当前用户的 AppData\Roaming 路径
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // 构建目标文件夹路径：AppData\Roaming\瓦斯含量测定数据分析系统\SystemData\DataAdministrationForm
            string rootPath = Path.Combine(appDataPath, "瓦斯含量测定数据分析系统", "SystemData", "DataAdministrationForm");

            // 如果路径不存在则创建
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            // 加载该路径下的文件夹结构到树控件
            LoadFoldersToTree(rootPath);
        }

        public string SelectSaveExcelFile(string name)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                var lastFolder = GasFormsApp.Settings.Default.LastFolder;
                saveFileDialog.InitialDirectory = string.IsNullOrEmpty(lastFolder)
                    ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    : lastFolder;

                saveFileDialog.Filter = "Excel 文件 (*.xlsx)|*.xlsx|Excel 97-2003 文件 (*.xls)|*.xls";
                saveFileDialog.Title = "请选择保存位置";
                saveFileDialog.FileName = $"{name}" + ".xlsx"; // 可以根据需要设置默认文件名

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GasFormsApp.Settings.Default.LastFolder = Path.GetDirectoryName(saveFileDialog.FileName);
                    GasFormsApp.Settings.Default.Save();
                    return saveFileDialog.FileName;
                }
                else
                {
                    return null;
                }
            }
        }

        private void 导出矿井数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string targetDir = Path.Combine(appData, "瓦斯含量测定数据分析系统", "SystemData", "DataAdministrationForm");

            if (!Directory.Exists(targetDir))
            {
                Console.WriteLine("目标目录不存在，创建目录：" + targetDir);
                Directory.CreateDirectory(targetDir);
            }

            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Multiselect = true,
                InitialDirectory = targetDir,
                Title = "请选择需要导出的矿井目录"
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                foreach (var selectedFolder in dialog.FileNames)
                {
                    string parent = Directory.GetParent(selectedFolder)?.FullName;
                    if (!string.Equals(parent, targetDir, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("只能选择目录下的一级子文件夹!");
                        return;
                    }
                }

                // 让用户选择导出目录
                string exportDir = SelectExportFolder();
                if (string.IsNullOrEmpty(exportDir))
                {
                    Console.WriteLine("用户未选择导出目录，程序终止。");
                    return;
                }

                // 在 exportDir 下创建带时间戳的子文件夹
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string exportSubDir = Path.Combine(exportDir, $"矿井数据导出_{timestamp}");
                Directory.CreateDirectory(exportSubDir);

                // 复制文件夹
                foreach (var sourceFolder in dialog.FileNames)
                {
                    string folderName = Path.GetFileName(sourceFolder);
                    string destFolder = Path.Combine(exportSubDir, folderName);

                    Console.WriteLine($"复制：{sourceFolder} -> {destFolder}");
                    CopyDirectory(sourceFolder, destFolder);
                }

                Console.WriteLine("数据已成功导出到：" + exportSubDir);
                MessageBox.Show("数据已成功导出到：" + exportSubDir, "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Console.WriteLine("用户取消了选择");
            }
        }

        // 弹出文件夹选择对话框，返回用户选择的路径，取消返回空字符串
        private static string SelectExportFolder()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "请选择导出数据的文件夹";
                fbd.ShowNewFolderButton = true;
                var result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    return fbd.SelectedPath;
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 递归复制文件夹
        /// </summary>
        static void CopyDirectory(string sourceDir, string targetDir)
        {
            // 创建目标文件夹
            Directory.CreateDirectory(targetDir);

            // 复制所有文件
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(targetDir, fileName);
                File.Copy(file, destFile, true); // 覆盖
            }

            // 递归复制所有子文件夹
            foreach (var subDir in Directory.GetDirectories(sourceDir))
            {
                string subDirName = Path.GetFileName(subDir);
                string destSubDir = Path.Combine(targetDir, subDirName);
                CopyDirectory(subDir, destSubDir);
            }
        }
        static void _CopyDirectory(string sourceDir, string targetDir)
        {
            // 创建目标文件夹
            Directory.CreateDirectory(targetDir);

            // 复制所有文件
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(targetDir, fileName);

                if (File.Exists(destFile))
                {
                    // 如果存在同名文件，加时间戳
                    string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                    string extension = Path.GetExtension(fileName);
                    string newFileName = $"{fileNameWithoutExt}_{timeStamp}{extension}";
                    destFile = Path.Combine(targetDir, newFileName);
                }

                File.Copy(file, destFile);
            }

            // 递归复制所有子文件夹
            foreach (var subDir in Directory.GetDirectories(sourceDir))
            {
                string subDirName = Path.GetFileName(subDir);
                string destSubDir = Path.Combine(targetDir, subDirName);

                if (Directory.Exists(destSubDir))
                {
                    // 如果存在同名文件夹，加时间戳
                    string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string newSubDirName = $"{subDirName}_{timeStamp}";
                    destSubDir = Path.Combine(targetDir, newSubDirName);
                }

                _CopyDirectory(subDir, destSubDir);
            }
        }
        private void 合并矿井数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Multiselect = true,
                Title = "请选择需要合并的矿井目录"
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string targetDir = Path.Combine(appData, "瓦斯含量测定数据分析系统", "SystemData", "DataAdministrationForm");

                if (!Directory.Exists(targetDir))
                {
                    Directory.CreateDirectory(targetDir);
                }

                foreach (var sourceDir in dialog.FileNames)
                {
                    string folderName = Path.GetFileName(sourceDir.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
                    string destSubDir = Path.Combine(targetDir, folderName);

                    if (Directory.Exists(destSubDir))
                    {
                        Console.WriteLine($"目标目录已存在：{destSubDir}，将合并数据。");
                    }
                    else
                    {
                        Console.WriteLine($"创建新目录：{destSubDir}");
                        Directory.CreateDirectory(destSubDir);
                    }

                    // 合并数据（同名文件覆盖）
                    _CopyDirectory(sourceDir, destSubDir);

                    Console.WriteLine($"已合并: {sourceDir} -> {destSubDir}");
                }

                MessageBox.Show("合并完成！", "提示");
            }
        }

        private void 导出矿井Excel统计表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_rightClickedNode != null)
            {
                string path = _rightClickedNode.Tag as string;
                string nodeName = _rightClickedNode.Text; // 这里是节点名字
                if (!string.IsNullOrEmpty(path))
                {
                    //MessageBox.Show($"当前节点路径：{path}\n当前节点名称：{nodeName}");
                    // 这里做导出等操作
                    string excelPath = SelectSaveExcelFile(nodeName);
                    if (!string.IsNullOrEmpty(excelPath))
                    {
                        try
                        {
                            using (var workbook = new XLWorkbook())
                            {
                                var worksheet = workbook.Worksheets.Add("Sheet1");

                                // 全局默认字体：宋体 11
                                worksheet.Style.Font.FontName = "宋体";
                                worksheet.Style.Font.FontSize = 11;

                                // 合并 A1:I1，做标题
                                worksheet.Range("A1:I1").Merge();
                                var titleCell = worksheet.Cell("A1");
                                string nodeText = _rightClickedNode.Text;
                                titleCell.Value = nodeText;                  // 设置标题内容
                                titleCell.Style.Font.FontName = "宋体";             // 字体
                                titleCell.Style.Font.FontSize = 22;                // 字体大小
                                titleCell.Style.Font.Bold = true;                  // 加粗（可选）
                                titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // 居中
                                titleCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                // 小标题
                                worksheet.Range("A2:A3").Merge();
                                titleCell = worksheet.Cell("A2");
                                titleCell.Value = "序号";
                                titleCell.Style.Font.FontName = "宋体";
                                titleCell.Style.Font.FontSize = 14;
                                titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // 居中
                                titleCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                worksheet.Range("B2:B3").Merge();
                                titleCell = worksheet.Cell("B2");
                                titleCell.Value = "取样地点";
                                titleCell.Style.Font.FontName = "宋体";
                                titleCell.Style.Font.FontSize = 14;
                                titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // 居中
                                titleCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                worksheet.Range("C2:C3").Merge();
                                titleCell = worksheet.Cell("C2");
                                titleCell.Value = "埋深（m）";
                                titleCell.Style.Font.FontName = "宋体";
                                titleCell.Style.Font.FontSize = 14;
                                titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // 居中
                                titleCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                worksheet.Range("D2:D3").Merge();
                                titleCell = worksheet.Cell("D2");
                                titleCell.Value = "煤种";
                                titleCell.Style.Font.FontName = "宋体";
                                titleCell.Style.Font.FontSize = 14;
                                titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // 居中
                                titleCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                worksheet.Range("E2:G2").Merge();
                                titleCell = worksheet.Cell("E2");
                                titleCell.Value = "取样点坐标";
                                titleCell.Style.Font.FontName = "宋体";
                                titleCell.Style.Font.FontSize = 14;
                                titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // 居中
                                titleCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                worksheet.Cell("E3").Value = "X";
                                worksheet.Cell("F3").Value = "Y";
                                worksheet.Cell("G3").Value = "Z";
                                foreach (var addr in new[] { "E3", "F3", "G3" })
                                {
                                    var cell = worksheet.Cell(addr);
                                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                }
                                titleCell.Style.Font.FontName = "宋体";
                                titleCell.Style.Font.FontSize = 14;

                                worksheet.Range("H2:H3").Merge();
                                titleCell = worksheet.Cell("H2");
                                titleCell.Value = "瓦斯含量（W）";
                                titleCell.Style.Font.FontName = "宋体";
                                titleCell.Style.Font.FontSize = 14;
                                titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // 居中
                                titleCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                worksheet.Range("I2:I3").Merge();
                                titleCell = worksheet.Cell("I2");
                                titleCell.Value = "瓦斯压力（P）";
                                titleCell.Style.Font.FontName = "宋体";
                                titleCell.Style.Font.FontSize = 14;
                                titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // 居中
                                titleCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                ////////////////////////////////////////////////////////
                                worksheet.Column(1).Width = 12;
                                worksheet.Column(2).Width = 50;
                                worksheet.Column(3).Width = 12;
                                worksheet.Column(4).Width = 12;
                                worksheet.Column(5).Width = 12;
                                worksheet.Column(6).Width = 12;
                                worksheet.Column(7).Width = 12;
                                worksheet.Column(8).Width = 18;
                                worksheet.Column(9).Width = 18;
                                ////////////////////////////////////////////////////////
                                string nodePath = _rightClickedNode.Tag as string;
                                if (!string.IsNullOrEmpty(nodePath))
                                {
                                    string directoryPath;

                                    if (Directory.Exists(nodePath))
                                    {
                                        directoryPath = nodePath;
                                    }
                                    else if (File.Exists(nodePath))
                                    {
                                        directoryPath = Path.GetDirectoryName(nodePath);
                                    }
                                    else
                                    {
                                        MessageBox.Show("节点路径不存在！");
                                        return;
                                    }

                                    string[] subDirs = Directory.GetDirectories(directoryPath);

                                    int binFileCount = 0;  // 计数器

                                    string message = $"当前目录：{directoryPath}\n子目录及文件列表：\n";

                                    var binFiles = new List<string>();
                                    foreach (var dir in subDirs)
                                    {
                                        message += $"目录：{Path.GetFileName(dir)}\n";

                                        string[] files = Directory.GetFiles(dir, "*.WSHL");
                                        binFiles.AddRange(files);
                                        binFileCount += files.Length;  // 统计数量

                                        foreach (var file in files)
                                        {
                                            message += $"  文件：{Path.GetFileName(file)}\n";
                                        }
                                    }

                                    message += $"\n所有子目录中 .WSHL 文件总数：{binFileCount}";
                                    BinaryFormatter formatter = new BinaryFormatter();
                                    // 从 E4 开始写编号，F4 开始写文件名
                                    for (int i = 0; i < binFileCount; i++)
                                    {
                                        //worksheet.Cell("A" + (4 + i)).Value = i + 1;  // 编号
                                        //worksheet.Cell("F" + (4 + i)).Value = Path.GetFileName(binFiles[i]); // 文件名

                                        titleCell = worksheet.Cell("A" + (4 + i));
                                        titleCell.Value = i + 1;
                                        titleCell.Style.Font.FontName = "宋体";
                                        titleCell.Style.Font.FontSize = 12;
                                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // 居中
                                        titleCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                        //titleCell = worksheet.Cell("B" + (4 + i));
                                        //titleCell.Value = Path.GetFileName(binFiles[i]);
                                        //titleCell.Style.Font.FontName = "宋体";
                                        //titleCell.Style.Font.FontSize = 12;
                                        //titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // 居中
                                        //titleCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                        //////////////////////////////////////////////////////////////////////////
                                        //1
                                        UserData user;
                                        using (FileStream fs = new FileStream(binFiles[i], FileMode.Open))
                                        {
                                            user = (UserData)formatter.Deserialize(fs);
                                        }

                                        var cell = worksheet.Cell("B" + (4 + i));
                                        cell.Value = user.取样地点;
                                        cell.Style.Font.FontName = "宋体";
                                        cell.Style.Font.FontSize = 12;
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                        cell = worksheet.Cell("C" + (4 + i));
                                        string depthStr = user.埋深;
                                        double depthValue;
                                        if (double.TryParse(depthStr, out depthValue))
                                        {
                                            // 转换成功，depthValue就是数字
                                            Console.WriteLine($"埋深的数值是 {depthValue}");
                                        }
                                        else
                                        {
                                            // 转换失败，字符串格式不正确
                                            Console.WriteLine("埋深转换成数字失败");
                                        }
                                        cell.Value = depthValue;
                                        cell.Style.Font.FontName = "宋体";
                                        cell.Style.Font.FontSize = 12;
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                        cell = worksheet.Cell("D" + (4 + i));
                                        cell.Value = user.煤种;
                                        cell.Style.Font.FontName = "宋体";
                                        cell.Style.Font.FontSize = 12;
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;


                                        ///////////////////////////////////////////////////////////
                                        string input = user.取样地点坐标;
                                        // 如果 input 是 null，就替换为 ""
                                        if (string.IsNullOrWhiteSpace(input))
                                        {
                                            input = "X=0,Y=0,Z=0";  // 或者直接 return / 设置默认值
                                        }
                                        double x = 0, y = 0, z = 0;
                                        // 提取 X
                                        var matchX = Regex.Match(input, @"X\s*=\s*([-+]?\d+(\.\d+)?)", RegexOptions.IgnoreCase);
                                        if (matchX.Success && double.TryParse(matchX.Groups[1].Value, out double valX))
                                        {
                                            x = valX;
                                        }
                                        // 提取 Y
                                        var matchY = Regex.Match(input, @"Y\s*=\s*([-+]?\d+(\.\d+)?)", RegexOptions.IgnoreCase);
                                        if (matchY.Success && double.TryParse(matchY.Groups[1].Value, out double valY))
                                        {
                                            y = valY;
                                        }
                                        // 提取 Z
                                        var matchZ = Regex.Match(input, @"Z\s*=\s*([-+]?\d+(\.\d+)?)", RegexOptions.IgnoreCase);
                                        if (matchZ.Success && double.TryParse(matchZ.Groups[1].Value, out double valZ))
                                        {
                                            z = valZ;
                                        }
                                        ///////////////////////////////////////////////////////////
                                        cell = worksheet.Cell("E" + (4 + i));
                                        cell.Value = x;
                                        cell.Style.Font.FontName = "宋体";
                                        cell.Style.Font.FontSize = 12;
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                        cell = worksheet.Cell("F" + (4 + i));
                                        cell.Value = y;
                                        cell.Style.Font.FontName = "宋体";
                                        cell.Style.Font.FontSize = 12;
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                        cell = worksheet.Cell("G" + (4 + i));
                                        cell.Value = z;
                                        cell.Style.Font.FontName = "宋体";
                                        cell.Style.Font.FontSize = 12;
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                        // 假设 user.W 和 user.P 是字符串类型，需要转换成数字
                                        double w = 0, p = 0;
                                        // 尝试转换 W
                                        if (!double.TryParse(user.W, out w))
                                        {
                                            w = 0; // 转换失败时默认用 0（也可以用其他默认值）
                                        }
                                        // 尝试转换 P
                                        if (!double.TryParse(user.P.Split('[')[0], out p))
                                        {
                                            p = 0;
                                        }
                                        
                                        // 写到 H 列
                                        cell = worksheet.Cell("H" + (4 + i));
                                        cell.Value = w;
                                        cell.Style.Font.FontName = "宋体";
                                        cell.Style.Font.FontSize = 12;
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                        // 写到 I 列
                                        cell = worksheet.Cell("I" + (4 + i));
                                        cell.Value = p;
                                        cell.Style.Font.FontName = "宋体";
                                        cell.Style.Font.FontSize = 12;
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                    }

                                    //MessageBox.Show(message);
                                }
                                else
                                {
                                    MessageBox.Show("节点未关联路径！");
                                }



                                workbook.SaveAs(excelPath);
                            }

                            MessageBox.Show("Excel 文件已成功导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"导出失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("未选择文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("该节点没有设置路径！");
                }
            }
        }

        private void 删除项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_rightClickedNode != null)
            {
                string path = _rightClickedNode.Tag as string;

                if (!string.IsNullOrEmpty(path))
                {
                    // 获取最后一级目录名
                    string dirName = Path.GetFileName(path);

                    // 弹出确认提示
                    DialogResult confirm = MessageBox.Show(
                        $"确定要删除项目吗？\n\n项目名称：\r\n{dirName}",
                        "确认移动",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            // 1. 获取 AppData 目录
                            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                            // 2. 目标目录
                            string targetDir = Path.Combine(appData, "瓦斯含量测定数据分析系统", "DataReclamation");

                            // 如果目标目录不存在，先创建
                            if (!Directory.Exists(targetDir))
                            {
                                Directory.CreateDirectory(targetDir);
                            }

                            // 3. 拼接新的目标路径：目标目录 + 当前目录名
                            string destPath = Path.Combine(targetDir, dirName);

                            // 如果目标目录下已经有同名目录，为避免冲突，可加时间戳或GUID
                            if (Directory.Exists(destPath))
                            {
                                string newDirName = dirName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                                destPath = Path.Combine(targetDir, newDirName);
                            }

                            // 4. 移动目录
                            Directory.Move(path, destPath);

                            // 5. 移动成功后，从 TreeView 移除节点
                            //_rightClickedNode.Remove();

                            // 可选：提示用户
                            //MessageBox.Show($"项目已移动到：\n{destPath}", "移动成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"移动失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        private void 删除煤矿及项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_rightClickedNode != null)
            {
                string path = _rightClickedNode.Tag as string;

                if (!string.IsNullOrEmpty(path))
                {
                    string dirName = Path.GetFileName(path);

                    // 弹出确认提示
                    DialogResult confirm = MessageBox.Show(
                        $"确定要删除矿井数据吗？\n\n矿井名称：\r\n{Path.GetFileName(path)}",
                        "确认删除",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            // 1. 获取 AppData 目录
                            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                            // 2. 目标回收目录
                            string targetDir = Path.Combine(appData, "瓦斯含量测定数据分析系统", "DataReclamation");

                            // 3. 如果目标目录不存在，先创建
                            if (!Directory.Exists(targetDir))
                            {
                                Directory.CreateDirectory(targetDir);
                            }

                            // 4. 生成目标路径：目标目录 + 当前目录名
                            string destPath = Path.Combine(targetDir, dirName);

                            // 5. 如果已存在同名目录，加时间戳
                            if (Directory.Exists(destPath))
                            {
                                string newDirName = dirName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                                destPath = Path.Combine(targetDir, newDirName);
                            }

                            // 6. 移动目录
                            Directory.Move(path, destPath);

                            // 7. 移动成功后，从 TreeView 移除节点
                            //_rightClickedNode.Remove();

                            // 8. 可选：提示用户
                            //MessageBox.Show($"矿井数据已移动到：\n{destPath}", "移动成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"移动失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_rightClickedNode != null)
            {
                _mainForm.treeView1.LabelEdit = true;
                _rightClickedNode.BeginEdit();
            }
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null)
                return; // 用户取消编辑

            string oldPath = e.Node.Tag?.ToString();
            if (string.IsNullOrEmpty(oldPath) || !Directory.Exists(oldPath))
                return;

            string newName = e.Label.Trim();

            // 检查非法字符
            if (string.IsNullOrWhiteSpace(newName) || newName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                MessageBox.Show("名称无效！");
                e.CancelEdit = true;
                return;
            }

            try
            {
                string parentPath = Path.GetDirectoryName(oldPath);
                string newPath = Path.Combine(parentPath, newName);

                if (Directory.Exists(newPath))
                {
                    MessageBox.Show("已存在同名文件夹！");
                    e.CancelEdit = true;
                    return;
                }

                // 重命名文件夹
                Directory.Move(oldPath, newPath);
                e.Node.Tag = newPath; // 更新路径
            }
            catch (Exception ex)
            {
                MessageBox.Show("重命名失败：" + ex.Message);
                e.CancelEdit = true;
            }
        }
    }
}
