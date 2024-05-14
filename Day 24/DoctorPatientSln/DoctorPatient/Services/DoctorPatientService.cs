using DoctorPatient.Exceptions;
using DoctorPatient.Interfaces;
using DoctorPatient.Models;

namespace DoctorPatient.Services
{
    public class DoctorPatientService : IDoctorServices
    {
        private readonly IRepository<int, Doctor> _repository;

        public DoctorPatientService(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Doctor>> GetDoctorBySpecilization(string specialization)
        {
            var doctors = (await _repository.GetAll()).Where(e => e.Specialization == specialization);
            if (doctors.Count() == 0)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _repository.GetAll();
            if (doctors.Count() == 0)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<Doctor> UpdateDoctorExperience(int doctorID, float experience)
        {
            var employee = await _repository.Get(doctorID);
            if (employee == null)
                throw new NoSuchDoctorFoundException();
            employee.Experience = experience;
            employee = await _repository.Update(employee);
            return employee;
        }
    }
}