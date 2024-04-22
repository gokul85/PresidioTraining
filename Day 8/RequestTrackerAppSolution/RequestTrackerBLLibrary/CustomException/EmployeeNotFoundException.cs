using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.CustomException
{
    public class EmployeeNotFoundException : Exception
    {
        string msg;
        public EmployeeNotFoundException()
        {
            msg = "Employe Not Found Exception";
        }
        public override string Message => msg;
    }
}
