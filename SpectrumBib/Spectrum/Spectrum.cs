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
using System.Runtime.Serialization;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace SpectrumBib
{
    public enum ESpectrumTemplate
    {
        Empty, Visible, ExtendedVisible
    }
    public enum ESpectralInterpolation
    {
        Linear, Peak
    }
    public enum ELaserSampleMode
    {
        Lambda, BoxFilter
    }

    // TODO Spectrum-Interpolation: sqarePeak mode
    // TODO Spectrum: Add Keywords!

    [Serializable()]
    [XmlRoot("Spectrum")]
    public class Spectrum : ISerializable//, IEnumerable
    {
        #region Properties
        /*
        private List<SpectralPoint> points;
        [CategoryAttribute("Spectrum"), DescriptionAttribute("Collection of Spectralpoints")]
        [XmlArray("SpectralPoints"), XmlArrayItem("SpectralPoint", typeof(SpectralPoint))]
        public List<SpectralPoint> Points
        {
            get { return points; }
        }
        */

        private SpectralPointCollection points;
        [CategoryAttribute("Spectrum"), DescriptionAttribute("Collection of Spectralpoints")]
        [XmlArray("SpectralPoints")]
        public SpectralPointCollection Points
        {
            get { return points; }
            set { points = value; }
        }

        [ReadOnly(true), CategoryAttribute("Spectrum"), DescriptionAttribute("Points in the Spectrum")]
        public int PointsCount
        {
            get {return points.Count;}
        }

        private ESpectralInterpolation specInt;
        [CategoryAttribute("Spectrum"), DescriptionAttribute("Interpolationmethod for Spectralpoints")]
        [XmlAttribute("SpectralInterpolation")]
        public ESpectralInterpolation Interpolation
        {
            get { return specInt; }
            set { SetInterpolation(value); }
        }


        double lambdaMax = -1;
        [CategoryAttribute("Spectrum"), DescriptionAttribute("Maximum Wavelength")]
        [XmlAttribute("LambdaMax")]
        public double LambdaMax
        {
            get { return GetLambdaMax(); }
            set { SetLambdaMax(value); }
        }

        double lambdaMin = -1;
        [CategoryAttribute("Spectrum"), DescriptionAttribute("Minimum Wavelength")]
        [XmlAttribute("LambdaMin")]
        public double LambdaMin
        {
            get { return GetLambdaMin(); }
            set { SetLambdaMin(value); }
        }

        [CategoryAttribute("Spectrum"), DescriptionAttribute("Maximum Intensity")]
        public double IntensityMax
        {
            get { return GetIntensityMax(); }
        }

        [CategoryAttribute("Spectrum"), DescriptionAttribute("Minimum Intensity")]
        public double IntensityMin
        {
            get { return GetIntensityMin(); }
        }

        [Browsable(false), CategoryAttribute("Spectrum"), DescriptionAttribute("Has SpectralPoints")]
        public bool HasSpectralPoints
        {
            get { return (points.Count > 0); }
        }

        private double baseIntensity = 0;
        [DefaultValue(0), CategoryAttribute("Spectrum"), DescriptionAttribute("base Intensity")]
        [XmlAttribute("BaseIntensity")]
        public double BaseIntensity
        {
            get { return baseIntensity; }
            set { baseIntensity = value; }
        }

        private String name;
        [CategoryAttribute("Spectrum"), DescriptionAttribute("Name of the Spectrum")]
        [XmlAttribute("SpectrumName")]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String category;
        [ReadOnly(true), CategoryAttribute("Category"), DescriptionAttribute("Category of the Spectrum")]
        [XmlAttribute("CategoryName")]
        public String Category
        {
            get { return category; }
            set { category = value; }
        }

        private SpectrumUndo undo;
        [Browsable(false)]
        public SpectrumUndo Undo
        {
            get { return undo; }
        }

        private int lastModifiedIdx = -1;
        [Browsable(false)]
        public int LastModifiedIndex
        {
            get { return lastModifiedIdx; }
        }

        private int imageIndex = -1;
        [Browsable(false)]
        [XmlAttribute("ImageIndex")]
        public int ImageIndex
        {
            get { return imageIndex; }
            set { imageIndex = value; }
        }
        #endregion

        #region Constructors
        public Spectrum()
        {
            points = new SpectralPointCollection();

            name = "Spectrum";

            category = "uncategorized";
        }

        public Spectrum(ESpectrumTemplate eSpTemplate)
        {
            category = "uncategorized";
            points = new SpectralPointCollection();
            name = "Spectrum";

            switch (eSpTemplate)
            {
                case ESpectrumTemplate.Empty:
                    break;
                case ESpectrumTemplate.Visible:
                    name = "Visible Spectrum";
                    AddSpectralPoint(380, 1);
                    AddSpectralPoint(780, 1);
                    break;
                case ESpectrumTemplate.ExtendedVisible:
                    name = "Extended Visible Spectrum";
                    AddSpectralPoint(324, 1);
                    AddSpectralPoint(836, 1);
                    break;
                default:
                    break;
            }
        }

        public Spectrum(ESpectrumTemplate eSpTemplate, ESpectralInterpolation eSpInterpolation)
        {
            category = "uncategorized";
            points = new SpectralPointCollection();
            name = "Spectrum";
            specInt = eSpInterpolation;

            switch (eSpTemplate)
            {
                case ESpectrumTemplate.Empty:
                    break;
                case ESpectrumTemplate.Visible:
                    name = "Visible Spectrum";
                    AddSpectralPoint(380, 1);
                    AddSpectralPoint(780, 1);
                    break;
                case ESpectrumTemplate.ExtendedVisible:
                    name = "Extended Visible Spectrum";
                    AddSpectralPoint(324, 1);
                    AddSpectralPoint(836, 1);
                    break;
                default:
                    break;
            }
            Clear();
        }

        public Spectrum(Spectrum sp)
        {
            //properties kopieren
            name = sp.Name;
            category = sp.Category;
            specInt = sp.Interpolation;
            points = new SpectralPointCollection(sp.Points);
            baseIntensity = sp.BaseIntensity;
            imageIndex = sp.ImageIndex;
            lambdaMin = sp.LambdaMin;
            lambdaMax = sp.LambdaMax;

            CallSpectrumChanged();
        }


        public Spectrum(SerializationInfo info, StreamingContext ctxt)
        {
            this.name = (String)info.GetValue("SpectrumName", typeof(String));
            this.category = (String)info.GetValue("CategoryName", typeof(String));
            this.specInt = (ESpectralInterpolation)info.GetValue("SpectralInterpolation", typeof(ESpectralInterpolation));
            this.points = (SpectralPointCollection)info.GetValue("SpectralPoints", typeof(SpectralPointCollection));
            this.baseIntensity = (double)info.GetValue("BaseIntensity", typeof(double));
            this.imageIndex = (int)info.GetValue("ImageIndex", typeof(Int32));
            this.lambdaMin = (double)info.GetValue("LambdaMin", typeof(double));
            this.lambdaMax = (double)info.GetValue("LambdaMax", typeof(double));
        }
        #endregion

        public void Clone(Spectrum spec)
        {
            category = spec.Category;
            name = spec.Name;
            specInt = spec.Interpolation;
            lambdaMin = spec.LambdaMin;
            lambdaMax = spec.LambdaMax;
            imageIndex = spec.ImageIndex;
            baseIntensity = spec.BaseIntensity;

            points.Clear();
            foreach (SpectralPoint sp in spec.Points)
                points.Add(new SpectralPoint(sp));

            CallSpectrumChanged();
        }

        #region Interpolation
        private void SetInterpolation(ESpectralInterpolation value)
        {
            if (specInt == ESpectralInterpolation.Linear)
                if (value == ESpectralInterpolation.Peak)
                    if (lambdaMax == lambdaMin)
                        if (HasSpectralPoints)
                        {
                            lambdaMin = GetLambdaMin();
                            lambdaMax = GetLambdaMax();
                        }
            if (specInt == ESpectralInterpolation.Peak)
            {
                SpectralPoint sp = Points[0];
                if (sp.Lambda != lambdaMin)
                    points.Insert(0, new SpectralPoint(lambdaMin, baseIntensity));
                sp = Points[PointsCount - 1];
                if (sp.Lambda != lambdaMax)
                    points.Add(new SpectralPoint(lambdaMax, baseIntensity));
            }
            specInt = value;
            CallSpectrumChanged();
        }

        private double Interpolate(double lambda, SpectralPoint a, SpectralPoint b)
        {
            double x = (lambda - a.Lambda);
            return a.Intensity + x * (b.Intensity - a.Intensity) / (b.Lambda - a.Lambda);
        }
        #endregion

        #region Getters
        private double BoxFilter(double lambda, double delta)
        {
            double upper = lambda + delta;
            int counter = 0;
            double res = 0;
            foreach (SpectralPoint sp in points)
            {
                if ((sp.Lambda >= lambda) && (sp.Lambda < upper))
                {
                    res += sp.Intensity;
                    counter++;
                }
            }
            if (counter > 0)
                res /= (double)counter;
            return res;
        }

        public double GetIntensity(double lambda, double delta, ELaserSampleMode sampleMode)
        {
            switch (specInt)
            {
                case ESpectralInterpolation.Linear:
                    break;
                case ESpectralInterpolation.Peak:
                    switch (sampleMode)
                    {
                        case ELaserSampleMode.Lambda:
                            break;
                        case ELaserSampleMode.BoxFilter:
                            return BoxFilter(lambda, delta);
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return GetIntensity(lambda);
        }

        public double GetIntensity(double lambda)
        {
            if (Interpolation == ESpectralInterpolation.Linear)
            {
                if (points.Count > 1)
                {
                    int idx = points.BinarySearch(new SpectralPoint(lambda, 0.5),new SpectralPointWavelength());
                    if (idx >= 0)
                        return points[idx].Intensity;
                    else
                    {
                        idx = ~idx;
                        if (idx == points.Count)
                            return points[idx - 1].Intensity;
                        else if (idx == 0)
                            return points[0].Intensity;
                        else
                            return Interpolate(lambda, points[idx - 1], points[idx]);
                    }
                }
                return -1;
            }
            if (Interpolation == ESpectralInterpolation.Peak)
            {
                int idx = points.BinarySearch(new SpectralPoint(lambda, 0.5), new SpectralPointWavelength());
                if (idx >= 0)
                    return points[idx].Intensity;
                else
                    return baseIntensity;
            }
            return baseIntensity;
        }

        public int GetIntensityi(double lambda)
        {
            if (points.Count > 1)
            {
                return (int) (GetIntensity(lambda)*255);
            }
            return -1;
        }

        private double GetLambdaMin()
        {
            switch (Interpolation)
            {
                case ESpectralInterpolation.Linear:
                    if (HasSpectralPoints)
                        return points[0].Lambda;
                    else
                        return -1;
                case ESpectralInterpolation.Peak:
                    return lambdaMin;
                default:
                    break;
            }
            return -1;
        }

        private double GetLambdaMax()
        {
            switch (Interpolation)
            {
                case ESpectralInterpolation.Linear:
                    if (HasSpectralPoints)
                        return points[points.Count - 1].Lambda;
                    else
                        return -1;
                case ESpectralInterpolation.Peak:
                    return lambdaMax;
                default:
                    break;
            }
            return -1;
        }

        private double GetIntensityMin()
        {
            double res = -1;
            if (HasSpectralPoints)
            {
                res = points[0].Intensity;
                foreach (SpectralPoint sp in points)
                    res = Math.Min(res, sp.Intensity);
            }
            return res;
        }

        private double GetIntensityMax()
        {
            double res = -1;
            if (HasSpectralPoints)
            {
                res = points[0].Intensity;
                foreach (SpectralPoint sp in points)
                    res = Math.Max(res, sp.Intensity);
            }
            return res;
        }

        #endregion

        #region Adder
        private int AddHelperSpectralPoint(SpectralPoint sp, bool insertIfEqual)
        {
            int idx = points.BinarySearch(sp);
            if (idx < 0)
            {
                idx = ~idx;
                if (idx == points.Count)
                {
                    points.Add(sp);
                    idx = points.Count - 1;
                }
                else
                    points.Insert(idx, sp);
            }
            else
                if (insertIfEqual)
                    points.Insert(idx, sp);
            return idx;
        }
        public int AddSpectralPoint(SpectralPoint sp)
        {
            int idx = AddHelperSpectralPoint(sp, false);

            CallSpectrumChanged();

            undo = new SpectrumUndo(EAction.Added, null, sp);
            lastModifiedIdx = -1;

            return idx;
        }

        public int AddSpectralPoint(double lambda, double intensity)
        {
            return AddSpectralPoint(new SpectralPoint(lambda, intensity));
        }
        #endregion

        #region Delete
        public void DeleteSpectralPoint(int idx)
        {
            if ((idx != -1) && (idx < points.Count))
            {
                undo = new SpectrumUndo(EAction.Deleted, points[idx], null);
                points.RemoveAt(idx);
                if (OnSpectrumChanged != null)
                    OnSpectrumChanged();

                lastModifiedIdx = -1;
            }
        }

        public void DeleteSpectralPoint(SpectralPoint sp)
        {
            int idx = points.BinarySearch(sp);
            if (idx > -1)
            {
                DeleteSpectralPoint(idx);
            }
        }
        #endregion

        #region Setter
        public void Scale(double factor)
        {
            foreach (SpectralPoint sp in Points)
                sp.Intensity *= factor;
            CallSpectrumChanged();
        }

        public void Clear()
        {
            if (Interpolation == ESpectralInterpolation.Peak)
            {
                for (int i = Points.Count - 1; i >= 0; i--)
                {
                    SpectralPoint sp = Points[i];
                    if ((sp.Lambda == lambdaMin) || (sp.Lambda == lambdaMax))
                        points.RemoveAt(i);
                }
                CallSpectrumChanged();
            }
        }

        private int CheckInBetween(SpectralPoint low, SpectralPoint check, SpectralPoint high)
        {
            int lowCompare = check.CompareTo(low);
            if (lowCompare == check.CompareTo(high))
                return lowCompare;
            else
                return 0;
        }

        public void SetSpectralPoint(int idx, double lambda_, double intensity_)
        {
            if (Helper.InRange(idx, 0, points.Count - 1))
            {
                SpectralPoint sp_new = new SpectralPoint(lambda_, intensity_);

                if (idx == lastModifiedIdx)
                {
                    undo.SetAfter(sp_new);
                }
                else
                {
                    undo = new SpectrumUndo(EAction.Moved, points[idx], sp_new);
                }

                //reuse it as a flag....
                lastModifiedIdx = -1;
                //if it's still fits in the same point interval - exchange it
                if ((idx > 0) && (idx < points.Count - 1))
                {
                    int check = CheckInBetween(points[idx - 1], sp_new, points[idx + 1]);
                    if (check == 0)
                    {
                        lastModifiedIdx = idx;
                        points[idx] = sp_new;
                    }
                }
                //if not - remove + binary search
                if (lastModifiedIdx == -1)
                {
                    points.RemoveAt(idx);
                    lastModifiedIdx = AddHelperSpectralPoint(sp_new, true);
                }
                CallSpectrumChanged();
            }
        }

        public void SetSpectralPoint(int idx, SpectralPoint sp)
        {
            SetSpectralPoint(idx, sp.Lambda, sp.Intensity);
        }

        public void SetSpectralPointLambda(int idx, double lambda_)
        {
            if ((idx >= 0) && (idx < points.Count))
            {
                SetSpectralPoint(idx, lambda_, points[idx].Intensity);
            }
        }

        public void SetSpectralPointIntensity(int idx, double intensity_)
        {
            if ((idx >= 0) && (idx < points.Count))
            {
                SetSpectralPoint(idx, points[idx].Lambda, intensity_);
            }
        }

        public void SetSpectralPoint(SpectralPoint before, SpectralPoint after)
        {
            int idxAfter = points.BinarySearch(after);

            if (idxAfter > -1)
            {
                SetSpectralPoint(idxAfter, before);
            }
        }

        public void SetLambdaMax(double value)
        {
            lambdaMax = value;
        }

        public void SetLambdaMin(double value)
        {
            lambdaMin = value;
        }
        #endregion

        public override string ToString()
        {
            return name;
        }

        public void ResetAction()
        {
            lastModifiedIdx = -1;
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("SpectralPoints", this.points);
            info.AddValue("SpectralInterpolation", this.specInt);
            info.AddValue("SpectrumName", this.name);
            info.AddValue("CategoryName", this.category);
            info.AddValue("BaseIntensity", this.baseIntensity);
            info.AddValue("ImageIndex", this.imageIndex);
            info.AddValue("LambdaMin", this.lambdaMin);
            info.AddValue("LambdaMax", this.lambdaMax);
        }

        #region Events
        public delegate void SpectrumChanged();
        public event SpectrumChanged OnSpectrumChanged;
        private void CallSpectrumChanged()
        {
            if (OnSpectrumChanged != null)
                OnSpectrumChanged();
        }
        #endregion
    }
}
