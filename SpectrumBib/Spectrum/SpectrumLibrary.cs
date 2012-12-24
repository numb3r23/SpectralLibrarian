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

namespace SpectrumBib
{
    public class SpectrumLibraryEnumerator : IEnumerator
    {
        IEnumerator enumCategories;
        SpectrumLibrary specLib;

        public SpectrumLibraryEnumerator(SpectrumLibrary specLib_)
        {
            specLib = specLib_;
            enumCategories = specLib.Categories.Keys.GetEnumerator();
        }

        #region Enumerato
        public object Current
        {
            get
            {
                String category = (String)enumCategories.Current;
                return specLib.Category(category);
            }
        }

        public bool MoveNext()
        {
            return enumCategories.MoveNext();
        }

        public void Reset()
        {
            enumCategories.Reset();
        }
        #endregion

    }
    
    public class SpectrumLibrary : IEnumerable
    {
        public static Size SIZE_IMAGES_SMALL = new Size(16, 16);
        public static Size SIZE_IMAGES_LARGE = new Size(64, 64);
        
        #region properties
        private SpectrumList spectra;
        public SpectrumList Spectra
        {
            get { return spectra; }
        }

        //catgeroy --> ArrayList(idx1, idx2)
        private Hashtable categories;
        public Hashtable Categories
        {
            get { return categories; }
        }

        //category --> ArrayList(idx1, idx2)
        private Hashtable keywords;
        public Hashtable Keywords
        {
            get { return keywords; }
        }

        private ImageList imagesSmall;
        public ImageList ImagesSmall
        {
            get { return imagesSmall; }
        }

        private ImageList imagesLarge;
        public ImageList ImagesLarge
        {
            get { return imagesLarge; }
        }

        private SpectrumPainter specDrawer;

        [DefaultValue(typeof(Color), "Color.Black")]
        public Color BackColor
        {
            get { return specDrawer.BackColor; }
            set { specDrawer.BackColor = value; InvalidateImages(); }
        }

        [DefaultValue(typeof(Color), "Color.Red")]
        public Color SpectrumColor
        {
            get { return specDrawer.SpectrumColor; }
            set { specDrawer.SpectrumColor = value; InvalidateImages(); }
        }

        [DefaultValue(true)]
        public bool UseSpectralColors
        {
            get { return specDrawer.UseSpectralColors; }
            set { specDrawer.UseSpectralColors = value; InvalidateImages(); }
        }

        private Size imageSizeSmall = SpectrumLibrary.SIZE_IMAGES_SMALL;
        public Size ImageSizeSmall
        {
            get { return imageSizeSmall; }
            set { imageSizeSmall = value; }
        }

        private Size imageSizeLarge = SpectrumLibrary.SIZE_IMAGES_LARGE;
        public Size ImageSizeLarge
        {
            get { return imageSizeLarge; }
            set { imageSizeLarge = value; }
        }
	

        #endregion


        #region Constructors & init
        public SpectrumLibrary()
        {
            init();
        }

        private void init()
        {
            spectra = new SpectrumList();

            categories = new Hashtable();
            keywords = new Hashtable();

            imagesSmall = new ImageList();
            imagesSmall.ImageSize = imageSizeSmall;
            imagesLarge = new ImageList();
            imagesLarge.ImageSize = imageSizeLarge;

            specDrawer = new SpectrumPainter();
        }
        #endregion

        #region Invalidaters
        public void InvalidateImages()
        {
#pragma warning disable
            bool flag = false;
            if (spectra.Spectra.Count != imagesSmall.Images.Count)
            {
                imagesSmall.Images.Clear();
                imagesLarge.Images.Clear();
                flag = true;
            }

            foreach (Spectrum spec in spectra.Spectra)
            {
                imagesSmall.Images.Add(specDrawer.GetBitmap(spec, true, imageSizeSmall));
                imagesLarge.Images.Add(specDrawer.GetBitmap(spec, true, imageSizeLarge));
                spec.ImageIndex = imagesSmall.Images.Count - 1;
            }

            //if (flag)
                // TODO fire event to update ImageIndices!
        }
        #endregion

