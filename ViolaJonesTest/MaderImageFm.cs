using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ViolaJonesTest
{
    public partial class MaderImageFm : DevExpress.XtraEditors.XtraForm
    {
        public MaderImageFm()
        {
            InitializeComponent();
            barAndDockingController.AppearancesBar.Dock.BackColor = Color.FromArgb(86, 198, 184);
            this.BackColor = Color.FromArgb(86, 198, 184);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}