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
    public class Vec4
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

        private double w;
        public double W
        {
            get {return w;}
            set {w = value;}
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

        public int Wi
        {
            get { return (int)Math.Round(w); }
        }

        public Point Point
        {
            get { return new Point(Xi, Yi); }
        }

        public Size Size
        {
            get { return new Size(Xi, Yi); }
        }
        #endregion

        #region Konstruktoren
        public Vec4() 
        {
            Set(0, 0, 0, 0);
        }

        public Vec4(double all)
        {
            Set(all, all, all, all);
        }

        public Vec4(double x_, double y_)
        {
            Set(x_, y_, 0, 1);
        }

        public Vec4(Point p)
        {
            Set(p.X, p.Y, 0, 1);
        }

        public Vec4(double x_, double y_, double z_)
        {
            Set(x_, y_, z_, 1);
        }

        public Vec4(double x_, double y_, double z_, double w_)
        {
            Set(x_, y_, z_, w_);
        }

        public Vec4(Vec4 original)
        {
            Set(original.X, original.Y, original.Z, 1);
        }

        public Vec4(Collection<double> col)
        {
            if (col.Count == 3)
                Set(col[0], col[1], col[2]);
            if (col.Count == 4)
                if (col[3] != 0)
                    Set(col[0] / col[3], col[1] / col[3], col[2] / col[3]);
        }
        #endregion

        #region Operatoren
        public static Vec4 operator +(Vec4 a, Vec4 b)
        {
            return new Vec4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }

        public static Vec4 operator -(Vec4 a, Vec4 b)
        {
            return new Vec4(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }

        public static Vec4 operator *(Vec4 a, double s)
        {
            return new Vec4(a.X*s, a.Y*s, a.Z*s, a.W * s);
        }

        public static Vec4 operator *(double s, Vec4 a)
        {
            return new Vec4(a.X * s, a.Y * s, a.Z*s, a.W * s);
        }

        public static Vec4 operator /(Vec4 v, int a)
        {
            return new Vec4(v.Xi / a, v.Yi / a, v.Zi / a, v.Wi / a);
        }
        public static Vec4 operator %(Vec4 v, int a)
        {
            return new Vec4(v.Xi % a, v.Yi % a, v.Zi % a, v.Wi % a);
        }
        #endregion

        #region SetValues
        public void Set(double all)
        {
            x = all;
            y = all;
            z = all;
            w = all;
        }
        public void Set(double x_, double y_, double z_)
        {
            x = x_;
            y = y_;
            z = z_;
            w = 1;
        }

        public void Set(double x_, double y_, double z_, double w_)
        {
            x = x_;
            y = y_;
            z = z_;
            w = w_;
        }

        #endregion

        #region Operations
        public double GetLength()
        {
            return Math.Sqrt(x*x+y*y+z*z + w*w);
        }

        public Vec4 GetNormalized()
        {
            return new Vec4(this * (1/GetLength()));
        }

        public void DoNormalize()
        {
            double length = GetLength();
            Set(x / length, y / length, z/length, w/length);
        }

        public void Homogenize()
        {
            if (w != 0)
                Set(x / w, y / w, z / w, 1);
        }

        public double Dot(Vec4 b)
        {
            return b.X * x + b.Y * y + b.Z * z + b.W * w;
        }
        #endregion

        #region CheckEqual
        public bool EqualTo2D(Vec4 v)
        {
            return ((X == v.X) && (Y == v.Y));
        }
        public bool EqualTo3D(Vec4 v)
        {
            return ((X == v.X) && (Y == v.Y) && (Z == v.Z));
        }
        public bool EqualTo(Vec4 v)
        {
            return ((X == v.X) && (Y == v.Y) && (Z == v.Z) && (W == v.W));
        }
        #endregion

        public override string ToString()
        {
            return "Vektor: x=" + X.ToString() + ", y=" + Y.ToString() + ", z=" + Z.ToString() + ", w=" + W.ToString();
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
            res.Add(W);
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
    }
}
