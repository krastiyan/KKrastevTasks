using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    /**
     * Reads phone book content from CLI.
     **/
    public interface IBookReader
    {
        List<Person> ReadFromBook(PhoneBook aPhoneBook);
    }
}
