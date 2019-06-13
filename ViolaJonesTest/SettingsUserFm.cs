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
using DevExpress.XtraBars.Utils;
using DevExpress.XtraBars;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using ViolaJonesTest.Camera;
using Emgu.CV;
using Emgu.CV.Structure;
using DirectShowLib;
using System.Threading;
using Emgu.CV.CvEnum;
using DevExpress.XtraEditors.DXErrorProvider;
using Emgu.CV.Util;
using Emgu.CV.Face;
using System.Diagnostics;
using MS.WindowsAPICodePack.Internal;
using System.Runtime.InteropServices.ComTypes;
using DevExpress.Internal.WinApi;
using Tulpep.NotificationWindow;
using ViolaJonesTest.Infrastructure;

namespace ViolaJonesTest
{
    public partial class SettingsUserFm : DevExpress.XtraEditors.XtraForm
    {
        // для кастомизации
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private Point mouseOffset;

        // шрифты
        private Font labelTaskFont;
        private Font labelDescriptionFont;

        // видеопоток для каждого таба
        private VideoCapture videoCaptureFirst;
        private VideoCapture videoCaptureSecond;
        private VideoCapture videoCaptureThird;
        private VideoCapture videoCaptureFourth;
        private VideoCapture videoCaptureFives;


        private PrivateFontCollection privateFontCollection;
        private bool isMouseDown = false;
        private int imageWidth = 640;
        private int imageHeight = 360;
        private int flag = 0;


        // поиск точек лица
        FacemarkLBFParams fParams = new FacemarkLBFParams();
        FacemarkLBF facemark;

        
        //пути для поиска глаз и лица класификатором Хаара
        static string faceFrontalPath = Path.GetFullPath(@"../../data/haarcascade_frontalface_default.xml");
        static string faceProfilPath = Path.GetFullPath(@"../../data/haarcascade_profileface.xml");
        static string eyePath = Path.GetFullPath(@"../../data/haarcascade_eye.xml");

        CascadeClassifier faceFrontalDetector = new CascadeClassifier(faceFrontalPath);

        //PopupNotifier notification = new PopupNotifier();

        //Параметри из настроек
        public double lenghtFromLinearToCam = 14;// расстояние до камеры
        public double lenghtLinear = 10;// длинна линейки
        public int avarageFaceSize = 15; // средний размер лица (см)
        public int normalLenghtFromUserToCam = 80; // нормальное расстояние до монитора (см)
        public double matrixCam = 2.5; 
        private double? heightOpenRightEye = null; //высота открытого правого глаза (см)
        private double? heightOpenLeftEye = null;  //высота открытого левого глаза (см)
        private double? heightCloseRightEye = null; //высота закрытого правого глаза (см)
        private double? heightCloseLeftEye = null; //высота закрытого правого глаза (см)

        private List<Utils.Bright> imageBrightList = null;
        public Utils.Bright abc;

        Devices[] WebCams;

        private Image<Bgr, byte> firstTabImage;
        private Image<Bgr, byte> secondTabImage;
        private Image<Bgr, byte> thirdTabImage;
        private Image<Bgr, byte> fourthTabImage;
        private Image<Bgr, byte> fivesTabImage;

        private Utils.CurrentPage? currentPage = null;



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

        

        public SettingsUserFm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler((sender2, e2) => KeyUpWithParameter(sender2, e2, currentPage));

            FacemarkSettings();
            settingsBar.ForceInitialize();
            CustomBarControl barControl = bar2.GetBarControl();

            



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

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

           

            //switch (currentPage)
            //{
            //    case Infrastructure.Utils.CurrentPage.FirstPage:
            //        videoCaptureFirst.Stop();
            //        videoCaptureFirst.ImageGrabbed -= captureImageGrabberEvent;
            //        videoCaptureFirst.Dispose();
            //        break;

            //    case Infrastructure.Utils.CurrentPage.SecondPage:
            //        videoCaptureSecond.Stop();
            //        videoCaptureSecond.ImageGrabbed -= captureImageGrabberSecondTabEvent;
            //        videoCaptureSecond.Dispose();
            //        break;

