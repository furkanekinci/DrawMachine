namespace DrawMachine
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnLoadList = new System.Windows.Forms.Button();
            this.grdList = new System.Windows.Forms.DataGridView();
            this.btnDraw = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.timShowNumbers = new System.Windows.Forms.Timer(this.components);
            this.flpRandoms = new System.Windows.Forms.FlowLayoutPanel();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnShowHide = new System.Windows.Forms.Button();
            this.timShowResult = new System.Windows.Forms.Timer(this.components);
            this.lblItemCount = new System.Windows.Forms.Label();
            this.timMoveNumber = new System.Windows.Forms.Timer(this.components);
            this.timWaiter = new System.Windows.Forms.Timer(this.components);
            this.pbrRandom = new System.Windows.Forms.ProgressBar();
            this.lblRandomMain = new DrawMachine.ucNumberWithRate();
            this.lblLine = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadList
            // 
            this.btnLoadList.Location = new System.Drawing.Point(157, 15);
            this.btnLoadList.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadList.Name = "btnLoadList";
            this.btnLoadList.Size = new System.Drawing.Size(100, 28);
            this.btnLoadList.TabIndex = 0;
            this.btnLoadList.Text = "Load List";
            this.btnLoadList.UseVisualStyleBackColor = true;
            this.btnLoadList.Click += new System.EventHandler(this.btnLoadList_Click);
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
            this.grdList.Location = new System.Drawing.Point(16, 50);
            this.grdList.Margin = new System.Windows.Forms.Padding(4);
            this.grdList.Name = "grdList";
            this.grdList.ReadOnly = true;
            this.grdList.RowHeadersVisible = false;
            this.grdList.Size = new System.Drawing.Size(241, 528);
            this.grdList.TabIndex = 1;
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDraw.Location = new System.Drawing.Point(880, 16);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(4);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(115, 28);
            this.btnDraw.TabIndex = 0;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 300F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.lblNumber.Location = new System.Drawing.Point(295, 103);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(323, 453);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "-";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timShowNumbers
            // 
            this.timShowNumbers.Interval = 10;
            this.timShowNumbers.Tick += new System.EventHandler(this.timShowNumbers_Tick);
            // 
            // flpRandoms
            // 
            this.flpRandoms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpRandoms.Location = new System.Drawing.Point(854, 97);
            this.flpRandoms.Margin = new System.Windows.Forms.Padding(4);
            this.flpRandoms.Name = "flpRandoms";
            this.flpRandoms.Size = new System.Drawing.Size(141, 481);
            this.flpRandoms.TabIndex = 5;
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
            this.btnShowHide.Location = new System.Drawing.Point(16, 15);
            this.btnShowHide.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(100, 28);
            this.btnShowHide.TabIndex = 0;
            this.btnShowHide.Text = "Show/Hide";
            this.btnShowHide.UseVisualStyleBackColor = true;
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // timShowResult
            // 
            this.timShowResult.Interval = 1000;
            this.timShowResult.Tick += new System.EventHandler(this.timShowResult_Tick);
            // 
            // lblItemCount
            // 
            this.lblItemCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblItemCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.lblItemCount.Location = new System.Drawing.Point(797, 51);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(198, 37);
            this.lblItemCount.TabIndex = 7;
            this.lblItemCount.Text = "-";
            this.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timMoveNumber
            // 
            this.timMoveNumber.Interval = 50;
            this.timMoveNumber.Tick += new System.EventHandler(this.timMoveNumber_Tick);
            // 
            // timWaiter
            // 
            this.timWaiter.Interval = 1000;
            this.timWaiter.Tick += new System.EventHandler(this.timWaiter_Tick);
            // 
            // pbrRandom
            // 
            this.pbrRandom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrRandom.Location = new System.Drawing.Point(371, 442);
            this.pbrRandom.Name = "pbrRandom";
            this.pbrRandom.Size = new System.Drawing.Size(206, 4);
            this.pbrRandom.TabIndex = 9;
            // 
            // lblRandomMain
            // 
            this.lblRandomMain.Location = new System.Drawing.Point(613, 52);
            this.lblRandomMain.Margin = new System.Windows.Forms.Padding(4);
            this.lblRandomMain.Name = "lblRandomMain";
            this.lblRandomMain.Number = "-";
            this.lblRandomMain.Rate = "*";
            this.lblRandomMain.Size = new System.Drawing.Size(176, 93);
            this.lblRandomMain.TabIndex = 8;
            this.lblRandomMain.Visible = false;
            // 
            // lblLine
            // 
            this.lblLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.lblLine.Location = new System.Drawing.Point(854, 92);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(142, 1);
            this.lblLine.TabIndex = 10;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.pbrRandom);
            this.Controls.Add(this.lblRandomMain);
            this.Controls.Add(this.lblItemCount);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.flpRandoms);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.btnShowHide);
            this.Controls.Add(this.btnLoadList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Draw Machine";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMain_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadList;
        private System.Windows.Forms.DataGridView grdList;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Timer timShowNumbers;
        private System.Windows.Forms.FlowLayoutPanel flpRandoms;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnShowHide;
        private System.Windows.Forms.Timer timShowResult;
        private System.Windows.Forms.Label lblItemCount;
        private ucNumberWithRate lblRandomMain;
        private System.Windows.Forms.Timer timMoveNumber;
        private System.Windows.Forms.Timer timWaiter;
        private System.Windows.Forms.ProgressBar pbrRandom;
        private System.Windows.Forms.Label lblLine;
    }
}

