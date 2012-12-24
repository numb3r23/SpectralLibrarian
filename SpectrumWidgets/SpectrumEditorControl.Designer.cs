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
    partial class SpectrumEditorControl
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpectrumEditorControl));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSpectralPoints = new System.Windows.Forms.ListBox();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.pGridSpectrum = new System.Windows.Forms.PropertyGrid();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pGridSpectralPoint = new System.Windows.Forms.PropertyGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnIMNone = new System.Windows.Forms.ToolStripButton();
            this.tsBtnIMIntensity = new System.Windows.Forms.ToolStripButton();
            this.tsBtnIMLambda = new System.Windows.Forms.ToolStripButton();
            this.tsBtnIMIntensityLambda = new System.Windows.Forms.ToolStripButton();
            this.tsBtnIMAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnIMDelete = new System.Windows.Forms.ToolStripButton();
            this.tsDDBtnOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.showMouseCursorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSpectralPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useSpectralColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectralColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.spectralPointColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filledGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.colDlg = new System.Windows.Forms.ColorDialog();
            this.ofDlg = new System.Windows.Forms.OpenFileDialog();
            this.sfDlg = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.revertToolStripMenuItem1 = new System.Windows.Forms.ToolStripButton();
            this.overwriteToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnUndo = new System.Windows.Forms.ToolStripSplitButton();
            this.tsBtnRedo = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem1 = new System.Windows.Forms.ToolStripButton();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnParseGraph = new System.Windows.Forms.ToolStripButton();
            this.specPanel = new SpectrumWidgets.SpectrumPanel();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 261);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(490, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbSpectralPoints);
            this.panel1.Controls.Add(this.splitter3);
            this.panel1.Controls.Add(this.pGridSpectrum);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.pGridSpectralPoint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 204);
            this.panel1.TabIndex = 0;
            // 
            // lbSpectralPoints
            // 
            this.lbSpectralPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSpectralPoints.FormattingEnabled = true;
            this.lbSpectralPoints.Location = new System.Drawing.Point(175, 0);
            this.lbSpectralPoints.Name = "lbSpectralPoints";
            this.lbSpectralPoints.ScrollAlwaysVisible = true;
            this.lbSpectralPoints.Size = new System.Drawing.Size(150, 199);
            this.lbSpectralPoints.TabIndex = 2;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter3.Location = new System.Drawing.Point(325, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(10, 204);
            this.splitter3.TabIndex = 4;
            this.splitter3.TabStop = false;
            // 
            // pGridSpectrum
            // 
            this.pGridSpectrum.Dock = System.Windows.Forms.DockStyle.Right;
            this.pGridSpectrum.Location = new System.Drawing.Point(335, 0);
            this.pGridSpectrum.Name = "pGridSpectrum";
            this.pGridSpectrum.Size = new System.Drawing.Size(155, 204);
            this.pGridSpectrum.TabIndex = 3;
            this.pGridSpectrum.ToolbarVisible = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(165, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(10, 204);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // pGridSpectralPoint
            // 
            this.pGridSpectralPoint.Dock = System.Windows.Forms.DockStyle.Left;
            this.pGridSpectralPoint.Location = new System.Drawing.Point(0, 0);
            this.pGridSpectralPoint.Name = "pGridSpectralPoint";
            this.pGridSpectralPoint.Size = new System.Drawing.Size(165, 204);
            this.pGridSpectralPoint.TabIndex = 0;
            this.pGridSpectralPoint.ToolbarVisible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSave,
            this.toolStripSeparator1,
            this.tsBtnIMNone,
            this.tsBtnIMIntensity,
            this.tsBtnIMLambda,
            this.tsBtnIMIntensityLambda,
            this.tsBtnIMAdd,
            this.tsBtnIMDelete,
            this.tsDDBtnOptions,
            this.toolStripSeparator2,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(490, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnIMNone
            // 
            this.tsBtnIMNone.Checked = true;
            this.tsBtnIMNone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnIMNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnIMNone.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnIMNone.Image")));
            this.tsBtnIMNone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnIMNone.Name = "tsBtnIMNone";
            this.tsBtnIMNone.Size = new System.Drawing.Size(40, 22);
            this.tsBtnIMNone.Text = "None";
            this.tsBtnIMNone.Click += new System.EventHandler(this.tsBtnIMNone_Click);
            // 
            // tsBtnIMIntensity
            // 
            this.tsBtnIMIntensity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnIMIntensity.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnIMIntensity.Image")));
            this.tsBtnIMIntensity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnIMIntensity.Name = "tsBtnIMIntensity";
            this.tsBtnIMIntensity.Size = new System.Drawing.Size(56, 22);
            this.tsBtnIMIntensity.Text = "Intensity";
            this.tsBtnIMIntensity.Click += new System.EventHandler(this.tsBtnIMIntensity_Click);
            // 
            // tsBtnIMLambda
            // 
            this.tsBtnIMLambda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnIMLambda.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnIMLambda.Image")));
            this.tsBtnIMLambda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnIMLambda.Name = "tsBtnIMLambda";
            this.tsBtnIMLambda.Size = new System.Drawing.Size(54, 22);
            this.tsBtnIMLambda.Text = "Lambda";
            this.tsBtnIMLambda.Click += new System.EventHandler(this.tsBtnIMLambda_Click);
            // 
            // tsBtnIMIntensityLambda
            // 
            this.tsBtnIMIntensityLambda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnIMIntensityLambda.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnIMIntensityLambda.Image")));
            this.tsBtnIMIntensityLambda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnIMIntensityLambda.Name = "tsBtnIMIntensityLambda";
            this.tsBtnIMIntensityLambda.Size = new System.Drawing.Size(34, 22);
            this.tsBtnIMIntensityLambda.Text = "I + L";
            this.tsBtnIMIntensityLambda.Click += new System.EventHandler(this.tsBtnIMIntensityLambda_Click);
            // 
            // tsBtnIMAdd
            // 
            this.tsBtnIMAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnIMAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnIMAdd.Image")));
            this.tsBtnIMAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnIMAdd.Name = "tsBtnIMAdd";
            this.tsBtnIMAdd.Size = new System.Drawing.Size(33, 22);
            this.tsBtnIMAdd.Text = "Add";
            this.tsBtnIMAdd.Click += new System.EventHandler(this.tsBtnIMAdd_Click);
            // 
            // tsBtnIMDelete
            // 
            this.tsBtnIMDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnIMDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnIMDelete.Image")));
            this.tsBtnIMDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnIMDelete.Name = "tsBtnIMDelete";
            this.tsBtnIMDelete.Size = new System.Drawing.Size(44, 22);
            this.tsBtnIMDelete.Text = "Delete";
            this.tsBtnIMDelete.Click += new System.EventHandler(this.tsBtnIMDelete_Click);
            // 
            // tsDDBtnOptions
            // 
            this.tsDDBtnOptions.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsDDBtnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDDBtnOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMouseCursorToolStripMenuItem,
            this.showSpectralPointsToolStripMenuItem,
            this.useSpectralColorToolStripMenuItem,
            this.spectralColorToolStripMenuItem,
            this.backgroundColorToolStripMenuItem,
            this.pointSizeToolStripMenuItem,
            this.spectralPointColorToolStripMenuItem,
            this.filledGraphToolStripMenuItem});
            this.tsDDBtnOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsDDBtnOptions.Image")));
            this.tsDDBtnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDDBtnOptions.Name = "tsDDBtnOptions";
            this.tsDDBtnOptions.Size = new System.Drawing.Size(62, 22);
            this.tsDDBtnOptions.Text = "Options";
            // 
            // showMouseCursorToolStripMenuItem
            // 
            this.showMouseCursorToolStripMenuItem.Checked = true;
            this.showMouseCursorToolStripMenuItem.CheckOnClick = true;
            this.showMouseCursorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMouseCursorToolStripMenuItem.Name = "showMouseCursorToolStripMenuItem";
            this.showMouseCursorToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.showMouseCursorToolStripMenuItem.Text = "Show Mouse Crosshair";
            this.showMouseCursorToolStripMenuItem.Click += new System.EventHandler(this.showMouseCursorToolStripMenuItem_Click);
            // 
            // showSpectralPointsToolStripMenuItem
            // 
            this.showSpectralPointsToolStripMenuItem.CheckOnClick = true;
            this.showSpectralPointsToolStripMenuItem.Name = "showSpectralPointsToolStripMenuItem";
            this.showSpectralPointsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.showSpectralPointsToolStripMenuItem.Text = "Show SpectralPoints";
            this.showSpectralPointsToolStripMenuItem.Click += new System.EventHandler(this.showSpectralPointsToolStripMenuItem_Click);
            // 
            // useSpectralColorToolStripMenuItem
            // 
            this.useSpectralColorToolStripMenuItem.Checked = true;
            this.useSpectralColorToolStripMenuItem.CheckOnClick = true;
            this.useSpectralColorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useSpectralColorToolStripMenuItem.Name = "useSpectralColorToolStripMenuItem";
            this.useSpectralColorToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.useSpectralColorToolStripMenuItem.Text = "Use Spectral Color";
            this.useSpectralColorToolStripMenuItem.Click += new System.EventHandler(this.useSpectralColorToolStripMenuItem_Click);
            // 
            // spectralColorToolStripMenuItem
            // 
            this.spectralColorToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.spectralColorToolStripMenuItem.Name = "spectralColorToolStripMenuItem";
            this.spectralColorToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.spectralColorToolStripMenuItem.Text = "Spectral Color";
            this.spectralColorToolStripMenuItem.Click += new System.EventHandler(this.spectralColorToolStripMenuItem_Click);
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.backgroundColorToolStripMenuItem.Text = "Background Color";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
            // 
            // pointSizeToolStripMenuItem
            // 
            this.pointSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.pointSizeToolStripMenuItem.Name = "pointSizeToolStripMenuItem";
            this.pointSizeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.pointSizeToolStripMenuItem.Text = "Point Size";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(88, 22);
            this.toolStripMenuItem6.Text = "-2";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(88, 22);
            this.toolStripMenuItem2.Text = "3";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(88, 22);
            this.toolStripMenuItem3.Text = "7";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(88, 22);
            this.toolStripMenuItem4.Text = "11";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(88, 22);
            this.toolStripMenuItem5.Text = "+2";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // spectralPointColorToolStripMenuItem
            // 
            this.spectralPointColorToolStripMenuItem.Name = "spectralPointColorToolStripMenuItem";
            this.spectralPointColorToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.spectralPointColorToolStripMenuItem.Text = "SpectralPoint Color";
            this.spectralPointColorToolStripMenuItem.Click += new System.EventHandler(this.spectralPointColorToolStripMenuItem_Click);
            // 
            // filledGraphToolStripMenuItem
            // 
            this.filledGraphToolStripMenuItem.Name = "filledGraphToolStripMenuItem";
            this.filledGraphToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.filledGraphToolStripMenuItem.Text = "Filled Graph";
            this.filledGraphToolStripMenuItem.Click += new System.EventHandler(this.filledGraphToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revertToolStripMenuItem1,
            this.overwriteToolStripMenuItem,
            this.toolStripSeparator4,
            this.tsBtnUndo,
            this.tsBtnRedo,
            this.toolStripSeparator5,
            this.importToolStripMenuItem1,
            this.exportToolStripMenuItem1,
            this.toolStripSeparator6,
            this.toolStripButton1,
            this.toolStripSeparator7,
            this.tsBtnParseGraph});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(490, 25);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // revertToolStripMenuItem1
            // 
            this.revertToolStripMenuItem1.Name = "revertToolStripMenuItem1";
            this.revertToolStripMenuItem1.Size = new System.Drawing.Size(44, 22);
            this.revertToolStripMenuItem1.Text = "Revert";
            this.revertToolStripMenuItem1.Click += new System.EventHandler(this.revertToolStripMenuItem1_Click);
            // 
            // overwriteToolStripMenuItem
            // 
            this.overwriteToolStripMenuItem.Name = "overwriteToolStripMenuItem";
            this.overwriteToolStripMenuItem.Size = new System.Drawing.Size(62, 22);
            this.overwriteToolStripMenuItem.Text = "Overwrite";
            this.overwriteToolStripMenuItem.Click += new System.EventHandler(this.overwriteToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnUndo
            // 
            this.tsBtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnUndo.Enabled = false;
            this.tsBtnUndo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUndo.Image")));
            this.tsBtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUndo.Name = "tsBtnUndo";
            this.tsBtnUndo.Size = new System.Drawing.Size(52, 22);
            this.tsBtnUndo.Text = "Undo";
            this.tsBtnUndo.ButtonClick += new System.EventHandler(this.tsBtnUndo_ButtonClick);
            // 
            // tsBtnRedo
            // 
            this.tsBtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnRedo.Enabled = false;
            this.tsBtnRedo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRedo.Image")));
            this.tsBtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRedo.Name = "tsBtnRedo";
            this.tsBtnRedo.Size = new System.Drawing.Size(50, 22);
            this.tsBtnRedo.Text = "Redo";
            this.tsBtnRedo.ButtonClick += new System.EventHandler(this.tsBtnRedo_ButtonClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // importToolStripMenuItem1
            // 
            this.importToolStripMenuItem1.Name = "importToolStripMenuItem1";
            this.importToolStripMenuItem1.Size = new System.Drawing.Size(47, 22);
            this.importToolStripMenuItem1.Text = "Import";
            this.importToolStripMenuItem1.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(44, 22);
            this.exportToolStripMenuItem1.Text = "Export";
            this.exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripButton1.Text = "Clear";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnParseGraph
            // 
            this.tsBtnParseGraph.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnParseGraph.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnParseGraph.Image")));
            this.tsBtnParseGraph.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnParseGraph.Name = "tsBtnParseGraph";
            this.tsBtnParseGraph.Size = new System.Drawing.Size(74, 22);
            this.tsBtnParseGraph.Text = "Parse Graph";
            this.tsBtnParseGraph.Click += new System.EventHandler(this.tsBtnParseGraph_Click);
            // 
            // specPanel
            // 
            this.specPanel.BackColor = System.Drawing.Color.Black;
            this.specPanel.ColorSpectralPoint = System.Drawing.Color.Orange;
            this.specPanel.CrosshairColor = System.Drawing.Color.White;
            this.specPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.specPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.specPanel.FilledGraph = false;
            this.specPanel.Image = ((System.Drawing.Bitmap)(resources.GetObject("specPanel.Image")));
            this.specPanel.InteractionMode = SpectrumWidgets.EInteractionModes.None;
            this.specPanel.Location = new System.Drawing.Point(0, 50);
            this.specPanel.Name = "specPanel";
            this.specPanel.ShowMouseCrosshair = true;
            this.specPanel.ShowSpectrumPoints = true;
            this.specPanel.Size = new System.Drawing.Size(490, 211);
            this.specPanel.Spectrum = null;
            this.specPanel.SpectrumColor = System.Drawing.Color.Red;
            this.specPanel.TabIndex = 3;
            // 
            // SpectrumEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.specPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "SpectrumEditorControl";
            this.Size = new System.Drawing.Size(490, 468);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.PropertyGrid pGridSpectrum;
        private System.Windows.Forms.ListBox lbSpectralPoints;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.PropertyGrid pGridSpectralPoint;
        private SpectrumWidgets.SpectrumPanel specPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnIMNone;
        private System.Windows.Forms.ToolStripButton tsBtnIMIntensity;
        private System.Windows.Forms.ToolStripButton tsBtnIMLambda;
        private System.Windows.Forms.ToolStripButton tsBtnIMIntensityLambda;
        private System.Windows.Forms.ToolStripButton tsBtnIMAdd;
        private System.Windows.Forms.ToolStripButton tsBtnIMDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton tsDDBtnOptions;
        private System.Windows.Forms.ToolStripMenuItem showSpectralPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useSpectralColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spectralColorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colDlg;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem showMouseCursorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem spectralPointColorToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofDlg;
        private System.Windows.Forms.SaveFileDialog sfDlg;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton revertToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton overwriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton importToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSplitButton tsBtnUndo;
        private System.Windows.Forms.ToolStripSplitButton tsBtnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem filledGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsBtnParseGraph;
    }
}
