using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TexturePacker
{
  public static class MagicStrings
  {
    public const string PLIST_XML =
@"<?xml version=""1.0"" encoding=""UTF-8""?>
<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">
<plist version=""1.0"">
<dict>
  <key>texture</key>
  <dict>
    <key>width</key>
    <integer><<OverallWidth>></integer>
    <key>height</key>
    <integer><<OverallHeight>></integer>
  </dict>
  <key>frames</key>
  <dict>
<<Frames>>  </dict>
</dict>
</plist>
";
    public const string PLIST_ITEM_XML =
@"    <key><<frameName>></key>
    <dict>
      <key>x</key>
      <integer><<x>></integer>
      <key>y</key>
      <integer><<y>></integer>
      <key>width</key>
      <integer><<width>></integer>
      <key>height</key>
      <integer><<height>></integer>
      <key>offsetX</key>
      <real><<offsetX>></real>
      <key>offsetY</key>
      <real><<offsetY>></real>
      <key>originalWidth</key>
      <integer><<originalWidth>></integer>
      <key>originalHeight</key>
      <integer><<originalHeight>></integer>
      <key>rotate</key>
      <<<rotate>> />
    </dict>";

    public static string DFAULT_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\TexturePacker";
  }
}
