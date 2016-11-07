using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DelegatesAndEnumerations.Program;

namespace DelegatesAndEnumerations
{
    class OperationFactory
    {
        public static OperationToDo GiveMeOperation(Operations operationType)
        {
            OperationToDo operationDone = null;
            switch (operationType)
            {
                case Operations.add: operationDone += Program.add; break;
                case Operations.sub: operationDone += Program.subtract; break;
                case Operations.mul: operationDone += Program.multiply; break;
            }
            return operationDone;
        }
    }
}
