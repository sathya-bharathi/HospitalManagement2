
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Models
{
    public partial class HMContext : DbContext
    {
        public HMContext()
        {
        }

        public HMContext(DbContextOptions<HMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<AppointmentBooking> AppointmentBookings { get; set; } = null!;
        public virtual DbSet<DoctorRegistration> DoctorRegistrations { get; set; } = null!;
        public virtual DbSet<PatientRegistration> PatientRegistrations { get; set; } = null!;
        public virtual DbSet<Specialization> Specializations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=HM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__Admins__7ED91ACF0257899A");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppointmentBooking>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("PK__Appointm__8ECDFCC2C963167F");

                entity.Property(e => e.AppointmentId).ValueGeneratedNever();

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.AppointmentTime).HasColumnType("datetime");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.AppointmentBookings)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Appointme__Docto__2D27B809");
            });

            modelBuilder.Entity<DoctorRegistration>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__DoctorRe__7ED91ACF3600CBC8");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.DoctorRegistrations)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK__DoctorReg__Speci__2A4B4B5E");
            });

            modelBuilder.Entity<PatientRegistration>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__PatientR__7ED91ACF3EBD7D53");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.Property(e => e.SpecializationId).ValueGeneratedNever();

                entity.Property(e => e.SpecilizationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
