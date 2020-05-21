using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.Models
{
    public class CodeFirstContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription  { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
        public DbSet<Medicament> Medicament { get; set; }

        public CodeFirstContext(DbContextOptions<CodeFirstContext>options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity=>
            {
                entity.HasKey(e => e.IdPatient).HasName("Patient_PK");
                entity.Property(e => e.IdPatient).ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Birthdate).IsRequired();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
                entity.Property(e => e.IdPrescription).ValueGeneratedNever();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();
                entity.HasOne(d => d.Patient).WithMany(p => p.Prescriptions).HasForeignKey(f => f.IdPatient).OnDelete(DeleteBehavior.ClientNoAction).HasConstraintName("Prescription_Patient");
                entity.HasOne(d => d.Doctor).WithMany(p => p.Prescriptions).HasForeignKey(f => f.IdDoctor).OnDelete(DeleteBehavior.ClientNoAction).HasConstraintName("Prescription_Doctor");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor).HasName("Doctor_PK");
                entity.Property(e => e.IdDoctor).ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
            });
            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.ToTable("Prescription_Medicament");
                entity.HasKey(e => e.IdPresMed).HasName("IdPresMed_PK");
                entity.HasKey(e => e.IdPrescription).HasName("IdPrescription_PK");
                entity.HasKey(e => e.IdMedicament).HasName("IdMedicament_PK");
                entity.Property(e => e.IdMedicament).ValueGeneratedNever();
                entity.Property(e => e.Dose).IsRequired();
                entity.Property(e => e.Details).HasMaxLength(100).IsRequired();

                entity.HasOne(d => d.Medicament).WithMany(j=>j.PrescriptionsMed).HasForeignKey(f => f.IdMedicament).OnDelete(DeleteBehavior.ClientNoAction).HasConstraintName("PrescriptionMed_Medicament");
                entity.HasOne(d => d.Prescription).WithMany(j=>j.PrescriptionsMed).HasForeignKey(f => f.IdPrescription).OnDelete(DeleteBehavior.ClientNoAction).HasConstraintName("PrescriptionMed_Prescription");


            });
            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament).HasName("Medicament_PK");
                entity.Property(e => e.IdMedicament).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(100).IsRequired();


            });
        }
    }
}
