using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace TexturePacker
{
  public partial class DuplicateDialog : Form
  {
    private BindingList<DuplicationInfo> _DuplicationInfos;

    public IEnumerable<DuplicationInfo> GetDuplicationInfos()
    {
      string rootPath = txtRootFolder.Text.TrimEnd('\\') + @"\";
      string filePath;
      foreach (DuplicationInfo duplicationInfo in _DuplicationInfos)
      {
        if (string.IsNullOrWhiteSpace(duplicationInfo.RelativeFilePath.Trim()))
        {
          continue;
        }

        filePath = duplicationInfo.RelativeFilePath
                                  .Replace("/", @"\")
                                  .TrimStart('\\');
        if (!filePath.EndsWith(".tpd"))
          filePath += ".tpd";

        yield return new DuplicationInfo()
        {
          FileInfo = new FileInfo(rootPath + filePath),
          RelativeFilePath = duplicationInfo.RelativeFilePath,
          Scale = duplicationInfo.Scale
        };
      }
    }

    public DuplicateDialog()
    {
      InitializeComponent();

      UserSettings userSettings = ApplicationContext.Instance.UserSettings;
      _DuplicationInfos = new BindingList<DuplicationInfo>(userSettings.DuplicationInfos);
      txtRootFolder.Text = userSettings.DuplicateFolderPath;

      gvDuplicationInfo.DataSource = _DuplicationInfos;
      gvDuplicationInfo.AutoGenerateColumns = false;
      gvDuplicationInfo.MultiSelect = false;
      gvDuplicationInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      gvDuplicationInfo.CellValidating += new DataGridViewCellValidatingEventHandler(gvDuplicationInfo_CellValidating);
      gvDuplicationInfo.CellEndEdit += new DataGridViewCellEventHandler(gvDuplicationInfo_CellEndEdit);
    }

    void gvDuplicationInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      gvDuplicationInfo.Rows[e.RowIndex].ErrorText = string.Empty;
    }

    void gvDuplicationInfo_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
      gvDuplicationInfo.Rows[e.RowIndex].ErrorText = string.Empty;

      switch (gvDuplicationInfo.Columns[e.ColumnIndex].DataPropertyName)
      {
        case "Scale":
          float temp = 0;
          if (!float.TryParse(gvDuplicationInfo[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString(), out temp))
          {
            e.Cancel = true;
            gvDuplicationInfo.Rows[e.RowIndex].ErrorText = gvDuplicationInfo.Columns[e.ColumnIndex].DataPropertyName + " value must be a non-negative integer";
          }
          break;
      }
    }

    private void btnDuplicate_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(txtRootFolder.Text.Trim()))
      {
        MessageBox.Show("Please select a file name");
      }
      else
      {
        ApplicationContext.Instance.UserSettings.DuplicationInfos = new List<DuplicationInfo>(this.GetDuplicationInfos());
        ApplicationContext.Instance.UserSettings.DuplicateFolderPath = txtRootFolder.Text.Trim();
        ApplicationContext.Instance.UserSettings.Save();

        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void btnBrowseDirectory_Click(object sender, EventArgs e)
    {
      using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
      {
        folderBrowserDialog.ShowNewFolderButton = true;
        switch (folderBrowserDialog.ShowDialog())
        {
          case System.Windows.Forms.DialogResult.OK:
            txtRootFolder.Text = folderBrowserDialog.SelectedPath;
            break;
        }
      }
    }
  }


  public class DuplicationInfo
  {
    [XmlIgnore]
    public FileInfo FileInfo { get; set; }

    public string RelativeFilePath { get; set; }
    public float Scale { get; set; }
  }
}
