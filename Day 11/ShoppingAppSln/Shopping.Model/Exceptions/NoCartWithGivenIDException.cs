using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model.Exceptions
{
    public class NoCartWithGivenIDException :Exception
    {
        string msg;
        public NoCartWithGivenIDException()
        {
            msg = "No cart with the given ID Found";
        }
        public override string Message => msg;
    }
}
