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
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SpectrumBib.IO
{
    public class SpectrumXMLIO : SpectrumDiskIO
    {
        new public String Extensions
        {
            get { return "SpectrumXMLFile (*.xml)|*.xml"; }
        }

        public SpectrumXMLIO()
            :
            base()
        {
        }

        public SpectrumXMLIO(Spectrum sp)
            :
            base(sp)
        {
        }

        override public void WriteToDisk()
        {
            TextWriter tw = new StreamWriter(fname);
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(Spectrum));
                xs.Serialize(tw, spectrum);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
            }
            finally
            {
                tw.Close();
            }
        }

        override public void ReadFromDisk()
        {
            TextReader tr = new StreamReader(fname);
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(Spectrum));

                spectrum = (Spectrum)xs.Deserialize(tr);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            }
            finally
            {
                tr.Close();
            }
        }
    }
}
