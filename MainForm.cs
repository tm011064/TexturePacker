using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TexturePacker
{
  public partial class MainForm : Form
  {
    TabControl _TabControl;
    Dictionary<string, TabPage> _TabPages;
    private int _NewTabPageCounter = 0;

    public MainForm()
    {
      InitializeComponent();

      _TabControl = new TabControl();
      _TabControl.Dock = DockStyle.Fill;
      _TabControl.SelectedIndexChanged += new EventHandler(_TabControl_SelectedIndexChanged);

      _TabPages = new Dictionary<string, TabPage>();

      panMain.Controls.Add(_TabControl);

      UserSettings userSettings = ApplicationContext.Instance.UserSettings;
      if (userSettings.TabFiles.Count > 0)
      {
        foreach (string fileName in userSettings.TabFiles)
        {
          LoadTabPage(new FileInfo(fileName));
        }
        if (_TabPages.ContainsKey(userSettings.OpenedTabKey))
          _TabControl.SelectedTab = _TabPages[userSettings.OpenedTabKey];
      }
      else
      {
        AddNewTabPage();
      }
    }

    private void SaveUserSettings()
    {
      ApplicationContext.Instance.UserSettings.TabFiles = new List<string>(from c in _TabPages.Keys
                                                                           where File.Exists(c)
                                                                           select c);
      ApplicationContext.Instance.UserSettings.OpenedTabKey = (from c in _TabPages
                                                               where c.Value == _TabControl.SelectedTab
                                                               select c.Key).FirstOrDefault();
      ApplicationContext.Instance.UserSettings.Save();
    }

    void _TabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
      SaveUserSettings();
    }

    private void AddNewTabPage()
    {
      TabPage tabPage;

      _NewTabPageCounter++;
      string header = "new " + _NewTabPageCounter;
      string tabKey = "_" + header;
      tabPage = new TabPage(header);

      PListControl control = new PListControl(tabKey);
      control.Dock = DockStyle.Fill;

      control.Saved += new EventHandler<EventArgs>(control_Saved);
      control.Duplicate += new EventHandler<DuplicateEventArgs>(control_Duplicate);
      control.CloseRequest += new EventHandler<EventArgs>(control_CloseRequest);

      tabPage.Controls.Add(control);

      _TabPages.Add(tabKey, tabPage);

      _TabControl.TabPages.Add(tabPage);
      _TabControl.SelectedTab = tabPage;

      SaveUserSettings();
    }
    private void LoadTabPage(FileInfo fileInfo)
    {
      if (_TabPages.ContainsKey(fileInfo.FullName))
      {
        BindingList<PListDefinition> list = XmlSerializationHelper<BindingList<PListDefinition>>.ConvertFromFile(fileInfo.FullName);
        if (list != null)
        {
          PListControl control = _TabControl.SelectedTab.Controls[0] as PListControl;
          if (control != null)
          {
            control.Update(list);
          }
        }
        else
        {
          MessageBox.Show("Unable to load definition file " + fileInfo.FullName + ".", "Load Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        _TabControl.SelectedTab = _TabPages[fileInfo.FullName];
        return;
      }
      else
      {
        BindingList<PListDefinition> list = XmlSerializationHelper<BindingList<PListDefinition>>.ConvertFromFile(fileInfo.FullName);
        if (list != null)
        {
          TabPage tabPage = new TabPage(fileInfo.Name);
          PListControl control = new PListControl(list, fileInfo, fileInfo.FullName);
          control.Dock = DockStyle.Fill;

          control.Saved += new EventHandler<EventArgs>(control_Saved);
          control.Duplicate += new EventHandler<DuplicateEventArgs>(control_Duplicate);
          control.CloseRequest += new EventHandler<EventArgs>(control_CloseRequest);

          tabPage.Controls.Add(control);

          _TabPages.Add(fileInfo.FullName, tabPage);

          _TabControl.TabPages.Add(tabPage);
          _TabControl.SelectedTab = tabPage;

          SaveUserSettings();
        }
        else
        {
          MessageBox.Show("Unable to load definition file " + fileInfo.FullName + ".", "Load Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
    }

    void control_CloseRequest(object sender, EventArgs e)
    {
      PListControl control = sender as PListControl;
      if (control != null)
      {
        if (!File.Exists(control.TabKey)
            || control.IsDirty)
        {
          switch (MessageBox.Show("Do you want to save changes?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
          {
            case System.Windows.Forms.DialogResult.Yes:
              if (control.Save())
              {
                CloseTab(control);
              }
              break;

            case System.Windows.Forms.DialogResult.No:
              CloseTab(control);
              break;
          }
        }
        else
        {
          CloseTab(control);
        }
      }
    }

    private void CloseTab(PListControl control)
    {
      _TabControl.TabPages.Remove(_TabPages[control.TabKey]);
      _TabPages.Remove(control.TabKey);

      control.Dispose();
    }

    void control_Duplicate(object sender, DuplicateEventArgs e)
    {
      string errorMessage;
      foreach (DuplicateEventArgsInfo record in e.DuplicateEventArgsInfos)
      {
        if (!record.FileInfo.Directory.Exists)
          record.FileInfo.Directory.Create();

        if (!XmlSerializationHelper<BindingList<PListDefinition>>.SaveAsXmlFile(record.Definitions, record.FileInfo.FullName, out errorMessage))
        {
          MessageBox.Show("Unable to save " + record.FileInfo.FullName);
        }
        else
        {
          this.LoadTabPage(record.FileInfo);
        }
      }
    }

    void control_Saved(object sender, EventArgs e)
    {
      PListControl control = sender as PListControl;
      if (control != null)
      {
        if (control.TabKey != control.FileInfo.FullName)
        {// new item
          if (_TabPages.ContainsKey(control.FileInfo.FullName))
          {
            _TabControl.TabPages.Remove(_TabPages[control.TabKey]);
            _TabPages.Remove(control.TabKey);
            LoadTabPage(control.FileInfo);
          }
          else
          {
            _TabPages.Add(control.FileInfo.FullName, _TabPages[control.TabKey]);
            _TabPages.Remove(control.TabKey);
            _TabPages[control.FileInfo.FullName].Text = control.FileInfo.Name;
            control.TabKey = control.FileInfo.FullName;
          }
        }
      }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (_TabControl.SelectedTab != null
        && _TabControl.SelectedTab.Controls.Count > 0)
      {
        PListControl control = _TabControl.SelectedTab.Controls[0] as PListControl;
        if (control != null)
        {
          control.Save();
        }
      }
    }

    private void loadDefinitionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(MagicStrings.DFAULT_PATH);
      if (!directoryInfo.Exists)
        directoryInfo.Create();

      using (OpenFileDialog openFileDialog = new OpenFileDialog())
      {
        openFileDialog.InitialDirectory = directoryInfo.FullName;
        openFileDialog.Filter = "Texture Packer Definition (*.tpd)|*.tpd";
        openFileDialog.Multiselect = true;
        switch (openFileDialog.ShowDialog())
        {
          case DialogResult.OK:

            foreach (string fileName in openFileDialog.FileNames)
            {
              FileInfo fileInfo = new FileInfo(fileName);
              if (fileInfo.Exists)
              {
                LoadTabPage(fileInfo);
              }
            }
            break;
        }

      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveUserSettings();
      this.Close();
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.AddNewTabPage();
    }
  }
}