        #region Getters
        public int GetIndex(Spectrum spec)
        {
            return spectra.GetIndex(spec);
        }
        public Spectrum GetSpectrum(int idx)
        {
            if (Helper.InRange(idx, 0, spectra.Count - 1))
                return (Spectrum) spectra[idx];
            else
                return null;
        }
        public String GetCategory(Spectrum spec)
        {
            if (categories.ContainsKey(spec.Category))
                return spec.Category;
            else
            {
                int idx = GetIndex(spec);
                if (idx > -1)
                    foreach (String category in categories.Keys)
                        if (((ArrayList)categories[category]).Contains(idx))
                            return category;
                return "";
            }
        }
        #endregion

        #region SpectrumLists
        public void AddSpectrum(Spectrum spec, String category)
        {
            int idx = spectra.Add(spec);

            AddImages(idx, spec);
            spec.Category = category;

            SetCategory(idx, category);
            if (OnCategorySpectrumAdded != null)
                OnCategorySpectrumAdded(idx, spec, category);
        }

        public void AddSpectrum(Spectrum spec)
        {
            int idx = spectra.Add(spec);

            AddImages(idx, spec);

            if (spec.Category == "")
                spec.Category = "[blank]";

            SetCategory(idx, spec.Category);
            if (OnCategorySpectrumAdded != null)
                OnCategorySpectrumAdded(idx, spec, spec.Category);
        }

        public void RemoveSpectrum(Spectrum spec)
        {
            int idx = spectra.GetIndex(spec);

            if (OnPreSpectrumRemoved != null)
                OnPreSpectrumRemoved(idx);

            // TODO can be done via spectrum
            foreach (String category in categories.Keys)
            {
                if (((ArrayList)categories[category]).Contains(idx))
                {
                    ((ArrayList)categories[category]).Remove(idx);
                    if (OnSpectrumRemoved != null)
                        OnSpectrumRemoved(idx, category);
                }

            }
            spectra.Remove(spec);
            imagesSmall.Images.RemoveAt(idx);
            imagesLarge.Images.RemoveAt(idx);
        }

        /*
        public void UpdateSpectrum(Spectrum specOld, Spectrum specNew)
        {
            int idx = spectra.GetIndex(specOld);
            spectra.SetSpectrum(idx, specNew);

            // TODO can be done via spectrum
            foreach (String category in categories.Keys)
                if (((ArrayList)categories[category]).Contains(idx))
                    if (OnSpectrumModified != null)
                        OnSpectrumModified(idx, specNew, category);
        }
         * */
        #endregion

        #region Categories
        private void SetCategory(int idx, String category)
        {
            // TODO remove old Category assignement
            if (categories.ContainsKey(category))
                ((ArrayList)categories[category]).Add(idx);
            else
            {
                ArrayList sl = new ArrayList();
                sl.Add(idx);
                categories[category] = sl;
            }
        }

        private void RemoveCategory(int idx, String category)
        {
            // TODO hm - then there'd be a spectra without category?
            // category [unassigned]
            if (categories.ContainsKey(category))
                ((ArrayList)categories[category]).Remove(idx);
        }

        public void ChangeCategory(Spectrum spec, String categoryOld, String categoryNew)
        {
            // TODO edit spectrum also
            int idx = spectra.GetIndex(spec);
            RemoveCategory(idx, categoryOld);
            SetCategory(idx, categoryNew);

            if (OnSpectrumCategoryChanged != null)
                OnSpectrumCategoryChanged(idx, spec, categoryOld, categoryNew);
        }

        public void ChangeCategoryName(String categoryOld, String categoryNew)
        {
            // TODO edit spectrum also
            if (categories.ContainsKey(categoryOld))
            {
                categories[categoryNew] = categories[categoryOld];
                categories.Remove(categoryOld);

                if (OnCategoryRenamed != null)
                    OnCategoryRenamed(categoryOld, categoryNew);
            }
        }
        #endregion

        #region Images
        private void AddImages(int idx, Spectrum spec)
        {
            if (idx != imagesSmall.Images.Count)
                InvalidateImages();
            else
            {
                imagesSmall.Images.Add(specDrawer.GetBitmap(spec, true, imageSizeSmall));
                imagesLarge.Images.Add(specDrawer.GetBitmap(spec, true, imageSizeLarge));
                spec.ImageIndex = idx;
            }
        }

