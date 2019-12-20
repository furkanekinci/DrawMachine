using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DrawMachine
{
    public partial class ucNumberCounter : UserControl
    {
        public delegate void CountingFinishedHandler();
        public event CountingFinishedHandler CountingFinished;

        System.Media.SoundPlayer Player;

        double SpeedMultiplier = 1;

        int RandomFirstLimit = 350;

        int Counter = -1;

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

        private void SetNumberPosition()
        {
            lblNumber.Left = (this.Width - lblNumber.Width) / 2;
            lblNumber.Top = (this.Height - lblNumber.Height) / 2;
        }
        private void SetNumber(object pText)
        {
            lblNumber.Text = pText.ToString();
            SetNumberPosition();
        }

        public void Draw(int pTargetValue, int pCounterStart = 0)
        {
            this.TargetValue = pTargetValue;
            this.Counter = pCounterStart;

            this.SpeedMultiplier = 1;

            timCountNumbers.Interval = 15;
            timCountNumbers.Start();
        }

        public ucNumberCounter()
        {
            InitializeComponent();
        }
        private void ucNumberCounter_Load(object sender, EventArgs e)
        {
            lblNumber.ForeColor = this.StartColor;

            this.SetNumericFont(lblNumber);

            Player = new System.Media.SoundPlayer(DrawMachine.Properties.Resources.tik);
        }
        private void ucNumberCounter_Resize(object sender, EventArgs e)
        {
            SetNumberPosition();
        }

        private void timCountNumbers_Tick(object sender, EventArgs e)
        {
            if (this.Counter >= 9)
            {
                this.Counter = -1;
            }

            SetNumber(++this.Counter);

            this.SpeedMultiplier *= 1.11D;
            timCountNumbers.Interval += Convert.ToInt32(this.SpeedMultiplier);

            if (timCountNumbers.Interval > this.RandomFirstLimit)
            {
                Player.Stop();
                Player.Play();

                if (this.Counter == this.TargetValue)
                {
                    this.SpeedMultiplier = 1D;

                    timCountNumbers.Interval = 15;
                    timCountNumbers.Enabled = false;

                    lblNumber.ForeColor = this.EndColor;

                    if (this.CountingFinished != null)
                    {
                        this.CountingFinished();
                    }
                }
            }
        }
    }
}