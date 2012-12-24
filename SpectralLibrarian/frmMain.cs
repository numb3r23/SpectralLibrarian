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
using SpectrumWidgets;

namespace SpectralLibrarian
{
    public partial class frmMain : Form
    {
        public enum ELibrarySelectedType
        {
            Category, Spectrum, Nothing
        }

        SpectrumLibrary spectrumLibrary;
        
        public SpectrumList Collection
        {
            get { return sclv.Collection; }
            set { sclv.Collection = value; }
        }
        
        String collectionFileName;
        String libraryFileName;

        SpectraBinIO spectraBinIO;
        SpectraXMLIO spectraXMLIO;

        ToolStripSplitButtonVariable<View> tsSplitVar;

        public frmMain()
        {
            InitializeComponent();

            init();


            AddEditor("[Editor]");
        }

        private void init()
        {
            spectraBinIO = new SpectraBinIO();
            spectraXMLIO = new SpectraXMLIO();

            collectionFileName = "";
            libraryFileName = "";

            String[] strArr = new String[5] { "List", "Small Icons", "Large Icons", "Tile", "Details" };
            View[] viewArr = new View[5] { View.List, View.SmallIcon, View.LargeIcon, View.Tile, View.Details };
            tsSplitVar = new ToolStripSplitButtonVariable<View>(strArr, viewArr);
            tsSplitVar.Alignment = ToolStripItemAlignment.Right;
            tsSplitVar.OnVariableSet += new ToolStripSplitButtonVariable<View>.VariableSet(tsSplitVar_OnVariableSet);
            tsSplitVar.Variable = View.Details;

            tsCollection.Items.Add(tsSplitVar);

            
        }
        private void GenerateTestData()
        {
            SpectrumLibrary specLib = new SpectrumLibrary();
            for (int i = 0; i < 15; i++)
            {
                Spectrum spec = new Spectrum(ESpectrumTemplate.ExtendedVisible);
                spec.AddSpectralPoint(630, 1);
                spec.Name = "Laser: " + (i);
                spec.Interpolation = ESpectralInterpolation.Peak;
                spec.Clear();
                specLib.AddSpectrum(spec, "Laser");
            }

            for (int i = 0; i < 15; i++)
            {
                Spectrum spec = new Spectrum(ESpectrumTemplate.ExtendedVisible);
                spec.AddSpectralPoint(580, 0);
                spec.Name = "Light: " + (i);
                specLib.AddSpectrum(spec, "Light");
            }

            for (int i = 0; i < 15; i++)
            {
                Spectrum spec = new Spectrum(ESpectrumTemplate.ExtendedVisible);
                spec.AddSpectralPoint(580, 0);
                spec.Name = "Material: " + (i);
                specLib.AddSpectrum(spec, "Materials");
            }

            SetSpectrumLibrary(specLib);
        }

        private void SetSpectrumLibrary(SpectrumLibrary specLib)
        {
            spectrumLibrary = specLib;
            sLibTVP.SpectrumLibrary = specLib;

            tcMain.TabPages.Clear();
            AddEditor("[Editor]");
            foreach (String category in specLib.Categories.Keys)
                AddPage(category);
        }
        
        public void AddPage(String category)
        {
            tcMain.TabPages.Add(new SpectraListTabPage(spectrumLibrary, category));
        }

        public void AddEditor(String name)
        {
            tcMain.TabPages.Add(new SpectrumEditorTabPage(spectrumLibrary));
        }

        #region Collection
        private void tsBtnAddToCollection_Click(object sender, EventArgs e)
        {
            if (tcMain.SelectedTab.GetType() == typeof(SpectraListTabPage))
                foreach (ListViewItem lvi in ((SpectraListTabPage)tcMain.SelectedTab).SpectraListListView.SelectedItems)
                    Collection.Add(spectrumLibrary.GetSpectrum(lvi.ImageIndex));
        }

        private void tsCollectionDelete_Click(object sender, EventArgs e)
        {
            List<Spectrum> tmp = new List<Spectrum>();
            for (int i = sclv.SelectedIndices.Count - 1; i >= 0; i--)
                tmp.Add(Collection[sclv.SelectedIndices[i]]);
            
            foreach (Spectrum spectrum in tmp)
                Collection.Remove(spectrum);
        }

        #region Collection: ViewModes

        void tsSplitVar_OnVariableSet()
        {
            sclv.View = tsSplitVar.Variable;
        }

        #endregion
        #endregion

