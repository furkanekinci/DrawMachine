namespace DrawMachine
{
    partial class ucNumberCounterSliding
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
            this.lblNumber1 = new System.Windows.Forms.Label();
            this.timCountNumbers = new System.Windows.Forms.Timer(this.components);
            this.lblNumber2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumber1
            // 
            this.lblNumber1.Font = new System.Drawing.Font("Microsoft Sans Serif", 350F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblNumber1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.lblNumber1.Location = new System.Drawing.Point(0, 0);
            this.lblNumber1.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumber1.Name = "lblNumber1";
            this.lblNumber1.Size = new System.Drawing.Size(236, 340);
            this.lblNumber1.TabIndex = 4;
            this.lblNumber1.Text = "-";
            this.lblNumber1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timCountNumbers
            // 
            this.timCountNumbers.Interval = 1;
            this.timCountNumbers.Tick += new System.EventHandler(this.timCountNumbers_Tick);
            // 
            // lblNumber2
            // 
            this.lblNumber2.Font = new System.Drawing.Font("Microsoft Sans Serif", 350F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblNumber2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.lblNumber2.Location = new System.Drawing.Point(0, 340);
            this.lblNumber2.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumber2.Name = "lblNumber2";
            this.lblNumber2.Size = new System.Drawing.Size(236, 340);
            this.lblNumber2.TabIndex = 5;
            this.lblNumber2.Text = "-";
            this.lblNumber2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucNumberCounterSliding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNumber2);
            this.Controls.Add(this.lblNumber1);
            this.Name = "ucNumberCounterSliding";
            this.Size = new System.Drawing.Size(236, 340);
            this.Load += new System.EventHandler(this.ucNumberCounterSliding_Load);
            this.Resize += new System.EventHandler(this.ucNumberCounterSliding_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumber1;
        private System.Windows.Forms.Timer timCountNumbers;
        private System.Windows.Forms.Label lblNumber2;
    }
}
