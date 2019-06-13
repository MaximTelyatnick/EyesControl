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
using DevExpress.XtraBars.Utils;
using System.Runtime.InteropServices;
using DevExpress.XtraBars;
using Emgu.CV;
using System.Drawing.Text;
using Emgu.CV.Face;
using System.IO;
using Emgu.CV.CvEnum;
using Tulpep.NotificationWindow;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Threading;
using ViolaJonesTest.Infrastructure;
using System.Diagnostics;
using DevExpress.XtraCharts;

namespace ViolaJonesTest
{
    public partial class MainTabUserFm : DevExpress.XtraEditors.XtraForm
    {

        private Thread chartThread;
        private Thread realTimeAnalizatorThread;
        private Thread oneMinuteAnalizatorThread;
        private double[] brightArray = new double[60];
        private double[] distanceArray = new double[60];
        private double[] eyesBlinkArray = new double[60];
        private double[] buffer = new double[60];
        private double[] bufferten = new double[10];

        private double chit = 1.2;
        // для кастомизации
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public Point mouseOffset;

        public VideoCapture videoCapture = null;

        public bool isMouseDown = false;
        public int imageWidth = 640;
        public int imageHeight = 360;
        public int flag = 0;
        public int blink = 0;
        public short block = 0;

        //public Image<Bgr, byte> inputImage;


        // поиск точек лица
        FacemarkLBFParams fParams = new FacemarkLBFParams();
        FacemarkLBF facemark;


        //пути для поиска глаз и лица класификатором Хаара
        static string faceFrontalPath = Path.GetFullPath(@"haarcascade_frontalface_default.xml");
        static string faceProfilPath = Path.GetFullPath(@"haarcascade_profileface.xml");
        static string eyePath = Path.GetFullPath(@"haarcascade_eye.xml");

        CascadeClassifier faceFrontalDetector = new CascadeClassifier(faceFrontalPath);

        //PopupNotifier notification = new PopupNotifier();

        //Параметри из настроек
        public double lenghtFromLinearToCam = 14;// расстояние до камеры
        public double lenghtLinear = 10;// длинна линейки
        public int avarageFaceSize = 15; // средний размер лица (см)
        public int normalLenghtFromUserToCam = 80; // нормальное расстояние до монитора (см)
        public double matrixCam = 1.4;
        private double? heightOpenRightEye = null; //высота открытого правого глаза (см)
        private double? heightOpenLeftEye = null;  //высота открытого левого глаза (см)
        private double? heightCloseRightEye = null; //высота закрытого правого глаза (см)
        private double? heightCloseLeftEye = null; //высота закрытого правого глаза (см)
        private BlockForm blockForm;

        private double? curentLeftEye = null;
        private double? curentRightEye = null;


        int currentBright = 0;
        double currentDistance = 0;

        int clipCounter = 0;

        int brightflag = 0;
        int distanceLowFlag = 0;
        int distanceHightFlag = 0;
        int seconds = 0;

        private double? avarageHeightRightEye = null; //высота закрытого правого глаза (см)
        private double? avarageHeightLeftEye = null; //высота закрытого правого глаза (см)

        private List<Int16> imageBrightList = null;

