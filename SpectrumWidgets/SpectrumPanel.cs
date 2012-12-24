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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SpectrumBib;

/*
 * Restore points, when mouse out of panel
 * 
 */
namespace SpectrumWidgets
{
    // TODO: SpectrumPanel: Add/Move/Delete abkapseln
    public enum EInteractionModes
    {
        None=0, Intesity=1, Lambda=2, IntensityLambda=3, Add=4, Delete=5
    }

    public partial class SpectrumPanel : UserControl
    {
        public static Point NOPOINT = new Point(-1, -1);
        #region Properties
        private Bitmap image;
        public Bitmap Image
        {
            get { return image; }
            set { image = value; Invalidate(); }
        }
        private Pen penCrosshair;
        private Color colCrosshair;
        [DefaultValue(typeof(Color), "Color.White")]
        public Color CrosshairColor
        {
            get { return colCrosshair; }
            set { CreatePenCrosshair(value); Invalidate(); }
        }


        private Brush brushBack;
        private Color colBack;
        [DefaultValue(typeof(Color), "Color.Black")]
        override public Color BackColor
        {
            get { return specDrawer.BackColor; }
            set { specDrawer.BackColor = value; CreateBrushBack(value);  InvalidateSpectrum(); }
        }

        [DefaultValue(typeof(Color), "Color.Red")]
        public Color SpectrumColor
        {
            get { return specDrawer.SpectrumColor; }
            set { specDrawer.SpectrumColor = value; InvalidateSpectrum(); }
        }
	
        [DefaultValue(true)]
        public bool UseSpectralColors
        {
            get { return specDrawer.UseSpectralColors; }
            set { specDrawer.UseSpectralColors = value; InvalidateSpectrum(); }
        }

        private bool showMouseCrosshair = false;
        [DefaultValue(false)]
        public bool ShowMouseCrosshair
        {
            get { return showMouseCrosshair; }
            set { showMouseCrosshair = value; Invalidate(); }
        }
        private Point pointCursor = SpectrumPanel.NOPOINT;
        public Point MouseCursor
        {
            get { return pointCursor; }
        }

        private EInteractionModes interactionMode;
        [DefaultValue(typeof(EInteractionModes), "EInteractionModes.Intesity")]
        public EInteractionModes InteractionMode
        {
            get { return interactionMode; }
            set { interactionMode = value; }
        }

        private bool showSpectrumPoints = false;
        [DefaultValue(false)]
        public bool ShowSpectrumPoints
        {
            get { return showSpectrumPoints; }
            set { showSpectrumPoints = value; }
        }

        private int sizePointHalf = 3;
        private int sizePoint = 7;
        [DefaultValue(7)]
        public int PointSize
        {
            get { return sizePoint; }
            set { SetPointSize(value); }
        }

        private Brush brushSpectralPoint;
        private Pen penSpectralPoint;
        private Color colSpectralPoint;
        [DefaultValue(typeof(Color), "Color.Orange")]
        public Color ColorSpectralPoint
        {
            get { return colSpectralPoint; }
            set { CreateBrushPenSpectralPoint(value); }
        }

        private Spectrum spectrum;
        public Spectrum Spectrum
        {
            get { return spectrum; }
            set { SetSpectrum(value); Invalidate(); }
        }

        public bool FilledGraph
        {
            get { return specDrawer.FilledGraph; }
            set { specDrawer.FilledGraph = value; InvalidateSpectrum(); }
        }
	

        int idxSpectralPoint = -1;
        SpectralPoint spNew = null;
        SpectralPoint spOriginal = null;
        SpectrumPainter specDrawer;
        #endregion

        public SpectrumPanel()
        {
            InitializeComponent();

            DoubleBuffered = true;

            init();
        }

        #region Init & PropertyMethods
        private void init()
        {
            specDrawer = new SpectrumPainter();

            CreateBrushBack(Color.Black);
            CreatePenCrosshair(Color.White);
            CreateBrushPenSpectralPoint(Color.Orange);
            SetPointSize(7);

            Cursor = Cursors.Cross;
        }

