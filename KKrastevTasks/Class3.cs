using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKrastevTasks
{
    public class Class3
    {
        public static void Main(string[] args)
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
            for (; numberToEnter > 0; numberToEnter--)
            {
                Console.WriteLine("Enter course data following the format: courseName//duration//capacity: ");
                parsedInput = Console.ReadLine().Split(new string[] { "//" }, StringSplitOptions.None);
                if (parsedInput.Length < 3)
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
                        if (parsedInput.Length > 2 && parsedInput[2].Equals("remove"))
                        {
                            TheAcademy.UnSignUp(StudentOnFocus, CourseOnFocus);
                        }
                        else
                        {
                            TheAcademy.SignUp(StudentOnFocus, CourseOnFocus);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"\n\tError: {e.Message}\n{e.StackTrace}");
                    }

                }//if to create new Person
            } while (!userInput.Equals(quitCommand));

            Console.WriteLine("\n\n\t\tThanks for working with TheAcademy!\nCome again, please! ;)");
        }//Main method
    }//Class3 class
}
