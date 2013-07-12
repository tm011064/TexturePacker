using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Cocos2dxDeployer
{
  class Program
  {
    #region template
    const string ANDROID_MAKE_FILE =
@"LOCAL_PATH := $(call my-dir)

include $(CLEAR_VARS)

LOCAL_MODULE := game_shared

LOCAL_MODULE_FILENAME := libgame

LOCAL_SRC_FILES := hellocpp/main.cpp \
{0}                    					 
				   
LOCAL_C_INCLUDES := $(LOCAL_PATH)/../../Classes                   

LOCAL_WHOLE_STATIC_LIBRARIES := cocos2dx_static cocosdenshion_static cocos_extension_static
            
include $(BUILD_SHARED_LIBRARY)

$(call import-module,CocosDenshion/android) \
$(call import-module,cocos2dx) \
$(call import-module,extensions)
";
    #endregion

    static void Main(string[] args)
    {
      Random random = new Random();
      RandomStringGenerator randomStringGenerator = new RandomStringGenerator();
      while (Console.ReadKey().Key != ConsoleKey.Enter)
      {
        Console.Clear();
        foreach (string s in randomStringGenerator.GenerateRandomString(10, 4, 6, .45))
          Console.WriteLine(s);
      }
      return;

      UpdateAndroidMakeFile(
        @"C:\GIT\android\cocos2d-2.1beta3-x-2.1.1\cocos2d-2.1beta3-x-2.1.1\Mulongo\proj.win32\"
        , @"C:\GIT\android\cocos2d-2.1beta3-x-2.1.1\cocos2d-2.1beta3-x-2.1.1\MulongoProject\Classes\"
        , @"C:\GIT\android\cocos2d-2.1beta3-x-2.1.1\cocos2d-2.1beta3-x-2.1.1\MulongoProject\proj.android\jni\Android.mk"
        , @"C:\GIT\android\cocos2d-2.1beta3-x-2.1.1\cocos2d-2.1beta3-x-2.1.1\Mulongo\Resources\"
        , @"C:\GIT\android\cocos2d-2.1beta3-x-2.1.1\cocos2d-2.1beta3-x-2.1.1\MulongoProject\Resources\");

      Console.WriteLine("\nALL DONE :)");

      Console.ReadLine();
    }

    static void UpdateAndroidMakeFile(string classesSourcePath, string classesDestinationPath, string androidMakePath
      , string resourceFolderSourcePath, string resourceFolderDestinationPath)
    {
      DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(classesSourcePath);
      DirectoryInfo destinationDirectoryInfo = new DirectoryInfo(classesDestinationPath);

      Dictionary<string, FileInfo> sourceFileInfos = new Dictionary<string, FileInfo>();
      Dictionary<string, FileInfo> destinationFileInfos = new Dictionary<string, FileInfo>();

      if (sourceDirectoryInfo.Exists)
      {
        foreach (FileInfo fileInfo in sourceDirectoryInfo.GetFiles("*.cpp"))
          sourceFileInfos[fileInfo.Name] = fileInfo;
        foreach (FileInfo fileInfo in sourceDirectoryInfo.GetFiles("*.h"))
          sourceFileInfos[fileInfo.Name] = fileInfo;
      }
      if (destinationDirectoryInfo.Exists)
      {
        foreach (FileInfo fileInfo in destinationDirectoryInfo.GetFiles())
          destinationFileInfos[fileInfo.Name] = fileInfo;
      }

      #region resources
      //Now Create all of the directories
      foreach (string dirPath in Directory.GetDirectories(resourceFolderSourcePath, "*",
          SearchOption.AllDirectories))
        Directory.CreateDirectory(dirPath.Replace(resourceFolderSourcePath, resourceFolderDestinationPath));

      //Copy all the files
      foreach (string newPath in Directory.GetFiles(resourceFolderSourcePath, "*.*",
          SearchOption.AllDirectories))
        File.Copy(newPath, newPath.Replace(resourceFolderSourcePath, resourceFolderDestinationPath), true);
      #endregion


      StringBuilder sb = new StringBuilder();
      FileInfo fi;
      foreach (var kvp in sourceFileInfos)
      {
        if (kvp.Key == "main.cpp"
            || kvp.Key == "main.h")
          continue;

        if (kvp.Value.Extension == ".cpp")
          sb.AppendLine("../../Classes/" + kvp.Value.Name + " \\");

        if (!destinationFileInfos.ContainsKey(kvp.Key))
        {
          // copy file over
          File.Copy(kvp.Value.FullName, destinationDirectoryInfo.FullName.TrimEnd('\\') + @"\" + kvp.Key);
          Console.WriteLine("Copying " + kvp.Key);
        }
        else
        {
          fi = destinationFileInfos[kvp.Key];
          if (fi.LastWriteTimeUtc != kvp.Value.LastWriteTimeUtc)
          {
            // copy over
            File.Copy(kvp.Value.FullName, destinationDirectoryInfo.FullName.TrimEnd('\\') + @"\" + kvp.Key, true);
            Console.WriteLine("Copying " + kvp.Key);
          }
        }
      }

      string makeContent = string.Format(ANDROID_MAKE_FILE, sb.ToString().Trim(Environment.NewLine.ToCharArray()));
      string currentContent = File.ReadAllText(androidMakePath);

      if (makeContent != currentContent)
      {
        File.WriteAllText(androidMakePath, makeContent);
        Console.WriteLine("Overwriting Android make file");
      }
    }
  }
}
