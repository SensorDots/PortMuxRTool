using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortMuxRTool
{
    public partial class FormLogs : Form
    {
        public FormLogs()
        {
            InitializeComponent();
        }

        public FormLogs(String logText, int port, int board)
        {
            InitializeComponent();
            this.textBoxLogs.Text = logText;
            this.Text = "Logs (Board " + board + " Port "+ port +")";
        }


        private void FormLogs_Load(object sender, EventArgs e)
        {
            textBoxLogs.Select(textBoxLogs.Text.Length, 0);
            textBoxLogs.SelectionStart = textBoxLogs.Text.Length;
            textBoxLogs.ScrollToCaret();
        }
    }
}
