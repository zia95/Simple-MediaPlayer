using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MediaPlayerHelper
{
    internal class MediaPlayList : List<mpInterface.IMediaItem>, mpInterface.IMediaPlayList
    {
        #region EVENTS
        public event PlayStateChangedEventHandler PlayStateChanged = null;
        #endregion


        private mpInterface.IMediaItem last_current_media = null;
        public mpInterface.IMediaItem CurrentlyPlayingItem
        { 
            get
            {
                var c_item = this.PlayerControl.Player != null ? this.PlayerControl.Player.Ctlcontrols.currentItem : this.PlayerControl.Player2.controls.currentItem;


                //----direct---return---//
                if (this.last_current_media != null && ((MediaItem)this.last_current_media).wmpMedia.sourceURL == c_item.sourceURL)
                    return this.last_current_media;

                //----long---way-----//
                int count = this.playlist.count;
                for (int i = 0; i < count; i++)
                {
                    if (c_item.sourceURL == this.playlist.Item[i].sourceURL)
                    {
                        this.last_current_media = this[i];
                        return this.last_current_media;
                    }
                }
                return null;
            }
        }


        private readonly MediaPlayerControl PlayerControl = null;
        private WMPLib.IWMPPlaylist playlist
        {
            get
            {
                if (this.PlayerControl.Player != null)
                {
                    return this.PlayerControl.Player.currentPlaylist;
                }
                else
                {
                    return this.PlayerControl.Player2.currentPlaylist;
                }
            }
        }
        public MediaPlayList(MediaPlayerControl plyr) : base()
        {
            if (plyr == null)
                throw new ArgumentNullException("win media player cannot be null");
            
            this.PlayerControl = plyr;

            if(this.PlayerControl.Player != null)
            {
                this.PlayerControl.Player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            }
            else
            {
                this.PlayerControl.Player2.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player2_PlayStateChange);
            }
            
        }

        private void Player2_PlayStateChange(int NewState)
        {
            this.PlayStateChanged?.Invoke(this, new PlayStateChangedEventArg(this.PlayerControl.PlayState));
        }
        private void Player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            this.PlayStateChanged?.Invoke(this, new PlayStateChangedEventArg(this.PlayerControl.PlayState));
        }

        #region Basic Control - Play, Stop , Pause
        public void Play()
        {
            if(this.PlayerControl.Player != null)
            {
                this.PlayerControl.Player.Ctlcontrols.play();
            }
            else
            {
                this.PlayerControl.Player2.controls.play();
            }
        }
        public void PlayItem(int index)
        {
            if (index < 0 || index >= this.Count)
                throw new IndexOutOfRangeException("cannot play index is out of range");

            if (this.PlayerControl.Player != null)
            {
                this.PlayerControl.Player.Ctlcontrols.playItem(this.playlist.Item[index]);
            }
            else
            {
                this.PlayerControl.Player2.controls.playItem(this.playlist.Item[index]);
            }
        }
        public void PlayItem(mpInterface.IMediaItem media_item)
        {
            if (media_item == null)
                throw new ArgumentNullException("cannot play media item is null");

            if (this.Contains(media_item) == false)
                throw new ArgumentException("media items does not exist.");

            this.PlayItem(this.IndexOf(media_item));
        }
        public void Stop()
        {
            if (this.PlayerControl.Player != null)
            {
                this.PlayerControl.Player.Ctlcontrols.stop();
            }
            else
            {
                this.PlayerControl.Player2.controls.stop();
            }
            
        }
        public void Pause()
        {
            if (this.PlayerControl.Player != null)
            {
                this.PlayerControl.Player.Ctlcontrols.pause();
            }
            else
            {
                this.PlayerControl.Player2.controls.pause();
            }
        }
        public void Next()
        {
            if (this.PlayerControl.Player != null)
            {
                this.PlayerControl.Player.Ctlcontrols.next();
            }
            else
            {
                this.PlayerControl.Player2.controls.next();
            }
        }
        public void Previous()
        {
            if (this.PlayerControl.Player != null)
            {
                this.PlayerControl.Player.Ctlcontrols.previous();
            }
            else
            {
                this.PlayerControl.Player2.controls.previous();
            }
        }
        #endregion
        public mpInterface.IMediaItem GetMediaItem(string media_path)
        {
            if (media_path == null)
                throw new ArgumentNullException("media path null.");

            if (!System.IO.File.Exists(media_path))
                throw new ArgumentException("media file not found.");

            WMPLib.IWMPMedia media = this.PlayerControl.Player != null ? this.PlayerControl.Player.newMedia(media_path) : this.PlayerControl.Player2.newMedia(media_path);
            
            return new MediaItem(media, this);
        }
        public void Add(string media_path)
        {
            if (media_path == null)
                throw new ArgumentNullException("media path null.");

            if (!System.IO.File.Exists(media_path))
                throw new ArgumentException("media file not found.");

            this.Add(this.GetMediaItem(media_path));
        }
        
        #region List---Interface---Implementation
        public new void Add(mpInterface.IMediaItem mediaitem)
        {
            if (mediaitem == null)
                throw new ArgumentNullException("media item null");

            if (!mediaitem.IsValid)
                throw new ArgumentException("media items is not valid");
            
            this.playlist.appendItem(((MediaItem)mediaitem).wmpMedia);
            base.Add(mediaitem);
        }
        public void AddRange(mpInterface.IMediaItem[] mediaitems)
        {
            if (mediaitems == null)
                throw new ArgumentNullException("media item null");

            foreach (var m in mediaitems)
                this.Add(m);
        }
        public new void AddRange(IEnumerable<mpInterface.IMediaItem> mediaitems)
        {
            if (mediaitems == null)
                throw new ArgumentNullException("media item null");

            this.AddRange(mediaitems.ToArray());
        }
        public new void RemoveAt(int index)
        {
            if(index >= 0 && index < this.Count)
            {
                base.RemoveAt(index);
                this.playlist.removeItem(this.playlist.Item[index]);
            }
            else
            {
                throw new IndexOutOfRangeException(string.Format("index:{0} is out of range, try checking count before remoing...", index));
            }
        }
        public new bool Remove(mpInterface.IMediaItem item)
        {
            if (item == null)
                throw new ArgumentNullException("media item null");

            if(this.Contains(item))
            {
                this.RemoveAt(this.IndexOf(item));
                return true;
            }
            else
            {
                return false;
                //throw new ArgumentException(string.Format("media item:{0} does not exist.", item.Source));
            }
        }
        public new void Insert(int index, mpInterface.IMediaItem mediaitem)
        {
            if (mediaitem == null)
                throw new ArgumentNullException("media item null");

            if (mediaitem.IsValid)
                throw new ArgumentException("media items is not valid");

            if (index < 0 || index >= this.Count)
                throw new IndexOutOfRangeException("cannot insert index is out of range");
            
            this.playlist.insertItem(index, ((MediaItem)mediaitem).wmpMedia);
            base.Insert(index,mediaitem);
        }
        public new void Clear()
        {
            base.Clear();
            this.playlist.clear();
        }

        #region NOT Supported Methods
        [Obsolete("not supported", true)]
        public new void InsertRange(int index, IEnumerable<mpInterface.IMediaItem> mediaitems) { }

        [Obsolete("not supported", true)]
        public new void Reverse() { }
        [Obsolete("not supported", true)]
        public new void TrimExcess() { }
        [Obsolete("not supported", true)]
        public new void Sort() { }
        [Obsolete("not supported", true)]
        public new void Sort(IComparer<mpInterface.IMediaItem> comparer) { }
        [Obsolete("not supported", true)]
        public new void Sort(int index, int count, IComparer<mpInterface.IMediaItem> comparer) { }
        [Obsolete("not supported", true)]
        public new void Sort(Comparison<mpInterface.IMediaItem> comparison) { }
        [Obsolete("not supported", true)]
        public new void RemoveRange(int index, int count) { }

        [Obsolete("not supported", true)]
        public new int RemoveAll(Predicate<mpInterface.IMediaItem> match) { return 0; }
        #endregion
        #endregion
    }
}
