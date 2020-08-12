using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerHelper
{
    public class MediaPlayer : IDisposable
    {

        #region Implementation --- IDisposable
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                ((MediaPlayerControl)this.MediaControl).ShutDown();
            }
        }
        ~MediaPlayer()
        {
            this.Dispose(false);
        }
        #endregion
        
        public mpInterface.IMediaPlayerControl MediaControl { get; private set; }

        public MediaPlayer(AxWMPLib.AxWindowsMediaPlayer wmp_player)
        {
            if (wmp_player == null)
                throw new ArgumentNullException("Media player object cannot be null.");

            this.MediaControl = new MediaPlayerControl(wmp_player);
        }
        public MediaPlayer(AxWMPLib.AxWindowsMediaPlayer wmp_player, params string[] MediaPaths)
        {
            if (wmp_player == null)
                throw new ArgumentNullException("Media player object cannot be null.");

            this.MediaControl = new MediaPlayerControl(wmp_player);

            if (MediaPaths != null)
                foreach (var media in MediaPaths)
                    this.MediaControl.PlayList.Add(media);
        }
        public MediaPlayer()
        {
            var player = new WMPLib.WindowsMediaPlayer();
            this.MediaControl = new MediaPlayerControl(player);
        }
        public MediaPlayer(params string[] MediaPaths)
        {
            var player = new WMPLib.WindowsMediaPlayer();

            this.MediaControl = new MediaPlayerControl(player);

            if (MediaPaths != null)
                foreach (var media in MediaPaths)
                    this.MediaControl.PlayList.Add(media);
        }

    }
}
