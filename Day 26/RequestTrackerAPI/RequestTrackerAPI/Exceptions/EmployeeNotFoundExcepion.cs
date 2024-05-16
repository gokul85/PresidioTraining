using System.Runtime.Serialization;

namespace RequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class EmployeeNotFoundExcepion : Exception
    {
        public EmployeeNotFoundExcepion()
        {
        }

        public EmployeeNotFoundExcepion(string? message) : base(message)
        {
        }

        public EmployeeNotFoundExcepion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmployeeNotFoundExcepion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}