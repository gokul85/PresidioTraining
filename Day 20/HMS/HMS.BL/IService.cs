using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.DAL.Model;

namespace HMS.BL
{
    public interface IService
    {
        Appointment CreateAppointment(int doctorid, int patientid, DateTime appointmentDateTime);
        List<Appointment> GetAllAppointments();
        Doctor AddDoctor(string DocName, string DocSpec);
        List<Doctor> GetAllDoctors();
        Doctor UpdateDoctor(Doctor doctor);
        bool DeleteDoctor(int doctorId);
        Patient AddPatient(string PatientName);
        List<Patient> GetAllPatients();
        Patient UpdatePatient(Patient patient);
        bool DeletePatient(int patientId);
        Appointment UpdateAppointment(int appointmentId, DateTime appointmentDateTime);
        List<Appointment> GetAllAppointmentsByDoctor(int doctorId);
        List<Appointment> GetAllAppointmentsByPatient(int patientId);
    }
}
