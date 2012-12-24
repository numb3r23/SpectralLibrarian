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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpectrumBib;

namespace SpectrumWidgets
{
    public enum EMouseAction
    {
        None, ChooseGraphColor, ChooseStartingPoint, ChooseGraphSize
    }
    public partial class SpectrumImgImporter : Form
    {
        private Spectrum spectrum;
        public Spectrum Spectrum
        {
            get { return spectrum; }
            set { spectrum = value; }
        }

        
        private Bitmap bufferBMP;
        private Bitmap backBufferBMP;

        private ImportProperty imProp;

        private Color colCrosshair;
        private Color colArea;

        private EMouseAction mouseAction = EMouseAction.None;
        private Point mousePointRelative = new Point(-1, -1);
        private Rectangle area = new Rectangle(0,0,0,0);

        public SpectrumImgImporter()
        {
            InitializeComponent();

            imProp = new ImportProperty();

            this.Resize += new EventHandler(SpectrumImgImporter_Resize);

            pGridImport.PropertyValueChanged += new PropertyValueChangedEventHandler(pGridImport_PropertyValueChanged);

            pbImport.MouseMove += new MouseEventHandler(pbImport_MouseMove);
            pbImport.MouseUp += new MouseEventHandler(pbImport_MouseUp);
            pbImport.MouseLeave += new EventHandler(pbImport_MouseLeave);

            pbImport.BackColor = imProp.BackgroundColor;
            pGraphColor.BackColor = imProp.GraphColor;

            pGridImport.SelectedObject = imProp;

            colCrosshair = InvertColor(imProp.BackgroundColor);
            colArea = Color.FromArgb(127, colCrosshair.R, colCrosshair.G,colCrosshair.B);
        }

        void SpectrumImgImporter_Resize(object sender, EventArgs e)
        {
            RenderImage();
        }

        private Color InvertColor(Color col)
        {
            return Color.FromArgb(255 - col.R, 255 - col.G, 255 - col.B);
        }

        private void CreateArea()
        {

            int minX = Math.Min(imProp.StartPoint.X, imProp.EndPoint.X);
            int maxX = Math.Max(imProp.StartPoint.X, imProp.EndPoint.X);

            int minY = Math.Min(imProp.StartPoint.Y, imProp.EndPoint.Y);
            int maxY = Math.Max(imProp.StartPoint.Y, imProp.EndPoint.Y);

            area = new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }

        #region Drawingroutines
        private Graphics InitGraphics()
        {
            double width = pbImport.ClientSize.Width - 2;
            double height = pbImport.ClientSize.Height - 2;

            bufferBMP = new Bitmap((int)width + 1, (int)height + 1);

            return Graphics.FromImage(bufferBMP);
        }

        private void CreateBackBuffer()
        {
            double width = pbImport.ClientSize.Width - 2;
            double height = pbImport.ClientSize.Height - 2;

            backBufferBMP = new Bitmap((int)width + 1, (int)height + 1);
            (Graphics.FromImage(backBufferBMP)).DrawImage(imProp.Image, new Point(imProp.Image.Size.Width / 2, 0));
        }

        private void DrawCrosshair(Graphics g, Point center)
        {
            if (center != new Point(-1, -1))
            {
                Pen pCrosshair = new Pen(colCrosshair);
                //System.Console.WriteLine("Crosshair");

                g.DrawLine(pCrosshair, new Point(center.X, 0), new Point(center.X, pbImport.ClientSize.Height));
                g.DrawLine(pCrosshair, new Point(0, center.Y), new Point(pbImport.ClientSize.Width, center.Y));
            }
        }

        private void DrawArea(Graphics g)
        {
            if (area != new Rectangle(0, 0, 0, 0))
            {
                Brush bArea = new SolidBrush(colArea);

                g.FillRectangle(bArea, area);
            }
        }

        private void DrawImage(Graphics g)
        {
            g.DrawImage(imProp.Image, new Point(imProp.Image.Size.Width / 2, 0));
        }

        private void RenderImage()
        {
            if (imProp.Image != null)
            {
                Graphics g = InitGraphics();
                DrawImage(g);

                DrawCrosshair(g, mousePointRelative);

                if (imProp.StartPoint != new Point(-1, -1))
                    DrawCrosshair(g, imProp.StartPoint);
                if (imProp.EndPoint != new Point(-1, -1))
                    DrawCrosshair(g, imProp.EndPoint);
                if ((imProp.StartPoint != new Point(-1, -1)) && (imProp.EndPoint != new Point(-1, -1)))
                    DrawArea(g);

                pbImport.Image = bufferBMP;
            }
        }
        #endregion

