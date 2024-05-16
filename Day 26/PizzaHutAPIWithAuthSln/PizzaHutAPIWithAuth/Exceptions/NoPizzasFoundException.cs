using System.Runtime.Serialization;

namespace PizzaHutAPIWithAuth.Exceptions
{
    internal class NoPizzasFoundException : Exception
    {
        string msg;
        public NoPizzasFoundException()
        {
            msg = "No Pizzas Found Exception";
        }
        public NoPizzasFoundException(string msge)
        {
            msg = msge;
        }
        public override string Message => msg;
    }
}