using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class CommandExecutor
    {
        public const string JSONFileType = "JSON";
        public const string XMLFileType = "XML";

        private static string[] ConstructCommand(SupportedCommands command, string[] commandParameters)
        {
            string[] result = new string[commandParameters.Length + 1];
            switch (command)
            {
                //{ Enum.GetName(typeof(SupportedCommands), SupportedCommands.find), command[1]}
                case SupportedCommands.Add:
                    result[0] = Enum.GetName(typeof(SupportedCommands), SupportedCommands.find);
                    break;
                case SupportedCommands.find:
                    result[0] = Enum.GetName(typeof(SupportedCommands), SupportedCommands.find);
                    break;
                case SupportedCommands.serialize:
                    result[0] = Enum.GetName(typeof(SupportedCommands), SupportedCommands.find);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unrecognized command {command}");
            }

            int index = 1;
            foreach (string param in commandParameters)
            {
                result[index++] = param;
            }

            return result;
        }

        public static List<Person> ExecuteFindCommand(string[] command, PhoneBook onPhoneBook)
        {
            if (onPhoneBook == null ||
                (onPhoneBook.people == null || onPhoneBook.people.Count < 1)
                )
            {
                throw new ArgumentOutOfRangeException("Null or empty phonebook provided!");
            }
            if (command == null)
            {
                throw new ArgumentNullException("Null command argument prpovided");
            }

            if (command.Length == 2)
            {
                if (command[1] == null || command[1].Trim().Length > 0)
                {
                    throw new ArgumentException($"Null or empty argument provided for person Names: \"{command[1]}\"!");
                }
                return onPhoneBook.people.FindAll(x => x.Names.Contains(command[1]));
            }
            else if (command.Length >= 3)//If command hahs more than 3 items, those after teh 3rd one are ignored
            {
                if(command[1]==null || command[1].Trim().Length > 0 
                    || command[2]==null || command[2].Trim().Length > 0)
                {
                    throw new ArgumentException($"Null or empty arguments provided for person Names: \"{command[1]}\" or town: \"{command[2]}\"!");
                }
                return onPhoneBook.people.FindAll(x => x.Names.Contains(command[1]) && x.Town.Contains(command[2]));
            }
            else // This should only fire when command has < 2 items
            {
                throw new ArgumentException("Less than needed arguments provided for command "+command[0]);
            }
        }

        public static bool ExecuteAddCommand(string[] command, PhoneBook onPhoneBook)
        {
            List<Person> aPersonToAdd = new List<Person>(1);
            aPersonToAdd.Add(new Person(command[1], command[2], command[3]));
            onPhoneBook.people = aPersonToAdd;
            if (command.Length > 4 &&
                (command[4] != null && command[4].Trim().Length > 0)
                )//If also to add this person to a specified .txt file representation of the phonebook
            {
                return WriteBookContentIntoFile(aPersonToAdd, command[4], JSONFileType);
            }
            return true;
        }

        public static bool ExecuteSerializeCommand(string[] command, PhoneBook onPhoneBook)
        {
            List<Person> foundPeople = ExecuteFindCommand(
                ConstructCommand(SupportedCommands.find, new string[] { command[1]})//This constructs find command
                , onPhoneBook);

            return WriteBookContentIntoFile(foundPeople, command[2], command[3]);
        }

        public static bool WriteBookContentIntoFile(List<Person> people, string pathToPhoneBookFile, string fileType)
        {
            if (people == null || people.Count < 1)
            {
                throw new ArgumentException("A null or empty list of people provided- Check again how you call me!");
            }
            if (pathToPhoneBookFile == null || pathToPhoneBookFile.Trim().Length == 0)
            {
                throw new ArgumentException($"Invalid pathToPhoneBookFile argument provided: \"{pathToPhoneBookFile}\"");
            }
            if (fileType == null || fileType.Trim().Length == 0)
            {
                throw new ArgumentException($"Invalid fileType argument provided: \"{fileType}\"");
            }

            StringBuilder contentToWrite = new StringBuilder(people.Count * 100);
            switch (fileType)
            {
                case JSONFileType:
                    foreach (Person someone in people)
                    {
                        contentToWrite.Append(XMLAndJSONSerializer.JSONSerialize(someone) + "\n");
                    }
                    break;
                case XMLFileType:
                    foreach (Person someone in people)
                    {
                        contentToWrite.Append(XMLAndJSONSerializer.XMLSerialize(someone) + "\n");
                    }
                    break;
                default: throw new ArgumentOutOfRangeException($"Unsupported file type provided: {fileType}");
            }
            return PhoneBookManipulator.WriteContentInFile(contentToWrite.ToString(), pathToPhoneBookFile);
        }

    }
}
