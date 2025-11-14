using Farmalitycs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Farmalitycs.Infrastructure.Context
{
    public class FarmalitycsContext : DbContext
    {
        public FarmalitycsContext(DbContextOptions<FarmalitycsContext> options)
            : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Patient)
                .WithMany(pa => pa.Prescriptions)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Medicine)
                .WithMany()
                .HasForeignKey(p => p.MedicineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasMany(p => p.Medicines)
                .WithMany(m => m.Prescriptions)
                .UsingEntity(j => j.ToTable("PrescriptionMedicines"));

            // Configuración para Sale
            modelBuilder.Entity<Sale>()
                .Property(s => s.TotalAmount)
                .HasPrecision(18, 2); // 18 dígitos, 2 decimales
        }


    }
}



