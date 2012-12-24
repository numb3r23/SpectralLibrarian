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
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpectrumBib;

namespace SpectrumWidgets
{
    public partial class SpectrumLibraryTVPanel : TreeView
    {
//        public static int NOIMAGE = -1;
        SpectrumLibrary specLib;
        public SpectrumLibrary SpectrumLibrary
        {
            get { return specLib; }
            set { SetSpectrumLibrary(value); }
        }

//        Bitmap dottedImage;
//        Bitmap dottedExpandedImage;

        new public Color LineColor
        {
            get { return base.LineColor; }
            set { SetLineColor(value); }
        }

        private ContextMenuStrip contextMenuCategory;
        public ContextMenuStrip ContextMenuCategory
        {
            get { return contextMenuCategory; }
            set { SetContextMenuCategory(value); }
        }

        private ContextMenuStrip contextMenuSpectrum;
        public ContextMenuStrip ContextMenuSpectrum
        {
            get { return contextMenuSpectrum; }
            set { SetContextMenuSpectrum(value); }
        }
        
        public SpectrumLibraryTVPanel()
        {
            InitializeComponent();

            init();
        }

        public SpectrumLibraryTVPanel(SpectrumLibrary specLib_)
        {
            InitializeComponent();

            init();

            SetSpectrumLibrary(specLib_);   
        }

        public SpectrumLibraryTVPanel(IContainer conatiner)
        {
            InitializeComponent();

            init();

            conatiner.Add(this);
        }

        private void init()
        {
            LineColor = SystemColors.GrayText;
            this.LabelEdit = true;
            this.AfterLabelEdit += new NodeLabelEditEventHandler(SpectrumLibraryTVPanel_AfterLabelEdit);

            CreateContextMenuStripCategory();
            CreateContextMenuStripSpectrum();
            CreateContextMenuStripPlain();
        }

        void SpectrumLibraryTVPanel_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            String oldName = e.Node.Text;

            if (e.Node.Name == "Category")
            {
                specLib.ChangeCategoryName(oldName, e.Label);
                e.Node.Text = e.Label;
            }
            if (e.Node.Name == "Spectrum")
            {
                Spectrum spec = specLib.GetSpectrum(e.Node.ImageIndex);
                spec.Name = e.Label;
                specLib.DoSpectrumModified(spec);
            }
            System.Console.WriteLine(e.Label);
        }

        #region ContextMenu
        #region ContextCategory
        private void CreateContextMenuStripCategory()
        {
            contextMenuCategory = null;
            contextMenuCategory = new ContextMenuStrip();
            ToolStripItem renameCategory = contextMenuCategory.Items.Add("Rename");
            renameCategory.Click += new EventHandler(renameCategory_Click);
            /*
            ToolStripDropDownItem addCategory = (ToolStripDropDownItem) contextMenuCategory.Items.Add("Add...");

            ToolStripItem addDDCategory = addCategory.DropDown.Items.Add("New Category");
            addDDCategory.Click += new EventHandler(addDDCategory_Click);

            ToolStripItem addDDSpectrum = addCategory.DropDown.Items.Add("New Spectrum");
            addDDSpectrum.Click += new EventHandler(addDDSpectrum_Click);
             */
        }

        void addDDCategory_Click(object sender, EventArgs e)
        {
            if (this.SelectedNode != null)
                System.Console.WriteLine(this.SelectedNode.Text);
            else
                System.Console.WriteLine("null");
        }

        void addDDSpectrum_Click(object sender, EventArgs e)
        {
            if (this.SelectedNode != null)
                System.Console.WriteLine(this.SelectedNode.Text);
            else
                System.Console.WriteLine("null");
        }

        void renameCategory_Click(object sender, EventArgs e)
        {
            EditSelectedNodeName();
        }
        #endregion

        #region ContextSpectrum
        private void CreateContextMenuStripSpectrum()
        {
            contextMenuSpectrum = null;
            contextMenuSpectrum = new ContextMenuStrip();
            ToolStripItem renameSpectrum = contextMenuSpectrum.Items.Add("Rename");
            renameSpectrum.Click += new EventHandler(renameSpectrum_Click);


        }

