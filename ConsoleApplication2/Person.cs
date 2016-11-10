using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class Person
    {
        private static System.Collections.Generic.HashSet<string> PeoplePhones = new System.Collections.Generic.HashSet<string>();

        public string Names { get; set; }
        public string Town { get; set; }
        public string PhoneNumber { get; set; }

        public Person(string names, string town, string phoneNumber)
        {
            if(!PeoplePhones.Add(phoneNumber))
            {
                throw new InvalidOperationException($"Person with phone number {phoneNumber} already present in phone book!");
            }
            this.Names = names;
            this.Town = town;
            this.PhoneNumber = phoneNumber;
    }
}
}
