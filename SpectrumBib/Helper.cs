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


namespace SpectrumBib
{
    public static class Helper
    {
        public static bool InRange(double val, double low, double high)
        {
            return ((val >= low) && (val <= high));
        }

        public static int Clip(int low, int value, int high)
        {
            return (value < low) ? low : (value > high) ? high : value;
        }

        public static String FormatDouble(double tmp)
        {
            return (Math.Round(tmp * 100) / 100).ToString();
        }

        public static String EnumToString(EAction action)
        {
            switch (action)
            {
                case EAction.None:
                    return "";
                case EAction.Moved:
                    return "Moved";
                case EAction.Added:
                    return "Added";
                case EAction.Deleted:
                    return "Deleted";
                default:
                    return "";
            }
        }

        public static String EnumToString(ESpectralInterpolation interpolation)
        {
            switch (interpolation)
            {
                case ESpectralInterpolation.Linear:
                    return "Linear";
                case ESpectralInterpolation.Peak:
                    return "Peak";
                default:
                    return "";
            }
        }

        public static String EnumToString(ESpectrumTemplate template)
        {
            switch (template)
            {
                case ESpectrumTemplate.Empty:
                    return "Empty";
                case ESpectrumTemplate.Visible:
                    return "Visible";
                case ESpectrumTemplate.ExtendedVisible:
                    return "Extended Visible";
                default:
                    return "";
            }
        }
    }
}
