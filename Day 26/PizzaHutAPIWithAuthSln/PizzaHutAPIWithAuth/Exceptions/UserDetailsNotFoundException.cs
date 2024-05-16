using System.Runtime.Serialization;

namespace PizzaHutAPIWithAuth.Exceptions
{
    [Serializable]
    internal class UserDetailsNotFoundException : Exception
    {
        public UserDetailsNotFoundException()
        {
        }

        public UserDetailsNotFoundException(string? message) : base(message)
        {
        }

        public UserDetailsNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserDetailsNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}