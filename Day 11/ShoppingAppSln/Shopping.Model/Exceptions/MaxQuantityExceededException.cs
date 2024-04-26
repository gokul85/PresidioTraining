using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model.Exceptions
{
    public class MaxQuantityExceededException :Exception
    {
        string msg;
        public MaxQuantityExceededException()
        {
            msg = "Maximum Cart Quantity Reached";
        }
        public override string Message => msg;
    }
}
