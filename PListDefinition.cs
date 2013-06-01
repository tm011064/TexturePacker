using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TexturePacker
{
  [Serializable]
  [XmlRoot(ElementName = "plistDefinition")]
  public class PListDefinition
  {
    private int _Index;
    public int Index
    {
      get { return _Index; }
      set
      {
        if (_Index != value)
        {
          _Index = value;
          Refresh();
        }
      }
    }

    private string _Name;
    public string Name
    {
      get { return _Name; }
      set
      {
        if (_Name != value)
        {
          _Name = value;
          Refresh();
        }
      }
    }

    private int _OriginX;
    public int OriginX
    {
      get { return _OriginX; }
      set
      {
        if (_OriginX != value)
        {
          _OriginX = value;
          Refresh();
        }
      }
    }
    private int _OriginY;
    public int OriginY
    {
      get { return _OriginY; }
      set
      {
        if (_OriginY != value)
        {
          _OriginY = value;
          Refresh();
        }
      }
    }
    private int _DestinationX;
    public int DestinationX
    {
      get { return _DestinationX; }
      set
      {
        if (_DestinationX != value)
        {
          _DestinationX = value;
          Refresh();
        }
      }
    }
    private int _DestinationY;
    public int DestinationY
    {
      get { return _DestinationY; }
      set
      {
        if (_DestinationY != value)
        {
          _DestinationY = value;
          Refresh();
        }
      }
    }
    private int _TotalHorizontalRepeats;
    public int TotalHorizontalRepeats
    {
      get { return _TotalHorizontalRepeats; }
      set
      {
        if (_TotalHorizontalRepeats != value)
        {
          _TotalHorizontalRepeats = value;
          Refresh();
        }
      }
    }
    private int _TotalVerticalRepeats;
    public int TotalVerticalRepeats
    {
      get { return _TotalVerticalRepeats; }
      set
      {
        if (_TotalVerticalRepeats != value)
        {
          _TotalVerticalRepeats = value;
          Refresh();
        }
      }
    }
    private bool _Rotate;
    public bool Rotate
    {
      get { return _Rotate; }
      set
      {
        if (_Rotate != value)
        {
          _Rotate = value;
          Refresh();
        }
      }
    }

    #region public methods
    public PListDefinition Scale(float scale)
    {
      PListDefinition pListDefinition = new PListDefinition(this.Name);
      
      pListDefinition.DestinationX = (int)Math.Round((float)this.DestinationX * scale, MidpointRounding.AwayFromZero);
      pListDefinition.DestinationY = (int)Math.Round((float)this.DestinationY * scale, MidpointRounding.AwayFromZero);
      pListDefinition.OriginX = (int)Math.Round((float)this.OriginX * scale, MidpointRounding.AwayFromZero);
      pListDefinition.OriginY = (int)Math.Round((float)this.OriginY * scale, MidpointRounding.AwayFromZero);
      pListDefinition.Rotate = this.Rotate;
      pListDefinition.TotalHorizontalRepeats = this.TotalHorizontalRepeats;
      pListDefinition.TotalVerticalRepeats = this.TotalVerticalRepeats;

      return pListDefinition;
    }

    public int GetMaximumDestinationX()
    {
      return this.TotalHorizontalRepeats > 1
        ? (this.TotalHorizontalRepeats * (this.DestinationX - this.OriginX)) + this.OriginX
        : this.DestinationX;
    }
    public int GetMaximumDestinationY()
    {
      return this.TotalVerticalRepeats > 1
        ? (this.TotalVerticalRepeats * (this.DestinationY - this.OriginY)) + this.OriginY
        : this.DestinationY;
    }

    public string GetPListNodeText()
    {
      StringBuilder frames = new StringBuilder();

      if (this.TotalHorizontalRepeats <= 1
          && this.TotalVerticalRepeats <= 1)
      {
        return MagicStrings.PLIST_ITEM_XML
          .Replace("<<frameName>>", this.Name ?? "undefined")
          .Replace("<<x>>", this.OriginX.ToString())
          .Replace("<<y>>", this.OriginY.ToString())
          .Replace("<<width>>", (this.DestinationX - this.OriginX).ToString())
          .Replace("<<height>>", (this.DestinationY - this.OriginY).ToString())
          .Replace("<<offsetX>>", "0")
          .Replace("<<offsetY>>", "0")
          .Replace("<<originalWidth>>", (this.DestinationX - this.OriginX).ToString())
          .Replace("<<originalHeight>>", "-" + (this.DestinationY - this.OriginY).ToString())
          .Replace("<<rotate>>", this.Rotate ? "true" : "false");
      }
      else
      {
        StringBuilder sb = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        string numberFormat;

        for (int i = 0; i < this.TotalHorizontalRepeats.ToString().Length; i++)
          sb2.Append("0");
        numberFormat = sb2.ToString();

        for (int i = 0; i < this.TotalHorizontalRepeats; i++)
        {
          sb.AppendLine(MagicStrings.PLIST_ITEM_XML
          .Replace("<<frameName>>", (this.Name ?? "undefined") + "_" + i.ToString(numberFormat))
          .Replace("<<x>>", (this.OriginX + ((this.DestinationX - this.OriginX) * i)).ToString())
          .Replace("<<y>>", this.OriginY.ToString())
          .Replace("<<width>>", (this.DestinationX - this.OriginX).ToString())
          .Replace("<<height>>", (this.DestinationY - this.OriginY).ToString())
          .Replace("<<offsetX>>", "0")
          .Replace("<<offsetY>>", "0")
          .Replace("<<originalWidth>>", (this.DestinationX - this.OriginX).ToString())
          .Replace("<<originalHeight>>", "-" + (this.DestinationY - this.OriginY).ToString())
          .Replace("<<rotate>>", this.Rotate ? "true" : "false"));
        }

        sb2 = sb2.Clear();
        for (int i = 0; i < this.TotalVerticalRepeats.ToString().Length; i++)
          sb2.Append("0");
        numberFormat = sb2.ToString();

        for (int i = 0; i < this.TotalVerticalRepeats; i++)
        {
          sb.AppendLine(MagicStrings.PLIST_ITEM_XML
          .Replace("<<frameName>>", (this.Name ?? "undefined") + "_" + i.ToString(numberFormat))
          .Replace("<<x>>", this.OriginX.ToString())
          .Replace("<<x>>", (this.OriginY + ((this.DestinationY - this.OriginY) * i)).ToString())
          .Replace("<<width>>", (this.DestinationX - this.OriginX).ToString())
          .Replace("<<height>>", (this.DestinationY - this.OriginY).ToString())
          .Replace("<<offsetX>>", "0")
          .Replace("<<offsetY>>", "0")
          .Replace("<<originalWidth>>", (this.DestinationX - this.OriginX).ToString())
          .Replace("<<originalHeight>>", "-" + (this.DestinationY - this.OriginY).ToString())
          .Replace("<<rotate>>", this.Rotate ? "true" : "false"));
        }

        return sb.ToString().Trim(Environment.NewLine.ToCharArray());
      }
    }
    #endregion

    private void Refresh()
    {

    }

    public PListDefinition() { }
    public PListDefinition(string name)
    {
      this.Name = name;
    }
  }
}
