using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKrastevTasks
{
    public class Person
    {
        //Resolving task 1 and 2

        protected string name;
        public int age;

        public string Name { get { return name; } set { name = value; } }

        public Person()
        {
            name = "No name";
            age = 1;
        }

        public Person(string givenName) : this()
        {
            name = givenName;
        }

        public Person(string givenName, int personAge) : this(givenName)
        {
            if (personAge < 0) throw new InvalidOperationException($"Ivalid age provided: {personAge}");
            age = personAge;

        }
    }

    public class Class1
    {
        static void Main(string[] args)
        {
            //Resolving tasks 1 and 2 together

            Console.Write("\nPlease enter person's name:");
            string nameInput = Console.ReadLine();
            Console.Write("\nPlease enter person's age:");
            //int ageInput = int.Parse(Console.ReadLine());
            int ageInput;
            if (int.TryParse(Console.ReadLine(), out ageInput)) {
                Console.WriteLine("Successfully added age value :)");
            } else
            {
                Console.WriteLine("Could NOT add age value ):");
            }
            Person object1, object2, object3;
            object1 = new Person();
            object2 = new Person(nameInput);
            object3 = new Person(nameInput, ageInput);
            Console.WriteLine($"1st Person data: name {object1.Name} age {object1.age}");
            Console.WriteLine($"2nd Person data: name {object2.Name} age {object2.age}");
            Console.WriteLine($"3rd Person data: name {object3.Name} age {object3.age}");
        }
    }//Class1

    public class Class2{
        static void Main(string[] args)
        {
            List<Person> personsList = new List<Person>();
            string userInput, quitCommand="quit";
            Person personToAdd = null;
            do
            {
                Console.Write("\nPlease enter person's name /quit to exit/:");
                userInput = Console.ReadLine();
                if (!userInput.Equals(quitCommand))
                {
                    string[] parsedInput = userInput.Split(new string[]{"//"}, StringSplitOptions.None);
                    Console.WriteLine($"\nparsedInput.size = {parsedInput.Length}\nparsedInput[0]={parsedInput[0]} && parsedInput[1]={parsedInput[1]}");
                    Console.ReadKey();
                    string nameInput = parsedInput[0];
                    int ageInput;
                    if (int.TryParse(parsedInput[1], out ageInput))
                    {
                        Console.WriteLine("Successfully added age value :)");
                    }
                    else
                    {
                        Console.WriteLine("Could NOT add age value ):");
                    }
                    personToAdd = new Person(nameInput, ageInput);
                    personsList.Add(personToAdd);
                    Console.WriteLine($"\nNew Person created with name {personToAdd.Name} and age {personToAdd.age}\n");
                }//if to create new Person
            } while (!userInput.Equals(quitCommand));

            personsList = personsList.OrderBy(p => p.Name.Length).ToList();

            foreach(Person person in personsList)
            {
                
                if (person.age > 18)
                {
                    Console.WriteLine(person.Name + "\t" + person.age);
                }
            }
        }
    }//Class2

    //resolving task 5 - to be completed...

        //To start task 5 you should change main method class to be Class3

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
                if (value!=null && AttendedCourse != null)
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

    public class Course
    {
        public int CourseCapacity {get; set;}

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
                        foreach(CourseAttandee attendee in value)
                        {
                            mAttendees.Add(attendee);
                            if (mAttendees.Count == CourseCapacity)
                            {
                                Console.WriteLine($"\tWARN!\tOnly first {CourseCapacity-initialCapacity} students added from provided list!");
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

    public class Academy
    {
        public List<Course> AllCoursesList { get; set; } = new List<Course>();
        public List<CourseAttandee> AllStudentsList { get; set; } = new List<CourseAttandee>();

        public bool SignUp(CourseAttandee aStudent, Course toCourse)
        {
            if(aStudent == null)
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
                Console.WriteLine($"\t\tException! caught:\n{e.Message}\n"+e.StackTrace);
                if (e.Message.Contains("already full!") && aStudent.AttendedCourse != null)
                {
                    aStudent.AttendedCourse = null;
                }
            }

            return false;
        }

        public bool UnSignUp(CourseAttandee aStudent, Course fromCourse)
        {
            if(fromCourse.CheckAttending(aStudent.Name))
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

    public class Class3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\tHello and welcome to TheAcademy version 1.00 :)\n");
            Console.Write("Enter number of courses to create:");
            int numberToEnter = int.Parse(Console.ReadLine());
            Academy TheAcademy = new Academy();

            int firstInt, secondInt;
            string name;
            Course CourseOnFocus = null;
            string[] parsedInput = null;
            bool successfulParse = true;
            for(;numberToEnter>0;numberToEnter--)
            {
                Console.WriteLine("Enter course data following the format: courseName//duration//capacity: ");
                parsedInput = Console.ReadLine().Split(new string[] { "//" }, StringSplitOptions.None);
                if(parsedInput.Length<3)
                {
                    numberToEnter++;
                    Console.WriteLine("\n\tEROR! Too little values entered for course!\nTry again ;)\n");
                    continue;
                }
                name = parsedInput[0];
                if (!int.TryParse(parsedInput[2], out firstInt))
                {
                    successfulParse = false;
                    Console.WriteLine($"Couldn't parse value {parsedInput[2]} as course capacity");
                }
                if (!int.TryParse(parsedInput[1], out secondInt))
                {
                    successfulParse = false;
                    Console.WriteLine($"Couldn't parse value {parsedInput[1]} as houhrse per day for the course");
                }

                if (!successfulParse)
                {
                    numberToEnter++;
                    Console.WriteLine("\n\n\tCouldn't parse all data entered for course\n\t - Check messages above and reenter values again ;)");
                    continue;
                }

                CourseOnFocus = new Course(name, firstInt, secondInt);
                TheAcademy.AllCoursesList.Add(CourseOnFocus);
                Console.WriteLine($"Successfully created Course {CourseOnFocus.UniqueIdetifier} with data");
                Console.WriteLine($"\tname: {CourseOnFocus.CourseName}\n\tcapacity {CourseOnFocus.CourseCapacity}\n\t hours spent per day {CourseOnFocus.DurationInHoursePerDay}");
            }

            Console.Write("Enter number of students to create:");
            numberToEnter = int.Parse(Console.ReadLine());

            //int capacity, hoursPerDay;
            //string name;
            CourseAttandee StudentOnFocus = null;
            for (; numberToEnter > 0; numberToEnter--)
            {
                Console.WriteLine("Enter Student data following the format: name//age: ");
                parsedInput = Console.ReadLine().Split(new string[] { "//" }, StringSplitOptions.None);
                if (parsedInput.Length < 2)
                {
                    numberToEnter++;
                    Console.WriteLine("\n\tEROR! Too little values entered for student!\nTry again ;)\n");
                    continue;
                }
                name = parsedInput[0];
                if (!int.TryParse(parsedInput[1], out firstInt))
                {
                    successfulParse = false;
                    Console.WriteLine($"Couldn't parse value {parsedInput[1]} as course capacity");
                }

                if (!successfulParse)
                {
                    numberToEnter++;
                    Console.WriteLine("\n\n\tCouldn't parse all data entered for course\n\t - Check messages above and reenter values again ;)");
                    continue;
                }

                StudentOnFocus = new CourseAttandee(name, firstInt);
                TheAcademy.AllStudentsList.Add(StudentOnFocus);
                Console.WriteLine($"Successfully created Student {StudentOnFocus.UniqueIdetifier} with data");
                Console.WriteLine($"\tname: {StudentOnFocus.Name}\n\thaving age {StudentOnFocus.age}");
            }

            string userInput, quitCommand = "quit";
            do
            {
                Console.WriteLine("\nSign up student for course using format: studentID courseID\n\t_hint: Enter CourseID*-1 to UnSignUp student from it.");
                Console.Write("\n\t\t/Type quit to exit/:");
                userInput = Console.ReadLine();
                if (!userInput.Equals(quitCommand))
                {
                    parsedInput = userInput.Split(new string[] { " " }, StringSplitOptions.None);
                    if (!int.TryParse(parsedInput[0], out firstInt))
                    {
                        successfulParse = false;
                        Console.WriteLine($"Couldn't parse value {parsedInput[1]} as studentID");
                    }
                    if (!int.TryParse(parsedInput[1], out secondInt))
                    {
                        successfulParse = false;
                        Console.WriteLine($"Couldn't parse value {parsedInput[1]} as courseID");
                    }

                    if (!successfulParse)
                    {
                        Console.WriteLine("\n\n\tCouldn't parse all data entered for course\n\t - Check messages above and reenter values again ;)");
                        continue;
                    }

                    CourseOnFocus = TheAcademy.FindCourseByID(secondInt);
                    StudentOnFocus = TheAcademy.FindStudentByID(firstInt);
                    //if (firstInt < 0)
                    //{
                    //    //Then user wants to remove student from course attendance
                    //    firstInt = secondInt;
                    //    StudentOnFocus = TheAcademy.FindStudentByID(-firstInt);
                    //}
                    //else
                    //{
                    //    StudentOnFocus = TheAcademy.FindStudentByID(firstInt);
                    //}
                    try
                    {
                        if(parsedInput.Length>2 && parsedInput[2].Equals("remove"))
                        {
                            TheAcademy.UnSignUp(StudentOnFocus, CourseOnFocus);
                        }else
                        {
                            TheAcademy.SignUp(StudentOnFocus, CourseOnFocus);
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"\n\tError: {e.Message}\n{e.StackTrace}");
                    }

                }//if to create new Person
            } while (!userInput.Equals(quitCommand));

            Console.WriteLine("\n\n\t\tThanks for working with TheAcademy!\nCome again, please! ;)");
        }//Main method
    }

    }//namespace
