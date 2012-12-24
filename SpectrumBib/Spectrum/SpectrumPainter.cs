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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Text;

namespace SpectrumBib
{
    //TODO: SpectrumPainter - Use Gradient
    public class SpectrumPainter
    {

        #region Properties
        private Brush brushBack;
        private Color colBack;
        [DefaultValue(typeof(Color), "Color.Black")]
        public Color BackColor
        {
            get { return colBack; }
            set { CreateBrushBack(value); }
        }

        private Pen penSpectrum;
        private Color colSpectrum;
        [DefaultValue(typeof(Color), "Color.Red")]
        public Color SpectrumColor
        {
            get { return colSpectrum; }
            set { CreatePenSpectrum(value); }
        }

        private bool useSpectralColors = true;
        [DefaultValue(true)]
        public bool UseSpectralColors
        {
            get { return useSpectralColors; }
            set { useSpectralColors = value; }
        }

        private bool filledGraph;

        public bool FilledGraph
        {
            get { return filledGraph; }
            set { filledGraph = value; }
        }
	

        #endregion

        public SpectrumPainter()
        {
            CreateBrushBack(Color.Black);
            CreatePenSpectrum(Color.Red);
        }

        #region Setters
        private void CreateBrushBack(Color col)
        {
            colBack = col;
            brushBack = new SolidBrush(col);
        }

        private void CreatePenSpectrum(Color col)
        {
            colSpectrum = col;
            penSpectrum = new Pen(colSpectrum);
        }
        #endregion

        #region Drawings
        public Bitmap GetBitmap(Spectrum spec, bool background, Size size)
        {
            return GetBitmap(spec, background, size.Width, size.Height);
        }

        public Bitmap GetBitmap(Spectrum spec, bool background, int width, int height)
        {
            if ((width <= 0) || (height <= 0))
                return null;
            else
            {
                Bitmap image = new Bitmap(width, height);
                if (background)
                    ((Graphics) Graphics.FromImage(image)).FillRectangle(brushBack, 0,0,width, height);
                if (spec != null)
                {
                    switch (spec.Interpolation)
                    {
                        case ESpectralInterpolation.Linear:
                            return DrawSpectrumCurve(spec, image, width, height);
                        case ESpectralInterpolation.Peak:
                            return DrawSpectrumPeak(spec, image, width, height);
                        default:
                            break;
                    }
                }
                return image;
            }
        }

        private Bitmap DrawSpectrumPeak(Spectrum spectrum, Bitmap image, int width_, int height_)
        {
            double width = (double) width_;
            double height = (double) height_;

            width -= 2;
            height -= 2;

            if (spectrum.HasSpectralPoints)
            {
                double minLambda = spectrum.LambdaMin;
                double maxLambda = spectrum.LambdaMax;

                double scale = (maxLambda - minLambda) / width;

                double lambda;
                int y;
                int baseY = Helper.Clip(0, (int)((1 - spectrum.BaseIntensity) * height), height_);

                for (int xx = 0; xx < width; xx++)
                {
                    
                    lambda = xx * scale + minLambda;
                    if (useSpectralColors)
                        image.SetPixel(xx, baseY, CIEConverter.WavelengthToRGB(lambda));
                    else
                        image.SetPixel(xx, baseY, colSpectrum);
                }
                foreach (SpectralPoint sp in spectrum.Points)
                {
                    int xx = Helper.Clip(0,(int)Math.Round((sp.Lambda - minLambda) / scale), width_);

                    y = (int)((1 - sp.Intensity) * height);
                    y = Helper.Clip(0, y, height_);
                    
                    for (int yy = Math.Min(y,baseY); yy < Math.Max(y, baseY); yy++)
                        if (useSpectralColors)
                            image.SetPixel(xx, yy, CIEConverter.WavelengthToRGB(sp.Lambda));
                        else
                            image.SetPixel(xx, yy, colSpectrum);
                }
            }
            return image;
        }

        private Bitmap DrawSpectrumPeak_orig(Spectrum spectrum, Bitmap image, int width_, int height_)
        {
            double width = (double)width_;
            double height = (double)height_;

            width -= 2;
            height -= 2;

            if (spectrum.HasSpectralPoints)
            {
                double minLambda = spectrum.LambdaMin;
                double maxLambda = spectrum.LambdaMax;

                double scale = (maxLambda - minLambda) / width;

                double lambda;
                int y;

                for (int xx = 0; xx < width; xx++)
                {

                    lambda = xx * scale + minLambda;
                    y = (int)((1 - spectrum.GetIntensity(lambda)) * height);
                    y = Helper.Clip(0, y, height_);
                    for (int yy = y; yy < height; yy++)
                    {
                        if (useSpectralColors)
                            image.SetPixel(xx, yy, CIEConverter.WavelengthToRGB(lambda));
                        else
                            image.SetPixel(xx, yy, colSpectrum);
                    }
                }
            }
            return image;
        }

        private Bitmap DrawSpectrumCurve(Spectrum spectrum, Bitmap image, int width_, int height_)
        {
            double width = (double)width_;
            double height = (double)height_;
            width -= 2;
            height -= 2;
            Color col = Color.Black;

            if (spectrum.HasSpectralPoints)
            {
                double minLambda = spectrum.LambdaMin;
                double maxLambda = spectrum.LambdaMax;

                double scale = (maxLambda - minLambda) / width;

                double lambda;
                int y;

                for (int xx = 0; xx < width; xx++)
                {
                    lambda = xx * scale + minLambda;

                    y = (int)((1 - spectrum.GetIntensity(lambda)) * height);
                    y = Helper.Clip(0, y, (int)height);
					y = Math.Max(0, y);

                    col = (useSpectralColors) ? CIEConverter.WavelengthToRGB(lambda) : colSpectrum;

                    if (filledGraph)
                        for (int yy = Math.Min(y, image.Height); yy < Math.Max(y, image.Height); yy++)
                            image.SetPixel(xx, yy, col);
                    else{
						System.Console.WriteLine(xx + ", " + y);
                        	image.SetPixel(xx, y, col);
					}
                }
            }
            return image;
        }

        private Bitmap DrawSpectrumCurve_gradient(Spectrum spectrum, Bitmap image, int width_, int height_)
        {
            double width = (double)width_;
            double height = (double)height_;
            width -= 2;
            height -= 2;

            if (spectrum.HasSpectralPoints)
            {
                double minLambda = spectrum.LambdaMin;
                double maxLambda = spectrum.LambdaMax;

                double scale = (maxLambda - minLambda) / width;

                int y;

                for (int i = 0; i < spectrum.PointsCount - 1; i++)
                {
                    SpectralPoint sp1 = spectrum.Points[i];
                    SpectralPoint sp2 = spectrum.Points[i + 1];

                    Point p1 = new Point();
                    p1.X = Helper.Clip(0, (int)Math.Round((sp1.Lambda - minLambda) / scale), width_);
                    p1.Y = Helper.Clip(0, (int)((1 - sp1.Intensity) * height), height_);

                    Point p2 = new Point();
                    p2.X = Helper.Clip(0, (int)Math.Round((sp2.Lambda - minLambda) / scale), width_);
                    p2.Y = Helper.Clip(0, (int)((1 - sp2.Intensity) * height), height_);


                }
                foreach (SpectralPoint sp in spectrum.Points)
                {
                    int xx = Helper.Clip(0, (int)Math.Round((sp.Lambda - minLambda) / scale), width_);

                    y = (int)((1 - sp.Intensity) * height);
                    y = Helper.Clip(0, y, height_);
					y = Math.Max(0, y);
				}
            }
            return image;
        }
        #endregion
    }
}
