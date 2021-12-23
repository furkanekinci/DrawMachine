namespace DrawMachine
{
    partial class frmNumberCounting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNumberCounting));
            this.grdList = new System.Windows.Forms.DataGridView();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnShowHide = new System.Windows.Forms.Button();
            this.lblItemCount = new System.Windows.Forms.Label();
            this.timShowResult = new System.Windows.Forms.Timer(this.components);
            this.btnShuffle = new System.Windows.Forms.Button();
            this.timStarter = new System.Windows.Forms.Timer(this.components);
            this.timWaitForNext = new System.Windows.Forms.Timer(this.components);
            this.lblRate = new System.Windows.Forms.Label();
            this.lblWaitTop = new System.Windows.Forms.Label();
            this.nca = new DrawMachine.ucNumberCounterArray();
            this.lblWaitBottom = new System.Windows.Forms.Label();
            this.lblShortcuts = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // grdList
            // 
            this.grdList.AllowUserToAddRows = false;
            this.grdList.AllowUserToDeleteRows = false;
            this.grdList.AllowUserToResizeColumns = false;
            this.grdList.AllowUserToResizeRows = false;
            this.grdList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdList.Location = new System.Drawing.Point(16, 122);
            this.grdList.Margin = new System.Windows.Forms.Padding(4);
            this.grdList.Name = "grdList";
            this.grdList.ReadOnly = true;
            this.grdList.RowHeadersVisible = false;
            this.grdList.Size = new System.Drawing.Size(275, 420);
            this.grdList.TabIndex = 1;
            this.grdList.Visible = false;
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.lblResult.Location = new System.Drawing.Point(9, 582);
            this.lblResult.Margin = new System.Windows.Forms.Padding(0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(990, 124);
            this.lblResult.TabIndex = 6;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShowHide
            // 
            this.btnShowHide.Location = new System.Drawing.Point(124, 550);
            this.btnShowHide.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(100, 28);
            this.btnShowHide.TabIndex = 0;
            this.btnShowHide.Text = "Show/Hide";
            this.btnShowHide.UseVisualStyleBackColor = true;
            this.btnShowHide.Visible = false;
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // lblItemCount
            // 
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblItemCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.lblItemCount.Location = new System.Drawing.Point(12, 9);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(53, 73);
            this.lblItemCount.TabIndex = 7;
            this.lblItemCount.Text = "-";
            this.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblItemCount.Visible = false;
            // 
            // timShowResult
            // 
            this.timShowResult.Interval = 1000;
            this.timShowResult.Tick += new System.EventHandler(this.timShowResult_Tick);
            // 
            // btnShuffle
            // 
            this.btnShuffle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShuffle.Location = new System.Drawing.Point(16, 550);
            this.btnShuffle.Margin = new System.Windows.Forms.Padding(4);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(100, 28);
            this.btnShuffle.TabIndex = 0;
            this.btnShuffle.Text = "Shuffle";
            this.btnShuffle.UseVisualStyleBackColor = true;
            this.btnShuffle.Visible = false;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // timStarter
            // 
            this.timStarter.Interval = 500;
            this.timStarter.Tick += new System.EventHandler(this.timStarter_Tick);
            // 
            // timWaitForNext
            // 
            this.timWaitForNext.Interval = 10000;
            this.timWaitForNext.Tick += new System.EventHandler(this.timWaitForNext_Tick);
            // 
            // lblRate
            // 
            this.lblRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.lblRate.Location = new System.Drawing.Point(810, 9);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(186, 73);
            this.lblRate.TabIndex = 7;
            this.lblRate.Text = "-";
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRate.Visible = false;
            // 
            // lblWaitTop
            // 
            this.lblWaitTop.BackColor = System.Drawing.Color.Red;
            this.lblWaitTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWaitTop.Location = new System.Drawing.Point(494, 18);
            this.lblWaitTop.Name = "lblWaitTop";
            this.lblWaitTop.Size = new System.Drawing.Size(20, 7);
            this.lblWaitTop.TabIndex = 7;
            this.lblWaitTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nca
            // 
            this.nca.Location = new System.Drawing.Point(319, 162);
            this.nca.Margin = new System.Windows.Forms.Padding(4);
            this.nca.Name = "nca";
            this.nca.Size = new System.Drawing.Size(574, 342);
            this.nca.TabIndex = 8;
            // 
            // lblWaitBottom
            // 
            this.lblWaitBottom.BackColor = System.Drawing.Color.Red;
            this.lblWaitBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWaitBottom.Location = new System.Drawing.Point(494, 34);
            this.lblWaitBottom.Name = "lblWaitBottom";
            this.lblWaitBottom.Size = new System.Drawing.Size(20, 7);
            this.lblWaitBottom.TabIndex = 9;
            this.lblWaitBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShortcuts
            // 
            this.lblShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblShortcuts.AutoSize = true;
            this.lblShortcuts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblShortcuts.Location = new System.Drawing.Point(12, 693);
            this.lblShortcuts.Name = "lblShortcuts";
            this.lblShortcuts.Size = new System.Drawing.Size(336, 13);
            this.lblShortcuts.TabIndex = 10;
            this.lblShortcuts.Text = "F1: Quick Result, F4: Toggle Fullscreeen, F12: Load Data";
            // 
            // frmNumberCounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.lblShortcuts);
            this.Controls.Add(this.lblWaitBottom);
            this.Controls.Add(this.lblWaitTop);
            this.Controls.Add(this.nca);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.lblItemCount);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.btnShowHide);
            this.Controls.Add(this.btnShuffle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "frmNumberCounting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Draw Machine";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNew_Load);
            this.ResizeEnd += new System.EventHandler(this.frmNew_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNew_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmNew_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView grdList;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnShowHide;
        private System.Windows.Forms.Label lblItemCount;
        private ucNumberCounterArray nca;
        private System.Windows.Forms.Timer timShowResult;
        private System.Windows.Forms.Button btnShuffle;
        private System.Windows.Forms.Timer timStarter;
        private System.Windows.Forms.Timer timWaitForNext;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblWaitTop;
        private System.Windows.Forms.Label lblWaitBottom;
        private System.Windows.Forms.Label lblShortcuts;
    }
}

