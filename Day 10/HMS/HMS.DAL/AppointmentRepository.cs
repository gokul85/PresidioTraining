using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly Dictionary<int, Appointment> _appointments;

        public AppointmentRepository()
        {
            _appointments = new Dictionary<int, Appointment>();
        }

        public Appointment Add(Appointment appointment)
        {
            appointment.AppointmentId = GenerateId();
            _appointments.Add(appointment.AppointmentId, appointment);
            return appointment;
        }

        public Appointment Get(int key)
        {
            return _appointments.ContainsKey(key) ? _appointments[key] : null;
        }

        public List<Appointment> GetAll()
        {
            if (_appointments.Count == 0)
                return null;
            return new List<Appointment>(_appointments.Values);
        }

        public Appointment Update(Appointment appointment)
        {
            if (_appointments.ContainsKey(appointment.AppointmentId))
            {
                _appointments[appointment.AppointmentId] = appointment;
                return appointment;
            }
            return null;
        }

        private int GenerateId()
        {
            if (_appointments.Count == 0)
                return 1;
            int id = _appointments.Keys.Max();
            return ++id;
        }
    }
}
