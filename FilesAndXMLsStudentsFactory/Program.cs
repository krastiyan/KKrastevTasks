using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FilesAndXMLsStudentsFactory
{
    class Program
    {
//Create students with factory and save all students in XML
        static void Main(string[] args)
        {
            List<Student> studentsCreated = StudentsFactory.makeStudents(5);
            SerializeStudentsList("StudentsXML.xml", studentsCreated);
        }

        private static void SerializeStudentsList(string filename, List<Student> theList)
        {
            XmlSerializer ser = new XmlSerializer(typeof(XmlNode));
            string namespaceURI = "studentsNS";
            XmlDocument document = new XmlDocument();
            XmlNode studentsListNode = document.
            CreateNode(XmlNodeType.Element, "StudentsList", namespaceURI);
            XmlNode studChildNode = null, dataChildNode = null;

            foreach (Student stud in theList)
            {
                studChildNode = document.
            CreateNode(XmlNodeType.Element, "Student", namespaceURI);
                dataChildNode = document.
            CreateElement("StudentName", namespaceURI);
                dataChildNode.InnerText = stud.Name;
                studChildNode.AppendChild(dataChildNode);
                dataChildNode = document.
            CreateElement( "StudentID", namespaceURI);
                dataChildNode.InnerText = stud.ID;
                studChildNode.AppendChild(dataChildNode);
                dataChildNode = document.
            CreateElement( "StudentAge", namespaceURI);
                dataChildNode.InnerText = stud.Age.ToString();
                studChildNode.AppendChild(dataChildNode);

                studentsListNode.AppendChild(studChildNode);
            }
            TextWriter writer = new StreamWriter(filename); //, true, Encoding.UTF8);//second value is of append mode on/off
            ser.Serialize(writer, studentsListNode);
            writer.Close();
        }
    }
}
