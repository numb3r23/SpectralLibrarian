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
using System.Text;
using System.Drawing;

namespace SpectrumBib.IO
{
    public class SpectraTextureIO : SpectraDiskIO
    {
        #region Enums
        public enum ESpectralWidth
        {
            FullSpectrum, Visible, ExtendedVisible
        }
        public enum EColorChannels
        {
            RGB=3, RGBA=4
        }
        public enum EUndefinedArea
        {
            Static_1, Static_0
        }
        public enum ETextureSize
        {
            s128=128, s256=256, s512=512, s1024=1024, s2048=2048
        }
        public enum EUnusedSpectra
        {
            Repeat,Black,Gray,White
        }
        #endregion

        new public String Extensions
        {
            get { return "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png"; }
        }

        #region Properties
        private ESpectralWidth spectralWidth;
        [CategoryAttribute("Spectrum Sampling"), DescriptionAttribute("Wavelengths to export")]
        public ESpectralWidth SpectralWidth
        {
            get { return spectralWidth; }
            set { spectralWidth = value; }
        }

        private EUndefinedArea undefinedArea;
        [CategoryAttribute("Spectrum Sampling"), DescriptionAttribute("How to process undefined Wavelengths")]
        public EUndefinedArea UndefinedArea
        {
            get { return undefinedArea; }
            set { undefinedArea = value; }
        }

        private EColorChannels colorChannels;
        [CategoryAttribute("Texture Parameters"), DescriptionAttribute("ColorChannels of Texture")]
        public EColorChannels ColorChannels
        {
            get { return colorChannels; }
            set { colorChannels = value; }
        }

        private ETextureSize textureWidth;
        [CategoryAttribute("Texture Parameters"), DescriptionAttribute("Texture Widths")]
        public ETextureSize TextureWidth
        {
            get { return textureWidth; }
            set { textureWidth = value; }
        }

        private ETextureSize textureHeight;
        [CategoryAttribute("Texture Parameters"), DescriptionAttribute("Texture Heights")]
        public ETextureSize TextureHeight
        {
            get { return textureHeight; }
            set { textureHeight = value; }
        }

        private int spectraPerWidth;
        [CategoryAttribute("Texture Parameters"), DescriptionAttribute("Spectra per Width")]
        public int SpectraPerWidth
        {
            get { return spectraPerWidth; }
            set { spectraPerWidth = value; }
        }

        private EUnusedSpectra unusedSpectra;
        [CategoryAttribute("Texture Parameters"), DescriptionAttribute("Deal with unused Spectra space")]
        public EUnusedSpectra UnusedSpectra
        {
            get { return unusedSpectra; }
            set { unusedSpectra = value; }
        }

        [CategoryAttribute("Texture Parameters"), DescriptionAttribute("Samples taken per Spectrum")]
        public int SamplesPerSpectrum
        {
            get { return ((int)textureWidth * (int)colorChannels) / spectraPerWidth; }
        }

        private ELaserSampleMode laserSampleMode;
        [CategoryAttribute("Laser Sample Mode"), DescriptionAttribute("How to Handle single Wavelengths")]
        public ELaserSampleMode LaserSamples
        {
            get { return laserSampleMode; }
            set { laserSampleMode = value; }
        }
        #endregion

        public SpectraTextureIO()
            :
            base()
        {
            init();
        }

        public SpectraTextureIO(SpectrumList specList)
            :
            base(specList)
        {
            init();
        }

        private void init()
        {
            spectralWidth = ESpectralWidth.ExtendedVisible;
            undefinedArea = EUndefinedArea.Static_0;
            colorChannels = EColorChannels.RGBA;
            textureWidth = ETextureSize.s512;
            textureHeight = ETextureSize.s512;
            spectraPerWidth = 4;
            unusedSpectra = EUnusedSpectra.Black;
            laserSampleMode = ELaserSampleMode.BoxFilter;
        }


        override public void WriteToDisk()
        {
            Bitmap saveBMP = GenerateOutput();
            saveBMP.Save(fname);
        }

        override public void ReadFromDisk()
        {
        }

