# 导入必要的库
import matplotlib.pyplot as plt  # 绘图库
import numpy as np  # 数值计算库
import io  # 用于内存字节流操作
import matplotlib  # 绘图基础库
import ctypes  # 用于调用C/C++共享内存
from ctypes import wintypes  # Windows类型定义
import struct  # 字节打包/解包
import time  # 时间相关操作

# 设置中文字体（解决乱码）
matplotlib.rcParams['font.sans-serif'] = ['SimHei']  # 使用黑体显示中文
matplotlib.rcParams['axes.unicode_minus'] = False    # 解决负号显示问题

# 定义Windows API常量
PAGE_READWRITE = 0x04  # 内存读写权限
FILE_MAP_READ = 0x0004  # 文件映射读取权限
INVALID_HANDLE_VALUE = -1  # 无效句柄值

# 加载Windows内核库
kernel32 = ctypes.WinDLL('kernel32', use_last_error=True)

# 定义Windows API函数原型
OpenFileMapping = kernel32.OpenFileMappingW
OpenFileMapping.argtypes = [wintypes.DWORD, wintypes.BOOL, wintypes.LPCWSTR]
OpenFileMapping.restype = wintypes.HANDLE

MapViewOfFile = kernel32.MapViewOfFile
MapViewOfFile.argtypes = [wintypes.HANDLE, wintypes.DWORD,
                          wintypes.DWORD, wintypes.DWORD, ctypes.c_size_t]
MapViewOfFile.restype = wintypes.LPVOID

UnmapViewOfFile = kernel32.UnmapViewOfFile
UnmapViewOfFile.argtypes = [wintypes.LPCVOID]
UnmapViewOfFile.restype = wintypes.BOOL

CloseHandle = kernel32.CloseHandle
CloseHandle.argtypes = [wintypes.HANDLE]
CloseHandle.restype = wintypes.BOOL

def read_shared_memory(map_name="Local\\MySharedMemory", rows=60, cols=2, retries=10, retry_interval=1):
    """
    从共享内存读取数据
    
    参数:
        map_name: 共享内存名称
        rows: 数据行数
        cols: 数据列数
        retries: 重试次数
        retry_interval: 重试间隔(秒)
    
    返回:
        二维列表形式的数据矩阵
    """
    size = rows * cols * 8  # 计算内存大小(每个double占8字节)
    hMap = None  # 内存映射句柄

    # 重试机制打开共享内存
    for attempt in range(retries):
        hMap = OpenFileMapping(FILE_MAP_READ, False, map_name)
        if hMap:
            break
        time.sleep(retry_interval)

    if not hMap:
        raise RuntimeError("无法打开共享内存")

    # 映射内存视图
    pBuf = MapViewOfFile(hMap, FILE_MAP_READ, 0, 0, size)
    if not pBuf:
        CloseHandle(hMap)
        raise ctypes.WinError(ctypes.get_last_error())

    try:
        # 读取内存数据并转换为Python数据结构
        buffer_type = ctypes.c_char * size
        buffer = buffer_type.from_address(pBuf)
        read_bytes = bytes(buffer[:])
        values = struct.unpack('d' * rows * cols, read_bytes)
        matrix = [values[i*cols:(i+1)*cols] for i in range(rows)]
        return matrix
    finally:
        # 清理资源
        UnmapViewOfFile(pBuf)
        CloseHandle(hMap)

# 从共享内存读取数据
data = read_shared_memory()[:12]
# 先筛选出满足条件的点
x = np.array([row[0] for row in data if row[0] != 0 and row[1] != 0])
y = np.array([row[1] for row in data if row[0] != 0 and row[1] != 0])
# 线性拟合(1次多项式拟合)
coefficients = np.polyfit(x, y, 1)
slope, intercept = coefficients  # 获取斜率和截距
fitted_y = slope * x + intercept  # 计算拟合值
# 计算R平方值(拟合优度)
ss_res = np.sum((y - fitted_y) ** 2)  # 残差平方和
ss_tot = np.sum((y - np.mean(y)) ** 2)  # 总平方和
r_squared = 1 - ss_res / ss_tot  # R平方值

