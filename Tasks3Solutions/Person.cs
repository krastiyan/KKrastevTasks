using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks3Solutions
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
            if (personAge < 0) throw new PersonAgeException($"Ivalid age provided: {personAge}");
            age = personAge;

        }
    }

}
