using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace TexturePacker
{
  public partial class PListControl : UserControl
  {
    private BindingList<PListDefinition> _PListDefinitions;
    private FileInfo _FileInfo;

    public PListControl()
      : this(new BindingList<PListDefinition>() { new PListDefinition("undefined") }, null, null)
    { }
    public PListControl(string tabKey)
      : this(new BindingList<PListDefinition>() { new PListDefinition("undefined") }, null, tabKey)
    { }
    public PListControl(BindingList<PListDefinition> pListDefinitions, FileInfo fileInfo, string tabKey)
    {
      InitializeComponent();

      _PListDefinitions = pListDefinitions;
      _FileInfo = fileInfo;

      this.TabKey = tabKey;

      gvDefinitions.DataSource = _PListDefinitions;
      gvDefinitions.MultiSelect = false;
      gvDefinitions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      gvDefinitions.CellValidating += new DataGridViewCellValidatingEventHandler(gvDefinitions_CellValidating);
      gvDefinitions.CellEndEdit += new DataGridViewCellEventHandler(gvDefinitions_CellEndEdit);
      gvDefinitions.CellValueChanged += new DataGridViewCellEventHandler(gvDefinitions_CellValueChanged);

      Refresh();
    }

    public event EventHandler<EventArgs> Saved;
    public event EventHandler<EventArgs> CloseRequest;
    public event EventHandler<DuplicateEventArgs> Duplicate;
    
    public string TabKey { get; set; }
    public FileInfo FileInfo { get { return this._FileInfo; } }
    public bool IsDirty { get; private set; }

    public void Update(IEnumerable<PListDefinition> definitions)
    {
      this._PListDefinitions.Clear();

      foreach (PListDefinition definition in definitions)
      {
        this._PListDefinitions.Add(definition);
      }
      RefreshIndexes();
    }

    private void RefreshIndexes()
    {
      int count = _PListDefinitions.Count;
      for (int i = 0; i < count; i++)
      {
        this._PListDefinitions[i].Index = i;
      }
    }

    void gvDefinitions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      this.IsDirty = true;
      Refresh();
    }

    private void Refresh()
    {
      StringBuilder sb = new StringBuilder();
      int maxX = int.MinValue;
      int maxY = int.MinValue;
      int val;
      foreach (PListDefinition pListDefinition in this._PListDefinitions)
      {
        sb.AppendLine(pListDefinition.GetPListNodeText());

        val = pListDefinition.GetMaximumDestinationX();
        if (val > maxX)
          maxX = val;

        val = pListDefinition.GetMaximumDestinationY();
        if (val > maxY)
          maxY = val;
      }

      this.txtPListOutput.Text = MagicStrings.PLIST_XML
                                             .Replace("<<OverallWidth>>", maxX.ToString())
                                             .Replace("<<OverallHeight>>", maxY.ToString())
                                             .Replace("<<Frames>>", sb.ToString());

      RefreshIndexes();
    }

    void gvDefinitions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      gvDefinitions.Rows[e.RowIndex].ErrorText = string.Empty;
      RefreshIndexes();
    }

    void gvDefinitions_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
      gvDefinitions.Rows[e.RowIndex].ErrorText = string.Empty;

      switch (gvDefinitions.Columns[e.ColumnIndex].DataPropertyName)
      {
        case "OriginX":
        case "OriginY":
        case "DestinationX":
        case "DestinationY":
        case "TotalHorizontalRepeats":
        case "TotalVerticalRepeats":
          int temp = 0;
          if (!int.TryParse(gvDefinitions[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString(), out temp))
          {
            e.Cancel = true;
            gvDefinitions.Rows[e.RowIndex].ErrorText = gvDefinitions.Columns[e.ColumnIndex].DataPropertyName + " value must be a non-negative integer";
          }
          break;
      }
    }

    public bool Save()
    {
      string errorMessage;
      if (_FileInfo == null)
      {
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
          DirectoryInfo directoryInfo = new DirectoryInfo(MagicStrings.DFAULT_PATH);
          if (!directoryInfo.Exists)
            directoryInfo.Create();

          saveFileDialog.InitialDirectory = directoryInfo.FullName;
          saveFileDialog.AddExtension = true;
          saveFileDialog.DefaultExt = ".tpd";
          saveFileDialog.Filter = "Texture Packer Definition (*.tpd)|*.tpd";
          saveFileDialog.OverwritePrompt = true;

          switch (saveFileDialog.ShowDialog())
          {
            case DialogResult.OK:

              FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
              if (!XmlSerializationHelper<BindingList<PListDefinition>>.SaveAsXmlFile(_PListDefinitions, fileInfo.FullName, out errorMessage))
              {
                MessageBox.Show("Unable to save file. Error: " + errorMessage);
              }
              else
              {
                _FileInfo = fileInfo;
                this.IsDirty = false;

                if (Saved != null)
                  this.Saved(this, EventArgs.Empty);

                return true;
              }

              break;
          }
        }
      }
      else
      {
        if (!XmlSerializationHelper<BindingList<PListDefinition>>.SaveAsXmlFile(_PListDefinitions, _FileInfo.FullName, out errorMessage))
        {
          MessageBox.Show("Unable to save file. Error: " + errorMessage);
        }
        else
        {
          if (Saved != null)
            this.Saved(this, EventArgs.Empty);

          return true;
        }
      }

      return false;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      Save();
    }


    private void btnDuplicate_Click(object sender, EventArgs e)
    {
      using (DuplicateDialog duplicateDialog = new DuplicateDialog())
      {
        switch (duplicateDialog.ShowDialog())
        {
          case DialogResult.OK:

            List<DuplicateEventArgsInfo> duplicateEventArgsInfos = new List<DuplicateEventArgsInfo>();
            BindingList<PListDefinition> definitions;
            foreach (DuplicationInfo duplicationInfo in duplicateDialog.GetDuplicationInfos())
            {
              definitions = new BindingList<PListDefinition>();
              foreach (PListDefinition record in this._PListDefinitions)
              {
                definitions.Add(record.Scale(duplicationInfo.Scale));
              }
              duplicateEventArgsInfos.Add(new DuplicateEventArgsInfo(duplicationInfo.FileInfo, definitions));
            }

            if (this.Duplicate != null)
              this.Duplicate(this, new DuplicateEventArgs(duplicateEventArgsInfos));

            break;
        }
      }
    }

    private void btnAddDefinition_Click(object sender, EventArgs e)
    {
      _PListDefinitions.Add(new PListDefinition("undefined"));
      RefreshIndexes();
    }

    private void btnCopyToClipboard_Click(object sender, EventArgs e)
    {
      Refresh();
      Clipboard.SetText(txtPListOutput.Text);
    }

    private void btnDeleteDefinition_Click(object sender, EventArgs e)
    {
      var row = gvDefinitions.CurrentRow;
      if (row != null)
      {
        if (!row.IsNewRow)
        {
          gvDefinitions.Rows.Remove(row);
        }
      }
    }

    private void btnUp_Click(object sender, EventArgs e)
    {
      var row = gvDefinitions.CurrentRow;
      if (row != null
          && row.Index > 0)
      {
        int index = row.Index;
        PListDefinition value = _PListDefinitions[index];
        _PListDefinitions.Remove(value);
        _PListDefinitions.Insert(index - 1, value);

        gvDefinitions.CurrentRow.Selected = false;
        gvDefinitions.CurrentCell = gvDefinitions.Rows[index - 1].Cells[0];
        gvDefinitions.Rows[index - 1].Selected = true;

        Refresh();
      }
    }

    private void btnDown_Click(object sender, EventArgs e)
    {
      var row = gvDefinitions.CurrentRow;
      if (row != null
          && row.Index < gvDefinitions.Rows.Count - 2)
      {
        int index = row.Index;
        PListDefinition value = _PListDefinitions[row.Index];
        _PListDefinitions.Remove(value);
        _PListDefinitions.Insert(index + 1, value);

        gvDefinitions.CurrentRow.Selected = false;
        gvDefinitions.CurrentCell = gvDefinitions.Rows[index + 1].Cells[0];
        gvDefinitions.Rows[index + 1].Selected = true;

        Refresh();
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (CloseRequest != null)
        CloseRequest(this, EventArgs.Empty);
    }

  }

  public class DuplicateEventArgsInfo
  {
    public FileInfo FileInfo { get; set; }
    public BindingList<PListDefinition> Definitions { get; set; }

    public DuplicateEventArgsInfo(FileInfo fileInfo, BindingList<PListDefinition> definitions)
    {
      this.FileInfo = fileInfo;
      this.Definitions = definitions;
    }
  }

  public class DuplicateEventArgs : EventArgs
  {
    public List<DuplicateEventArgsInfo> DuplicateEventArgsInfos { get; private set; }

    public DuplicateEventArgs(List<DuplicateEventArgsInfo> duplicateEventArgsInfos)
    {
      this.DuplicateEventArgsInfos = duplicateEventArgsInfos;
    }
  }
}
