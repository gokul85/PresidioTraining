using System.Runtime.Serialization;

namespace RequestTrackerBLLib
{
    [Serializable]
    internal class DuplicateDepartmentNameException : Exception
    {
        public DuplicateDepartmentNameException()
        {
        }

        public DuplicateDepartmentNameException(string? message) : base(message)
        {
        }

        public DuplicateDepartmentNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DuplicateDepartmentNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}