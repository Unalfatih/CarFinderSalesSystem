using System;
using System.Collections.Generic;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{

    public partial class CarFinderSalesSystemContext : DbContext
    {
        public CarFinderSalesSystemContext()
        {
        }

        public CarFinderSalesSystemContext(DbContextOptions<CarFinderSalesSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Notice> Notices { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(" Server=UNAL;Database=CarFinder/SalesSystem;Trusted_Connection=True;TrustServerCertificate=True; ");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Image).HasColumnType("image");
                entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand).WithMany(p => p.Cars)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cars_Brands");

                entity.HasOne(d => d.Color).WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cars_Colors");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Car).WithMany(p => p.Notices)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notices_Cars");

                entity.HasOne(d => d.User).WithMany(p => p.Notices)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notices_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);
                entity.Property(e => e.CompanyName).HasMaxLength(50);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.PasswordHash).HasMaxLength(50);
                entity.Property(e => e.PasswordSalt).HasMaxLength(50);
                entity.Property(e => e.Surname).HasMaxLength(50);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
