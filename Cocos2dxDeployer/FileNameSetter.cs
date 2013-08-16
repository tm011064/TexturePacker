using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Cocos2dxDeployer
{
  static class FileNameSetter
  {
    public static void RenameFilesInFolderStructure(string rootPath)
    {
      DoRename(new DirectoryInfo(rootPath));
    }

    private static string GetIntString(int totalDigits, int number)
    {
      StringBuilder sb = new StringBuilder(number.ToString());
      while (sb.Length < totalDigits)
      {
        sb.Insert(0, "0");
      }
      return sb.ToString();
    }

    private static void DoRename(DirectoryInfo directoryInfo)
    {
      if (directoryInfo == null
          || !directoryInfo.Exists)
        return;

      int counter = 1;
      foreach (FileInfo fileInfo in directoryInfo.GetFiles().OrderBy(c => c.CreationTime))
      {
        string s = directoryInfo.FullName + "\\" + directoryInfo.Name + "_" + GetIntString(4, counter) + fileInfo.Extension;
        fileInfo.MoveTo(s);
        counter++;
      }

      foreach (DirectoryInfo d in directoryInfo.GetDirectories())
        DoRename(d);
    }
  }
}
