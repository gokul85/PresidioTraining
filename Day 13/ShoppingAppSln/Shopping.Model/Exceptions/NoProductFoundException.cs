using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model.Exceptions
{
    public class NoProductFoundException :Exception
    {
        string msg;
        public NoProductFoundException()
        {
            msg = "No Product Found";
        }
        public override string Message => msg;
    }
}
