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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SpectrumBib;

namespace SpectrumWidgets
{
    public partial class SpectraListTabPage : TabPage
    {
        // TODO SpectraListTabPage - UI
        // TODO SpectraListTabPage - Tooltip
        // TODO SpectraListTabPage - Events: Click/DoubleClick
        #region Properties & Variables
        private SpectrumLibrary specLib;
        private String category;

        public SpectraListListView SpectraListListView
        {
            get { return sllv; }
        }

        public View View
        {
            get { return (sllv != null)?sllv.View: View.LargeIcon; }
            set { if (sllv != null) tsSplitVar.Variable = value; }
        }

        ToolStrip tsMain;

        ToolStripButton tsBtnDelete;
        ToolStripButton tsBtnRename;

        ToolStripSplitButtonVariable<View> tsSplitVar;
        ToolStripSplitButtonVariable<ESpectrumTemplate> tsAddLinearVar;
        ToolStripSplitButtonVariable<ESpectrumTemplate> tsAddPeakVar;

        #endregion

        #region Constructors & init
        public SpectraListTabPage(SpectrumLibrary spectrumLib_, String category_)
            :
            base(category_)
        {
            InitializeComponent();

            specLib = spectrumLib_;
            category = category_;

            SetSpectrumLibrary(spectrumLib_);
            SetCategory(category_);
            sllv.Parent = this;

            initToolBar();

            Name = category_;
        }

        private void initToolBar()
        {
            tsMain = new ToolStrip();
            tsMain.Parent = this;

            String[] strArr = new String[5] { "List", "Small Icons", "Large Icons", "Tile", "Details" };
            View[] viewArr = new View[5] { View.List, View.SmallIcon, View.LargeIcon, View.Tile, View.Details };
            tsSplitVar = new ToolStripSplitButtonVariable<View>(strArr, viewArr);
            tsSplitVar.Alignment = ToolStripItemAlignment.Right;
            tsSplitVar.OnVariableSet += new ToolStripSplitButtonVariable<View>.VariableSet(tsSplitVar_OnVariableSet);
            tsSplitVar.Variable = View.Tile;

            String[] strAddArr = new String[2] { "Extended Visible Spectrum", "Visible Spectrum" };
            ESpectrumTemplate[] tmpAddArr = new ESpectrumTemplate[2] {ESpectrumTemplate.ExtendedVisible, ESpectrumTemplate.Visible};

            tsAddLinearVar = new ToolStripSplitButtonVariable<ESpectrumTemplate>(strAddArr, tmpAddArr);
            tsAddLinearVar.ChangeText = false;
            tsAddLinearVar.CycleVariable = false;
            tsAddLinearVar.Text = "Add Linear";
            tsAddLinearVar.OnVariableSet += new ToolStripSplitButtonVariable<ESpectrumTemplate>.VariableSet(tsAddLinearVar_OnVariableSet);

            tsAddPeakVar = new ToolStripSplitButtonVariable<ESpectrumTemplate>(strAddArr, tmpAddArr);
            tsAddPeakVar.ChangeText = false;
            tsAddPeakVar.CycleVariable = false;
            tsAddPeakVar.Text = "Add Peak";
            tsAddPeakVar.OnVariableSet += new ToolStripSplitButtonVariable<ESpectrumTemplate>.VariableSet(tsAddPeakVar_OnVariableSet);

            tsBtnDelete = new ToolStripButton("Delete");
            tsBtnDelete.Click += new EventHandler(tsBtnDelete_Click);

            tsBtnRename = new ToolStripButton("Rename");
            tsBtnRename.Click += new EventHandler(tsBtnRename_Click);

            tsMain.Items.Add(tsAddLinearVar);
            tsMain.Items.Add(tsAddPeakVar);
            tsMain.Items.Add(tsBtnDelete);
            tsMain.Items.Add(tsBtnRename);
            tsMain.Items.Add(tsSplitVar);
        }

        private void tsBtnRename_Click(object sender, EventArgs e)
        {
            
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void tsAddPeakVar_OnVariableSet()
        {
            Spectrum spectrum = new Spectrum(tsAddLinearVar.Variable);
            spectrum.Interpolation = ESpectralInterpolation.Peak;
            spectrum.Name = category;
            specLib.AddSpectrum(spectrum, category);
        }

        private void tsAddLinearVar_OnVariableSet()
        {
            Spectrum spectrum = new Spectrum(tsAddLinearVar.Variable);
            spectrum.Interpolation = ESpectralInterpolation.Linear;
            spectrum.Name = category;
            
            specLib.AddSpectrum(spectrum, category);
        }

        private void tsSplitVar_OnVariableSet()
        {
            sllv.View = tsSplitVar.Variable;
        }

        #endregion

        public void SetSpectrumLibrary(SpectrumLibrary sl)
        {
            sllv.SpectrumLibrary = sl;
        }

        public void SetCategory(String category_)
        {
            sllv.Category = category_;
        }
   }
}
