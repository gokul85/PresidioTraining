using System.Runtime.Serialization;

namespace DoctorPatient.Exceptions
{
    public class NoDoctorsFoundException : Exception
    {
        string msg;
        public NoDoctorsFoundException()
        {
            msg = "No Doctors Found Exception";
        }
        public override string Message => msg;
    }
}