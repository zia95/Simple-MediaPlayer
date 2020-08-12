using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerHelper.mpInterface
{
    public interface IMediaItemInfo
    {
        void SetAttribute(IMediaAttribute media_attribute);
        IMediaAttribute[] GetAllAttributes();
        [Obsolete("Use GetAllAttributes() instead", false)]
        IMediaAttribute GetAttribute(MediaTag attribute);


        double Duration { get; }
        string DurationAsString { get; }
        string Name { get; }
        string Source { get; }
    }
}
