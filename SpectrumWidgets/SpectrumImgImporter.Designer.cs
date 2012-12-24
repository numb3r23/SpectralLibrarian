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
﻿namespace SpectrumWidgets
{
    partial class SpectrumImgImporter
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpectrumImgImporter));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnParse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnChooseGraphColor = new System.Windows.Forms.ToolStripButton();
            this.tsBtnChooseStartingpoint = new System.Windows.Forms.ToolStripButton();
            this.tsBtnChooseSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ofDlg = new System.Windows.Forms.OpenFileDialog();
            this.colDlg = new System.Windows.Forms.ColorDialog();
            this.pbImport = new System.Windows.Forms.PictureBox();
            this.pGridImport = new System.Windows.Forms.PropertyGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pGraphColor = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.spbPreview = new SpectrumWidgets.SpectrumPanel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnImport = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnParse,
            this.toolStripSeparator1,
            this.tsBtnReset,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.tsBtnChooseGraphColor,
            this.tsBtnChooseStartingpoint,
            this.tsBtnChooseSize,
            this.toolStripSeparator3,
            this.tsBtnCancel,
            this.tsBtnImport,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(745, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnParse
            // 
            this.tsBtnParse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnParse.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnParse.Image")));
            this.tsBtnParse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnParse.Name = "tsBtnParse";
            this.tsBtnParse.Size = new System.Drawing.Size(39, 22);
            this.tsBtnParse.Text = "Parse";
            this.tsBtnParse.Click += new System.EventHandler(this.tsBtnImport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel1.Text = "Choose:";
            // 
            // tsBtnChooseGraphColor
            // 
            this.tsBtnChooseGraphColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnChooseGraphColor.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnChooseGraphColor.Image")));
            this.tsBtnChooseGraphColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnChooseGraphColor.Name = "tsBtnChooseGraphColor";
            this.tsBtnChooseGraphColor.Size = new System.Drawing.Size(70, 22);
            this.tsBtnChooseGraphColor.Text = "Graphcolor";
            this.tsBtnChooseGraphColor.Click += new System.EventHandler(this.tsBtnChooseGraphColor_Click);
            // 
            // tsBtnChooseStartingpoint
            // 
            this.tsBtnChooseStartingpoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnChooseStartingpoint.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnChooseStartingpoint.Image")));
            this.tsBtnChooseStartingpoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnChooseStartingpoint.Name = "tsBtnChooseStartingpoint";
            this.tsBtnChooseStartingpoint.Size = new System.Drawing.Size(80, 22);
            this.tsBtnChooseStartingpoint.Text = "Startingpoint";
            this.tsBtnChooseStartingpoint.Click += new System.EventHandler(this.tsBtnChooseStartingpoint_Click);
            // 
            // tsBtnChooseSize
            // 
            this.tsBtnChooseSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnChooseSize.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnChooseSize.Image")));
            this.tsBtnChooseSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnChooseSize.Name = "tsBtnChooseSize";
            this.tsBtnChooseSize.Size = new System.Drawing.Size(59, 22);
            this.tsBtnChooseSize.Text = "Endpoint";
            this.tsBtnChooseSize.Click += new System.EventHandler(this.tsBtnChooseSize_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ofDlg
            // 
            this.ofDlg.FileName = "openFileDialog1";
            // 
            // pbImport
            // 
            this.pbImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImport.Location = new System.Drawing.Point(0, 25);
            this.pbImport.Name = "pbImport";
            this.pbImport.Size = new System.Drawing.Size(745, 538);
            this.pbImport.TabIndex = 1;
            this.pbImport.TabStop = false;
            // 
            // pGridImport
            // 
            this.pGridImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGridImport.Location = new System.Drawing.Point(0, 63);
            this.pGridImport.Name = "pGridImport";
            this.pGridImport.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pGridImport.Size = new System.Drawing.Size(123, 475);
            this.pGridImport.TabIndex = 2;
            this.pGridImport.ToolbarVisible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(123, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 388);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pGridImport);
            this.panel1.Controls.Add(this.pGraphColor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 538);
            this.panel1.TabIndex = 4;
            // 
            // pGraphColor
            // 
            this.pGraphColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pGraphColor.Location = new System.Drawing.Point(0, 0);
            this.pGraphColor.Name = "pGraphColor";
            this.pGraphColor.Size = new System.Drawing.Size(123, 63);
            this.pGraphColor.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(131, 405);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(614, 8);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // spbPreview
            // 
            this.spbPreview.BackColor = System.Drawing.Color.Black;
            this.spbPreview.ColorSpectralPoint = System.Drawing.Color.Orange;
            this.spbPreview.CrosshairColor = System.Drawing.Color.White;
            this.spbPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            this.spbPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spbPreview.Image = ((System.Drawing.Bitmap)(resources.GetObject("spbPreview.Image")));
            this.spbPreview.InteractionMode = SpectrumWidgets.EInteractionModes.None;
            this.spbPreview.Location = new System.Drawing.Point(123, 413);
            this.spbPreview.Name = "spbPreview";
            this.spbPreview.Size = new System.Drawing.Size(622, 150);
            this.spbPreview.Spectrum = null;
            this.spbPreview.SpectrumColor = System.Drawing.Color.Red;
            this.spbPreview.TabIndex = 6;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnImport
            // 
            this.tsBtnImport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnImport.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnImport.Image")));
            this.tsBtnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnImport.Name = "tsBtnImport";
            this.tsBtnImport.Size = new System.Drawing.Size(74, 22);
            this.tsBtnImport.Text = "OK - Import";
            this.tsBtnImport.Click += new System.EventHandler(this.tsBtnImport_Click_1);
            // 
            // tsBtnCancel
            // 
            this.tsBtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCancel.Image")));
            this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCancel.Name = "tsBtnCancel";
            this.tsBtnCancel.Size = new System.Drawing.Size(47, 22);
            this.tsBtnCancel.Text = "Cancel";
            this.tsBtnCancel.Click += new System.EventHandler(this.tsBtnCancel_Click);
            // 
            // SpectrumImgImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 563);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.spbPreview);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbImport);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "SpectrumImgImporter";
            this.Text = "SpectrumImgImporter";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnParse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnReset;
        private System.Windows.Forms.OpenFileDialog ofDlg;
        private System.Windows.Forms.ColorDialog colDlg;
        private System.Windows.Forms.PictureBox pbImport;
        private System.Windows.Forms.PropertyGrid pGridImport;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsBtnChooseGraphColor;
        private System.Windows.Forms.ToolStripButton tsBtnChooseStartingpoint;
        private System.Windows.Forms.ToolStripButton tsBtnChooseSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pGraphColor;
        private System.Windows.Forms.Splitter splitter2;
        private SpectrumPanel spbPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsBtnImport;
        private System.Windows.Forms.ToolStripButton tsBtnCancel;
    }
}