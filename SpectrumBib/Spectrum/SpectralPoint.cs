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
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace SpectrumBib
{
    public class SpectralPointWavelength : IComparer<SpectralPoint>
    {
        public int Compare(SpectralPoint spA, SpectralPoint spB)
        {
            if (spA.Lambda < spB.Lambda)
                return -1;
            else if (spA.Lambda == spB.Lambda)
                return 0;
            else
                return 1;
        }
    }
    
    [Serializable()]
    [XmlRoot("SpectralPoint")]
    public class SpectralPoint : IComparable<SpectralPoint>, ISerializable
    {
        #region properties
        private double lambda;
        [CategoryAttribute("SpectralPoint"), DescriptionAttribute("Wavelength [nm]")]
        [XmlAttribute("Lambda")]
        public double Lambda
        {
            get { return lambda; }
            set { lambda = value;}
        }

        private double intensity;
        [CategoryAttribute("SpectralPoint"), DescriptionAttribute("Intensity [0..1]")]
        [XmlAttribute("Intensity")]
        public double Intensity
        {
            get { return intensity; }
            set { SetIntensity(value);}
        }
        #endregion

        #region Constructors
        public SpectralPoint()
        {
            lambda = 0;
            intensity = 0;
        }

        public SpectralPoint(SpectralPoint sp)
        {
            lambda = sp.Lambda;
            intensity = sp.Intensity;
        }

        public SpectralPoint(double lambda_, double intensity_)
        {
            lambda = lambda_;
            SetIntensity(intensity_);
        }

        public SpectralPoint(SerializationInfo info, StreamingContext ctxt)
        {
            this.lambda = (double)info.GetValue("Lambda", typeof(double));
            this.intensity = (double)info.GetValue("Intensity", typeof(double));
        }
        #endregion

        private void SetIntensity(double value)
        {
            if ((value >= 0) && (value <= 1))
                intensity = value;
            else
                if (value >= 1)
                    intensity = 1;
                else
                    intensity = 0;
        }

        public int CompareTo(SpectralPoint sp)
        {
            if (this.lambda < sp.lambda)
                return -1;
            else if (this.lambda > sp.lambda)
                return 1;
            else
                if (this.intensity < sp.intensity)
                    return -1;
                else if (this.intensity > sp.intensity)
                    return 1;
                else
                    return 0;
        }

        public string LambdaToString()
        {
            return Helper.FormatDouble(lambda) + "[nm]";
        }

        public string IntensityToString()
        {
            return Helper.FormatDouble(intensity);
        }

        public override string ToString()
        {
            return "SpectralPoint: " +LambdaToString() + " --> " + IntensityToString();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Lambda", this.lambda);
            info.AddValue("Intensity", this.intensity);
        }
    }
}
