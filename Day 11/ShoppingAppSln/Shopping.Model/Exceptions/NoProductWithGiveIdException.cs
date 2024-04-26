using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model.Exceptions
{
    public class NoProductWithGiveIdException :Exception
    {
        string message;
        public NoProductWithGiveIdException()
        {
            message = "Product with the given Id is not present";
        }
        public override string Message => message;
    }
}
