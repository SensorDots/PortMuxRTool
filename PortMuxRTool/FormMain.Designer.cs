namespace PortMuxRTool
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNonChainBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllBoardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allVccOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allVccOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllCombinedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllDualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetCommandStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripPortTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBarStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxPorts = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelBoards = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxLogs = new System.Windows.Forms.GroupBox();
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewPorts = new System.Windows.Forms.TreeView();
            this.groupBoxPortTree = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.menuStripMain.SuspendLayout();
            this.contextMenuStripPortTree.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxPorts.SuspendLayout();
            this.groupBoxLogs.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.groupBoxPortTree.SuspendLayout();
            this.tableLayoutPanelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.controlsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1244, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "Main Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNonChainBoardToolStripMenuItem,
            this.removeAllBoardsToolStripMenuItem,
            this.saveConfigToolStripMenuItem,
            this.loadConfigToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // addNonChainBoardToolStripMenuItem
            // 
            this.addNonChainBoardToolStripMenuItem.Name = "addNonChainBoardToolStripMenuItem";
            this.addNonChainBoardToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addNonChainBoardToolStripMenuItem.Text = "Add &Non Chain Board";
            this.addNonChainBoardToolStripMenuItem.Click += new System.EventHandler(this.addNonChainBoardToolStripMenuItem_Click);
            // 
            // removeAllBoardsToolStripMenuItem
            // 
            this.removeAllBoardsToolStripMenuItem.Name = "removeAllBoardsToolStripMenuItem";
            this.removeAllBoardsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.removeAllBoardsToolStripMenuItem.Text = "&Remove All Boards";
            this.removeAllBoardsToolStripMenuItem.Click += new System.EventHandler(this.removeAllBoardsToolStripMenuItem_Click);
            // 
            // saveConfigToolStripMenuItem
            // 
            this.saveConfigToolStripMenuItem.Name = "saveConfigToolStripMenuItem";
            this.saveConfigToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveConfigToolStripMenuItem.Text = "&Save Config";
            this.saveConfigToolStripMenuItem.Click += new System.EventHandler(this.saveConfigToolStripMenuItem_Click);
            // 
            // loadConfigToolStripMenuItem
            // 
            this.loadConfigToolStripMenuItem.Name = "loadConfigToolStripMenuItem";
            this.loadConfigToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.loadConfigToolStripMenuItem.Text = "&Load Config";
            this.loadConfigToolStripMenuItem.Click += new System.EventHandler(this.loadConfigToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allVccOnToolStripMenuItem,
            this.allVccOffToolStripMenuItem,
            this.runAllToolStripMenuItem});
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.controlsToolStripMenuItem.Text = "&Tools";
            // 
            // allVccOnToolStripMenuItem
            // 
            this.allVccOnToolStripMenuItem.Name = "allVccOnToolStripMenuItem";
            this.allVccOnToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.allVccOnToolStripMenuItem.Text = "All Vcc O&n";
            this.allVccOnToolStripMenuItem.Click += new System.EventHandler(this.allVccOnToolStripMenuItem_Click);
            // 
            // allVccOffToolStripMenuItem
            // 
            this.allVccOffToolStripMenuItem.Name = "allVccOffToolStripMenuItem";
            this.allVccOffToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.allVccOffToolStripMenuItem.Text = "All Vcc O&ff";
            this.allVccOffToolStripMenuItem.Click += new System.EventHandler(this.allVccOffToolStripMenuItem_Click);
            // 
            // runAllToolStripMenuItem
            // 
            this.runAllToolStripMenuItem.Name = "runAllToolStripMenuItem";
            this.runAllToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.runAllToolStripMenuItem.Text = "Execute &All Port Commands";
            this.runAllToolStripMenuItem.Click += new System.EventHandler(this.runAllToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAllCombinedToolStripMenuItem,
            this.setAllDualToolStripMenuItem,
            this.resetCommandStatusToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // setAllCombinedToolStripMenuItem
            // 
            this.setAllCombinedToolStripMenuItem.Name = "setAllCombinedToolStripMenuItem";
            this.setAllCombinedToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.setAllCombinedToolStripMenuItem.Text = "Set Port Control C&ombined";
            this.setAllCombinedToolStripMenuItem.Click += new System.EventHandler(this.setAllCombinedToolStripMenuItem_Click);
            // 
            // setAllDualToolStripMenuItem
            // 
            this.setAllDualToolStripMenuItem.Name = "setAllDualToolStripMenuItem";
            this.setAllDualToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.setAllDualToolStripMenuItem.Text = "Set Port Control &Dual";
            this.setAllDualToolStripMenuItem.Click += new System.EventHandler(this.setAllDualToolStripMenuItem_Click);
            // 
            // resetCommandStatusToolStripMenuItem
            // 
            this.resetCommandStatusToolStripMenuItem.Name = "resetCommandStatusToolStripMenuItem";
            this.resetCommandStatusToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.resetCommandStatusToolStripMenuItem.Text = "&Reset All Command Status";
            this.resetCommandStatusToolStripMenuItem.Click += new System.EventHandler(this.resetCommandStatusToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // contextMenuStripPortTree
            // 
            this.contextMenuStripPortTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyXMLToolStripMenuItem});
            this.contextMenuStripPortTree.Name = "contextMenuStripPortTree";
            this.contextMenuStripPortTree.Size = new System.Drawing.Size(130, 26);
            // 
            // copyXMLToolStripMenuItem
            // 
            this.copyXMLToolStripMenuItem.Name = "copyXMLToolStripMenuItem";
            this.copyXMLToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.copyXMLToolStripMenuItem.Text = "&Copy XML";
            this.copyXMLToolStripMenuItem.Click += new System.EventHandler(this.copyXMLToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 699);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1244, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripProgressBarStatus
            // 
            this.toolStripProgressBarStatus.Name = "toolStripProgressBarStatus";
            this.toolStripProgressBarStatus.Size = new System.Drawing.Size(150, 16);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "mux";
            this.saveFileDialog.Filter = "Port MuxR files|*.mux";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "mux";
            this.openFileDialog.FileName = "boards.mux";
            this.openFileDialog.Filter = "Port MuxR files|*.mux";
            // 
            // groupBoxPorts
            // 
            this.groupBoxPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPorts.Controls.Add(this.flowLayoutPanelBoards);
            this.groupBoxPorts.Location = new System.Drawing.Point(3, 3);
            this.groupBoxPorts.Name = "groupBoxPorts";
            this.groupBoxPorts.Size = new System.Drawing.Size(927, 663);
            this.groupBoxPorts.TabIndex = 0;
            this.groupBoxPorts.TabStop = false;
            this.groupBoxPorts.Text = "Ports";
            // 
            // flowLayoutPanelBoards
            // 
            this.flowLayoutPanelBoards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelBoards.AutoScroll = true;
            this.flowLayoutPanelBoards.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanelBoards.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelBoards.Name = "flowLayoutPanelBoards";
            this.flowLayoutPanelBoards.Size = new System.Drawing.Size(918, 638);
            this.flowLayoutPanelBoards.TabIndex = 0;
            // 
            // groupBoxLogs
            // 
            this.groupBoxLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLogs.Controls.Add(this.textBoxLogs);
            this.groupBoxLogs.Location = new System.Drawing.Point(3, 3);
            this.groupBoxLogs.Name = "groupBoxLogs";
            this.groupBoxLogs.Size = new System.Drawing.Size(305, 328);
            this.groupBoxLogs.TabIndex = 3;
            this.groupBoxLogs.TabStop = false;
            this.groupBoxLogs.Text = "Logs";
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.AcceptsReturn = true;
            this.textBoxLogs.AcceptsTab = true;
            this.textBoxLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLogs.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLogs.Location = new System.Drawing.Point(6, 19);
            this.textBoxLogs.MaxLength = 10000;
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.ReadOnly = true;
            this.textBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogs.Size = new System.Drawing.Size(293, 303);
            this.textBoxLogs.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Controls.Add(this.groupBoxPorts, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanelRight, 1, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1244, 669);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // treeViewPorts
            // 
            this.treeViewPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewPorts.ContextMenuStrip = this.contextMenuStripPortTree;
            this.treeViewPorts.Location = new System.Drawing.Point(6, 19);
            this.treeViewPorts.Name = "treeViewPorts";
            this.treeViewPorts.Size = new System.Drawing.Size(293, 304);
            this.treeViewPorts.TabIndex = 2;
            // 
            // groupBoxPortTree
            // 
            this.groupBoxPortTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPortTree.Controls.Add(this.treeViewPorts);
            this.groupBoxPortTree.Location = new System.Drawing.Point(3, 337);
            this.groupBoxPortTree.Name = "groupBoxPortTree";
            this.groupBoxPortTree.Size = new System.Drawing.Size(305, 329);
            this.groupBoxPortTree.TabIndex = 4;
            this.groupBoxPortTree.TabStop = false;
            this.groupBoxPortTree.Text = "Port Tree View";
            // 
            // tableLayoutPanelRight
            // 
            this.tableLayoutPanelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelRight.ColumnCount = 1;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRight.Controls.Add(this.groupBoxLogs, 0, 0);
            this.tableLayoutPanelRight.Controls.Add(this.groupBoxPortTree, 0, 1);
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(933, 0);
            this.tableLayoutPanelRight.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 2;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(311, 669);
            this.tableLayoutPanelRight.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 721);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "FormMain";
            this.Text = "SensorDots Port MuxR Tool";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.contextMenuStripPortTree.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxPorts.ResumeLayout(false);
            this.groupBoxLogs.ResumeLayout(false);
            this.groupBoxLogs.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.groupBoxPortTree.ResumeLayout(false);
            this.tableLayoutPanelRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAllCombinedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAllDualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNonChainBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allVccOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allVccOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runAllToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarStatus;
        private System.Windows.Forms.ToolStripMenuItem removeAllBoardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetCommandStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPortTree;
        private System.Windows.Forms.ToolStripMenuItem copyXMLToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxPorts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBoards;
        private System.Windows.Forms.GroupBox groupBoxLogs;
        private System.Windows.Forms.TextBox textBoxLogs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox groupBoxPortTree;
        private System.Windows.Forms.TreeView treeViewPorts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRight;
    }
}