        public MainTabUserFm(bool settingSet)
        {
            InitializeComponent();
            settingsBar.ForceInitialize();
            CustomBarControl barControl = bar1.GetBarControl();

            chartThread = new Thread(new ThreadStart(this.GetPerformanceCounters));
            chartThread.IsBackground = true;
            chartThread.Start();

            realTimeAnalizatorThread = new Thread(new ThreadStart(this.RealTimeAnalizator));
            realTimeAnalizatorThread.IsBackground = true;
            realTimeAnalizatorThread.Start();

            oneMinuteAnalizatorThread = new Thread(new ThreadStart(this.OneMinuteAnalizator));
            oneMinuteAnalizatorThread.IsBackground = true;
            oneMinuteAnalizatorThread.Start();



            using (CustomWaitFm frm = new CustomWaitFm(LoadSetting))
            {
                frm.ShowDialog(this);
            }

            if (settingSet)
            {

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Програмны налаштування відсутні. Розпочати налаштування?", "Повідомлення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    using (var form = new SettingsUserFm())
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            MessageBox.Show("Збережено параметри користувача", "Повідомлення", MessageBoxButtons.YesNo);
                        }
                        else
                        {
                            MessageBox.Show("Параметри користувача не збережено", "Повідомлення", MessageBoxButtons.YesNo);
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
        }

        private void RealTimeAnalizator()
        {
            while (true)
            {
                if (currentDistance != 0)
                {
                    String notification = "Не коректні показники:\n";
                    String correct = "";
                    if (currentBright < 50)
                        ++brightflag;
                    if (currentDistance < 60)
                        ++distanceLowFlag;
                    if (currentDistance > 100)
                        ++distanceHightFlag;


                    if (brightflag == 2)
                        correct += "Занизький рівень освітленості!\n";
                    if (distanceLowFlag == 2)
                        correct += "Замала відстань між обличчям та монітором!\n";
                    if (distanceHightFlag == 2)
                        correct += "Занадто велика відстань між обличчям та монітором!\n";

                    if (correct == "")
                    {

                    }
                    else
                    {
                        notification += correct;
                        NotificationWarning("Повідомлення", notification);
                        brightflag = 0;
                        distanceLowFlag = 0;
                        distanceHightFlag = 0;

                    }

                    if(block >= 3 && clipCounter>1)
                    {  
                        Invoke(new Action(() =>
                        {
                            blockForm.Close(); ;

                        }));
                        block = 0;
                    }

                    ++seconds;

                    Thread.Sleep(1000);
                }
            }

        }

        private void OneMinuteAnalizator()
        {
            while (true)
            {
                if (seconds > 10 && block < 3)
                {
                    String notification = "Не коректні показники:\n";
                    String correct = "";


                    buffer = eyesBlinkArray.ToArray();

                    bufferten = buffer.Reverse().Take(10).ToArray();
                    if (bufferten.Sum() < 6)
                    {
                        correct = "Занадто низький показник частоти кліпання очей!\n";
                        notification += correct;
                        NotificationWarning("Повідомлення", notification);
                        ++block;

                        if (block == 2)
                        {
                            block = 3;
                            clipCounter = 0;

                            Invoke(new Action(() =>
                            {
                                blockForm = new BlockForm();
                                blockForm.Show();

                            }));
                        }
                    }
                    else
                    {
                        block = 0;
                    }


                    seconds = 0;
                    Thread.Sleep(10000);
                }
            }

        }

        private void GetPerformanceCounters()
        {

            while (true)
            {

                brightArray[brightArray.Length - 1] = (int)currentBright+0.5;

                distanceArray[distanceArray.Length - 1] = (int)currentDistance + 0.5;

                if (blink == 1)
                    blink = 1;
                else if (blink == 0)
                    blink = 0;
                else if (blink > 1)
                    blink = (int)((blink / 2) + 0.5);

                eyesBlinkArray[eyesBlinkArray.Length - 1] = blink;

                blink = 0;

                Array.Copy(brightArray, 1, brightArray, 0, brightArray.Length - 1);

                Array.Copy(distanceArray, 1, distanceArray, 0, distanceArray.Length - 1);

                Array.Copy(eyesBlinkArray, 1, eyesBlinkArray, 0, eyesBlinkArray.Length - 1);

                if (brightChartControl.IsHandleCreated && distanceChartControl.IsHandleCreated && blinkEyesChartControl.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateChart(); });
                }
                else
                {
                    //......
                }

                Thread.Sleep(1000);
            }
        }

