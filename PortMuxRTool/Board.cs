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
using System.Text.RegularExpressions;
using System.Collections;
using System.Diagnostics;

namespace PortMuxRTool
{
    public partial class Board : UserControl
    {
        SerialPort serialPort;
        String command = "";
        String args = "";
        int boardNumber = 0;
        int linkedBoard = 0;
        int linkedPort = 0;
        int[] vccState = { 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] portAState = { 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] portBState = { 0, 0, 0, 0, 0, 0, 0, 0 };
        ArrayList status = new ArrayList();

        /// <summary>
        /// Board Constructor
        /// </summary>
        /// <param name="board">Board number</param>
        /// <param name="chainedBoard">Board number that this board is chained to (0 for not chained)</param>
        /// <param name="chainedPort">Port number that this board is chained to (0 for not chained)</param>
        public Board(int board, int chainedBoard, int chainedPort)
        {
            InitializeComponent();
            linkedBoard = chainedBoard;
            linkedPort = chainedPort;
            boardNumber = board;
            labelStatus.Text = "";

            groupBoxBoard.Text = "Board " + board.ToString();

            if (chainedBoard > 0)
            {
                groupBoxBoard.Text = groupBoxBoard.Text + " - Primary Port, Chained to Board " + chainedBoard + " - Port " + chainedPort;
            }

            serialPort = new SerialPort();
            for (int i = 1; i <= 8; i++) flowLayoutPanelPorts.Controls.Add(new PortControl(i, boardNumber, ref serialPort));

            var portNames = SerialPort.GetPortNames();

            foreach (var port in portNames)
            {
                if (!comboBoxSerial.Items.Contains(port))
                {
                    comboBoxSerial.Items.Add(port);
                }
            }

            statusAdd("Com port not set", 0);

            if (command == "") statusAdd("Cmd not set", 1);
        }

        /// <summary>
        /// Get Board Details
        /// </summary>
        /// <returns>Return string information about board</returns>
        public String getBoardDetails()
        {
            string check = "";
            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                check = check + ", " + port.getSkipped() ;
            }
            return serialPort.PortName + ", " + command +
                ", " + args + ", " + boardNumber + ", " + linkedBoard + ", " + linkedPort + check;
        }

        public String getCommand() { return command; }
        public String getArgs() { return args; }

        public void setCommand(string cmd) {
            command = cmd;
            if (command != "") statusRemove("Cmd not set");
        }
        public void setArgs(string arg) { args = arg; }

        public void setComPort(string comPort)
        {
            comboBoxSerial.Text = comPort;
        }