data = read_shared_memory()[:20]  # 多取一点，防止筛选后点太少

# 筛选满足条件的点（非零）
filtered_points = [row for row in data if row[0] != 0 and row[1] != 0]

best_r2 = -np.inf
best_range = None
best_coefficients = None
DataExtentEnd = 0

# 确保筛选后的点数够12个
max_len = min(len(filtered_points), 12)

for end in range(5, max_len + 1):  # 从第5个点到第max_len个点
    subset = filtered_points[:end]
    x = np.array([row[0] for row in subset])
    y = np.array([row[1] for row in subset])
    coefficients = np.polyfit(x, y, 1)
    slope, intercept = coefficients
    fitted_y = slope * x + intercept
    ss_res = np.sum((y - fitted_y) ** 2)
    ss_tot = np.sum((y - np.mean(y)) ** 2)
    r_squared = 1 - ss_res / ss_tot

    if r_squared > best_r2:
        best_r2 = r_squared
        best_range = (1, end)
        DataExtentEnd = end
        best_coefficients = coefficients

# 从共享内存读取数据
data = read_shared_memory()
# 先筛选出满足条件的点
x = np.array([row[0] for row in data if row[0] != 0 and row[1] != 0])
y = np.array([row[1] for row in data if row[0] != 0 and row[1] != 0])
y_max_value = max(y)
y_max_value = np.max(y)          # y的最大值
index_of_max = np.argmax(y)      # y最大值对应的索引
x_max_value = x[index_of_max]    # 对应的x值
x_max_value_ceil = np.ceil(x_max_value)
print("x最大值是:", x_max_value_ceil)
# 创建图形和坐标轴
fig, ax = plt.subplots(figsize=(6, 6))

def to_sqrt_form_auto(value, tol=1e-5):
    squared = value ** 2
    rounded = round(squared)
    if abs(squared - rounded) < tol:
        # 说明value接近根号rounded
        return f"√{rounded-2}"
    else:
        # 不能准确转换，返回字符串保留3位小数
        return f"{value:.3f}"
for item in x:
    print(to_sqrt_form_auto(item))

# 绘制散点图(原始数据)和拟合线
ax.scatter(x, y, s=4, color='blue', label='原始数据')
data = read_shared_memory()[:DataExtentEnd]
# 先筛选出满足条件的点
x = np.array([row[0] for row in data if row[0] != 0 and row[1] != 0])
y = np.array([row[1] for row in data if row[0] != 0 and row[1] != 0])
ax.scatter(x, y, s=14, color='red', marker='D',label='原始数据')
slope = best_coefficients[0]
intercept = best_coefficients[1]
x_new = np.linspace(0, np.max(x)+0.5, 100)
y_new = slope * x_new + intercept
ax.plot(x_new, y_new, color='black', label=f'拟合线: y = {slope:.3f}x + {intercept:.3f}')

sign = '+' if intercept >= 0 else '-'
abs_intercept = abs(intercept)
ax.text(0.6, ax.get_ylim()[1]-ax.get_ylim()[1]/7, f'y = {slope:.3f}x {sign} {abs_intercept:.3f} \n    $R^2$ = {best_r2:.5f}', fontsize=18, color='black',fontname='Times New Roman')

# ax.text(
#     0.95, ax.get_ylim()[1]-ax.get_ylim()[1],
#     r'$\sqrt{t_0 + t}\ (\mathrm{min}^{0.5})$',
#     transform=ax.transAxes,  # 使用坐标轴单位（0~1）
#     ha='right',
#     va='top',
#     fontsize=18
# )

_xxx = x_max_value_ceil + 1
_yyy = y_max_value

