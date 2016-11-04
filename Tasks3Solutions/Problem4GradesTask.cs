using System;
using Tasks3Solutions.Education;

namespace Tasks3Solutions
{
    internal class Problem4GradesTask
    {
        internal static void Main(object p)
        {
            Console.WriteLine("\n\n\tHello and welcome to TheAcademy version 1.02 - with Tasks added :)\n");
            Console.Write("Enter number of courses to create:");
            int numberToEnter = int.Parse(Console.ReadLine());
            Academy TheAcademy = new Academy();

            int firstInt, secondInt;
            string name;
            Course CourseOnFocus = null;
            string[] parsedInput = null;
            bool successfulParse = true;

            //a cycle Creating courses
            for (; numberToEnter > 0; numberToEnter--)
            {
                Console.WriteLine("Enter course data following the format: courseName//capacity: ");
                parsedInput = Console.ReadLine().Split(new string[] { "//" }, StringSplitOptions.None);
                if (parsedInput.Length < 2)
                {
                    numberToEnter++;
                    Console.WriteLine("\n\tEROR! Too little values entered for course!\nTry again ;)\n");
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
                    Console.WriteLine("\n\n\tCouldn't parse all data entered for course\n\t - Check messages above and re-enter values again ;)");
                    continue;
                }

                CourseOnFocus = new Course(name, firstInt);
                TheAcademy.AllCoursesList.Add(CourseOnFocus);
                Console.WriteLine($"Successfully created Course {CourseOnFocus.UniqueIdetifier} with data");
                Console.WriteLine($"\tname: {CourseOnFocus.CourseName}\n\tcapacity {CourseOnFocus.CourseCapacity}\n\t hours spent per day {CourseOnFocus.DurationInHoursePerDay}");
            }//a cycle Creating courses

            Console.Write("Enter number of students to create:");
            numberToEnter = int.Parse(Console.ReadLine());

            //a cycle Creating students and signing them up for courses
            CourseAttandee StudentOnFocus = null;
            for (; numberToEnter > 0; numberToEnter--)
            {
                Console.WriteLine("Enter Student data following the format: studentName//courseId: ");
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
                    Console.WriteLine($"Couldn't parse value {parsedInput[1]} as courseId");
                }

                if (!successfulParse)
                {
                    numberToEnter++;
                    Console.WriteLine("\n\n\tCouldn't parse all data entered for student && course\n\t - Check messages above and reenter values again ;)");
                    continue;
                }

                try
                {
                    StudentOnFocus = new CourseAttandee(name);
                }
                catch (PersonAgeException e)
                {
                    Console.WriteLine($"\n\tThrown PersonAgeException Error: {e.Message}\n{e.StackTrace}");
                    numberToEnter++;
                    Console.WriteLine("\n\n\tCouldn't parse all data entered for student\n\t - Check messages above and reenter values again ;)");
                    continue;
                }

                TheAcademy.AllStudentsList.Add(StudentOnFocus);
                Console.WriteLine($"Successfully created Student {StudentOnFocus.UniqueIdetifier} with data");
                Console.WriteLine($"\tname: {StudentOnFocus.Name}\n\thaving age {StudentOnFocus.age}");

                CourseOnFocus = TheAcademy.FindCourseByID(firstInt);
                try
                {
                    TheAcademy.SignUp(StudentOnFocus, CourseOnFocus);
                }
                catch (CourseNotFound e)
                {
                    Console.WriteLine($"\n\tThrown {e.GetType()} Error: {e.Message}\n{e.StackTrace}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n\tThrown an unknown Error: {e.Message}\n{e.StackTrace}");
                }

            }//a cycle Creating students and signing them up for courses

            //Entering students tasks for attended courses
            string userInput, quitCommand = "quit";
            float grade;
            StudentCourseTask TaskOnFocus = null;
            do
            {
                Console.WriteLine("\nEnter tasks given for student(s) attending course(s) using format: studentId courseId taskName//score");
                Console.Write("\n\t\t/Type quit to exit/:");
                userInput = Console.ReadLine();
                if (userInput.Equals(quitCommand))
                {
                    continue;
                }//if to quit using TheAcademy
                parsedInput = userInput.Split(new string[] { " " }, StringSplitOptions.None);
                if (parsedInput.Length < 3)
                {
                    Console.WriteLine("\n\tEROR! Too little values entered for studentId courseId taskName//score!\nTry again ;)\n");
                    continue;
                }

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

                name = parsedInput[2];
                parsedInput = name.Split(new string[] { "//" }, StringSplitOptions.None);
                if (parsedInput.Length < 2)
                {
                    Console.WriteLine("\n\tEROR! Too little values entered for Task creation: taskName//score!\nTry again ;)\n");
                    continue;
                }

                name = parsedInput[0];

                if (!float.TryParse(parsedInput[1], out grade))
                {
                    successfulParse = false;
                    Console.WriteLine($"Couldn't parse value {parsedInput[1]} as Task's grade");
                }

                if (!successfulParse)
                    {
                        Console.WriteLine("\n\n\tCouldn't parse all data entered for studentId courseId taskName//score\n\t - Check messages above and re-enter values again ;)");
                        continue;
                    }

                StudentOnFocus = TheAcademy.FindStudentByID(firstInt);
                CourseOnFocus = StudentOnFocus.AttendedCourse;

                //Needed or unnecessary bonus?
                if (CourseOnFocus.UniqueIdetifier != secondInt)
                {
                    Console.WriteLine($"\n\n\tStudent {StudentOnFocus} signed up for course with ID {CourseOnFocus.UniqueIdetifier} hten with ID {secondInt}!\nTry to guess again ;)");
                    continue;
                }

                TaskOnFocus = new StudentCourseTask(StudentOnFocus, CourseOnFocus, name, grade);
                TheAcademy.AcademyHistory.Add(TaskOnFocus);
                Console.WriteLine($"Successfully added Task {TaskOnFocus.Name}"+
                    $" for {TaskOnFocus.ForStudent}"+
                    $" attending {TaskOnFocus.InCourse}"+
                    $" having grade {TaskOnFocus.Grade}"+
                    "\nGood job! :)\n");

            } while (!userInput.Equals(quitCommand));//Entering students tasks for attended courses

            /**
             * TODO:
             * The program should output the students which have an average of no less than 95% score on their courses tasks,
             *  with the students sorted by name ascending and then by their score (use the LINQ ThenBy() ).
             *  And finally the program should output the top 3 or less courses,
             *  in which the students have 95% or higher scores, sorted by the course’s name and total task count
             *  ( hint: use a helper method from your AcademyHelper together with your Academy object,
             *  to sum the student tasks, for a given course) .
             **/

            Console.WriteLine("\n\n\t\tThanks for working with TheAcademy!\nCome again, please! ;)");

        }
    }
}