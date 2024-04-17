using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HMS.Model
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
