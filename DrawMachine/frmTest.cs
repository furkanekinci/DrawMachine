using System;
using System.Windows.Forms;

namespace DrawMachine
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }
        private void frmTest_Load(object sender, EventArgs e)
        {
        }
        private void frmTest_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int max = 9999;

            Random r = new Random();
            int rInt = r.Next(0, max);

            //ucNumberCounterArray1.Draw(rInt.ToString().PadLeft(max.ToString().Length, '0'));

            //Random r = new Random();
            //int rInt = r.Next(0, 999);

            //string text = rInt.ToString().PadLeft(3, '0');

            //Random rCounter = new Random();

            //ucNumberCounter1.Draw(Convert.ToInt32(text[0].ToString()), rCounter.Next(0, 9));
            //ucNumberCounter2.Draw(Convert.ToInt32(text[1].ToString()), rCounter.Next(0, 9));
            //ucNumberCounter3.Draw(Convert.ToInt32(text[2].ToString()), rCounter.Next(0, 9));
        }
    }
}
