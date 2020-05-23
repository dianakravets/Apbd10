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

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    IdPatient=1,
                    FirstName="Julia",
                    LastName="Kowalska",
                    Birthdate=DateTime.Parse("2000-01-23")
                },
                new Patient
                {
                    IdPatient=2,
                    FirstName="Maciej",
                    LastName="Nowak",
                    Birthdate=DateTime.Parse("1999-06-08")

                }
                );

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
                entity.Property(e => e.IdPrescription).ValueGeneratedNever();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();
                entity.HasOne(d => d.Patient).WithMany(p => p.Prescriptions).HasForeignKey(f => f.IdPatient).OnDelete(DeleteBehavior.ClientNoAction).HasConstraintName("Prescription_Patient");
                entity.HasOne(d => d.Doctor).WithMany(p => p.Prescriptions).HasForeignKey(f => f.IdDoctor).OnDelete(DeleteBehavior.ClientNoAction).HasConstraintName("Prescription_Doctor");
            });
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    IdPrescription=01,
                    Date=DateTime.Parse("2020-03-17"),
                    DueDate=DateTime.Parse("2020-03-27"),
                    IdPatient=1,
                    IdDoctor=2
                },
                new Prescription
                {
                    IdPrescription=02,
                    Date = DateTime.Parse("2020-04-05"),
                    DueDate = DateTime.Parse("2020-05-27"),
                    IdPatient = 1,
                    IdDoctor = 1
                },
                 new Prescription
                 {
                     IdPrescription = 03,
                     Date = DateTime.Parse("2020-02-15"),
                     DueDate = DateTime.Parse("2020-04-07"),
                     IdPatient = 2,
                     IdDoctor = 1
                 }
                );

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor).HasName("Doctor_PK");
                entity.Property(e => e.IdDoctor).ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor {
                    IdDoctor=1,
                    FirstName="Kondrad",
                    LastName="Nitosz",
                    Email="kond@gmail.com"

                },
                new Doctor {
                    IdDoctor=2,
                    FirstName="Mikolaj",
                    LastName="Sikorskij",
                    Email="sikorski@gmail.com"
                },
                 new Doctor
                 {
                     IdDoctor = 3,
                     FirstName = "Katarzyna",
                     LastName = "Kowalska",
                     Email = "kk@gmail.com"
                 }
                );

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.ToTable("Prescription_Medicament");
                entity.HasKey(e => new {e.IdPrescription,e.IdMedicament });
        
                entity.Property(e => e.IdMedicament).ValueGeneratedNever();
                entity.Property(e => e.Dose).IsRequired();
                entity.Property(e => e.Details).HasMaxLength(100).IsRequired();

                entity.HasOne(d => d.Medicament).WithMany(j=>j.PrescriptionsMed).HasForeignKey(f => f.IdMedicament).OnDelete(DeleteBehavior.ClientNoAction).HasConstraintName("PrescriptionMed_Medicament");
                entity.HasOne(d => d.Prescription).WithMany(j=>j.PrescriptionsMed).HasForeignKey(f => f.IdPrescription).OnDelete(DeleteBehavior.ClientNoAction).HasConstraintName("PrescriptionMed_Prescription");


            });

            modelBuilder.Entity<PrescriptionMedicament>().HasData(
                new PrescriptionMedicament
                {
                    IdMedicament=1,
                    IdPrescription=02,
                    Dose=2,
                    Details="wiecorem"
                },
                new PrescriptionMedicament
                {
                    IdMedicament=2,
                    IdPrescription=01,
                    Dose=3,
                    Details="codzienie"
                }
                );


            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament).HasName("Medicament_PK");
                entity.Property(e => e.IdMedicament).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(100).IsRequired();


            });

            modelBuilder.Entity<Medicament>().HasData(
                 new Medicament
                 {
                     IdMedicament=1,
                     Name="Thicodin",
                     Description="kaszel",
                     Type="w"
                 },
                 new Medicament
                 {
                     IdMedicament=2,
                     Name="ACC",
                     Description="kaszel",
                     Type="e"

                 }
                );
        }
    }
}
