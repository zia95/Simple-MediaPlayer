using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerHelper.mpInterface
{
    public interface IMediaItem
    {
        //static void Attach(MediaItem itm, MediaPlayList play_list);
        string Source { get; }
        bool IsValid { get; }
        IMediaPlayList PlayList { get; }
        IMediaItemInfo MediaInfo { get; }
        MediaType MediaType { get; }

        void Play();
        void Stop();
        void Pause();
    }
}