            //    case Infrastructure.Utils.CurrentPage.ThirdPage:
            //        videoCaptureThird.Stop();
            //        videoCaptureThird.ImageGrabbed -= captureImageGrabberThirdTabEvent;
            //        videoCaptureThird.Dispose();
            //        break;

            //    case Infrastructure.Utils.CurrentPage.FourthPage:
            //        videoCaptureFourth.Stop();
            //        videoCaptureFourth.ImageGrabbed -= captureImageGrabberFourthTabEvent;
            //        videoCaptureFourth.Dispose();
            //        break;

            //    case Infrastructure.Utils.CurrentPage.FivesPage:
            //        videoCaptureFives.Stop();
            //        videoCaptureFives.ImageGrabbed -= captureImageGrabberFivesTabEvent;
            //        videoCaptureFives.Dispose();
            //        break;
            //    default:
            //        break;
            //}
            this.Dispose();
            this.Close();
        }

        #endregion

        public void LoadCemaraSetting()
        {
            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            WebCams = new Devices[_SystemCamereas.Length];
            for (int i = 0; i < _SystemCamereas.Length; i++)
            {
                WebCams[i] = new Devices(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID); //fill web cam array
                deviceEdit.Properties.Items.Add(WebCams[i].ToString());
                //deviceEdit.
            }
            if (deviceEdit.Properties.Items.Count > 0)
            {
                deviceEdit.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Не знайдено пристроїв захоплення зображення!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                deviceEdit.SelectedIndex = -1;
                lenghtEdit.Enabled = false;
                
            }
             
        }

        public void LoadFont()
        {
            string resource = Path.GetFullPath(@"../../data/12508.ttf");
            privateFontCollection = new PrivateFontCollection();
            privateFontCollection.AddFontFile(resource);
            labelTaskFont = new Font(privateFontCollection.Families[0], 18, FontStyle.Regular);
            labelDescriptionFont = new Font(privateFontCollection.Families[0], 13, FontStyle.Regular);
        }

        private void SettingsUserFm_Load(object sender, EventArgs e)
        {
          
            CustomBarControl barControl = ((IDockableObject)bar2).BarControl as CustomBarControl;
            barControl.MouseDown += new MouseEventHandler(barControl_MouseDown);

            LoadCemaraSetting();

            LoadFont();

            barAndDockingController.AppearancesBar.Dock.BackColor = Color.FromArgb(235, 236, 239);
            this.BackColor = Color.FromArgb(86, 198, 184);
            

            firstSteppTabPage.Appearance.Header.BackColor = Color.IndianRed;
            secondSteppTabPage.Appearance.Header.BackColor = Color.IndianRed;
            thirdSteppTabPage.Appearance.Header.BackColor = Color.IndianRed;
            fourthSteppTabPage.Appearance.Header.BackColor = Color.IndianRed;
            fivesSteppTabPage.Appearance.Header.BackColor = Color.IndianRed;

            firstSteppTabPage.ImageOptions.Image = svgImageCollection.GetImage(0);
            secondSteppTabPage.ImageOptions.Image = svgImageCollection.GetImage(0);
            thirdSteppTabPage.ImageOptions.Image = svgImageCollection.GetImage(0);
            fourthSteppTabPage.ImageOptions.Image = svgImageCollection.GetImage(0);
            fivesSteppTabPage.ImageOptions.Image = svgImageCollection.GetImage(0);

            secondSteppTabPage.PageVisible = false;
            thirdSteppTabPage.PageVisible = false;
            fourthSteppTabPage.PageVisible = false;
            fivesSteppTabPage.PageVisible = false;

            taskFirstSteepLbl.Font = labelTaskFont;
            deviceLbl.Font = labelDescriptionFont;
            lenghtLbl.Font = labelDescriptionFont;
            taskSecondSteepLbl.Font = labelTaskFont;
            taskThirdSteepLbl.Font = labelTaskFont;
            taskFourthSteepLbl.Font = labelTaskFont;
            taskFivesSteepLbl.Font = labelTaskFont;

            //this.settingFirstTabValidationProvider.Validate();

            //settingFirstTabValidationProvider.SetValidationRule(deviceEdit, new CustomValidationRule { ErrorText = "Не знайдено пристроїв захоплення зображення", ErrorType = ErrorType.Critical });

            //firstSteppTabPage.ImageOptions.Image = svgImageCollection.GetImage(1);
            //firstSteppTabPage.ImageOptions.Image.;
        }

