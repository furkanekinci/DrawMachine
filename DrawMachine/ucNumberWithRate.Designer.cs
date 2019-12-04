namespace DrawMachine
{
    partial class ucNumberWithRate
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
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.lblNumber.Location = new System.Drawing.Point(0, 0);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(59, 88);
            this.lblNumber.TabIndex = 5;
            this.lblNumber.Text = "-";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRate
            // 
            this.lblRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.lblRate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRate.Location = new System.Drawing.Point(59, 0);
            this.lblRate.Margin = new System.Windows.Forms.Padding(0);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(89, 88);
            this.lblRate.TabIndex = 6;
            this.lblRate.Text = "*";
            // 
            // ucNumberWithRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.lblNumber);
            this.Name = "ucNumberWithRate";
            this.Size = new System.Drawing.Size(148, 88);
            this.Load += new System.EventHandler(this.ucNumberWithRate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblNumber;
        public System.Windows.Forms.Label lblRate;
    }
}
