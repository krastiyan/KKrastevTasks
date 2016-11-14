using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class Person
    {
        public string Names { get; set; }
        public string Town { get; set; }
        public string PhoneNumber { get; set; }

        public Person(string names, string town, string phoneNumber)
        {
            this.Names = names;
            this.Town = town;
            this.PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return Names + PhoneBookParser.PersonDataSeparator
                + Town + PhoneBookParser.PersonDataSeparator
                + PhoneNumber;
        }
    }
}
