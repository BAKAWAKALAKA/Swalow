using System;
using System.Xml.Serialization;

namespace Swalow.Model
{
    [Serializable]
    public class assembly
    {
        [XmlElement("name")]
        public string name;
    }
}