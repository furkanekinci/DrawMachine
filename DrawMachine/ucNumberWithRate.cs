using System;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DrawMachine
{
    public partial class ucNumberWithRate : UserControl
    {
        public object Tag
        {
            get
            {
                return lblNumber.Tag;
            }
            set
            {
                lblNumber.Tag = value;
            }
        }
        public override string Text
        {
            get
            {
                return lblNumber.Text;
            }
            set
            {
                lblNumber.Text = value;
            }
        }
        public string Number
        {
            get
            {
                return lblNumber.Text;
            }
            set
            {
                lblNumber.Text = value;
            }
        }
        public string Rate
        {
            get
            {
                return lblRate.Text;
            }
            set
            {
                lblRate.Text = value;
            }
        }

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

        public ucNumberWithRate()
        {
            InitializeComponent();
        }

        private void ucNumberWithRate_Load(object sender, EventArgs e)
        {
            this.SetNumericFont(lblNumber);
            this.SetNumericFont(lblRate);
        }
    }
}
