using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MedicationAPI.Repo.DataModels.MedicationDataModels;

public partial class MedicationAPIDbContext : DbContext
{
    public MedicationAPIDbContext(DbContextOptions<MedicationAPIDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Changelog> Changelogs { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Changelog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("changelog_pkey");

            entity.ToTable("changelog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Checksum)
                .HasMaxLength(32)
                .HasColumnName("checksum");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.InstalledBy)
                .HasMaxLength(100)
                .HasColumnName("installed_by");
            entity.Property(e => e.InstalledOn)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("installed_on");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .HasColumnName("name");
            entity.Property(e => e.Success).HasColumnName("success");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .HasColumnName("version");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("medication_pkey");

            entity.ToTable("medication");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_date");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
