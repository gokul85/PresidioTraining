using HMS.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly dbHMSContext _context;

        public PatientRepository(dbHMSContext context)
        {
            _context = context;
        }

        public Patient Add(Patient patient)
        {
            patient.PatientId = GetNextPatientId();
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient;
        }

        public Patient Delete(int key)
        {
            var patient = _context.Patients.Find(key);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
            return patient;
        }

        public Patient Get(int key)
        {
            return _context.Patients.Find(key);
        }

        public List<Patient> GetAll()
        {
            if (_context.Patients.Count() == 0)
                return null;
            return _context.Patients.ToList();
        }

        public Patient Update(Patient patient)
        {
            var oldPatient = _context.Patients.Find(patient.PatientId);

            if (oldPatient != null)
            {
                oldPatient.PatientName = patient.PatientName;
            }
            return oldPatient;
        }

        private int GetNextPatientId()
        {
            int maxId = _context.Patients.Max(d => (int?)d.PatientId) ?? -1;
            return maxId + 1;
        }
    }
}
