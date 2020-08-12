using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaPlayer.MediaPlayerUI
{
    public partial class Player : UserControl
    {
        public static readonly string[] AudioExtensions = { ".mp3", ".m4a", ".wav", ".mpg", ".mpeg", ".m1v", ".mp2", ".mp3", ".mpa", ".mpe", ".m3u", ".aac", ".adt", ".adts" };
        public static readonly string[] VideoExtensions = { ".mp4", ".avi", ".flv", ".mov", ".m4v", ".mp4v", ".3g2", ".3gp2", ".3gp", ".3gpp", ".m2ts" };

        public enum MediaPlayerUIMode
        {
            Full,
            Mini,
        };
        private Size last_player_size = Size.Empty;
        private FormBorderStyle last_player_form_style = 0;
        public bool SetUIMode(MediaPlayerUIMode mode, Form player_form)
        {
            if(mode == MediaPlayerUIMode.Full && this.mPlayer.Visible == false)
            {
                this.mPlayer.Visible = true;
                if (this.ShowAudioModeUI && this.pbAudioDisplay.Visible == false && this.pbAudioDisplay.Enabled == true)
                    this.pbAudioDisplay.Visible = true;

                player_form.Size = last_player_size;
                player_form.FormBorderStyle = this.last_player_form_style;

                return true;
            }
            else if(mode == MediaPlayerUIMode.Mini && this.mPlayer.Visible == true)
            {
                this.mPlayer.Visible = false;
                if (this.ShowAudioModeUI && this.pbAudioDisplay.Visible)
                    this.pbAudioDisplay.Visible = false;

                if (player_form.WindowState == FormWindowState.Maximized)
                    player_form.WindowState = FormWindowState.Normal;

                this.last_player_size = player_form.Size;
                player_form.Size = new Size(player_form.Size.Width, (player_form.Size.Height - this.mPlayer.Height));

                this.last_player_form_style = player_form.FormBorderStyle;
                player_form.FormBorderStyle = FormBorderStyle.Fixed3D;

                return true;
            }
            return false;
        }

        #region MyGlobals
        private MediaPlayerHelper.State myState { get; set; }
        #endregion
        
        private readonly MediaPlayerHelper.MediaPlayer mPlayerHelper = null;
        
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public MediaPlayerHelper.mpInterface.IMediaPlayerControl Settings { get { return this.mPlayerHelper.MediaControl; } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public MediaPlayerHelper.mpInterface.IMediaPlayList PlayList { get { return this.mPlayerHelper.MediaControl.PlayList; } }
        public AxWMPLib.AxWindowsMediaPlayer wmPlayer { get { return this.mPlayer; } }


        #region UI
        public bool ShowToolTips { get; set; }
        public bool ShowAudioModeUI { get; set; }
        public Color MediaControlBackColor { get { return this.pnlMediaControl.BackColor; } set { this.pnlMediaControl.BackColor = value; } }
        public Color MediaControlForeColor { get { return this.pnlMediaControl.ForeColor; } set { this.pnlMediaControl.ForeColor = value; } }

        public Color MediaPositionTrackingBarBorderColor { get { return this.tbMediaTracking.BackColor; } set { this.tbMediaTracking.BackColor = value; } }
        public Color VolumeTrackingBarBorderColor { get { return this.tbVolumeTrackBar.BackColor; } set { this.tbVolumeTrackBar.BackColor = value; } }
        #endregion

        public Player()
        {
            InitializeComponent();
            this.mPlayerHelper = new MediaPlayerHelper.MediaPlayer(this.wmPlayer);
        }

        private void SetupUI()
        {
            this.pnlPlayer.Dock = DockStyle.Fill;

            this.mPlayer.Location = new Point(0, 0);
            this.mPlayer.Size = new Size(this.pnlPlayer.Size.Width, (this.pnlPlayer.Size.Height - this.pnlMediaControl.Size.Height));

            this.tbMediaTracking.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.lbMediaTracking.Anchor = AnchorStyles.Right | AnchorStyles.Top;

            this.btMute.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.tbVolumeTrackBar.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.lbVolume.Anchor = AnchorStyles.Right | AnchorStyles.Top;


            this.pnlMediaControl.Location = new Point(0, this.mPlayer.Size.Height);
            this.pnlMediaControl.Size = new Size(this.pnlPlayer.Size.Width, this.pnlMediaControl.Size.Height);

            this.mPlayer.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.pnlMediaControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            this.pnlPlayer.BackColor = Color.Transparent;
            this.BackColor = Color.Transparent;
        }
        private void SetToolTips()
        {
            this.tooltipsMain.SetToolTip(this.btPlayPause, "Pause or Pause");
            this.tooltipsMain.SetToolTip(this.btStop, "Stop");
            this.tooltipsMain.SetToolTip(this.btPrevious, "Previous");
            this.tooltipsMain.SetToolTip(this.btNext, "Next");
            this.tooltipsMain.SetToolTip(this.btMute, "Mute");

            this.tooltipsMain.SetToolTip(this.tbMediaTracking, "Media Position");
            this.tooltipsMain.SetToolTip(this.tbVolumeTrackBar, "Volume");
        }

        private void MediaPlayer_Load(object sender, EventArgs e)
        {
            this.SetupUI();

            if (this.ShowToolTips)
                this.SetToolTips();

            this.tmrUpdateTimer.Enabled = true;

            this.tbVolumeTrackBar.Value = this.Settings.Volume;

            this.mPlayerHelper.MediaControl.PlayList.PlayStateChanged += new MediaPlayerHelper.PlayStateChangedEventHandler(PlayList_PlayStateChanged);
        }

        private void PlayList_PlayStateChanged(object sender, MediaPlayerHelper.PlayStateChangedEventArg e)
        {
            var curr_media = this.PlayList.CurrentlyPlayingItem;
            if (curr_media != null)
            {
                if(curr_media.MediaType == MediaPlayerHelper.MediaType.Audio && this.ShowAudioModeUI)
                {
                    this.pbAudioDisplay.Enabled = true;
                    this.pbAudioDisplay.Visible = true;
                    this.pbAudioDisplay.Invalidate();
                }
                else
                {
                    this.pbAudioDisplay.Enabled = false;
                    this.pbAudioDisplay.Visible = false;
                }
            }
        }

        //-----------Timer------------//

        private void tmrUpdateTimer_Tick(object sender, EventArgs e)
        {
            this.myState = this.Settings.PlayState;

            #region Player Update 
            this.lbVolume.Text = this.Settings.Volume.ToString();

            if (this.myState == MediaPlayerHelper.State.Playing)
            {
                if(this.tbMediaTracking.Enabled == false)
                    this.tbMediaTracking.Enabled = true;

                var current_media = this.Settings.PlayList.CurrentlyPlayingItem;
                
                double position = this.Settings.Position;
                double duration = current_media == null ? 0 : current_media.MediaInfo.Duration;
                
                if (position >= 0 && duration > 0 && position <= duration)
                {
                    this.tbMediaTracking.Value = this.GetTrackingBarPosition(position, duration);
                    this.lbMediaTracking.Text = this.Settings.PositionAsString + "/" + this.Settings.PlayList.CurrentlyPlayingItem.MediaInfo.DurationAsString;
                }
            }
            else
            {
                if(this.myState != MediaPlayerHelper.State.Paused)
                {
                    if (this.tbMediaTracking.Enabled == true)
                        this.tbMediaTracking.Enabled = false;

                    this.tbMediaTracking.Value = 0;
                    this.lbMediaTracking.Text = "00:00/00:00";
                }
            }
            #endregion

            //if(this.pbAudioDisplay.Enabled && this.pbAudioDisplay.Visible)
            //    this.pbAudioDisplay.Invalidate();
        }
        private void pbAudioDisplay_Paint(object sender, PaintEventArgs e)
        {
            //------Audio-----Mode--------Display-------
            var draw = e.Graphics;

            if (this.pbAudioDisplay.Location != this.mPlayer.Location)
                this.pbAudioDisplay.Location = this.mPlayer.Location;

            if (this.pbAudioDisplay.Size != this.mPlayer.Size)
                this.pbAudioDisplay.Size = this.mPlayer.Size;

            if (this.pbAudioDisplay.Anchor != this.mPlayer.Anchor)
                this.pbAudioDisplay.Anchor = this.mPlayer.Anchor;

            draw.Clear(Color.Black);
            draw.DrawString("[AUDIO MODE]", this.Font, Brushes.Blue, new PointF(0, 0));
        }

        //-----------Buttons------------//

        private void btPlayPause_Click(object sender, EventArgs e)
        {
            if (this.myState != MediaPlayerHelper.State.Playing )
            {
                this.Settings.Play();
            }
            else
            {
                this.Settings.Pause();
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            this.Settings.Stop();
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            this.Settings.Previous();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            this.Settings.Next();
        }

        private void btMute_Click(object sender, EventArgs e)
        {
            this.Settings.Mute = !this.Settings.Mute;
        }

        //-----------Scroll------------//
        private void tbVolumeTrackBar_TrackBarScroll(object sender, EventArgs e)
        {
            this.Settings.Volume = this.tbVolumeTrackBar.Value;
        }
        private void tbMediaTracking_TrackBarScroll(object sender, EventArgs e)
        {
            this.Settings.Position = this.GetPosition(this.tbMediaTracking.Value, this.Settings.PlayList.CurrentlyPlayingItem.MediaInfo.Duration);
        }










        private double GetPosition(int scroll_val, double media_dur)
        {
            return ((((double)scroll_val) * media_dur) / 100.00d);
        }
        private int GetTrackingBarPosition(double pos, double media_dur)
        {
            return (int)(((pos * 100) / media_dur));
        }

        
    }
}
