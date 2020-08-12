using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerHelper
{
    internal class MediaPlayerControl : mpInterface.IMediaPlayerControl
    {
        internal AxWMPLib.AxWindowsMediaPlayer Player { get; private set; }
        internal WMPLib.WindowsMediaPlayer Player2 { get; private set; }
        public mpInterface.IMediaPlayList PlayList { get; private set; }


        public MediaPlayerControl(AxWMPLib.AxWindowsMediaPlayer player)
        {
            if (player == null)
                throw new ArgumentNullException("Media player null.");
            
            this.Player = player;
            this.PlayList = new MediaPlayList(this);
        }
        public MediaPlayerControl(WMPLib.WindowsMediaPlayer player)
        {
            if (player == null)
                throw new ArgumentNullException("Media player null.");

            this.Player2 = player;
            this.PlayList = new MediaPlayList(this);
        }

        #region Basic Controls Play,Stop,Pause,FF,FR,Previous,Next
        public void Play()
        {
            this.PlayList.Play();
        }
        public void Stop()
        {
            this.PlayList.Stop();
        }
        public void Pause()
        {
            this.PlayList.Pause();
        }
        public void FastForward()
        {
            this.Player?.Ctlcontrols.fastForward();
            this.Player2?.controls.fastForward();
        }
        public void FastReverse()
        {
            this.Player.Ctlcontrols.fastReverse();
            this.Player2?.controls.fastReverse();
        }
        public void Previous()
        {
            this.PlayList.Previous();
        }
        public void Next()
        {
            this.PlayList.Next();
        }
        #endregion

        #region Other Controls PlayState,Position,Volume,Mute,AutoStart,StrechToFit,Balance
        public State PlayState
        {
            get
            {
                if(this.Player != null)
                {
                    return (State)this.Player.playState;
                }
                else
                {
                    return (State)this.Player2.playState;
                }
                
            }
        }
        public double Position
        {
            get
            {
                if (this.Player != null)
                {
                    return this.Player.Ctlcontrols.currentPosition;
                }
                else
                {
                    return this.Player2.controls.currentPosition;
                }
            }
            set
            {

                if (this.Player != null)
                {
                    this.Player.Ctlcontrols.currentPosition = value;
                }
                else
                {
                     this.Player2.controls.currentPosition = value;
                }
            }
        }
        public string PositionAsString
        {
            get
            {
                if (this.Player != null)
                {
                    return this.Player.Ctlcontrols.currentPositionString;
                }
                else
                {
                    return this.Player2.controls.currentPositionString;
                }
                
            }
        }
        public int Volume
        {
            get
            {
                if(Player != null)
                {
                    return this.Player.settings.volume;
                }
                else
                {
                    return this.Player2.settings.volume;
                }
                
            }
            set
            {
                if (Player != null)
                {
                    this.Player.settings.volume = value;
                }
                else
                {
                    this.Player2.settings.volume = value;
                }
            }
        }
        public bool Mute
        {
            get
            {
                if (Player != null)
                {
                    return this.Player.settings.mute;
                }
                else
                {
                    return this.Player2.settings.mute;
                }
                
            }
            set
            {
                if (Player != null)
                {
                    this.Player.settings.mute = value;
                }
                else
                {
                    this.Player2.settings.mute = value;
                }
            }
        }
        public bool AutoStart
        {
            get
            {
                if (Player != null)
                {
                    return this.Player.settings.autoStart;
                }
                else
                {
                    return this.Player2.settings.autoStart;
                }
                
            }
            set
            {
                if (Player != null)
                {
                    this.Player.settings.autoStart = value;
                }
                else
                {
                    this.Player2.settings.autoStart = value;
                }
            }
        }
        public bool StrechToFit
        {
            get
            {
                if (Player != null)
                {
                    return this.Player.stretchToFit;
                }
                else
                {
                    return this.Player2.stretchToFit;
                }
            }
            set
            {
                if (Player != null)
                {
                    this.Player.stretchToFit = value;
                }
                else
                {
                    this.Player2.stretchToFit = value;
                }
            }
        }
        public int Balance
        {
            get
            {
                if (Player != null)
                {
                    return this.Player.settings.balance;
                }
                else
                {
                    return this.Player2.settings.balance;
                }
                
            }
            set
            {
                if (Player != null)
                {
                    this.Player.settings.balance = value;
                }
                else
                {
                    this.Player2.settings.balance = value;
                }
            }
        }
        #endregion

        #region PlayList & Media Create & Save
        public void LoadPlayList(mpInterface.IMediaPlayList playlist)
        {
            if (playlist == null)
                throw new ArgumentNullException("PlayList is null");

            this.PlayList = playlist;
        }
        public mpInterface.IMediaPlayList CreateNewPlayList(params string[] media_paths)
        {
            var playlist = new MediaPlayList(this);
            if(media_paths != null && media_paths.Length > 0)
                foreach (var mediapath in media_paths)
                    playlist.Add(mediapath);

            return playlist;
        }
        public mpInterface.IMediaItem CreateNewMedia(string media_path, mpInterface.IMediaPlayList playlist)
        {
            if (playlist == null)
                throw new ArgumentNullException("playlist is null");

            return playlist.GetMediaItem(media_path);
        }
        private class XML_Constant
        {
            public const string PlayList_StartElement = "MediaPlayList";
            public const string PlayList_MediaElement = "Media";
            public const string PlayList_MediaPathAttribute = "Path";
            public const int PlayList_AttributeCount = 1;
        }
        public mpInterface.IMediaPlayList LoadPlayListFromFile(string playlist_path)
        {
            if (playlist_path == null)
                throw new ArgumentNullException("playlist path is null");

            if (System.IO.File.Exists(playlist_path) == false)
                throw new ArgumentException("playlist file does not exist.");

            var playlist = new MediaPlayList(this);

            using (var fs = System.IO.File.OpenRead(playlist_path))
            using (var reader = System.Xml.XmlReader.Create(fs))
            {
                while(reader.Read())
                {
                    if(reader.IsStartElement(XML_Constant.PlayList_MediaElement))
                    {
                        if(reader.AttributeCount == XML_Constant.PlayList_AttributeCount)
                        {
                            string media_path = reader.GetAttribute(XML_Constant.PlayList_MediaPathAttribute);
                            if (media_path != null && System.IO.File.Exists(media_path))
                                playlist.Add(media_path);
                        }
                    }
                }
            }
            return playlist;
        }
        public void SavePlayListToFile(mpInterface.IMediaPlayList playlist, string path_to_save)
        {
            if (playlist == null)
                throw new ArgumentNullException("playlist is null");

            if (path_to_save == null)
                throw new ArgumentNullException("playlist save path is null");

            if (System.IO.File.Exists(path_to_save))
                throw new ArgumentException("some file already exist in save path.");

            if (playlist.Count < 0)
                throw new InvalidOperationException("there are no media(s) in playlist, empty playlist cannot be saved...");

            var writer_settings = new System.Xml.XmlWriterSettings()
            {
                IndentChars = "\t",
                Indent = true,
            };


            using (var fs = System.IO.File.Create(path_to_save))
            using (var writer = System.Xml.XmlWriter.Create(fs, writer_settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(XML_Constant.PlayList_StartElement);

                foreach(var media in playlist)
                {
                    writer.WriteStartElement(XML_Constant.PlayList_MediaElement);

                    writer.WriteAttributeString(XML_Constant.PlayList_MediaPathAttribute, media.Source);

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        #endregion



        internal void ShutDown()
        {
            if (Player != null)
            {
                this.Player.Dispose();
                this.Player = null;
            }
            else
            {
                this.Player2 = null;
            }
            this.PlayList.Clear();
            this.PlayList = null;
            
        }


    }

}
