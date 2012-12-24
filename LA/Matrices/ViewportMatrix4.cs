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
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LA
{
    public class ViewportMatrix4: Matrix4
    {
        private double startX;
        [CategoryAttribute("Origin"), DescriptionAttribute("Top left Point.X")]
        public double StartX
        {
            get { return startX; }
            set { startX = value; Update(); }
        }

        private double startY;
        [CategoryAttribute("Origin"), DescriptionAttribute("Top left Point.Y")]
        public double StartY
        {
            get { return startY; }
            set { startY = value; Update(); }
        }

        private double sizeX;
        [ReadOnly(true), CategoryAttribute("Dimension"), DescriptionAttribute("Width of Viewport")]
        public double SizeX
        {
            get { return sizeX; }
            set { sizeX = value; Update(); }
        }

        private double sizeY;
        [ReadOnly(true), CategoryAttribute("Dimension"), DescriptionAttribute("Height of Viewport")]
        public double SizeY
        {
            get { return sizeY; }
            set { sizeY = value; Update(); }
        }

        public ViewportMatrix4(double startX_, double startY_, double sizeX_, double sizeY_)
        {
            init();

            startX = startX_;
            startY = startY_;
            sizeX = sizeX_;
            sizeY = sizeY_;

            Update();
        }

        override public void Update()
        {
            Matrix4 p = new Matrix4();

            double siX_half = sizeX / 2;
            double siY_half = sizeY / 2;

            p.Vals[0, 0] = siX_half;
            p.Vals[1, 1] = -siY_half;
            p.Vals[0, 2] = -startX;
            p.Vals[1, 2] = -startY;
            p.Vals[0, 3] = siX_half;
            p.Vals[1, 3] = siY_half;

            Set(p);

        }

        public override string ToString()
        {
            return "Viewport";
        }

    }
}
