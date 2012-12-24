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
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace SpectrumWidgets
{
    public class ImportProperty
    {
        private Color bkgColor = Color.White;
        [CategoryAttribute("Graph"), DescriptionAttribute("Background Color")]
        public Color BackgroundColor
        {
            get { return bkgColor; }
            set { bkgColor = value; }
        }

        private Color graphColor = Color.Black;
        [CategoryAttribute("Graph"), DescriptionAttribute("Plot Color")]
        public Color GraphColor
        {
            get { return graphColor; }
            set { graphColor = value; }
        }

        private Image image;
        [CategoryAttribute("Graph"), DescriptionAttribute("GraphImage")]
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        private Point startPoint = new Point(-1, -1);
        [CategoryAttribute("Point"), DescriptionAttribute("Startpoint of Plot")]
        public Point StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        private Point endPoint = new Point(-1, -1);
        [CategoryAttribute("Point"), DescriptionAttribute("Endpoint of Plot")]
        public Point EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        private double lambdaStart = 380;
        [CategoryAttribute("Lambda"), DescriptionAttribute("Startpoint Wavelength [nm]")]
        public double StartLambda
        {
            get { return lambdaStart; }
            set { lambdaStart = value; }
        }

        private double lambdaEnd = 780;
        [CategoryAttribute("Lambda"), DescriptionAttribute("Endpoint Wavelength [nm]")]
        public double EndLambda
        {
            get { return lambdaEnd; }
            set { lambdaEnd = value; }
        }

        private double minIntensity = 0;
        [CategoryAttribute("Intensity"), DescriptionAttribute("Minimum Intensity")]
        public double MinIntensity
        {
            get { return minIntensity; }
            set { minIntensity = value; }
        }

        private double maxIntensity = 1;
        [CategoryAttribute("Intensity"), DescriptionAttribute("Maximum Intensity")]
        public double MaxIntensity
        {
            get { return maxIntensity; }
            set { maxIntensity = value; }
        }

        public ImportProperty()
        {
        }

        public void Reset()
        {
            startPoint = new Point(-1, -1);
            endPoint = new Point(-1, -1);
        }
    }
}
