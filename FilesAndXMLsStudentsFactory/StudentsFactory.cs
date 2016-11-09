using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndXMLsStudentsFactory
{
    class StudentsFactory
    {
        private static int uniqueID = 0;

        public static int getID()
        {
            return uniqueID++;
        }

        public static List<Student> makeStudents(int howMuchToCreate)
        {
            List<Student> theStudList =new List<Student>(howMuchToCreate);
            string studentID = null;
            Random ramdzer = new Random();
            for(int i = howMuchToCreate; i>0; i--)
            {
                //studentID = Guid.NewGuid().ToString("N");
                studentID = getID().ToString();
                theStudList.Add(new Student("Student_" + studentID, studentID, ramdzer.Next(18, 100)));
            }
            return theStudList;
        }
    }
}
