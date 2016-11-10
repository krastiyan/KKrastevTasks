using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    /**
     * Writes phone book content onto CLI.
     **/
    public interface IBookWriter
    {
        bool WriteInBook(List<Person> dataOfSomeone);
    }
}
