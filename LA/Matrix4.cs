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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LA
{
    public enum Axis
    {
        X = 0, Y = 1, Z = 2
    }
    public class Matrix4
    {
        
        #region Properties
        
        //[y, x]
        protected double[,] vals;
        [BrowsableAttribute(false)]
        public double[,] Vals
        {
            get { return vals; }
        }
        #endregion

        #region Konstruktoren
        public Matrix4()
        {
            init();
            SetIdentity();
        }

        public Matrix4(Matrix4 m)
        {
            init();
            Set(m.Vals);
        }

        public Matrix4(double[,] vals_)
        {
            init();
            Set(vals_);
        }

        #endregion

        protected void init()
        {
            vals = new double[4, 4];
        }

        #region Setters
        protected void Set(Matrix4 m)
        {
            Set(m.Vals);
        }

        protected void Set(double[,] vals_)
        {
            for (int xx = 0; xx < 4; xx++)
                for (int yy = 0; yy < 4; yy++)
                    vals[yy, xx] = vals_[yy, xx];

        }

        public void SetIdentity()
        {
            for (int xx = 0; xx < 4; xx++)
                for (int yy = 0; yy < 4; yy++)
                    vals[yy, xx] = xx == yy ? 1 : 0;
        }
        #endregion


        #region Operatoren
        public static Vec4 operator *(Matrix4 m, Vec4 v)
        {
            Collection<double> res = new Collection<double>();
            Collection<double> vCol = v.GetCollection();

            for (int i = 0; i < 4; i++)
            {
                Collection<double> mCol = m.GetRow(i);
                double tmp = 0;
                for (int j = 0; j < 4; j++)
                    tmp += mCol[j] * vCol[j];
                res.Add(tmp);
            }

            // Und da der Vektor hier nicht unbedingt homogenisiert ist, holen wir das einfach nach
            Vec4 tmpVec = new Vec4(res);
            if (tmpVec.W != 0)
                tmpVec.Homogenize();
            return tmpVec;
        }

        public static Matrix4 operator *(Matrix4 mA, Matrix4 mB)
        {
            double[,] res = new double[4, 4];
            int counter = 0;
            foreach (double val in res)
            {
                int xx = counter % 4;
                int yy = counter / 4;

                Collection<double> mRow = mA.GetRow(yy);
                Collection<double> mCol = mB.GetCol(xx);

                double tmp = 0;
                for (int j = 0; j < 4; j++)
                    tmp += mRow[j] * mCol[j];

                res[yy, xx] = tmp;
                counter++;
            }


            return new Matrix4(res);
        }
        #endregion

        #region Collections
        public Collection<double> GetRow(int m)
        {
            Collection<double> res = new Collection<double>();
            for (int i = 0; i < 4; i++)
                res.Add(vals[m, i]);
            return res;
        }

        public Collection<double> GetCol(int n)
        {
            Collection<double> res = new Collection<double>();
            for (int i = 0; i < 4; i++)
                res.Add(vals[i, n]);
            return res;
        }
        #endregion

        public override string ToString()
        {
            String txt = "";
            int counter = 0;
            foreach (double val in vals)
            {
                txt += val.ToString() + " ";
                if (((counter % 4) == 3) && (counter < 15))
                    txt += "\n";
                counter++;
            }
            return txt;
        }

        public string GetStringMatrix()
        {
            String txt = "";
            int counter = 0;
            foreach (double val in vals)
            {
                txt += val.ToString() + " ";
                if (((counter % 4) == 3) && (counter < 15))
                    txt += "\n";
                counter++;
            }
            return txt;
        }

        public virtual void Update()
        {
        }
    }
}