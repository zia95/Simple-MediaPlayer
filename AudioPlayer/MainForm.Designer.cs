namespace AudioPlayer
{
    partial class MainForm
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
            this.trackbarPosition = new System.Windows.Forms.TrackBar();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.btPlay = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btOpen = new System.Windows.Forms.Button();
            this.btMute = new System.Windows.Forms.Button();
            this.lbPosDur = new System.Windows.Forms.Label();
            this.lbVolume = new System.Windows.Forms.Label();
            this.ofdMedia = new System.Windows.Forms.OpenFileDialog();
            this.tmrUpdateTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackbarPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // trackbarPosition
            // 
            this.trackbarPosition.AutoSize = false;
            this.trackbarPosition.Location = new System.Drawing.Point(75, 0);
            this.trackbarPosition.Maximum = 100;
            this.trackbarPosition.Name = "trackbarPosition";
            this.trackbarPosition.Size = new System.Drawing.Size(341, 40);
            this.trackbarPosition.TabIndex = 0;
            this.trackbarPosition.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackbarPosition.Scroll += new System.EventHandler(this.trackbarPosition_Scroll);
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.AutoSize = false;
            this.trackBarVolume.Location = new System.Drawing.Point(264, 46);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(152, 20);
            this.trackBarVolume.TabIndex = 1;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // btPlay
            // 
            this.btPlay.Location = new System.Drawing.Point(0, 46);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(60, 20);
            this.btPlay.TabIndex = 2;
            this.btPlay.Text = "Play";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(66, 46);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(60, 20);
            this.btPause.TabIndex = 3;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(132, 46);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(60, 20);
            this.btStop.TabIndex = 4;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(0, 0);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(75, 40);
            this.btOpen.TabIndex = 5;
            this.btOpen.Text = "Open";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // btMute
            // 
            this.btMute.Location = new System.Drawing.Point(198, 46);
            this.btMute.Name = "btMute";
            this.btMute.Size = new System.Drawing.Size(60, 20);
            this.btMute.TabIndex = 6;
            this.btMute.Text = "Mute";
            this.btMute.UseVisualStyleBackColor = true;
            this.btMute.Click += new System.EventHandler(this.btMute_Click);
            // 
            // lbPosDur
            // 
            this.lbPosDur.AutoSize = true;
            this.lbPosDur.Location = new System.Drawing.Point(422, 14);
            this.lbPosDur.Name = "lbPosDur";
            this.lbPosDur.Size = new System.Drawing.Size(66, 13);
            this.lbPosDur.TabIndex = 7;
            this.lbPosDur.Text = "00:00/00:00";
            // 
            // lbVolume
            // 
            this.lbVolume.AutoSize = true;
            this.lbVolume.Location = new System.Drawing.Point(422, 46);
            this.lbVolume.Name = "lbVolume";
            this.lbVolume.Size = new System.Drawing.Size(19, 13);
            this.lbVolume.TabIndex = 8;
            this.lbVolume.Text = "50";
            // 
            // ofdMedia
            // 
            this.ofdMedia.Title = "Select Audio File";
            // 
            // tmrUpdateTimer
            // 
            this.tmrUpdateTimer.Enabled = true;
            this.tmrUpdateTimer.Tick += new System.EventHandler(this.tmrUpdateTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 74);
            this.Controls.Add(this.lbVolume);
            this.Controls.Add(this.lbPosDur);
            this.Controls.Add(this.btMute);
            this.Controls.Add(this.btOpen);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btPlay);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.trackbarPosition);
            this.Name = "MainForm";
            this.Text = "Audio Player";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackbarPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackbarPosition;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Button btMute;
        private System.Windows.Forms.Label lbPosDur;
        private System.Windows.Forms.Label lbVolume;
        private System.Windows.Forms.OpenFileDialog ofdMedia;
        private System.Windows.Forms.Timer tmrUpdateTimer;
    }
}

