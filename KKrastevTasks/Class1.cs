using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKrastevTasks
{
    public class Person
    {
        //Resolving task 1 and 2

        protected string name;
        public int age;

        public string Name { get { return name; } set { name = value; } }

        public Person()
        {
            name = "No name";
            age = 1;
        }

        public Person(string givenName) : this()
        {
            name = givenName;
        }

        public Person(string givenName, int personAge) : this(givenName)
        {
            if (personAge < 0) throw new InvalidOperationException($"Ivalid age provided: {personAge}");
            age = personAge;

        }
    }

    public class Class1
    {
        static void Main(string[] args)
        {
            //Resolving tasks 1 and 2 together

            Console.Write("\nPlease enter person's name:");
            string nameInput = Console.ReadLine();
            Console.Write("\nPlease enter person's age:");
            //int ageInput = int.Parse(Console.ReadLine());
            int ageInput;
            if (int.TryParse(Console.ReadLine(), out ageInput)) {
                Console.WriteLine("Successfully added age value :)");
            } else
            {
                Console.WriteLine("Could NOT add age value ):");
            }
            Person object1, object2, object3;
            object1 = new Person();
            object2 = new Person(nameInput);
            object3 = new Person(nameInput, ageInput);
            Console.WriteLine($"1st Person data: name {object1.Name} age {object1.age}");
            Console.WriteLine($"2nd Person data: name {object2.Name} age {object2.age}");
            Console.WriteLine($"3rd Person data: name {object3.Name} age {object3.age}");
        }
    }//Class1

    public class Class2{
        static void Main(string[] args)
        {
            List<Person> personsList = new List<Person>();
            string userInput, quitCommand="quit";
            Person personToAdd = null;
            do
            {
                Console.Write("\nPlease enter person's name /quit to exit/:");
                userInput = Console.ReadLine();
                if (!userInput.Equals(quitCommand))
                {
                    string[] parsedInput = userInput.Split(new string[]{"//"}, StringSplitOptions.None);
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

            foreach(Person person in personsList)
            {
                
                if (person.age > 18)
                {
                    Console.WriteLine(person.Name + "\t" + person.age);
                }
            }
        }
    }//Class2

    //resolving task 5 - to be completed...

    public class CourseAttandee : Person
    {
        protected static int mStaticUniqueIdentifier = 0;

        public int incrementUniiqueIdenifier()
        {
            return ++mStaticUniqueIdentifier;
        }

        //a public property
        public int UniqueIdetifier { get; }

        public CourseAttandee(string nameInput, int ageInput) : base(nameInput, ageInput)
        {
            UniqueIdetifier = incrementUniiqueIdenifier();
        }
    }

    public class Course
    {
        public int CourseCapacity {get; set;}
        public List<CourseAttandee> attendees { get; set; }

    }

    public class Class3
    {
        static void Main(string[] args)
        {

        }
    }

    }//namespace
