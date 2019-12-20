using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DrawMachine
{
    public partial class ucNumberCounterSliding : UserControl
    {
        public delegate void CountingFinishedHandler();
        public event CountingFinishedHandler CountingFinished;

        System.Media.SoundPlayer Player;

        double SpeedMultiplier = 1;

        int RandomFirstLimit = 25;
        int FastPeriod = 175;

        int Counter = -1;
        int Sub = 50;

        public int TargetValue { get; set; }
        public Color StartColor { get; set; } = Color.FromArgb(0, 51, 160);
        public Color EndColor { get; set; } = Color.Red;

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

        internal void ShowResult()
        {
            Label currentLabel = null;
            Label otherLabel = null;

            if (lblNumber1.Top > 0
                && lblNumber1.Top < this.Height / 2)
            {
                currentLabel = lblNumber1;
                otherLabel = lblNumber2;
            }
            else
            {
                currentLabel = lblNumber2;
                otherLabel = lblNumber1;
            }

            otherLabel.Top = -otherLabel.Height;
            currentLabel.Top = 0;
            currentLabel.Text = TargetValue.ToString();

            this.SpeedMultiplier = 1D;

            timCountNumbers.Interval = 15;
            timCountNumbers.Enabled = false;

            currentLabel.ForeColor = this.EndColor;

            this.CountingFinished?.Invoke();
        }

        public void Draw(int pTargetValue, int pCounterStart = 0)
        {
            this.TargetValue = pTargetValue;
            this.Counter = pCounterStart;

            this.SpeedMultiplier = 1;


            lblNumber1.Tag = this.Counter;
            lblNumber1.Text = Convert.ToString(lblNumber1.Tag);

            this.Counter++;

            lblNumber2.Tag = this.Counter;
            lblNumber2.Text = Convert.ToString(lblNumber2.Tag);

            timCountNumbers.Interval = 15;
            timCountNumbers.Start();
        }

        public ucNumberCounterSliding()
        {
            InitializeComponent();
        }
        private void ucNumberCounterSliding_Load(object sender, EventArgs e)
        {
            lblNumber1.ForeColor = this.StartColor;

            this.SetNumericFont(lblNumber1);
            this.SetNumericFont(lblNumber2);

            Player = new System.Media.SoundPlayer(DrawMachine.Properties.Resources.tik);
        }
        private void ucNumberCounterSliding_Resize(object sender, EventArgs e)
        {
            //while (lblNumber1.Width < System.Windows.Forms.TextRenderer.MeasureText(lblNumber1.Text, new System.Drawing.Font(lblNumber1.Font.FontFamily, lblNumber1.Font.Size, lblNumber1.Font.Style)).Width)
            //{
            //    lblNumber1.Font = new System.Drawing.Font(lblNumber1.Font.FontFamily, lblNumber1.Font.Size - 0.2f, lblNumber1.Font.Style);
            //}
            //while (lblNumber2.Width < System.Windows.Forms.TextRenderer.MeasureText(lblNumber2.Text, new System.Drawing.Font(lblNumber2.Font.FontFamily, lblNumber2.Font.Size, lblNumber2.Font.Style)).Width)
            //{
            //    lblNumber2.Font = new System.Drawing.Font(lblNumber2.Font.FontFamily, lblNumber2.Font.Size - 0.2f, lblNumber2.Font.Style);
            //}
        }

        private void timCountNumbers_Tick(object sender, EventArgs e)
        {
            this.FastPeriod--;

            lblNumber1.Top -= this.Sub;
            lblNumber2.Top -= this.Sub;

            if (-lblNumber1.Height > lblNumber1.Top)
            {
                lblNumber1.Top = lblNumber2.Top + lblNumber2.Height;

                if (this.Counter < 9)
                {
                    this.Counter++;
                }
                else
                {
                    this.Counter = 0;
                }

                lblNumber1.Tag = this.Counter;
                lblNumber1.Text = Convert.ToString(lblNumber1.Tag);
            }

            if (-lblNumber2.Height > lblNumber2.Top)
            {
                lblNumber2.Top = lblNumber1.Top + lblNumber1.Height;

                if (this.Counter < 9)
                {
                    this.Counter++;
                }
                else
                {
                    this.Counter = 0;
                }

                lblNumber2.Tag = this.Counter;
                lblNumber2.Text = Convert.ToString(lblNumber2.Tag);
            }

            if (0 > this.FastPeriod)
            {
                this.Sub = Convert.ToInt32(this.Sub * this.SpeedMultiplier);

                if (this.Sub > 100)
                {
                    this.Sub = 50;
                }

                this.SpeedMultiplier *= 1.075D;

                if (this.SpeedMultiplier > 5)
                {
                    this.SpeedMultiplier = 1;
                }

                timCountNumbers.Interval += Convert.ToInt32(this.SpeedMultiplier);

                Label currentLabel = null;
                Label otherLabel = null;

                if (lblNumber1.Top > 0
                    && lblNumber1.Top < this.Height / 2)
                {
                    currentLabel = lblNumber1;
                    otherLabel = lblNumber2;
                }
                else
                {
                    currentLabel = lblNumber2;
                    otherLabel = lblNumber1;
                }

                if (timCountNumbers.Interval > this.RandomFirstLimit
                    && Convert.ToInt32(currentLabel.Tag) == this.TargetValue
                    && this.Sub > currentLabel.Top)
                {
                    this.ShowResult();
                }
            }
        }
    }
}