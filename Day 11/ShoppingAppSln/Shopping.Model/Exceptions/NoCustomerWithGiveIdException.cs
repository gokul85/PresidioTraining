﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model.Exceptions
{
    public class NoCustomerWithGiveIdException : Exception
    {
        string message;
        public NoCustomerWithGiveIdException()
        {
            message = "Customer with the given Id is not present";
        }
        public override string Message => message;
    }
}