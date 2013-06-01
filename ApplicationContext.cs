using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TexturePacker
{
  public class ApplicationContext
  {
    public UserSettings UserSettings { get; set; }

    private static ApplicationContext _ApplicationContext;
    public static ApplicationContext Instance { get { return _ApplicationContext; } }
    static ApplicationContext()
    {
      _ApplicationContext = new ApplicationContext();
    }
  }
}
