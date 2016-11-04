using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKrastevTasks
{
    public class Course
    {
        public int CourseCapacity { get; set; }

        protected List<CourseAttandee> mAttendees;
        public List<CourseAttandee> Attendees
        {
            get
            {
                return mAttendees;
            }
            set
            {
                if (Attendees == null)
                {
                    mAttendees = new List<CourseAttandee>(CourseCapacity);
                    mAttendees.AddRange(value);
                }
                else if (Attendees.Count == CourseCapacity)
                {
                    Console.WriteLine($"\nCourse is full - maximum capacity of {CourseCapacity} already reached.\n");
                    throw new Exception($"Course #nameOfCourse={CourseName} is already full!");
                }
                else
                {
                    if (mAttendees.Count + value.Count > CourseCapacity)
                    {
                        int initialCapacity = mAttendees.Count;
                        foreach (CourseAttandee attendee in value)
                        {
                            mAttendees.Add(attendee);
                            if (mAttendees.Count == CourseCapacity)
                            {
                                Console.WriteLine($"\tWARN!\tOnly first {CourseCapacity - initialCapacity} students added from provided list!");
                                break;
                            }
                        }
                    }
                    else
                    {
                        mAttendees.AddRange(value);
                    }
                }
            }
        }

        protected static int mStaticUniqueIdentifier = 0;

        public static int IncrementUniiqueIdenifier()
        {
            return mStaticUniqueIdentifier++;
        }

        //a public property
        public int UniqueIdetifier { get; } = IncrementUniiqueIdenifier();

        public string CourseName { get; set; }

        public int DurationInHoursePerDay { get; set; }

        public Course(string nameInput, int maxCapacity, int hoursPerDay)
        {
            CourseName = nameInput;
            CourseCapacity = maxCapacity;
            DurationInHoursePerDay = hoursPerDay;
        }

        public override string ToString()
        {
            return CourseName;
        }

        public bool CheckAttending(CourseAttandee studentToFind)
        {
            return CheckAttending(studentToFind.Name);
        }

        public bool CheckAttending(string studentName)
        {
            return (Attendees.Find(x => x.Name == studentName) != null);
        }

        public bool RemoveStudent(CourseAttandee student)
        {
            if (CheckAttending(student))
            {
                return mAttendees.Remove(student);
            }
            return false;
        }

    }//Course class

}
