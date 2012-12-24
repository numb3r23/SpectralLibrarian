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
    public class ProjectionMatrix4 : Matrix4
    {
        protected double left;
        [CategoryAttribute("X-Axis"), DescriptionAttribute("Left Clipping Parameter")]
        public double Left
        {
            get { return left; }
            set { left = value; Update(); }
        }

        protected double right;
        [CategoryAttribute("X-Axis"), DescriptionAttribute("Right Clipping Parameter")]
        public double Right
        {
            get { return right; }
            set { right = value; Update(); }
        }

        protected double bottom;
        [CategoryAttribute("Y-Axis"), DescriptionAttribute("Bottom Clipping Parameter")]
        public double Bottom
        {
            get { return bottom; }
            set { bottom = value; Update(); }
        }

        protected double top;
        [CategoryAttribute("Y-Axis"), DescriptionAttribute("Top Clipping Parameter")]
        public double Top
        {
            get { return top; }
            set { top = value; Update(); }
        }

        protected double near;
        [CategoryAttribute("Z-Axis"), DescriptionAttribute("Near Clipping Parameter")]
        public double Near
        {
            get { return near; }
            set { near = value; Update(); }
        }

        protected double far;
        [CategoryAttribute("Z-Axis"), DescriptionAttribute("Raf Clipping Parameter")]
        public double Far
        {
            get { return far; }
            set { far = value; Update(); }
        }

    }
}
