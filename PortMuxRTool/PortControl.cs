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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace PortMuxRTool
{
    public partial class PortControl : UserControl
    {
        private int portNumber;
        private int boardNumber;
        private SerialPort serialPort;
        private int vccState = 0;
        private int portAState = 0;
        private int portBState = 0;
        private bool chained = false;

        String logs;

        /// <summary>
        /// Port Control Contstructor
        /// </summary>
        /// <param name="port">Port Number</param>
        /// <param name="board">Board Number Port Belongs To</param>
        /// <param name="serial">Serial port by reference belonging to board</param>
        public PortControl(int port, int board, ref SerialPort serial)
        {
            portNumber = port;
            boardNumber = board;
            serialPort = serial;
            logs = "";
            InitializeComponent();
            this.groupBoxPort.Text = portNumber.ToString();
            this.buttonConnectA.Visible = false;
            this.buttonConnectB.Visible = false;
        }

        public bool getSkipped() { return checkBoxSkip.Checked; }
        public void setSkipped(bool skip) { checkBoxSkip.Checked = skip; }

        public bool getChained() { return chained;  }

        /// <summary>
        /// Set Port as Chained
        /// </summary>
        /// <param name="chainPort"></param>
        public void setChained(bool chainPort) {
            chained = chainPort;
            if (chained)
            {
                checkBoxSkip.Checked = true;
                buttonVccToggle.Enabled = false;
                buttonConnect.Enabled = false;
                buttonConnectA.Enabled = false;
                buttonConnectB.Enabled = false;
                buttonChain.Enabled = false;
                buttonCommand.Enabled = false;
                buttonLogs.Enabled = false;
                checkBoxSkip.Enabled = false;
                this.groupBoxPort.Text = portNumber.ToString() + " - Chained";
            }
        }

        public int getPortID()
        {
            return portNumber;
        }

        /// <summary>
        /// Set Port to Combined Control Port
        /// </summary>
        public void setCombined()
        {
            this.buttonConnectA.Visible = false;
            this.buttonConnectB.Visible = false;
            this.buttonConnect.Visible = true;
        }

        /// <summary>
        /// Add a log entry to port
        /// </summary>
        /// <param name="logEntry"></param>
        public void appendLog(String logEntry)
        {
            logs = logs + DateTime.Now.TimeOfDay.ToString().Split('.')[0] + " - " + logEntry + "\r\n";
        }

        /// <summary>
        /// Set Port to Dual Control Port
        /// </summary>
        public void setDual()
        {
            this.buttonConnect.Visible = false;
            this.buttonConnectA.Visible = true;
            this.buttonConnectB.Visible = true;
        }

        private void dualPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDual();
        }

        private void singlePortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCombined();
        }

        /// <summary>
        /// Send Serial Command
        /// </summary>
        /// <param name="command">Serial command</param>
        /// <returns>command state (1 for error connect error, 2 for serial error, 0 for success)</returns>
        private int writeSerialCommand(String command)
        {
            if (serialPort != null)
            {
                try
                {

                    if (serialPort.IsOpen)
                        serialPort.Close();

                    serialPort.Open();
                }
                catch (System.IO.IOException)
                {
                    ((Board)this.Parent.Parent.Parent).portReport("Could not connect to serial port!", portNumber);
                    return 1;
                }
                catch (System.UnauthorizedAccessException)
                {
                    ((Board)this.Parent.Parent.Parent).portReport("Access denied to serial port!", portNumber);
                    return 1;
                }

                try
                {
                    serialPort.Write(command);
                    Thread.Sleep(50);
                    if (serialPort.BytesToRead > 0) serialPort.ReadExisting();
                    serialPort.Close();
                }
                catch (System.IO.IOException)

                {
                    ((Board)this.Parent.Parent.Parent).portReport("Error communicating with serial port!", portNumber);
                    return 2;
                }

                catch (System.TimeoutException)
                {
                    ((Board)this.Parent.Parent.Parent).portReport("Serial port timeout!", portNumber);

                    serialPort.Close();

                    return 2;
                }
                catch (Exception ex)
                {
                    ((Board)this.Parent.Parent.Parent).portReport("Error occured!", portNumber);

                    return 2;
                }
            } else
            {
                ((Board)this.Parent.Parent.Parent).portReport("Error occured!", portNumber);

                return 2;
            }
            return 0; 
        }

        /// <summary>
        /// Reset port GUI state
        /// </summary>
        /// <param name="vcc">New VCC state</param>
        /// <param name="porta">New PortA state</param>
        /// <param name="portb">New PortB state</param>
        public void refreshPortState(int vcc, int porta, int portb)
        {
            vccState = vcc;
            portAState = porta;
            portBState = portb;

            //Set buttons to new state
            if (vccState == 1)
            {
                buttonVccToggle.Text = "Vcc Off";
                this.toolTip.SetToolTip(this.buttonVccToggle, "Vcc is on");
                buttonVccToggle.BackColor = Color.LightGoldenrodYellow;
            }
            else
            {
                buttonVccToggle.Text = "Vcc On";
                this.toolTip.SetToolTip(this.buttonVccToggle, "Vcc is off");
                buttonVccToggle.BackColor = Color.DarkGray;
            }

            // Dual Port
            if (portAState == 1 && portBState == 1)
            {
                buttonConnect.Text = "Disconnect";
                buttonConnect.BackColor = Color.LightGoldenrodYellow;
                this.toolTip.SetToolTip(this.buttonConnect, "Port A and port B are on");
            }
            else if (portAState == 1 && portBState == 0)
            {
                buttonConnect.Text = "Disconnect";
                buttonConnect.BackColor = Color.LightCyan;
                this.toolTip.SetToolTip(this.buttonConnect, "Port A is on and port B is off");
            }
            else if (portAState == 0 && portBState == 1)
            {
                buttonConnect.Text = "Disconnect";
                buttonConnect.BackColor = Color.LightCyan;
                this.toolTip.SetToolTip(this.buttonConnect, "Port A is off and port B is on");
            }
            else
            {
                buttonConnect.Text = "Connect";
                buttonConnect.BackColor = Color.DarkGray;
                this.toolTip.SetToolTip(this.buttonConnect, "Port A and port B are off");
            }

            //Single Ports
            if (portAState == 1)
            {
                buttonConnectA.Text = "Discon A";
                buttonConnectA.BackColor = Color.LightGoldenrodYellow;
                this.toolTip.SetToolTip(this.buttonConnectA, "Port A is on");
            }
            else
            {
                buttonConnectA.Text = "Connect A";
                buttonConnectA.BackColor = Color.DarkGray;
                this.toolTip.SetToolTip(this.buttonConnectA, "Port A is off");
            }

            if (portBState == 1)
            {
                buttonConnectB.Text = "Discon B";
                buttonConnectB.BackColor = Color.LightGoldenrodYellow;
                this.toolTip.SetToolTip(this.buttonConnectB, "Port A is on");
            }
            else
            {
                buttonConnectB.Text = "Connect B";
                buttonConnectB.BackColor = Color.DarkGray;
                this.toolTip.SetToolTip(this.buttonConnectB, "Port A is off");
            }
        }

        /// <summary>
        /// Set the GUI Command State
        /// </summary>
        /// <param name="success">1 for success, 0 for fail</param>
        /// <param name="tooltip">Status string for tooltip</param>
        public void setCommandState(bool success, String tooltip)
        {
            if (!success)
            {
                buttonCommand.BackColor = Color.Red;
                this.toolTip.SetToolTip(this.buttonCommand, tooltip);
            } else {
                buttonCommand.BackColor = Color.LightGreen;
                this.toolTip.SetToolTip(this.buttonCommand, tooltip);
            }
        }

        /// <summary>
        /// Reset the GUI state for command
        /// </summary>
        public void resetCommandStatus()
        {
            buttonCommand.BackColor = SystemColors.ControlLight;
            this.toolTip.SetToolTip(this.buttonCommand, "");
        }

        /// <summary>
        /// Switch Both VCC and Port
        /// </summary>
        /// <param name="state">State to Switch to</param>
        /// <param name="silent">Whether the operation reports to logs</param>
        /// <returns>2 if chained or skipped, 1 if error, 0 if success</returns>
        public int switchWholePortAndVcc(int state, bool silent)
        {
            
            if (checkBoxSkip.Checked == false && chained == false)
            {
                if (setVcc(state) != 0) return 1;
                if (!silent) ((Board)this.Parent.Parent.Parent).portReport("VCC " + (state & 0x01), portNumber);

                if (setPort(state) != 0) return 1;
                if (!silent) ((Board)this.Parent.Parent.Parent).portReport("Dual " + (state & 0x01), portNumber);
            } else { return 2; }
            return 0;
        }

        /// <summary>
        /// Set VCC and Port to States
        /// </summary>
        /// <param name="portState">State of Port</param>
        /// <param name="vccState">State of Vcc</param>
        /// <returns>1 if fail, 0 if success</returns>
        public int switchChained(int portState, int vccState)
        {
            if (writeSerialCommand("p" + portNumber.ToString() + "a" + (portState & 0x01) + "\r") != 0) return 1;
            if (writeSerialCommand("p" + portNumber.ToString() + "b" + (portState & 0x01) + "\r") != 0) return 1;
            if (writeSerialCommand("v" + portNumber.ToString() + vccState + "\r") != 0) return 1;

            return 0;
        }

        /// <summary>
        /// Set Port to State
        /// </summary>
        /// <param name="state">State to Set</param>
        /// <returns>1 if failed, 0 if success</returns>
        public int setPort(int state)
        {
            if (checkBoxSkip.Checked == false && chained == false)
            {
                appendLog("Dual " + (state & 0x01));
                return ((writeSerialCommand("p" + portNumber.ToString() + "a" + (state & 0x01) + "\r")) |
                    (writeSerialCommand("p" + portNumber.ToString() + "b" + (state & 0x01) + "\r")));
            }
            else { return 0; }
        }

        /// <summary>
        /// Set Vcc to State
        /// </summary>
        /// <param name="vccState">State to Set</param>
        /// <returns>1 if failed, 0 if success</returns>
        public int setVcc(int vccState)
        {
            if (checkBoxSkip.Checked == false && chained == false)
            {
                appendLog("VCC " + vccState);
                return writeSerialCommand("v" + portNumber.ToString() + vccState + "\r"); 
            } else { return 0; }
        }

        /// <summary>
        /// Vcc Toggle Notifier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonVccToggle_Click(object sender, EventArgs e)
        {
            if (writeSerialCommand("v" + portNumber.ToString() + (~vccState & 0x01) + "\r") == 0)
            {
                ((Board)this.Parent.Parent.Parent).portReport("VCC " + (~vccState & 0x01), portNumber);
                appendLog("VCC " + (~vccState & 0x01));
                ((Board)this.Parent.Parent.Parent).portChanged();
            }
        }

        /// <summary>
        /// Button A Notifier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConnectA_Click(object sender, EventArgs e)
        {
            if (writeSerialCommand("p" + portNumber.ToString() + "a" + (~portAState & 0x01) + "\r") == 0)
            {
                ((Board)this.Parent.Parent.Parent).portReport("A " + (~portAState & 0x01), portNumber);
                appendLog("A " + (~portAState & 0x01));
                ((Board)this.Parent.Parent.Parent).portChanged();
            }    
        }

        /// <summary>
        /// Button B Notifier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConnectB_Click(object sender, EventArgs e)
        {
            if (writeSerialCommand("p" + portNumber.ToString() + "b" + (~portBState & 0x01) + "\r") == 0)
            {
                ((Board)this.Parent.Parent.Parent).portReport("B " + (~portBState & 0x01), portNumber);
                appendLog("B " + (~portAState & 0x01));
                ((Board)this.Parent.Parent.Parent).portChanged();
            }
        }

        /// <summary>
        /// Dual Port Notifier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            int state = portAState | portBState;
            if ((writeSerialCommand("p" + portNumber.ToString() + "a" + (~state & 0x01) + "\r") == 0) && 
                    (writeSerialCommand("p" + portNumber.ToString() + "b" + (~state & 0x01) + "\r") == 0))
            {
                ((Board)this.Parent.Parent.Parent).portReport("Dual " + (~state & 0x01), portNumber);
                appendLog("Dual " + (~state & 0x01));
                ((Board)this.Parent.Parent.Parent).portChanged();
            }
        }

        /// <summary>
        /// Disable Chaining Button on Port
        /// </summary>
        public void disableChain()
        {
            buttonChain.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogs_Click(object sender, EventArgs e)
        {
            FormLogs frmLogs = new FormLogs(logs, portNumber, boardNumber);
            frmLogs.Show();
        }

        /// <summary>
        /// Chain Button Notifier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChain_Click(object sender, EventArgs e)
        {
            ((Board)this.Parent.Parent.Parent).chainBoard(portNumber);
        }

        /// <summary>
        /// Command Button Notifier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCommand_Click(object sender, EventArgs e)
        {

            ((Board)this.Parent.Parent.Parent).executeCommand(portNumber);
        }

        /// <summary>
        /// Reset Command Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetCommandStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetCommandStatus();
        }
    }
}
