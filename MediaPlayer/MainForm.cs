using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class MainForm : Form
    {
        private readonly string AudioFilter = null;
        private readonly string VideoFilter = null;
        private readonly string MediaFilter = null;

        public void AddMedia()
        {
            OpenFileDialog o = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Title = "Add Media(s)",
                Multiselect = true,
                Filter = this.MediaFilter + " | " + this.AudioFilter + " | " + this.VideoFilter,
            };
            if(o.ShowDialog() == DialogResult.OK)
            {
                string[] media_S = o.FileNames;
                int media_loaded = 0;
                if(media_S != null)
                {
                    foreach(string media in media_S)
                    {
                        if(media != null && System.IO.File.Exists(media))
                        {
                            this.mPlayer.PlayList.Add(media);
                            media_loaded++;
                        }
                    }
                }
                //MessageBox.Show("Total Media Loaded: " + media_loaded, "Media loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.SetHighlights("Total Media Loaded: " + media_loaded, Brushes.Green);
            }
            o.Dispose();
            o = null;
        }
        private MediaPlayList media_play_list = null;
        private void ShowPlayList()
        {
            if(this.media_play_list == null || this.media_play_list.IsDisposed)
                this.media_play_list = new MediaPlayList(this.mPlayer, this);

            this.media_play_list.Show(this);
        }
        public void SavePlayList()
        {
            if (this.mPlayer.Settings.PlayList.Count <= 0)
            {
                MessageBox.Show("At least one media should me added to playlist only then it can be saved.", "Add Media First", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog s = new SaveFileDialog()
            {
                CheckFileExists = false,
                CheckPathExists = true,
                Title = "Save PlayList",
                OverwritePrompt = true,
                Filter = "XML Media PlayList | *.xml",
            };
            if(s.ShowDialog() == DialogResult.OK)
            {
                string file = s.FileName;
                if (System.IO.File.Exists(file))
                    System.IO.File.Delete(file);

                this.mPlayer.Settings.SavePlayListToFile(this.mPlayer.Settings.PlayList, file);
                this.SetHighlights($"Playlist {file} saved.", Brushes.Green);
            }
            s.Dispose();
            s = null;
        }
        public void LoadPlayList()
        {
            OpenFileDialog o = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Title = "Load PlayList",
                Multiselect = false,
                Filter = "XML Media PlayList | *.xml",
            };
            if(o.ShowDialog() == DialogResult.OK)
            {
                string playlist_path = o.FileName;
                if(System.IO.File.Exists(playlist_path))
                {
                    var play_list = this.mPlayer.Settings.LoadPlayListFromFile(playlist_path);
                    if(play_list != null && play_list.Count > 0)
                    {
                        this.mPlayer.Settings.LoadPlayList(play_list);
                        //MessageBox.Show("Playlist loaded sucessfully.", "Playlist Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.SetHighlights($"Playlist {playlist_path} loaded.", Brushes.Green);
                    }
                    else
                    {
                        MessageBox.Show("Playlist loaded but the media count is 0, playlist is invalid so its cannot be loaded.", "Invalid Playlist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            o.Dispose();
            o = null;
        }
        private string ArrayToFilter(string[] extensions, string display_txt)
        {
            string buffer = null;
            foreach(var ext in extensions)
            {
                string extension = '*' + ext;
                if (buffer == null)
                    buffer = (extension + "; ");
                else
                    buffer += (extension + "; ");
            }

            return buffer == null ? buffer : display_txt + " | " + buffer;
        }
        public MainForm()
        {
            InitializeComponent();

            this.AudioFilter = this.ArrayToFilter(MediaPlayerUI.Player.AudioExtensions, "All Supported Audio Files");
            this.VideoFilter = this.ArrayToFilter(MediaPlayerUI.Player.VideoExtensions, "All Supported Video Files");

            List<string> media_extension = new List<string>();
            media_extension.AddRange(MediaPlayerUI.Player.AudioExtensions);
            media_extension.AddRange(MediaPlayerUI.Player.VideoExtensions);

            this.MediaFilter = this.ArrayToFilter(media_extension.ToArray(), "All Supported Media Files");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.mPlayer.PlayList.PlayStateChanged += new MediaPlayerHelper.PlayStateChangedEventHandler(PlayList_PlayStateChanged);
        }
        private string GetCurrentMediaTitle()
        {
            var media = this.mPlayer.PlayList.CurrentlyPlayingItem;
            if (media != null && media.IsValid)
            {
                MediaPlayerHelper.mpInterface.IMediaAttribute media_title_att = media.MediaInfo.GetAttribute(MediaPlayerHelper.MediaTag.Title);
                if (media_title_att != null)
                {
                    return media_title_att.AttributeValue;
                }
            }
            return null;
        }
        private void PlayList_PlayStateChanged(object sender, MediaPlayerHelper.PlayStateChangedEventArg e)
        {
            string media_title = this.GetCurrentMediaTitle();
            
            if (e.NewPlayState == MediaPlayerHelper.State.Playing)
            {
                this.SetHighlights($"Now Playing:{media_title}", Brushes.Green);
            }
            else if(e.NewPlayState == MediaPlayerHelper.State.Paused)
            {
                this.SetHighlights($"Paused:{media_title}", Brushes.Yellow);
            }
            else if(e.NewPlayState == MediaPlayerHelper.State.Stopped)
            {
                this.SetHighlights($"Stopped:{media_title}", Brushes.Red);
            }
            else
            {
                this.SetHighlights(null, Brushes.Red);
            }
        }

        #region Context Menu Strip
        private void fileToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.PlayerContextMenuStrip.Close();
            if (e.ClickedItem == this.openMediasToolStripMenuItem)
            {
                this.AddMedia();
            }
            else if (e.ClickedItem == this.savePlayListToolStripMenuItem)
            {
                this.SavePlayList();
            }
            else if (e.ClickedItem == this.loadPlayListToolStripMenuItem)
            {
                this.LoadPlayList();
            }
        }
        private void viewToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.PlayerContextMenuStrip.Close();
            if (e.ClickedItem == this.showPlayListToolStripMenuItem)
            {
                this.ShowPlayList();
            }
            else if (e.ClickedItem == this.setModeFullToolStripMenuItem || e.ClickedItem == this.setModeMiniToolStripMenuItem)
            {
                var myscreen = Screen.PrimaryScreen.WorkingArea;

                if (e.ClickedItem == this.setModeFullToolStripMenuItem)
                {
                    if(this.mPlayer.SetUIMode(MediaPlayerUI.Player.MediaPlayerUIMode.Full, this))
                    {
                        this.SetDesktopLocation(myscreen.Width / 4, myscreen.Height / 4);
                        this.TopMost = false;
                    }
                }
                else if(e.ClickedItem == this.setModeMiniToolStripMenuItem)
                {
                    if(this.mPlayer.SetUIMode(MediaPlayerUI.Player.MediaPlayerUIMode.Mini, this))
                    {
                        this.Size = new Size(300, this.Size.Height);

                        Point myapploc = new Point((myscreen.Width - this.Size.Width), (myscreen.Height - this.Size.Height));

                        this.SetDesktopLocation(myapploc.X, myapploc.Y);

                        this.TopMost = true;
                    }
                }
            }
        }
        private void helpToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.PlayerContextMenuStrip.Close();
            if (e.ClickedItem == this.aboutToolStripMenuItem) new About().ShowDialog();
        }
        #endregion

        #region Bottom Highlights (Timer & PictureBox)
        private void tmrHighlights_Tick(object sender, EventArgs e)
        {
            this.pbHighlights.Invalidate();
        }
        private Image CreateStringImage(string str, Size siz, Font fnt, Brush fc, Color bc)
        {
            Bitmap img = new Bitmap(siz.Width, siz.Height);
            using (var g = Graphics.FromImage(img))
            {
                g.Clear(bc);
                g.DrawString(str, fnt, fc, PointF.Empty);
            }
            return img;
        }
        private void SetHighlights(string hl, Brush clr, float hlspeed = 4.0f) => this.SetHighlights(hl, clr, null, hlspeed);
        private void SetHighlights(string hl, Brush clr, Font fnt, float hlspeed = 4.0f)
        {
            this.highlights = hl;
            this.highlight_clr = clr;
            this.highlight_fnt = fnt;
            this.highlight_speed = hlspeed;
        }
        private string highlights = null;
        private Brush highlight_clr = Brushes.Red;
        private Font highlight_fnt = null;
        private float highlight_speed = 4.0f;

        private float highlight_pos = -1000;
        private void pbHighlights_Paint(object sender, PaintEventArgs e)
        {
            if (this.highlights == null)
                this.highlights = "Media Player";

            if (this.highlight_fnt == null)
                this.highlight_fnt = this.Font;

            if (this.highlight_speed < 0)
                this.highlight_speed = 4.0f;

            e.Graphics.Clear(Color.Black);

            var str_size = e.Graphics.MeasureString(this.highlights, this.highlight_fnt);
            
            float leftside_max = -(str_size.Width);
            float rightside_max = this.pbHighlights.Size.Width;

            this.highlight_pos = this.highlight_pos <= leftside_max ? rightside_max : (this.highlight_pos - this.highlight_speed);

            PointF hl_pos = new PointF(this.highlight_pos, 2f);
            
            e.Graphics.DrawString(this.highlights, this.highlight_fnt, this.highlight_clr, hl_pos);
        }


        #endregion

        
    }
}
