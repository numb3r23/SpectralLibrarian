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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LA
{
    public class Vec3
    {
        #region Properties
        private double x;
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y;
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        private double z;
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public int Xi
        {
            get { return (int)Math.Round(x); }
        }

        public int Yi
        {
            get { return (int)Math.Round(y); }
        }

        public int Zi
        {
            get { return (int)Math.Round(z); }
        }

        public Point Point
        {
            get { return new Point(Xi, Yi); }
        }

        public Size Size
        {
            get { return new Size(Xi, Yi); }
        }

        public double this[int i]
        {
            get
            {
                return (i == 0)?X:((i==1)?Y:((i==2)?Z:-1));
            }
            set
            {
                if (i == 0) x = value;
                if (i == 1) y = value;
                if (i == 2) z = value;
            }
        }
        #endregion

        #region Konstruktoren
        public Vec3() 
        {
            Set(0, 0, 0);
        }

        public Vec3(double all)
        {
            Set(all, all, all);
        }

        public Vec3(double x_, double y_)
        {
            Set(x_, y_, 0);
        }

        public Vec3(Point p)
        {
            Set(p.X, p.Y, 0);
        }

        public Vec3(double x_, double y_, double z_)
        {
            Set(x_, y_, z_);
        }

        public Vec3(Vec3 original)
        {
            Set(original.X, original.Y, original.Z);
        }

        public Vec3(Collection<double> col)
        {
            if (col.Count == 3)
                Set(col[0], col[1], col[2]);
        }
        #endregion

        #region Operatoren
        public static Vec3 operator +(Vec3 a, Vec3 b)
        {
            return new Vec3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vec3 operator -(Vec3 a, Vec3 b)
        {
            return new Vec3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vec3 operator *(Vec3 a, double s)
        {
            return new Vec3(a.X*s, a.Y*s, a.Z*s);
        }

        public static Vec3 operator *(double s, Vec3 a)
        {
            return new Vec3(a.X * s, a.Y * s, a.Z*s);
        }

        public static Vec3 operator /(Vec3 v, int a)
        {
            return new Vec3(v.Xi / a, v.Yi / a, v.Zi / a);
        }
        public static Vec3 operator /(Vec3 v, double a)
        {
            return new Vec3(v.X / a, v.Y / a, v.Z / a);
        }
        public static Vec3 operator %(Vec3 v, int a)
        {
            return new Vec3(v.Xi % a, v.Yi % a, v.Zi % a);
        }
        #endregion

        #region SetValues
        public void Set(double all)
        {
            x = all;
            y = all;
            z = all;
        }
        public void Set(double x_, double y_, double z_)
        {
            x = x_;
            y = y_;
            z = z_;
        }

        #endregion

        #region Operations
        public double GetLength()
        {
            return Math.Sqrt(x*x+y*y+z*z);
        }

        public Vec3 GetNormalized()
        {
            return new Vec3(this * (1/GetLength()));
        }

        public void DoNormalize()
        {
            double length = GetLength();
            Set(x / length, y / length, z/length);
        }

        public double Dot(Vec3 b)
        {
            return b.X * x + b.Y * y + b.Z * z;
        }

        public void Clip(double min, double max)
        {
            for (int i = 0; i < 3; i++)
                this[i] = (this[i] > max) ? max : ((this[i] < min) ? min : this[i]);
        }
        #endregion

        #region CheckEqual
        public bool EqualTo2D(Vec3 v)
        {
            return ((X == v.X) && (Y == v.Y));
        }
        public bool EqualTo3D(Vec3 v)
        {
            return ((X == v.X) && (Y == v.Y) && (Z == v.Z));
        }
        #endregion

        public override string ToString()
        {
            return "Vektor: x=" + X.ToString() + ", y=" + Y.ToString() + ", z=" + Z.ToString();
        }

        public String ToStringVec2()
        {
            return "(" + X.ToString() + ", " + Y.ToString() + ")";
        }

        public Point ToPoint()
        {
            return new Point((int)Math.Round(x), (int)Math.Round(y));
        }

        internal Collection<double> GetCollection()
        {
            Collection<double> res = new Collection<double>();
            res.Add(X);
            res.Add(Y);
            res.Add(Z);
            return res;
        }

        public Point GetPoint()
        {
            return new Point((int)X, (int)Y);
        }

        public Point GetPoint(int totalHeight)
        {
            return new Point((int)X, totalHeight - (int)Y);
        }

        public Color GetColor(double scale)
        {
            return Color.FromArgb((byte)(x * scale), (byte)(y * scale), (byte)(z * scale));
        }
    }
}
