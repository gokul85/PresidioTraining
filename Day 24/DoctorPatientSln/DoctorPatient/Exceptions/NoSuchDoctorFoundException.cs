using System.Runtime.Serialization;

namespace DoctorPatient.Exceptions
{
    public class NoSuchDoctorFoundException : Exception
    {
        string msg;
        public NoSuchDoctorFoundException()
        {
            msg = "No Such Doctor Found";
        }
        public override string Message => msg;
    }
}