        void renameSpectrum_Click(object sender, EventArgs e)
        {
            EditSelectedNodeName();
        }
        #endregion

        #region ContextPlain
        private void CreateContextMenuStripPlain()
        {

        }
        #endregion
        #endregion

        private void SetSpectrumLibrary(SpectrumLibrary specLib_)
        {
            specLib = specLib_;
            if (specLib != null)
            {
                this.ImageList = specLib.ImagesSmall;

                InvalidateSpectrumLib();

                specLib.OnSpectrumModified += new SpectrumLibrary.SpectrumModified(specLib_OnSpectrumModified);
                specLib.OnSpectrumRemoved += new SpectrumLibrary.SpectrumRemoved(specLib_OnSpectrumRemoved);
                specLib.OnCategorySpectrumAdded += new SpectrumLibrary.CategorySpectrumAdded(specLib_OnCategorySpectrumAdded);
            }
        }

        void specLib_OnCategorySpectrumAdded(int idx, Spectrum spec, string category)
        {
            InvalidateSpectrumLib();
        }

        void specLib_OnSpectrumRemoved(int idx, string Category)
        {
            InvalidateSpectrumLib();
        }

        public void SetContextMenu(ContextMenuStrip cmsCategory, ContextMenuStrip cmsSpectrum)
        {
            contextMenuCategory = cmsCategory;
            contextMenuSpectrum = cmsSpectrum;
            InvalidateSpectrumLib();
        }

        private void SetContextMenuCategory(ContextMenuStrip value)
        {
            contextMenuCategory = value;
            InvalidateSpectrumLib();
        }

        private void SetContextMenuSpectrum(ContextMenuStrip value)
        {
            contextMenuSpectrum = value;
            InvalidateSpectrumLib();
        }

        void specLib_OnSpectrumModified(int idx, Spectrum spec, string category)
        {
            this.Invalidate();
        }

        public void InvalidateSpectrumLib()
        {
            this.Nodes.Clear();
            if (specLib != null)
            {
                foreach (SpectrumList sl in specLib)
                {
                    TreeNode tnCategory = new TreeNode(sl.Category);
                    tnCategory.Name = "Category";
                    tnCategory.Text = sl.Category;
                    tnCategory.ImageIndex = 9999999;
                    tnCategory.SelectedImageIndex = 9999999;
                    foreach (Spectrum spec in sl.Spectra)
                    {
                        TreeNode tnSpectrum = new TreeNode(spec.Name);
                        tnSpectrum.Name = "Spectrum";
                        tnSpectrum.Text = spec.Name;
                        tnSpectrum.ImageIndex = spec.ImageIndex;
                        tnSpectrum.SelectedImageIndex = spec.ImageIndex;
                        tnSpectrum.ContextMenuStrip = contextMenuSpectrum;
                        tnCategory.Nodes.Add(tnSpectrum);

                    }
                    tnCategory.ContextMenuStrip = contextMenuCategory;
                    this.Nodes.Add(tnCategory);
                }
            }
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawNode(e);

        }

        private void SetLineColor(Color col)
        {
            base.LineColor = col;

            CreateNoImageImages();
        }

        private void CreateNoImageImages()
        {
            /*
            if (ImageList != null)
            {
                Pen p = new Pen(base.LineColor, 1);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                p.DashOffset = base.Indent % 2;

                int imgW = base.ImageList.ImageSize.Width;
                int imgH = base.ImageList.ImageSize.Height;


                dottedImage = new Bitmap(imgW, imgH);
                Graphics g = Graphics.FromImage(dottedImage);

            }
                 * */
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            TreeNode tn = this.GetNodeAt(new Point(e.X, e.Y));
            if (tn != null)
            {
                int idx = tn.ImageIndex;
                if (Helper.InRange(idx, 0, specLib.Spectra.Count - 1))
                    specLib.DoEditSpectrum(idx);
            }
        }

        private void EditSelectedNodeName()
        {
            TreeNode tn = this.SelectedNode;
            if (tn != null)
                tn.BeginEdit();
        }
    }
}
