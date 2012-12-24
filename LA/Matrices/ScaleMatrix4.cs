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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LA
{
    class ScaleMatrix4 : Matrix4
    {
        private double x;
        [CategoryAttribute("Scaling"), DescriptionAttribute("Scaling along X-Axis")]
        public double X
        {
            get { return x; }
            set { x = value; Update(); }
        }

        private double y;
        [CategoryAttribute("Scaling"), DescriptionAttribute("Scaling along Y-Axis")]
        public double Y
        {
            get { return y; }
            set { y = value; Update(); }
        }

        private double z;
        [CategoryAttribute("Scaling"), DescriptionAttribute("Scaling along Z-Axis")]
        public double Z
        {
            get { return z; }
            set { z = value; Update(); }
        }

        public ScaleMatrix4()
        {
            base.init();

            x = 1;
            y = 1;
            z = 1;

            Update();
        }

        public ScaleMatrix4(Vec4 v)
        {
            base.init();

            x = v.X;
            y = v.Y;
            z = v.Z;

            Update();
        }
        public ScaleMatrix4(double sX, double sY, double sZ)
        {
            base.init();

            x = sX;
            y = sY;
            z = sZ;

            Update();
        }

        override public void Update()
        {
            SetIdentity();

            vals[0, 0] = x;
            vals[1, 1] = y;
            vals[2, 2] = z;
        }

        public override string ToString()
        {
            return "Scaling";
        }


    }
}