        public void CurrentTabPage(Infrastructure.Utils.CurrentPage? currentPage)
        {
            this.currentPage = currentPage;

            switch (currentPage)
            {
                case Infrastructure.Utils.CurrentPage.FirstPage:

                    videoCaptureFirst = new VideoCapture(deviceEdit.SelectedIndex);
                    //videocapture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, CurrentFrameNo);
                    videoCaptureFirst.ImageGrabbed += captureImageGrabberEvent;
                    videoCaptureFirst.SetCaptureProperty(CapProp.FrameWidth, imageWidth);
                    videoCaptureFirst.SetCaptureProperty(CapProp.FrameHeight, imageHeight);
                    videoCaptureFirst.Start();

                    break;
                case Infrastructure.Utils.CurrentPage.SecondPage:

                    videoCaptureSecond = new VideoCapture(deviceEdit.SelectedIndex);
                    //videocapture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, CurrentFrameNo);
                    videoCaptureSecond.ImageGrabbed += captureImageGrabberSecondTabEvent;
                    videoCaptureSecond.SetCaptureProperty(CapProp.FrameWidth, imageWidth);
                    videoCaptureSecond.SetCaptureProperty(CapProp.FrameHeight, imageHeight);
                    videoCaptureSecond.Start();


                    break;
                case Infrastructure.Utils.CurrentPage.ThirdPage:

                    videoCaptureThird = new VideoCapture(deviceEdit.SelectedIndex);
                    //videocapture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, CurrentFrameNo);
                    videoCaptureThird.ImageGrabbed += captureImageGrabberThirdTabEvent;
                    videoCaptureThird.SetCaptureProperty(CapProp.FrameWidth, imageWidth);
                    videoCaptureThird.SetCaptureProperty(CapProp.FrameHeight, imageHeight);
                    videoCaptureThird.Start();

                    break;
                case Infrastructure.Utils.CurrentPage.FourthPage:

                    videoCaptureFourth = new VideoCapture(deviceEdit.SelectedIndex);
                    //videocapture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, CurrentFrameNo);
                    videoCaptureFourth.ImageGrabbed += captureImageGrabberFourthTabEvent;
                    videoCaptureFourth.SetCaptureProperty(CapProp.FrameWidth, imageWidth);
                    videoCaptureFourth.SetCaptureProperty(CapProp.FrameHeight, imageHeight);
                    videoCaptureFourth.Start();

                    break;
                case Infrastructure.Utils.CurrentPage.FivesPage:

                    videoCaptureFives = new VideoCapture(deviceEdit.SelectedIndex);
                    //videocapture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, CurrentFrameNo);
                    videoCaptureFives.ImageGrabbed += captureImageGrabberFivesTabEvent;
                    videoCaptureFives.SetCaptureProperty(CapProp.FrameWidth, imageWidth);
                    videoCaptureFives.SetCaptureProperty(CapProp.FrameHeight, imageHeight);
                    videoCaptureFives.Start();

                    break;
                default:
                    break;
            }
        }


        #region Event's


