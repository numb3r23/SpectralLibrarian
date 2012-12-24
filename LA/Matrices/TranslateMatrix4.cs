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
    public class TranslateMatrix4 : Matrix4
    {
        private double x;
        [CategoryAttribute("Translation"), DescriptionAttribute("Translation along X-Axis")]
        public double X
        {
            get { return x; }
            set { x = value; Update(); }
        }

        private double y;
        [CategoryAttribute("Translation"), DescriptionAttribute("Translation along Y-Axis")]
        public double Y
        {
            get { return y; }
            set { y = value; Update(); }
        }

        private double z;
        [CategoryAttribute("Translation"), DescriptionAttribute("Translation along Z-Axis")]
        public double Z
        {
            get { return z; }
            set { z = value; Update(); }
        }













        public TranslateMatrix4()
        {
            base.init();
            x = 0;
            y = 0;
            z = 0;
            Update();
        }

        public TranslateMatrix4(Vec4 v)
        {
            base.init();
            x = v.X;
            y = v.Y;
            z = v.Z;
            Update();
        }

        public TranslateMatrix4(double tX, double tY, double tZ)
        {
            base.init();

            x = tX;
            y = tY;
            z = tZ;

            Update();
        }

        override public void Update()
        {
            SetIdentity();

            vals[0, 3] = x;
            vals[1, 3] = y;
            vals[2, 3] = z;

        }

        public override string ToString()
        {
            return "Translation";
        }


    }
}
