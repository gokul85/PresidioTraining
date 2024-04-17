using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly Dictionary<int, Patient> _patients;

        public PatientRepository()
        {
            _patients = new Dictionary<int, Patient>();
        }

        public Patient Add(Patient patient)
        {
            if (_patients.ContainsValue(patient))
            {
                return null;
            }
            patient.PatientId = GenerateId();
            _patients.Add(patient.PatientId, patient);
            return patient;
        }

        public Patient Delete(int key)
        {
            if (_patients.ContainsKey(key))
            {
                var removedPatient = _patients[key];
                _patients.Remove(key);
                return removedPatient;
            }
            return null;
        }

        public Patient Get(int key)
        {
            return _patients.ContainsKey(key) ? _patients[key] : null;
        }

        public List<Patient> GetAll()
        {
            if (_patients.Count == 0)
                return null;
            return new List<Patient>(_patients.Values);
        }

        public Patient Update(Patient patient)
        {
            if (_patients.ContainsKey(patient.PatientId))
            {
                _patients[patient.PatientId] = patient;
                return patient;
            }
            return null;
        }

        private int GenerateId()
        {
            if (_patients.Count == 0)
                return 1;
            int id = _patients.Keys.Max();
            return ++id;
        }
    }
}
