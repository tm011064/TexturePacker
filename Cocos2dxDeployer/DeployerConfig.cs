using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Cocos2dxDeployer
{
  public class DeployerConfig
  {
    public string ClassesSourcePath{get;set;}
    public string ClassesDestinationPath{get;set;}
    public string AndroidMakePath{get;set;}
    public string ResourceFolderSourcePath{get;set;}
    public string ResourceFolderDestinationPath{get;set;}

    public string CygWinPath { get; set; }
    public string CygWinCommandArguments { get; set; }

    public DeployerConfig() { }
  }
}
