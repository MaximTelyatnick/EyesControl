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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViolaJonesTest
{
    public partial class OneFrameTestFm : Form
    {
        static string facePath = Path.GetFullPath(@"../../data/haarcascade_frontalface_default.xml");
        static string eyePath = Path.GetFullPath(@"../../data/haarcascade_eye.xml");

        CascadeClassifier classifierFace = new CascadeClassifier(facePath);
        CascadeClassifier classifierEye = new CascadeClassifier(eyePath);

        Image<Bgr, byte> colorInputImage;
        Image<Gray, byte> grayImage;
        Image<Gray, byte> grayImageWithFaces;
        Image<Gray, byte> grayImgeOnlyFace;
        Image<Gray, byte> grayImgeAreaForSearchEyes;

        Image<Gray, byte> grayImageLeftEye;
        Image<Gray, byte> grayImageRightEye;

        Image<Gray, byte> grayImageRightEyeBinar;
        Image<Gray, byte> grayImageLeftEyeBinar;

        Image<Gray, byte> temp;
        Rectangle[] facesRecs;
        Rectangle eyesAreaRec;

        Rectangle[] eyes;

        public OneFrameTestFm()
        {
            InitializeComponent();
            colorInputImage = new Image<Bgr, byte>("test.png");
            firstShowBox.Image = colorInputImage.Bitmap;
            firstSteepBtn_Click(this, new EventArgs());
        }

        private void loadImageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    colorInputImage = new Image<Bgr, byte>(dialog.FileName);
                    firstShowBox.Image = colorInputImage.Bitmap;
                }
                else
                {
                    throw new Exception("No file selected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void madeImageBtn_Click(object sender, EventArgs e)
        {
            using (MadeImageFm madeImageFm = new MadeImageFm())
            {
                madeImageFm.ShowDialog();
            }
        }

        private void firstSteepBtn_Click(object sender, EventArgs e)
        {
            //secondShowBox.Image = imgInput.Convert<Gray, byte>();

            grayImage = colorInputImage.Convert<Gray, Byte>();
            secondShowBox.Image = grayImage.Bitmap;
            //.Convert<Gray, byte>().Clone();
            secondSteepBtn_Click(this, new EventArgs());

        }

        private void secondSteepBtn_Click(object sender, EventArgs e)
        {
            facesRecs = classifierFace.DetectMultiScale(grayImage, 1.1, 4);// тут можно указать и размер окна поиска

            grayImageWithFaces = new Image<Gray, byte>(grayImage.Size);
            grayImageWithFaces.Bitmap = grayImage.Bitmap;
                //grayImage.Bitmap;
            grayImageWithFaces.Draw(facesRecs[0], new Gray(255), 2);




            //foreach (var face in faces)
            //{
            //    grayImageWithFaces.Draw(face, new Gray(255), 2);
            //    grayImageWithFaces.ROI = face;
            //    //Mat myNewMat = new Mat(grayImage, face);

            //}
            //grayImageWithFaces.Draw(faces[0], new Gray(255), 2);
            //grayImageWithFaces.ROI = faces[0];
            //thirdShowBox.Image = grayImageWithFaces.Bitmap;

            thirdShowBox.Image = grayImageWithFaces.Bitmap;

            thirdSteepBtn_Click(this, new EventArgs());

        }

        private void thirdSteepBtn_Click(object sender, EventArgs e)
        {
            Mat newMat = crop_gray_frame(grayImage.Mat, facesRecs[0]);

            

            grayImgeOnlyFace = new Image<Gray, byte>(newMat.Size);
            grayImgeOnlyFace.Bitmap = newMat.Bitmap;

            fourthShowBox.Image = grayImgeOnlyFace.Bitmap;

            fourthSteepBtn_Click(this, new EventArgs());
        }

        private void fourthSteepBtn_Click(object sender, EventArgs e)
        {
            int cropHeight = (int)Math.Round(grayImgeOnlyFace.Height * 0.5, 0);

            eyesAreaRec = new Rectangle(0, 0, grayImgeOnlyFace.Width, cropHeight);

            grayImgeOnlyFace.Draw(eyesAreaRec, new Gray(255), 2);

            fivesShowBox.Image = grayImgeOnlyFace.Bitmap;


            //Mat newMat = crop_gray_frame(grayImgeOnlyFace.Mat, new Rectangle(0, 0, grayImgeOnlyFace.Width, cropHeight));

            fivesSteepBtn_Click(this, new EventArgs());
        }

        private void fivesSteepBtn_Click(object sender, EventArgs e)
        {

            Mat mat = crop_gray_frame(grayImgeOnlyFace.Mat, eyesAreaRec);

            grayImgeAreaForSearchEyes = new Image<Gray, byte>(mat.Size);
            grayImgeAreaForSearchEyes.Bitmap = mat.Bitmap;

            Size minimal;
            

             eyes = classifierEye.DetectMultiScale(grayImgeAreaForSearchEyes, 1.1, 4);//сдесь можно задать минимальный и максимальный размер окна

            if (eyes.Length > 2)
            {
                MessageBox.Show("Найдено больше двух глах, и это проблема(", "Повыдомлення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            else if(eyes.Length == 0)
            {
                MessageBox.Show("Все намного хуже, у вас нету глаз(", "Повыдомлення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            


            foreach (var eye in eyes)
            {
                var ec = eye;
                grayImgeAreaForSearchEyes.Draw(ec, new Gray(255), 2);

                sixthShowBox.Image = grayImgeAreaForSearchEyes.Bitmap;
            }

            sixsSteepBtn_Click(this, new EventArgs());
        }


       
        private void sixsSteepBtn_Click(object sender, EventArgs e)
        {
            Mat mat = crop_gray_frame(grayImgeAreaForSearchEyes.Mat, eyes[0]);
            grayImageLeftEye = new Image<Gray, byte>(mat.Size);
            grayImageLeftEye.Bitmap = mat.Bitmap;
            eightShowBox.Image = grayImageLeftEye.Bitmap;

            mat = crop_gray_frame(grayImgeAreaForSearchEyes.Mat, eyes[1]);
            grayImageRightEye = new Image<Gray, byte>(mat.Size);
            grayImageRightEye.Bitmap = mat.Bitmap;
            seventsShowBox.Image = grayImageRightEye.Bitmap;
        }

        private void sevensSteepBtn_Click(object sender, EventArgs e)
        {
            grayImageLeftEyeBinar = new Image<Gray, byte>(grayImageLeftEye.Size);

            //int label = (int)grayImageLeftEye.Int;

            grayImageLeftEyeBinar = grayImageLeftEye.Convert<Gray, byte>().ThresholdAdaptive(new Gray(255), Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC, Emgu.CV.CvEnum.ThresholdType.BinaryInv, 5, new Gray(0));


            //CvInvoke.AdaptiveThreshold(grayImageLeftEye, grayImageLeftEyeBinar,255,Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC, Emgu.CV.CvEnum.ThresholdType.Binary, 5, 0.0);
            //grayImageLeftEyeBinar = grayImageLeftEye.Convert<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255)).Dilate(2).Erode(1);
           
            //grayImageLeftEyeBinar.Dilate(10);
            nienShowBox.Image = grayImageLeftEyeBinar.Dilate(1).Erode(1).Bitmap;
            
            grayImageRightEyeBinar = new Image<Gray, byte>(grayImageLeftEye.Size);
            grayImageRightEyeBinar = grayImageRightEye.Convert<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255)).Dilate(2).Erode(1);
            tensShowBox.Image = grayImageRightEyeBinar.Dilate(12).Bitmap;

            
        }


        public Image<Bgr, Byte> GetFacePoints()
        {
            CascadeClassifier faceDetector = new CascadeClassifier(@"..\..\Resource\EMGUCV\haarcascade_frontalface_default.xml");
            FacemarkLBFParams fParams = new FacemarkLBFParams();
            fParams.ModelFile = @"..\..\Resource\EMGUCV\lbfmodel.yaml";
            fParams.NLandmarks = 68; // number of landmark points
            fParams.InitShapeN = 10; // number of multiplier for make data augmentation
            fParams.StagesN = 5; // amount of refinement stages
            fParams.TreeN = 6; // number of tree in the model for each landmark point
            fParams.TreeDepth = 5; //he depth of decision tree
            FacemarkLBF facemark = new FacemarkLBF(fParams);
            //facemark.SetFaceDetector(MyDetector);

            Image<Bgr, Byte> image = new Image<Bgr, byte>(@"C:\Users\matias\Downloads\personas-buena-vibra-caracteristicas-1200x600.jpg");
            Image<Gray, byte> grayImage = image.Convert<Gray, byte>();
            grayImage._EqualizeHist();

            VectorOfRect faces = new VectorOfRect(faceDetector.DetectMultiScale(grayImage));
            VectorOfVectorOfPointF landmarks = new VectorOfVectorOfPointF();
            facemark.LoadModel(fParams.ModelFile);

            bool success = facemark.Fit(grayImage, faces, landmarks);
            if (success)
            {
                Rectangle[] facesRect = faces.ToArray();
                for (int i = 0; i < facesRect.Length; i++)
                {
                    image.Draw(facesRect[i], new Bgr(Color.Blue), 2);
                    FaceInvoke.DrawFacemarks(image, landmarks[i], new Bgr(Color.Blue).MCvScalar);
                }
                return image;
            }
            return null;
        }


        Mat crop_gray_frame(Mat input, Rectangle crop_region)
        {
            /* 
            * TODO(Ahmed): Figure out why I had to copy this into this class. 
            * */
            Image<Bgr, Byte> buffer_im = input.ToImage<Bgr, Byte>();
            buffer_im.ROI = crop_region;

            Image<Bgr, Byte> cropped_im = buffer_im.Copy();


            return cropped_im.Mat;

        }
    }
}
