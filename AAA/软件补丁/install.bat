@echo off
chcp 65001 >nul
setlocal

set "SoftName=瓦斯含量测定数据分析系统"

:: 64 位 Program Files
set "Path1=%ProgramFiles%\%SoftName%"
:: 32 位 Program Files (x86)
set "Path2=%ProgramFiles(x86)%\%SoftName%"

:: 查找软件安装目录
if exist "%Path1%" (
    set "InstallPath=%Path1%"
) else if exist "%Path2%" (
    set "InstallPath=%Path2%"
) else (
    echo 未找到软件目录
    pause
    exit /b
)

echo 安装路径: "%InstallPath%"

:: 设置 Python 子目录
set "PythonDir=%InstallPath%\Python_embed\Python"

if not exist "%PythonDir%" (
    echo 未找到 "%PythonDir%" 目录
    pause
    exit /b
)

echo "%PythonDir%" 目录下的文件：
pushd "%PythonDir%"
dir /b
popd

:: 检查写权限
:: > "%PythonDir%\_write_test.txt" (
::     echo 测试写入
:: ) 2>nul || (
::     echo ERROR: 没有权限写入 "%PythonDir%"，请以管理员身份运行此 BAT
::     pause
::     exit /b
:: )

:: 设置源文件路径为 BAT 所在目录
set "SourceFile=%~dp0aaa.py"

if not exist "%SourceFile%" (
    echo BAT 同级目录未找到 "%SourceFile%" 文件
    pause
    exit /b
)

copy /Y "%SourceFile%" "%PythonDir%\aaa.py" >nul
if errorlevel 1 (
    echo 复制失败
    pause
    exit /b
)
pause
exit /b
