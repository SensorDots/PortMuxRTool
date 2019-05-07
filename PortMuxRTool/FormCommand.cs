/**
   SensorDots Port MuxR Tool

   Copyright (C) 2019 SensorDots

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PortMuxRTool
{
    public partial class FormCommand : Form
    {
        public FormCommand(String command, String args)
        {
            InitializeComponent();
            textBoxArguments.Text = args;
            textBoxExecutable.Text = command;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxExecutable.Text = openFileDialog.FileName;
            }

        }

        public string executable { get; set; }
        public string arguments { get; set; }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.executable = textBoxExecutable.Text;
            this.arguments = textBoxArguments.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