        private void UpdateImage(int idx, Spectrum spec)
        {
            if (Helper.InRange(idx, 0, imagesSmall.Images.Count - 1))
            {
                imagesSmall.Images[idx] = specDrawer.GetBitmap(spec, true, imageSizeSmall);
                imagesLarge.Images[idx] = specDrawer.GetBitmap(spec, true, imageSizeLarge);
            }
        }
        #endregion 

        #region IEnumerable
        public IEnumerator GetEnumerator()
        {
            return new SpectrumLibraryEnumerator(this);
        }

        public SpectrumList Category(String category)
        {
            SpectrumList sl = null;
            if (categories.ContainsKey(category))
            {
                sl = new SpectrumList();
                sl.Category = category;
                foreach (int idx in ((ArrayList) categories[category]))
                {
                    sl.Add(spectra[idx]);
                }
            }
            return sl;
        }
        #endregion

        #region Editing-/ViewingCallbacks
        public void DoEditSpectrum(Spectrum spec)
        {
            if (OnEditSpectrum != null)
            {
                int idx = GetIndex(spec);
                if (idx > -1)
                {
                    String category = GetCategory(spec);

                    OnEditSpectrum(idx, spec, category);
                }
            }
        }

        public void DoEditSpectrum(int idx)
        {
            if (OnEditSpectrum != null)
            {
                Spectrum spec = spectra[idx];
                if (spec != null)
                {
                    String category = GetCategory(spec);

                    OnEditSpectrum(idx, spec, category);
                }
            }
        }

        public void DoViewSpectrum(Spectrum spec)
        {
            if (OnViewSpectrum != null)
            {
                int idx = GetIndex(spec);
                if (idx > -1)
                {
                    String category = GetCategory(spec);

                    OnViewSpectrum(idx, spec, category);
                }
            }
        }

        public void DoViewSpectrum(int idx)
        {
            if (OnViewSpectrum != null)
            {
                Spectrum spec = spectra[idx];
                if (spec != null)
                {
                    String category = GetCategory(spec);

                    OnViewSpectrum(idx, spec, category);
                }
            }
        }
        #endregion

        #region Misc. Callbacks
        public void DoSpectrumModified(Spectrum spec)
        {
            if (OnSpectrumModified != null)
            {
                int idx = GetIndex(spec);
                if (idx > -1)
                {
                    String category = GetCategory(spec);

                    UpdateImage(idx, spec);

                    OnSpectrumModified(idx, spec, category);
                }
            }
        }
        #endregion

        #region Events
        //Spectrum Editing
        /*
        public delegate void SpectrumAdded(int idx, Spectrum spec, String category);
        public event SpectrumAdded OnSpectrumAdded;
        */
        //Category Editing
        public delegate void SpectrumModified(int idx, Spectrum spec, String category);
        public event SpectrumModified OnSpectrumModified;

        public delegate void SpectrumRemoved(int idx, String Category);
        public event SpectrumRemoved OnSpectrumRemoved;

        public delegate void CategorySpectrumAdded(int idx, Spectrum spec, String category);
        public event CategorySpectrumAdded OnCategorySpectrumAdded;

        public delegate void SpectrumCategoryChanged(int idx, Spectrum spec, String categoryOld, String categoryNew);
        public event SpectrumCategoryChanged OnSpectrumCategoryChanged;

        public delegate void CategoryRenamed(String categoryOld, String categoryNew);
        public event CategoryRenamed OnCategoryRenamed;

        //UI-Service
        public delegate void PreSpectrumRemoved(int idx);
        public event PreSpectrumRemoved OnPreSpectrumRemoved;

        //Interaction Events
        public delegate void EditSpectrum(int idx, Spectrum spec, String category);
        public event EditSpectrum OnEditSpectrum;

        public delegate void ViewSpectrum(int idx, Spectrum spec, String category);
        public event ViewSpectrum OnViewSpectrum;

        
        #endregion

        #region UI-Servicefunctions

        #endregion
    }
}