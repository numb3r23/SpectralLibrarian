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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpectrumWidgets;
using SpectrumBib;

namespace SpectralLibrarian
{
    public partial class SpectraLibraryList : Panel
    {
        SpectrumLibrary spectrumLib;

        public SpectraLibraryList( SpectrumLibrary sl)
        {
            InitializeComponent();

            init();

            SetSpectrumLibrary(sl);
        }

        public SpectraLibraryList()
        {
            InitializeComponent();

            init();
        }

        private void init()
        {
            //tabControl1.TabPages.Add(new SpectraListTabPage("[default]"));
        }

        private void tsBtnTest_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 0)
            {
                SpectraListTabPage sltp = (SpectraListTabPage) tabControl1.TabPages[0];
            }
        }

        private void tsBtnView_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 0)
            {
                SpectraListTabPage sltp = (SpectraListTabPage)tabControl1.SelectedTab;
                switch (sltp.View)
                {
                    case View.Details:
                        sltp.View = View.LargeIcon;
                        break;
                    case View.LargeIcon:
                        sltp.View = View.List;
                        break;
                    case View.List:
                        sltp.View = View.SmallIcon;
                        break;
                    case View.SmallIcon:
                        sltp.View = View.Tile;
                        break;
                    case View.Tile:
                        sltp.View = View.Details;
                        break;
                    default:
                        break;
                }
            }
        }

        public void SetSpectrumLibrary(SpectrumLibrary sl)
        {
            tabControl1.TabPages.Clear();

            spectrumLib = sl;
        }

        public void AddPage(String category)
        {
            tabControl1.TabPages.Add(new SpectraListTabPage(spectrumLib, category));
        }

        public void SetPage(int idx, String category)
        {
            if (idx < tabControl1.TabPages.Count)
                ((SpectraListTabPage) tabControl1.TabPages[idx]).SetCategory(category);

        }

        public void AddEditor(String name)
        {
            tabControl1.TabPages.Add(new SpectrumEditorTabPage(spectrumLib));
        }

    }
}