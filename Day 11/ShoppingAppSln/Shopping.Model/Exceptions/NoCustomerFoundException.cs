using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model.Exceptions
{
    public class NoCustomerFoundException :Exception
    {
        string msg;
        public NoCustomerFoundException()
        {
            msg = "No Customer Found";
        }
        public override string Message => msg;
    }
}
