namespace ViolaJonesTest
{
    partial class MadeImageFm
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
            this.saveImgBtn = new System.Windows.Forms.Button();
            this.middleSizeItem = new System.Windows.Forms.RadioButton();
            this.lowSizeItem = new System.Windows.Forms.RadioButton();
            this.veryLowSizeItem = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.veryVeryLowSizeItem = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.currentDeviceCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.videoCaptureBox = new Emgu.CV.UI.PanAndZoomPictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoCaptureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // saveImgBtn
            // 
            this.saveImgBtn.Location = new System.Drawing.Point(0, 356);
            this.saveImgBtn.Name = "saveImgBtn";
            this.saveImgBtn.Size = new System.Drawing.Size(353, 44);
            this.saveImgBtn.TabIndex = 1;
            this.saveImgBtn.Text = "Зберегти зображення";
            this.saveImgBtn.UseVisualStyleBackColor = true;
            this.saveImgBtn.Click += new System.EventHandler(this.saveImgBtn_Click);
            // 
            // middleSizeItem
            // 
            this.middleSizeItem.AutoSize = true;
            this.middleSizeItem.Location = new System.Drawing.Point(12, 82);
            this.middleSizeItem.Name = "middleSizeItem";
            this.middleSizeItem.Size = new System.Drawing.Size(49, 17);
            this.middleSizeItem.TabIndex = 3;
            this.middleSizeItem.TabStop = true;
            this.middleSizeItem.Text = "720p";
            this.middleSizeItem.UseVisualStyleBackColor = true;
            // 
            // lowSizeItem
            // 
            this.lowSizeItem.AutoSize = true;
            this.lowSizeItem.Location = new System.Drawing.Point(12, 105);
            this.lowSizeItem.Name = "lowSizeItem";
            this.lowSizeItem.Size = new System.Drawing.Size(49, 17);
            this.lowSizeItem.TabIndex = 4;
            this.lowSizeItem.TabStop = true;
            this.lowSizeItem.Text = "486p";
            this.lowSizeItem.UseVisualStyleBackColor = true;
            // 
            // veryLowSizeItem
            // 
            this.veryLowSizeItem.AutoSize = true;
            this.veryLowSizeItem.Location = new System.Drawing.Point(12, 128);
            this.veryLowSizeItem.Name = "veryLowSizeItem";
            this.veryLowSizeItem.Size = new System.Drawing.Size(49, 17);
            this.veryLowSizeItem.TabIndex = 5;
            this.veryLowSizeItem.TabStop = true;
            this.veryLowSizeItem.Text = "360p";
            this.veryLowSizeItem.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.veryVeryLowSizeItem);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.saveImgBtn);
            this.panel1.Controls.Add(this.veryLowSizeItem);
            this.panel1.Controls.Add(this.middleSizeItem);
            this.panel1.Controls.Add(this.lowSizeItem);
            this.panel1.Location = new System.Drawing.Point(741, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 403);
            this.panel1.TabIndex = 6;
            // 
            // veryVeryLowSizeItem
            // 
            this.veryVeryLowSizeItem.AutoSize = true;
            this.veryVeryLowSizeItem.Location = new System.Drawing.Point(12, 151);
            this.veryVeryLowSizeItem.Name = "veryVeryLowSizeItem";
            this.veryVeryLowSizeItem.Size = new System.Drawing.Size(49, 17);
            this.veryVeryLowSizeItem.TabIndex = 9;
            this.veryVeryLowSizeItem.TabStop = true;
            this.veryVeryLowSizeItem.Text = "180p";
            this.veryVeryLowSizeItem.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.currentDeviceCombo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 73);
            this.panel2.TabIndex = 8;
            // 
            // currentDeviceCombo
            // 
            this.currentDeviceCombo.FormattingEnabled = true;
            this.currentDeviceCombo.Location = new System.Drawing.Point(64, 45);
            this.currentDeviceCombo.Name = "currentDeviceCombo";
            this.currentDeviceCombo.Size = new System.Drawing.Size(285, 21);
            this.currentDeviceCombo.TabIndex = 6;
            this.currentDeviceCombo.SelectedValueChanged += new System.EventHandler(this.currentDeviceCombo_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Пристрій:";
            // 
            // videoCaptureBox
            // 
            this.videoCaptureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.videoCaptureBox.Location = new System.Drawing.Point(12, 15);
            this.videoCaptureBox.Name = "videoCaptureBox";
            this.videoCaptureBox.Size = new System.Drawing.Size(723, 400);
            this.videoCaptureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.videoCaptureBox.TabIndex = 7;
            this.videoCaptureBox.TabStop = false;
            this.videoCaptureBox.Click += new System.EventHandler(this.videoCaptureBox_Click_1);
            // 
            // MadeImageFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 427);
            this.Controls.Add(this.videoCaptureBox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MadeImageFm";
            this.ShowIcon = false;
            this.Text = "Інструменти";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MadeImageFm_FormClosed);
            this.Load += new System.EventHandler(this.MadeImageFm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoCaptureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveImgBtn;
        private System.Windows.Forms.RadioButton middleSizeItem;
        private System.Windows.Forms.RadioButton lowSizeItem;
        private System.Windows.Forms.RadioButton veryLowSizeItem;
        private System.Windows.Forms.Panel panel1;
        private Emgu.CV.UI.PanAndZoomPictureBox videoCaptureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox currentDeviceCombo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton veryVeryLowSizeItem;
    }
}