        /// <summary>
        /// Send to all ports in the board a reset command status
        /// </summary>
        public void resetCommandStatus()
        {
            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                port.resetCommandStatus();
            }
        }

        System.Diagnostics.Process pProcess = null;

        /// <summary>
        /// Execute Command
        /// </summary>
        /// <param name="portID">Port number of the executing method</param>
        /// <returns>command state (-1 for error, 0 for success)</returns>
        public int executeCommand(int portID)
        {
            //Execute command
            if (command == "")
            {
                setCommandState(portID, false, "Command not set");
                ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Error executing command. No command set ", boardNumber);
                return -1;
            }

            pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = @command;
            pProcess.StartInfo.Arguments = @args; //argument

            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.RedirectStandardError = true;
            pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            pProcess.StartInfo.CreateNoWindow = true;

            try
            {
                pProcess.Start();

                string output = pProcess.StandardError.ReadToEnd(); //The output result

                pProcess.WaitForExit();

                if (pProcess.ExitCode != 0)
                    //Set port command state
                    setCommandState(portID, false, "Command failed");
                else
                    //Set port command state
                    setCommandState(portID, true, "Command success");

                portReport(output, portID);

                pProcess.Dispose();
            }
            catch (System.ComponentModel.Win32Exception ex) {
                setCommandState(portID, false, "Command failed");

                ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Error executing command. " + ex.Message + ".\r\n", boardNumber);
                return -1;

            }

            //TODO control port in here or let user/main execute loop handle this?

            return 0;
        }

        /// <summary>
        /// Set the command state of port
        /// </summary>
        /// <param name="portID">Port ID to set</param>
        /// <param name="success">True if success, false if unsuccess</param>
        /// <param name="tooltip">Tooltip string to set command button to</param>
        private void setCommandState(int portID, bool success, String tooltip)
        {
            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                if (port.getPortID() == portID)
                {
                    port.setCommandState(success, tooltip);
                    break;
                }
            }
        }

        /// <summary>
        /// Set all ports to skipped array
        /// </summary>
        /// <param name="skipped">Array of skipped values for each port</param>
        public void setSkip(bool[] skipped)
        {
            int i = 0;

            if (skipped.Length < 8) return;

            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                port.setSkipped(skipped[i]);
                i++;
            }
        }

        /// <summary>
        /// Set all ports to single control
        /// </summary>
        public void setCombined()
        {
            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                port.setCombined();
            }
        }

        /// <summary>
        /// Set port to dual port control
        /// </summary>
        public void setDual()
        {
            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                port.setDual();
            }
        }

        /// <summary>
        /// Change the state of any chained ports
        /// </summary>
        /// <param name="portState">Port state of the chained ports</param>
        /// <param name="vccState">Vcc state of the chained ports</param>
        /// <returns>1 if error, 0 if success</returns>
        public int switchChainedPorts(int portState, int vccState)
        {
            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                if (port.getChained() == true)
                {
                    if (port.switchChained(portState, vccState) != 0) return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// Set all ports and VCC to state
        /// </summary>
        /// <param name="state">State to set</param>
        /// <param name="silent">Whether the ports will be set without logs being written</param>
        /// <returns></returns>
        public int switchAllPorts(int state, bool silent)
        {
            //int retVal = writeSerialCommand("a" + state + "\r");

            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                 port.switchWholePortAndVcc(state, silent);
            }

            portChanged();

            return 0;
        }

        /// <summary>
        /// Check if port is chained
        /// </summary>
        /// <param name="portNum">Port number to check</param>
        /// <returns>If port if chained</returns>
        public int isChainedPort(int portNum)
        {
            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                if (portNum == port.getPortID())
                {
                    if (port.getChained()) return 1;
                    else return 0;
                }
            }
            return 0;
        }
        

        /// <summary>
        /// Switch port and vcc
        /// </summary>
        /// <param name="portNum">Port number to set</param>
        /// <param name="state">State to set to</param>
        /// <returns>1 if error, 0 if success</returns>
        public int switchPort(int portNum, int state)
        {
            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                if (portNum == port.getPortID() && port.getChained() == false)
                    return port.switchWholePortAndVcc(state, false);
            }
            return 0;
        }

        /// <summary>
        /// Disable the chaining buttons on all ports
        /// </summary>
        public void disableChainButtons()
        {
            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                port.disableChain();
            }
        }

        /// <summary>
        /// Chain board to port number
        /// </summary>
        /// <param name="portNumber">Chain to port</param>
        public void chainBoard(int portNumber)
        {
            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                if (port.getPortID() == portNumber)
                {
                    port.setChained(true);
                }
            }
            ((FormMain)this.Parent.Parent.Parent.Parent).chainBoard(portNumber, boardNumber);
            switchChainedPorts(1, 0);
            portChanged();

        }

        /// <summary>
        /// Receive Message From Port and Report Message to Parent
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <param name="portNumber">Port number belonging to message</param>
        public void portReport(String message, int portNumber)
        {
            //Pass up to main log

            if (portNumber == 0)
            {
                ((FormMain)this.Parent.Parent.Parent.Parent).boardReport(message, boardNumber);
            }
            else
            {
                ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Port " + portNumber.ToString() + " - " + message, boardNumber);
            }
        }

        /// <summary>
        /// Notify that a port has changed to refresh all port states
        /// </summary>
        public void portChanged()
        {
            refreshState();

            int i = 0;
            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                port.refreshPortState(vccState[i], portAState[i], portBState[i]);
                i++;
            }
        }

        /// <summary>
        /// Set the VCC on all ports
        /// </summary>
        /// <param name="vccState">State of VCC</param>
        /// <returns>1 if error, 0 if success</returns>
        public int setVCCAll(int vccState)
        {
            foreach (PortControl port in flowLayoutPanelPorts.Controls)
            {
                if (port.setVcc(vccState) != 0) return 1;
            }

            portChanged();

            return 0;
        }

        /// <summary>
        /// Refresh the state of all ports
        /// </summary>
        private void refreshState()
        {
            String state = "";
            readSerialCommand("s\r", ref state);
            //((FormMain)this.Parent.Parent.Parent).boardReport(state, boardNumber);
            
            try
            {
                state = state.Substring(state.IndexOf("vcc:") + 4).Trim(); //remove starting chars
                //vcc: 1,1,1,1,0,0,0,0 port_a: 0,0,0,0,0,0,0,0 port_b: 0,0,0,0,0,0,0,0
                for (int i = 0; i < 8; i++)
                {
                    vccState[i] = int.Parse(state.Split(' ')[0].Split(',')[i]);
                }

                state = state.Substring(state.IndexOf("port_a:") + 7).Trim(); //remove starting chars
                for (int i = 0; i < 8; i++)
                {
                    portAState[i] = int.Parse(state.Split(' ')[0].Split(',')[i]);
                }

                state = state.Substring(state.IndexOf("port_b:") + 7).Trim(); //remove starting chars
                for (int i = 0; i < 8; i++)
                {
                    portBState[i] = int.Parse(state.Split(' ')[0].Split(',')[i]);
                }

            } catch (Exception)
            {
                ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Error getting board state", boardNumber);
            }
            
        }

        /// <summary>
        /// Gets the board number
        /// </summary>
        /// <returns>Board number</returns>
        public int getBoardNumber()
        {
            return boardNumber;
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
                    if (this.Parent != null)
                    {
                        ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Could not connect to serial port!", boardNumber);
                    }
                    return 1;
                }
                catch (System.UnauthorizedAccessException)
                {
                    if (this.Parent != null)
                    {
                        ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Access denied to serial port!", boardNumber);
                    }
                    return 1;
                }

                try
                {
                    serialPort.Write(command);
                    if (serialPort.BytesToRead > 0) serialPort.ReadExisting();
                    serialPort.Close();
                }
                catch (System.IO.IOException)

                {
                    if (this.Parent != null)
                    {
                        ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Error communicating with serial port!", boardNumber);
                    }
                    return 2;
                }

                catch (System.TimeoutException)
                {
                    if (this.Parent != null)
                    {
                        ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Serial port timeout!", boardNumber);
                    }

                    serialPort.Close();

                    return 2;
                }
                catch (Exception)
                {
                    if (this.Parent != null)
                    {
                        ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Error occured!", boardNumber);
                    }
                    return 2;
                }
            }
            else
            {
                ((Board)this.Parent.Parent.Parent.Parent).portReport("Error occured!", boardNumber);

                return 2;
            }
            return 0;

        }

        /// <summary>
        /// Send Serial Command
        /// </summary>
        /// <param name="command">Serial command</param>
        /// <param name="returnString">Returned serial data (byref)</param>
        /// <returns>command state (1 for error connect error, 2 for serial error, 0 for success)</returns>
        private int readSerialCommand(String command, ref String returnString)
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
                    if (this.Parent != null)
                    {
                        ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Could not connect to serial port!", boardNumber);
                    }
                    return 1;
                }
                catch (System.UnauthorizedAccessException)
                {
                    if (this.Parent != null)
                    {
                        ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Access denied to serial port!", boardNumber);
                    }
                    return 1;
                }

                try
                {
                    if (serialPort.BytesToRead > 0) returnString = serialPort.ReadExisting();
                    serialPort.Write(command);
                    Thread.Sleep(200);
                    if (serialPort.BytesToRead > 0) returnString = serialPort.ReadExisting().Trim();
                    serialPort.Close();
                }
                catch (System.IO.IOException)

                {
                    if (this.Parent != null)
                    {
                        ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Error communicating with serial port!", boardNumber);
                    }
                    return 2;
                }

                catch (System.TimeoutException)
                {
                    if (this.Parent != null)
                    {
                        ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Serial port timeout!", boardNumber);
                    }

                    serialPort.Close();

                    return 2;
                }
                catch (Exception)
                {
                    if (this.Parent != null)
                    {
                        ((FormMain)this.Parent.Parent.Parent.Parent).boardReport("Error occured!", boardNumber);
                    }

                    return 2;
                }
            }
            else
            {
                ((Board)this.Parent.Parent.Parent.Parent).portReport("Error occured!", boardNumber);

                return 2;
            }
            return 0;
        }

        /// <summary>
        /// Notify when serial combo box changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxSerial_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort.PortName = comboBoxSerial.Text;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.BaudRate = 57600;
            serialPort.RtsEnable = false;
            serialPort.DtrEnable = false;
            serialPort.ReadTimeout = 1000;
            serialPort.WriteTimeout = 500;

            //Set manual mode
            if (writeSerialCommand("m0\r") == 0)
            {
                //Set chained ports if ports chained
                if (switchChainedPorts(1, 0) == 0)
                {
                    portChanged();
                    statusRemove("Com !connect");
                }
            } else
            {
                statusAdd("Com !connect", 0);
            }

            statusRemove("Com port not set");
        }

        /// <summary>
        /// Add to status label
        /// </summary>
        /// <param name="statusText">Text to add</param>
        /// <param name="priority">Priority to display text</param>
        private void statusAdd(String statusText, int priority)
        {

            try
            {
                if (priority == 0)
                {
                    status.Insert(0, statusText);
                }
                else
                {
                    status.Add(statusText);
                }
                if (status.Count >= 1) labelStatus.Text = (String)status[0];
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Remove from status label
        /// </summary>
        /// <param name="statusText">Text to remove</param>
        private void statusRemove(String statusText)
        {
            try
            {
                status.Remove(statusText);

                if (status.Count >= 1) labelStatus.Text = (String)status[0];
                else labelStatus.Text = "";
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Load change command parameter form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCommand_Click(object sender, EventArgs e)
        {
            FormCommand commandDialog = new FormCommand(command, args);
            commandDialog.executable = command;
            commandDialog.arguments = args;

            var result = commandDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                command = commandDialog.executable;            //values preserved after close
                args = commandDialog.arguments; 

            }

            if (command != "") statusRemove("Cmd not set");

        }

        /// <summary>
        /// Notify when serial combo box is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxSerial_DropDown(object sender, EventArgs e)
        {
            var portNames = SerialPort.GetPortNames();

            comboBoxSerial.Items.Clear();
            foreach (var port in portNames)
            {
                if (!comboBoxSerial.Items.Contains(port))
                {
                    comboBoxSerial.Items.Add(port);
                }
            }
        }
    }
}
