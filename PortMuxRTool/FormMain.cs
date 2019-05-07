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
using System.Collections;
using System.IO.Ports;
using System.Threading;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

namespace PortMuxRTool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            flowLayoutPanelBoards.Controls.Add(new Board(1,0,0));
            addNewBoardToTreeView(1, 0, 0);
            //flowLayoutPanelBoards.Controls.Add(new Board(4,0));
        }

        /// <summary>
        /// Set All Ports to Combined
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setAllCombinedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Board board in flowLayoutPanelBoards.Controls)
            {
                board.setCombined();
            }
        }

        /// <summary>
        /// Set All Ports to Dual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setAllDualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Board board in flowLayoutPanelBoards.Controls)
            {
                board.setDual();
            }
        }

        /// <summary>
        /// Add New Chained Board
        /// </summary>
        /// <param name="portNumber">Port Chained To</param>
        /// <param name="boardNumber">Board Chained To</param>
        public void chainBoard(int portNumber, int boardNumber)
        {
            if (flowLayoutPanelBoards.Controls.Count < 6)
            {
                flowLayoutPanelBoards.Controls.Add(new Board(flowLayoutPanelBoards.Controls.Count + 1, boardNumber, portNumber));
                addNewBoardToTreeView(flowLayoutPanelBoards.Controls.Count, boardNumber, portNumber);

                textBoxLogs.AppendText("Board " + flowLayoutPanelBoards.Controls.Count + " Chained to Board " + boardNumber + " - " + portNumber + "\r\n");

                if (flowLayoutPanelBoards.Controls.Count < 6) return;
            }

            addNonChainBoardToolStripMenuItem.Enabled = false;
            foreach (Board board in flowLayoutPanelBoards.Controls)
            {
                board.disableChainButtons();
            }

        }

        /*public void removeBoard(int boardNumber)
        {
            foreach (Board board in flowLayoutPanelBoards.Controls)
            {
                if (board.getBoardNumber() == boardNumber)
                {
                    flowLayoutPanelBoards.Controls.Remove(board);
                    break;
                } 
            }
        }*/

        /// <summary>
        /// Search Tree View and Add Value To Searched Node
        /// </summary>
        /// <param name="searchKey"></param>
        /// <param name="newValue"></param>
        /// <param name="isPort"></param>
        private void searchAndAddTreeView(string searchKey, string newValue, Boolean isPort)
        {
            TreeNode[] list = treeViewPorts.Nodes.Find(searchKey, true);
            if (list.Length != 0)
            {
                if (isPort)
                {
                    list[0].Nodes.Add(newValue + "," + searchKey, newValue);
                } else
                {
                    list[0].Nodes.Add(newValue, newValue);
                }
            }
        }

        /// <summary>
        /// Add New Board to Tree View
        /// </summary>
        /// <param name="boardNumber"></param>
        /// <param name="chainedBoard"></param>
        /// <param name="chainedPort"></param>
        private void addNewBoardToTreeView(int boardNumber, int chainedBoard, int chainedPort)
        {
            if (chainedBoard > 0)
            {
                searchAndAddTreeView("Port " + chainedPort + ",Board " + chainedBoard, "Board " + boardNumber.ToString(), false);

            }
            else
            {
                TreeNode treeNode = new TreeNode("Board " + boardNumber.ToString());
                treeNode.Name = "Board " + boardNumber.ToString();
                treeViewPorts.Nodes.Add(treeNode);
            }

            for (int i = 1; i <= 8; i++)
            {
                searchAndAddTreeView("Board " + boardNumber.ToString(), "Port " + i.ToString(), true);
            }

            treeViewPorts.ExpandAll();
        }

        /// <summary>
        /// Receive Board Messages
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="boardNumber">Board Number Received From</param>
        public void boardReport(String message, int boardNumber)
        {
            textBoxLogs.AppendText("Board " + boardNumber.ToString() + ": " + message + "\r\n");
        }

        /// <summary>
        /// Add Non Chained Port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNonChainBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanelBoards.Controls.Count < 6)
            {
                flowLayoutPanelBoards.Controls.Add(new Board(flowLayoutPanelBoards.Controls.Count + 1, 0, 0));
                addNewBoardToTreeView(flowLayoutPanelBoards.Controls.Count, 0, 0);
                textBoxLogs.AppendText("Board " + flowLayoutPanelBoards.Controls.Count + " Added\r\n");

                if (flowLayoutPanelBoards.Controls.Count < 6) return;
            }

            addNonChainBoardToolStripMenuItem.Enabled = false;
            foreach (Board board in flowLayoutPanelBoards.Controls)
            {
                board.disableChainButtons();
            }
        }

        /// <summary>
        /// About Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }

        /// <summary>
        /// Set All Vcc to On
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allVccOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxLogs.AppendText("All Vcc 1\r\n");
            foreach (Board board in flowLayoutPanelBoards.Controls)
            {
                if (board.setVCCAll(1) != 0)
                {
                    textBoxLogs.AppendText("Error running, break.\r\n");
                    break;
                }
            }
        }

        /// <summary>
        /// Set All Vcc to Off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allVccOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxLogs.AppendText("All Vcc 0\r\n");
            foreach (Board board in flowLayoutPanelBoards.Controls)
            {
                if (board.setVCCAll(0) != 0)
                {
                    textBoxLogs.AppendText("Error running, break.\r\n");
                    break;
                }
            }
        }

        /// <summary>
        /// Execute Command on Each Board and Port in Sequence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Power off all boards
            textBoxLogs.AppendText("Powering off and disconnecting all ports and maintaining board chain links\r\n");
            foreach (Board board in flowLayoutPanelBoards.Controls)
            {
                if (board.switchAllPorts(0, true) != 0)
                {
                    textBoxLogs.AppendText("Error running, break.\r\n");
                    return;
                }

                //Make sure all chained ports are connected

                if (board.switchChainedPorts(1, 0) != 0)
                {
                    textBoxLogs.AppendText("Error running, break.\r\n");
                    return;
                }
            }

            this.Refresh();

            int status = flowLayoutPanelBoards.Controls.Count * 8;
            toolStripProgressBarStatus.Maximum = status;
            toolStripProgressBarStatus.Step = 1;

            int retVal = 0;

            foreach (Board board in flowLayoutPanelBoards.Controls)
            {
                for (int i = 1; i <= 8; i++)
                {
                    toolStripProgressBarStatus.PerformStep();
                    if (board.isChainedPort(i) == 0)
                    {
                        retVal = board.switchPort(i, 1);
                        if (retVal == 1)
                        {
                            textBoxLogs.AppendText("Error running, break.\r\n");
                            toolStripProgressBarStatus.Value = 0;
                            
                            return;
                        }
                        else if (retVal == 0)
                        {
                            //Execute command

                            textBoxLogs.AppendText("Executing command.\r\n");
                            if (board.executeCommand(i) == -1)
                            {
                                textBoxLogs.AppendText("Error running, break.\r\n");
                                toolStripProgressBarStatus.Value = 0;
                                board.portChanged();
                                return; //Command isn't set
                            }

                            Thread.Sleep(100);
                        }

                        retVal = board.switchPort(i, 0);
                        this.Refresh();
                        if (retVal == 1)
                        {
                            textBoxLogs.AppendText("Error running, break.\r\n");
                            toolStripProgressBarStatus.Value = 0;
                            return;
                        }
                    }
                }       
            }
            toolStripProgressBarStatus.Value = 0;
        }

        /// <summary>
        /// Remove all Boards from GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeAllBoardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove all boards?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                flowLayoutPanelBoards.Controls.Clear();
                treeViewPorts.Nodes.Clear();
                addNonChainBoardToolStripMenuItem.Enabled = true;

            }
        }

        /// <summary>
        /// Reset all Command Statuses on All Ports
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetCommandStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Board board in flowLayoutPanelBoards.Controls)
            {
                for (int i = 1; i <= 8; i++)
                {
                    board.resetCommandStatus();
                }
            }
        }

        /// <summary>
        /// Save GUI State
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writetext = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (Board board in flowLayoutPanelBoards.Controls)
                    {
                        writetext.WriteLine(board.getBoardDetails());
                    }
                }
            }
        }

        /// <summary>
        /// Load GUI State
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                flowLayoutPanelBoards.Controls.Clear();
                treeViewPorts.Nodes.Clear();
                try
                {
                    using (StreamReader readtext = new StreamReader(openFileDialog.FileName))
                    {
                        string nextBoard = readtext.ReadLine();
                        while (nextBoard != null)
                        {
                            if (int.Parse(nextBoard.Split(',')[5].Trim()) > 0)
                            {
                                foreach (Board board in flowLayoutPanelBoards.Controls)
                                {
                                    if (board.getBoardNumber() == int.Parse(nextBoard.Split(',')[4].Trim()))
                                    {
                                        //Add board as chained
                                        board.chainBoard(int.Parse(nextBoard.Split(',')[5].Trim()));

                                        //Search for new board added and modify it
                                        foreach (Board modBoard in flowLayoutPanelBoards.Controls)
                                        {
                                            if (modBoard.getBoardNumber() == int.Parse(nextBoard.Split(',')[3].Trim()))
                                            {

                                                modBoard.setCommand(nextBoard.Split(',')[1].Trim());
                                                modBoard.setArgs(nextBoard.Split(',')[2].Trim());
                                                modBoard.setComPort(nextBoard.Split(',')[0].Trim());
                                                bool[] skip = {
                                                    bool.Parse(nextBoard.Split(',')[6].Trim()),
                                                    bool.Parse(nextBoard.Split(',')[7].Trim()),
                                                    bool.Parse(nextBoard.Split(',')[8].Trim()),
                                                    bool.Parse(nextBoard.Split(',')[9].Trim()),
                                                    bool.Parse(nextBoard.Split(',')[10].Trim()),
                                                    bool.Parse(nextBoard.Split(',')[11].Trim()),
                                                    bool.Parse(nextBoard.Split(',')[12].Trim()),
                                                    bool.Parse(nextBoard.Split(',')[13].Trim())
                                                };
                                                modBoard.setSkip(skip);
    
                                            break;
                                            }
                                        }
                                        break;

                                    }
                                }

                            }
                            else
                            {
                                Board board = new Board(int.Parse(nextBoard.Split(',')[3].Trim()), int.Parse(nextBoard.Split(',')[4].Trim()),
                                    int.Parse(nextBoard.Split(',')[5].Trim()));
                                board.setCommand(nextBoard.Split(',')[1].Trim());
                                board.setArgs(nextBoard.Split(',')[2].Trim());
                                board.setComPort(nextBoard.Split(',')[0].Trim());
                                bool[] skip = {
                                    bool.Parse(nextBoard.Split(',')[6].Trim()),
                                    bool.Parse(nextBoard.Split(',')[7].Trim()),
                                    bool.Parse(nextBoard.Split(',')[8].Trim()),
                                    bool.Parse(nextBoard.Split(',')[9].Trim()),
                                    bool.Parse(nextBoard.Split(',')[10].Trim()),
                                    bool.Parse(nextBoard.Split(',')[11].Trim()),
                                    bool.Parse(nextBoard.Split(',')[12].Trim()),
                                    bool.Parse(nextBoard.Split(',')[13].Trim())
                                };
                                board.setSkip(skip);

                                flowLayoutPanelBoards.Controls.Add(board);

                                addNewBoardToTreeView(int.Parse(nextBoard.Split(',')[3].Trim()), int.Parse(nextBoard.Split(',')[4].Trim()),
                                int.Parse(nextBoard.Split(',')[5].Trim()));


                            }

                            nextBoard = readtext.ReadLine();
                        }
                    }
                } catch (Exception ex)
                {
                    textBoxLogs.AppendText("Error parsing save file.\r\n");
                    flowLayoutPanelBoards.Controls.Clear();
                    treeViewPorts.Nodes.Clear();
                    addNonChainBoardToolStripMenuItem.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Copy TreeView XML to Clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rootElement = new XElement("PortMuxR", CreateXmlElement(treeViewPorts.Nodes));
            var document = new XDocument(rootElement);

            Clipboard.SetText(document.ToString());
        }

        /// <summary>
        /// Create XML Data from Treeview
        /// </summary>
        /// <param name="treeViewNodes"></param>
        /// <returns></returns>
        private static List<XElement> CreateXmlElement(TreeNodeCollection treeViewNodes)
        {
            var elements = new List<XElement>();
            foreach (TreeNode treeViewNode in treeViewNodes)
            {
                var element = new XElement(treeViewNode.Text.Replace(' ', '_'));
                if (treeViewNode.GetNodeCount(true) == 1)
                    element.Value = treeViewNode.Nodes[0].Text;
                else
                    element.Add(CreateXmlElement(treeViewNode.Nodes));
                elements.Add(element);
            }
            return elements;
        }
    }
}