print("intercept:",intercept)
import math
def custom_round_up(x):
    val = math.ceil(abs(x))
    # 先计算十位部分
    tens = val // 10
    ones = val % 10
    
    # 如果个位是1-9之间，直接进位到下一个10的整数
    # 这里按照你的需求，只要个位不是0都进位
    if ones != 0:
        val = (tens + 1) * 10
    
    # 恢复符号
    return val if x >= 0 else -val
# 设置坐标轴范围
ax.set_xlim(0, _xxx)
y_start = -custom_round_up(intercept)
y_end = _yyy + 1

if y_start > y_end:
    ax.set_ylim(y_end, y_start)  # 自动调换顺序，避免Y轴反转
else:
    ax.set_ylim(y_start, y_end)


# 设置刻度
ax.set_xticks(np.arange(1, _xxx, 1))  # X轴1到8，步长1
def auto_step(start, end, target_ticks=8, max_ticks=10):
    range_val = end - start
    if range_val <= 0:
        return 1

    rough_step = range_val / target_ticks
    magnitude = 10 ** np.floor(np.log10(rough_step))
    
    # 尝试更多常见倍数，从小到大，尽量细致
    multiples = np.arange(1, 10.5, 0.5)  # 1 到 10，每隔 0.5 增加
    steps = sorted([magnitude * m for m in multiples])
    
    for step in steps:
        num_ticks = range_val / step
        if num_ticks <= max_ticks:
            return step

    # 所有都太细，最后返回最大步长
    return steps[-1]


# 假设你有如下数据：
# intercept = -87
# _yyy = 243

neg_limit = custom_round_up(intercept)  # -90
pos_limit = custom_round_up(_yyy)       # 250

# 以包含范围为基础计算步长
step = auto_step(neg_limit, pos_limit)

# 以 0 为中心，向正负两边展开
# 先确定正负最多需要多少个步长
n_pos = int(np.ceil(pos_limit / step))
n_neg = int(np.ceil(abs(neg_limit) / step))

# 构造刻度：从 -n_neg*step 到 +n_pos*step，以 step 为间隔
yticks = np.arange(-n_neg * step, (n_pos + 1) * step, step)
print("yticks:", yticks)

# 设置 y 轴刻度
ax.set_yticks(yticks)
# ax.set_yticks(np.arange(custom_round_up(intercept), _yyy+1, 50))  # Y轴-60到140，步长20
ax.tick_params(axis='x', labelsize=18,direction='in')  # 设置X轴刻度标签字体大小为12
ax.tick_params(axis='y', labelsize=18,direction='in')  # 设置Y轴刻度标签字体大小为12



plt.rcParams['font.family'] = 'Times New Roman'
plt.rcParams['xtick.labelsize'] = 18
plt.rcParams['ytick.labelsize'] = 18


# ax.set_ylabel(r'$\sqrt{t_0 + t}\ (\mathrm{min}^{0.5})$', fontsize=20)
# ax.set_xlabel(r'$\sqrt{t_0 + t}\ (\mathrm{min}^{0.5})$    ', fontsize=18, loc='right',fontname='Times New Roman')
ax.set_xlabel(r'$\sqrt{t_0 + t}$' + "(min$^{0.5}$)       ", fontsize=18, loc='right',fontname='Times New Roman')


# 设置坐标轴样式
# ax.spines['top'].set_visible(False)  # 隐藏上边框
# ax.spines['right'].set_visible(False)  # 隐藏右边框
ax.spines['left'].set_position('zero')  # 左边框移动到零位置
ax.spines['bottom'].set_position('zero')  # 下边框移动到零位置
# 隐藏默认坐标轴线
for spine in ax.spines.values():
    spine.set_visible(False)


yticks = ax.get_yticks()
max_tick = max(yticks)
# 添加箭头风格的坐标轴
ax.annotate('', xy=(_xxx-1+0.5, 0), xytext=(0-0.03, 0),
            arrowprops=dict(arrowstyle='->', lw=1.0, color='black'))  # X轴箭头

