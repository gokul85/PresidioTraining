using System;
using System.Collections.Generic;

namespace HMS.DAL.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int? DocId { get; set; }
        public string? DocName { get; set; }
        public string? Specialization { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
