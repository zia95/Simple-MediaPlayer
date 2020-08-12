using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerHelper
{
    public delegate void PlayStateChangedEventHandler(object sender, PlayStateChangedEventArg e);
    public class PlayStateChangedEventArg : EventArgs
    {
        public State NewPlayState { get; private set; }
        public PlayStateChangedEventArg(State new_state) : base()
        {
            this.NewPlayState = new_state;
        }
    }
}
