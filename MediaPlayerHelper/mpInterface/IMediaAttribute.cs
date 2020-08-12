using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerHelper.mpInterface
{
    public interface IMediaAttribute
    {
        MediaTag AttributeType { get; }
        string AttributeValue { get; }

        void ChangeValue(string new_value);
    }
}
