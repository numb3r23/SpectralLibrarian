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
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

using LA;

namespace SpectrumBib
{
    //Source: http://www.easyrgb.com/index.php?X=MATH&H=15#text15
    public static class XYZ
    {
        public static Vec3 D50 = new Vec3(96.422, 100, 82.521);
        public static Vec3 D55 = new Vec3(95.682, 100, 92.149);
        public static Vec3 D65 = new Vec3(95.047, 100, 108.883);
        public static Vec3 D75 = new Vec3(94.972, 100, 122.638);

        public static Vec3 F2 = new Vec3(99.187, 100, 67.395);
    }
    public enum ECIEConverterLoadType
    {
        None, TextFile, Image
    }
    public class CIEConverter
    {
        private String fileName = "";
        public String FileName
        {
            get { return fileName; }
        }

        private ECIEConverterLoadType loadedType = ECIEConverterLoadType.None;
        public ECIEConverterLoadType LoadedType
        {
            get { return loadedType; }
        }

        static double[,] CIExyz = {{ 3.2406, -1.5372, -0.4986},
                                   {-0.9689,  1.8758,  0.0415},
                                   { 0.0557, -0.2040,  1.0570}};

        private double minLambda = 0;
        public double LambdaMin
        {
            get { return minLambda; }
        }

        private double maxLambda = 0;
        public double LambdaMax
        {
            get { return maxLambda; }
        }

        private double valueMin;
        public double ValueMin
        {
            get { return valueMin; }
            set { valueMin = value; }
        }

        private double valueMax;
        public double ValueMax
        {
            get { return valueMax; }
            set { valueMax = value; }
        }


        private double delta = 0;
        private double k = 0;
        private double ySum = 0;

        private Vec3[] values;
        public Vec3[] Values
        {
            get { return values; }
        }

        private Hashtable valuesHT;
        public Hashtable ValueHT
        {
            get { return valuesHT; }
        }
        
        public int ValuesCount
        {
            get { return (values == null) ? -1 : values.Length; }
        }

        
        #region Constructors
        public CIEConverter()
        {
        }
        public CIEConverter(String fname, ECIEConverterLoadType type)
        {
            LoadFile(fname, type);
        }
        #endregion

        #region Loaders
        public void LoadFile(String fname, ECIEConverterLoadType type)
        {
            loadedType = type;
            fileName = fname;
            switch (type)
            {
                case ECIEConverterLoadType.TextFile:
                    LoadFromTxtFile(fname);
                    break;
                case ECIEConverterLoadType.Image:
                    LoadFromImageFile(fname);
                    break;
                default:
                    break;
            }
        }

        public void LoadFromTxtFile(String fname)
        {
            TextReader tr = new StreamReader(fname);

            List<String[]> list = new List<String[]>();
            String line;
            while ((line = tr.ReadLine()) != null)
            {
                line = line.Replace(" ", "");
                line = line.Replace(',', ';');
                line = line.Replace(".", ",");
                String[] strValues = line.Split(';');
                if (strValues.Length > 3)
                    list.Add(strValues);
            }

            tr.Close();

            values = new Vec3[list.Count];
            valuesHT = new Hashtable();
            int counter = 0;
            foreach (String[] strValues in list)
            {
                
                double x = Double.Parse(strValues[1]);
                double y = Double.Parse(strValues[2]);
                double z = Double.Parse(strValues[3]);
                
                double min = Math.Min(Math.Min(x, y), z);
                double max = Math.Max(Math.Max(x, y), z);

                valueMin = (counter == 0) ? min : Math.Min(min, valueMin);
                valueMax = (counter == 0) ? max : Math.Max(max, valueMax);

                values[counter] = new Vec3(x, y, z);
                valuesHT[Double.Parse(strValues[0])] = new Vec3(x, y, z);
                if (counter == 0)
                    minLambda = Double.Parse(strValues[0]);
                if (counter == list.Count -1)
                    maxLambda = Double.Parse(strValues[0]);
                counter++;
            }
            delta = maxLambda - minLambda;

            CalculateK();
        }

        public void LoadFromImageFile(String fname)
        {
        }

        private void CalculateK()
        {
            //Adjust for OverbrightLighting Scenarios
            double maxBrightWhiteIntensity = 1;

            ySum = 0;

            for (double lambda = minLambda; lambda < maxLambda; lambda++)
                ySum += maxBrightWhiteIntensity * values[(int)Math.Round(lambda) - (int)minLambda].Y;

            k = 100 / ySum;
        }
        #endregion

        public Color SpectrumToColor(Spectrum spec)
        {
            Vec3 xyz = new Vec3();
            
            for (double lambda = spec.LambdaMin; lambda < spec.LambdaMax; lambda++)
                if ((lambda >= minLambda) && (lambda <= maxLambda))
                    xyz += spec.GetIntensity(lambda) * values[(int)Math.Round(lambda) - (int)minLambda];

            xyz *= k / 100.0;

            Vec3 rgb = new Vec3();
            
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    rgb[i] += xyz[j] * CIExyz[i, j];

            for (int i=0; i<3; i++)
                if ( rgb[i] > 0.0031308 ) 
                    rgb[i] = 1.055 * ( Math.Pow(rgb[i], ( 1 / 2.4 )) ) - 0.055;
                else                     
                    rgb[i] = 12.92 * rgb[i];

            rgb.Clip(0, 1);

            return rgb.GetColor(255);
        }

        #region Statics
        private static int ColorGamma(double rgb, double gamma, double sss)
        {
            int res = (int)(255 * Math.Pow(sss * rgb, gamma));
            res = (res < 0) ? 0 : res;
            res = (res > 255) ? 255 : res;
            return res;
        }

        public static Color WavelengthToRGB(double lambda)
        {
            double gamma = 0.8;

            double r = 0;
            double g = 0;
            double b = 0;
            if (lambda < 380)
                lambda = 380;
            if (lambda > 780)
                lambda = 780;
            if ((lambda >= 380) && (lambda <= 440))
            {
                r = -1 * (lambda - 440) / (440 - 380);
                g = 0;
                b = 1;
            }
            if ((lambda >= 440) && (lambda <= 490))
            {
                r = 0;
                g = (lambda - 440) / (490 - 440);
                b = 1;
            }
            if ((lambda >= 490) && (lambda <= 510))
            {
                r = 0;
                g = 1;
                b = -1 * (lambda - 440) / (510 - 490);
            }
            if ((lambda >= 510) && (lambda <= 580))
            {
                r = (lambda - 510) / (580 - 510);
                g = 1;
                b = 0;
            }
            if ((lambda >= 580) && (lambda <= 645))
            {
                r = 1;
                g = -1 * (lambda - 645) / (645 - 580);
                b = 0;
            }
            if ((lambda >= 645) && (lambda <= 780))
            {
                r = 1;
                g = 0;
                b = 0;
            }

            double sss = 1;
            if (lambda > 700)
                sss = 0.3 + 0.7 * (780 - lambda) / (780 - 700);
            if (lambda < 420)
                sss = 0.3 + 0.7 * (lambda - 380) / (420 - 380);

            return Color.FromArgb(255, ColorGamma(r, gamma, sss), ColorGamma(g, gamma, sss), ColorGamma(b, gamma, sss));
        }

        #endregion

    }
}
