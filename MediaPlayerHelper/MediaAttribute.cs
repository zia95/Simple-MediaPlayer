using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerHelper
{
    internal class MediaAttribute : mpInterface.IMediaAttribute
    {
        public static bool StringToAttribute(string att_str, out MediaTag attribute)
        {
            if(att_str != null)
            {
                if (att_str.Contains('/'))
                    att_str=att_str.Replace('/', '_');

                //try parsing
                MediaTag[] all_media_tags = Enum.GetValues(typeof(MediaTag)) as MediaTag[];
                if(all_media_tags != null)
                {
                    foreach(var media_tag in all_media_tags)
                    {
                        if(media_tag.ToString() == att_str)
                        {
                            attribute = media_tag;
                            return true;
                        }
                    }
                }
            }
            attribute = MediaTag.AcquisitionTime;
            return false;
        }
        public static string AttributeToString(MediaTag attribute)
        {
            string tag_string = attribute.ToString();
            if (tag_string.Contains("_"))
                tag_string= tag_string.Replace('_', '/');

            return tag_string;
        }
        public MediaTag AttributeType { get; private set; }
        public string AttributeValue { get; private set; }
        public MediaAttribute(MediaTag attribute, string attribute_value)
        {
            this.AttributeType = attribute;
            this.AttributeValue = attribute_value == null ? "" : attribute_value;
        }

        public void ChangeValue(string new_value)
        {

        }
    }
}
