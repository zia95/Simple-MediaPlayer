using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerHelper
{
    internal class MediaItem : mpInterface.IMediaItem
    {
        private static readonly string[] AudioExtensions = { ".mp3", ".m4a", ".wav", ".mpg", ".mpeg", ".m1v", ".mp2", ".mp3", ".mpa", ".mpe", ".m3u", ".aac", ".adt", ".adts" };
        private static readonly string[] VideoExtensions = { ".mp4", ".avi", ".flv", ".mov", ".m4v", ".mp4v", ".3g2", ".3gp2", ".3gp", ".3gpp", ".m2ts" };



        internal WMPLib.IWMPMedia wmpMedia = null;

        public string Source { get; private set; }
        public bool IsValid
        {
            get
            {
                return System.IO.File.Exists(this.Source);
            }
        }
        public mpInterface.IMediaPlayList PlayList { get; private set; }
        public mpInterface.IMediaItemInfo MediaInfo { get; private set; }
        public MediaType MediaType { get; private set; }
        public MediaItem(WMPLib.IWMPMedia wmp_media, mpInterface.IMediaPlayList playlist)
        {
            if (wmp_media == null)
                throw new ArgumentNullException("Media path cannot be null");

            if (playlist == null)
                throw new ArgumentNullException("playlist cannot be null");

            if (!System.IO.File.Exists(wmp_media.sourceURL))
                throw new ArgumentException("Media does not exist.");

            this.wmpMedia = wmp_media;
            this.Source = wmp_media.sourceURL;
            this.MediaInfo = new MediaItemInfo(wmp_media);
            this.PlayList = playlist;
            this.MediaType = this.GetMediaType();
        }
        
        public void Play()
        {
            this.Check();
            this.PlayList.PlayItem(this);
        }
        public void Stop()
        {
            this.Check();
            if (this.Equal(((MediaItem)this.PlayList.CurrentlyPlayingItem)))
            {
                this.PlayList.Stop();
            }
        }
        public void Pause()
        {
            this.Check();
            if (this.Equal(((MediaItem)this.PlayList.CurrentlyPlayingItem)))
            {
                this.PlayList.Pause();
            }
        }

        private bool Equal(MediaItem itm)
        {
            if (itm != null)
            {
                return (itm.Source == this.Source);
            }
            return false;
        }
        private void Check()
        {
            if (this.PlayList == null)
                throw new InvalidOperationException("Cannot play, pause and stop media because it has not been connected to playlist yet.");
        }
        
        private MediaType GetMediaType()
        {
            if (this.Source != null)
            {
                string c_media_extension = System.IO.Path.GetExtension(this.Source);
                if (c_media_extension != null)
                {
                    c_media_extension = c_media_extension.ToLower();

                    foreach (string extension in AudioExtensions)
                        if (extension == c_media_extension)
                            return MediaType.Audio;

                    foreach (string extension in VideoExtensions)
                        if (extension == c_media_extension)
                            return MediaType.Video;

                    return MediaType.Unknown;
                }
            }
            return MediaType.None;
        }
    }
}
