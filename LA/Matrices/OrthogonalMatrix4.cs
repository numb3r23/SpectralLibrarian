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
    public class OrthogonalMatrix4 : ProjectionMatrix4
    {

        public OrthogonalMatrix4()
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

        public OrthogonalMatrix4(double l, double r, double b, double t, double n, double f)
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
            SetIdentity();

            double xDelta = right - left;
            double yDelta = top - bottom;
            double zDelta = far - near;
            
            Vec4 sVec = new Vec4(2 / xDelta, 2/yDelta, 2/zDelta);
            Vec4 tVec = new Vec4(-((right + left) / xDelta), -((top + bottom) / yDelta), -((far + near) / zDelta));

            Set(new TranslateMatrix4(tVec) * new ScaleMatrix4(sVec));
        }

        public override string ToString()
        {
            return "Orthogonal";
        }


    }
}
