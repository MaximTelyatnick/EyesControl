namespace ViolaJonesTest
{
    partial class SettingsFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsFm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.settingsMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.photoBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.resumeBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.settingsOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cameraCheck = new System.Windows.Forms.RadioButton();
            this.fileCheck = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.settingsMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 329);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(490, 329);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // settingsMenu
            // 
            this.settingsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu});
            this.settingsMenu.Location = new System.Drawing.Point(0, 0);
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Size = new System.Drawing.Size(1103, 24);
            this.settingsMenu.TabIndex = 1;
            this.settingsMenu.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(48, 20);
            this.fileMenu.Text = "Файл";
            // 
            // loadMenuItem
            // 
            this.loadMenuItem.Name = "loadMenuItem";
            this.loadMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadMenuItem.Text = "Завантажити";
            this.loadMenuItem.Click += new System.EventHandler(this.loadMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.photoBtn);
            this.panel2.Controls.Add(this.stopBtn);
            this.panel2.Controls.Add(this.resumeBtn);
            this.panel2.Controls.Add(this.playBtn);
            this.panel2.Location = new System.Drawing.Point(0, 410);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 28);
            this.panel2.TabIndex = 2;
            // 
            // photoBtn
            // 
            this.photoBtn.Location = new System.Drawing.Point(3, 3);
            this.photoBtn.Name = "photoBtn";
            this.photoBtn.Size = new System.Drawing.Size(75, 23);
            this.photoBtn.TabIndex = 3;
            this.photoBtn.Text = "фото";
            this.photoBtn.UseVisualStyleBackColor = true;
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(118, 3);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 2;
            this.stopBtn.Text = "Стоп";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // resumeBtn
            // 
            this.resumeBtn.Location = new System.Drawing.Point(280, 3);
            this.resumeBtn.Name = "resumeBtn";
            this.resumeBtn.Size = new System.Drawing.Size(75, 23);
            this.resumeBtn.TabIndex = 1;
            this.resumeBtn.Text = "Пауза";
            this.resumeBtn.UseVisualStyleBackColor = true;
            this.resumeBtn.Click += new System.EventHandler(this.resumeBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(199, 3);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(75, 23);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "Играть";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(0, 362);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(490, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // settingsOpenFileDialog
            // 
            this.settingsOpenFileDialog.FileName = "openFileDialog1";
            // 
            // cameraCheck
            // 
            this.cameraCheck.AutoSize = true;
            this.cameraCheck.Location = new System.Drawing.Point(3, 3);
            this.cameraCheck.Name = "cameraCheck";
            this.cameraCheck.Size = new System.Drawing.Size(63, 17);
            this.cameraCheck.TabIndex = 4;
            this.cameraCheck.TabStop = true;
            this.cameraCheck.Text = "камера";
            this.cameraCheck.UseVisualStyleBackColor = true;
            // 
            // fileCheck
            // 
            this.fileCheck.AutoSize = true;
            this.fileCheck.Location = new System.Drawing.Point(3, 26);
            this.fileCheck.Name = "fileCheck";
            this.fileCheck.Size = new System.Drawing.Size(51, 17);
            this.fileCheck.TabIndex = 5;
            this.fileCheck.TabStop = true;
            this.fileCheck.Text = "файл";
            this.fileCheck.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cameraCheck);
            this.panel3.Controls.Add(this.fileCheck);
            this.panel3.Location = new System.Drawing.Point(496, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(73, 58);
            this.panel3.TabIndex = 6;
            // 
            // SettingsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 575);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.settingsMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.settingsMenu;
            this.Name = "SettingsFm";
            this.Text = "Налаштування";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.settingsMenu.ResumeLayout(false);
            this.settingsMenu.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip settingsMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem loadMenuItem;
        private System.Windows.Forms.Button photoBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button resumeBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.OpenFileDialog settingsOpenFileDialog;
        private System.Windows.Forms.RadioButton cameraCheck;
        private System.Windows.Forms.RadioButton fileCheck;
        private System.Windows.Forms.Panel panel3;
    }
}