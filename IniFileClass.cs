using System.Runtime.InteropServices;
using System.Text;

public class IniFile
{
    public string Path;

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    public IniFile(string path)
    {
        Path = path;
    }

    public void Write(string section, string key, string value)
    {
        WritePrivateProfileString(section, key, value, Path);
    }

    public string Read(string section, string key, string defaultValue = "")
    {
        StringBuilder temp = new StringBuilder(255);
        GetPrivateProfileString(section, key, defaultValue, temp, 255, Path);
        return temp.ToString();
    }
}