        private void UpdateChart()
        {


            brightChartControl.Series["Освітленість(%)"].Points.Clear();
            distanceChartControl.Series["Відстань до обличчя (см)"].Points.Clear();
            blinkEyesChartControl.Series["Кількість кліпань очима"].Points.Clear();

            for (int i = 0; i < brightArray.Length - 1; ++i)
            {
                brightChartControl.Series["Освітленість(%)"].Points.AddY(brightArray[i]);
                distanceChartControl.Series["Відстань до обличчя (см)"].Points.AddY(distanceArray[i]);
                blinkEyesChartControl.Series["Кількість кліпань очима"].Points.AddY(eyesBlinkArray[i]);
            }
        }
        public void LoadSetting()
        {
            FacemarkSettings();

            heightCloseLeftEye = ConfigClass.Instance.GlobalLocalSettings.HeightCloseLeftEye;
            heightCloseRightEye = ConfigClass.Instance.GlobalLocalSettings.HeightCloseRightEye;

            heightOpenRightEye = ConfigClass.Instance.GlobalLocalSettings.HeightOpenRightEye;
            heightOpenLeftEye = ConfigClass.Instance.GlobalLocalSettings.HeightOpenLeftEye;

            avarageHeightLeftEye = heightOpenLeftEye - heightCloseLeftEye;
            avarageHeightRightEye = heightOpenRightEye - heightCloseRightEye;

            brightChartControl.ChartAreas[0].AxisY.Maximum = 100;
            brightChartControl.ChartAreas[0].AxisY.Minimum = 0;

            distanceChartControl.ChartAreas[0].AxisY.Maximum = 160;
            distanceChartControl.ChartAreas[0].AxisY.Minimum = 0;

            blinkEyesChartControl.ChartAreas[0].AxisY.Maximum = 10;
            blinkEyesChartControl.ChartAreas[0].AxisY.Minimum = 0;

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
                MessageBox.Show("При завантаженнs налаштувань виникла помилка" + ex.Message);
                return false;
            }

        }

        public void CaptureSetting()
        {
            videoCapture = new VideoCapture(0);
            videoCapture.ImageGrabbed += imageGraberCapture;
            videoCapture.SetCaptureProperty(CapProp.FrameWidth, imageWidth);
            videoCapture.SetCaptureProperty(CapProp.FrameHeight, imageHeight);

        }


        private void imageGraberCapture(object sender, EventArgs e)
        {
            try
            {

                #region Получение кадра и массива лиц

                Mat m = new Mat();

                videoCapture.Retrieve(m);
                Image<Bgr, Byte> inputImage = m.ToImage<Bgr, Byte>();
                var imgGray = inputImage.Convert<Gray, Byte>().Clone(); //Конвертируем в оттенки серого
                imgGray._EqualizeHist();//выравниваем яркость
                imgGray._SmoothGaussian(1);//убираем шумы

                VectorOfRect faces = new VectorOfRect(faceFrontalDetector.DetectMultiScale(imgGray, 1.05, 5, new Size(120, 120)));//находим все лица

                #endregion



                if (faces.Size > 0)
                {
                    Rectangle[] facesRect = faces.ToArray();// приводим вектор к фигуре

                    facesRect.OrderBy(ob => ob.Height); //сортировка по высоте

                    VectorOfVectorOfPointF landmarks = new VectorOfVectorOfPointF();

                    bool success = facemark.Fit(imgGray, faces, landmarks); //находим точки лица


                    #region Анализ расстояния до пользователя

                    double k = ((double)faces[0].Height) / imgGray.Height;

                    currentDistance = (2.5 * avarageFaceSize) / k;

                    #endregion

                    #region Анализ яркости

                    imageBrightList = FrameBright(imgGray.Clone(), facesRect[0]);

                    if((imageBrightList[1] - imageBrightList[0]) > 55)
                        currentBright = 10;
                    else if ((imageBrightList[1] - imageBrightList[0]) > 45 && (imageBrightList[1] - imageBrightList[0]) < 55)
                        currentBright = 20;
                    else if ((imageBrightList[1] - imageBrightList[0]) > 35 && (imageBrightList[1] - imageBrightList[0]) < 45)
                        currentBright = 35;
                    else if ((imageBrightList[1] - imageBrightList[0]) > 25 && (imageBrightList[1] - imageBrightList[0]) < 35)
                        currentBright = 50;
                    else if ((imageBrightList[1] - imageBrightList[0]) > 15 && (imageBrightList[1] - imageBrightList[0]) < 25)
                        currentBright = 70;
                    else if((imageBrightList[1] - imageBrightList[0]) > 10 && (imageBrightList[1] - imageBrightList[0]) < 15)
                        currentBright = 85;
                    else if ((imageBrightList[1] - imageBrightList[0]) > 5 && (imageBrightList[1] - imageBrightList[0]) < 10)
                        currentBright = 95;

                    //currentBright = (int)(((100.0/255)*imageBrightList[0]) + 0.5);

                    #endregion


                    #region Глазной анализатор

                    PointF[] h = landmarks[0].ToArray();//преобразовываем в массив точек

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

                   

                    if (rightEyeMaximalPoint.Y > 0 && rightEyeMinimalPoint.Y > 0 && leftEyeMaximalPoint.Y > 0 && leftEyeMinimalPoint.Y > 0)
                    {

                        double bufer;


                        inputImage.DrawPolyline(leftEye, true, new Bgr(Color.Red), 2);
                        inputImage.DrawPolyline(rightEye, true, new Bgr(Color.Red), 2);

                        bufer = rightEyeMinimalPoint.Y - rightEyeMaximalPoint.Y;

                        double kk = ((double)bufer) / imgGray.Height;

                        curentRightEye = (currentDistance * kk)/2.5; //в сантиметрах



                        if (curentRightEye > heightOpenRightEye)
                        {
                            curentRightEye = heightOpenRightEye;
                        }
                        else if (curentRightEye < heightCloseRightEye*chit)
                        {
                            curentRightEye = heightCloseRightEye;
                            blink++;
                            clipCounter++;
                        }

                         



                        curentLeftEye = curentRightEye;
                    }
                    else
                    {
                        curentLeftEye = heightCloseRightEye;
                        curentRightEye = heightCloseRightEye;
                    }


                    double? buffer = ((100/ (heightOpenLeftEye - heightCloseLeftEye)) * (curentRightEye - heightCloseLeftEye));

                    #endregion

                    Invoke(new Action(() =>
                    {
                        if (faces.Size > 0)
                        {
                            //brightGaugComponent.Value = (float)60;
                            distanceGaugComponent.Value = (float)currentDistance;

                            //график света
                            linearScaleMarkerComponent3.Value = (float)currentBright;
                            linearScaleRangeBarComponent2.Value = (float)currentBright;

                            //lengthEdit.Text = test.ToString();
                            //faceSizeEdit.Text = curentRightEye.ToString();

                            //график глаза
                            linearScaleRangeBarComponent3.Value = (float)buffer;
                            linearScaleMarkerComponent4.Value = (float)buffer;
                            //linearScaleRangeBarComponent1.Value = 60;


                        }

                    }));

                    inputImage.Draw(faces[0], new Bgr(Color.Green), 1);

                    generalTabBox.Image = inputImage;

                }
                else if (faces.Size == 0)
                {
                    //faces = new VectorOfRect(faceProfilDetector.DetectMultiScale(imgGray));
                    generalTabBox.Image = inputImage;
                }

                Thread.Sleep(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void MainTabUserFm_Load(object sender, EventArgs e)
        {

            CustomBarControl barControl = ((IDockableObject)bar1).BarControl as CustomBarControl;
            barControl.MouseDown += new MouseEventHandler(barControl_MouseDown);

            barAndDockingController.AppearancesBar.Dock.BackColor = Color.FromArgb(86, 198, 184);
            this.BackColor = Color.FromArgb(86, 198, 184);
            
        }


        public int FrameBright(Image<Gray, byte> img)
        {

            DenseHistogram histImage = new DenseHistogram(256, new RangeF(0.0f, 255.0f));

            histImage.Calculate<Byte>(new Image<Gray, byte>[] { img }, true, null);

            float[] GrayHistImage = histImage.GetBinValues();
            
            double bufferImage = 0.0;
            double bufferImageFace = 0.0;

            for (int i = 1; i < 256; i++)
                    bufferImage += (GrayHistImage[i]) * i;

            double avarageImage = bufferImage / ((img.Width * img.Height));


            return (int)(avarageImage + 0.5);

        }



        public List<Int16> FrameBright(Image<Gray, byte> img, Rectangle rec)
        {
            List<Int16> returnParam = new List<Int16>();

            DenseHistogram histImage = new DenseHistogram(256, new RangeF(0.0f, 255.0f));
            DenseHistogram histFace = new DenseHistogram(256, new RangeF(0.0f, 255.0f));

            Mat newMat = cropFrame(img.Mat.Clone(), rec);

            int mask = newMat.Width * newMat.Height;

            Image<Gray, byte> grayFace = new Image<Gray, byte>(newMat.Size);

            grayFace.Bitmap = newMat.Bitmap;

            img.Draw(rec, new Gray(0), -1);

            histFace.Calculate<Byte>(new Image<Gray, byte>[] { grayFace }, true, null);
            histImage.Calculate<Byte>(new Image<Gray, byte>[] { img }, true, null);

            float[] GrayHistImage = histImage.GetBinValues();
            float[] GrayHistFace = histFace.GetBinValues();
            double avarageImage, avarageImageFace;
            double bufferImage = 0.0;
            double bufferImageFace = 0.0;


            for (int i = 0; i < GrayHistImage.Length; i++)
            {
                if (i == 0)
                    bufferImage += (GrayHistImage[i] - mask) * i;
                else
                    bufferImage += (GrayHistImage[i]) * i;
            }

            //avarageImage = bufferImage / ((img.Width * img.Height) - (grayFace.Height * grayFace.Width));

            avarageImage = bufferImage / ((img.Width * img.Height));

            for (int i = 0; i < GrayHistFace.Length; i++)
            {
                bufferImageFace += GrayHistFace[i] * i;
            }

            avarageImageFace = bufferImageFace / (grayFace.Height * grayFace.Width);



            
            returnParam.Add(Convert.ToInt16(avarageImage));
            returnParam.Add(Convert.ToInt16(avarageImageFace));

            return returnParam;

        }

        public Mat cropFrame(Mat input, Rectangle cropRegion)
        {
            /* 
            * TODO(Ahmed): Figure out why I had to copy this into this class. 
            * */
            Image<Bgr, Byte> buffer_im = input.ToImage<Bgr, Byte>();
            buffer_im.ROI = cropRegion;

            Image<Bgr, Byte> cropped_im = buffer_im.Copy();


            return cropped_im.Mat;

        }

        public string AnalizeBright(Utils.Bright image, Utils.Bright imageFace)
        {
            if (image == Utils.Bright.Normal)
                return "Нормальне освітлення приміщення";
            else if (image == Utils.Bright.Hight)
                return "Завишені показники освітленості приміщення ";
            else if (image == Utils.Bright.VeryHight)
                return "Критично високі показники освітленості приміщення";
            else if (image == Utils.Bright.Low)
                return "Низькі показники освітленості приміщення";
            else
                return "Критично Низькі показники освітленості приміщення";
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

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        private void calibrationItemBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (SettingsUserFm settingsUserFm = new SettingsUserFm())
            {
                settingsUserFm.ShowDialog();
            }
        }

        private void settingsProgramItemBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (SettingsManuallFm settingsManuallFm = new SettingsManuallFm())
            {
                settingsManuallFm.ShowDialog();
            }
        }

        

        


        #region Notification event's

        public void NotificationSucess(String titleText, String contentText)
        {

            this.Invoke((MethodInvoker)delegate
            {
                PopupNotifier notification = new PopupNotifier();
                notification.TitleText = titleText;
                notification.ContentText = contentText;
                notification.HeaderColor = Color.FromArgb(37, 125, 89);
                notification.BorderColor = Color.Transparent;
                notification.ContentColor = Color.White;
                notification.BodyColor = Color.FromArgb(37, 125, 89);
                notification.ButtonBorderColor = Color.Transparent;
                notification.TitleColor = Color.White;
                notification.TitlePadding = new Padding(5);
                notification.TitleFont = new Font("Arial", 14, FontStyle.Bold);
                notification.ContentFont = new Font("Arial", 12, FontStyle.Bold);
                notification.ContentPadding = new Padding(5);
                notification.ShowOptionsButton = false;
                notification.ShowGrip = false;
                notification.GradientPower = 0;
                notification.ContentHoverColor = Color.White;
                notification.Image = pngImageCollection.Images[2];
                notification.ImageSize = new Size(40, 45);
                notification.ImagePadding = new Padding(17);
                notification.Size = new Size(400, 150);
                notification.Popup();
            });

        }

        public void NotificationError(String titleText, String contentText)
        {
            this.Invoke((MethodInvoker)delegate
            {
                PopupNotifier notification = new PopupNotifier();
                notification.TitleText = titleText;
                notification.ContentText = contentText;
                notification.HeaderColor = Color.FromArgb(236, 42, 61);
                notification.BorderColor = Color.Transparent;
                notification.ContentColor = Color.White;
                notification.BodyColor = Color.FromArgb(236, 42, 61);
                notification.ButtonBorderColor = Color.Transparent;
                notification.TitleColor = Color.White;
                notification.TitlePadding = new Padding(5);
                notification.TitleFont = new Font("Arial", 14, FontStyle.Bold);
                notification.ContentFont = new Font("Arial", 12, FontStyle.Bold);
                notification.ContentPadding = new Padding(5);
                notification.ShowOptionsButton = false;
                notification.ShowGrip = false;
                notification.GradientPower = 0;
                notification.ContentHoverColor = Color.White;
                notification.Image = pngImageCollection.Images[0];
                notification.ImageSize = new Size(40, 45);
                notification.ImagePadding = new Padding(17);
                notification.Size = new Size(400, 150);
                notification.Popup();
            });
        }

        public void NotificationInfo(String titleText, String contentText)
        {
            this.Invoke((MethodInvoker)delegate
            {
                PopupNotifier notification = new PopupNotifier();
                notification.TitleText = titleText;
                notification.ContentText = contentText;
                notification.HeaderColor = Color.FromArgb(0, 121, 255);
                notification.BorderColor = Color.Transparent;
                notification.ContentColor = Color.White;
                notification.BodyColor = Color.FromArgb(0, 121, 255);
                notification.ButtonBorderColor = Color.Transparent;
                notification.TitleColor = Color.White;
                notification.TitlePadding = new Padding(5);
                notification.TitleFont = new Font("Arial", 14, FontStyle.Bold);
                notification.ContentFont = new Font("Arial", 12, FontStyle.Bold);
                notification.ContentPadding = new Padding(5);
                notification.ShowOptionsButton = false;
                notification.ShowGrip = false;
                notification.GradientPower = 0;
                notification.ContentHoverColor = Color.White;
                notification.Image = pngImageCollection.Images[1];
                notification.ImageSize = new Size(40, 45);
                notification.ImagePadding = new Padding(17);
                notification.Size = new Size(400, 150);
                notification.Popup();
            });
        }

        public void NotificationWarning(String titleText, String contentText)
        {
            Task.Run(() => {
                this.Invoke((MethodInvoker)delegate
                {
                    PopupNotifier notification = new PopupNotifier();
                    notification.TitleText = titleText;
                    notification.ContentText = contentText;
                    notification.HeaderColor = Color.FromArgb(255, 134, 0);
                    notification.BorderColor = Color.Transparent;
                    notification.ContentColor = Color.White;
                    notification.BodyColor = Color.FromArgb(255, 134, 0);
                    notification.ButtonBorderColor = Color.Transparent;
                    notification.TitleColor = Color.White;
                    notification.TitlePadding = new Padding(5);
                    notification.TitleFont = new Font("Arial", 14, FontStyle.Bold);
                    notification.ContentFont = new Font("Arial", 12, FontStyle.Bold);
                    notification.ContentPadding = new Padding(5);
                    notification.ShowOptionsButton = false;
                    notification.ShowGrip = false;
                    notification.GradientPower = 0;
                    notification.ContentHoverColor = Color.White;
                    notification.Image = pngImageCollection.Images[3];
                    notification.ImageSize = new Size(41, 45);
                    notification.ImagePadding = new Padding(17);
                    notification.Size = new Size(400, 150);
                    notification.Popup();
                });
            });
        }


        #endregion

        private void graphicsItemBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            CaptureSetting();
            videoCapture.Start();
        }

        private void gaugeControl2_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (MaderImageFm maderImageFm = new MaderImageFm())
            {
                maderImageFm.ShowDialog();
            }
        }

        private void aboutDeveloperItemBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (AboutDevelopperFm aboutDevelopperFm = new AboutDevelopperFm())
            {
                aboutDevelopperFm.ShowDialog();
            }
        }
    }
}