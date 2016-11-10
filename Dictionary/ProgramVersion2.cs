using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class ProgramVersion2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter file path to read from:");
            string inputFilePath = Console.ReadLine();

            Dictionary<string, int> dictionary = readFileINtoDictionary(inputFilePath);

            Console.WriteLine("Enter file path to write result into:");
            string outputFilePath = Console.ReadLine();
            bool result = printDictionaryIntoFile(outputFilePath, dictionary);
            Console.WriteLine("Writing result into output file {0}",(result) ?"succeeded":"failed");
        }

        public static Dictionary<string, int> readFileINtoDictionary(string filePath)
        {
            Dictionary<string, int> textDictionary = new Dictionary<string, int>();
            string textInFile;
            var fileStream = new FileStream(@""+filePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                textInFile = streamReader.ReadToEnd();
            }

            string[] textInput = textInFile.Split(new string[] { " ", ",", ".", "!", "?", ";", ":", "(", ")", "[", "]", "<", ">", "\n", "\t", "\r", "{", "}", "\"", "\'", "\\", "/", "=", "-", "_" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < textInput.Length; i++)
            {
                if (textDictionary.ContainsKey(textInput[i]))
                {
                    textDictionary[textInput[i]]++;
                }
                else
                {
                    textDictionary.Add(textInput[i], 1);
                }
            }//for
            return textDictionary;
        }

        public static string putDictionaryIntoString(Dictionary<string, int> dictionary)
        {
            StringBuilder result = new StringBuilder(dictionary.Count*5);
            foreach (string key in dictionary.Keys)
            {
                result.Append($"Number of mentions of {key} = {dictionary[key]}\r\n");
            }
            return result.ToString();
        }

        public static bool printDictionaryIntoFile(string filePath, Dictionary<string, int> dictionary)
        {
            string fileContent = putDictionaryIntoString(dictionary);
            var fileStream = new FileStream(@"" + filePath, FileMode.OpenOrCreate, FileAccess.Write);
            using (var streamReader = new StreamWriter(fileStream, Encoding.UTF8))
            {
                streamReader.WriteLine(fileContent);
            }
            return true;
        }
    }//class
}
