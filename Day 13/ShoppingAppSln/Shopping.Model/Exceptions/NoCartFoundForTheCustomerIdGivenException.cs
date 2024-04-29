using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model.Exceptions
{
    public class NoCartFoundForTheCustomerIdGivenException : Exception
    {
        string msg;
        public NoCartFoundForTheCustomerIdGivenException()
        {
            msg = "Cart for the customer not exists";
        }
        public override string Message => msg;
    }
}