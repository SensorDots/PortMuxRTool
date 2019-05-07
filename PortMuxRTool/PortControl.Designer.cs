using System.Drawing;
using System.Windows.Forms;

namespace PortMuxRTool
{
    partial class PortControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxPort = new System.Windows.Forms.GroupBox();
            this.contextMenuStripConnect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.singlePortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dualPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonConnectB = new System.Windows.Forms.Button();
            this.buttonVccToggle = new System.Windows.Forms.Button();
            this.buttonLogs = new System.Windows.Forms.Button();
            this.buttonCommand = new System.Windows.Forms.Button();
            this.buttonChain = new System.Windows.Forms.Button();
            this.checkBoxSkip = new System.Windows.Forms.CheckBox();
            this.buttonConnectA = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.resetCommandStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxPort.SuspendLayout();
            this.contextMenuStripConnect.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPort
            // 
            this.groupBoxPort.ContextMenuStrip = this.contextMenuStripConnect;
            this.groupBoxPort.Controls.Add(this.buttonConnectB);
            this.groupBoxPort.Controls.Add(this.buttonVccToggle);
            this.groupBoxPort.Controls.Add(this.buttonLogs);
            this.groupBoxPort.Controls.Add(this.buttonCommand);
            this.groupBoxPort.Controls.Add(this.buttonChain);
            this.groupBoxPort.Controls.Add(this.checkBoxSkip);
            this.groupBoxPort.Controls.Add(this.buttonConnectA);
            this.groupBoxPort.Controls.Add(this.buttonConnect);
            this.groupBoxPort.Location = new System.Drawing.Point(3, 3);
            this.groupBoxPort.Name = "groupBoxPort";
            this.groupBoxPort.Size = new System.Drawing.Size(88, 179);
            this.groupBoxPort.TabIndex = 0;
            this.groupBoxPort.TabStop = false;
            this.groupBoxPort.Text = "groupBoxPort";
            // 
            // contextMenuStripConnect
            // 
            this.contextMenuStripConnect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singlePortToolStripMenuItem,
            this.dualPortToolStripMenuItem,
            this.resetCommandStatusToolStripMenuItem});
            this.contextMenuStripConnect.Name = "contextMenuStripConnect";
            this.contextMenuStripConnect.Size = new System.Drawing.Size(198, 92);
            // 
            // singlePortToolStripMenuItem
            // 
            this.singlePortToolStripMenuItem.Name = "singlePortToolStripMenuItem";
            this.singlePortToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.singlePortToolStripMenuItem.Text = "&Combined Port";
            this.singlePortToolStripMenuItem.Click += new System.EventHandler(this.singlePortToolStripMenuItem_Click);
            // 
            // dualPortToolStripMenuItem
            // 
            this.dualPortToolStripMenuItem.Name = "dualPortToolStripMenuItem";
            this.dualPortToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.dualPortToolStripMenuItem.Text = "&Dual Port";
            this.dualPortToolStripMenuItem.Click += new System.EventHandler(this.dualPortToolStripMenuItem_Click);
            // 
            // buttonConnectB
            // 
            this.buttonConnectB.BackColor = System.Drawing.Color.DarkGray;
            this.buttonConnectB.Location = new System.Drawing.Point(6, 85);
            this.buttonConnectB.Name = "buttonConnectB";
            this.buttonConnectB.Size = new System.Drawing.Size(76, 22);
            this.buttonConnectB.TabIndex = 7;
            this.buttonConnectB.Text = "Connect B";
            this.buttonConnectB.UseVisualStyleBackColor = false;
            this.buttonConnectB.Click += new System.EventHandler(this.buttonConnectB_Click);
            // 
            // buttonVccToggle
            // 
            this.buttonVccToggle.BackColor = System.Drawing.Color.DarkGray;
            this.buttonVccToggle.Location = new System.Drawing.Point(6, 39);
            this.buttonVccToggle.Name = "buttonVccToggle";
            this.buttonVccToggle.Size = new System.Drawing.Size(76, 22);
            this.buttonVccToggle.TabIndex = 2;
            this.buttonVccToggle.Text = "Vcc On";
            this.buttonVccToggle.UseVisualStyleBackColor = false;
            this.buttonVccToggle.Click += new System.EventHandler(this.buttonVccToggle_Click);
            // 
            // buttonLogs
            // 
            this.buttonLogs.Location = new System.Drawing.Point(6, 108);
            this.buttonLogs.Name = "buttonLogs";
            this.buttonLogs.Size = new System.Drawing.Size(76, 22);
            this.buttonLogs.TabIndex = 4;
            this.buttonLogs.Text = "Logs";
            this.buttonLogs.UseVisualStyleBackColor = true;
            this.buttonLogs.Click += new System.EventHandler(this.buttonLogs_Click);
            // 
            // buttonCommand
            // 
            this.buttonCommand.Location = new System.Drawing.Point(6, 16);
            this.buttonCommand.Name = "buttonCommand";
            this.buttonCommand.Size = new System.Drawing.Size(76, 22);
            this.buttonCommand.TabIndex = 1;
            this.buttonCommand.Text = "Execute";
            this.buttonCommand.UseVisualStyleBackColor = true;
            this.buttonCommand.Click += new System.EventHandler(this.buttonCommand_Click);
            // 
            // buttonChain
            // 
            this.buttonChain.Location = new System.Drawing.Point(6, 131);
            this.buttonChain.Name = "buttonChain";
            this.buttonChain.Size = new System.Drawing.Size(76, 22);
            this.buttonChain.TabIndex = 5;
            this.buttonChain.Text = "Chain";
            this.buttonChain.UseVisualStyleBackColor = true;
            this.buttonChain.Click += new System.EventHandler(this.buttonChain_Click);
            // 
            // checkBoxSkip
            // 
            this.checkBoxSkip.Location = new System.Drawing.Point(20, 154);
            this.checkBoxSkip.Name = "checkBoxSkip";
            this.checkBoxSkip.Size = new System.Drawing.Size(50, 22);
            this.checkBoxSkip.TabIndex = 5;
            this.checkBoxSkip.Text = "Skip";
            this.checkBoxSkip.UseVisualStyleBackColor = true;
            // 
            // buttonConnectA
            // 
            this.buttonConnectA.BackColor = System.Drawing.Color.DarkGray;
            this.buttonConnectA.Location = new System.Drawing.Point(6, 62);
            this.buttonConnectA.Name = "buttonConnectA";
            this.buttonConnectA.Size = new System.Drawing.Size(76, 22);
            this.buttonConnectA.TabIndex = 8;
            this.buttonConnectA.Text = "Connect A";
            this.buttonConnectA.UseVisualStyleBackColor = false;
            this.buttonConnectA.Click += new System.EventHandler(this.buttonConnectA_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.Color.DarkGray;
            this.buttonConnect.Location = new System.Drawing.Point(6, 62);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(76, 22);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // resetCommandStatusToolStripMenuItem
            // 
            this.resetCommandStatusToolStripMenuItem.Name = "resetCommandStatusToolStripMenuItem";
            this.resetCommandStatusToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.resetCommandStatusToolStripMenuItem.Text = "&Reset Command Status";
            this.resetCommandStatusToolStripMenuItem.Click += new System.EventHandler(this.resetCommandStatusToolStripMenuItem_Click);
            // 
            // PortControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxPort);
            this.Name = "PortControl";
            this.Size = new System.Drawing.Size(95, 184);
            this.groupBoxPort.ResumeLayout(false);
            this.contextMenuStripConnect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPort;
        private Button buttonConnectA;
        private Button buttonConnectB;
        private Button buttonVccToggle;
        private Button buttonConnect;
        private Button buttonLogs;
        private Button buttonCommand;
        private Button buttonChain;
        private CheckBox checkBoxSkip;
        private ContextMenuStrip contextMenuStripConnect;
        private ToolStripMenuItem dualPortToolStripMenuItem;
        private ToolStripMenuItem singlePortToolStripMenuItem;
        private ToolTip toolTip;
        private ToolStripMenuItem resetCommandStatusToolStripMenuItem;
    }
}
