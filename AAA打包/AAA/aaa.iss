; 由 Inno Setup Script Wizard 生成的安装脚本
; 详细文档请查看官方文档以了解如何创建脚本文件！

#define MyAppName "瓦斯含量测定数据分析系统"                         ; 应用程序名称
#define MyAppVersion "1.5"                              ; 应用程序版本
#define MyAppPublisher "My Company, Inc."               ; 发布者名称
#define MyAppURL "https://www.example.com/"             ; 官方网址
#define MyAppExeName "瓦斯含量测定数据分析系统.exe"                  ; 主程序可执行文件名
#define MyAppAssocName MyAppName + " File"              ; 文件关联显示的名称
#define MyAppAssocExt ".myp"                            ; 文件关联的扩展名
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt  ; 注册表键名（去掉空格）

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{28694473-8D9D-4BF6-AA31-D88C8DDEF5BC}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only).
;PrivilegesRequired=lowest
OutputDir=C:\Users\17851\Desktop\0B工程\GasFormsApp\bin\Release\AAA
OutputBaseFilename=瓦斯含量测定数据分析系统
SolidCompression=yes
WizardStyle=modern
SetupIconFile=C:\Users\17851\Desktop\0B工程\GasFormsApp\Image\AppLog.ico

[Languages]
; 使用简体中文界面
Name: "chinesesimplified"; MessagesFile: "compiler:Languages\ChineseSimplified.isl"
    

[Tasks]
; 定义额外任务，这里是“创建桌面快捷方式”，默认不勾选
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

#define SrcRoot "C:\Users\17851\Desktop\0A打包"          ; 定义源文件根目录

[Files]
; 打包整个 SrcRoot 文件夹下的所有文件和子目录到安装目录
Source: "{#SrcRoot}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; 注意：不要对系统共享文件使用 "Flags: ignoreversion"

[Registry]
; 注册文件扩展名关联
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
; 注册扩展名的描述
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
; 设置默认图标
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
; 设置双击打开命令
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""

[Icons]
; 在开始菜单创建快捷方式
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
; 在桌面创建快捷方式（根据任务选择）
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
; 安装完成后运行主程序
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
