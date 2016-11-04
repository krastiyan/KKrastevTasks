using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks3Solutions.Education
{
    public class CourseAttandee : Person
    {
        protected static int mStaticUniqueIdentifier = 0;

        public static int IncrementUniiqueIdenifier()
        {
            return mStaticUniqueIdentifier++;
        }

        //a public property
        public int UniqueIdetifier { get; } = IncrementUniiqueIdenifier();

        protected Course mAttendedCourse = null;
        public Course AttendedCourse
        {
            get { return mAttendedCourse; }
            set
            {
                if (value != null && AttendedCourse != null)
                {
                    //Console.WriteLine($"\n\tAttendedCourse already has value: {AttendedCourse} and its field has value {mAttendedCourse}");
                    throw new InvalidOperationException("Student is already signed up for another course");
                }
                else
                {
                    //Console.WriteLine($"\n\n\tSetting up attended course to be {value}\n\n");
                    mAttendedCourse = value;
                }
            }
        }
        public CourseAttandee(string nameInput, int ageInput) : base(nameInput, ageInput)
        {
            //UniqueIdetifier = IncrementUniiqueIdenifier();
            //initialization moved to property definition
        }

        public override string ToString()
        {
            return Name;
        }

    }//CourseAttandee class

}
