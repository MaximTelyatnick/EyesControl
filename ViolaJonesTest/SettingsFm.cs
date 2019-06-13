using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViolaJonesTest
{
    public partial class SettingsFm : Form
    {
        VideoCapture videocapture;


        static string facePath = Path.GetFullPath(@"../../data/haarcascade_frontalface_default.xml");
        static string eyePath = Path.GetFullPath(@"../../data/haarcascade_eye.xml");
        

            //CascadeClassifier faceDetector = new CascadeClassifier(@"..\..\Resource\EMGUCV\haarcascade_frontalface_default.xml");
            CascadeClassifier faceDetector = new CascadeClassifier(facePath);
            FacemarkLBFParams fParams = new FacemarkLBFParams();
        //fParams.ModelFile = @"..\..\Resource\EMGUCV\lbfmodel.yaml";

        FacemarkLBF facemark;

        CascadeClassifier classifierFace = new CascadeClassifier(facePath);
        CascadeClassifier classifierEye = new CascadeClassifier(eyePath);

        bool IsPlaying = false;
        int TotalFrames;
        int CurrentFrameNo;
        Mat CurrentFrame;
        int FPS;
        bool Pause = false;

        Image<Bgr, byte> imgInput;


        public SettingsFm()
        {
            InitializeComponent();
            fParams.ModelFile = @"lbfmodel.yaml";
            facemark = new FacemarkLBF(fParams);
            facemark.LoadModel(fParams.ModelFile);
            
            fParams.NLandmarks = 32; // number of landmark points
            fParams.InitShapeN = 10; // number of multiplier for make data augmentation
            fParams.StagesN = 5; // amount of refinement stages
            fParams.TreeN = 6; // number of tree in the model for each landmark point
            fParams.TreeDepth = 5; //he depth of decision tree
        }

        public Image<Bgr, Byte> GetFacePoints()
        {

            
            //facemark.SetFaceDetector(MyDetector);

            Image<Bgr, Byte> image = new Image<Bgr, byte>("test.png");


            Image<Gray, byte> grayImage = imgInput.Convert<Gray, byte>();

            grayImage._EqualizeHist();

            VectorOfRect faces = new VectorOfRect(faceDetector.DetectMultiScale(grayImage));
            VectorOfVectorOfPointF landmarks = new VectorOfVectorOfPointF();
            

            bool success = facemark.Fit(grayImage, faces, landmarks);
            PointF[][] f = landmarks.ToArrayOfArray();
            if (success)
            {
                Rectangle[] facesRect = faces.ToArray();
                for (int i = 0; i < facesRect.Length; i++)
                {
                    imgInput.Draw(facesRect[0], new Bgr(Color.Blue), 2);
                    FaceInvoke.DrawFacemarks(imgInput, landmarks[i], new Bgr(Color.Blue).MCvScalar);

                }
                return imgInput;
            }
            return null;
        }
        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            if (fileCheck.Checked)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Video Files (*.mp4, *.flv)| *.mp4;*.flv";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    videocapture = new VideoCapture(ofd.FileName);
                    TotalFrames = Convert.ToInt32(videocapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount));
                    FPS = Convert.ToInt32(videocapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps));
                    IsPlaying = true;
                    CurrentFrame = new Mat();
                    CurrentFrameNo = 0;
                    trackBar1.Minimum = 0;
                    trackBar1.Maximum = TotalFrames - 1;
                    trackBar1.Value = 0;
                    PlayVideo();
                }
            }
            else
            {
                //OpenFileDialog ofd = new OpenFileDialog();

                //if (ofd.ShowDialog() == DialogResult.OK)
                //{

                    videocapture = new VideoCapture(0);
                    Mat m = new Mat();
                    videocapture.ImageGrabbed += Capture_ImageGrabbed;
                    videocapture.Start();
                //}
            }
        }

        private async void PlayVideo()
        {
            if (videocapture == null)
            {
                return;
            }


            try
            {
                while (IsPlaying == true && CurrentFrameNo < TotalFrames)
                {
                    videocapture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, CurrentFrameNo);
                    videocapture.Read(CurrentFrame);
                    pictureBox1.Image = CurrentFrame.Bitmap;
                    trackBar1.Value = CurrentFrameNo;
                    CurrentFrameNo += 1;
                    await Task.Delay(1000 / FPS);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {

                while (!Pause)
                {
                    Mat m = new Mat();
                    videocapture.Read(m);

                    if (!m.IsEmpty)
                    {
                        pictureBox1.Image = m.Bitmap;
                        double fps = videocapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);
                        await Task.Delay(1000 / Convert.ToInt32(fps));
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                videocapture.Retrieve(m);

                imgInput = m.ToImage<Bgr, Byte>();

                //////var imgGray = imgInput.Convert<Gray, byte>().Clone();
                //////Rectangle[] faces = classifierFace.DetectMultiScale(imgGray, 1.1, 4);
                //////foreach (var face in faces)
                //////{
                //////    imgInput.Draw(face, new Bgr(0, 0, 255), 2);

                //////    imgGray.ROI = face;
                //////    Rectangle[] eyes = classifierEye.DetectMultiScale(imgGray, 1.1, 4);
                //////    foreach (var eye in eyes)
                //////    {
                //////        var ec = eye;
                //////        ec.X += face.X;
                //////        ec.Y += face.Y;
                //////        imgInput.Draw(ec, new Bgr(0, 255, 0), 2);
                //////    }
                //////}


                pictureBox1.Image = GetFacePoints().Bitmap;
                Thread.Sleep(1);
                //imageInput = 
                //pictureBox1.Image = m.ToImage<Bgr, byte>().Bitmap;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }
        private void playBtn_Click(object sender, EventArgs e)
        {
            if (videocapture != null)
            {
                IsPlaying = true;
                PlayVideo();
            }

            else
            {
                IsPlaying = false;
            }
        }


        //public void DetectFaceHaar()
        //{
        //    try
        //    {
                

        //        var imgGray = imgInput.Convert<Gray, byte>().Clone();
        //        Rectangle[] faces = classifierFace.DetectMultiScale(imgGray, 1.1, 4);
        //        foreach (var face in faces)
        //        {
        //            imgInput.Draw(face, new Bgr(0, 0, 255), 2);

        //            imgGray.ROI = face;
        //            Rectangle[] eyes = classifierEye.DetectMultiScale(imgGray, 1.1, 4);
        //            foreach (var eye in eyes)
        //            {
        //                var e = eye;
        //                e.X += face.X;
        //                e.Y += face.Y;
        //                imgInput.Draw(e, new Bgr(0, 255, 0), 2);
        //            }
        //        }
        //        pictureBox1.Image = imgInput.Bitmap;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        private void resumeBtn_Click(object sender, EventArgs e)
        {
            IsPlaying = false;

        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            IsPlaying = false;
            CurrentFrameNo = 0;
            trackBar1.Value = 0;
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (videocapture != null)
            {
                CurrentFrameNo = trackBar1.Value;
            }
        }
    }
}
