import ctypes
from ctypes import wintypes
import struct
import time

PAGE_READWRITE = 0x04
FILE_MAP_READ = 0x0004
INVALID_HANDLE_VALUE = -1

kernel32 = ctypes.WinDLL('kernel32', use_last_error=True)

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

def main():
    map_name = "Local\\MySharedMemory"
    rows, cols = 5, 2
    size = rows * cols * 8  # double的字节数

    hMap = None
    print("[Python] 尝试打开共享内存...")
    for attempt in range(10):
        hMap = OpenFileMapping(FILE_MAP_READ, False, map_name)
        if hMap:
            print(f"[Python] 成功打开共享内存（尝试次数: {attempt + 1}）")
            break
        print(f"[Python] 共享内存未创建，等待 1 秒后重试...")
        time.sleep(1)

    if not hMap:
        print("[Python] 打开共享内存失败，退出")
        return

    pBuf = MapViewOfFile(hMap, FILE_MAP_READ, 0, 0, size)
    if not pBuf:
        CloseHandle(hMap)
        raise ctypes.WinError(ctypes.get_last_error())

    buffer_type = ctypes.c_char * size
    buffer = buffer_type.from_address(pBuf)

    read_bytes = bytes(buffer[:])
    values = struct.unpack('d' * rows * cols, read_bytes)
    matrix = [values[i*cols:(i+1)*cols] for i in range(rows)]

    for i, row in enumerate(matrix, 1):
        print(f"[Python] 读取第{i}行: {row}")

    UnmapViewOfFile(pBuf)
    CloseHandle(hMap)
    print("[Python] 共享内存已关闭")

if __name__ == "__main__":
    main()
