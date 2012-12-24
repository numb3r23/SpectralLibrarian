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
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using SpectrumBib;

namespace SpectrumWidgets
{
    public partial class SpectrumEditorTabPage : TabPage
    {

        #region Properties
        private SpectrumEditorControl specEdControl;

        private SpectrumLibrary specLib = null;
        public SpectrumLibrary SpectrumLibrary
        {
            get { return specLib; }
            set { SetSpectrumLibrary(value); }
        }

        public Spectrum Spectrum
        {
            get { return specEdControl.Spectrum; }
            set { SetSpectrum(value); }
        }

        bool externalSpectrum;
        #endregion

        #region Constructors & Init
        public SpectrumEditorTabPage()
        {
            InitializeComponent();

            init();
        }

        public SpectrumEditorTabPage(Spectrum spec)
        {
            InitializeComponent();

            init();

            Spectrum = spec;

        }

        public SpectrumEditorTabPage(SpectrumLibrary specLib_)
        {
            InitializeComponent();

            init();

            SetSpectrumLibrary(specLib_);

        }

        public SpectrumEditorTabPage(SpectrumLibrary specLib_, Spectrum spec)
        {
            InitializeComponent();

            init();

            SetSpectrumLibrary(specLib_);
            Spectrum = spec;

        }

        public SpectrumEditorTabPage(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            init();
        }

        private void SetName(String txt)
        {
            base.Name = txt;
            base.Text = txt;
        }

        private void init()
        {
            specEdControl = new SpectrumEditorControl();
            specEdControl.Dock = DockStyle.Fill;

            externalSpectrum = false;
            SetAppropriateName(false);

            this.Controls.Add(specEdControl);

            specEdControl.OnSpectrumEditorSave += new SpectrumEditorControl.SpectrumEditorSave(specEdControl_OnSpectrumEditorSave);
        }

        void specEdControl_OnSpectrumEditorSave(Spectrum spec)
        {
            CallSpectrumModified();
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent != null)
            {
                ((TabControl)this.Parent).Deselecting += new TabControlCancelEventHandler(SpectrumEditorTabPage_Deselecting);
                ((TabControl)this.Parent).Selected += new TabControlEventHandler(SpectrumEditorTabPage_Selected);
            }
        }

        void SpectrumEditorTabPage_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == this)
            {
                CallSpectrumModified();
                SetAppropriateName(false);
            }
        }

        void SpectrumEditorTabPage_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == this)
                SetAppropriateName(true);
        }

        private void CallSpectrumModified()
        {
            if (specLib != null)
                specLib.DoSpectrumModified(Spectrum);
        }
        #endregion

        private void SetSpectrumLibrary(SpectrumLibrary specLib_)
        {
            specLib = specLib_;
            if (specLib != null)
            {
                specLib.OnEditSpectrum += new SpectrumLibrary.EditSpectrum(specLib_OnEditSpectrum);
            }
        }

        void specLib_OnEditSpectrum(int idx, Spectrum spec, string category)
        {
            Spectrum = spec;
            ((TabControl) this.Parent).SelectTab(this);
        }

        private void SetSpectrum(Spectrum spec)
        {
            CallSpectrumModified();
            externalSpectrum = true;
            specEdControl.Spectrum = spec;
            SetAppropriateName(true);
        }

        private void SetAppropriateName(bool focused)
        {
            if (focused)
                if (externalSpectrum)
                    SetName("[Editor] [" + Spectrum.Category + ":" + Spectrum.Name + "]");
                else
                    SetName("[Editor]");
            else
                SetName("[Editor]");
        }
    }
}
