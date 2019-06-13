using DirectShowLib;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViolaJonesTest.Camera;

namespace ViolaJonesTest
{
    public partial class MadeImageFm : Form
    {

        private VideoCapture videoCapture;
        int CameraDevice = 0; //Variable to track camera device selected
        Devices[] WebCams; 
        private Image<Bgr, byte> currentImage;
        private bool captureImageGraberState;
        private int imageWidth;
        private int imageHeight;



        public MadeImageFm()
        {
            InitializeComponent();

            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            WebCams = new Devices[_SystemCamereas.Length];
            for (int i = 0; i < _SystemCamereas.Length; i++)
            {
                WebCams[i] = new Devices(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID); //fill web cam array
                currentDeviceCombo.Items.Add(WebCams[i].ToString());
            }
            if (currentDeviceCombo.Items.Count > 0)
            {
                currentDeviceCombo.SelectedIndex = 0; 
            }
            else
            {
                MessageBox.Show("Не знайдено пристроїв захоплення зображення!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            SetupCapture(currentDeviceCombo.SelectedIndex);
            

        }

        public void SetupCapture(int deviceIndex)
        {
            if (videoCapture != null)
            {
                if(captureImageGraberState)
                {
                    videoCapture.ImageGrabbed -= captureImageGrabberEvent;
                    captureImageGraberState = false;
                }
            }
            else
            {
                videoCapture = new VideoCapture(deviceIndex);
                //videocapture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, CurrentFrameNo);
                videoCapture.ImageGrabbed += captureImageGrabberEvent;
                videoCapture.SetCaptureProperty(CapProp.FrameWidth, imageWidth);
                videoCapture.SetCaptureProperty(CapProp.FrameHeight, imageHeight);
                videoCapture.Start();
                captureImageGraberState = true;
                veryVeryLowSizeItem.Checked = true;
            }
        }


        private void videoCaptureBox_Click(object sender, EventArgs e)
        {
            if (captureImageGraberState)
            {
                videoCapture.Stop();
                captureImageGraberState = false;
            }
            else
            {
                videoCapture.Start();
                captureImageGraberState = true;
            }
        }


        private void captureImageGrabberEvent(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                videoCapture.Retrieve(m);

                currentImage = m.ToImage<Bgr, byte>();
                //currentImage.Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                videoCaptureBox.Image = currentImage.Bitmap;

                Thread.Sleep(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void saveImgBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            
            if (middleSizeItem.Checked == true)
            {
                imageWidth = 1280;
                imageHeight = 720;
            }
            else if (lowSizeItem.Checked == true)
            {
                imageWidth = 960;
                imageHeight = 540;
            }
            else if (veryLowSizeItem.Checked == true)
            {
                imageWidth = 640;
                imageHeight = 480;
            }
            else if (veryVeryLowSizeItem.Checked == true)
            {
                imageWidth = 320;
                imageHeight = 240;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //int width = Convert.ToInt32(videoCaptureBox.Width);
                //int height = Convert.ToInt32(videoCaptureBox.Height);
                Bitmap bitmap = new Bitmap(imageWidth, imageHeight);
                currentImage.Resize(imageWidth, imageHeight, Emgu.CV.CvEnum.Inter.Cubic);
                currentImage.Bitmap.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                ////videoCaptureBox.DrawToBitmap(bitmap, new Rectangle(0, 0, imageWidth, imageHeight));

                ////bitmap.Save(saveFileDialog.FileName, ImageFormat.Jpeg);


                //currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            }
        }

        private void currentDeviceCombo_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void videoCaptureBox_Click_1(object sender, EventArgs e)
        {
            videoCapture.Stop();
        }

        private void MadeImageFm_Load(object sender, EventArgs e)
        {

        }

        private void MadeImageFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            videoCapture.Stop();
            videoCapture.Dispose();
        }
    }
}
