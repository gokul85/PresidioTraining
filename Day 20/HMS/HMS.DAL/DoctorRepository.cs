using System.Numerics;
using HMS.DAL.Model;
namespace HMS.DAL
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly dbHMSContext _context;

        public DoctorRepository(dbHMSContext context)
        {
            _context = context;
        }

        public Doctor Add(Doctor doctor)
        {
            doctor.DocId = GetNextDoctorId();
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public Doctor Delete(int key)
        {
            var doctor = _context.Doctors.Find(key);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
            return doctor;
        }

        public Doctor Get(int key)
        {
            return _context.Doctors.Find(key);
        }

        public List<Doctor> GetAll()
        {
            if (_context.Doctors.Count() == 0)
                return null;
            return _context.Doctors.ToList();
        }

        public Doctor Update(Doctor doctor)
        {
            var oldDoctor = _context.Doctors.Find(doctor.DocId);

            if (oldDoctor != null)
            {
                oldDoctor.DocName = doctor.DocName;
                oldDoctor.Specialization = doctor.Specialization;
                oldDoctor.Appointments = doctor.Appointments;
            }
            return oldDoctor;
        }

        private int GetNextDoctorId()
        {
            int maxId = _context.Doctors.Max(d => (int?)d.DocId) ?? -1;
            return maxId + 1;
        }
    }
}
