using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerHelper.mpInterface
{
    public interface IMediaPlayList : IList<IMediaItem>
    {

        event PlayStateChangedEventHandler PlayStateChanged;


        IMediaItem CurrentlyPlayingItem { get; }

        IMediaItem GetMediaItem(string media_path);
        void Add(string media_path);
        void Play();
        void PlayItem(int index);
        void PlayItem(IMediaItem media_item);
        void Stop();
        void Pause();
        void Next();
        void Previous();
    }
}
