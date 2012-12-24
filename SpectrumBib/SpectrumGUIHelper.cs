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
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SpectrumBib
{
    public class SpectrumGUIHelper
    {
        public static Size SIZE_SMALL = new Size(16, 16);
        public static Size SIZE_LARGE = new Size(64, 64);

        public static ListViewItem CreateListViewItem(Spectrum spec)
        {
            ListViewItem lvi = new ListViewItem(spec.Name);
            lvi.SubItems.Add(Helper.FormatDouble(spec.LambdaMin));
            lvi.SubItems.Add(Helper.FormatDouble(spec.LambdaMax));
            lvi.SubItems.Add(Helper.FormatDouble(spec.PointsCount));
            lvi.SubItems.Add(Helper.EnumToString(spec.Interpolation));
            lvi.SubItems.Add(Helper.FormatDouble(spec.BaseIntensity));
            lvi.SubItems.Add(Helper.FormatDouble(spec.IntensityMin));
            lvi.SubItems.Add(Helper.FormatDouble(spec.IntensityMax));

            lvi.ImageIndex = spec.ImageIndex;

            return lvi;
        }

        public static void UpdateListViewItem(ListViewItem lvi, Spectrum spec)
        {
            lvi.SubItems[0].Text = spec.Name;
            lvi.SubItems[1].Text = Helper.FormatDouble(spec.LambdaMin);
            lvi.SubItems[2].Text = Helper.FormatDouble(spec.LambdaMax);
            lvi.SubItems[3].Text = Helper.FormatDouble(spec.PointsCount);
            lvi.SubItems[4].Text = Helper.EnumToString(spec.Interpolation);
            lvi.SubItems[5].Text = Helper.FormatDouble(spec.BaseIntensity);
            lvi.SubItems[6].Text = Helper.FormatDouble(spec.IntensityMin);
            lvi.SubItems[7].Text = Helper.FormatDouble(spec.IntensityMax);
        }

    }
}
