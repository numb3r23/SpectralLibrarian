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

    class RotateMatrix4 : Matrix4
    {
        private double factor = Math.PI / 180;

        private Axis axis;
        [CategoryAttribute("Rotation"), DescriptionAttribute("Axis to be rotated around")]
        public Axis RotationAxis
        {
            get { return axis; }
            set { axis = value; Update(); }
        }

        private double angle;
        [CategoryAttribute("Rotation"), DescriptionAttribute("Angle of rotation")]
        public double Angle
        {
            get { return angle; }
            set { angle = value; Update(); }

        }

        public RotateMatrix4()
        {
            init();

            axis = Axis.X;
            angle = 0;

            Update();
        }

        public RotateMatrix4(Axis axis_, double angle_)
        {
            init();

            axis = axis_;
            angle = angle_;

            Update();
        }

        override public void Update()
        {
            SetIdentity();

            double radAngle = angle * factor;
            double s = Math.Sin(radAngle);
            double c = Math.Cos(radAngle);
            switch (axis)
            {
                case Axis.X:
                    vals[1, 1] = c;
                    vals[2, 2] = c;
                    vals[1, 2] = s;
                    vals[2, 1] = -s;
                    break;
                case Axis.Y:
                    vals[0, 0] = c;
                    vals[2, 2] = c;
                    vals[0, 2] = -s;
                    vals[2, 0] = s;
                    break;
                case Axis.Z:
                    vals[0, 0] = c;
                    vals[1, 1] = c;
                    vals[0, 1] = s;
                    vals[1, 0] = -s;
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            /*
            String txt = "";
            switch (axis)
            {
                case Axis.X:
                    txt = "X";
                    break;
                case Axis.Y:
                    txt = "Y";
                    break;
                case Axis.Z:
                    txt = "Z";
                    break;
                default:
                    break;
            }
             */
            return "Rotation";
        }

    }
}
