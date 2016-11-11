using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System.Collections.Generic;

using PhoneBookApp;

namespace PhoneBookUnitTestProject
{
    [TestClass]
    public class PhoneBookManipulatorUnitTests
    {

        string[] TestDataCommandsFiles = new string[]
        {
            ////All correct commands - index 0
            // "Mimi Shmatkata          | Plovdiv  | 0888 12 34 56\n"
            //+"Kireto                  | Varna    | 052 23 45 67\n"
            //+"Daniela Ivanova Petrova | Karnobat | 0899 999 888\n"
            //+"Bat Gancho              | Sofia    | 02 946 946 946",
            ////Missing separators - index 1
            // "Mimi Shmatkata           Plovdiv  | 0888 12 34 56\n"
            //+"Kireto                  | Varna     052 23 45 67\n"
            //+"Daniela Ivanova Petrova | Karnobat | 0899 999 888\n"
            //+"Bat Gancho              | Sofia    | 02 946 946 946",
            ////Missing data - index 2
            // "Mimi Shmatkata          | Plovdiv  | 0888 12 34 56\n"
            //+"Kireto                  | | 052 23 45 67\n"
            //+"Daniela Ivanova Petrova | Karnobat | 0899 999 888\n"
            //+"Bat Gancho              | Sofia    | ",
        /* Above is test data for People*/

            //All correct commands - index 0
             "find(\"Mimi\");// – display all matching records by given name (first, middle, last or nickname)\n"
            +"find(\"Daniela Ivanova\", Karnobat);// – display all matching records by given name and town\n"
            +"serialize(\"Bat Gancho\", \"BatGancho.s.Data.txt\", \"XML\");// – serializes all records with the given name into a file with the given filename using the given serialization type (XML, JSON)\n"
            +"serialize(\"Kireto\", \"Kireto.s.JSON.txt\", \"JSON\");// – serializes all records with the given name into a file with the given filename using the given serialization type (XML, JSON)\n"
            +"Add(\"Pencho Ganchev Tenchevski\", \"Chuchulovitsa\", \"0845/6458588\");// – adds the new record in the memory\n"
            +"Add(\"Ivan Petrov Todorov\", \"Pernik\", \"03898998998\", \"C:\\Users\\Student\\Desktop\\Venci\\ConsoleApplication1\\KKrastevTasks\");// – adds the new record in the memory (optional: add it also to the phone.txt) - using intoFilePath parameter\n"
            +"serialize(\"Pencho Ganchev\", \"Pencho.Ganchev.s.JSON.txt\", \"JSON\");// – serializes all records with the given name into a file with the given filename using the given serialization type (XML, JSON)",
            //Missing separators - index 1
             "find(\"Mimi\");// – display all matching records by given name (first, middle, last or nickname)\n"
            +"find(\"Daniela Ivanova\" Karnobat);// – display all matching records by given name and town\n"
            +"serialize(\"Bat Gancho\", \"BatGancho.s.Data.txt\" \"XML\");// – serializes all records with the given name into a file with the given filename using the given serialization type (XML, JSON)\n"
            +"serialize(\"Kireto\", \"Kireto.s.JSON.txt\", \"JSON\");// – serializes all records with the given name into a file with the given filename using the given serialization type (XML, JSON)\n"
            +"Add(\"Pencho Ganchev Tenchevski\", \"Chuchulovitsa\", \"0845/6458588\")// – adds the new record in the memory\n"
            +"Add(\"Ivan Petrov Todorov\", \"Pernik\", \"03898998998\", \"C:\\Users\\Student\\Desktop\\Venci\\ConsoleApplication1\\KKrastevTasks\");// – adds the new record in the memory (optional: add it also to the phone.txt) - using intoFilePath parameter\n"
            +"serialize(\"Pencho Ganchev\", \"Pencho.Ganchev.s.JSON.txt\", \"JSON\");// – serializes all records with the given name into a file with the given filename using the given serialization type (XML, JSON)",
            //Missing data - index 2
             "find(\"Mimi\");// – display all matching records by given name (first, middle, last or nickname)\n"
            +"find(\"Daniela Ivanova\", Karnobat);// – display all matching records by given name and town\n"
            +"serialize(\"Bat Gancho\", \"BatGancho.s.Data.txt\", \"XML\");// – serializes all records with the given name into a file with the given filename using the given serialization type (XML, JSON)\n"
            +"serialize(\"Kireto\", \"Kireto.s.JSON.txt\", \"JSON\");// – serializes all records with the given name into a file with the given filename using the given serialization type (XML, JSON)\n"
            +"Add(\"Pencho Ganchev Tenchevski\", \"Chuchulovitsa\");// – adds the new record in the memory\n"
            +"Add(\"Ivan Petrov Todorov\", \"Pernik\", \"03898998998\", \"C:\\Users\\Student\\Desktop\\Venci\\ConsoleApplication1\\KKrastevTasks\");// – adds the new record in the memory (optional: add it also to the phone.txt) - using intoFilePath parameter\n"
            +"serialize(\"Pencho Ganchev\", \"Pencho.Ganchev.s.JSON.txt\");// – serializes all records with the given name into a file with the given filename using the given serialization type (XML, JSON)",
            //Empty file - index 3
            ""
        };

        private string writeTestDataFile(string fileContent, string filePath)
        {
            var fileStream = new FileStream(@"" + filePath, FileMode.OpenOrCreate, FileAccess.Write);
            using (var streamReader = new StreamWriter(fileStream, Encoding.UTF8))
            {
                streamReader.WriteLine(fileContent);
            }
            return filePath;
        }//writeTestDataFile

        string FilePathStart = "../../TestData/";

        [TestMethod]
        public void ReadCommandsFromEmptyFileShouldReturnEmptyCommandsSet()
        {
            string filePath = FilePathStart + "EmptyCommandsFile.txt";
            string fileContent = TestDataCommandsFiles[3];
            PhoneBookManipulator manipulator = new PhoneBookManipulator();
            List<string[]> commandsFound = manipulator.ReadCommandsFromFile(writeTestDataFile(fileContent, filePath));
            Assert.IsTrue(commandsFound.Count == 0);
        }

        [TestMethod]
        public void ReadWrongFormattedCommandsFromFileShouldReadOnlyCorrectOnesInCommandsSet()
        {
            string filePath = FilePathStart + "WrongFormattedCommandsFile.txt";
            string fileContent = TestDataCommandsFiles[1];
            //3 from 7 commands in TestData have wrong formatting
            PhoneBookManipulator manipulator = new PhoneBookManipulator();
            try
            {
                List<string[]> commandsFound = manipulator.ReadCommandsFromFile(writeTestDataFile(fileContent, filePath));
            }
            catch (FormatException e)
            {
                //We expect only 4 commands from all 7 in file to be in commandsFound
                Assert.IsTrue(e.Message.Contains("Invalid") && e.Message.Contains("passed - check syntax!")
                    && e.Message.Contains("find")//This is second find command in current DataSet
                    );
            }
        }
    }
}
