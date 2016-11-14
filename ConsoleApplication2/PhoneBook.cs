using System;
using System.Collections.Generic;

namespace PhoneBookApp
{
    public class PhoneBook
    {
        /**
         * Used to control not to duplicate people by their Unique ID.
         **/
        private static System.Collections.Generic.HashSet<string> PeoplePhones = new System.Collections.Generic.HashSet<string>();

        public string FilePath { get; set; }
        public List<Person> people
        {
            get
            {
                return new List<Person>(people);
            }
            set
            {
                if (value == null || value.Count < 1)
                {
                    throw new ArgumentOutOfRangeException($"Null or empty list of people provided!");
                }
                if(people == null)
                {
                    people = new List<Person>(value.Count);
                }
                foreach(Person someone in value)
                {
                    if (!PeoplePhones.Add(someone.PhoneNumber))
                    {
                        throw new InvalidOperationException($"Person with phone number {someone.PhoneNumber} already present in this phone book!");
                    }
                    people.Add(someone);
                }
            }
        }
        public DateTime PhoneBookLastChanged { get; set; }
        public DateTime PhoneBookFileLastChanged { get; set; }
    }
}