        public Bitmap GenerateOutput()
        {
            Bitmap saveBMP = new Bitmap((int)textureWidth, (int)textureHeight);

            //First get the Wavelengths which are analyzed
            double minL = 0;
            double maxL = 0;
            switch (spectralWidth)
            {
                case ESpectralWidth.FullSpectrum:
                    minL = spectra[0].LambdaMin;
                    maxL = spectra[0].LambdaMax;
                    foreach (Spectrum spectrum in Spectra.Spectra)
                    {
                        minL = Math.Min(spectrum.LambdaMin, minL);
                        maxL = Math.Max(spectrum.LambdaMax, maxL);
                    }
                    break;
                case ESpectralWidth.Visible:
                    minL = 380;
                    maxL = 780;
                    break;
                case ESpectralWidth.ExtendedVisible:
                    minL = 324;
                    maxL = 836;
                    break;
                default:
                    break;
            }

            //Now calculate the sampling
            int samplesCount = SamplesPerSpectrum;
            double delta = (maxL - minL) / samplesCount;
            double intensity = 0;
            byte[,] temp = new byte[Spectra.Spectra.Count, samplesCount+1];

            bool firstRun = true;

            int xx = 0;
            int yy = 0;

            byte R = 0;
            byte G = 0;
            byte B = 0;
            byte A = 255;
            byte value = 0;

            double lambda;

            while (yy < (int)textureHeight)
            {
                if (!firstRun)
                    if (unusedSpectra != EUnusedSpectra.Repeat)
                        break;
                for (int idxSpectrum = 0; idxSpectrum < Spectra.Spectra.Count; idxSpectrum++)
                {
                    Spectrum spectrum = Spectra.Spectra[idxSpectrum];
                    lambda = minL;
                    for (int iSample = 0; iSample <= samplesCount; iSample++)
                    {
                        if (firstRun)
                        {
                            if ((lambda >= spectrum.LambdaMin) && (lambda <= spectrum.LambdaMax))

                                intensity = spectrum.GetIntensity(lambda, delta, laserSampleMode);
                            else
                                switch (undefinedArea)
                                {
                                    case EUndefinedArea.Static_1:
                                        intensity = 1;
                                        break;
                                    case EUndefinedArea.Static_0:
                                        intensity = 0;
                                        break;
                                    default:
                                        intensity = 0;
                                        break;
                                }
                            value = (byte)(intensity * 255);
                            temp[idxSpectrum, iSample] = value;
                        }
                        else
                            value = temp[idxSpectrum, iSample];

                        switch (iSample % (int)colorChannels)
                        {
                            case 0:
                                if (iSample > 0)
                                {
                                    saveBMP.SetPixel(xx, yy, Color.FromArgb(A, R, G, B));
                                    xx++;
                                    if (xx >= (int)textureWidth)
                                    {
                                        xx = 0;
                                        yy++;
                                        if (yy >= (int)textureHeight)
                                            break;
                                    }
                                }
                                R = value;
                                break;
                            case 1:
                                G = value;
                                break;
                            case 2:
                                B = value;
                                break;
                            case 3:
                                A = value;
                                break;
                            default:
                                break;

                        }
                        lambda += delta;
                    }
                    if (yy >= (int)textureHeight)
                        break;
                }
                firstRun = false;
                //Now do the FillUp part...
                if (unusedSpectra != EUnusedSpectra.Repeat)
                {
                    switch (unusedSpectra)
                    {
                        case EUnusedSpectra.Black:
                            R = 0;
                            G = 0;
                            B = 0;
                            A = 0;
                            break;
                        case EUnusedSpectra.Gray:
                            R = 127;
                            G = 127;
                            B = 127;
                            A = 127;
                            break;
                        case EUnusedSpectra.White:
                            R = 255;
                            G = 255;
                            B = 255;
                            A = 255;
                            break;
                        case EUnusedSpectra.Repeat:
                            break;
                        default:
                            break;
                    }
                    while (yy < (int)textureHeight)
                    {
                        saveBMP.SetPixel(xx, yy, Color.FromArgb(A, R, G, B));
                        xx++;
                        if (xx >= (int)textureWidth)
                        {
                            xx = 0;
                            yy++;
                        }
                    }
                }
            }
            return saveBMP;
        }

    }
}
