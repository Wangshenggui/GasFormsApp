@echo off
chcp 65001 >nul
setlocal

set "SoftName=瓦斯含量测定数据分析系统"

set "InstallPath="

:: 遍历所有逻辑盘符
for %%D in (C D E F G H I J K L M N O P Q R S T U V W X Y Z) do (
    if exist "%%D:\Program Files\%SoftName%" (
        set "InstallPath=%%D:\Program Files\%SoftName%"
        goto :found
    )
    if exist "%%D:\Program Files (x86)\%SoftName%" (
        set "InstallPath=%%D:\Program Files (x86)\%SoftName%"
        goto :found
    )
)

echo 未找到软件目录
pause
exit /b

:found
echo 安装路径: "%InstallPath%"

:: Python 子目录
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

:: 源文件路径为 BAT 所在目录
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
