using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerHelper.mpInterface
{
    public interface IMediaPlayerControl
    {
        IMediaPlayList PlayList { get; }

        void LoadPlayList(IMediaPlayList playlist);
        IMediaPlayList CreateNewPlayList(params string[] media_paths);
        IMediaItem CreateNewMedia(string media_path, IMediaPlayList playlist);
        IMediaPlayList LoadPlayListFromFile(string playlist_path);
        void SavePlayListToFile(IMediaPlayList playlist, string path_to_save);


        void Play();
        void Stop();
        void Pause();
        void FastForward();
        void FastReverse();
        void Previous();
        void Next();

        State PlayState { get; }
        double Position { get; set; }
        string PositionAsString { get; }
        int Volume { get; set; }
        bool Mute { get; set; }
        bool AutoStart { get; set; }
        bool StrechToFit { get; set; }
        int Balance { get; set; }
    }
}
