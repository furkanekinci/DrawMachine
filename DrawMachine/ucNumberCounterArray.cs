using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DrawMachine
{
    public partial class ucNumberCounterArray : UserControl
    {
        int CountingFinishCounter = 0;

        public delegate void DrawingFinishedHandler();
        public event DrawingFinishedHandler DrawingFinished;

        public string NumberAsString = "";

        public void Draw(string pNumberAsString)
        {
            this.CountingFinishCounter = 0;
            this.NumberAsString = pNumberAsString;

            this.Controls.Clear();

            int startAt = 0;
            List<int> startAts = new List<int>();

            Random r = null;

            ucNumberCounterSliding nc = null;

            for (int i = 0; i < pNumberAsString.Length; i++)
            {
                nc = new ucNumberCounterSliding();
                nc.Top = 0;
                nc.Left = 0;

                nc.Left = i * nc.Width;

                nc.CountingFinished += nc_CountingFinished;

                this.Controls.Add(nc);
                this.Width = nc.Left + nc.Width;
                this.Height = nc.Height;

                r = new Random();

                do
                {
                    startAt = r.Next(0, 9);

                    if (startAts.Count > 9)
                    {
                        break;
                    }
                } while (startAts.Contains(startAt));

                startAts.Add(startAt);

                nc.Draw(Convert.ToInt32(pNumberAsString[i].ToString()), startAt);
            }
        }

        private void nc_CountingFinished()
        {
            this.CountingFinishCounter++;

            if (this.CountingFinishCounter == this.Controls.Count)
            {
                if (this.DrawingFinished != null)
                {
                    this.DrawingFinished();
                }
            }
        }

        public void Clear()
        {
            this.Controls.Clear();
        }

        public void ShowResult()
        {
            foreach (ucNumberCounterSliding item in this.Controls)
            {
                item.ShowResult();
            }
        }


        public ucNumberCounterArray()
        {
            InitializeComponent();
        }
    }
}