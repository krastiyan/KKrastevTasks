using System;
using System.Collections.Generic;

namespace PhoneBookApp
{
    public class PhoneBook
    {
        public string FilePath { get; set; }
        public List<Person> people { get; set; }
        public DateTime PhoneBookLastChanged { get; set; }
        public DateTime PhoneBookFileLastChanged { get; set; }
    }
}