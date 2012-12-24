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
using SpectrumBib.IO;

namespace SpectrumWidgets
{
    public enum EFrontRear
    {
        Front = 0, Rear = 1
    }

    public partial class SpectrumEditorControl : UserControl
    {
        private List<SpectrumUndo> undoList;
        private List<SpectrumUndo> redoList;

        private SpectrumBinIO spectrumBinIO;
        private SpectrumXMLIO spectrumXMLIO;

        private CIEConverter cieConverter;
        
        public Spectrum Spectrum
        {   
            get { return specPanel.Spectrum; }
            set { SetSpectrum(value);}
        }

        private Spectrum backup;

        public Bitmap SpectrumBmp
        {
            get { return specPanel.Image; }
        }

        BindingSource bsSpectralPoints;
        bool doUndoRedo = false;

        public SpectrumEditorControl()
        {
            InitializeComponent();
            
            init();

            Spectrum spectrum_ = new Spectrum(ESpectrumTemplate.ExtendedVisible);
            spectrum_.AddSpectralPoint(580, 0);

            SetSpectrum(spectrum_);
        }

        public SpectrumEditorControl(Spectrum spectrum_)
        {
            InitializeComponent();

            init();

            SetSpectrum(spectrum_);
        }

        private void init()
        {
            if (System.IO.File.Exists("ciexyz64.txt"))
                cieConverter = new CIEConverter("ciexyz64.txt", ECIEConverterLoadType.TextFile);

            spectrumBinIO = new SpectrumBinIO();
            spectrumXMLIO = new SpectrumXMLIO();
            
            // SpectrumOptions
            SetUseSpectralColor(specPanel.UseSpectralColors);
            SetSpectralColor(specPanel.SpectrumColor);
            SetBackgroundColor(specPanel.BackColor);
            SetShowMouseCrosshair(specPanel.ShowMouseCrosshair);
            SetShowSpectralPoints(specPanel.ShowSpectrumPoints);
            SetPointSize(7);
            SetPointColor(specPanel.ColorSpectralPoint);
            SetFilledGraph(false);

            //lbSpectralPoints
            lbSpectralPoints.SelectedIndexChanged += new EventHandler(lbSpectralPoints_SelectedIndexChanged);
            bsSpectralPoints = new BindingSource();
            lbSpectralPoints.DataSource = bsSpectralPoints;

            specPanel.OnSpectrumChanged += new SpectrumWidgets.SpectrumPanel.SpectrumChanged(specPanel_OnSpectrumChanged);
            specPanel.OnSpectrumBeginChange += new SpectrumPanel.SpectrumBeginChange(specPanel_OnSpectrumBeginChange);
            specPanel.OnSpectrumChanging += new SpectrumPanel.SpectrumChanging(specPanel_OnSpectrumChanging);

            pGridSpectralPoint.PropertyValueChanged += new PropertyValueChangedEventHandler(pGridSpectralPoint_PropertyValueChanged);
            pGridSpectrum.PropertyValueChanged += new PropertyValueChangedEventHandler(pGridSpectrum_PropertyValueChanged);
        }

        void specPanel_OnSpectrumChanging()
        {
            if (cieConverter != null)
                specPanel.BackColor = cieConverter.SpectrumToColor(Spectrum);
        }

        void pGridSpectrum_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            specPanel.InvalidateSpectrum();
        }

        void specPanel_OnSpectrumBeginChange()
        {
        }

