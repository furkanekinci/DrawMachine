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
    public partial class frmMain : Form
    {
        int ResultCounterFix = 3;
        int ResultCounter = 0;

        int NoLength = 0;

        DataTable dtList = null;

        List<KeyValuePair<string, string>> ValueList = new List<KeyValuePair<string, string>>();

        List<int> PossibleNextValues = null;

        Label lblMoveNumber = null;
        double NumberMoveSize = 1;

        double RandomNumberMultiplier = 1;

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

            foreach (KeyValuePair<string, string> item in ValueList.OrderBy(x=>x.Value))
            {
                dr = dtList.NewRow();

                dr["No"] = item.Key;
                dr["Name"] = item.Value;

                dtList.Rows.Add(dr);
            }

            grdList.DataSource = dtList;
            grdList.Columns[0].Visible = false;

            lblItemCount.Text = ValueList.Count.ToString();
        }

        private void CleanForm()
        {
            SetNumber("-");
            lblResult.Text = "";

            flpRandoms.Tag = null;

            for (int i = 0; i < flpRandoms.Controls.Count; i++)
            {
                ucNumberWithRate lbl = flpRandoms.Controls[i] as ucNumberWithRate;

                lbl.Tag = null;
                lbl.Text = "";
                lbl.Rate = "";
            }
        }

        private void HideForDraw()
        {
            btnLoadList.Hide();
            grdList.Hide();

            btnDraw.Hide();
        }

        private List<int> GetPossibleValues()
        {
            int foundCount = flpRandoms.Tag.ToString().Length;
            int nextPos = Convert.ToInt32(flpRandoms.Controls[foundCount].Tag);

            Dictionary<int, int> positions = new Dictionary<int, int>();

            for (int i = 0; i < foundCount; i++)
            {
                positions.Add(Convert.ToInt32(flpRandoms.Controls[i].Tag), Convert.ToInt32(flpRandoms.Controls[i].Text));
            }

            List<int> retVal = new List<int>();

            List<string> values = new List<string>();

            if (positions.Count == 0)
            {
                int index = Convert.ToInt32(flpRandoms.Controls[0].Tag);

                retVal = ValueList.Select(x => Convert.ToInt32(x.Key[index].ToString())).Distinct().ToList();
            }
            else
            {
                ValueList.ForEach(x =>
                {
                    bool ok = true;

                    foreach (KeyValuePair<int, int> item in positions)
                    {
                        if (Convert.ToInt32(x.Key[item.Key].ToString()) != item.Value)
                        {
                            ok = false;
                            break;
                        }
                    }

                    if (ok)
                    {
                        values.Add(x.Key);
                    }
                });

                if (values.Count > 0)
                {
                    retVal = values.Select(x => Convert.ToInt32(x[nextPos].ToString())).Distinct().ToList();
                }
            }

            return retVal;
        }

        private void RandomizeOrder()
        {
            List<int> randomList = new List<int>();
            List<int> inputList = new List<int>();

            for (int i = 0; i < NoLength; i++)
            {
                inputList.Add(i);
            }

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count);
                randomList.Add(inputList[randomIndex]);
                inputList.RemoveAt(randomIndex);
            }

            for (int i = 0; i < randomList.Count; i++)
            {
                flpRandoms.Controls[i].Tag = randomList[i];
            }

            flpRandoms.Tag = "";
        }
        private void PrepareNextNumber()
        {
            this.PossibleNextValues = GetPossibleValues();
        }

        private void ShowResult()
        {
            this.ResultCounter = this.ResultCounterFix + 1;            
            timShowResult.Enabled = true;
        }

        private int CalculateRate()
        {
            int retVal = 0;

            int foundCount = flpRandoms.Tag.ToString().Length;

            List<string> randomNums = new List<string>();
            List<string> values = new List<string>();

            for (int i = 0; i < foundCount; i++)
            {
                randomNums.Add(flpRandoms.Controls[i].Text);
            }

            ValueList.ForEach(x =>
            {
                bool ok = true;

                foreach (string no in randomNums)
                {
                    int count = randomNums.Where(t => t.ToString().Equals(no)).Count();

                    if (!x.Key.Contains(no))
                    {
                        ok = false;
                        break;
                    }
                    else if (count > x.Key.Where(t => t.ToString().Equals(no)).Count())
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok && !values.Contains(x.Key))
                {
                    values.Add(x.Key);
                }
            });

            retVal = values.Count;

            return retVal;
        }

        private void SetNumberPosition()
        {
            lblNumber.Left = (this.Width - lblNumber.Width) / 2;
            lblNumber.Top = (this.Height - lblNumber.Height) / 2;

            pbrRandom.Width = 350;
            pbrRandom.Left = (this.Width - pbrRandom.Width) / 2;
            pbrRandom.Top = lblNumber.Top + lblNumber.Height;
        }
        private void SetNumber(object pText)
        {
            lblNumber.Text = pText.ToString();
            SetNumberPosition();
        }

        private void Draw()
        {
            if (grdList.DataSource != null)
            {
                HideForDraw();

                CleanForm();

                RandomizeOrder();

                PrepareNextNumber();

                timShowNumbers.Enabled = true;
            }
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


        public frmMain()
        {
            InitializeComponent();

            this.SetNumericFont(lblNumber);
            this.SetNumericFont(lblItemCount);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            SetNumberPosition();
        }
        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            SetNumberPosition();

            while (lblResult.Width < System.Windows.Forms.TextRenderer.MeasureText(lblResult.Text, new System.Drawing.Font(lblResult.Font.FontFamily, lblResult.Font.Size, lblResult.Font.Style)).Width)
            {
                lblResult.Font = new System.Drawing.Font(lblResult.Font.FontFamily, lblResult.Font.Size - 0.5f, lblResult.Font.Style);
            }
        }
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (btnDraw.Visible)
                {
                    Draw();
                }
            }
        }
        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
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

                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                btnLoadList.Show();
                grdList.Show();

                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }
        private void btnLoadList_Click(object sender, EventArgs e)
        {
            flpRandoms.Controls.Clear();

            ValueList = new List<KeyValuePair<string, string>>();

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

                for (int i = 0; i < NoLength; i++)
                {
                    ucNumberWithRate lbl = lblRandomMain.CloneUC();
                    lbl.Text = "";
                    lbl.Visible = false;

                    flpRandoms.Controls.Add(lbl);
                }

                BindGrid();
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void timShowNumbers_Tick(object sender, EventArgs e)
        {
            pbrRandom.Maximum = 500;

            Random r = new Random();
            int rInt = -1, preVal = -1;

            if (this.PossibleNextValues.Count > 1)
            {
                int counter = 0;

                do
                {
                    rInt = r.Next(0, this.PossibleNextValues.Count);

                    if (counter >= 10)
                    {
                        break;
                    }
                } while (rInt == preVal);
            }
            else
            {
                rInt = r.Next(0, this.PossibleNextValues.Count);
            }

            SetNumber(this.PossibleNextValues[rInt]);

            this.RandomNumberMultiplier *= 1.11D;
            timShowNumbers.Interval += Convert.ToInt32(this.RandomNumberMultiplier); ;

            if (pbrRandom.Maximum > timShowNumbers.Interval)
            {
                pbrRandom.Value = timShowNumbers.Interval;
            }
            else
            {
                pbrRandom.Value = pbrRandom.Maximum;
            }

            if (timShowNumbers.Interval > 500)
            {
                this.RandomNumberMultiplier = 1D;

                timShowNumbers.Interval = 15;
                timShowNumbers.Enabled = false;

                flpRandoms.Tag = flpRandoms.Tag.ToString() + lblNumber.Text;

                string tag = flpRandoms.Tag.ToString();

                (flpRandoms.Controls[tag.Length - 1] as ucNumberWithRate).Number = lblNumber.Text;
                (flpRandoms.Controls[tag.Length - 1] as ucNumberWithRate).Rate = CalculateRate().ToString();

                if (flpRandoms.Controls.Count > tag.Length)
                {
                    PrepareNextNumber();
                }

                lblNumber.Visible = false;

                (flpRandoms.Controls[tag.Length - 1] as ucNumberWithRate).Visible = false;

                lblMoveNumber = lblNumber.Clone();
                lblMoveNumber.BringToFront();
                lblMoveNumber.Visible = true;

                LabelFader lf = new LabelFader();
                lf.attachToControl(lblMoveNumber);
                lf.setColorSteps(20);
                lf.doFade();
                 
                timMoveNumber.Enabled = true;
            }
        }
        private void timShowResult_Tick(object sender, EventArgs e)
        {
            timShowResult.Interval = 1000;

            this.ResultCounter--;

            if (this.ResultCounter > 0)
            {
                lblNumber.ForeColor = System.Drawing.Color.Red;
                SetNumber(this.ResultCounter);
            }
            else
            {
                lblNumber.ForeColor = System.Drawing.Color.FromArgb(0, 51, 160);
                SetNumber("*");

                string code = "".PadLeft(NoLength, '*');

                for (int i = 0; i < flpRandoms.Controls.Count; i++)
                {
                    ucNumberWithRate lbl = (flpRandoms.Controls[i] as ucNumberWithRate);

                    code = code.Insert(Convert.ToInt32(flpRandoms.Controls[i].Tag), lbl.Text);
                    code = code.Remove(Convert.ToInt32(flpRandoms.Controls[i].Tag) + 1, 1);
                }

                KeyValuePair<string, string> item = ValueList.Where(x => x.Key.Equals(code)).First();

                lblResult.Text = code + " - " + item.Value;

                while (lblResult.Width < System.Windows.Forms.TextRenderer.MeasureText(lblResult.Text, new System.Drawing.Font(lblResult.Font.FontFamily, lblResult.Font.Size, lblResult.Font.Style)).Width)
                {
                    lblResult.Font = new System.Drawing.Font(lblResult.Font.FontFamily, lblResult.Font.Size - 0.5f, lblResult.Font.Style);
                }

                ValueList.Remove(item);

                this.BindGrid();

                timShowResult.Enabled = false;

                btnDraw.Show();
            }
        }

        private void timMoveNumber_Tick(object sender, EventArgs e)
        {
            if (flpRandoms.Left > lblMoveNumber.Left)
            {
                this.NumberMoveSize *= 1.7D;
                lblMoveNumber.Left += Convert.ToInt32(this.NumberMoveSize);
            }
            else
            {
                this.NumberMoveSize = 1;

                string tag = flpRandoms.Tag.ToString();

                timMoveNumber.Enabled = false;
                lblMoveNumber.Visible = false;

                (flpRandoms.Controls[flpRandoms.Tag.ToString().Length - 1] as ucNumberWithRate).Visible = true;

                SetNumber("-");
                lblNumber.Visible = true;

                if (flpRandoms.Controls.Count > tag.Length)
                {
                    timWaiter.Enabled = true;
                }
                else
                {
                    ShowResult();
                }
            }
        }

        private void timWaiter_Tick(object sender, EventArgs e)
        {
            timWaiter.Enabled = false;
            timShowNumbers.Enabled = true;
        }
    }
}