        private void CreateBrushBack(Color col)
        {
            colBack = col;
            brushBack = new SolidBrush(col);
        }

        private void CreatePenCrosshair(Color col)
        {
            colCrosshair = col;
            penCrosshair = new Pen(colCrosshair);
        }

        private void CreateBrushPenSpectralPoint(Color col)
        {
            colSpectralPoint = col;
            brushSpectralPoint = new SolidBrush(Color.FromArgb(colSpectralPoint.A / 2, colSpectralPoint));
            penSpectralPoint = new Pen(colSpectralPoint);
        }

        private void SetPointSize(int size)
        {
            sizePoint = size;
            sizePointHalf = (sizePoint % 2 == 0) ? sizePoint / 2 : (sizePoint - 1) / 2;
        }

        private void SetSpectrum(Spectrum spec)
        {
            spectrum = spec;
            if (spectrum != null)
            {
                spectrum.OnSpectrumChanged += new Spectrum.SpectrumChanged(spectrum_OnSpectrumChanged);
                DrawSpectrum();
            }
        }

        void spectrum_OnSpectrumChanged()
        {
            InvalidateSpectrum();
        }
        #endregion

        #region DrawingRoutines
        public void InvalidateSpectrum()
        {
            DrawSpectrum();
            Invalidate();
        }

        private void DrawSpectrum()
        {
            image = specDrawer.GetBitmap(spectrum, false, ClientSize.Width, ClientSize.Height);
        }

        private void DrawCrosshair(Graphics g, Point center)
        {
            g.DrawLine(penCrosshair, new Point(center.X, 0), new Point(center.X, ClientSize.Height));
            g.DrawLine(penCrosshair, new Point(0, center.Y), new Point(ClientSize.Width, center.Y));
        }

        private void DrawSpectrumPoints(Graphics g)
        {
            if (spectrum != null)
            {
                foreach (SpectralPoint sp in spectrum.Points)
                {
                    Rectangle rect = SpectralPointToRectangle(sp);
                    g.DrawEllipse(penSpectralPoint, rect);
                    g.FillEllipse(brushSpectralPoint, rect);
                }
            }
        }

        #endregion

        #region Override Events
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(brushBack, this.ClientRectangle);

            if (image != null)
                e.Graphics.DrawImage(image, new Point(0, 0));

