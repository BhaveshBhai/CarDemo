using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLibrary.EntityModels
{
    public partial class CarsaleDBContext : DbContext
    {
        public CarsaleDBContext()
        {
        }

        public CarsaleDBContext(DbContextOptions<CarsaleDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BodyType> BodyType { get; set; }
        public virtual DbSet<VehicleDetail> VehicleDetail { get; set; }
        public virtual DbSet<VehicleType> VehicleType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CarsaleDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<BodyType>(entity =>
            {
                entity.HasKey(e => e.BodyId);

                entity.Property(e => e.BodyId).HasColumnName("Body_id");

                entity.Property(e => e.BodyName).HasMaxLength(500);

                entity.Property(e => e.VehicleId).HasColumnName("Vehicle_Id");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.BodyType)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_BodyType_VehicleType");
            });

            modelBuilder.Entity<VehicleDetail>(entity =>
            {
                entity.HasKey(e => e.VehicleDetailsId);

                entity.Property(e => e.VehicleDetailsId).HasColumnName("VehicleDetails_Id");

                entity.Property(e => e.BodyTypeId).HasColumnName("BodyType_id");

                entity.Property(e => e.Engine).HasMaxLength(50);

                entity.Property(e => e.Make).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.VehicleId).HasColumnName("Vehicle_id");

                entity.HasOne(d => d.BodyType)
                    .WithMany(p => p.VehicleDetail)
                    .HasForeignKey(d => d.BodyTypeId)
                    .HasConstraintName("FK_VehicleDetail_BodyType");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehicleDetail)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_VehicleDetail_VehicleType");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.HasKey(e => e.VehicleId);

                entity.Property(e => e.VehicleId).HasColumnName("Vehicle_Id");

                entity.Property(e => e.Name).HasMaxLength(500);
            });
        }
    }
}
