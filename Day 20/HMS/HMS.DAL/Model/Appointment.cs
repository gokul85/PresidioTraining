using System;
using System.Collections.Generic;

namespace HMS.DAL.Model
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int? DocId { get; set; }
        public int? PatientId { get; set; }

        public virtual Doctor? Doc { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
