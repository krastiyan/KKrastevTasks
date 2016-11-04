using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks3Solutions
{
    public class Class2
    {
        public static void Main(string[] args)
        {
            List<Person> personsList = new List<Person>();
            string userInput, quitCommand = "quit";
            Person personToAdd = null;
            do
            {
                Console.Write("\nPlease enter person's name /quit to exit/:");
                userInput = Console.ReadLine();
                if (!userInput.Equals(quitCommand))
                {
                    string[] parsedInput = userInput.Split(new string[] { "//" }, StringSplitOptions.None);
                    Console.WriteLine($"\nparsedInput.size = {parsedInput.Length}\nparsedInput[0]={parsedInput[0]} && parsedInput[1]={parsedInput[1]}");
                    Console.ReadKey();
                    string nameInput = parsedInput[0];
                    int ageInput;
                    if (int.TryParse(parsedInput[1], out ageInput))
                    {
                        Console.WriteLine("Successfully added age value :)");
                    }
                    else
                    {
                        Console.WriteLine("Could NOT add age value ):");
                    }
                    personToAdd = new Person(nameInput, ageInput);
                    personsList.Add(personToAdd);
                    Console.WriteLine($"\nNew Person created with name {personToAdd.Name} and age {personToAdd.age}\n");
                }//if to create new Person
            } while (!userInput.Equals(quitCommand));

            personsList = personsList.OrderBy(p => p.Name.Length).ToList();

            foreach (Person person in personsList)
            {

                if (person.age > 18)
                {
                    Console.WriteLine(person.Name + "\t" + person.age);
                }
            }
        }
    }//Class2

}
