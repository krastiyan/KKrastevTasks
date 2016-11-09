using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndXMLsStudentsFactory
{
    public class Student
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public Student(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }
    }
}
