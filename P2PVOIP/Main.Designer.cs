namespace P2PVOIP
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbNodeAddress = new System.Windows.Forms.TextBox();
            this.tbConnect = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripAddress = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBoxNodes = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbInput = new System.Windows.Forms.RichTextBox();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbHashAddress = new System.Windows.Forms.TextBox();
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuPing = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btCall = new System.Windows.Forms.Button();
            this.btMessage = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address:";
            // 
            // tbNodeAddress
            // 
            this.tbNodeAddress.Location = new System.Drawing.Point(83, 6);
            this.tbNodeAddress.Name = "tbNodeAddress";
            this.tbNodeAddress.Size = new System.Drawing.Size(310, 20);
            this.tbNodeAddress.TabIndex = 1;
            // 
            // tbConnect
            // 
            this.tbConnect.Location = new System.Drawing.Point(399, 4);
            this.tbConnect.Name = "tbConnect";
            this.tbConnect.Size = new System.Drawing.Size(75, 23);
            this.tbConnect.TabIndex = 4;
            this.tbConnect.Text = "Connect";
            this.tbConnect.UseVisualStyleBackColor = true;
            this.tbConnect.Click += new System.EventHandler(this.tbConnect_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripStatus,
            this.StripAddress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(539, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StripStatus
            // 
            this.StripStatus.Name = "StripStatus";
            this.StripStatus.Size = new System.Drawing.Size(39, 17);
            this.StripStatus.Text = "Ready";
            // 
            // StripAddress
            // 
            this.StripAddress.Margin = new System.Windows.Forms.Padding(350, 3, 0, 2);
            this.StripAddress.Name = "StripAddress";
            this.StripAddress.Size = new System.Drawing.Size(49, 17);
            this.StripAddress.Text = "Address";
            // 
            // listBoxNodes
            // 
            this.listBoxNodes.ContextMenuStrip = this.MenuStrip;
            this.listBoxNodes.FormattingEnabled = true;
            this.listBoxNodes.Location = new System.Drawing.Point(15, 110);
            this.listBoxNodes.Name = "listBoxNodes";
            this.listBoxNodes.Size = new System.Drawing.Size(200, 316);
            this.listBoxNodes.TabIndex = 6;
            this.listBoxNodes.SelectedIndexChanged += new System.EventHandler(this.listBoxNodes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nodes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Input";
            // 
            // rtbInput
            // 
            this.rtbInput.Location = new System.Drawing.Point(226, 110);
            this.rtbInput.Name = "rtbInput";
            this.rtbInput.Size = new System.Drawing.Size(300, 150);
            this.rtbInput.TabIndex = 9;
            this.rtbInput.Text = "";
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(226, 279);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(300, 150);
            this.rtbOutput.TabIndex = 11;
            this.rtbOutput.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Output";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "My Number:";
            // 
            // tbHashAddress
            // 
            this.tbHashAddress.Location = new System.Drawing.Point(83, 37);
            this.tbHashAddress.Name = "tbHashAddress";
            this.tbHashAddress.Size = new System.Drawing.Size(310, 20);
            this.tbHashAddress.TabIndex = 13;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPing,
            this.MenuDelete});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(108, 48);
            // 
            // MenuPing
            // 
            this.MenuPing.Name = "MenuPing";
            this.MenuPing.Size = new System.Drawing.Size(107, 22);
            this.MenuPing.Text = "Ping";
            // 
            // MenuDelete
            // 
            this.MenuDelete.Name = "MenuDelete";
            this.MenuDelete.Size = new System.Drawing.Size(107, 22);
            this.MenuDelete.Text = "Delete";
            // 
            // btCall
            // 
            this.btCall.Location = new System.Drawing.Point(15, 68);
            this.btCall.Name = "btCall";
            this.btCall.Size = new System.Drawing.Size(75, 23);
            this.btCall.TabIndex = 15;
            this.btCall.Text = "Call";
            this.btCall.UseVisualStyleBackColor = true;
            this.btCall.Click += new System.EventHandler(this.btCall_Click);
            // 
            // btMessage
            // 
            this.btMessage.Location = new System.Drawing.Point(97, 67);
            this.btMessage.Name = "btMessage";
            this.btMessage.Size = new System.Drawing.Size(75, 23);
            this.btMessage.TabIndex = 16;
            this.btMessage.Text = "Message";
            this.btMessage.UseVisualStyleBackColor = true;
            this.btMessage.Click += new System.EventHandler(this.btMessage_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 462);
            this.Controls.Add(this.btMessage);
            this.Controls.Add(this.btCall);
            this.Controls.Add(this.tbHashAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtbInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxNodes);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tbConnect);
            this.Controls.Add(this.tbNodeAddress);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "BlimeyTel";
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNodeAddress;
        private System.Windows.Forms.Button tbConnect;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StripAddress;
        private System.Windows.Forms.ListBox listBoxNodes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbInput;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel StripStatus;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox tbHashAddress;
        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuPing;
        private System.Windows.Forms.ToolStripMenuItem MenuDelete;
        private System.Windows.Forms.Button btCall;
        private System.Windows.Forms.Button btMessage;
    }
}

