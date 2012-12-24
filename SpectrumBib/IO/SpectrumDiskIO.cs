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
using System.Text;

namespace SpectrumBib.IO
{
    public abstract class SpectrumDiskIO
    {
        protected Spectrum spectrum;
        [BrowsableAttribute(false)]
        public Spectrum Spectrum
        {
            get { return spectrum; }
            set { spectrum = value; }
        }

        protected String fname;
        [CategoryAttribute("ExportFile"), DescriptionAttribute("FileName Exporting-operations")]
        public String FileName
        {
            get { return fname; }
            set { fname = value; }
        }

        //static protected String extensions;
        [CategoryAttribute("ExportFile"), DescriptionAttribute("Extension supported")]
        public String Extensions
        {
            get { return ""; }
        }

        public SpectrumDiskIO()
        {
            spectrum = null;
        }

        public SpectrumDiskIO(Spectrum sp)
        {
            spectrum = new Spectrum(sp);
        }

        abstract public void WriteToDisk();
        abstract public void ReadFromDisk();
    }
}
