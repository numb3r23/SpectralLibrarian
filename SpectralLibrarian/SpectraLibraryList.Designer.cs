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
    partial class SpectraLibraryList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpectraLibraryList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnView = new System.Windows.Forms.ToolStripButton();
            this.tsBtnTest = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnView,
            this.tsBtnTest});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(443, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnView
            // 
            this.tsBtnView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnView.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnView.Image")));
            this.tsBtnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnView.Name = "tsBtnView";
            this.tsBtnView.Size = new System.Drawing.Size(36, 22);
            this.tsBtnView.Text = "View";
            this.tsBtnView.Click += new System.EventHandler(this.tsBtnView_Click);
            // 
            // tsBtnTest
            // 
            this.tsBtnTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnTest.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnTest.Image")));
            this.tsBtnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnTest.Name = "tsBtnTest";
            this.tsBtnTest.Size = new System.Drawing.Size(33, 22);
            this.tsBtnTest.Text = "Test";
            this.tsBtnTest.Click += new System.EventHandler(this.tsBtnTest_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(443, 371);
            this.tabControl1.TabIndex = 3;
            // 
            // SpectraLibraryList
            // 
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Size = new System.Drawing.Size(443, 396);
            this.Text = "SpectraLibraryList";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripButton tsBtnView;
        private System.Windows.Forms.ToolStripButton tsBtnTest;
    }
}