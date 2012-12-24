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
using System.Collections;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace SpectrumBib
{
    [Serializable()]
    [XmlRoot("SpectrumList")]
    public class SpectrumList : ISerializable
    {
        // TODO SpectrumList - remove .Get(idx)
        /*
        private ArrayList spectra;
        [XmlArray("Spectra"), XmlArrayItem("Spectrum",typeof(Spectrum))]
        public ArrayList Spectra
        {
            get { return spectra; }
        }
        */

        private SpectrumCollection spectra;

        public SpectrumCollection Spectra
        {
            get { return spectra; }
            set { spectra = value; }
        }
	
        private String category;

        public String Category
        {
            get { return category; }
            set { category = value; }
        }

        public int Count
        {
            get { return spectra.Count; }
        }

        public Spectrum this[int idx]
        {
            get {
                if (spectra != null)
                    if (Helper.InRange(idx, 0, spectra.Count))
                        return (Spectrum) spectra[idx];
                return null;
            }
        }
	

        #region Constructors
        public SpectrumList()
        {
            spectra = new SpectrumCollection();
        }

        public SpectrumList(IList list)
        {
            spectra = new SpectrumCollection(list);
        }

        public SpectrumList(SpectrumList specList)
        {
            category = specList.Category;

            spectra = new SpectrumCollection();
            foreach (Spectrum spec in specList.Spectra)
                spectra.Add(spec);
        }

        public SpectrumList(ArrayList list)
        {
            spectra = new SpectrumCollection(list);
        }

        public SpectrumList(SerializationInfo info, StreamingContext ctxt)
        {
            this.spectra = (SpectrumCollection)info.GetValue("Spectra", typeof(SpectrumCollection));
        }
        #endregion

        public void GetObjectData(SerializationInfo info,
                                StreamingContext ctxt)
        {
            info.AddValue("Spectra", this.spectra);
        }

        #region Management
        public int Add(Spectrum spec)
        {
            spectra.Add(spec);
            int idx = spectra.IndexOf(spec);
            if (OnSpectrumAdded != null)
                OnSpectrumAdded(idx, spec);
            return idx;
        }

        public bool Contains(Spectrum spec)
        {
            return spectra.Contains(spec);
        }

        public void Remove(Spectrum spec)
        {
            if (spectra.Contains(spec))
                RemoveAt(spectra.IndexOf(spec));
        }

        public void RemoveAt(int idx)
        {
            if (Helper.InRange(idx, 0, spectra.Count - 1))
            {
                spectra.RemoveAt(idx);
                if (OnSpectrumDeleted != null)
                    OnSpectrumDeleted(idx);
            }
        }

        public int GetIndex(Spectrum spec)
        {
            return spectra.IndexOf(spec);
        }

        public void SetSpectrum(int idx, Spectrum spec)
        {
            if (Helper.InRange(idx, 0, spectra.Count - 1))
            {
                spectra[idx] = spec;
                if (OnSpectrumModified != null)
                    OnSpectrumModified(idx, spec);
            }
        }
        #endregion

        #region Events
        public delegate void SpectrumAdded(int idx, Spectrum spec);
        public event SpectrumAdded OnSpectrumAdded;

        public delegate void SpectrumDeleted(int idx);
        public event SpectrumDeleted OnSpectrumDeleted;

        public delegate void SpectrumModified(int idx, Spectrum spec);
        public event SpectrumModified OnSpectrumModified;
        #endregion
    }
}
