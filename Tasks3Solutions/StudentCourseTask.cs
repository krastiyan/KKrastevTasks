using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks3Solutions.Education
{
    public class StudentCourseTask
    {
        public CourseAttandee ForStudent { get; }
        public Course InCourse { get; }
        public DateTime DateCreated { get; } = DateTime.Now;
        public float Grade { get; set; }
        protected string mName = null;
        public string Name
        {
            get { return mName; }
            set
            {
                mName = value + "_task.created_" + DateCreated;
            }
        }

        public StudentCourseTask(CourseAttandee forStudent, Course inCourse, string TaskName, float TaskGrade)
        {
            ForStudent = forStudent;
            InCourse = inCourse;
            Name = TaskName;
            Grade = TaskGrade;
        }
    }
}
