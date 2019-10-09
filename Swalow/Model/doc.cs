using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Swalow.Model
{
    [Serializable]
    [XmlRoot]
    public class doc
    {
        [XmlElement("assembly")]
        public assembly[] assembly;
        [XmlArray("members")]
        public member[] members;
    }
}
