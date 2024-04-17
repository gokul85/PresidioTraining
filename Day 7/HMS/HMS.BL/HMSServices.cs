using HMS.Model;
using HMS.DAL;

namespace HMS.BL
{
    public class HMSService : IService
    {
        private readonly IRepository<int, Doctor> _doctorRepository;
        private readonly IRepository<int, Patient> _patientRepository;
        private readonly IRepository<int, Appointment> _appointmentRepository;

        public HMSService(IRepository<int, Doctor> doctorRepo, IRepository<int, Patient> patientRepo, IRepository<int, Appointment> appointmentRepo)
        {
            _doctorRepository = doctorRepo;
            _patientRepository = patientRepo;
            _appointmentRepository = appointmentRepo;
        }

        public Appointment CreateAppointment(Doctor doctor, Patient patient, DateTime appointmentDateTime)
        {
            Appointment appointment = new Appointment { Doctor = doctor, Patient = patient, AppointmentDateTime = appointmentDateTime };
            appointment = _appointmentRepository.Add(appointment);
            doctor.Appointments.Add(appointment);
            patient.Appointments.Add(appointment);
            return appointment;
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAll();
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            return _doctorRepository.Add(doctor);
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            return _doctorRepository.Update(doctor);
        }

        public bool DeleteDoctor(int doctorId)
        {
            Doctor doctor = _doctorRepository.Get(doctorId);
            if (doctor != null)
            {
                return _doctorRepository.Delete(doctorId) != null;
            }
            return false;
        }

        public Patient AddPatient(Patient patient)
        {
            return _patientRepository.Add(patient);
        }

        public List<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll();
        }

        public Patient UpdatePatient(Patient patient)
        {
            return _patientRepository.Update(patient);
        }

        public bool DeletePatient(int patientId)
        {
            Patient patient = _patientRepository.Get(patientId);
            if (patient != null)
            {
                return _patientRepository.Delete(patientId) != null;
            }
            return false;
        }

        public Appointment UpdateAppointment(int appointmentId, DateTime appointmentDateTime)
        {
            Appointment appointment = _appointmentRepository.Get(appointmentId);
            if (appointment != null)
            {
                appointment.AppointmentDateTime = appointmentDateTime;
                return _appointmentRepository.Update(appointment);
            }
            return null;
        }

        public List<Appointment> GetAllAppointmentsByDoctor(int doctorId)
        {
            Doctor doctor = _doctorRepository.Get(doctorId);
            if (doctor != null)
            {
                return doctor.Appointments;
            }
            return new List<Appointment>();
        }

        public List<Appointment> GetAllAppointmentsByPatient(int patientId)
        {
            Patient patient = _patientRepository.Get(patientId);
            if (patient != null)
            {
                return patient.Appointments;
            }
            return new List<Appointment>();
        }
    }
}
