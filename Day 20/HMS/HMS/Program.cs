using HMS.BL;
using HMS.DAL.Model;
using HMS.DAL;
using System.Xml.Serialization;
namespace HMS
{
    public class Program
    {
        static IService hmsService;

        static void AddDoctor()
        {
            int c;
            do
            {
                Console.Write("Enter doctor's name: ");
                string doctorName = Console.ReadLine();
                Console.Write("Enter doctor's specialization: ");
                string doctorSpecialization = Console.ReadLine();
                hmsService.AddDoctor(doctorName,doctorSpecialization);
                Console.WriteLine("Doctor added successfully.\n1 - Add more\n0 - Go back");
                c = Convert.ToInt32(Console.ReadLine());
            } while (c != 0);
        }

        static void AddPatient()
        {
            int c;
            do
            {
                Console.Write("Enter patient's name: ");
                string patientName = Console.ReadLine();
                hmsService.AddPatient(patientName);
                Console.WriteLine("Patient added successfully.\n1 - Add more\n0 - Go back");
                c = Convert.ToInt32(Console.ReadLine());
            } while (c != 0);
        }

        static void ScheduleAppointment()
        {
            Console.WriteLine("Select a doctor:");
            var doctors = hmsService.GetAllDoctors();
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"{doctor.DocId}. {doctor.DocName} ({doctor.Specialization})");
            }
            Console.Write("Enter the number corresponding to the doctor: ");
            int selectedDoctorIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Select a patient:");
            var patients = hmsService.GetAllPatients();
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.PatientId}. {patient.PatientName}");
            }
            Console.Write("Enter the number corresponding to the patient: ");
            int selectedPatientIndex = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Enter appointment date and time (yyyy-mm-dd hh:mm:ss): ");
            DateTime appointmentDateTime = DateTime.Parse(Console.ReadLine());

            hmsService.CreateAppointment(selectedDoctorIndex, selectedPatientIndex, appointmentDateTime);
            Console.WriteLine("Appointment scheduled successfully.");
        }

        static void DisplayAllAppointments()
        {
            Console.WriteLine("\nAll Appointments:");
            foreach (var appointment in hmsService.GetAllAppointments())
            {
                Console.WriteLine($"ID: {appointment.AppointmentId}, Doctor: {appointment.Doc.DocName}, Patient: {appointment.Patient.PatientName}, DateTime: {appointment.AppointmentDate}");
            }
        }

        static void DisplayAllDoctors()
        {
            Console.WriteLine("\nAll Doctors:");
            foreach (var doctor in hmsService.GetAllDoctors())
            {
                Console.WriteLine($"ID: {doctor.DocId}, Doctor Name: {doctor.DocName}, Specialization: {doctor.Specialization}");
            }
        }

        static void DisplayAllPatients()
        {
            Console.WriteLine("\nAll Patients:");
            foreach (var patient in hmsService.GetAllPatients())
            {
                Console.WriteLine($"ID: {patient.PatientId}, Patient Name: {patient.PatientName}");
            }
        }

        static void DisplayAppointmentsByDoctor()
        {
            DisplayAllDoctors();
            Console.Write("Enter doctor's ID: ");
            int doctorId = int.Parse(Console.ReadLine());
            var appointments = hmsService.GetAllAppointmentsByDoctor(doctorId);
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found for the specified doctor.");
            }
            else
            {
                Console.WriteLine("\nAppointments for the specified doctor:");
                foreach (var appointment in appointments)
                {
                    Console.WriteLine($"Patient: {appointment.Patient.PatientName}, DateTime: {appointment.AppointmentDate}");
                }
            }
        }

        static void DisplayAppointmentsByPatient()
        {
            DisplayAllPatients();
            Console.Write("Enter patient's ID: ");
            int patientId = int.Parse(Console.ReadLine());
            var appointments = hmsService.GetAllAppointmentsByPatient(patientId);
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found for the specified patient.");
            }
            else
            {
                Console.WriteLine("\nAppointments for the specified patient:");
                foreach (var appointment in appointments)
                {
                    Console.WriteLine($"Doctor: {appointment.Doc.DocName}, DateTime: {appointment.AppointmentDate}");
                }
            }
        }
        static void UpdateAppointment()
        {
            DisplayAllAppointments();
            Console.Write("Enter appointment ID to update: ");
            int appointmentId = int.Parse(Console.ReadLine());
            Console.Write("Enter new appointment date and time (yyyy-mm-dd hh:mm:ss): ");
            DateTime newDateTime = DateTime.Parse(Console.ReadLine());
            hmsService.UpdateAppointment(appointmentId, newDateTime);
            Console.WriteLine("Appointment updated successfully.");
        }

        static void Main(string[] args)
        {
            dbHMSContext context = new dbHMSContext();
            IRepository<int, Doctor> doctorRepository = new DoctorRepository(context);
            IRepository<int, Patient> patientRepository = new PatientRepository(context);
            IRepository<int, Appointment> appointmentRepository = new AppointmentRepository(context);

            hmsService = new HMSService(doctorRepository, patientRepository, appointmentRepository);

            int choice;
            do
            {
                Console.WriteLine("\nHospital Management System Menu:");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Add Patient");
                Console.WriteLine("3. Schedule Appointment");
                Console.WriteLine("4. Display all Appointments");
                Console.WriteLine("5. Display all Doctors");
                Console.WriteLine("6. Display all Patients");
                Console.WriteLine("7. Display Appointments by Doctor");
                Console.WriteLine("8. Display Appointments by Patient");
                Console.WriteLine("9. Update Appointment");
                Console.WriteLine("0. Exit");
                Console.Write("Please enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddDoctor();
                        break;

                    case 2:
                        AddPatient();
                        break;

                    case 3:
                        ScheduleAppointment();
                        break;

                    case 4:
                        DisplayAllAppointments();
                        break;

                    case 5:
                        DisplayAllDoctors();
                        break;

                    case 6:
                        DisplayAllPatients();
                        break;

                    case 7:
                        DisplayAppointmentsByDoctor();
                        break;

                    case 8:
                        DisplayAppointmentsByPatient();
                        break;

                    case 9:
                        UpdateAppointment();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            } while (choice != 0);
        }
    }
}
