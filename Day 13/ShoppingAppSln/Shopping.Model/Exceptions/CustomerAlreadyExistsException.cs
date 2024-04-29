using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model.Exceptions
{
    public class CustomerAlreadyExistsException : Exception
    {
        string msg;
        public CustomerAlreadyExistsException()
        {
            msg = "Customer Already Exists";
        }
        public override string Message => msg;
    }
}
