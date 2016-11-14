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
            if (command==null || command.Length<1)
            {
                throw new ArgumentException("Null or empty command parameter provided to ExecuteCommand(string[])!");
            }
            if(command[0] == null || command[0].Length < 1)
            {
                throw new ArgumentException($"Null or empty command[0] parameter provided to ExecuteCommand(string[]): command[0]= \"{command[0]}\"!");
            }

            switch ((SupportedCommands)Enum.Parse(typeof(SupportedCommands), command[0]))
            {
                case SupportedCommands.Add:
                    return CommandExecutor.ExecuteAddCommand(command, aPhoneBook);
                case SupportedCommands.find:
                    return CommandExecutor.ExecuteFindCommand(command, aPhoneBook) != null;
                case SupportedCommands.serialize:
                    return CommandExecutor.ExecuteSerializeCommand(command, aPhoneBook);
                default:
                    throw new ArgumentOutOfRangeException($"Attempt to execute unsupported command: \"{command[0]}\" !");
            }
        }//ExecuteCommand

        public string[] ExecuteCommands(string fromFilePath)
        {
            if (fromFilePath == null || fromFilePath.Length < 1)
            {
                throw new ArgumentException($"Null or empty fromFilePath parameter provided to ExecuteCommands(string fromFilePath = \"{fromFilePath}\")!");
            }

            List<string[]> commandsSet = ReadCommandsFromFile(fromFilePath);
            List<string> commandsExecutionResults = new List<string>(commandsSet.Count);
            foreach (string[] command in commandsSet)
            {
                commandsExecutionResults.Add($"Execution for [{command[0]}] successful = {ExecuteCommand(command)}");
            }
            return commandsExecutionResults.ToArray<string>();
        }

        public List<string[]> ReadCommandsFromFile(string fromFilePath)
        {
            if (fromFilePath == null || fromFilePath.Length < 1)
            {
                throw new ArgumentException($"Null or empty fromFilePath parameter provided to ReadCommandsFromFile(string fromFilePath = \"{fromFilePath}\")!");
            }

            string textProcessed = ReadFileContent(fromFilePath);
            string[] commandsRead = textProcessed.Split(PhoneBookParser.FileRowsSplitParameter, StringSplitOptions.RemoveEmptyEntries);

            List<string[]> result = new List<string[]>(commandsRead.Length);
            foreach (string command in commandsRead)
            {
                result.Add(CommandParser.ParseCommand(command));
            }

            return result;
        }

        public static string ReadFileContent(string fromFilePath)
        {
            if (fromFilePath == null || fromFilePath.Length < 1)
            {
                throw new ArgumentException($"Null or empty fromFilePath parameter provided to ReadFileContent(string fromFilePath = \"{fromFilePath}\")!");
            }

            string textProcessed = null;
            FileStream fileStream = new FileStream(@"" + fromFilePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                textProcessed = streamReader.ReadToEnd();
            }
            return textProcessed;
        }

        public static bool WriteContentInFile(string content, string toFilePath)
        {
            if (content == null || content.Length < 1)
            {
                throw new ArgumentException($"Null or empty content parameter provided to WriteContentInFile(string content =\"{content}\", string )!");
            }
            if (toFilePath == null || toFilePath.Length < 1)
            {
                throw new ArgumentException($"Null or empty toFilePath parameter provided to WriteContentInFile(string content, string toFilePath = \"{toFilePath}\")!");
            }

            //FileStream fileStream = new FileStream(@"" + toFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            using (var streamReader = new StreamWriter(@"" + toFilePath, true, Encoding.UTF8))
            {
                streamReader.WriteLine(content);
            }
            return true;
        }

        /**
         * Reads data from given phonebook into the phonebook managed from this manipulator
         **/
        public List<Person> ReadFromBook(PhoneBook aPhoneBook)
        {
            if (aPhoneBook == null
                || aPhoneBook.people == null || aPhoneBook.people.Count < 1)
            {
                throw new ArgumentException("Null or empty phone book rpovided to ReadFromBook(PhoneBook)!");
            }

            return aPhoneBook.people;
        }

        public List<Person> ReadFromBook(string pathToBookFile)
        {
            if (pathToBookFile == null || pathToBookFile.Length < 1)
            {
                throw new ArgumentException($"Null or empty pathToBookFile parameter provided to ReadFromBook(string pathToBookFile =\"{pathToBookFile}\")!");
            }

            if (pathToBookFile.Equals(this.aPhoneBook.FilePath))
            {
                throw new ArgumentException("Duplicating phonebooks not allowed in ReadFromBook()!");
            }
            string textProcessed = ReadFileContent(pathToBookFile);
            string[] personDataRead = textProcessed.Split(PhoneBookParser.FileRowsSplitParameter, StringSplitOptions.RemoveEmptyEntries);
            List<Person> result = new List<Person>(personDataRead.Length);
            foreach (string personData in personDataRead)
            {
                result.Add(PhoneBookParser.ParsePersonData(personData));
            }
            return result;
        }

        public bool WriteInBook(List<Person> dataOfSomePeople)
        {
            if (dataOfSomePeople == null || dataOfSomePeople.Count < 1)
            {
                throw new ArgumentException("Null or empty list of personal data provided to WriteInBook(List<Person>)!");
            }

            if (this.aPhoneBook == null)
            {
                this.aPhoneBook = new PhoneBook();
            }
            this.aPhoneBook.people=dataOfSomePeople;
            return true;
        }

        public bool WriteInBook(List<Person> dataOfSomePeople, string pathToPhoneBookFile)
        {
            if (dataOfSomePeople == null || dataOfSomePeople.Count < 1)
            {
                throw new ArgumentException("Null or empty list of personal data provided to WriteInBook(List<Person>, string)!");
            }
            if (pathToPhoneBookFile == null || pathToPhoneBookFile.Length < 1)
            {
                throw new ArgumentException($"Null or empty pathToPhoneBookFile parameter provided to WriteInBook(List<Person>, string pathToPhoneBookFile =\"{pathToPhoneBookFile}\")!");
            }

            StringBuilder fileContent = new StringBuilder(dataOfSomePeople.Count);
            foreach (Person someone in dataOfSomePeople)
            {
                fileContent.Append(PhoneBookParser.ParsePersonDataToPhoneBookFileRow(someone) + "\n");
            }
            return WriteContentInFile(fileContent.ToString(), pathToPhoneBookFile);
        }

    }
}
