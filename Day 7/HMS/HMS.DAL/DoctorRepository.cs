using System.Numerics;
using HMS.Model;
namespace HMS.DAL
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly Dictionary<int, Doctor> _doctors;

        public DoctorRepository()
        {
            _doctors = new Dictionary<int, Doctor>();
        }

        public Doctor Add(Doctor doctor)
        {
            if (_doctors.ContainsValue(doctor))
            {
                return null;
            }
            doctor.DoctorId = GenerateId();
            _doctors.Add(doctor.DoctorId, doctor);
            return doctor;
        }

        public Doctor Delete(int key)
        {
            if (_doctors.ContainsKey(key))
            {
                var removedDoctor = _doctors[key];
                _doctors.Remove(key);
                return removedDoctor;
            }
            return null;
        }

        public Doctor Get(int key)
        {
            return _doctors.ContainsKey(key) ? _doctors[key] : null;
        }

        public List<Doctor> GetAll()
        {
            if (_doctors.Count == 0)
                return null;
            return new List<Doctor>(_doctors.Values);
        }

        public Doctor Update(Doctor doctor)
        {
            if (_doctors.ContainsKey(doctor.DoctorId))
            {
                _doctors[doctor.DoctorId] = doctor;
                return doctor;
            }
            return null;
        }

        private int GenerateId()
        {
            if (_doctors.Count == 0)
                return 1;
            int id = _doctors.Keys.Max();
            return ++id;
        }
    }
}
