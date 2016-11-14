using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PhoneBookApp
{
    class XMLAndJSONSerializer
    {
        public static string JSONSerialize(Person someone)
        {
            return JsonConvert.SerializeObject(someone);
        }

        public static string XMLSerialize(Person someone)
        {
            string namespaceURI = "studentsNS";
            XmlDocument document = new XmlDocument();
            XmlNode personNode = null, personDataChildNode = null;
                personNode = document.
            CreateNode(XmlNodeType.Element, "Person", namespaceURI);
                personDataChildNode = document.
            CreateElement("Names", namespaceURI);
                personDataChildNode.InnerText = someone.Names;
                personNode.AppendChild(personDataChildNode);
                personDataChildNode = document.
            CreateElement("Town", namespaceURI);
                personDataChildNode.InnerText = someone.Town;
                personNode.AppendChild(personDataChildNode);
                personDataChildNode = document.
            CreateElement("PhoneNumber", namespaceURI);
                personDataChildNode.InnerText = someone.PhoneNumber;
                personNode.AppendChild(personDataChildNode);
            document.AppendChild(personNode);
            return document.ToString();
        }
    }
}
