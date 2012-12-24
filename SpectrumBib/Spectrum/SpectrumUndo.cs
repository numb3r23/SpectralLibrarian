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
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace SpectrumBib
{
    public enum EAction
    {
        None = 0, Moved = 1, Added = 2, Deleted = 3
    }

    public class SpectrumUndo
    {
        private EAction action = EAction.None;
        [Browsable(false), DefaultValue(typeof(EAction), "EAction.None")]
        public EAction LastAction
        {
            get { return action; }
        }

        private SpectralPoint actionBefore = null;
        [Browsable(false)]
        public SpectralPoint SPActionBefore
        {
            get { return actionBefore; }
        }

        private SpectralPoint actionAfter = null;
        [Browsable(false)]
        public SpectralPoint SPActionAfter
        {
            get { return actionAfter; }
        }

        public SpectrumUndo(EAction act, SpectralPoint before, SpectralPoint after)
        {
            action = act;
            actionBefore = (before == null) ? null : new SpectralPoint(before);
            actionAfter = (after == null) ? null : new SpectralPoint(after);
        }

        public void SetAfter(SpectralPoint after)
        {
            actionAfter = (after == null) ? null : new SpectralPoint(after);
        }

        public void Undo(Spectrum spec)
        {
            switch (action)
            {
                case EAction.Moved:
                    spec.SetSpectralPoint(actionBefore, actionAfter);
                    break;
                case EAction.Added:
                    spec.DeleteSpectralPoint(actionAfter);
                    break;
                case EAction.Deleted:
                    spec.AddSpectralPoint(actionBefore);
                    break;
                case EAction.None:
                default:
                    break;
            }
        }

        public void Redo(Spectrum spec)
        {
            switch (action)
            {
                case EAction.Moved:
                    spec.SetSpectralPoint(actionAfter, actionBefore);
                    break;
                case EAction.Added:
                    spec.AddSpectralPoint(actionAfter);
                    break;
                case EAction.Deleted:
                    spec.DeleteSpectralPoint(actionBefore);
                    break;
                case EAction.None:
                default:
                    break;
            }
        }

        public string UndoString()
        {
            String txt = "";
            switch (action)
            {
                case EAction.Moved:
                    txt = "Moved --> " + actionAfter.LambdaToString();
                    break;
                case EAction.Added:
                    txt = "Added @ " + actionAfter.LambdaToString();
                    break;
                case EAction.Deleted:
                    txt = "Deleted @ " + actionBefore.LambdaToString();
                    break;
                case EAction.None:
                default:
                    break;
            }
            return txt;
        }

        public string RedoString()
        {
            String txt = "";
            switch (action)
            {
                case EAction.Moved:
                    txt = "Moved --> " + actionAfter.LambdaToString();
                    break;
                case EAction.Added:
                    txt = "Added @ " + actionAfter.LambdaToString();
                    break;
                case EAction.Deleted:
                    txt = "Deleted @ " + actionBefore.LambdaToString();
                    break;
                case EAction.None:
                default:
                    break;
            }
            return txt;
        }

        public override string ToString()
        {
            String txt = "";
            switch (action)
            {
                case EAction.Moved:
                    txt = "Moved --> " + actionAfter.LambdaToString();
                    break;
                case EAction.Added:
                    txt = "Added @ " + actionAfter.LambdaToString();
                    break;
                case EAction.Deleted:
                    txt = "Deleted @ " + actionBefore.LambdaToString();
                    break;
                case EAction.None:
                default:
                    break;
            }
            return txt;
        }
	
    }
}
