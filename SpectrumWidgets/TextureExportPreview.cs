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
using SpectrumBib;
using SpectrumBib.IO;

namespace SpectrumWidgets
{
    public partial class TextureExportPreview : Form
    {
        SpectrumList specList;
        SpectraTextureIO export;

        public TextureExportPreview(SpectrumList specList_)
        {
            InitializeComponent();

            pGridExport.PropertyValueChanged += new PropertyValueChangedEventHandler(pGridExport_PropertyValueChanged);

            specList = specList_;
            export = new SpectraTextureIO(specList);
            sfDlg.Filter = export.Extensions;
            pGridExport.SelectedObject = export;
            RefreshPropertyGrid();
        }

        void RefreshPropertyGrid()
        {
            pbPreview.Image = export.GenerateOutput();
        }

        void pGridExport_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (tsBtnLiveUpdate.Checked)
                RefreshPropertyGrid();
        }

        private void tsBtnReset_Click(object sender, EventArgs e)
        {
            export = new SpectraTextureIO(specList);
            pGridExport.SelectedObject = export;
            pbPreview.Image = export.GenerateOutput();
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (sfDlg.ShowDialog() == DialogResult.OK)
            {
                export.FileName = sfDlg.FileName;
                pGridExport.Refresh();
                export.WriteToDisk();
            }
        }

        private void tsBtnLiveUpdate_Click(object sender, EventArgs e)
        {
            tsBtnLiveUpdate.Checked = !tsBtnLiveUpdate.Checked;
        }

        private void tsBtnUpdate_Click(object sender, EventArgs e)
        {
            RefreshPropertyGrid();
        }
    }
}