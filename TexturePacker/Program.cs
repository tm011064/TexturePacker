using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TexturePacker
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      UserSettings userSettings = XmlSerializationHelper<UserSettings>.ConvertFromFile(UserSettings.FILE_PATH);
      if (userSettings == null)
        userSettings = new UserSettings();

      ApplicationContext.Instance.UserSettings = userSettings;

      Application.Run(new MainForm());
    }
  }
}
