using Emgu.CV;
using Emgu.CV.CvEnum;
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
    public partial class MainTabFm : DevExpress.XtraEditors.XtraForm
    {

        VideoCapture videoCapture;

        static string faceFrontalPath = Path.GetFullPath(@"../../data/haarcascade_frontalface_default.xml");
        static string faceProfilPath = Path.GetFullPath(@"../../data/haarcascade_profileface.xml");
        static string eyePath = Path.GetFullPath(@"../../data/haarcascade_eye.xml");

        CascadeClassifier faceFrontalDetector = new CascadeClassifier(faceFrontalPath);
        CascadeClassifier faceProfilDetector = new CascadeClassifier(faceProfilPath);

        FacemarkLBFParams fParams = new FacemarkLBFParams();

        FacemarkLBF facemark;

        // CascadeClassifier classifierFace = new CascadeClassifier(faceFrontalPath);
        //CascadeClassifier classifierEye = new CascadeClassifier(eyePath);

        //настройки камеры
        bool IsPlaying = false;




        int TotalFrames;
        int CurrentFrameNo;
        //Mat CurrentFrame;
        //int FPS;
        bool Pause = false;
        double matrixCam = 1.4;
        int avarageFaceSize = 15;

        Image<Bgr, byte> imgInput;


        public MainTabFm()
        {
            
            InitializeComponent();


            using (CustomWaitFm frm = new CustomWaitFm(LoadSetting))
            {
                frm.ShowDialog(this);
            }


            


        }
        public void LoadSetting()
        {
            FacemarkSettings();

            CameraSettings(0, 640, 360);
        }


        public bool FacemarkSettings()
        {
            try
            {
                fParams.ModelFile = @"lbfmodel.yaml";
                facemark = new FacemarkLBF(fParams);
                facemark.LoadModel(fParams.ModelFile);

                fParams.NLandmarks = 32; // number of landmark points
                fParams.InitShapeN = 10; // number of multiplier for make data augmentation
                fParams.StagesN = 5; // amount of refinement stages
                fParams.TreeN = 6; // number of tree in the model for each landmark point
                fParams.TreeDepth = 5; //he depth of decision tree
                

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("При завантаженны налаштувань виникла помилка" + ex.Message);
                return false;
            }

        }

        public bool CameraSettings(int currentDevics, int frameWidth, int frameHeight)
        {
            videoCapture = new VideoCapture(currentDevics);
            //videocapture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, CurrentFrameNo);
            videoCapture.ImageGrabbed += captureImageGrabberEvent;
            videoCapture.SetCaptureProperty(CapProp.FrameWidth, frameWidth);
            videoCapture.SetCaptureProperty(CapProp.FrameHeight, frameHeight);
            



            return true;
        }

        public static int CompareShapes(Rectangle left, Rectangle right)
        {
            return left.Height.CompareTo(right.Height);
        }

        private void captureImageGrabberEvent(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                videoCapture.Retrieve(m);

                imgInput = m.ToImage<Bgr, Byte>();
                var imgGray = imgInput.Convert<Gray, byte>().Clone(); //Конвертируем в оттенки серого

                imgGray._EqualizeHist();// выравниваем ярксоть (только для черно-белого изображения)

                //imgGray.SmoothGaussian(4);
                imgGray._SmoothGaussian(1);//гауусовский фильтр

                VectorOfRect faces = new VectorOfRect(faceFrontalDetector.DetectMultiScale(imgGray, 1.1, 3, new Size(100,100), new Size(300,300)));//находим все лица
                if (faces.Size > 0)
                {
                    Rectangle[] facesRect = faces.ToArray();// приводим вектор к фигуре
                    //facesRect[0]

                    Array.Sort(facesRect, new Comparison<Rectangle>(CompareShapes));  //сортировка по высоте

                    VectorOfVectorOfPointF landmarks = new VectorOfVectorOfPointF();

                    bool success = facemark.Fit(imgGray, faces, landmarks);//находим точки лица


                    double k = (double)faces[0].Width / imgGray.Width;

                    double s = (matrixCam * avarageFaceSize) / k;


                    PointF[] h = landmarks[0].ToArray();//преобразовываем в массив точек

                   //var point = h.Select(p => new Point(Convert.ToInt32(p.X), Convert.ToInt32(p.Y)));

                    Point[] rightEye = new Point[6];
                    rightEye[0].X = Convert.ToInt32(Math.Round(h[36].X));
                    rightEye[0].Y = Convert.ToInt32(Math.Round(h[36].Y));
                    rightEye[1].X = Convert.ToInt32(Math.Round(h[37].X));
                    rightEye[1].Y = Convert.ToInt32(Math.Round(h[37].Y));
                    rightEye[2].X = Convert.ToInt32(Math.Round(h[38].X));
                    rightEye[2].Y = Convert.ToInt32(Math.Round(h[38].Y));
                    rightEye[3].X = Convert.ToInt32(Math.Round(h[39].X));
                    rightEye[3].Y = Convert.ToInt32(Math.Round(h[39].Y));
                    rightEye[4].X = Convert.ToInt32(Math.Round(h[40].X));
                    rightEye[4].Y = Convert.ToInt32(Math.Round(h[40].Y));
                    rightEye[5].X = Convert.ToInt32(Math.Round(h[41].X));
                    rightEye[5].Y = Convert.ToInt32(Math.Round(h[41].Y));

                    var rightEyeMinimalPoint = rightEye.First(x => x.Y == rightEye.Max(y => y.Y));
                    var rightEyeMaximalPoint = rightEye.First(x => x.Y == rightEye.Min(y => y.Y));

                    Point[] leftEye = new Point[6];
                    leftEye[0].X = Convert.ToInt32(Math.Round(h[42].X));
                    leftEye[0].Y = Convert.ToInt32(Math.Round(h[42].Y));
                    leftEye[1].X = Convert.ToInt32(Math.Round(h[43].X));
                    leftEye[1].Y = Convert.ToInt32(Math.Round(h[43].Y));
                    leftEye[2].X = Convert.ToInt32(Math.Round(h[44].X));
                    leftEye[2].Y = Convert.ToInt32(Math.Round(h[44].Y));
                    leftEye[3].X = Convert.ToInt32(Math.Round(h[45].X));
                    leftEye[3].Y = Convert.ToInt32(Math.Round(h[45].Y));
                    leftEye[4].X = Convert.ToInt32(Math.Round(h[46].X));
                    leftEye[4].Y = Convert.ToInt32(Math.Round(h[46].Y));
                    leftEye[5].X = Convert.ToInt32(Math.Round(h[47].X));
                    leftEye[5].Y = Convert.ToInt32(Math.Round(h[47].Y));

                    var leftEyeMinimalPoint = leftEye.First(x => x.Y == leftEye.Max(y => y.Y));
                    var leftEyeMaximalPoint = leftEye.First(x => x.Y == leftEye.Min(y => y.Y));


                    imgInput.DrawPolyline(leftEye, true, new Bgr(Color.Blue), 1);
                    imgInput.DrawPolyline(rightEye, true, new Bgr(Color.Blue), 1);


                    ////for (int i = 0; i < h.Length; ++i)
                    ////{
                    ////    mas[i].X = Convert.ToInt32(Math.Round(h[i].X));
                    ////    mas[i].Y = Convert.ToInt32(Math.Round(h[i].Y));
                    ////}



                    //imgInput.Draw(h[37], new Bgr(Color.Blue), 2);


                    //imgInput.Draw(new CircleF(mas[41], 10), new Bgr(Color.Gray), 1);


                    //imgInput.DrawPolyline(mas, true, new Bgr(Color.Blue), 2);

                    //////if (success)
                    //////{
                    //////    facesRect = faces.ToArray();
                    //////    for (int i = 0; i < facesRect.Length; i++)
                    //////    {
                    //////        imgInput.Draw(facesRect[0], new Bgr(Color.Blue), 2);
                    //////        FaceInvoke.DrawFacemarks(imgInput, landmarks[i], new Bgr(Color.Blue).MCvScalar);

                    //////    }
                    //////    //return imgInput;
                    //////}
                    //return null;

                    //int cropHeight = (int)Math.Round(facesRect[0].Height * 0.5, 0);

                    //Rectangle eyesAreaRec = new Rectangle(facesRect[0].X, (int)Math.Round(facesRect[0].Y * 1.4), facesRect[0].Width, cropHeight);


                    //for (int i = 0; i < facesRect.Length; i++)
                    //{
                    //    imgInput.Draw(facesRect[0], new Bgr(Color.Blue), 2);
                    //    //FaceInvoke.DrawFacemarks(imgInput, landmarks[i], new Bgr(Color.Blue).MCvScalar);

                    //}

                    //imgInput.Draw(eyesAreaRec, new Bgr(Color.Blue), 2);

                    Invoke(new Action(() =>
                    {
                        if (faces.Size > 0)
                        {
                            faceSizePixelEdit.Text = faces[0].Size.Height.ToString();
                            camLengthEdit.Text = s.ToString();
                            arcScaleComponent1.Value = faces[0].Size.Height;

                            if (rightEyeMaximalPoint.Y > 0 && rightEyeMinimalPoint.Y > 0)
                                rightEyeEdit.Text = Convert.ToString(rightEyeMinimalPoint.Y - rightEyeMaximalPoint.Y);

                        }

                    }));
                    //faceSizePixelEdit.Text = Convert.ToString(k);
                    //Writelabel(0);
                    generalBox.Image = imgInput;

                }
                else if (faces.Size == 0)
                {
                    //faces = new VectorOfRect(faceProfilDetector.DetectMultiScale(imgGray));
                    generalBox.Image = imgInput;
                }


                    
                

                //VectorOfRect faces = new VectorOfRect(faceDetector.DetectMultiScale(grayImage));
                //VectorOfVectorOfPointF landmarks = new VectorOfVectorOfPointF();


                //bool success = facemark.Fit(grayImage, faces, landmarks);
                //PointF[][] f = landmarks.ToArrayOfArray();
                //if (success)
                //{
                //    Rectangle[] facesRect = faces.ToArray();
                //    for (int i = 0; i < facesRect.Length; i++)
                //    {
                //        imgInput.Draw(facesRect[0], new Bgr(Color.Blue), 2);
                //        FaceInvoke.DrawFacemarks(imgInput, landmarks[i], new Bgr(Color.Blue).MCvScalar);

                //    }
                //    return imgInput;
                //}
                //return null;

                //if (faces.Length > 0)
                //    faceSizePixelEdit.Text = Convert.ToString(faces[0].Size.Height * faces[0].Size.Width);
                //faceSizePixelEdit.Text = faces[0].Size.Height.ToString();
                //videoCapture.Pause();
                
                //videoCapture.Start();
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


                Thread.Sleep(1);

                //imageInput = 
                //pictureBox1.Image = m.ToImage<Bgr, byte>().Bitmap;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        public void Writelabel(int info)
        {
            label1.Text = info.ToString();
        } 
        private void settingsMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void showBtn_Click(object sender, EventArgs e)
        {
            videoCapture.Start();
        }

        private void closeShowBtn_Click(object sender, EventArgs e)
        {
            videoCapture.Stop();
        }








        #region Menu Items             
        private void тестуванняЗОднимКадромToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OneFrameTestFm oneFeameTestFm = new OneFrameTestFm())
            {
                oneFeameTestFm.ShowDialog();
            }
        }

        private void тестированиеFacemarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TestFacemarkFm testFacemarkFm = new TestFacemarkFm())
            {
                testFacemarkFm.ShowDialog();
            }
        }

        private void тестированиеВидепотокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsFm settingsFm = new SettingsFm())
            {
                settingsFm.ShowDialog();
            }
        }



        #endregion

        private void faceSizeCaug_Changed(object sender, EventArgs e)
        {
            
        }

        private void інформаціяПроРозробникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsUserFm settingsUserFm = new SettingsUserFm())
            {
                settingsUserFm.ShowDialog();
            }
        }
    }
}
