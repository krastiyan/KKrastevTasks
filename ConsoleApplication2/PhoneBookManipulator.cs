using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class PhoneBookManipulator : IFileBookReader, IFileBookWriter
    {

        /** All methods should work directly with this field. **/
        private PhoneBook aPhoneBook = null;
        public PhoneBook ThePhoneBook { get { return aPhoneBook; } }

        public bool ExecuteCommand(string[] command)
        {
            switch ((SupportedCommands)Enum.Parse(typeof(SupportedCommands), command[0]))
            {
                case SupportedCommands.Add:
                    return true;
                case SupportedCommands.find:
                    return true;
                case SupportedCommands.serialize:
                    return true;
                default:
                    Console.WriteLine($"Attempt to execute unsupported command {command[0]} !");
                    return false;
            }
        }//ExecuteCommand

        public string[] ExecuteCommands(string fromFilePath)
        {
            List<string[]> commandsSet = ReadCommandsFromFile(fromFilePath);
            List<string> commandsExecutionResults = new List<string>(commandsSet.Count);
            foreach (string[] command in commandsSet)
            {
                commandsExecutionResults.Add($"Execution for [{command[0]}] successful = {ExecuteCommand(command)}");
            }
            return null;
        }

        public List<string[]> ReadCommandsFromFile(string fromFilePath)
        {
            string textProcessed;
            FileStream fileStream = new FileStream(@"" + fromFilePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                textProcessed = streamReader.ReadToEnd();
            }

            string[] commandsRead = textProcessed.Split(new string[] { /*"|",*/ "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            List<string[]> result = new List<string[]>(commandsRead.Length);
            foreach (string command in commandsRead)
            {
                result.Add(CommandParser.ParseCommand(command));
            }

            return result;

            //TODO: Use below for reading people from file! :)
            //if (commandsRead.Length != 3 
            //    || !commandsRead[2].StartsWith("0")
            //    || !commandsRead[2].StartsWith("+")
            //    )
            //{
            //    throw new FileLoadException($"Commands in file {fromFilePath} with invalid format: check file again!");
            //}

            //commandsRead[0] = commandsRead[0].Trim();
            //commandsRead[1] = commandsRead[1].Trim();
            //return commandsRead;
        }

        public List<Person> ReadFromBook(PhoneBook aPhoneBook)
        {
            throw new NotImplementedException();
        }

        public List<Person> ReadFromBook(string pathToBookFile)
        {
            throw new NotImplementedException();
        }

        public bool WriteInBook(List<Person> dataOfSomeone)
        {
            throw new NotImplementedException();
        }

        public bool WriteInBook(List<Person> dataOfSomeone, string pathToBookFile)
        {
            throw new NotImplementedException();
        }
    }
}
