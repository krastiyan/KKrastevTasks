using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> textDictionary = new Dictionary<string, int>();
            Console.WriteLine("Enter your text:");
            string[] textInput = Console.ReadLine().Split(new string[] { " ", ",", ".", "!", "?", ";", ":", "(", ")", "[", "]", "<", ">"}, StringSplitOptions.RemoveEmptyEntries);
            for (int i=0;i<textInput.Length;i++)
            {
                if (textDictionary.ContainsKey(textInput[i]))
                {
                    textDictionary[textInput[i]]++;
                }
                else
                {
                    textDictionary.Add(textInput[i], 1);
                }
            }

            Console.WriteLine("\nDone reading\n");
            foreach(string key in textDictionary.Keys)
            {
                Console.WriteLine($"Number of mentions of {key} = {textDictionary[key]}");
            }
        }
    }
}
