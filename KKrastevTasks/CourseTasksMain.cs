using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKrastevTasks
{
    class CourseTasksMain
    {
        public static void Main(string[] args)
        {
            string userInput=null, quitCommand="quit";
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t\tChoose task to start between");
                Console.WriteLine("\t0 - Data structures task"+
                "\n\t1 - Task #1 from Tasks2.docx"+
                "\n\t2 - Task #2 from Tasks2.docx"+
                "\n\t4 - Task #4 from Tasks2.docx"+
                "\n\t5 - Task #5 from Tasks2.docx"+
                "\n\t... almost anything else will be ignored");
                Console.Write("  /Type quit to exit/:");
                userInput = Console.ReadLine();

                if (userInput.Equals(quitCommand)) continue;
                int choise;
                if(!int.TryParse(userInput, out choise))
                {
                    Console.WriteLine($"\n\n\tInvalid choise entered: {userInput} - try again ;-)");
                    continue;
                }

                switch (choise)
                {
                    case 0: { Program.Main(null); } break;
                    case 1: { Console.WriteLine("\n\n\tNothihng to start here - check Person.cs in source code :)"); } break;
                    case 2: { Class1.Main(null); } break;
                    case 4: { Class2.Main(null); } break;
                    case 5: { Class3.Main(null); } break;
                    default:
                        {
                            Console.WriteLine($"\n\n\tCan't recognize choise entered: {userInput} - try again ;-)");
                        }
                        break;
                }
                Console.WriteLine("\n   Press any key to go back to main menu, good human (-:");
                Console.ReadKey();

            } while (!userInput.Equals(quitCommand));
        }
    }
}
