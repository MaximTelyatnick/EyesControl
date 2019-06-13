namespace ViolaJonesTest
{
    partial class MainTabFm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange1 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange2 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange3 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange4 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTabFm));
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::ViolaJonesTest.WaitForm1), true, true);
            this.generalMenu = new System.Windows.Forms.MenuStrip();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестуванняЗОднимКадромToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестированиеFacemarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестированиеВидепотокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.інформаціяПроРозробникаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalBox = new Emgu.CV.UI.ImageBox();
            this.showBtn = new System.Windows.Forms.Button();
            this.closeShowBtn = new System.Windows.Forms.Button();
            this.faceSizePixelEdit = new System.Windows.Forms.TextBox();
            this.camLengthEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.faceSizeCaug = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
            this.arcScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent();
            this.arcScaleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            this.arcScaleNeedleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent();
            this.arcScaleSpindleCapComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.leftEyeEdit = new System.Windows.Forms.TextBox();
            this.rightEyeEdit = new System.Windows.Forms.TextBox();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.generalMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generalBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faceSizeCaug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // generalMenu
            // 
            this.generalMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem,
            this.інформаціяПроРозробникаToolStripMenuItem});
            this.generalMenu.Location = new System.Drawing.Point(0, 0);
            this.generalMenu.Name = "generalMenu";
            this.generalMenu.Size = new System.Drawing.Size(1313, 24);
            this.generalMenu.TabIndex = 0;
            this.generalMenu.Text = "menuStrip1";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тестуванняЗОднимКадромToolStripMenuItem,
            this.тестированиеFacemarkToolStripMenuItem,
            this.тестированиеВидепотокToolStripMenuItem});
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(101, 20);
            this.settingsMenuItem.Text = "Налаштування";
            // 
            // тестуванняЗОднимКадромToolStripMenuItem
            // 
            this.тестуванняЗОднимКадромToolStripMenuItem.Name = "тестуванняЗОднимКадромToolStripMenuItem";
            this.тестуванняЗОднимКадромToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.тестуванняЗОднимКадромToolStripMenuItem.Text = "Тестування з одним кадром";
            this.тестуванняЗОднимКадромToolStripMenuItem.Click += new System.EventHandler(this.тестуванняЗОднимКадромToolStripMenuItem_Click);
            // 
            // тестированиеFacemarkToolStripMenuItem
            // 
            this.тестированиеFacemarkToolStripMenuItem.Name = "тестированиеFacemarkToolStripMenuItem";
            this.тестированиеFacemarkToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.тестированиеFacemarkToolStripMenuItem.Text = "Тестирование Facemark";
            this.тестированиеFacemarkToolStripMenuItem.Click += new System.EventHandler(this.тестированиеFacemarkToolStripMenuItem_Click);
            // 
            // тестированиеВидепотокToolStripMenuItem
            // 
            this.тестированиеВидепотокToolStripMenuItem.Name = "тестированиеВидепотокToolStripMenuItem";
            this.тестированиеВидепотокToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.тестированиеВидепотокToolStripMenuItem.Text = "Тестирование виде-поток";
            this.тестированиеВидепотокToolStripMenuItem.Click += new System.EventHandler(this.тестированиеВидепотокToolStripMenuItem_Click);
            // 
            // інформаціяПроРозробникаToolStripMenuItem
            // 
            this.інформаціяПроРозробникаToolStripMenuItem.Name = "інформаціяПроРозробникаToolStripMenuItem";
            this.інформаціяПроРозробникаToolStripMenuItem.Size = new System.Drawing.Size(176, 20);
            this.інформаціяПроРозробникаToolStripMenuItem.Text = "Інформація про розробника";
            this.інформаціяПроРозробникаToolStripMenuItem.Click += new System.EventHandler(this.інформаціяПроРозробникаToolStripMenuItem_Click);
            // 
            // generalBox
            // 
            this.generalBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.generalBox.Location = new System.Drawing.Point(12, 27);
            this.generalBox.Name = "generalBox";
            this.generalBox.Size = new System.Drawing.Size(640, 360);
            this.generalBox.TabIndex = 2;
            this.generalBox.TabStop = false;
            // 
            // showBtn
            // 
            this.showBtn.Location = new System.Drawing.Point(668, 27);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(167, 23);
            this.showBtn.TabIndex = 3;
            this.showBtn.Text = "Начать тестирование";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // closeShowBtn
            // 
            this.closeShowBtn.Location = new System.Drawing.Point(668, 56);
            this.closeShowBtn.Name = "closeShowBtn";
            this.closeShowBtn.Size = new System.Drawing.Size(167, 28);
            this.closeShowBtn.TabIndex = 4;
            this.closeShowBtn.Text = "Завершить тестирование";
            this.closeShowBtn.UseVisualStyleBackColor = true;
            this.closeShowBtn.Click += new System.EventHandler(this.closeShowBtn_Click);
            // 
            // faceSizePixelEdit
            // 
            this.faceSizePixelEdit.Location = new System.Drawing.Point(1201, 30);
            this.faceSizePixelEdit.Name = "faceSizePixelEdit";
            this.faceSizePixelEdit.Size = new System.Drawing.Size(100, 21);
            this.faceSizePixelEdit.TabIndex = 5;
            // 
            // camLengthEdit
            // 
            this.camLengthEdit.Location = new System.Drawing.Point(1201, 61);
            this.camLengthEdit.Name = "camLengthEdit";
            this.camLengthEdit.Size = new System.Drawing.Size(100, 21);
            this.camLengthEdit.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1063, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Размер лица в пикселях";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1063, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Расстояние до камеры";
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.AutoLayout = false;
            this.gaugeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.faceSizeCaug});
            this.gaugeControl1.Location = new System.Drawing.Point(2, 2);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(295, 186);
            this.gaugeControl1.TabIndex = 9;
            // 
            // faceSizeCaug
            // 
            this.faceSizeCaug.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent[] {
            this.arcScaleBackgroundLayerComponent1});
            this.faceSizeCaug.Bounds = new System.Drawing.Rectangle(-1, 0, 306, 183);
            this.faceSizeCaug.Name = "faceSizeCaug";
            this.faceSizeCaug.Needles.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent[] {
            this.arcScaleNeedleComponent1});
            this.faceSizeCaug.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent[] {
            this.arcScaleComponent1});
            this.faceSizeCaug.SpindleCaps.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent[] {
            this.arcScaleSpindleCapComponent1});
            this.faceSizeCaug.Changed += new System.EventHandler(this.faceSizeCaug_Changed);
            // 
            // arcScaleBackgroundLayerComponent1
            // 
            this.arcScaleBackgroundLayerComponent1.ArcScale = this.arcScaleComponent1;
            this.arcScaleBackgroundLayerComponent1.Name = "bg";
            this.arcScaleBackgroundLayerComponent1.ScaleCenterPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.695F);
            this.arcScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.CircularHalf_Style16;
            this.arcScaleBackgroundLayerComponent1.Size = new System.Drawing.SizeF(250F, 179F);
            this.arcScaleBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // arcScaleComponent1
            // 
            this.arcScaleComponent1.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent1.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent1.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent1.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent1.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 9F);
            this.arcScaleComponent1.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
            this.arcScaleComponent1.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 165F);
            this.arcScaleComponent1.EndAngle = 0F;
            this.arcScaleComponent1.MajorTickCount = 6;
            this.arcScaleComponent1.MajorTickmark.FormatString = "{0:F0}";
            this.arcScaleComponent1.MajorTickmark.ShapeOffset = -13F;
            this.arcScaleComponent1.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_1;
            this.arcScaleComponent1.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.arcScaleComponent1.MaxValue = 300F;
            this.arcScaleComponent1.MinorTickCount = 4;
            this.arcScaleComponent1.MinorTickmark.ShapeOffset = -9F;
            this.arcScaleComponent1.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_2;
            this.arcScaleComponent1.Name = "scale1";
            this.arcScaleComponent1.RadiusX = 98F;
            this.arcScaleComponent1.RadiusY = 98F;
            arcScaleRange1.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#9EC968");
            arcScaleRange1.EndThickness = 14F;
            arcScaleRange1.EndValue = 180F;
            arcScaleRange1.Name = "Range0";
            arcScaleRange1.ShapeOffset = 0F;
            arcScaleRange1.StartThickness = 15F;
            arcScaleRange1.StartValue = 120F;
            arcScaleRange2.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#FED96D");
            arcScaleRange2.EndThickness = 14F;
            arcScaleRange2.EndValue = 66F;
            arcScaleRange2.Name = "Range1";
            arcScaleRange2.ShapeOffset = 0F;
            arcScaleRange2.StartThickness = 14F;
            arcScaleRange2.StartValue = 33F;
            arcScaleRange3.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#EF8C75");
            arcScaleRange3.EndThickness = 14F;
            arcScaleRange3.EndValue = 100F;
            arcScaleRange3.Name = "Range2";
            arcScaleRange3.ShapeOffset = 0F;
            arcScaleRange3.StartThickness = 14F;
            arcScaleRange3.StartValue = 66F;
            arcScaleRange4.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:NavajoWhite");
            arcScaleRange4.EndThickness = 15F;
            arcScaleRange4.EndValue = 240F;
            arcScaleRange4.Name = "Range3";
            arcScaleRange4.ShapeOffset = 16F;
            arcScaleRange4.StartThickness = 15F;
            arcScaleRange4.StartValue = 180F;
            this.arcScaleComponent1.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            arcScaleRange1,
            arcScaleRange2,
            arcScaleRange3,
            arcScaleRange4});
            this.arcScaleComponent1.StartAngle = -180F;
            this.arcScaleComponent1.Value = 22F;
            // 
            // arcScaleNeedleComponent1
            // 
            this.arcScaleNeedleComponent1.ArcScale = this.arcScaleComponent1;
            this.arcScaleNeedleComponent1.EndOffset = 3F;
            this.arcScaleNeedleComponent1.Name = "needle";
            this.arcScaleNeedleComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.NeedleShapeType.CircularFull_Style16;
            this.arcScaleNeedleComponent1.ZOrder = -50;
            // 
            // arcScaleSpindleCapComponent1
            // 
            this.arcScaleSpindleCapComponent1.ArcScale = this.arcScaleComponent1;
            this.arcScaleSpindleCapComponent1.Name = "circularGauge1_SpindleCap1";
            this.arcScaleSpindleCapComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.SpindleCapShapeType.CircularFull_Style16;
            this.arcScaleSpindleCapComponent1.Size = new System.Drawing.SizeF(25F, 25F);
            this.arcScaleSpindleCapComponent1.ZOrder = -100;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gaugeControl1);
            this.panelControl1.Location = new System.Drawing.Point(1002, 371);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(299, 190);
            this.panelControl1.TabIndex = 10;
            // 
            // leftEyeEdit
            // 
            this.leftEyeEdit.Location = new System.Drawing.Point(1107, 108);
            this.leftEyeEdit.Name = "leftEyeEdit";
            this.leftEyeEdit.Size = new System.Drawing.Size(100, 21);
            this.leftEyeEdit.TabIndex = 11;
            // 
            // rightEyeEdit
            // 
            this.rightEyeEdit.Location = new System.Drawing.Point(1107, 134);
            this.rightEyeEdit.Name = "rightEyeEdit";
            this.rightEyeEdit.Size = new System.Drawing.Size(100, 21);
            this.rightEyeEdit.TabIndex = 12;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis";
            // 
            // MainTabFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 573);
            this.Controls.Add(this.rightEyeEdit);
            this.Controls.Add(this.leftEyeEdit);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.camLengthEdit);
            this.Controls.Add(this.faceSizePixelEdit);
            this.Controls.Add(this.closeShowBtn);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.generalBox);
            this.Controls.Add(this.generalMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.generalMenu;
            this.Name = "MainTabFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.generalMenu.ResumeLayout(false);
            this.generalMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generalBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faceSizeCaug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip generalMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem інформаціяПроРозробникаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестуванняЗОднимКадромToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестированиеFacemarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестированиеВидепотокToolStripMenuItem;
        private Emgu.CV.UI.ImageBox generalBox;
        private System.Windows.Forms.Button showBtn;
        private System.Windows.Forms.Button closeShowBtn;
        private System.Windows.Forms.TextBox faceSizePixelEdit;
        private System.Windows.Forms.TextBox camLengthEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge faceSizeCaug;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent arcScaleBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent arcScaleNeedleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent arcScaleSpindleCapComponent1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        private System.Windows.Forms.TextBox leftEyeEdit;
        private System.Windows.Forms.TextBox rightEyeEdit;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}

