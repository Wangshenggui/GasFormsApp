@chcp 65001 >nul
@echo off
echo 正在打包 aaa.py 为单文件并.exe可执行文件...

REM 确保当前目录包含 aaa.py
pyinstaller --onefile --noconsole aaa.py

echo.
echo 打包完成！生成文件在 dist\aaa.exe
pause
