namespace TexturePacker
{
  partial class PListControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PListControl));
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.txtPListOutput = new System.Windows.Forms.RichTextBox();
      this.gvDefinitions = new System.Windows.Forms.DataGridView();
      this.panel3 = new System.Windows.Forms.Panel();
      this.btnClose = new System.Windows.Forms.Button();
      this.btnCopyToClipboard = new System.Windows.Forms.Button();
      this.btnDuplicate = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.btnAddDefinition = new System.Windows.Forms.ToolStripButton();
      this.btnDeleteDefinition = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.btnUp = new System.Windows.Forms.ToolStripButton();
      this.btnDown = new System.Windows.Forms.ToolStripButton();
      this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colOriginX = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colOriginY = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colDestinationX = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colDestinationY = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colTotalHorizontalRepeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colTotalVerticalRepeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colRotate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvDefinitions)).BeginInit();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.toolStripContainer2.ContentPanel.SuspendLayout();
      this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
      this.toolStripContainer2.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.txtPListOutput);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox2.Location = new System.Drawing.Point(0, 0);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(858, 217);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "PList Output";
      // 
      // txtPListOutput
      // 
      this.txtPListOutput.BackColor = System.Drawing.Color.Gainsboro;
      this.txtPListOutput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtPListOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPListOutput.ForeColor = System.Drawing.Color.Black;
      this.txtPListOutput.Location = new System.Drawing.Point(3, 16);
      this.txtPListOutput.Name = "txtPListOutput";
      this.txtPListOutput.ReadOnly = true;
      this.txtPListOutput.Size = new System.Drawing.Size(852, 198);
      this.txtPListOutput.TabIndex = 0;
      this.txtPListOutput.Text = "";
      // 
      // gvDefinitions
      // 
      this.gvDefinitions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvDefinitions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colName,
            this.colOriginX,
            this.colOriginY,
            this.colDestinationX,
            this.colDestinationY,
            this.colTotalHorizontalRepeats,
            this.colTotalVerticalRepeats,
            this.colRotate});
      this.gvDefinitions.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gvDefinitions.Location = new System.Drawing.Point(0, 0);
      this.gvDefinitions.Name = "gvDefinitions";
      this.gvDefinitions.Size = new System.Drawing.Size(858, 218);
      this.gvDefinitions.TabIndex = 0;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.btnClose);
      this.panel3.Controls.Add(this.btnCopyToClipboard);
      this.panel3.Controls.Add(this.btnDuplicate);
      this.panel3.Controls.Add(this.btnSave);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel3.Location = new System.Drawing.Point(0, 439);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(858, 37);
      this.panel3.TabIndex = 5;
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.Location = new System.Drawing.Point(774, 8);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // btnCopyToClipboard
      // 
      this.btnCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCopyToClipboard.Location = new System.Drawing.Point(460, 8);
      this.btnCopyToClipboard.Name = "btnCopyToClipboard";
      this.btnCopyToClipboard.Size = new System.Drawing.Size(134, 23);
      this.btnCopyToClipboard.TabIndex = 2;
      this.btnCopyToClipboard.Text = "Copy to clipboard";
      this.btnCopyToClipboard.UseVisualStyleBackColor = true;
      this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
      // 
      // btnDuplicate
      // 
      this.btnDuplicate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDuplicate.Location = new System.Drawing.Point(600, 8);
      this.btnDuplicate.Name = "btnDuplicate";
      this.btnDuplicate.Size = new System.Drawing.Size(75, 23);
      this.btnDuplicate.TabIndex = 1;
      this.btnDuplicate.Text = "Duplicate";
      this.btnDuplicate.UseVisualStyleBackColor = true;
      this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
      // 
      // btnSave
      // 
      this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSave.Location = new System.Drawing.Point(681, 8);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 23);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.gvDefinitions);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
      this.splitContainer1.Size = new System.Drawing.Size(858, 439);
      this.splitContainer1.SplitterDistance = 218;
      this.splitContainer1.TabIndex = 6;
      // 
      // toolStripContainer2
      // 
      // 
      // toolStripContainer2.ContentPanel
      // 
      this.toolStripContainer2.ContentPanel.AutoScroll = true;
      this.toolStripContainer2.ContentPanel.Controls.Add(this.splitContainer1);
      this.toolStripContainer2.ContentPanel.Controls.Add(this.panel3);
      this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(858, 476);
      this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
      this.toolStripContainer2.Name = "toolStripContainer2";
      this.toolStripContainer2.Size = new System.Drawing.Size(858, 501);
      this.toolStripContainer2.TabIndex = 7;
      this.toolStripContainer2.Text = "toolStripContainer2";
      // 
      // toolStripContainer2.TopToolStripPanel
      // 
      this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolStrip1);
      // 
      // toolStrip1
      // 
      this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDefinition,
            this.btnDeleteDefinition,
            this.toolStripSeparator1,
            this.btnUp,
            this.btnDown});
      this.toolStrip1.Location = new System.Drawing.Point(3, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(246, 25);
      this.toolStrip1.TabIndex = 4;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // btnAddDefinition
      // 
      this.btnAddDefinition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnAddDefinition.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnAddDefinition.Name = "btnAddDefinition";
      this.btnAddDefinition.Size = new System.Drawing.Size(78, 22);
      this.btnAddDefinition.Text = "Add Definition";
      this.btnAddDefinition.Click += new System.EventHandler(this.btnAddDefinition_Click);
      // 
      // btnDeleteDefinition
      // 
      this.btnDeleteDefinition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnDeleteDefinition.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteDefinition.Image")));
      this.btnDeleteDefinition.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnDeleteDefinition.Name = "btnDeleteDefinition";
      this.btnDeleteDefinition.Size = new System.Drawing.Size(90, 22);
      this.btnDeleteDefinition.Text = "Delete Definition";
      this.btnDeleteDefinition.Click += new System.EventHandler(this.btnDeleteDefinition_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // btnUp
      // 
      this.btnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
      this.btnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnUp.Name = "btnUp";
      this.btnUp.Size = new System.Drawing.Size(24, 22);
      this.btnUp.Text = "Up";
      this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
      // 
      // btnDown
      // 
      this.btnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
      this.btnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnDown.Name = "btnDown";
      this.btnDown.Size = new System.Drawing.Size(38, 22);
      this.btnDown.Text = "Down";
      this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
      // 
      // colIndex
      // 
      this.colIndex.DataPropertyName = "Index";
      this.colIndex.HeaderText = "Index";
      this.colIndex.Name = "colIndex";
      this.colIndex.ReadOnly = true;
      this.colIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.colIndex.Width = 40;
      // 
      // colName
      // 
      this.colName.DataPropertyName = "Name";
      this.colName.HeaderText = "Name";
      this.colName.Name = "colName";
      // 
      // colOriginX
      // 
      this.colOriginX.DataPropertyName = "OriginX";
      this.colOriginX.HeaderText = "Origin X";
      this.colOriginX.Name = "colOriginX";
      // 
      // colOriginY
      // 
      this.colOriginY.DataPropertyName = "OriginY";
      this.colOriginY.HeaderText = "Origin Y";
      this.colOriginY.Name = "colOriginY";
      // 
      // colDestinationX
      // 
      this.colDestinationX.DataPropertyName = "DestinationX";
      this.colDestinationX.HeaderText = "Destination X";
      this.colDestinationX.Name = "colDestinationX";
      // 
      // colDestinationY
      // 
      this.colDestinationY.DataPropertyName = "DestinationY";
      this.colDestinationY.HeaderText = "Destination Y";
      this.colDestinationY.Name = "colDestinationY";
      // 
      // colTotalHorizontalRepeats
      // 
      this.colTotalHorizontalRepeats.DataPropertyName = "TotalHorizontalRepeats";
      this.colTotalHorizontalRepeats.HeaderText = "Horizontal Repeats";
      this.colTotalHorizontalRepeats.Name = "colTotalHorizontalRepeats";
      // 
      // colTotalVerticalRepeats
      // 
      this.colTotalVerticalRepeats.DataPropertyName = "TotalVerticalRepeats";
      this.colTotalVerticalRepeats.HeaderText = "Vertical Repeats";
      this.colTotalVerticalRepeats.Name = "colTotalVerticalRepeats";
      // 
      // colRotate
      // 
      this.colRotate.DataPropertyName = "Rotate";
      this.colRotate.HeaderText = "Rotate";
      this.colRotate.Name = "colRotate";
      // 
      // PListControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.toolStripContainer2);
      this.Name = "PListControl";
      this.Size = new System.Drawing.Size(858, 501);
      this.groupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gvDefinitions)).EndInit();
      this.panel3.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.toolStripContainer2.ContentPanel.ResumeLayout(false);
      this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
      this.toolStripContainer2.TopToolStripPanel.PerformLayout();
      this.toolStripContainer2.ResumeLayout(false);
      this.toolStripContainer2.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button btnDuplicate;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.DataGridView gvDefinitions;
    private System.Windows.Forms.RichTextBox txtPListOutput;
    private System.Windows.Forms.Button btnCopyToClipboard;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton btnAddDefinition;
    private System.Windows.Forms.ToolStripButton btnDeleteDefinition;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton btnUp;
    private System.Windows.Forms.ToolStripButton btnDown;
    private System.Windows.Forms.ToolStripContainer toolStripContainer2;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
    private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colOriginX;
    private System.Windows.Forms.DataGridViewTextBoxColumn colOriginY;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDestinationX;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDestinationY;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTotalHorizontalRepeats;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTotalVerticalRepeats;
    private System.Windows.Forms.DataGridViewCheckBoxColumn colRotate;
  }
}
