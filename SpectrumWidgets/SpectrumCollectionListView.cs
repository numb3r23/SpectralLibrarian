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
    public partial class SpectrumCollectionListView : ListView
    {
        // TODO SpectraListTabPage - UI
        // TODO SpectraListTabPage - Tooltip
        // TODO SpectraListTabPage - Events: Click/DoubleClick
        public static Size SIZE_SMALL = new Size(16, 16);
        public static Size SIZE_LARGE = new Size(64, 64);

        #region Properties
        private SpectrumList collection;
        public SpectrumList Collection
        {
            get { return collection; }
            set { SetCollection(value); }
        }

        private SpectrumPainter specPainter;
        #endregion

        #region Constructors & init
        public SpectrumCollectionListView(IContainer conatiner)
        {
            InitializeComponent();

            init();

            conatiner.Add(this);
        }

        private void init()
        {
            collection = new SpectrumList();
            specPainter = new SpectrumPainter();

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

            AllowDrop = true;
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            ListViewItem lvi = GetItemAt(e.X, e.Y);
            
            base.OnMouseClick(e);
        }

        #region Drag'n'Drop
        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            if (SelectedItems.Count > 0)
                this.DoDragDrop(SelectedItems, DragDropEffects.Move);
//            base.OnItemDrag(e);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            drgevent.Effect = DragDropEffects.None;

            if (drgevent.Data.GetDataPresent(typeof(SelectedListViewItemCollection)))
                drgevent.Effect = drgevent.AllowedEffect;
            if (drgevent.Data.GetDataPresent(typeof(List<Spectrum>)))
                drgevent.Effect = drgevent.AllowedEffect;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            switch (drgevent.AllowedEffect)
            {
                case DragDropEffects.All:
                    break;
                case DragDropEffects.Copy:
                    if (drgevent.Data.GetDataPresent(typeof(List<Spectrum>)))
                        AddSpectra((List<Spectrum>)drgevent.Data.GetData(typeof(List<Spectrum>)));
                    break;
                case DragDropEffects.Link:
                    break;
                case DragDropEffects.Move:
                    if (drgevent.Data.GetDataPresent(typeof(SelectedListViewItemCollection)))
                        MoveItems((SelectedListViewItemCollection)drgevent.Data.GetData(typeof(SelectedListViewItemCollection)), drgevent);
                    break;
                case DragDropEffects.None:
                    break;
                case DragDropEffects.Scroll:
                    break;
                default:
                    break;
            }
            drgevent.Effect = DragDropEffects.None;
        }

        private void AddSpectra(List<Spectrum> list)
        {
            foreach (Spectrum spectrum in list)
                this.AddToCollection(spectrum);
        }

        private void MoveItems(SelectedListViewItemCollection items, DragEventArgs drgevent)
        {
            if (items.Count == 0)
                return;

            Point cp = PointToClient(new Point(drgevent.X, drgevent.Y));
            ListViewItem dragToItem = GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
                return;

            int dragIndex = dragToItem.Index;

            Spectrum spectrumDragIdx = collection[dragToItem.ImageIndex];
            List<Spectrum> tmp = new List<Spectrum>();

            foreach (ListViewItem lvi in items)
                tmp.Add(collection[lvi.ImageIndex]);

            foreach (Spectrum spec in tmp)
                collection.Remove(spec);

            int idx = collection.GetIndex(spectrumDragIdx);

            foreach (Spectrum spec in tmp)
                collection.Spectra.Insert(idx, spec);

            InvalidateCollection();
        }
        #endregion

        private void initImageLists()
        {
            SmallImageList.ImageSize = SpectrumGUIHelper.SIZE_SMALL;
            LargeImageList.ImageSize = SpectrumGUIHelper.SIZE_LARGE;
        }
        #endregion


        #region Collection-Mode mothods
        //TODO
        private void SetCollection(SpectrumList specList)
        {
            collection = specList;
            if (collection != null)
            {
                collection.OnSpectrumAdded += new SpectrumList.SpectrumAdded(collection_OnSpectrumAdded);
                collection.OnSpectrumDeleted += new SpectrumList.SpectrumDeleted(collection_OnSpectrumDeleted);
            }

            InvalidateCollection();
        }

        void collection_OnSpectrumDeleted(int idx)
        {
            InvalidateCollection();
        }

        void collection_OnSpectrumAdded(int idx, Spectrum spec)
        {
            InvalidateCollection();
        }

        private void AddSpectrumItem(Spectrum spec)
        {
            SmallImageList.Images.Add(specPainter.GetBitmap(spec, true, SmallImageList.ImageSize));
            LargeImageList.Images.Add(specPainter.GetBitmap(spec, true, LargeImageList.ImageSize));
            int idx = SmallImageList.Images.Count - 1;

            ListViewItem lvi = SpectrumGUIHelper.CreateListViewItem(spec);
            lvi.ImageIndex = idx;

            Items.Add(lvi);
        }

        public void AddToCollection(Spectrum spec)
        {
            Collection.Add(new Spectrum(spec));
        }
        #endregion

        private void InvalidateCollection()
        {
            SmallImageList.Images.Clear();
            LargeImageList.Images.Clear();

            Items.Clear();

            foreach (Spectrum spec in Collection.Spectra)
                AddSpectrumItem(spec);

        }
    }

}
