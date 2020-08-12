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
    public partial class MediaPlayList : Form
    {
        private struct MediaListInfo
        {
            public string TrackNumber;
            public string Title;
            public string Duration;
            public string Artist;
            public string Album;
            public string Composer;

            public MediaListInfo(MediaPlayerHelper.mpInterface.IMediaItem media)
            {
                this.TrackNumber = "-";
                this.Title = "-";
                this.Duration = "-";
                this.Artist = "-";
                this.Album = "-";
                this.Composer = "-";

                if(media != null && media.IsValid)
                {
                    var mediainfo = media.MediaInfo;
                    if(mediainfo != null)
                    {
                        var dur = mediainfo.DurationAsString;
                        var attributes = media.MediaInfo.GetAllAttributes();
                        foreach (var attribute in attributes)
                        {
                            switch (attribute.AttributeType)
                            {
                                case MediaPlayerHelper.MediaTag.WM_TrackNumber:
                                    this.TrackNumber = attribute.AttributeValue;
                                    break;
                                case MediaPlayerHelper.MediaTag.Title:
                                    this.Title = attribute.AttributeValue;
                                    break;
                                case MediaPlayerHelper.MediaTag.Author:
                                    this.Artist = attribute.AttributeValue;
                                    break;
                                case MediaPlayerHelper.MediaTag.WM_AlbumTitle:
                                    this.Album = attribute.AttributeValue;
                                    break;
                                case MediaPlayerHelper.MediaTag.WM_Composer:
                                    this.Composer = attribute.AttributeValue;
                                    break;

                            }
                        }
                        this.Duration = dur != null ? dur : this.Duration;
                    }
                }

                if (media.IsValid == false)
                    this.Title = "<Media Not Found>";
            }
        }
        private readonly MediaPlayerUI.Player mPlayer = null;
        private MediaPlayerHelper.mpInterface.IMediaPlayList mPlayList { get { return this.mPlayer.PlayList; } }
        private readonly MainForm MainPlayerForm = null;
        private void UpdateMediaItemsColor()
        {
            foreach(ListViewItem item in this.lstPlayList.Items)
            {
                var media = item.Tag as MediaPlayerHelper.mpInterface.IMediaItem;
                if(media != null)
                {
                    item.BackColor = (media == this.mPlayList.CurrentlyPlayingItem) ? Color.LightBlue : Color.White;
                }
            }
        }
        private void AddToList(MediaPlayerHelper.mpInterface.IMediaItem media)
        {
            MediaListInfo info = new MediaListInfo(media);
            
            var item = this.lstPlayList.Items.Add(info.TrackNumber);

            string[] row = { info.Title, info.Duration, info.Artist, info.Album, info.Composer };

            item.SubItems.AddRange(row);

            item.BackColor = (media == this.mPlayList.CurrentlyPlayingItem) ? Color.AliceBlue : Color.White;

            item.Tag = media;
        }
        private MediaPlayerHelper.mpInterface.IMediaItem GetListSelectedMedia()
        {
            var selected_items = this.lstPlayList.SelectedItems;
            if (selected_items?.Count > 0)
            {
                var selected_item = selected_items[0];
                if (selected_item != null)
                {
                    return selected_item.Tag as MediaPlayerHelper.mpInterface.IMediaItem;
                }
            }
            return null;
        }
        public MediaPlayList(MediaPlayerUI.Player player, MainForm mf)
        {
            InitializeComponent();
            if (player != null && mf != null)
            {
                this.mPlayer = player;
                //this.mPlayList = play_list;
                this.MainPlayerForm = mf;
            }
            else
                throw new ArgumentNullException("PlayList args NULL");
        }

        private void MediaPlayList_Load(object sender, EventArgs e)
        {
            this.mPlayList.PlayStateChanged += new MediaPlayerHelper.PlayStateChangedEventHandler(MPlayList_PlayStateChanged);
        }

        private void MPlayList_PlayStateChanged(object sender, MediaPlayerHelper.PlayStateChangedEventArg e)
        {
            this.UpdateMediaItemsColor();
        }
        private void tmrUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (this.mPlayList.Count != this.lstPlayList.Items.Count)
            {
                this.lstPlayList.Items.Clear();

                foreach(var media in this.mPlayList)
                    this.AddToList(media);

                this.Text = "Media Play List (Count:" + this.lstPlayList.Items.Count + ")";
            }
        }

        private void lstPlayList_DoubleClick(object sender, EventArgs e)
        {
            var media = this.GetListSelectedMedia();
            if (media != null && media.IsValid)
            {
                this.mPlayList.PlayItem(media);
                this.UpdateMediaItemsColor();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btRemove_Click(object sender, EventArgs e)
        {
            var selected_media = this.GetListSelectedMedia();
            if(selected_media != null)
                this.mPlayList.Remove(selected_media);
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            if(this.mPlayList.Count > 0)
                this.mPlayList.Clear();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            this.MainPlayerForm.AddMedia();
        }

        private void btLoadPlayList_Click(object sender, EventArgs e)
        {
            this.MainPlayerForm.LoadPlayList();
        }
    }
    
}
