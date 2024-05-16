using System.Runtime.Serialization;

namespace RequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class NoUserFoundExecption : Exception
    {
        public NoUserFoundExecption()
        {
        }

        public NoUserFoundExecption(string? message) : base(message)
        {
        }

        public NoUserFoundExecption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoUserFoundExecption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}