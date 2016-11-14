using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    class PhoneBookParser
    {
        public const string PersonDataSeparator = " | ";
        public static readonly string[] FileRowsSplitParameter = new string[] { "\r", "\n" };

        public static Person ParsePersonData(string personData)
        {
            string[] PersonData = personData.Split(new string[] { PersonDataSeparator }, StringSplitOptions.RemoveEmptyEntries);
            if (PersonData.Length < 3)
            {
                throw new FormatException("Person data with incorrect format provided: " + personData);
            }
            return new Person(PersonData[0].Trim(), PersonData[1].Trim(), PersonData[2].Trim());
        }

        public static string ParsePersonDataToPhoneBookFileRow(Person aPerson)
        {
            StringBuilder result = new StringBuilder(100);
            result.Append(aPerson.Names);
            result.Append("\t|\t");
            result.Append(aPerson.Town);
            result.Append("\t|\t");
            result.Append(aPerson.PhoneNumber);
            return result.ToString();
        }
    }
}
