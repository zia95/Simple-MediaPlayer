using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AudioPlayer
{
    public partial class MainForm : Form
    {
        private MediaPlayerHelper.MediaPlayer Player = null;


        private double GetPosition(int scroll_val, double media_dur)
        {
            return ((((double)scroll_val) * media_dur) / 100.00d);
        }
        private int GetTrackingBarPosition(double pos, double media_dur)
        {
            return (int)(((pos * 100) / media_dur));
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Player = new MediaPlayerHelper.MediaPlayer();
            this.trackBarVolume.Value = this.Player.MediaControl.Volume;
            this.lbVolume.Text = this.trackBarVolume.Value.ToString();
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            this.Player.MediaControl.PlayList.Clear();

            if (this.ofdMedia.ShowDialog() == DialogResult.OK)
            {
                string file = this.ofdMedia.FileName;
                if(file != null && System.IO.File.Exists(file))
                {
                    this.Player.MediaControl.PlayList.Add(file);
                }
                else
                {
                    MessageBox.Show("Media File is not found!!", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btPlay_Click(object sender, EventArgs e)
        {
            this.Player.MediaControl.Play();
        }
        private void btPause_Click(object sender, EventArgs e)
        {
            this.Player.MediaControl.Pause();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            this.Player.MediaControl.Stop();
        }

        private void btMute_Click(object sender, EventArgs e)
        {
            this.Player.MediaControl.Mute = !this.Player.MediaControl.Mute;
        }

        private void tmrUpdateTimer_Tick(object sender, EventArgs e)
        {
            var state = this.Player.MediaControl.PlayState;
            var current_media = this.Player.MediaControl.PlayList.CurrentlyPlayingItem;

            if (current_media != null && state == MediaPlayerHelper.State.Playing)
            {
                this.trackbarPosition.Value = this.GetTrackingBarPosition(this.Player.MediaControl.Position, current_media.MediaInfo.Duration);

                this.lbPosDur.Text = this.Player.MediaControl.PositionAsString + "/" + current_media.MediaInfo.DurationAsString;


            }
        }

        private void trackbarPosition_Scroll(object sender, EventArgs e)
        {
            var current_media = this.Player.MediaControl.PlayList.CurrentlyPlayingItem;
            var state = this.Player.MediaControl.PlayState;
            if (current_media != null && state == MediaPlayerHelper.State.Playing || state == MediaPlayerHelper.State.Paused)
            {
                this.Player.MediaControl.Position = this.GetPosition(this.trackbarPosition.Value, current_media.MediaInfo.Duration);
            }
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            this.Player.MediaControl.Volume = this.trackBarVolume.Value;
            this.lbVolume.Text = this.trackBarVolume.Value.ToString();
        }

        
    }
}
