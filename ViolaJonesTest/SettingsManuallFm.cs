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
using DevExpress.XtraBars.Controls;
using System.Runtime.InteropServices;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Utils;

namespace ViolaJonesTest
{
    public partial class SettingsManuallFm : DevExpress.XtraEditors.XtraForm
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private Point mouseOffset;


        public SettingsManuallFm()
        {
            InitializeComponent();
            settingsBar.ForceInitialize();
            CustomBarControl barControl = bar1.GetBarControl();

            try
            {
                InitalizeLocalSettings();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Помилка при оновленні параметрів!\n" + ex.Message, "Отримання налаштувань", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }

        public void InitalizeLocalSettings()
        {
            leftEyeCloseEdit.Text = ConfigClass.Instance.GlobalLocalSettings.HeightCloseLeftEye.ToString();
            rightEyeCloseEdit.Text = ConfigClass.Instance.GlobalLocalSettings.HeightCloseRightEye.ToString();
            leftEyeOpenEdit.Text = ConfigClass.Instance.GlobalLocalSettings.HeightOpenLeftEye.ToString();
            rightEyeOpenEdit.Text = ConfigClass.Instance.GlobalLocalSettings.HeightOpenRightEye.ToString();

            avarageFaceEdit.Text = ConfigClass.Instance.GlobalLocalSettings.AvarageFaceSize.ToString();
            lengthFromCamToFaceEdit.Text = ConfigClass.Instance.GlobalLocalSettings.NormalLenghtFromUserToCam.ToString();
            lengthFromLinearToCamEdit.Text = ConfigClass.Instance.GlobalLocalSettings.LenghtFromLinearToCam.ToString();
            matrixSizeEdit.Text = ConfigClass.Instance.GlobalLocalSettings.MatrixCam.ToString();
            linearLengthEdit.Text = ConfigClass.Instance.GlobalLocalSettings.LenghtLinear.ToString();

            allowDisableScreenEdit.Checked = ConfigClass.Instance.GlobalLocalSettings.AllowDisableScreen;
            saveSettingsEdit.Checked = ConfigClass.Instance.GlobalLocalSettings.LoadlocalSettings;
            saveStatisticsEdit.Checked = ConfigClass.Instance.GlobalLocalSettings.SaveStatistics;

        }

        private void SettingsManuallFm_Load(object sender, EventArgs e)
        {
            CustomBarControl barControl = ((IDockableObject)bar1).BarControl as CustomBarControl;
            barControl.MouseDown += new MouseEventHandler(barControl_MouseDown);

            barAndDockingController.AppearancesBar.Dock.BackColor = Color.FromArgb(86, 198, 184);
            this.BackColor = Color.FromArgb(86, 198, 184);
        }

        #region Custom Window                                                      

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void barControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            CustomBarControl barControl = (CustomBarControl)sender;
            BarItemLink link = barControl.GetLinkByPoint(Control.MousePosition, true);
            if (link != null)
                return;

            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }


        #endregion

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigClass.Instance.SetLocalSettings();
                DialogResult = DialogResult.OK;
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при оновленні параметрів!\n" + ex.Message, "Оновлення налаштувань", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
        }




        #region Event's                   

        private void saveStatisticsEdit_EditValueChanged(object sender, EventArgs e)
        {
            ConfigClass.Instance.GlobalLocalSettings.SaveStatistics = saveStatisticsEdit.Checked;

        }

        private void saveSettingsEdit_EditValueChanged(object sender, EventArgs e)
        {
            ConfigClass.Instance.GlobalLocalSettings.LoadlocalSettings = saveSettingsEdit.Checked;
        }

        private void allowDisableScreenEdit_EditValueChanged(object sender, EventArgs e)
        {
            ConfigClass.Instance.GlobalLocalSettings.AllowDisableScreen = allowDisableScreenEdit.Checked;
                //\Convert.ToBoolean(allowDisableScreenEdit.Text);
        }

        private void matrixSizeEdit_TextChanged(object sender, EventArgs e)
        {
            ConfigClass.Instance.GlobalLocalSettings.MatrixCam = Convert.ToDouble(matrixSizeEdit.Text);
        }

        private void linearLengthEdit_TextChanged(object sender, EventArgs e)
        {
            ConfigClass.Instance.GlobalLocalSettings.LenghtLinear = Convert.ToDouble(linearLengthEdit.Text);
        }

        private void lengthFromLinearToCamEdit_TextChanged(object sender, EventArgs e)
        {
            ConfigClass.Instance.GlobalLocalSettings.LenghtFromLinearToCam = Convert.ToDouble(lengthFromLinearToCamEdit.Text);
        }

        private void rightEyeOpenEdit_TextChanged(object sender, EventArgs e)
        {
            ConfigClass.Instance.GlobalLocalSettings.HeightOpenRightEye = Convert.ToDouble(rightEyeOpenEdit.Text);
        }

        private void leftEyeOpenEdit_TextChanged(object sender, EventArgs e)
        {
            ConfigClass.Instance.GlobalLocalSettings.HeightOpenLeftEye = Convert.ToDouble(leftEyeOpenEdit.Text);
        }

        private void rightEyeCloseEdit_TextChanged(object sender, EventArgs e)
        {
            ConfigClass.Instance.GlobalLocalSettings.HeightCloseRightEye = Convert.ToDouble(rightEyeCloseEdit.Text);
        }

        private void leftEyeCloseEdit_TextChanged(object sender, EventArgs e)
        {
            ConfigClass.Instance.GlobalLocalSettings.HeightCloseLeftEye = Convert.ToDouble(leftEyeCloseEdit.Text);
        }

        private void avarageFaceEdit_TextChanged(object sender, EventArgs e)
        {
            ConfigClass.Instance.GlobalLocalSettings.AvarageFaceSize = Convert.ToInt32(avarageFaceEdit.Text);
        }

        private void lengthFromCamToFaceEdit_TextChanged(object sender, EventArgs e)
        {
            ConfigClass.Instance.GlobalLocalSettings.NormalLenghtFromUserToCam = Convert.ToInt32(lengthFromCamToFaceEdit.Text);
        }

        #endregion

    }
}