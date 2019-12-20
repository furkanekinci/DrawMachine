using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DrawMachine
{
    public partial class frmNumberCounting : Form
    {
        System.Media.SoundPlayer Player;

        bool Drawing = false;
        bool FirstClicked = false;

        int ResultCounterFix = 5;
        int ResultCounter = 0;

        int NoLength = 0;

        DataTable dtList = null;

        List<KeyValuePair<string, string>> ValueList = new List<KeyValuePair<string, string>>();

        #region Set Font
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        PrivateFontCollection mFontCollection = new PrivateFontCollection();

        private void SetNumericFont(Label pLabel)
        {
            Stream fontStream = new MemoryStream(DrawMachine.Properties.Resources.digital_7);

            //create an unsafe memory block for the data
            System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
            //create a buffer to read in to
            Byte[] fontData = new Byte[fontStream.Length];
            //fetch the font program from the resource
            fontStream.Read(fontData, 0, (int)fontStream.Length);
            //copy the bytes to the unsafe memory block
            Marshal.Copy(fontData, 0, data, (int)fontStream.Length);

            // We HAVE to do this to register the font to the system (Weird .NET bug !)
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);

            //pass the font to the font collection
            mFontCollection.AddMemoryFont(data, (int)fontStream.Length);
            //close the resource stream
            fontStream.Close();
            //free the unsafe memory
            Marshal.FreeCoTaskMem(data);

            pLabel.Font = new System.Drawing.Font(mFontCollection.Families[0], pLabel.Font.Size);
        }
        #endregion

        private void HideCursor()
        {
            Cursor.Position = new Point(Screen.PrimaryScreen.WorkingArea.Width, 0);
        }

        private void BindGrid()
        {
            dtList = new DataTable();
            dtList.Columns.Add("No", typeof(string));
            dtList.Columns.Add("Name", typeof(string));

            DataRow dr;

            ValueList.Shuffle();

            foreach (KeyValuePair<string, string> item in ValueList)
            {
                dr = dtList.NewRow();

                dr["No"] = item.Key;
                dr["Name"] = item.Value;

                dtList.Rows.Add(dr);
            }

            grdList.DataSource = dtList;
            grdList.Columns[0].Width = 40;

            lblItemCount.Text = ValueList.Count.ToString();
            lblRate.Text = string.Format("%{0:F4}", Convert.ToDecimal(100) / ValueList.Count);
        }

        private void CleanForm()
        {
            nca.Clear();
            lblResult.Text = string.Empty;
        }

        private void ShowResult()
        {
            this.ResultCounter = this.ResultCounterFix + 1;
            timShowResult.Enabled = true;
        }

        private void SetNumberPosition()
        {
            nca.Left = (this.Width - nca.Width) / 2;
            nca.Top = (this.Height - nca.Height) / 2;

            lblWaitTop.Left = nca.Left;
            lblWaitTop.Top = nca.Top - lblWaitTop.Height;
            lblWaitTop.Width = nca.Width;

            lblWaitBottom.Left = nca.Left;
            lblWaitBottom.Top = nca.Top + nca.Height;
            lblWaitBottom.Width = nca.Width;
        }

        private void Draw()
        {
            this.ToggleFullscreen(true);
            this.HideCursor();

            Player.Stop();

            if (grdList.DataSource != null)
            {
                CleanForm();

                Random r = new Random();
                int ind = r.Next(0, this.ValueList.Count);

                this.Drawing = true;
                lblWaitTop.BackColor = System.Drawing.Color.Red;
                lblWaitBottom.BackColor = System.Drawing.Color.Red;

                nca.Draw(this.ValueList[ind].Key);

                SetNumberPosition();
            }
        }

        private void nca_DrawingFinished()
        {
            //LabelFader lf = null;

            //foreach (ucNumberCounter item in nca.Controls)
            //{
            //    lf = new LabelFader();
            //    lf.attachToControl(item.Controls[0] as Label);
            //    lf.setColorSteps(25);
            //    lf.doFade();
            //}

            this.ShowResult();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == /*WM_SIZE*/ 0x0005)
            {
                if (this.WindowState != FormWindowState.Minimized)
                {
                    SetNumberPosition();

                    while (lblResult.Width < System.Windows.Forms.TextRenderer.MeasureText(lblResult.Text, new System.Drawing.Font(lblResult.Font.FontFamily, lblResult.Font.Size, lblResult.Font.Style)).Width)
                    {
                        lblResult.Font = new System.Drawing.Font(lblResult.Font.FontFamily, lblResult.Font.Size - 0.5f, lblResult.Font.Style);
                    }
                }
            }

            base.WndProc(ref m);
        }


        public frmNumberCounting()
        {
            InitializeComponent();

            this.SetNumericFont(lblItemCount);
            this.SetNumericFont(lblRate);
        }
        private void frmNew_Load(object sender, EventArgs e)
        {
            SetNumberPosition();

            Player = new System.Media.SoundPlayer(DrawMachine.Properties.Resources.tik);

            nca.DrawingFinished += nca_DrawingFinished;
        }
        private void frmNew_ResizeEnd(object sender, EventArgs e)
        {
            SetNumberPosition();

            while (lblResult.Width < System.Windows.Forms.TextRenderer.MeasureText(lblResult.Text, new System.Drawing.Font(lblResult.Font.FontFamily, lblResult.Font.Size, lblResult.Font.Style)).Width)
            {
                lblResult.Font = new System.Drawing.Font(lblResult.Font.FontFamily, lblResult.Font.Size - 0.5f, lblResult.Font.Style);
            }
        }
        private void frmNew_KeyDown(object sender, KeyEventArgs e)
        {
            bool draw = false;

            if (e.KeyCode == Keys.F2)
            {
                if (!this.Drawing)
                {
                    this.LoadListData();
                }
            }

            if (this.Drawing
                && e.KeyCode == Keys.F1)
            {
                nca.ShowResult();
            }

            if (e.KeyCode == Keys.F11)
            {
                this.ToggleFullscreen();
            }

            if (e.KeyCode == Keys.F5
                || e.KeyCode == Keys.Oem5
                || e.KeyCode == Keys.Next
                || e.KeyCode == Keys.PageUp
                )
            {
                draw = true;
            }

            if (draw == true
                && !this.Drawing)
            {
                if (!FirstClicked)
                {
                    FirstClicked = true;
                    timStarter.Start();
                }
                else
                {
                    Draw();
                }
            }
        }

        private void ToggleFullscreen(bool pSetFullscreen = false)
        {
            if (pSetFullscreen || this.FormBorderStyle == FormBorderStyle.Sizable)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                HideCursor();
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void LoadListData()
        {
            string fileName = string.Empty;

            string[] filePaths = Directory.GetFiles(Application.StartupPath, "*.xlsx", SearchOption.TopDirectoryOnly);

            if (filePaths.Length == 1)
            {
                fileName = filePaths[0];
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            ofd.Multiselect = false;

            if (string.IsNullOrWhiteSpace(fileName)
                && ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
            }

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                ValueList = new List<KeyValuePair<string, string>>();
                grdList.DataSource = null;

                #region Read Excel
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
                    {
                        WorkbookPart workbookPart = doc.WorkbookPart;
                        SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                        SharedStringTable sst = sstpart.SharedStringTable;

                        WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                        Worksheet sheet = worksheetPart.Worksheet;

                        var cells = sheet.Descendants<Cell>();
                        var rows = sheet.Descendants<Row>();

                        foreach (Row row in rows)
                        {
                            string name = "", no = "";

                            foreach (Cell c in row.Elements<Cell>())
                            {
                                if ((c.DataType != null) && (c.DataType == CellValues.SharedString))
                                {
                                    int ssid = int.Parse(c.CellValue.Text);
                                    string str = sst.ChildElements[ssid].InnerText;

                                    name = str;
                                }
                                else if (c.CellValue != null)
                                {
                                    no = c.CellValue.Text;

                                    if (no.Length > NoLength)
                                    {
                                        NoLength = no.Length;
                                    }
                                }
                            }

                            if (no.Length > 0 && name.Length > 0)
                            {
                                ValueList.Add(new KeyValuePair<string, string>(no, name));
                            }
                        }
                    }
                }
                #endregion

                for (int i = 0; i < ValueList.Count; i++)
                {
                    if (NoLength > ValueList[i].Key.Length)
                    {
                        ValueList[i] = new KeyValuePair<string, string>(ValueList[i].Key.PadLeft(NoLength, '0'), ValueList[i].Value);
                    }
                }

                lblItemCount.Visible = true;
                lblRate.Visible = true;

                BindGrid();

                lblWaitTop.BackColor = System.Drawing.Color.Green;
                lblWaitBottom.BackColor = System.Drawing.Color.Green;

                CleanForm();
            }
        }

        private void frmNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.ActiveControl is Button
               && e.KeyChar == (char)Keys.Space)
            {
                var button = this.ActiveControl;
                button.Enabled = false;
                Application.DoEvents();
                button.Enabled = true;
            }

            if (e.KeyChar == (char)Keys.Space)
            {
                if (!this.Drawing)
                {
                    if (!FirstClicked)
                    {
                        FirstClicked = true;
                        timStarter.Start();
                    }
                    else
                    {
                        Draw();
                    }
                }
            }
        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (grdList.Visible)
            {
                grdList.Hide();
                btnShuffle.Hide();

                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                grdList.Show();
                btnShuffle.Show();

                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        private void timShowResult_Tick(object sender, EventArgs e)
        {
            Player = new System.Media.SoundPlayer(DrawMachine.Properties.Resources.cheering);
            Player.Play();
            Player = new System.Media.SoundPlayer(DrawMachine.Properties.Resources.tik);

            KeyValuePair<string, string> item = ValueList.Where(x => x.Key.Equals(nca.NumberAsString)).First();

            lblResult.Text = item.Value;

            while (lblResult.Width < System.Windows.Forms.TextRenderer.MeasureText(lblResult.Text, new System.Drawing.Font(lblResult.Font.FontFamily, lblResult.Font.Size, lblResult.Font.Style)).Width)
            {
                lblResult.Font = new System.Drawing.Font(lblResult.Font.FontFamily, lblResult.Font.Size - 0.5f, lblResult.Font.Style);
            }

            ValueList.Remove(item);

            this.BindGrid();

            timShowResult.Enabled = false;

            timWaitForNext.Start();
        }

        private void timStarter_Tick(object sender, EventArgs e)
        {
            FirstClicked = false;
            timStarter.Stop();
        }

        private void timWaitForNext_Tick(object sender, EventArgs e)
        {
            lblWaitTop.BackColor = System.Drawing.Color.Green;
            lblWaitBottom.BackColor = System.Drawing.Color.Green;
            this.Drawing = false;
            timWaitForNext.Stop();
        }
    }
}