        private void KeyUpEnter(object sender, KeyEventArgs e)
        {
            
        }
        private void KeyUpWithParameter(object sender, KeyEventArgs e, Utils.CurrentPage? currentPage)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (currentPage)
                {
                    case Infrastructure.Utils.CurrentPage.FirstPage:


                        break;
                    case Infrastructure.Utils.CurrentPage.SecondPage:



                        break;
                    case Infrastructure.Utils.CurrentPage.ThirdPage:
                        if (heightOpenRightEye != null && heightOpenLeftEye != null)
                            excelenThirdTab();
                        else
                            NotificationError("Повідомлення","Не вдалося отримати параметри, спробуй ще.");


                        break;
                    case Infrastructure.Utils.CurrentPage.FourthPage:

                        if ((heightCloseRightEye != null && heightCloseLeftEye != null) && (heightCloseRightEye < heightOpenRightEye && heightCloseLeftEye < heightOpenLeftEye))
                            excelenFourthTab();
                        else
                            NotificationError("Повідомлення", "Не вдалося отримати параметри, спробуй ще.");
                        break;

                    case Infrastructure.Utils.CurrentPage.FivesPage:
                        if (imageBrightList != null)
                        {
                            switch (imageBrightList[0])
                            {
                                case Utils.Bright.VeryLow:
                                    NotificationError("Повідомлення", "Занадто низький параметр освітлення приміщення. Відкорегуйте освітлення кімнати!");
                                    break;
                                case Utils.Bright.Low:
                                    NotificationWarning("Повідомлення", "Занизький рівень параметру освітленості приміщення. Відкорегуйте освітлення кімнати!");

                                    break;
                                case Utils.Bright.Normal:
                                    //Task.Run(() =>
                                    //{

                                    //this.Invoke((MethodInvoker)delegate
                                    //{

                                    //    NotificationError("Повідомлення", "Не вдалося отримати параметри, спробуй ще.");
                                    //});
                                    //});
                                    NotificationSucess("Повідомлення", "Оптимальний рівень освітленості приміщення. Завершено налаштування додатку!");

                                    excelenFivesTab();

                                    break;
                                case Utils.Bright.Hight:
                                    NotificationWarning("Повідомлення", "Завищений рівень параметр освітленості приміщення. Відкорегуйте освітлення кімнати!");
                                    break;
                                case Utils.Bright.VeryHight:
                                    NotificationError("Повідомлення", "Занадто високий параметр освітлення приміщення. Відкорегуйте освітлення кімнати!");

                                    break;
                                default:
                                    break;
                            }
                        }





                        //NotificationSucess("",AnalizeBright(imageBrightList[0], imageBrightList[1]));
                        break;
                    default:
                        break;
                }
            } 
            
        }







        #endregion

        private void lenghtEdit_TextChanged(object sender, EventArgs e)
        {
            if(int.Parse(lenghtEdit.Text)>10)
                excelentFirstTab();

        }


        public static int CompareShapes(Rectangle left, Rectangle right)
        {
            return left.Height.CompareTo(right.Height);
        }
        private void settingFirstTabValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            firstSteppTabPage.Appearance.Header.BackColor = Color.IndianRed;
            firstSteppTabPage.ImageOptions.Image = svgImageCollection.GetImage(0);
            secondSteppTabPage.PageVisible = false;
            //secondSteppTabPage.PageEnabled = false;
        }

        
        private void excelentFirstTab()
        {
            firstSteppTabPage.Appearance.Header.BackColor = Color.GreenYellow;
            firstSteppTabPage.ImageOptions.Image = svgImageCollection.GetImage(1);
            secondSteppTabPage.PageVisible = true;
            videoCaptureFirst.Stop();
            settingsTab.SelectedTabPage = secondSteppTabPage;
            CurrentTabPage(Infrastructure.Utils.CurrentPage.SecondPage);

           NotificationSucess("Повідомлення", "Збережено налаштування камери");
            //NotificationWarning("Повідомлення", "Можливе погіршення зору");
        }


        private void excelentSecondTab()
        {
            secondSteppTabPage.Appearance.Header.BackColor = Color.GreenYellow;
            secondSteppTabPage.ImageOptions.Image = svgImageCollection.GetImage(1);
            thirdSteppTabPage.PageVisible = true;
            videoCaptureSecond.Stop();
            videoCaptureSecond.ImageGrabbed -= captureImageGrabberSecondTabEvent;

            settingsTab.SelectedTabPage = thirdSteppTabPage;
            CurrentTabPage(Infrastructure.Utils.CurrentPage.ThirdPage);

            flag = 0;
          
            NotificationSucess("Повідомлення", "Збережено інформацію про розмір обличчя");
         

           

        }

        private void excelenThirdTab()
        {

                thirdSteppTabPage.Appearance.Header.BackColor = Color.GreenYellow;
                thirdSteppTabPage.ImageOptions.Image = svgImageCollection.GetImage(1);
                fourthSteppTabPage.PageVisible = true;
                videoCaptureThird.Stop();
                videoCaptureThird.ImageGrabbed -= captureImageGrabberThirdTabEvent;
                settingsTab.SelectedTabPage = fourthSteppTabPage;
                CurrentTabPage(Infrastructure.Utils.CurrentPage.FourthPage);

                flag = 0;

                NotificationSucess("Повідомлення", "Збережено параметри очей у відкритому положенні");

        }

        private void excelenFourthTab()
        {
            fourthSteppTabPage.Appearance.Header.BackColor = Color.GreenYellow;
            fourthSteppTabPage.ImageOptions.Image = svgImageCollection.GetImage(1);
            fivesSteppTabPage.PageVisible = true;
            videoCaptureFourth.Stop();
            videoCaptureFourth.ImageGrabbed -= captureImageGrabberFourthTabEvent;
            settingsTab.SelectedTabPage = fivesSteppTabPage;
            CurrentTabPage(Infrastructure.Utils.CurrentPage.FivesPage);

            flag = 0;

            NotificationSucess("Повідомлення", "Збережено параметри очей у закритому положенні");

        }

        private void excelenFivesTab()
        {
            fivesSteppTabPage.Appearance.Header.BackColor = Color.GreenYellow;
            fivesSteppTabPage.ImageOptions.Image = svgImageCollection.GetImage(1);
            
            videoCaptureFives.Stop();
            
            //videoCaptureFives = null;
            videoCaptureFives.ImageGrabbed -= captureImageGrabberFivesTabEvent;
            videoCaptureFives.Dispose();
            videoCaptureFirst.Dispose();
            videoCaptureSecond.Dispose();
            videoCaptureThird.Dispose();
            videoCaptureFourth.Dispose();
            captureFirstTabBox.Dispose();
            captureSecondTabBox.Dispose();
            captureThirdTabBox.Dispose();
            captureFourthTabBox.Dispose();
            captureFivesTabBox.Dispose();

            //videoCaptureFives = null;
            flag = 1;

            SaveSettings();

            DialogResult = DialogResult.OK;
            this.Dispose();
            this.Close();


        }


        private void SaveSettings()
        {
            ConfigClass.Instance.GlobalLocalSettings.LoadlocalSettings = true;
            ConfigClass.Instance.GlobalLocalSettings.AllowDisableScreen = false;
            ConfigClass.Instance.GlobalLocalSettings.AvarageFaceSize = avarageFaceSize;
            ConfigClass.Instance.GlobalLocalSettings.HeightCloseLeftEye = heightCloseLeftEye;
            ConfigClass.Instance.GlobalLocalSettings.HeightCloseRightEye = heightCloseRightEye;
            ConfigClass.Instance.GlobalLocalSettings.HeightOpenLeftEye = heightOpenLeftEye;
            ConfigClass.Instance.GlobalLocalSettings.HeightOpenRightEye = heightOpenRightEye;
            ConfigClass.Instance.GlobalLocalSettings.LenghtFromLinearToCam = lenghtFromLinearToCam;
            ConfigClass.Instance.GlobalLocalSettings.LenghtLinear = lenghtLinear;
            ConfigClass.Instance.GlobalLocalSettings.MatrixCam = matrixCam;
            ConfigClass.Instance.GlobalLocalSettings.NormalLenghtFromUserToCam = normalLenghtFromUserToCam;
            ConfigClass.Instance.GlobalLocalSettings.SaveStatistics = false;

            try
            {
                ConfigClass.Instance.SetLocalSettings();
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при оновленні параметрів!\n" + ex.Message, "Оновлення налаштувань", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();

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

        private void deviceEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrentTabPage(Utils.CurrentPage.FirstPage);
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Не коректні налаштування системи!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void captureImageGrabberEvent(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                videoCaptureFirst.Retrieve(m);

                firstTabImage = m.ToImage<Bgr, byte>();
                captureFirstTabBox.Image = firstTabImage;

                Thread.Sleep(1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void captureImageGrabberSecondTabEvent(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                videoCaptureSecond.Retrieve(m);

                secondTabImage = m.ToImage<Bgr, byte>();

                double k = (matrixCam * avarageFaceSize) / normalLenghtFromUserToCam;

                int heightSearchFace = (int)Math.Round((imageHeight * k)*1.2,0);     

                Rectangle rec = new Rectangle((int)Math.Round((imageWidth - heightSearchFace) /2.0,0), (int)Math.Round((imageHeight - heightSearchFace) / 2.0, 0), heightSearchFace, heightSearchFace);

                Mat newMat = cropFrame(secondTabImage.Mat, rec);

                Image<Bgr, byte> areaSearchFace = new Image<Bgr, byte>(newMat.Size);

                areaSearchFace.Bitmap = newMat.Bitmap;

                VectorOfRect faces = new VectorOfRect(faceFrontalDetector.DetectMultiScale(areaSearchFace, 1.1, 3, new Size(150, 150), new Size(200, 200)));

                if (faces.Size > 0)
                {
                    secondTabImage.Draw(rec, new Bgr(Color.Green), 2);
                    ++flag;
                    if(flag > 10)
                    {
                        Invoke(new Action(() =>
                        {
                            excelentSecondTab();
                        }));
                    }
                }
                else
                {
                    secondTabImage.Draw(rec, new Bgr(Color.Red), 2);
                }

                captureSecondTabBox.Image = secondTabImage;

                Thread.Sleep(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void captureImageGrabberThirdTabEvent(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();

                videoCaptureThird.Retrieve(m);

                thirdTabImage = m.ToImage<Bgr, Byte>();
                var imgGray = thirdTabImage.Convert<Gray, byte>().Clone(); //Конвертируем в оттенки серого

                imgGray._EqualizeHist();// выравниваем ярксоть (только для черно-белого изображения)

                imgGray._SmoothGaussian(1);//гауусовский фильтр

                VectorOfRect faces = new VectorOfRect(faceFrontalDetector.DetectMultiScale(imgGray, 1.1, 3, new Size(150, 150), new Size(200, 200)));//находим все лица
                if (faces.Size > 0)
                {
                    Rectangle[] facesRect = faces.ToArray();// приводим вектор к фигуре
                    //facesRect[0]

                    Array.Sort(facesRect, new Comparison<Rectangle>(CompareShapes));  //сортировка по высоте

                    VectorOfVectorOfPointF landmarks = new VectorOfVectorOfPointF();

                    bool success = facemark.Fit(imgGray, faces, landmarks);//находим точки лица


                    double k = (double)faces[0].Height / imgGray.Height;

                    //double k = (matrixCam * avarageFaceSize) / normalLenghtFromUserToCam;

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

                    if (rightEyeMaximalPoint.Y > 0 && rightEyeMinimalPoint.Y > 0 && leftEyeMaximalPoint.Y > 0 && leftEyeMinimalPoint.Y > 0)
                    {
                        if (flag < 30)
                        {
                            thirdTabImage.DrawPolyline(leftEye, true, new Bgr(Color.Red), 1);
                            thirdTabImage.DrawPolyline(rightEye, true, new Bgr(Color.Red), 1);

                            ++flag;
                        }
                        else if (flag >= 30)
                        {
                            thirdTabImage.DrawPolyline(leftEye, true, new Bgr(Color.Green), 1);
                            thirdTabImage.DrawPolyline(rightEye, true, new Bgr(Color.Green), 1);

                            double bufer = rightEyeMinimalPoint.Y - rightEyeMaximalPoint.Y;

                            double kk = ((double)bufer) / imgGray.Height;

                            //double test = (s * kk) / matrixCam;


                            heightOpenRightEye = (s * kk) / matrixCam;
                            heightOpenLeftEye = (s * kk) / matrixCam;

                            //heightOpenRightEye = ((rightEyeMinimalPoint.Y - rightEyeMaximalPoint.Y) * k) / matrixCam;
                            //heightOpenLeftEye = ((leftEyeMinimalPoint.Y - leftEyeMaximalPoint.Y) * k) / matrixCam;

                        }
                    }

                    captureThirdTabBox.Image = thirdTabImage;

                }
                else if (faces.Size == 0)
                {
                    //faces = new VectorOfRect(faceProfilDetector.DetectMultiScale(imgGray));
                    captureThirdTabBox.Image = thirdTabImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void captureImageGrabberFourthTabEvent(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();

                videoCaptureFourth.Retrieve(m);

                fourthTabImage = m.ToImage<Bgr, Byte>();
                var imgGray = fourthTabImage.Convert<Gray, byte>().Clone(); //Конвертируем в оттенки серого

                imgGray._EqualizeHist();// выравниваем ярксоть (только для черно-белого изображения)

                imgGray._SmoothGaussian(1);//гауусовский фильтр

                VectorOfRect faces = new VectorOfRect(faceFrontalDetector.DetectMultiScale(imgGray, 1.1, 3, new Size(150, 150), new Size(200, 200)));//находим все лица
                if (faces.Size > 0)
                {
                    Rectangle[] facesRect = faces.ToArray();// приводим вектор к фигуре
                    //facesRect[0]

                    Array.Sort(facesRect, new Comparison<Rectangle>(CompareShapes));  //сортировка по высоте

                    VectorOfVectorOfPointF landmarks = new VectorOfVectorOfPointF();

                    bool success = facemark.Fit(imgGray, faces, landmarks);//находим точки лица

                    #region Расстояние до пользователя

                    double k = (double)faces[0].Height / imgGray.Height;

                    double s = (matrixCam * avarageFaceSize) / k;

                    #endregion


                    #region Поиск точек глаз 

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

                    #endregion




                    if (rightEyeMaximalPoint.Y > 0 && rightEyeMinimalPoint.Y > 0 && leftEyeMaximalPoint.Y > 0 && leftEyeMinimalPoint.Y > 0)
                    {
                        if (flag < 30)
                        {
                            fourthTabImage.DrawPolyline(leftEye, true, new Bgr(Color.Red), 1);
                            fourthTabImage.DrawPolyline(rightEye, true, new Bgr(Color.Red), 1);

                            ++flag;
                        }
                        else if (flag >= 30)
                        {

                            double bufer = rightEyeMinimalPoint.Y - rightEyeMaximalPoint.Y;

                            double kk = ((double)bufer) / imgGray.Height;
                            
                            fourthTabImage.DrawPolyline(leftEye, true, new Bgr(Color.Green), 1);
                            fourthTabImage.DrawPolyline(rightEye, true, new Bgr(Color.Green), 1);

                            heightCloseRightEye = (s * kk) / matrixCam;
                            heightCloseLeftEye = (s * kk) / matrixCam;

                            //heightCloseRightEye = ((rightEyeMinimalPoint.Y - rightEyeMaximalPoint.Y) * k) / matrixCam;
                            //heightCloseLeftEye = ((leftEyeMinimalPoint.Y - leftEyeMaximalPoint.Y) * k) / matrixCam;

                        }
                    }

                    captureFourthTabBox.Image = fourthTabImage;

                }
                else if (faces.Size == 0)
                {
                    //faces = new VectorOfRect(faceProfilDetector.DetectMultiScale(imgGray));
                    captureFourthTabBox.Image = fourthTabImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void captureImageGrabberFivesTabEvent(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                try
                {
                    Mat m = new Mat();

                    videoCaptureFives.Retrieve(m);

                    fivesTabImage = m.ToImage<Bgr, Byte>();
                    var imgGray = fivesTabImage.Convert<Gray, byte>().Clone(); //Конвертируем в оттенки серого

                    DenseHistogram hist = new DenseHistogram(256, new RangeF(0.0f, 255.0f));

                    hist.Calculate<Byte>(new Image<Gray, byte>[] { imgGray }, true, null);

                    VectorOfRect faces = new VectorOfRect(faceFrontalDetector.DetectMultiScale(imgGray, 1.2, 10, new Size(80, 80), new Size(300, 300)));//находим все лица
                    if (faces.Size > 0)
                    {
                        Rectangle[] facesRect = faces.ToArray();// приводим вектор к фигуре
                                                                //facesRect[0]

                        Array.Sort(facesRect, new Comparison<Rectangle>(CompareShapes));

                        imageBrightList = FrameBright(imgGray, facesRect[0]);



                        fivesTabImage.Draw(facesRect[0], new Bgr(Color.Green), 1);

                        captureFivesTabBox.Image = fivesTabImage;

                    }
                    else if (faces.Size == 0)
                    {
                        captureFivesTabBox.Image = fivesTabImage;
                    }

                    Thread.Sleep(1);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #region Анализатор яркости

        public List<Utils.Bright> FrameBright(Image<Gray, byte> img, Rectangle rec)
        {
            List<Utils.Bright> returnParam = new List<Utils.Bright>();
            Utils.Bright image;
            Utils.Bright imageFace;
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

            avarageImage = bufferImage / ((img.Width * img.Height) - (grayFace.Height * grayFace.Width));

            for (int i = 0; i < GrayHistFace.Length; i++)
            {
                bufferImageFace += GrayHistFace[i] * i;
            }

            avarageImageFace = bufferImageFace / (grayFace.Height * grayFace.Width);

            if (avarageImage > 120 && avarageImage < 200)
            {
                image = Utils.Bright.Normal;
            }
            else if (avarageImage > 50 && avarageImage < 120)
            {
                image = Utils.Bright.Low;
            }
            else if (avarageImage < 50)
            {
                image = Utils.Bright.VeryLow;
            }
            else if (avarageImage > 120 && avarageImage < 200)
            {
                image = Utils.Bright.Hight;
            }
            else
            {
                image = Utils.Bright.VeryHight;
            }

            if (avarageImageFace > 120 && avarageImageFace < 200)
            {
                imageFace = Utils.Bright.Normal;
            }
            else if (avarageImageFace > 50 && avarageImageFace < 120)
            {
                imageFace = Utils.Bright.Low;
            }
            else if (avarageImageFace < 50)
            {
                imageFace = Utils.Bright.VeryLow;
            }
            else if (avarageImageFace > 120 && avarageImageFace < 200)
            {
                imageFace = Utils.Bright.Hight;
            }
            else
            {
                imageFace = Utils.Bright.VeryHight;
            }
            returnParam.Add(image);
            returnParam.Add(imageFace);

            return returnParam;

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

        #endregion

        #region Работа с изображением

        Mat cropFrame(Mat input, Rectangle cropRegion)
        {
            /* 
            * TODO(Ahmed): Figure out why I had to copy this into this class. 
            * */
            Image<Bgr, Byte> buffer_im = input.ToImage<Bgr, Byte>();
            buffer_im.ROI = cropRegion;

            Image<Bgr, Byte> cropped_im = buffer_im.Copy();


            return cropped_im.Mat;

        }


        #endregion

        private void SettingsUserFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //captureFirstTabBox.Dispose();
            //captureSecondTabBox.Dispose();
            //captureThirdTabBox.Dispose();
            //captureFourthTabBox.Dispose();
            //captureFivesTabBox.Dispose();
            //videoCaptureFirst.Dispose();
            //videoCaptureFives.Dispose();
            //videoCaptureFourth.Dispose();
            //videoCaptureSecond.Dispose();
            //videoCaptureSecond.Dispose();

        }
    }

    public class CustomValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            ComboBoxEdit edit = control as ComboBoxEdit;
            if (edit == null || edit.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }
    }
}