using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Cocos2dxDeployer
{
  class Program
  {
    static void GenerateRandomStrings()
    {
      Random random = new Random();
      RandomStringGenerator randomStringGenerator = new RandomStringGenerator();
      while (Console.ReadKey().Key != ConsoleKey.Enter)
      {
        Console.Clear();
        foreach (string s in randomStringGenerator.GenerateRandomString(10, 4, 6, .45))
          Console.WriteLine(s);
      }
    }
    static void DeployCocosFiles(DeployerConfig deployerConfig)
    {
      FileDeployer.UpdateAndroidMakeFile(
        deployerConfig.ClassesSourcePath, deployerConfig.ClassesDestinationPath, deployerConfig.AndroidMakePath
      , deployerConfig.ResourceFolderSourcePath, deployerConfig.ResourceFolderDestinationPath);

      Console.WriteLine("\nFILES COPIED, CLOSE THE CYGWIN CONSOLE TO EXIT :)");

      Process process = StartCygWinProcess(deployerConfig.CygWinPath, deployerConfig.CygWinCommandArguments);
      process.WaitForExit();
    }

    static Process StartCygWinProcess(string filePath, string args)
    {
      ProcessStartInfo startInfo = new ProcessStartInfo();
      startInfo.CreateNoWindow = false;
      startInfo.UseShellExecute = false;
      startInfo.FileName = filePath;
      startInfo.WindowStyle = ProcessWindowStyle.Hidden;
      startInfo.Arguments = args;

      return Process.Start(startInfo);
    }

    static void Main(string[] args)
    {
      string configPath = null;
      if (args != null)
      {
        string[] splitted;
        foreach (string s in args)
        {
          splitted = s.Split('=');
          if (splitted.Length == 2 && splitted[0].Trim() == "config")
          {
            configPath = splitted[1].Trim();
          }
        }
      }

      DeployerConfig deployerConfig = null;
      if (!string.IsNullOrWhiteSpace(configPath))
      {
        XmlSerializer x = new XmlSerializer(typeof(DeployerConfig));
        try
        {
          using (FileStream fs = File.OpenRead(@"c:\temp\deployerConfig.xml"))
          {
            deployerConfig = (DeployerConfig)x.Deserialize(fs);
          }
        }
        catch (Exception err)
        {
          Console.WriteLine(err.Message);
          Console.ReadKey();
          return;
        }
      }
      else
      {
        deployerConfig = new DeployerConfig();
        deployerConfig.AndroidMakePath = @"C:\GIT\android\cocos2d-2.1beta3-x-2.1.1\cocos2d-2.1beta3-x-2.1.1\MulongoProject\proj.android\jni\Android.mk";
        deployerConfig.ClassesDestinationPath = @"C:\GIT\android\cocos2d-2.1beta3-x-2.1.1\cocos2d-2.1beta3-x-2.1.1\MulongoProject\Classes\";
        deployerConfig.ClassesSourcePath = @"C:\GIT\android\cocos2d-2.1beta3-x-2.1.1\cocos2d-2.1beta3-x-2.1.1\Mulongo\proj.win32\";
        deployerConfig.CygWinCommandArguments = "-i /Cygwin-Terminal.ico -";
        deployerConfig.CygWinPath = @"c:\cygwin\bin\mintty.exe";
        deployerConfig.ResourceFolderDestinationPath = @"C:\GIT\android\cocos2d-2.1beta3-x-2.1.1\cocos2d-2.1beta3-x-2.1.1\MulongoProject\Resources\";
        deployerConfig.ResourceFolderSourcePath = @"C:\GIT\android\cocos2d-2.1beta3-x-2.1.1\cocos2d-2.1beta3-x-2.1.1\Mulongo\Resources\";
      }

      DeployCocosFiles(deployerConfig);
      //FileNameSetter.RenameFilesInFolderStructure(@"C:\Users\Roman\Music\Sound Effects");
    }
  }
}
