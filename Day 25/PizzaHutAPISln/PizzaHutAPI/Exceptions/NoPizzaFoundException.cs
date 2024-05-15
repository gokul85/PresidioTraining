namespace PizzaHutAPI.Exceptions
{
    public class NoPizzaFoundException :Exception
    {
        string msg;
        public NoPizzaFoundException()
        {
            msg = "No Pizza Found";
        }
        public override string Message => msg;
    }
}
