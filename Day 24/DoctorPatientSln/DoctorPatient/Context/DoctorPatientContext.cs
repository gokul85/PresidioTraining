using Microsoft.EntityFrameworkCore;
using System.Numerics;
using DoctorPatient.Models;

namespace DoctorPatient.Context
{
    public class DoctorPatientContext : DbContext
    {
        public DoctorPatientContext(DbContextOptions<DoctorPatientContext> options) : base(options)
        {
        }
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                               new Doctor { DocId = 1, DocName = "Ram", Specialization = "Cardiologist", Experience = 1.5f },
                               new Doctor { DocId = 2, DocName = "Raj", Specialization = "Orthologist", Experience = 2.5f },
                               new Doctor { DocId = 3, DocName = "Rahul", Specialization = "Neurologist", Experience = 3.5f }
            );
        }
    }
}
