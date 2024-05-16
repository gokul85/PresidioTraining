using System.Runtime.Serialization;

namespace PizzaHutAPIWithAuth.Exceptions
{
    [Serializable]
    internal class UserNotActive : Exception
    {
        public UserNotActive()
        {
        }

        public UserNotActive(string? message) : base(message)
        {
        }

        public UserNotActive(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserNotActive(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}