using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks3Solutions
{
    class CourseNotFound:Exception
    {
        public CourseNotFound(string message):base(message)
        {}
    }
}
