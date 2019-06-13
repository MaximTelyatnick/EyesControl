using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViolaJonesTest
{
    public partial class CustomWaitFm : Form
    {

        public Action Worker { get; set; }
        public CustomWaitFm(Action worker)
        {
            InitializeComponent();
            System.Drawing.Drawing2D.GraphicsPath Form_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Form_Path.AddEllipse(0, 0, this.Width, this.Height);
            Region Form_Region = new Region(Form_Path);
            this.Region = Form_Region;

            if (worker == null)
            {
                throw new ArgumentNullException();
            }
            Worker = worker;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
