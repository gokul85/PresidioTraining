using HMS.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly dbHMSContext _context;

        public AppointmentRepository(dbHMSContext context)
        {
            _context = context;
        }

        public Appointment Add(Appointment appointment)
        {
            appointment.AppointmentId = GetNextAppointmentId();
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public Appointment Delete(int key)
        {
            var appointment = _context.Appointments.Find(key);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
            return appointment;
        }

        public Appointment Get(int key)
        {
            return _context.Appointments.Find(key);
        }

        public List<Appointment> GetAll()
        {
            if (_context.Appointments.Count() == 0)
                return null;
            return _context.Appointments.ToList();
        }

        public Appointment Update(Appointment appointment)
        {
            var oldAppointment = _context.Appointments.Find(appointment.AppointmentId);

            if (oldAppointment != null)
            {
                oldAppointment.AppointmentDate = appointment.AppointmentDate;
                oldAppointment.DocId = appointment.DocId;
                oldAppointment.PatientId = appointment.PatientId;
                _context.SaveChanges();
            }

            return oldAppointment;
        }

        private int GetNextAppointmentId()
        {
            int maxId = _context.Appointments.Max(d => (int?)d.AppointmentId) ?? -1;
            return maxId + 1;
        }
    }
}
