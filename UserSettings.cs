using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TexturePacker
{
  public class UserSettings
  {
    public List<DuplicationInfo> DuplicationInfos { get; set; }
    public List<string> TabFiles { get; set; }
    public string OpenedTabKey { get; set; }
    public string DuplicateFolderPath { get; set; }

    public static string USERSETTINGS_PATH;
    public static string FILE_PATH;

    static UserSettings()
    {
      USERSETTINGS_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\TexturePacker";
      FILE_PATH = USERSETTINGS_PATH + @"\usersettings.xml";
    }

    public void Save()
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(USERSETTINGS_PATH);
      if (!directoryInfo.Exists)
        directoryInfo.Create();

      XmlSerializationHelper<UserSettings>.SaveAsXmlFile(this, FILE_PATH);
    }

    public UserSettings()
    {
      this.DuplicationInfos = new List<DuplicationInfo>();
      this.TabFiles = new List<string>();
    }
  }
}
