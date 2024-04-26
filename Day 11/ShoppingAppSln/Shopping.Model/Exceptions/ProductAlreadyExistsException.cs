using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model.Exceptions
{
    public class ProductAlreadyExistsException : Exception
    {
        string msg;
        public ProductAlreadyExistsException()
        {
            msg = "Product Already Exists";
        }
        public override string Message => msg;
    }
}
