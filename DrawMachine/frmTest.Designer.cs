namespace DrawMachine
{
    partial class frmTest
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.ucNumberCounterSliding1 = new DrawMachine.ucNumberCounterSliding();
            this.ucNumberCounterSliding2 = new DrawMachine.ucNumberCounterSliding();
            this.ucNumberCounterSliding3 = new DrawMachine.ucNumberCounterSliding();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(13, 13);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // ucNumberCounterSliding1
            // 
            this.ucNumberCounterSliding1.EndColor = System.Drawing.Color.Red;
            this.ucNumberCounterSliding1.Location = new System.Drawing.Point(268, 91);
            this.ucNumberCounterSliding1.Name = "ucNumberCounterSliding1";
            this.ucNumberCounterSliding1.Size = new System.Drawing.Size(201, 325);
            this.ucNumberCounterSliding1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.ucNumberCounterSliding1.TabIndex = 2;
            this.ucNumberCounterSliding1.TargetValue = 2;
            // 
            // ucNumberCounterSliding2
            // 
            this.ucNumberCounterSliding2.EndColor = System.Drawing.Color.Red;
            this.ucNumberCounterSliding2.Location = new System.Drawing.Point(475, 91);
            this.ucNumberCounterSliding2.Name = "ucNumberCounterSliding2";
            this.ucNumberCounterSliding2.Size = new System.Drawing.Size(201, 325);
            this.ucNumberCounterSliding2.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.ucNumberCounterSliding2.TabIndex = 2;
            this.ucNumberCounterSliding2.TargetValue = 2;
            // 
            // ucNumberCounterSliding3
            // 
            this.ucNumberCounterSliding3.EndColor = System.Drawing.Color.Red;
            this.ucNumberCounterSliding3.Location = new System.Drawing.Point(682, 91);
            this.ucNumberCounterSliding3.Name = "ucNumberCounterSliding3";
            this.ucNumberCounterSliding3.Size = new System.Drawing.Size(201, 325);
            this.ucNumberCounterSliding3.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.ucNumberCounterSliding3.TabIndex = 2;
            this.ucNumberCounterSliding3.TargetValue = 2;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 525);
            this.Controls.Add(this.ucNumberCounterSliding3);
            this.Controls.Add(this.ucNumberCounterSliding2);
            this.Controls.Add(this.ucNumberCounterSliding1);
            this.Controls.Add(this.btnGenerate);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.ResizeEnd += new System.EventHandler(this.frmTest_ResizeEnd);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGenerate;
        private ucNumberCounterSliding ucNumberCounterSliding1;
        private ucNumberCounterSliding ucNumberCounterSliding2;
        private ucNumberCounterSliding ucNumberCounterSliding3;
    }
}