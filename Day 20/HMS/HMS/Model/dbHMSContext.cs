using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HMS.Model
{
    public partial class dbHMSContext : DbContext
    {
        public dbHMSContext()
        {
        }

        public dbHMSContext(DbContextOptions<dbHMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=C1RBBX3\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbHMS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("appointment_date");

                entity.Property(e => e.DocId).HasColumnName("doc_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DocId)
                    .HasConstraintName("fk_appointmentdoctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("fk_appointmentpatient");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("PK__Doctor__8AD0292411818F6C");

                entity.ToTable("Doctor");

                entity.Property(e => e.DocId).HasColumnName("doc_id");

                entity.Property(e => e.DocName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("doc_name");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("specialization");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("patient_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
