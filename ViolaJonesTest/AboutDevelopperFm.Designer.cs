namespace ViolaJonesTest
{
    partial class AboutDevelopperFm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDevelopperFm));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.videoCaptureBox = new Emgu.CV.UI.PanAndZoomPictureBox();
            this.settingsBar = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.videoCaptureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(17, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(95, 19);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Розробник:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(187, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(255, 19);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Онищенко Юрій Миколайович";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(17, 57);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 19);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Група:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(190, 57);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 19);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "КІ-17-1М";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(190, 95);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(253, 19);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Луговой Анатолій Васильович";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(17, 95);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(167, 19);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Науковий керівник:";
            // 
            // videoCaptureBox
            // 
            this.videoCaptureBox.Image = global::ViolaJonesTest.Properties.Resources.лицо;
            this.videoCaptureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.videoCaptureBox.Location = new System.Drawing.Point(12, 32);
            this.videoCaptureBox.Name = "videoCaptureBox";
            this.videoCaptureBox.Size = new System.Drawing.Size(300, 304);
            this.videoCaptureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.videoCaptureBox.TabIndex = 15;
            this.videoCaptureBox.TabStop = false;
            // 
            // settingsBar
            // 
            this.settingsBar.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.settingsBar.DockControls.Add(this.barDockControlTop);
            this.settingsBar.DockControls.Add(this.barDockControlBottom);
            this.settingsBar.DockControls.Add(this.barDockControlLeft);
            this.settingsBar.DockControls.Add(this.barDockControl1);
            this.settingsBar.Form = this;
            this.settingsBar.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem2,
            this.barButtonItem9,
            this.barButtonItem6});
            this.settingsBar.MainMenu = this.bar1;
            this.settingsBar.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarAppearance.Normal.BackColor = System.Drawing.Color.Transparent;
            this.bar1.BarAppearance.Normal.BackColor2 = System.Drawing.Color.Transparent;
            this.bar1.BarAppearance.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.bar1.BarAppearance.Normal.ForeColor = System.Drawing.Color.Transparent;
            this.bar1.BarAppearance.Normal.Options.UseBackColor = true;
            this.bar1.BarAppearance.Normal.Options.UseBorderColor = true;
            this.bar1.BarAppearance.Normal.Options.UseForeColor = true;
            this.bar1.BarAppearance.Pressed.BackColor = System.Drawing.Color.Transparent;
            this.bar1.BarAppearance.Pressed.Options.UseBackColor = true;
            this.bar1.BarName = "Главное меню";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.RotateWhenVertical = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Главное меню";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ImageOptions.SvgImage = global::ViolaJonesTest.Properties.Resources._01;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem4.Caption = "barButtonItem1";
            this.barButtonItem4.Id = 0;
            this.barButtonItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.barButtonItem4.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.LargeImage")));
            this.barButtonItem4.ItemAppearance.Disabled.BackColor = System.Drawing.Color.Transparent;
            this.barButtonItem4.ItemAppearance.Disabled.ForeColor = System.Drawing.Color.Transparent;
            this.barButtonItem4.ItemAppearance.Disabled.Options.UseBackColor = true;
            this.barButtonItem4.ItemAppearance.Disabled.Options.UseForeColor = true;
            this.barButtonItem4.ItemAppearance.Normal.BackColor = System.Drawing.Color.Transparent;
            this.barButtonItem4.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Transparent;
            this.barButtonItem4.ItemAppearance.Normal.Options.UseBackColor = true;
            this.barButtonItem4.ItemAppearance.Normal.Options.UseForeColor = true;
            this.barButtonItem4.ItemInMenuAppearance.Normal.BackColor = System.Drawing.Color.Transparent;
            this.barButtonItem4.ItemInMenuAppearance.Normal.ForeColor = System.Drawing.Color.Transparent;
            this.barButtonItem4.ItemInMenuAppearance.Normal.Options.UseBackColor = true;
            this.barButtonItem4.ItemInMenuAppearance.Normal.Options.UseForeColor = true;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Про розробника";
            this.barButtonItem6.Id = 4;
            this.barButtonItem6.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Black;
            this.barButtonItem6.ItemAppearance.Normal.Options.UseForeColor = true;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.settingsBar;
            this.barDockControlTop.Size = new System.Drawing.Size(811, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 349);
            this.barDockControlBottom.Manager = this.settingsBar;
            this.barDockControlBottom.Size = new System.Drawing.Size(811, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Manager = this.settingsBar;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 323);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(811, 26);
            this.barDockControl1.Manager = this.settingsBar;
            this.barDockControl1.Size = new System.Drawing.Size(0, 323);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem2";
            this.barButtonItem5.Id = 1;
            this.barButtonItem5.ImageOptions.SvgImage = global::ViolaJonesTest.Properties.Resources._011;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem9.Id = 3;
            this.barButtonItem9.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.barButtonItem9.ImageOptions.Image = global::ViolaJonesTest.Properties.Resources.minimize_window_16;
            this.barButtonItem9.ImageOptions.LargeImage = global::ViolaJonesTest.Properties.Resources.delete_32x32;
            this.barButtonItem9.ItemAppearance.Disabled.BackColor = System.Drawing.Color.White;
            this.barButtonItem9.ItemAppearance.Disabled.Options.UseBackColor = true;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // barAndDockingController
            // 
            this.barAndDockingController.AppearancesBackstageView.BackstageView.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBackstageView.BackstageView.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBackstageView.BackstageView.ForeColor = System.Drawing.Color.Purple;
            this.barAndDockingController.AppearancesBackstageView.BackstageView.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBackstageView.BackstageView.Options.UseForeColor = true;
            this.barAndDockingController.AppearancesBackstageView.Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.barAndDockingController.AppearancesBackstageView.Button.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.barAndDockingController.AppearancesBackstageView.Button.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.barAndDockingController.AppearancesBackstageView.Button.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBackstageView.Button.Options.UseBorderColor = true;
            this.barAndDockingController.AppearancesBackstageView.ButtonPressed.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBackstageView.ButtonPressed.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBackstageView.ButtonPressed.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBackstageView.Separator.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBackstageView.Separator.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBackstageView.Tab.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBackstageView.Tab.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBackstageView.Tab.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBackstageView.TabHover.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBackstageView.TabHover.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBackstageView.TabSelected.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBackstageView.TabSelected.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBackstageView.TabSelected.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBar.BarAppearance.Disabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.barAndDockingController.AppearancesBar.BarAppearance.Disabled.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.barAndDockingController.AppearancesBar.BarAppearance.Disabled.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBar.BarAppearance.Hovered.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.BarAppearance.Hovered.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.BarAppearance.Hovered.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBar.BarAppearance.Normal.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.BarAppearance.Normal.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.BarAppearance.Normal.BorderColor = System.Drawing.Color.White;
            this.barAndDockingController.AppearancesBar.BarAppearance.Normal.ForeColor = System.Drawing.Color.Fuchsia;
            this.barAndDockingController.AppearancesBar.BarAppearance.Normal.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBar.BarAppearance.Normal.Options.UseBorderColor = true;
            this.barAndDockingController.AppearancesBar.BarAppearance.Normal.Options.UseForeColor = true;
            this.barAndDockingController.AppearancesBar.BarAppearance.Pressed.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.BarAppearance.Pressed.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.BarAppearance.Pressed.BorderColor = System.Drawing.Color.White;
            this.barAndDockingController.AppearancesBar.BarAppearance.Pressed.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBar.BarAppearance.Pressed.Options.UseBorderColor = true;
            this.barAndDockingController.AppearancesBar.Dock.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.Dock.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.Dock.ForeColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.Dock.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBar.Dock.Options.UseForeColor = true;
            this.barAndDockingController.AppearancesBar.MainMenuAppearance.Normal.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.MainMenuAppearance.Normal.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.MainMenuAppearance.Normal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.barAndDockingController.AppearancesBar.MainMenuAppearance.Normal.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBar.MainMenuAppearance.Normal.Options.UseBorderColor = true;
            this.barAndDockingController.AppearancesBar.StatusBarAppearance.Normal.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.StatusBarAppearance.Normal.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.StatusBarAppearance.Normal.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBar.SubMenu.AppearanceMenu.Normal.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.SubMenu.AppearanceMenu.Normal.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.SubMenu.AppearanceMenu.Normal.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBar.SubMenu.HeaderItemAppearance.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.SubMenu.HeaderItemAppearance.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.SubMenu.HeaderItemAppearance.ForeColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.SubMenu.HeaderItemAppearance.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBar.SubMenu.HeaderItemAppearance.Options.UseForeColor = true;
            this.barAndDockingController.AppearancesBar.SubMenu.MenuBar.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.SubMenu.MenuBar.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.SubMenu.MenuBar.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBar.SubMenu.MenuCaption.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.SubMenu.MenuCaption.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.SubMenu.MenuCaption.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBar.SubMenu.SideStrip.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.SubMenu.SideStrip.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.SubMenu.SideStrip.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesBar.SubMenu.SideStripNonRecent.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.SubMenu.SideStripNonRecent.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesBar.SubMenu.SideStripNonRecent.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesDocking.ActiveTab.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesDocking.ActiveTab.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesDocking.ActiveTab.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesDocking.FloatFormCaption.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesDocking.FloatFormCaption.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesDocking.FloatFormCaption.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesDocking.FloatFormCaptionActive.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesDocking.FloatFormCaptionActive.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesDocking.FloatFormCaptionActive.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesDocking.HideContainer.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesDocking.HideContainer.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesDocking.HideContainer.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesDocking.HidePanelButton.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesDocking.HidePanelButton.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesDocking.HidePanelButton.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesDocking.HidePanelButtonActive.BackColor = System.Drawing.Color.Lime;
            this.barAndDockingController.AppearancesDocking.HidePanelButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.barAndDockingController.AppearancesDocking.HidePanelButtonActive.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesDocking.Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.barAndDockingController.AppearancesDocking.Panel.BackColor2 = System.Drawing.Color.Olive;
            this.barAndDockingController.AppearancesDocking.Panel.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesDocking.PanelCaption.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesDocking.PanelCaption.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesDocking.PanelCaption.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesDocking.PanelCaptionActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.barAndDockingController.AppearancesDocking.PanelCaptionActive.BackColor2 = System.Drawing.Color.Yellow;
            this.barAndDockingController.AppearancesDocking.PanelCaptionActive.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesDocking.Tabs.BackColor = System.Drawing.Color.Green;
            this.barAndDockingController.AppearancesDocking.Tabs.BackColor2 = System.Drawing.Color.Aqua;
            this.barAndDockingController.AppearancesDocking.Tabs.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesDocumentManager.View.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.barAndDockingController.AppearancesRibbon.Editor.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.Editor.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.Editor.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesRibbon.FormCaption.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.FormCaption.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.FormCaption.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesRibbon.FormCaptionForeColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.FormCaptionForeColorInactive = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.Item.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.Item.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.Item.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesRibbon.ItemDescriptionDisabled.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.ItemDescriptionDisabled.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.ItemDescriptionDisabled.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesRibbon.ItemDescriptionHovered.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.ItemDescriptionHovered.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.ItemDescriptionHovered.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesRibbon.ItemDescriptionPressed.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.ItemDescriptionPressed.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.ItemDescriptionPressed.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesRibbon.ItemDisabled.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.ItemDisabled.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.ItemDisabled.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesRibbon.ItemHovered.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.ItemHovered.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.ItemHovered.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesRibbon.ItemPressed.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.ItemPressed.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.ItemPressed.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesRibbon.PageCategory.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.PageCategory.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.PageCategory.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesRibbon.PageGroupCaption.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.PageGroupCaption.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.PageGroupCaption.Options.UseBackColor = true;
            this.barAndDockingController.AppearancesRibbon.PageHeader.BackColor = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.PageHeader.BackColor2 = System.Drawing.Color.Transparent;
            this.barAndDockingController.AppearancesRibbon.PageHeader.Options.UseBackColor = true;
            this.barAndDockingController.LookAndFeel.FormTouchUIMode = DevExpress.Utils.DefaultBoolean.False;
            this.barAndDockingController.LookAndFeel.SkinName = "VS2010";
            this.barAndDockingController.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.barAndDockingController.LookAndFeel.UseDefaultLookAndFeel = false;
            this.barAndDockingController.PropertiesBar.AllowLinkLighting = false;
            this.barAndDockingController.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.barAndDockingController.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Location = new System.Drawing.Point(332, 32);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(463, 304);
            this.panelControl1.TabIndex = 20;
            // 
            // AboutDevelopperFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 349);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.videoCaptureBox);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDevelopperFm";
            this.ShowIcon = false;
            this.Text = "Про розробника";
            ((System.ComponentModel.ISupportInitialize)(this.videoCaptureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private Emgu.CV.UI.PanAndZoomPictureBox videoCaptureBox;
        private DevExpress.XtraBars.BarManager settingsBar;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}