        #region Action
        #region Action: Library
        private void LibrarySave()
        {
            if (spectrumLibrary.Spectra.Count > 0)
            {
                //TODO: Store Filetype To WRite, so dialog pops up only once...!
                sfDlg.Filter = spectraXMLIO.Extensions + "|" + spectraBinIO.Extensions;
                SpectraDiskIO Writer = null;
                if (sfDlg.ShowDialog() == DialogResult.OK)
                {
                    if (sfDlg.FilterIndex == 1)
                        Writer = spectraXMLIO;
                    if (sfDlg.FilterIndex == 2)
                        Writer = spectraBinIO;
                    if (Writer != null)
                    {
                        Writer.Spectra = spectrumLibrary.Spectra;
                        Writer.FileName = sfDlg.FileName;
                        Writer.WriteToDisk();
                        libraryFileName = sfDlg.FileName;
                    }
                }
            }
        }

        private void LibrarySaveAs()
        {
            libraryFileName = "";
            LibrarySave();
        }

        private void LibraryOpen()
        {
            ofDlg.Filter = spectraXMLIO.Extensions + "|" + spectraBinIO.Extensions;
            SpectraDiskIO Reader = null;
            if (ofDlg.ShowDialog() == DialogResult.OK)
            {
                if (ofDlg.FilterIndex == 1)
                    Reader = spectraXMLIO;
                if (ofDlg.FilterIndex == 2)
                    Reader = spectraBinIO;
                if (Reader != null)
                {
                    Reader.FileName = ofDlg.FileName;
                    Reader.ReadFromDisk();
                    SpectrumLibrary specLib = new SpectrumLibrary();
                    foreach (Spectrum spec in Reader.Spectra.Spectra)
                    {
                        specLib.AddSpectrum(spec);
                    }
                    SetSpectrumLibrary(specLib);
                }
            }
        }

        private void LibraryNew()
        {
            SpectrumLibrary specLib = new SpectrumLibrary();
            SetSpectrumLibrary(specLib);
        }

        #region Action: Library: Management
        private ELibrarySelectedType GetTreeViewNodeType(TreeNode tn)
        {
            if (tn != null)
                if (spectrumLibrary.Categories.Contains(tn.Text))
                    return ELibrarySelectedType.Category;
                else
                    return ELibrarySelectedType.Spectrum;
            return ELibrarySelectedType.Nothing;
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion
        #region Action: Collection

        private void CollectionSave()
        {
            if (Collection.Count > 0)
            {
                //TODO: Store Filetype To WRite, so dialog pops up only once...!
                sfDlg.Filter = spectraXMLIO.Extensions + "|" + spectraBinIO.Extensions;
                SpectraDiskIO Writer = null;
                if (sfDlg.ShowDialog() == DialogResult.OK)
                {
                    if (sfDlg.FilterIndex == 1)
                        Writer = spectraXMLIO;
                    if (sfDlg.FilterIndex == 2)
                        Writer = spectraBinIO;
                    if (Writer != null)
                    {
                        Writer.Spectra = Collection;
                        Writer.FileName = sfDlg.FileName;
                        Writer.WriteToDisk();
                        collectionFileName = sfDlg.FileName;
                    }
                }
            }
        }

        private void CollectionSaveAs()
        {
            collectionFileName = "";
            CollectionSave();
        }

        private void CollectionNew()
        {
            Collection = new SpectrumList();
        }

        private void CollectionOpen()
        {
            ofDlg.Filter = spectraXMLIO.Extensions + "|" + spectraBinIO.Extensions;
            SpectraDiskIO Reader = null;
            if (ofDlg.ShowDialog() == DialogResult.OK)
            {
                if (ofDlg.FilterIndex == 1)
                    Reader = spectraXMLIO;
                if (ofDlg.FilterIndex == 2)
                    Reader = spectraBinIO;
                if (Reader != null)
                {
                    Reader.FileName = ofDlg.FileName;
                    Reader.ReadFromDisk();
                    Collection = Reader.Spectra;
                    collectionFileName = sfDlg.FileName;
                }
            }
        }
        #endregion
        #endregion

        #region MainMenu
        #region MainMenu: File
        private void saveLibraryAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibrarySaveAs();
        }

        private void openLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibraryOpen();
        }

        private void newLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibraryNew();
        }
        private void saveLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibrarySave();
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region MainMenu: Collection
        private void exportCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextureExportPreview texp = new TextureExportPreview(Collection);
            texp.Show(this);
        }

        private void saveCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CollectionSave();
        }

        private void saveCollectionAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CollectionSaveAs();
        }

        private void openCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CollectionOpen();
        }

        private void newCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CollectionNew();
        }
        #endregion

        private void generateTestLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateTestData();
        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }


    }
}