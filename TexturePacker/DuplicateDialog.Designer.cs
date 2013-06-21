namespace TexturePacker
{
  partial class DuplicateDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.panel1 = new System.Windows.Forms.Panel();
      this.gvDuplicationInfo = new System.Windows.Forms.DataGridView();
      this.colRelativeFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colScale = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel3 = new System.Windows.Forms.Panel();
      this.btnBrowseDirectory = new System.Windows.Forms.Button();
      this.txtRootFolder = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnDuplicate = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvDuplicationInfo)).BeginInit();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.gvDuplicationInfo);
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(493, 468);
      this.panel1.TabIndex = 0;
      // 
      // gvDuplicationInfo
      // 
      this.gvDuplicationInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvDuplicationInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRelativeFilePath,
            this.colScale});
      this.gvDuplicationInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gvDuplicationInfo.Location = new System.Drawing.Point(0, 40);
      this.gvDuplicationInfo.Name = "gvDuplicationInfo";
      this.gvDuplicationInfo.Size = new System.Drawing.Size(493, 428);
      this.gvDuplicationInfo.TabIndex = 0;
      // 
      // colRelativeFilePath
      // 
      this.colRelativeFilePath.DataPropertyName = "RelativeFilePath";
      this.colRelativeFilePath.HeaderText = "File Name Extension";
      this.colRelativeFilePath.Name = "colRelativeFilePath";
      // 
      // colScale
      // 
      this.colScale.DataPropertyName = "Scale";
      this.colScale.HeaderText = "Scale";
      this.colScale.Name = "colScale";
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.btnBrowseDirectory);
      this.panel3.Controls.Add(this.txtRootFolder);
      this.panel3.Controls.Add(this.label1);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(493, 40);
      this.panel3.TabIndex = 1;
      // 
      // btnBrowseDirectory
      // 
      this.btnBrowseDirectory.Location = new System.Drawing.Point(457, 8);
      this.btnBrowseDirectory.Name = "btnBrowseDirectory";
      this.btnBrowseDirectory.Size = new System.Drawing.Size(24, 23);
      this.btnBrowseDirectory.TabIndex = 2;
      this.btnBrowseDirectory.Text = "...";
      this.btnBrowseDirectory.UseVisualStyleBackColor = true;
      this.btnBrowseDirectory.Click += new System.EventHandler(this.btnBrowseDirectory_Click);
      // 
      // txtRootFolder
      // 
      this.txtRootFolder.Location = new System.Drawing.Point(75, 10);
      this.txtRootFolder.Name = "txtRootFolder";
      this.txtRootFolder.Size = new System.Drawing.Size(376, 20);
      this.txtRootFolder.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(57, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "File Name:";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnCancel);
      this.panel2.Controls.Add(this.btnDuplicate);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 432);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(493, 36);
      this.panel2.TabIndex = 1;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.Location = new System.Drawing.Point(331, 7);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnDuplicate
      // 
      this.btnDuplicate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDuplicate.Location = new System.Drawing.Point(412, 7);
      this.btnDuplicate.Name = "btnDuplicate";
      this.btnDuplicate.Size = new System.Drawing.Size(75, 23);
      this.btnDuplicate.TabIndex = 0;
      this.btnDuplicate.Text = "Duplicate";
      this.btnDuplicate.UseVisualStyleBackColor = true;
      this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
      // 
      // DuplicateDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(493, 468);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DuplicateDialog";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Duplicate";
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gvDuplicationInfo)).EndInit();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.DataGridView gvDuplicationInfo;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnDuplicate;
    private System.Windows.Forms.DataGridViewTextBoxColumn colRelativeFilePath;
    private System.Windows.Forms.DataGridViewTextBoxColumn colScale;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.TextBox txtRootFolder;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnBrowseDirectory;
  }
}