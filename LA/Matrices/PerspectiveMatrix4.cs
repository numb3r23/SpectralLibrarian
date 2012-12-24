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
    public class PerspectiveMatrix4 : ProjectionMatrix4
    {
        public PerspectiveMatrix4()
        {
            init();

            left = -1;
            right = 1;
            bottom = -1;
            top = 1;
            near = 1;
            far = 10;

            Update();
        }

        public PerspectiveMatrix4(double l, double r, double b, double t, double n, double f)
        {
            init();

            left = l;
            right = r;
            bottom = b;
            top = t;
            near = n;
            far = f;

            Update();
        }

        override public void Update()
        {
            double dX = right - left;
            double dY = top - bottom;
            double dZ = far - near;


            Matrix4 p = new Matrix4();
            p.Vals[0, 0] = 2 * near / (dX);
            p.Vals[1, 1] = 2 * near / (dY);
            p.Vals[0, 2] = (left + right) / (dX);
            p.Vals[1, 2] = (top + bottom) / (dY);
            p.Vals[2, 2] = (far+near) / (dZ);
            p.Vals[3, 2] = 1;
            p.Vals[2, 3] = -2*far * near / (dZ);
            p.Vals[3, 3] = 0;

            Set(p);
        }

        public override string ToString()
        {
            return "Perspective";
        }

    }
}
