namespace PizzaHutAPI.Exceptions
{
    public class NoSuchUserException :Exception
    {
        string msg;
        public NoSuchUserException()
        {
            msg = "No Employee Found";
        }
        public override string Message => msg;
    }
}
