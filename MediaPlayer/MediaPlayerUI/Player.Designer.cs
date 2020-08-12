namespace MediaPlayer.MediaPlayerUI
{
    partial class Player
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Player));
            this.pnlMediaControl = new System.Windows.Forms.Panel();
            this.lbVolume = new System.Windows.Forms.Label();
            this.lbMediaTracking = new System.Windows.Forms.Label();
            this.btMute = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.btPrevious = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btPlayPause = new System.Windows.Forms.Button();
            this.pnlPlayer = new System.Windows.Forms.Panel();
            this.pbAudioDisplay = new System.Windows.Forms.PictureBox();
            this.mPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.tmrUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.tooltipsMain = new System.Windows.Forms.ToolTip(this.components);
            this.tbVolumeTrackBar = new MediaPlayer.MediaPlayerUI.TrackingBar();
            this.tbMediaTracking = new MediaPlayer.MediaPlayerUI.TrackingBar();
            this.pnlMediaControl.SuspendLayout();
            this.pnlPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAudioDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMediaControl
            // 
            this.pnlMediaControl.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMediaControl.Controls.Add(this.lbVolume);
            this.pnlMediaControl.Controls.Add(this.lbMediaTracking);
            this.pnlMediaControl.Controls.Add(this.tbVolumeTrackBar);
            this.pnlMediaControl.Controls.Add(this.tbMediaTracking);
            this.pnlMediaControl.Controls.Add(this.btMute);
            this.pnlMediaControl.Controls.Add(this.btNext);
            this.pnlMediaControl.Controls.Add(this.btPrevious);
            this.pnlMediaControl.Controls.Add(this.btStop);
            this.pnlMediaControl.Controls.Add(this.btPlayPause);
            this.pnlMediaControl.Location = new System.Drawing.Point(0, 120);
            this.pnlMediaControl.Name = "pnlMediaControl";
            this.pnlMediaControl.Size = new System.Drawing.Size(230, 45);
            this.pnlMediaControl.TabIndex = 5;
            // 
            // lbVolume
            // 
            this.lbVolume.AutoSize = true;
            this.lbVolume.Location = new System.Drawing.Point(200, 25);
            this.lbVolume.Name = "lbVolume";
            this.lbVolume.Size = new System.Drawing.Size(25, 13);
            this.lbVolume.TabIndex = 7;
            this.lbVolume.Text = "000";
            // 
            // lbMediaTracking
            // 
            this.lbMediaTracking.AutoSize = true;
            this.lbMediaTracking.Location = new System.Drawing.Point(158, 3);
            this.lbMediaTracking.Name = "lbMediaTracking";
            this.lbMediaTracking.Size = new System.Drawing.Size(66, 13);
            this.lbMediaTracking.TabIndex = 6;
            this.lbMediaTracking.Text = "00:00/00:00";
            // 
            // btMute
            // 
            this.btMute.Location = new System.Drawing.Point(100, 20);
            this.btMute.Name = "btMute";
            this.btMute.Size = new System.Drawing.Size(20, 20);
            this.btMute.TabIndex = 5;
            this.btMute.Text = "M";
            this.btMute.UseVisualStyleBackColor = true;
            this.btMute.Click += new System.EventHandler(this.btMute_Click);
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(62, 20);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(20, 20);
            this.btNext.TabIndex = 4;
            this.btNext.Text = "Nx";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btPrevious
            // 
            this.btPrevious.Location = new System.Drawing.Point(42, 20);
            this.btPrevious.Name = "btPrevious";
            this.btPrevious.Size = new System.Drawing.Size(20, 20);
            this.btPrevious.TabIndex = 4;
            this.btPrevious.Text = "Pr";
            this.btPrevious.UseVisualStyleBackColor = true;
            this.btPrevious.Click += new System.EventHandler(this.btPrevious_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(22, 20);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(20, 20);
            this.btStop.TabIndex = 3;
            this.btStop.Text = "S";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btPlayPause
            // 
            this.btPlayPause.Location = new System.Drawing.Point(2, 20);
            this.btPlayPause.Name = "btPlayPause";
            this.btPlayPause.Size = new System.Drawing.Size(20, 20);
            this.btPlayPause.TabIndex = 2;
            this.btPlayPause.Text = "P";
            this.btPlayPause.UseVisualStyleBackColor = true;
            this.btPlayPause.Click += new System.EventHandler(this.btPlayPause_Click);
            // 
            // pnlPlayer
            // 
            this.pnlPlayer.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pnlPlayer.Controls.Add(this.pbAudioDisplay);
            this.pnlPlayer.Controls.Add(this.pnlMediaControl);
            this.pnlPlayer.Controls.Add(this.mPlayer);
            this.pnlPlayer.Location = new System.Drawing.Point(0, 0);
            this.pnlPlayer.Name = "pnlPlayer";
            this.pnlPlayer.Size = new System.Drawing.Size(240, 165);
            this.pnlPlayer.TabIndex = 6;
            // 
            // pbAudioDisplay
            // 
            this.pbAudioDisplay.Enabled = false;
            this.pbAudioDisplay.Location = new System.Drawing.Point(22, 12);
            this.pbAudioDisplay.Name = "pbAudioDisplay";
            this.pbAudioDisplay.Size = new System.Drawing.Size(84, 40);
            this.pbAudioDisplay.TabIndex = 6;
            this.pbAudioDisplay.TabStop = false;
            this.pbAudioDisplay.Visible = false;
            this.pbAudioDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbAudioDisplay_Paint);
            // 
            // mPlayer
            // 
            this.mPlayer.Enabled = true;
            this.mPlayer.Location = new System.Drawing.Point(0, 0);
            this.mPlayer.Name = "mPlayer";
            this.mPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mPlayer.OcxState")));
            this.mPlayer.Size = new System.Drawing.Size(230, 120);
            this.mPlayer.TabIndex = 5;
            // 
            // tmrUpdateTimer
            // 
            this.tmrUpdateTimer.Tick += new System.EventHandler(this.tmrUpdateTimer_Tick);
            // 
            // tbVolumeTrackBar
            // 
            this.tbVolumeTrackBar.BackColor = System.Drawing.Color.Black;
            this.tbVolumeTrackBar.BorderColor = System.Drawing.Color.Black;
            this.tbVolumeTrackBar.BorderWidth = 2;
            this.tbVolumeTrackBar.LargeChange = 10;
            this.tbVolumeTrackBar.Location = new System.Drawing.Point(125, 26);
            this.tbVolumeTrackBar.Name = "tbVolumeTrackBar";
            this.tbVolumeTrackBar.Size = new System.Drawing.Size(74, 10);
            this.tbVolumeTrackBar.SmallChange = 1;
            this.tbVolumeTrackBar.TabIndex = 4;
            this.tbVolumeTrackBar.Value = 0;
            this.tbVolumeTrackBar.TrackBarScroll += new System.EventHandler(this.tbVolumeTrackBar_TrackBarScroll);
            // 
            // tbMediaTracking
            // 
            this.tbMediaTracking.BackColor = System.Drawing.Color.Black;
            this.tbMediaTracking.BorderColor = System.Drawing.Color.Black;
            this.tbMediaTracking.BorderWidth = 2;
            this.tbMediaTracking.LargeChange = 10;
            this.tbMediaTracking.Location = new System.Drawing.Point(2, 3);
            this.tbMediaTracking.Name = "tbMediaTracking";
            this.tbMediaTracking.Size = new System.Drawing.Size(150, 13);
            this.tbMediaTracking.SmallChange = 2;
            this.tbMediaTracking.TabIndex = 3;
            this.tbMediaTracking.Value = 0;
            this.tbMediaTracking.TrackBarScroll += new System.EventHandler(this.tbMediaTracking_TrackBarScroll);
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pnlPlayer);
            this.Name = "Player";
            this.Size = new System.Drawing.Size(250, 165);
            this.Load += new System.EventHandler(this.MediaPlayer_Load);
            this.pnlMediaControl.ResumeLayout(false);
            this.pnlMediaControl.PerformLayout();
            this.pnlPlayer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAudioDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMediaControl;
        private TrackingBar tbVolumeTrackBar;
        private TrackingBar tbMediaTracking;
        private System.Windows.Forms.Button btMute;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btPrevious;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPlayPause;
        private System.Windows.Forms.Label lbMediaTracking;
        private System.Windows.Forms.Panel pnlPlayer;
        private AxWMPLib.AxWindowsMediaPlayer mPlayer;
        private System.Windows.Forms.Timer tmrUpdateTimer;
        private System.Windows.Forms.PictureBox pbAudioDisplay;
        private System.Windows.Forms.ToolTip tooltipsMain;
        private System.Windows.Forms.Label lbVolume;
    }
}
