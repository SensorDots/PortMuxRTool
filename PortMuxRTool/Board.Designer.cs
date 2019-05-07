namespace PortMuxRTool
{
    partial class Board
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
            this.groupBoxBoard = new System.Windows.Forms.GroupBox();
            this.buttonCommand = new System.Windows.Forms.Button();
            this.labelSerial = new System.Windows.Forms.Label();
            this.comboBoxSerial = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelPorts = new System.Windows.Forms.FlowLayoutPanel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBoxBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBoard
            // 
            this.groupBoxBoard.Controls.Add(this.labelStatus);
            this.groupBoxBoard.Controls.Add(this.buttonCommand);
            this.groupBoxBoard.Controls.Add(this.labelSerial);
            this.groupBoxBoard.Controls.Add(this.comboBoxSerial);
            this.groupBoxBoard.Controls.Add(this.flowLayoutPanelPorts);
            this.groupBoxBoard.Location = new System.Drawing.Point(3, -2);
            this.groupBoxBoard.Name = "groupBoxBoard";
            this.groupBoxBoard.Size = new System.Drawing.Size(900, 204);
            this.groupBoxBoard.TabIndex = 1;
            this.groupBoxBoard.TabStop = false;
            this.groupBoxBoard.Text = "groupBoxBoard";
            // 
            // buttonCommand
            // 
            this.buttonCommand.Location = new System.Drawing.Point(7, 68);
            this.buttonCommand.Name = "buttonCommand";
            this.buttonCommand.Size = new System.Drawing.Size(75, 23);
            this.buttonCommand.TabIndex = 5;
            this.buttonCommand.Text = "Command";
            this.buttonCommand.UseVisualStyleBackColor = true;
            this.buttonCommand.Click += new System.EventHandler(this.buttonCommand_Click);
            // 
            // labelSerial
            // 
            this.labelSerial.AutoSize = true;
            this.labelSerial.Location = new System.Drawing.Point(7, 24);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(58, 13);
            this.labelSerial.TabIndex = 4;
            this.labelSerial.Text = "Serial Port:";
            // 
            // comboBoxSerial
            // 
            this.comboBoxSerial.FormattingEnabled = true;
            this.comboBoxSerial.Location = new System.Drawing.Point(7, 40);
            this.comboBoxSerial.Name = "comboBoxSerial";
            this.comboBoxSerial.Size = new System.Drawing.Size(75, 21);
            this.comboBoxSerial.TabIndex = 2;
            this.comboBoxSerial.DropDown += new System.EventHandler(this.comboBoxSerial_DropDown);
            this.comboBoxSerial.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerial_SelectedIndexChanged);
            // 
            // flowLayoutPanelPorts
            // 
            this.flowLayoutPanelPorts.Location = new System.Drawing.Point(85, 14);
            this.flowLayoutPanelPorts.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelPorts.Name = "flowLayoutPanelPorts";
            this.flowLayoutPanelPorts.Size = new System.Drawing.Size(812, 185);
            this.flowLayoutPanelPorts.TabIndex = 3;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(6, 184);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(59, 13);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "labelStatus";
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxBoard);
            this.Name = "Board";
            this.Size = new System.Drawing.Size(909, 206);
            this.groupBoxBoard.ResumeLayout(false);
            this.groupBoxBoard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBoard;
        private System.Windows.Forms.ComboBox comboBoxSerial;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPorts;
        private System.Windows.Forms.Label labelSerial;
        private System.Windows.Forms.Button buttonCommand;
        private System.Windows.Forms.Label labelStatus;
    }
}
