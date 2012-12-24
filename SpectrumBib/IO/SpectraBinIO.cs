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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SpectrumBib.IO
{
    public class SpectraBinIO : SpectraDiskIO
    {
        new public String Extensions
        {
            get { return "SpectrumListFile (*.spa)|*.spa"; }
        }

        public SpectraBinIO()
            :
            base()
        {
        }

        public SpectraBinIO(SpectrumList specList)
            :
            base(specList)
        {
        }

        override public void WriteToDisk()
        {
            FileStream fs = new FileStream(fname, FileMode.Create);
            try
            {
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(fs, new SpectrumList(spectra));
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        override public void ReadFromDisk()
        {
            SpectrumList lSpectra = null;

            FileStream fs = new FileStream(fname, FileMode.Open);
            try
            {
                BinaryFormatter b = new BinaryFormatter();

                lSpectra = (SpectrumList)b.Deserialize(fs);
                spectra = new SpectrumList(lSpectra);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
