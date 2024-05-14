using System.ComponentModel.DataAnnotations;

namespace DoctorPatient.Models
{
    public class Doctor
    {
        [Key]
        public int DocId { get; set; }
        public string DocName { get; set; }
        public string Specialization { get; set; }
        public float Experience { get; set; }
    }
}
