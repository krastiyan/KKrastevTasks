using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    class Program
    {
        public const string QuitCommand = "quit";
        public const string EnterPersonDataFromConsoleCommand = "0";
        public const string PrintPersonDataOnConsoleCommand = "1";
        public const string EnterPersonDataFromFileCommand = "2";
        public const string PrintPersonDataIntoFileCommand = "3";
        public const string ExecuteCommandsSetFromFileCommand = "4";
        public const string ExecuteCommandFromConsoleCommand = "5";


        private static void RequestPressOfAnyKey()
        {
            Console.WriteLine("\n\tPress any key to continue..");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            PhoneBookManipulator MyPhoneBook = new PhoneBookManipulator();
            string userChoise = null;
            while (!(userChoise = RequestConsoleMenuInput().Trim()).Equals(QuitCommand))
            {
                switch (userChoise)
                {
                    case EnterPersonDataFromConsoleCommand:
                        string[] PeopleData = EnterPersonDataFromConsole();
                        if (PeopleData.Length > 0)
                        {
                            List<Person> People = new List<Person>(PeopleData.Length);
                            foreach (string aPersonData in PeopleData)
                            {
                                People.Add(PhoneBookParser.ParsePersonData(aPersonData));
                            }
                            if (MyPhoneBook.WriteInBook(People))
                            {
                                Console.WriteLine($"Successfully added data for {People.Count} people in phone book! :)");
                            }
                            else
                            {
                                Console.WriteLine("\n\tSomething went wrong while wrting people data in phone book!\n"
                                    + "\n\tCheck for any messages above to find why.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\tNo Person data read from your input.\n");
                        }
                        break;
                    case PrintPersonDataOnConsoleCommand:
                        if (MyPhoneBook.ThePhoneBook != null
                            && MyPhoneBook.ThePhoneBook.people != null
                            && MyPhoneBook.ThePhoneBook.people.Count > 0)
                        {
                            Console.WriteLine("\n\t===Printing phone book content===\n");
                            foreach (Person someone in MyPhoneBook.ReadFromBook(MyPhoneBook.ThePhoneBook))
                            {
                                Console.WriteLine(someone);
                            }
                            Console.WriteLine("\n\t===End of phone book content===\n");
                        }
                        else
                        {
                            Console.WriteLine("\n\tPhone book not yet created or currenty empty.\n");
                        }
                        break;
                    case EnterPersonDataFromFileCommand:
                        Console.WriteLine("Enter path to file with phone book content:");
                        string pathToFhoneBookFile = Console.ReadLine();
                        List<Person> peopleInFile = MyPhoneBook.ReadFromBook(pathToFhoneBookFile);
                        if (MyPhoneBook.WriteInBook(peopleInFile))
                        {
                            Console.WriteLine($"\n\tSuccessfully added {peopleInFile.Count} people to phone book.\n");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong while trying to add people to phone book!\n"
                                + "\n\tCheck for any messages above to see why.\n");
                        }
                        break;
                    case PrintPersonDataIntoFileCommand:
                        Console.WriteLine("Enter path to file in which to write phone book content:");
                        string pathToWriteFhoneBookInFile = Console.ReadLine();

                        if (MyPhoneBook.ThePhoneBook != null
                            && MyPhoneBook.ThePhoneBook.people != null
                            && MyPhoneBook.ThePhoneBook.people.Count > 0)
                        {
                            if(MyPhoneBook.WriteInBook(MyPhoneBook.ThePhoneBook.people, pathToWriteFhoneBookInFile))
                            {
                                Console.WriteLine($"\n\tSuccessfully written {MyPhoneBook.ThePhoneBook.people.Count} in file {pathToWriteFhoneBookInFile}.\n");
                            }
                            else
                            {
                                Console.WriteLine("\n\tSomething went wrong while wrting people data from current phone book in file!\n"
                                    + "\n\tCheck for any messages above to find why.\n");
                            }

                        }
                        else
                        {
                            Console.WriteLine("\n\tPhone book not yet created or currenty empty.\n");
                        }
                        break;
                    case ExecuteCommandsSetFromFileCommand:
                        break;
                    case ExecuteCommandFromConsoleCommand:
                        break;
                    default:
                        Console.WriteLine($"Unsupported command enetered {userChoise}");
                        break;
                }//switch
                RequestPressOfAnyKey();//Lets user see result of last command chosen
            }
        }

        private static string RequestConsoleMenuInput()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\t\tChoose from following options:"
                + "\n\t" + EnterPersonDataFromConsoleCommand + " - Enter Person's data from console"
                + "\n\t" + PrintPersonDataOnConsoleCommand + " - Print Person's data on console"
                + "\n\t" + EnterPersonDataFromFileCommand + " - Enter Person's data from file"
                + "\n\t" + PrintPersonDataIntoFileCommand + " - Print Person's data into file"
                + "\n\t" + ExecuteCommandsSetFromFileCommand + " - Execute commands set from file"
                + "\n\t" + ExecuteCommandFromConsoleCommand + " - Execute command specified in console"
                + "\n\t" + QuitCommand + " - Exit program"
                );
            return Console.ReadLine();
        }//RequestConsoleInput

        private static string[] EnterPersonDataFromConsole()
        {
            List<string> result = new List<string>();
            string userInput = null;
            string[] ConsolePersonData = null;
            while (!(userInput = RequestConsoleMenuInput().Trim()).Equals(QuitCommand))
            {
                Console.WriteLine("Enter Person's data in format <Names>"
                    + PhoneBookParser.PersonDataSeparator
                    + "<Twon>"
                    + PhoneBookParser.PersonDataSeparator
                    + "<PhoneNumber>");
                userInput = Console.ReadLine();
                ConsolePersonData = userInput.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                if (ConsolePersonData != null && ConsolePersonData.Length > 2)
                {
                    result.Add(userInput);
                }
            }

            return result.ToArray<string>();
        }

    }
}
