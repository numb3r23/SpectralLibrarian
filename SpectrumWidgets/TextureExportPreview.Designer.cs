/****************************************************************** 
  Copyright 2008 by numb3r23 (23@numb3r23.net)

  This file is part of SpectralLibrarian.

  - https://github.com/numb3r23/SpectralLibrarian -

  SpectralLibrarian is free software: you can redistribute it and/or
  modify it under the terms of the GNU General Public License as
  published by the Free Software Foundation, either version 3 of the
  License, or (at your option) any later version.

  SpectralLibrarian is distributed in the hope that it will be
  useful, but WITHOUT ANY WARRANTY; without even the implied
  warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
  See the GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with SpectralLibrarian. If not, see 
  http://www.gnu.org/licenses/.
*******************************************************************/
namespace SpectrumWidgets
{
    partial class TextureExportPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextureExportPreview));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pGridExport = new System.Windows.Forms.PropertyGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.sfDlg = new System.Windows.Forms.SaveFileDialog();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnReset = new System.Windows.Forms.ToolStripButton();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnLiveUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSave,
            this.tsBtnReset,
            this.toolStripSeparator1,
            this.tsBtnClose,
            this.toolStripSeparator2,
            this.tsBtnUpdate,
            this.tsBtnLiveUpdate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(700, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // pGridExport
            // 
            this.pGridExport.Dock = System.Windows.Forms.DockStyle.Left;
            this.pGridExport.Location = new System.Drawing.Point(0, 25);
            this.pGridExport.Name = "pGridExport";
            this.pGridExport.Size = new System.Drawing.Size(183, 514);
            this.pGridExport.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(183, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 514);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.Color.Black;
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(186, 25);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(514, 514);
            this.pbPreview.TabIndex = 3;
            this.pbPreview.TabStop = false;
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSave.Image")));
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(35, 22);
            this.tsBtnSave.Text = "Save";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // tsBtnReset
            // 
            this.tsBtnReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnReset.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnReset.Image")));
            this.tsBtnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnReset.Name = "tsBtnReset";
            this.tsBtnReset.Size = new System.Drawing.Size(39, 22);
            this.tsBtnReset.Text = "Reset";
            this.tsBtnReset.Click += new System.EventHandler(this.tsBtnReset_Click);
            // 
            // tsBtnClose
            // 
            this.tsBtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnClose.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnClose.Image")));
            this.tsBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnClose.Name = "tsBtnClose";
            this.tsBtnClose.Size = new System.Drawing.Size(37, 22);
            this.tsBtnClose.Text = "Close";
            this.tsBtnClose.Click += new System.EventHandler(this.tsBtnClose_Click);
            // 
            // tsBtnUpdate
            // 
            this.tsBtnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUpdate.Image")));
            this.tsBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUpdate.Name = "tsBtnUpdate";
            this.tsBtnUpdate.Size = new System.Drawing.Size(46, 22);
            this.tsBtnUpdate.Text = "Update";
            this.tsBtnUpdate.Click += new System.EventHandler(this.tsBtnUpdate_Click);
            // 
            // tsBtnLiveUpdate
            // 
            this.tsBtnLiveUpdate.Checked = true;
            this.tsBtnLiveUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnLiveUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnLiveUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnLiveUpdate.Image")));
            this.tsBtnLiveUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLiveUpdate.Name = "tsBtnLiveUpdate";
            this.tsBtnLiveUpdate.Size = new System.Drawing.Size(65, 22);
            this.tsBtnLiveUpdate.Text = "LiveUpdate";
            this.tsBtnLiveUpdate.Click += new System.EventHandler(this.tsBtnLiveUpdate_Click);
            // 
            // TextureExportPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 539);
            this.Controls.Add(this.pbPreview);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pGridExport);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "TextureExportPreview";
            this.Text = "TextureExportPreview";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripButton tsBtnReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsBtnUpdate;
        private System.Windows.Forms.ToolStripButton tsBtnLiveUpdate;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.SaveFileDialog sfDlg;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.PropertyGrid pGridExport;
    }
}