        #region MouseEvents
        void pbImport_MouseUp(object sender, MouseEventArgs e)
        {
            if (imProp.Image != null)
            {
                CreateBackBuffer();
                mousePointRelative = new Point(e.X, e.Y);
                if (mouseAction == EMouseAction.ChooseGraphColor)
                {
                    imProp.GraphColor = backBufferBMP.GetPixel(mousePointRelative.X, mousePointRelative.Y);
                    pGraphColor.BackColor = imProp.GraphColor;
                }
                if (mouseAction == EMouseAction.ChooseStartingPoint)
                {
                    imProp.StartPoint = mousePointRelative;
                    CreateArea();
                }
                if (mouseAction == EMouseAction.ChooseGraphSize)
                {
                    imProp.EndPoint = mousePointRelative;
                    CreateArea();
                }
                if ((mouseAction != EMouseAction.None))
                {
                    SetMouseAction(EMouseAction.None);
                    pGridImport.Refresh();
                }
            }
        }

        void pbImport_MouseMove(object sender, MouseEventArgs e)
        {
            if ((mouseAction == EMouseAction.None) || (imProp.Image == null))
            {
            }
            else
            {
                CreateBackBuffer();
                mousePointRelative = new Point(e.X, e.Y);
                switch (mouseAction)
                {
                    case EMouseAction.None:
                        break;
                    case EMouseAction.ChooseGraphColor:
                        pGraphColor.BackColor = backBufferBMP.GetPixel(mousePointRelative.X, mousePointRelative.Y);
                        break;
                    case EMouseAction.ChooseStartingPoint:
                        imProp.StartPoint = mousePointRelative;
                        CreateArea();
                        break;
                    case EMouseAction.ChooseGraphSize:
                        imProp.EndPoint = mousePointRelative;
                        CreateArea();
                        break;
                    default:
                        break;
                }
                RenderImage();
            }
        }

        void pbImport_MouseLeave(object sender, EventArgs e)
        {
            mousePointRelative = new Point(-1, -1); ;
            RenderImage();
        }
        #endregion

        void pGridImport_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Value.GetType() == typeof(Color))
            {
                //Color changes!
                pbImport.BackColor = imProp.BackgroundColor;
                colCrosshair = InvertColor(imProp.BackgroundColor);
            }
            RenderImage();
        }

        #region ButtonStuff
        private void SetMouseAction(EMouseAction action)
        {
            if (action == mouseAction)
                action = EMouseAction.None;

            mouseAction = action;

            tsBtnChooseGraphColor.Checked = (mouseAction == EMouseAction.ChooseGraphColor);
            tsBtnChooseStartingpoint.Checked = (mouseAction == EMouseAction.ChooseStartingPoint);
            tsBtnChooseSize.Checked = (mouseAction == EMouseAction.ChooseGraphSize);
        }

        private void tsBtnChooseGraphColor_Click(object sender, EventArgs e)
        {
            SetMouseAction(EMouseAction.ChooseGraphColor);
        }

        private void tsBtnChooseStartingpoint_Click(object sender, EventArgs e)
        {
            SetMouseAction(EMouseAction.ChooseStartingPoint);
        }

        private void tsBtnChooseSize_Click(object sender, EventArgs e)
        {
            SetMouseAction(EMouseAction.ChooseGraphSize);
        }
        #endregion

        private void ParseImage()
        {
            if ((imProp.Image != null) && (imProp.StartPoint != new Point(-1, -1)) && (imProp.EndPoint != new Point(-1, -1)))
            {
                CreateBackBuffer();

                spectrum = new Spectrum();

                int x_len = imProp.EndPoint.X - imProp.StartPoint.X;
                int y_len = imProp.EndPoint.Y - imProp.StartPoint.Y;

                double dLambda = (imProp.EndLambda - imProp.StartLambda) / (double)x_len;
                double dIntensity = (imProp.MaxIntensity - imProp.MinIntensity) / (double)y_len;

                double lambda = imProp.StartLambda;

                for (int xx = 0; xx <= Math.Abs(x_len); xx++)
                {
                    double intensity = imProp.MinIntensity;
                    for (int yy = 0; yy <= Math.Abs(y_len); yy++)
                    {
                        int x = Math.Sign(x_len) * xx + imProp.StartPoint.X;
                        int y = Math.Sign(y_len) * yy + imProp.StartPoint.Y;
                        if (backBufferBMP.GetPixel(x, y) == imProp.GraphColor)
                        {
                            intensity = imProp.MinIntensity + yy * Math.Abs(dIntensity);
                        }

                    }
                    spectrum.AddSpectralPoint(lambda, intensity);
                    lambda += dLambda;
                }
            }
        }

        private void tsBtnImport_Click(object sender, EventArgs e)
        {
            ParseImage();
            spbPreview.Spectrum = this.spectrum;
        }

        private void tsBtnReset_Click(object sender, EventArgs e)
        {
            imProp.Reset();
        }

        private void tsBtnImport_Click_1(object sender, EventArgs e)
        {
            if (this.Spectrum != null)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}