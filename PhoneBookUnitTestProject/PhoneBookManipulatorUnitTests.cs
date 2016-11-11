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
            //All correct commands - index 0
             "Mimi Shmatkata          | Plovdiv  | 0888 12 34 56\n"
            +"Kireto                  | Varna    | 052 23 45 67\n"
            +"Daniela Ivanova Petrova | Karnobat | 0899 999 888\n"
            +"Bat Gancho              | Sofia    | 02 946 946 946",
            //Missing separators - index 1
             "Mimi Shmatkata           Plovdiv  | 0888 12 34 56\n"
            +"Kireto                  | Varna     052 23 45 67\n"
            +"Daniela Ivanova Petrova | Karnobat | 0899 999 888\n"
            +"Bat Gancho              | Sofia    | 02 946 946 946",
            //Missing data - index 2
             "Mimi Shmatkata          | Plovdiv  | 0888 12 34 56\n"
            +"Kireto                  | | 052 23 45 67\n"
            +"Daniela Ivanova Petrova | Karnobat | 0899 999 888\n"
            +"Bat Gancho              | Sofia    | ",
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
    }
}
