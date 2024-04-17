using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Model;

namespace HMS.BL
{
    public interface IService
    {
        Appointment CreateAppointment(Doctor doctor, Patient patient, DateTime appointmentDateTime);
        List<Appointment> GetAllAppointments();
        Doctor AddDoctor(Doctor doctor);
        List<Doctor> GetAllDoctors();
        Doctor UpdateDoctor(Doctor doctor);
        bool DeleteDoctor(int doctorId);
        Patient AddPatient(Patient patient);
        List<Patient> GetAllPatients();
        Patient UpdatePatient(Patient patient);
        bool DeletePatient(int patientId);
        Appointment UpdateAppointment(int appointmentId, DateTime appointmentDateTime);
        List<Appointment> GetAllAppointmentsByDoctor(int doctorId);
        List<Appointment> GetAllAppointmentsByPatient(int patientId);
    }
}
