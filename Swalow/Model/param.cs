using System;
using System.Xml.Serialization;

namespace Swalow.Model
{
    [Serializable]
    public class param
    {
        [XmlAttribute("name")]
        public string name;
        [XmlElement]
        public string content;
    }
}