        void pGridSpectralPoint_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Spectrum.SetSpectralPoint(lbSpectralPoints.SelectedIndex, (SpectralPoint) pGridSpectralPoint.SelectedObject);
        }

        void lbSpectralPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSpectralPoints.SelectedItem != null)
                pGridSpectralPoint.SelectedObject = lbSpectralPoints.SelectedItem;
        }

        private Bitmap CreateColorBitmap(Color col, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            ((Graphics) Graphics.FromImage(bmp)).FillRectangle(new SolidBrush(col), new Rectangle(0, 0, size, size));
            return bmp;
        }

        void specPanel_OnSpectrumChanged()
        {
            bsSpectralPoints.SuspendBinding();
            bsSpectralPoints.ResumeBinding();
            if (Spectrum != null)
                if (!doUndoRedo)
                    AddUndo(Spectrum.Undo);
        }

        //Set new Spectrum
        private void InternalUpdate()
        {
            if (Spectrum != null)
            {
                bsSpectralPoints.DataSource = Spectrum.Points;
                bsSpectralPoints.SuspendBinding();
                bsSpectralPoints.ResumeBinding();
                undoList = new List<SpectrumUndo>();
                tsBtnUndo.DropDown.Items.Clear();
                redoList = new List<SpectrumUndo>();
                tsBtnRedo.DropDown.Items.Clear();

                pGridSpectrum.SelectedObject = Spectrum;

                if (cieConverter != null)
                    specPanel.BackColor = cieConverter.SpectrumToColor(Spectrum);

            }
        }

        #region UndoRedo
        private void Undo()
        {
            doUndoRedo = true;

            if (undoList.Count > 0)
            {
                undoList[0].Undo(Spectrum);

                AddRedo(undoList[0]);

                RemoveUndo();
            }

            doUndoRedo = false;
        }

        private void Redo()
        {
            doUndoRedo = true;
            if (redoList.Count > 0)
            {
                redoList[0].Redo(Spectrum);

                AddUndo(redoList[0]);

                RemoveRedo();
            }
            doUndoRedo = false;
        }

        private void AddUndo(SpectrumUndo op)
        {
            undoList.Insert(0, op);
            SetBtnUndoEntry(op.UndoString(), EFrontRear.Front);

            if (tsBtnUndo.DropDown.Items.Count > 10)
                tsBtnUndo.DropDown.Items.RemoveAt(10);

            tsBtnUndo.Enabled = undoList.Count > 0;
        }

        private void RemoveUndo()
        {
            undoList.RemoveAt(0);
            tsBtnUndo.DropDown.Items.RemoveAt(0);

            if (undoList.Count != tsBtnUndo.DropDown.Items.Count)
                if (undoList.Count > 0)
                    if (undoList.Count >= 10)
                        SetBtnUndoEntry(undoList[9].UndoString(), EFrontRear.Rear);
                    else
                        SetBtnUndoEntry(undoList[undoList.Count - 1].UndoString(), EFrontRear.Rear);

            tsBtnUndo.Enabled = undoList.Count > 0;
        }

        private void AddRedo(SpectrumUndo op)
        {
            redoList.Insert(0, op);
            SetBtnRedoEntry(op.ToString(), EFrontRear.Front);

            if (tsBtnRedo.DropDown.Items.Count > 10)
                tsBtnRedo.DropDown.Items.RemoveAt(10);

            tsBtnRedo.Enabled = redoList.Count > 0;
        }

        private void RemoveRedo()
        {
            redoList.RemoveAt(0);
            tsBtnRedo.DropDown.Items.RemoveAt(0);

            if (redoList.Count != tsBtnRedo.DropDown.Items.Count)
                if (redoList.Count > 0)
                    if (redoList.Count >= 10)
                        SetBtnRedoEntry(redoList[9].RedoString(), EFrontRear.Rear);
                    else
                        SetBtnRedoEntry(redoList[redoList.Count - 1].RedoString(), EFrontRear.Rear);

            tsBtnRedo.Enabled = redoList.Count > 0;
        }
        #endregion

        #region Setters
        private void SetBtnUndoEntry(String txt, EFrontRear pos)
        {
            ToolStripButton tsb = new ToolStripButton(txt);
            tsb.Click += new EventHandler(tsBtnUndo_Click);
            switch (pos)
            {
                case EFrontRear.Front:
                    tsBtnUndo.DropDown.Items.Insert(0, tsb);
                    break;
                case EFrontRear.Rear:
                    tsBtnUndo.DropDown.Items.Add(tsb);
                    break;
                default:
                    break;
            }
        }

        private void SetBtnRedoEntry(String txt, EFrontRear pos)
        {
            ToolStripButton tsb = new ToolStripButton(txt);
            tsb.Click += new EventHandler(tsBtnRedo_Click);
            switch (pos)
            {
                case EFrontRear.Front:
                    tsBtnRedo.DropDown.Items.Insert(0, tsb);
                    break;
                case EFrontRear.Rear:
                    tsBtnRedo.DropDown.Items.Add(tsb);
                    break;
                default:
                    break;
            }
        }

        private void SetSpectrum(Spectrum spectrum_)
        {
            specPanel.Spectrum = spectrum_;
            backup = new Spectrum(spectrum_);

            InternalUpdate();
        }
        #region SetOptions
        private void SetPointSize(int n)
        {
            if (n >= 3)
            {
                pointSizeToolStripMenuItem.Text = "Point Size: " + n;
                specPanel.PointSize = n;
            }
        }

        private void SetPointColor(Color col)
        {
            specPanel.ColorSpectralPoint = col;
            spectralPointColorToolStripMenuItem.Image = CreateColorBitmap(col, spectralPointColorToolStripMenuItem.Height);
        }

        private void SetUseSpectralColor(bool flag)
        {
            specPanel.UseSpectralColors = flag;
            spectralColorToolStripMenuItem.Checked = flag;
            spectralColorToolStripMenuItem.Enabled = !flag;
        }

        private void SetSpectralColor(Color col)
        {
            spectralColorToolStripMenuItem.Image = CreateColorBitmap(col, spectralColorToolStripMenuItem.Height);
            specPanel.SpectrumColor = col;
        }

        private void SetBackgroundColor(Color col)
        {
            backgroundColorToolStripMenuItem.Image = CreateColorBitmap(col, backgroundColorToolStripMenuItem.Height);
            specPanel.BackColor = col;
        }

        private void SetShowMouseCrosshair(bool flag)
        {
            specPanel.ShowMouseCrosshair = flag;
            showMouseCursorToolStripMenuItem.Checked = flag;

        }

        private void SetShowSpectralPoints(bool flag)
        {
            specPanel.ShowSpectrumPoints = flag;
            showSpectralPointsToolStripMenuItem.Checked = flag;
        }

        private void SetFilledGraph(bool flag)
        {
            specPanel.FilledGraph = flag;
            filledGraphToolStripMenuItem.Checked = flag;
        }


        #endregion

        private void SetInteractionMode(EInteractionModes IM)
        {
            specPanel.InteractionMode = IM;

            tsBtnIMNone.Checked = (IM == EInteractionModes.None);
            tsBtnIMIntensity.Checked = (IM == EInteractionModes.Intesity);
            tsBtnIMLambda.Checked = (IM == EInteractionModes.Lambda);
            tsBtnIMIntensityLambda.Checked = (IM == EInteractionModes.IntensityLambda);
            tsBtnIMAdd.Checked = (IM == EInteractionModes.Add);
            tsBtnIMDelete.Checked = (IM == EInteractionModes.Delete);
        }
        #endregion

        #region IM-Buttons
        //Toolbar
        private void tsBtnIMNone_Click(object sender, EventArgs e)
        {
            SetInteractionMode(EInteractionModes.None);
        }

        private void tsBtnIMIntensity_Click(object sender, EventArgs e)
        {
            SetInteractionMode(EInteractionModes.Intesity);
        }

        private void tsBtnIMLambda_Click(object sender, EventArgs e)
        {
            SetInteractionMode(EInteractionModes.Lambda);
        }

        private void tsBtnIMIntensityLambda_Click(object sender, EventArgs e)
        {
            SetInteractionMode(EInteractionModes.IntensityLambda);
        }

        private void tsBtnIMAdd_Click(object sender, EventArgs e)
        {
            SetInteractionMode(EInteractionModes.Add);
        }

        private void tsBtnIMDelete_Click(object sender, EventArgs e)
        {
            SetInteractionMode(EInteractionModes.Delete);
        }

        //Menu
        private void miBtnIMNone_Click(object sender, EventArgs e)
        {
            SetInteractionMode(EInteractionModes.None);
        }

        private void miBtnIMIntensity_Click(object sender, EventArgs e)
        {
            SetInteractionMode(EInteractionModes.Intesity);
        }

        private void miBtnIMLambda_Click(object sender, EventArgs e)
        {
            SetInteractionMode(EInteractionModes.Lambda);
        }

        private void miBtnIMIntensityLambda_Click(object sender, EventArgs e)
        {
            SetInteractionMode(EInteractionModes.IntensityLambda);
        }

        private void miBtnIMAdd_Click(object sender, EventArgs e)
        {
            SetInteractionMode(EInteractionModes.Add);
        }

        private void miBtnIMDelete_Click(object sender, EventArgs e)
        {
            SetInteractionMode(EInteractionModes.Delete);
        }
        #endregion

        private void tsBtnImport_Click(object sender, EventArgs e)
        {
            SpectrumImgImporter sii = new SpectrumImgImporter();
            sii.ShowDialog(this);
            if (sii.Spectrum != null)
            {
                Spectrum = sii.Spectrum;
            }
        }

        #region Option-Buttons
        private void showSpectralPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetShowSpectralPoints(showSpectralPointsToolStripMenuItem.Checked);
        }

        private void useSpectralColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetUseSpectralColor(useSpectralColorToolStripMenuItem.Checked);
        }

        private void spectralColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colDlg.Color = specPanel.SpectrumColor;
            if (colDlg.ShowDialog(this) == DialogResult.OK)
                SetSpectralColor(colDlg.Color);
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colDlg.Color = specPanel.BackColor;
            if (colDlg.ShowDialog(this) == DialogResult.OK)
                SetBackgroundColor(colDlg.Color);
        }

        private void showMouseCursorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetShowMouseCrosshair(showMouseCursorToolStripMenuItem.Checked);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            SetPointSize(specPanel.PointSize - 2);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            SetPointSize(specPanel.PointSize + 2);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SetPointSize(3);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SetPointSize(7);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SetPointSize(11);
        }

        private void spectralPointColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colDlg.Color = specPanel.ColorSpectralPoint;
            if (colDlg.ShowDialog(this) == DialogResult.OK)
                SetPointColor(colDlg.Color);
        }

        private void filledGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFilledGraph(!filledGraphToolStripMenuItem.Checked);
        }
        #endregion

        #region UnDo/ReDo Buttons
        private void tsBtnUndo_ButtonClick(object sender, EventArgs e)
        {
            Undo();
        }

        private void tsBtnUndo_Click(object sender, EventArgs e)
        {
            int idx = tsBtnUndo.DropDown.Items.IndexOf((ToolStripItem)sender);
            for (int i = 0; i <= idx; i++)
                Undo();
        }

        private void tsBtnRedo_ButtonClick(object sender, EventArgs e)
        {
            Redo();
        }

        private void tsBtnRedo_Click(object sender, EventArgs e)
        {
            int idx = tsBtnRedo.DropDown.Items.IndexOf((ToolStripItem)sender);
            for (int i = 0; i <= idx; i++)
                Redo();
        }
        #endregion

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (OnSpectrumEditorSave != null)
                OnSpectrumEditorSave(this.Spectrum);
        }

        private void miBtnSave_Click(object sender, EventArgs e)
        {
            if (OnSpectrumEditorSave != null)
                OnSpectrumEditorSave(this.Spectrum);
        }

        #region Events
        public delegate void SpectrumEditorSave(Spectrum spec);
        public event SpectrumEditorSave OnSpectrumEditorSave;

        public delegate void SpectrumEditorExport(Spectrum spec);
