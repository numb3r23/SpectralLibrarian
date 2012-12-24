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
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace SpectrumWidgets
{
    public partial class ToolStripSplitButtonVariable<T> : ToolStripSplitButton
    {
        #region Properties & Variables
        private T variable;
        public T Variable
        {
            get { return variable; }
            set { SetVariable(value); }
        }

        private bool changeText = true;
        public bool ChangeText
        {
            get { return changeText; }
            set { changeText = value; }
        }

        private String textPrefix = "";
        public String TextPrefix
        {
            get { return textPrefix; }
            set { textPrefix = value; }
        }

        private bool cycleIt = true;
        public bool CycleVariable
        {
            get { return cycleIt; }
            set { cycleIt = value; }
        }
	
        List<ToolStripMenuItem> menuItems;
        List<T> variables;

        int idx;
        #endregion

        #region Constructors & init
        public ToolStripSplitButtonVariable(String[] names, T[] values)
        {
            InitializeComponent();

            variables = new List<T>();
            foreach (T t in values)
                variables.Add(t);

            init(names, 0);
        }

        public ToolStripSplitButtonVariable(String[] names, List<T> values)
        {
            InitializeComponent();

            variables = new List<T>();

            foreach (T t in values)
                variables.Add(t);

            init(names, 0);
        }

        public ToolStripSplitButtonVariable(String[] names, T[] values, int defaultIdx)
        {
            InitializeComponent();

            variables = new List<T>();
            foreach (T t in values)
                variables.Add(t);

            init(names, defaultIdx);
        }

        public ToolStripSplitButtonVariable(String[] names, List<T> values, int defaultIdx)
        {
            InitializeComponent();

            variables = new List<T>();

            foreach (T t in values)
                variables.Add(t);

            init(names, defaultIdx);
        }

        private void init(String[] names, int defaultIdx)
        {
            menuItems = new List<ToolStripMenuItem>();

            if (names.Length == variables.Count)
            {
                int n = names.Length;
                //menuItems = new ToolStripMenuItem()[n];
                for (int ii = 0; ii < names.Length; ii++)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(names[ii]);
                    this.DropDownItems.Add(item);
                    menuItems.Add(item);
                    menuItems[ii].Tag = ii;
                    menuItems[ii].Click += new EventHandler(ToolStripSplitButtonVariable_Click);
                    variables.Add(variables[ii]);
                }
            }

            this.ButtonClick += new EventHandler(ToolStripSplitButtonVariable_ButtonClick);

            InternalSetVariable(defaultIdx);
        }

        private void ToolStripSplitButtonVariable_ButtonClick(object sender, EventArgs e)
        {
            if (cycleIt)
                InternalSetVariable((idx + 1) % menuItems.Count);
            else
                InternalSetVariable(idx);
        }

        private void SetVariable(T var)
        {
            if (variables.Contains(var))
                InternalSetVariable(variables.IndexOf(var));
        }

        private void InternalSetVariable(int i)
        {
            idx = i;

            variable = variables[idx];
            for (int ii = 0; ii < menuItems.Count; ii++)
            {
                menuItems[ii].Checked = (ii == idx);
                if (changeText)
                    if (menuItems[ii].Checked)
                        this.Text = textPrefix + menuItems[ii].Text;
            }

            CallVariableSet();
        }

        private void ToolStripSplitButtonVariable_Click(object sender, EventArgs e)
        {
            InternalSetVariable(((int)((ToolStripMenuItem) sender).Tag));
        }

        public ToolStripSplitButtonVariable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region Events
        public delegate void VariableSet();
        public event VariableSet OnVariableSet;
        private void CallVariableSet()
        {
            if (OnVariableSet != null)
                OnVariableSet();
        }
        #endregion
    }
}
