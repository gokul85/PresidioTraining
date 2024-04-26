using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model.Exceptions
{
    public class NoCartItemFoundExeption :Exception
    {
        string msg;
        public NoCartItemFoundExeption()
        {
            msg = "No Cart Item Found with the given ID";
        }
        public override string Message => msg;
    }
}
