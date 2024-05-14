using DoctorPatient.Models;

namespace DoctorPatient.Interfaces
{
    public interface IDoctorServices
    {
        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task<Doctor> UpdateDoctorExperience(int doctorID, float experience);
        public Task<IEnumerable<Doctor>> GetDoctorBySpecilization(string specialization);
    }
}