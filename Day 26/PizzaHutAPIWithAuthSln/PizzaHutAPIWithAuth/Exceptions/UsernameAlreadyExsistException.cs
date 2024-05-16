using System.Runtime.Serialization;

namespace PizzaHutAPIWithAuth.Exceptions
{
    [Serializable]
    internal class UsernameAlreadyExsistException : Exception
    {
        public UsernameAlreadyExsistException()
        {
        }

        public UsernameAlreadyExsistException(string? message) : base(message)
        {
        }

        public UsernameAlreadyExsistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UsernameAlreadyExsistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}