max_tick = max(ax.get_yticks())
min_tick_shown = min(ax.get_yticks())
ax.set_ylim(custom_round_up(intercept) - step, max_tick + step)  # 多留一格
ax.annotate('', xy=(0, max_tick + step - step * 0.2), xytext=(0, min_tick_shown-0/19.1),
# ax.annotate('', xy=(0, max_tick + step - step * 0.2), xytext=(0, 0),
            arrowprops=dict(arrowstyle='->', lw=1.0, color='#000000',antialiased=False,
                            shrinkA=0, shrinkB=0))  # Y轴箭头

# import matplotlib.patches as patches
# x0 = 0
# y_top = 0
# width = 0
# height = 90
# # 转换为左下角坐标
# rect = patches.Rectangle(
#     (x0, y_top - height),  # 左下角坐标 = (x, y_top - height)
#     width,
#     height,
#     facecolor='black',
#     edgecolor='black'
# )
# # 添加到坐标轴中
# ax.add_patch(rect)
# 显示横坐标单位
# ax.text(_xxx-1+0.5-3.3, -80, r'$\sqrt{t_0 + t}\ (\mathrm{min}^{0.5})$', fontsize=18, color='black')

print("显示的最小刻度:", min_tick_shown)
print((n_pos + 1) * step,custom_round_up(intercept)-20,"最大刻度：",max_tick)

from matplotlib.ticker import FixedLocator
# 限制次刻度线
minor_ticks = np.arange(min_tick_shown, max_tick, step / 2)
minor_ticks = [tick for tick in minor_ticks if tick not in yticks]  # 只保留非主刻度
ax.yaxis.set_minor_locator(FixedLocator(minor_ticks))
# 显示刻度线（可以根据需要设置样式）
# ax.tick_params(axis='y', which='both', direction='in', right=True)
ax.tick_params(axis='y', which='minor', length=3, color='black',direction='in')  # 小刻度样式
ax.tick_params(axis='y', which='major', length=6, color='black')  # 主刻度样式

# 限制次刻度线
minor_ticks = np.arange(0, _xxx-1, 0.5)
xticks = np.arange(0, _xxx-1, 1)
minor_ticks = [tick for tick in minor_ticks if tick not in xticks]  # 只保留非主刻度
ax.xaxis.set_minor_locator(FixedLocator(minor_ticks))
# 显示刻度线（可以根据需要设置样式）
# ax.tick_params(axis='y', which='both', direction='in', right=True)
ax.tick_params(axis='x', which='minor', length=3, color='black',direction='in')  # 小刻度样式
ax.tick_params(axis='x', which='major', length=6, color='black')  # 主刻度样式

# 保存图像到内存字节流
img_bytes = io.BytesIO()
plt.savefig(img_bytes, format='png', dpi=300, bbox_inches='tight')
img_bytes.seek(0)  # 将指针移回起始位置

import os
from io import BytesIO  # 如果 img_bytes 是 BytesIO 类型

# 获取当前用户的 AppData\Roaming 路径
appdata_roaming = os.getenv('APPDATA')

# 目标目录，假设放在你的程序名文件夹下的 Image 子目录
target_dir = os.path.join(appdata_roaming, "瓦斯含量测定数据分析系统", "Image")

# 确保目录存在
os.makedirs(target_dir, exist_ok=True)

# 目标文件路径
file_path = os.path.join(target_dir, "output_image.png")

# 写入文件
with open(file_path, 'wb') as f:
    f.write(img_bytes.read())


# 关闭图形释放内存
plt.close()

# 将拟合结果写入共享内存
import mmap
slope_mem_name = "Local\\tempSharedMemory"  # 共享内存名称
# 打包斜率和截距、R平方值(3个双精度浮点数)
slope_bytes = struct.pack('5d', slope, intercept, r_squared,0,555)  

# 创建内存映射并写入数据
with mmap.mmap(-1, len(slope_bytes), tagname=slope_mem_name, access=mmap.ACCESS_WRITE) as slope_mmap:
    slope_mmap.write(slope_bytes)
    
import sys
sys.exit(0)  # 退出Python程序，0表示正常退出
