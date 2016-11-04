using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKrastevTasks
{
    public class Academy
    {
        public List<Course> AllCoursesList { get; set; } = new List<Course>();
        public List<CourseAttandee> AllStudentsList { get; set; } = new List<CourseAttandee>();

        public bool SignUp(CourseAttandee aStudent, Course toCourse)
        {
            if (aStudent == null)
            {
                throw new InvalidOperationException("Student does not exist");
            }
            if (toCourse == null)
            {
                throw new InvalidOperationException("Course does not exist");
            }
            try
            {
                aStudent.AttendedCourse = toCourse;
                toCourse.Attendees = new List<CourseAttandee>() { aStudent };
                Console.WriteLine($"Succesfully signed up {aStudent} to {toCourse}");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"\t\tException! caught:\n{e.Message}\n" + e.StackTrace);
                if (e.Message.Contains("already full!") && aStudent.AttendedCourse != null)
                {
                    aStudent.AttendedCourse = null;
                }
            }

            return false;
        }

        public bool UnSignUp(CourseAttandee aStudent, Course fromCourse)
        {
            if (fromCourse.CheckAttending(aStudent.Name))
            {
                fromCourse.RemoveStudent(aStudent);
                aStudent.AttendedCourse = null;
                Console.WriteLine($"Succesfully un-signed up {aStudent} from {fromCourse}");
                return true;
            }
            Console.WriteLine($"'tINFO\t Student {aStudent} has not been currently signed up for course {fromCourse}\n");
            return true;
        }

        public CourseAttandee FindStudentByID(int searchedID)
        {
            return AllStudentsList.Find(x => x.UniqueIdetifier == searchedID);
        }

        internal Course FindCourseByID(int searchedID)
        {
            return AllCoursesList.Find(x => x.UniqueIdetifier == searchedID);
        }
    }//Academy class

}
