using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    /**
     * Reads phone book content from file.
     **/
    public interface IFileBookReader: IBookReader
    {
        List<Person> ReadFromBook(string pathToBookFile);
    }
}
