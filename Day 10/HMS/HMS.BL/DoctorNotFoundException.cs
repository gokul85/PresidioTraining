using System.Runtime.Serialization;

namespace HMS.BL
{
    public class DoctorNotFoundException : Exception
    {
        string message;
        public DoctorNotFoundException()
        {
            message = "Doctor Not Found";
        }
    }
}