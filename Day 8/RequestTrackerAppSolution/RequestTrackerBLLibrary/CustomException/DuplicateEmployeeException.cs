using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.CustomException
{
    public class DuplicateEmployeeException : Exception
    {
        string msg;
        public DuplicateEmployeeException()
        {
            msg = "Employe already exists";
        }
        public override string Message => msg;
    }
}