#pragma warning disable
        public event SpectrumEditorExport OnSpectrumEditorExport;

        #endregion

        private void revertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetSpectrum(backup);
        }

        private void overwriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backup = new Spectrum(Spectrum);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofDlg.Filter = spectrumXMLIO.Extensions + "|" + spectrumBinIO.Extensions;
            SpectrumDiskIO Reader = null;
            if (ofDlg.ShowDialog() == DialogResult.OK)
            {
                if (ofDlg.FilterIndex == 1)
                    Reader = spectrumXMLIO;
                if (ofDlg.FilterIndex == 2)
                    Reader = spectrumBinIO;
                if (Reader != null)
                {
                    Reader.FileName = ofDlg.FileName;
                    Reader.ReadFromDisk();
                    Reader.Spectrum.Name = Spectrum.Name;
                    Reader.Spectrum.Category = Spectrum.Category;
                    Spectrum.Clone(Reader.Spectrum);
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfDlg.Filter = spectrumXMLIO.Extensions + "|" + spectrumBinIO.Extensions;
            SpectrumDiskIO Writer = null;
            if (sfDlg.ShowDialog() == DialogResult.OK)
            {
                if (sfDlg.FilterIndex == 1)
                    Writer = spectrumXMLIO;
                if (sfDlg.FilterIndex == 2)
                    Writer = spectrumBinIO;
                if (Writer != null)
                {
                    Writer.Spectrum = Spectrum;
                    Writer.FileName = sfDlg.FileName;
                    Writer.WriteToDisk();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void miBtnUndo_Click(object sender, EventArgs e)
        {

        }

        private void tsBtnRedo_ButtonClick_1(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Spectrum.Clear();
        }

        private void tsBtnParseGraph_Click(object sender, EventArgs e)
        {
            SpectrumImgImporter specII = new SpectrumImgImporter();
            if (specII.ShowDialog(this) == DialogResult.OK)
                Spectrum = specII.Spectrum;
        }
    }
}
