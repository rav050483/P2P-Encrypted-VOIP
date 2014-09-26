namespace P2PVOIP
{
    partial class CallForm
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
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btCall = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(15, 25);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(250, 20);
            this.tbAddress.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number";
            // 
            // btCall
            // 
            this.btCall.Location = new System.Drawing.Point(98, 51);
            this.btCall.Name = "btCall";
            this.btCall.Size = new System.Drawing.Size(75, 23);
            this.btCall.TabIndex = 4;
            this.btCall.Text = "Call";
            this.btCall.UseVisualStyleBackColor = true;
            this.btCall.Click += new System.EventHandler(this.btCall_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(116, 77);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(37, 13);
            this.lbStatus.TabIndex = 5;
            this.lbStatus.Text = "Status";
            // 
            // CallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 112);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btCall);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CallForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Call";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCall;
        private System.Windows.Forms.Label lbStatus;
    }
}