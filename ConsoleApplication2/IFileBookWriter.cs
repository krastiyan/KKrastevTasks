using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    /**
     * Writes phone book content into file.
     **/
    public interface IFileBookWriter: IBookWriter
    {
        bool WriteInBook(List<Person> dataOfSomeone, string pathToBookFile);
    }
}