            if (showMouseCrosshair)
                if (pointCursor != SpectrumPanel.NOPOINT)
                    DrawCrosshair(e.Graphics, pointCursor);
            if (showSpectrumPoints)
                DrawSpectrumPoints(e.Graphics);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (spectrum != null)
            {
                Point p = new Point(e.X, e.Y);
                spNew = PointToSpectralPoint(p);

                if (showMouseCrosshair)
                {
                    pointCursor = p;
                }
                switch (interactionMode)
                {
                    case EInteractionModes.Intesity:
                        if (idxSpectralPoint > -1)
                        {
                            spectrum.SetSpectralPointIntensity(idxSpectralPoint, spNew.Intensity);
                            spNew = null;
                            idxSpectralPoint = spectrum.LastModifiedIndex;
                        }
                        break;
                    case EInteractionModes.Lambda:
                        if (idxSpectralPoint > -1)
                        {
                            spectrum.SetSpectralPointLambda(idxSpectralPoint, spNew.Lambda);
                            spNew = null;
                            idxSpectralPoint = spectrum.LastModifiedIndex;
                        }
                        break;
                    case EInteractionModes.IntensityLambda:
                        if (idxSpectralPoint > -1)
                        {
                            spectrum.SetSpectralPoint(idxSpectralPoint, spNew);
                            idxSpectralPoint = spectrum.LastModifiedIndex;
                            spNew = null;
                        }
                        break;
                    case EInteractionModes.Add:
                    case EInteractionModes.Delete:
                    case EInteractionModes.None:
                    default:
                        break;
                }


                if (interactionMode != EInteractionModes.None)
                    if (OnSpectrumChanging != null)
                        OnSpectrumChanging();

                if ((showMouseCrosshair) ||
                    (interactionMode != EInteractionModes.None))
                    Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            idxSpectralPoint = -1;
            if (showMouseCrosshair)
            {
                pointCursor = SpectrumPanel.NOPOINT;
            }
            if ((showMouseCrosshair) || 
                (interactionMode != EInteractionModes.None))
                Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point p = new Point(e.X, e.Y);
            if ((interactionMode > EInteractionModes.None) && (interactionMode < EInteractionModes.Add))
                idxSpectralPoint = GetSpectralPointUnderCursor(p);
            if (interactionMode == EInteractionModes.Add)
            {
                spNew = PointToSpectralPoint(p);
                idxSpectralPoint = spectrum.AddSpectralPoint(spNew);
                spNew = null;
                Invalidate();
            }
            if (idxSpectralPoint > -1)
                spOriginal = spectrum.Points[idxSpectralPoint];

            if (interactionMode != EInteractionModes.None)
                if (OnSpectrumBeginChange != null)
                    OnSpectrumBeginChange();
        }


        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Point p = new Point(e.X, e.Y);
            if (interactionMode == EInteractionModes.Delete)
            {
                idxSpectralPoint = GetSpectralPointUnderCursor(p);
                if (idxSpectralPoint != -1)
                    spectrum.DeleteSpectralPoint(idxSpectralPoint);
            }
                    
            idxSpectralPoint = -1;
            if (interactionMode != EInteractionModes.None)
                if (OnSpectrumChanged != null)
                    OnSpectrumChanged();
            spectrum.ResetAction();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            DrawSpectrum();
            Invalidate();
        }
        #endregion

        #region SpectrumManipulation
        private Point ConvertSpectrumPoint(SpectralPoint sp)
        {
            double width = ClientSize.Width - 2;
            double height = ClientSize.Height - 2;

            double minLambda = spectrum.LambdaMin;
            double maxLambda = spectrum.LambdaMax;

            double scale = (maxLambda - minLambda) / width;

            return new Point((int)Math.Round((sp.Lambda - minLambda) / scale), (int)((1 - sp.Intensity) * height));
        }

        private Rectangle SpectralPointToRectangle(SpectralPoint sp)
        {
            Point p = ConvertSpectrumPoint(sp);
            return new Rectangle(p.X - sizePointHalf, p.Y - sizePointHalf, sizePoint, sizePoint);
        }

        private SpectralPoint PointToSpectralPoint(Point p)
        {
            SpectralPoint sp = new SpectralPoint();
            
            double width = ClientSize.Width - 2;
            double height = ClientSize.Height - 2;

            double minLambda = spectrum.LambdaMin;
            double maxLambda = spectrum.LambdaMax;

            double scale = (maxLambda - minLambda) / width;

            sp.Lambda = p.X * scale + minLambda;
            sp.Intensity = 1 - (p.Y / height);
            return sp;
        }

        private int GetSpectralPointUnderCursor(Point p)
        {
            int res = -1;
            for (int i = 0; i < spectrum.PointsCount; i++)
            {
                Rectangle rect = SpectralPointToRectangle(spectrum.Points[i]);
                if (rect.Contains(p))
                    res = i;
            }
            return res;
        }
        #endregion

        #region Events
        public delegate void SpectrumBeginChange();
        public event SpectrumBeginChange OnSpectrumBeginChange;

        public delegate void SpectrumChanged();
        public event SpectrumChanged OnSpectrumChanged;

        public delegate void SpectrumChanging();
        public event SpectrumChanging OnSpectrumChanging;

        /*
        public delegate void CrosshairMove(SpectralPoint sp);
        public event CrosshairMove OnCrosshairMove;
         */
        #endregion

    }
}
