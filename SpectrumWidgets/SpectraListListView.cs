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
    public partial class SpectraListListView : ListView
    {
        // TODO SpectraListTabPage - UI
        // TODO SpectraListTabPage - Tooltip
        // TODO SpectraListTabPage - Events: Click/DoubleClick
        public static Size SIZE_SMALL = new Size(16, 16);
        public static Size SIZE_LARGE = new Size(64, 64);

        #region Properties
        private SpectrumLibrary spectrumLib;
        public SpectrumLibrary SpectrumLibrary
        {
            set { SetSpectrumLibrary(value); }
        }

        private String category = "";
        public String Category
        {
            get { return category; }
            set { SetCategory(value); }
        }
        #endregion

        #region Constructors & init
        public SpectraListListView(IContainer conatiner)
        {
            InitializeComponent();

            init();

            conatiner.Add(this);
        }

        public SpectraListListView(String category_)
            :
            base()
        {
            InitializeComponent();

            init();
        }

        public SpectraListListView(SpectrumLibrary spectrumLib_, String category_)
            :
            base()
        {
            InitializeComponent();

            init();

            SetSpectrumLibrary(spectrumLib_);
            SetCategory(category_);
        }

        public SpectraListListView(SpectrumLibrary spectrumLib_)
            :
            base()
        {
            InitializeComponent();

            init();

            SetSpectrumLibrary(spectrumLib_);
        }

        private void init()
        {
            View = View.LargeIcon;

            Columns.Add("Name");
            Columns.Add("Minlambda");
            Columns.Add("MaxLambda");
            Columns.Add("Points");
            Columns.Add("Interpolation");
            Columns.Add("BaseIntensity");
            Columns.Add("MinIntensity");
            Columns.Add("MaxIntensity");

            SmallImageList = new ImageList();
            LargeImageList = new ImageList();
            initImageLists();
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            ListViewItem lvi = GetItemAt(e.X, e.Y);
            if (lvi != null)
            {
                spectrumLib.DoEditSpectrum(lvi.ImageIndex);
            }
            
            base.OnMouseClick(e);
        }

        private void initImageLists()
        {
            SmallImageList.ImageSize = SpectrumGUIHelper.SIZE_SMALL;
            LargeImageList.ImageSize = SpectrumGUIHelper.SIZE_LARGE;
        }
        #endregion

        public void SetLibraryCategory(SpectrumLibrary sl, String category)
        {
            init();

            SetSpectrumLibrary(sl);
            SetCategory(category);
        }

        private void SetSpectrumLibrary(SpectrumLibrary sl)
        {
            spectrumLib = sl;
            if (sl != null)
            {
                SmallImageList = spectrumLib.ImagesSmall;
                LargeImageList = spectrumLib.ImagesLarge;

                category = "";

                sl.OnSpectrumModified += new SpectrumLibrary.SpectrumModified(sl_OnSpectrumModified);
                sl.OnCategorySpectrumAdded += new SpectrumLibrary.CategorySpectrumAdded(sl_OnCategorySpectrumAdded);

                InvalidateSpectrumLibrary();
            }
            /*
            spectra = sl;

            spectra.OnSpectrumAdded += new SpectrumList.SpectrumAdded(spectra_OnSpectrumAdded);
            spectra.OnSpectrumDeleted += new SpectrumList.SpectrumDeleted(spectra_OnSpectrumDeleted);
            spectra.OnSpectrumModified += new SpectrumList.SpectrumModified(spectra_OnSpectrumModified);
            */
        }

        void sl_OnCategorySpectrumAdded(int idx, Spectrum spec, string category)
        {
            InvalidateSpectrumLibrary();
        }

        void sl_OnSpectrumModified(int idx, Spectrum spec, string category)
        {
            if (category == this.category)
            {
                for (int i = 0; i < Items.Count; i++)
                    if (Items[i].ImageIndex == idx)
                        SpectrumGUIHelper.UpdateListViewItem(Items[i], spec);
            }
        }

        private void SetCategory(String category_)
        {
            category = category_;
            Name = category;

            InvalidateSpectrumLibrary();
        }

        private void CleanUpItemIndices(int idx)
        {
            foreach (ListViewItem lvi in Items)
                if (lvi.ImageIndex > idx)
                    lvi.ImageIndex -= 1;
        }
        /*
        void spectra_OnSpectrumModified(int idx, Spectrum spec)
        {
            ilSmall.Images[idx] = specDrawer.GetBitmap(spec, true, SpectraListTabPage.SIZE_SMALL);
            ilLarge.Images[idx] = specDrawer.GetBitmap(spec, true, SpectraListTabPage.SIZE_LARGE);
            lv.Items[idx] = CreateListViewItem(spec, idx);
        }

        void spectra_OnSpectrumDeleted(int idx)
        {
            CleanUpItemIndices(idx); //1h debugging ... thx }:/

            lv.Items.RemoveAt(idx);
            ilSmall.Images.RemoveAt(idx);
            ilLarge.Images.RemoveAt(idx);
        }

        void spectra_OnSpectrumAdded(int idx, Spectrum spec)
        {
            ilSmall.Images.Add(specDrawer.GetBitmap(spec, true, SpectraListTabPage.SIZE_SMALL));
            ilLarge.Images.Add(specDrawer.GetBitmap(spec, true, SpectraListTabPage.SIZE_LARGE));
            lv.Items.Add(CreateListViewItem(spec, idx));
        }
        */
        private void InvalidateSpectrumLibrary()
        {
                Items.Clear();
                int idx = 0;

                if (category != "")
                {
                    foreach (Spectrum spec in spectrumLib.Category(category).Spectra)
                    {
                        Items.Add(SpectrumGUIHelper.CreateListViewItem(spec));
                        idx++;
                    }
                }
        }

        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            List<Spectrum> tmp = new List<Spectrum>();
            if (SelectedItems.Count > 0)
                foreach (ListViewItem lvi in SelectedItems)
                    if (!tmp.Contains(spectrumLib.GetSpectrum(lvi.ImageIndex)))
                        tmp.Add(spectrumLib.GetSpectrum(lvi.ImageIndex));

            System.Console.WriteLine("ItemDrag - Tab " + tmp.Count);
            this.DoDragDrop(tmp, DragDropEffects.Copy);
        }

    }
}
