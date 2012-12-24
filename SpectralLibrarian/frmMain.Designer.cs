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
﻿namespace SpectralLibrarian
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLibraryAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCollectionAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateTestLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sclv = new SpectrumWidgets.SpectrumCollectionListView(this.components);
            this.tsCollection = new System.Windows.Forms.ToolStrip();
            this.tsBtnAddToCollection = new System.Windows.Forms.ToolStripButton();
            this.tsBtnUpdateCollection = new System.Windows.Forms.ToolStripButton();
            this.tsCollectionDelete = new System.Windows.Forms.ToolStripButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tsLib = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRename = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sLibTVP = new SpectrumWidgets.SpectrumLibraryTVPanel(this.components);
            this.sfDlg = new System.Windows.Forms.SaveFileDialog();
            this.ofDlg = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tsCollection.SuspendLayout();
            this.tsLib.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.collectionToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(987, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLibraryToolStripMenuItem,
            this.openLibraryToolStripMenuItem,
            this.saveLibraryToolStripMenuItem,
            this.saveLibraryAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newLibraryToolStripMenuItem
            // 
            this.newLibraryToolStripMenuItem.Name = "newLibraryToolStripMenuItem";
            this.newLibraryToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.newLibraryToolStripMenuItem.Text = "New Library";
            this.newLibraryToolStripMenuItem.Click += new System.EventHandler(this.newLibraryToolStripMenuItem_Click);
            // 
            // openLibraryToolStripMenuItem
            // 
            this.openLibraryToolStripMenuItem.Name = "openLibraryToolStripMenuItem";
            this.openLibraryToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.openLibraryToolStripMenuItem.Text = "Open Library";
            this.openLibraryToolStripMenuItem.Click += new System.EventHandler(this.openLibraryToolStripMenuItem_Click);
            // 
            // saveLibraryToolStripMenuItem
            // 
            this.saveLibraryToolStripMenuItem.Name = "saveLibraryToolStripMenuItem";
            this.saveLibraryToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveLibraryToolStripMenuItem.Text = "Save Library";
            this.saveLibraryToolStripMenuItem.Click += new System.EventHandler(this.saveLibraryToolStripMenuItem_Click);
            // 
            // saveLibraryAsToolStripMenuItem
            // 
            this.saveLibraryAsToolStripMenuItem.Name = "saveLibraryAsToolStripMenuItem";
            this.saveLibraryAsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveLibraryAsToolStripMenuItem.Text = "Save Library As";
            this.saveLibraryAsToolStripMenuItem.Click += new System.EventHandler(this.saveLibraryAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // collectionToolStripMenuItem
            // 
            this.collectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCollectionToolStripMenuItem,
            this.openCollectionToolStripMenuItem,
            this.saveCollectionToolStripMenuItem,
            this.saveCollectionAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exportCollectionToolStripMenuItem});
            this.collectionToolStripMenuItem.Name = "collectionToolStripMenuItem";
            this.collectionToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.collectionToolStripMenuItem.Text = "Collection";
            // 
            // newCollectionToolStripMenuItem
            // 
            this.newCollectionToolStripMenuItem.Name = "newCollectionToolStripMenuItem";
            this.newCollectionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.newCollectionToolStripMenuItem.Text = "New Collection";
            this.newCollectionToolStripMenuItem.Click += new System.EventHandler(this.newCollectionToolStripMenuItem_Click);
            // 
            // openCollectionToolStripMenuItem
            // 
            this.openCollectionToolStripMenuItem.Name = "openCollectionToolStripMenuItem";
            this.openCollectionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.openCollectionToolStripMenuItem.Text = "Open Collection";
            this.openCollectionToolStripMenuItem.Click += new System.EventHandler(this.openCollectionToolStripMenuItem_Click);
            // 
            // saveCollectionToolStripMenuItem
            // 
            this.saveCollectionToolStripMenuItem.Name = "saveCollectionToolStripMenuItem";
            this.saveCollectionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.saveCollectionToolStripMenuItem.Text = "Save Collection";
            this.saveCollectionToolStripMenuItem.Click += new System.EventHandler(this.saveCollectionToolStripMenuItem_Click);
            // 
            // saveCollectionAsToolStripMenuItem
            // 
            this.saveCollectionAsToolStripMenuItem.Name = "saveCollectionAsToolStripMenuItem";
            this.saveCollectionAsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.saveCollectionAsToolStripMenuItem.Text = "SaveCollection As";
            this.saveCollectionAsToolStripMenuItem.Click += new System.EventHandler(this.saveCollectionAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(165, 6);
            // 
            // exportCollectionToolStripMenuItem
            // 
            this.exportCollectionToolStripMenuItem.Name = "exportCollectionToolStripMenuItem";
            this.exportCollectionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exportCollectionToolStripMenuItem.Text = "Export Collection";
            this.exportCollectionToolStripMenuItem.Click += new System.EventHandler(this.exportCollectionToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateTestLibraryToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // generateTestLibraryToolStripMenuItem
            // 
            this.generateTestLibraryToolStripMenuItem.Name = "generateTestLibraryToolStripMenuItem";
            this.generateTestLibraryToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.generateTestLibraryToolStripMenuItem.Text = "GenerateTestLibrary";
            this.generateTestLibraryToolStripMenuItem.Click += new System.EventHandler(this.generateTestLibraryToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 611);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(987, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 587);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sclv);
            this.panel1.Controls.Add(this.tsCollection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(735, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 587);
            this.panel1.TabIndex = 7;
            // 
            // sclv
            // 
            this.sclv.AllowDrop = true;
            this.sclv.Collection = ((SpectrumBib.SpectrumList)(resources.GetObject("sclv.Collection")));
            this.sclv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sclv.Location = new System.Drawing.Point(0, 25);
            this.sclv.Name = "sclv";
            this.sclv.Size = new System.Drawing.Size(252, 562);
            this.sclv.TabIndex = 11;
            this.sclv.UseCompatibleStateImageBehavior = false;
            this.sclv.View = System.Windows.Forms.View.Details;
            // 
            // tsCollection
            // 
            this.tsCollection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAddToCollection,
            this.tsBtnUpdateCollection,
            this.tsCollectionDelete});
            this.tsCollection.Location = new System.Drawing.Point(0, 0);
            this.tsCollection.Name = "tsCollection";
            this.tsCollection.Size = new System.Drawing.Size(252, 25);
            this.tsCollection.TabIndex = 10;
            this.tsCollection.Text = "toolStrip1";
            // 
            // tsBtnAddToCollection
            // 
            this.tsBtnAddToCollection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnAddToCollection.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAddToCollection.Image")));
            this.tsBtnAddToCollection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddToCollection.Name = "tsBtnAddToCollection";
            this.tsBtnAddToCollection.Size = new System.Drawing.Size(33, 22);
            this.tsBtnAddToCollection.Text = "Add";
            this.tsBtnAddToCollection.Click += new System.EventHandler(this.tsBtnAddToCollection_Click);
            // 
            // tsBtnUpdateCollection
            // 
            this.tsBtnUpdateCollection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnUpdateCollection.Enabled = false;
            this.tsBtnUpdateCollection.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUpdateCollection.Image")));
            this.tsBtnUpdateCollection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUpdateCollection.Name = "tsBtnUpdateCollection";
            this.tsBtnUpdateCollection.Size = new System.Drawing.Size(49, 22);
            this.tsBtnUpdateCollection.Text = "Update";
            // 
            // tsCollectionDelete
            // 
            this.tsCollectionDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsCollectionDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsCollectionDelete.Image")));
            this.tsCollectionDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCollectionDelete.Name = "tsCollectionDelete";
            this.tsCollectionDelete.Size = new System.Drawing.Size(44, 22);
            this.tsCollectionDelete.Text = "Delete";
            this.tsCollectionDelete.Click += new System.EventHandler(this.tsCollectionDelete_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(732, 24);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 587);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            // 
            // tcMain
            // 
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(203, 24);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(529, 587);
            this.tcMain.TabIndex = 10;
            // 
            // tsLib
            // 
            this.tsLib.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.tsBtnRename,
            this.tsBtnDelete,
            this.toolStripButton3});
            this.tsLib.Location = new System.Drawing.Point(0, 0);
            this.tsLib.Name = "tsLib";
            this.tsLib.Size = new System.Drawing.Size(200, 25);
            this.tsLib.TabIndex = 11;
            this.tsLib.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(33, 22);
            this.toolStripButton1.Text = "Add";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsBtnRename
            // 
            this.tsBtnRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnRename.Enabled = false;
            this.tsBtnRename.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRename.Image")));
            this.tsBtnRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRename.Name = "tsBtnRename";
            this.tsBtnRename.Size = new System.Drawing.Size(54, 22);
            this.tsBtnRename.Text = "Rename";
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnDelete.Enabled = false;
            this.tsBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelete.Image")));
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(44, 22);
            this.tsBtnDelete.Text = "Delete";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(41, 22);
            this.toolStripButton3.Text = "Move";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sLibTVP);
            this.panel2.Controls.Add(this.tsLib);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 587);
            this.panel2.TabIndex = 12;
            // 
            // sLibTVP
            // 
            this.sLibTVP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sLibTVP.LabelEdit = true;
            this.sLibTVP.LineColor = System.Drawing.Color.Gray;
            this.sLibTVP.Location = new System.Drawing.Point(0, 25);
            this.sLibTVP.Name = "sLibTVP";
            this.sLibTVP.Size = new System.Drawing.Size(200, 562);
            this.sLibTVP.SpectrumLibrary = null;
            this.sLibTVP.TabIndex = 4;
            // 
            // ofDlg
            // 
            this.ofDlg.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 633);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SpectralLibrarian";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsCollection.ResumeLayout(false);
            this.tsCollection.PerformLayout();
            this.tsLib.ResumeLayout(false);
            this.tsLib.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private SpectrumWidgets.SpectrumLibraryTVPanel sLibTVP;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolStrip tsCollection;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLibraryAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCollectionAsToolStripMenuItem;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.ToolStripButton tsBtnAddToCollection;
        private System.Windows.Forms.ToolStripButton tsBtnUpdateCollection;
        private SpectrumWidgets.SpectrumCollectionListView sclv;
        private System.Windows.Forms.ToolStripMenuItem openCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tsLib;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SaveFileDialog sfDlg;
        private System.Windows.Forms.OpenFileDialog ofDlg;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateTestLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsBtnRename;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tsCollectionDelete;
    }
}

