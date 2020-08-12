using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerHelper
{
    internal class MediaItemInfo : mpInterface.IMediaItemInfo
    {
        private readonly WMPLib.IWMPMedia media_item = null;
        public MediaItemInfo(WMPLib.IWMPMedia media)
        {
            if (media == null)
                throw new ArgumentNullException("media items is null");

            this.media_item = media;
        }
        public void SetAttribute(mpInterface.IMediaAttribute media_attribute)
        {
            if (media_attribute == null)
                throw new ArgumentNullException("media attribute is null");

            if (media_attribute.AttributeValue == null)
                throw new ArgumentNullException("media attribute value is null");

            this.media_item.setItemInfo(MediaAttribute.AttributeToString(media_attribute.AttributeType), media_attribute.AttributeValue);
        }
        public mpInterface.IMediaAttribute[] GetAllAttributes()
        {
            List<mpInterface.IMediaAttribute> temp = new List<mpInterface.IMediaAttribute>();
            for (int i = 0; i < this.media_item.attributeCount;i++)
            {
                string attribute_name = this.media_item.getAttributeName(i);
                
                MediaTag media_att = MediaTag.AcquisitionTime;
                if (MediaAttribute.StringToAttribute(attribute_name, out media_att))
                {
                    string attribute_value = this.media_item.getItemInfo(attribute_name);
                    temp.Add(new MediaAttribute(media_att, attribute_value));
                }
            }
            return temp.ToArray();
        }
        
        public mpInterface.IMediaAttribute GetAttribute(MediaTag attribute)
        {
            int attribute_index = -1;
            string attribute_name = null;
            for (int i = 0; i < this.media_item.attributeCount; i++)
            {
                string attname = this.media_item.getAttributeName(i);
                
                if(attname == MediaAttribute.AttributeToString(attribute))
                {
                    attribute_index = i;
                    attribute_name = attname;
                }
            }
            if (attribute_name == null) new MediaAttribute(attribute, null);

            string attribute_value = this.media_item.getItemInfo(attribute_name);
            
            MediaTag media_att = MediaTag.AcquisitionTime;

            return MediaAttribute.StringToAttribute(attribute_name, out media_att) ? 
                new MediaAttribute(attribute, attribute_value) : new MediaAttribute(attribute, null);
        }

        public double Duration { get { return this.media_item.duration; } }
        public string DurationAsString { get { return this.media_item.durationString; } }
        public string Name { get { return this.media_item.name; } }
        public string Source { get { return this.media_item.sourceURL; } }
    }
}
