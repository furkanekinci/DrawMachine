using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DrawMachine
{
    public partial class frmDrawing : Form
    {
        int ResultCounterFix = 5;
        int ResultCounter = 0;

        int NoLength = 0;

        DataTable dtList = null;
        DataTable dtDraw = null;

        List<KeyValuePair<string, string>> ValueList = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> ValueListForDraw = new List<KeyValuePair<string, string>>();

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

            lblCount.Text = ValueList.Count.ToString();
        }

        private void HideForDraw()
        {
            btnLoadList.Hide();
            grdList.Hide();

            btnShuffle.Hide();
            btnDraw.Hide();
        }

        private void ShowResult()
        {
            this.ResultCounter = this.ResultCounterFix + 1;
            timShowResult.Enabled = true;
        }

        private void Draw()
        {
            DataGridView grdDraw = new DataGridView();

            grdDraw.AllowUserToAddRows = false;
            grdDraw.AllowUserToDeleteRows = false;
            grdDraw.AllowUserToResizeColumns = false;
            grdDraw.AllowUserToResizeRows = false;
            grdDraw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            grdDraw.BackgroundColor = System.Drawing.SystemColors.Control;
            grdDraw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            grdDraw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdDraw.Location = new System.Drawing.Point(4, 4);
            grdDraw.Margin = new System.Windows.Forms.Padding(4);
            grdDraw.Name = "grdDraw";
            grdDraw.ReadOnly = true;
            grdDraw.RowHeadersVisible = false;
            grdDraw.Visible = true;
            grdDraw.Height = flpDraws.Height;
            grdDraw.Width = 270;
            grdDraw.CellMouseClick += DataGridView_CellMouseClick;

            flpDraws.Controls.Add(grdDraw);

            ValueList.Shuffle();

            List<string> added = new List<string>();
            ValueListForDraw = new List<KeyValuePair<string, string>>();

            if (grdList.DataSource != null)
            {
                Random r = new Random();

                int ind = -1;

                for (int i = 0; i < ValueList.Count; i++)
                {
                    do
                    {
                        ind = r.Next(0, this.ValueList.Count);
                    } while (ValueListForDraw.Any(d => d.Key == this.ValueList[ind].Key));

                    ValueListForDraw.Add(this.ValueList[ind]);

                    dtDraw = new DataTable();
                    dtDraw.Columns.Add("No", typeof(string));
                    dtDraw.Columns.Add("Name", typeof(string));
                    dtDraw.Columns.Add("Count", typeof(int));
                }

                for (int i = 0; i < ValueListForDraw.Count; i++)
                {
                    DataRow dr = dtDraw.NewRow();

                    dr["No"] = ValueListForDraw[i].Key;
                    dr["Name"] = ValueListForDraw[i].Value;
                    dr["Count"] = i;

                    dtDraw.Rows.Add(dr);
                }

                grdDraw.DataSource = dtDraw;
                grdDraw.Columns[0].Width = 30;
                grdDraw.Columns[1].Width = 140;
                grdDraw.Columns[2].Width = 40;
            }
        }

        private void GrdDraw_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GrdDraw_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
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


        public frmDrawing()
        {
            InitializeComponent();
        }
        private void frmNew_Load(object sender, EventArgs e)
        {
        }
        private void frmNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (btnDraw.Visible)
                {
                    Draw();
                }
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
                if (btnDraw.Visible)
                {
                    Draw();
                }
            }
        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (grdList.Visible)
            {
                btnLoadList.Hide();
                grdList.Hide();
                btnShuffle.Hide();

                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                btnLoadList.Show();
                grdList.Show();
                btnShuffle.Show();

                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }
        private void btnLoadList_Click(object sender, EventArgs e)
        {
            ValueList = new List<KeyValuePair<string, string>>();
            grdList.DataSource = null;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;

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

                                    if (c.CellValue.Text.Length > NoLength)
                                    {
                                        NoLength = c.CellValue.Text.Length;
                                    }
                                }
                            }

                            ValueList.Add(new KeyValuePair<string, string>(no, name));
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

                BindGrid();
            }
        }
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void DataGridView_CellMouseClick(Object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                foreach (DataGridView grdDraw in flpDraws.Controls)
                {
                    grdDraw.ClearSelection();
                    grdDraw.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void frmDrawing_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}