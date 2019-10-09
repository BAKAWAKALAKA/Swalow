using System;
using System.Xml.Serialization;

namespace Swalow.Model
{
    [Serializable]
    public class member
    {
        [XmlAttribute("name")]
        public string name;
        [XmlElement("summary")]
        public string summary;
        [XmlElement("param")]
        public param[] param;
    }
}