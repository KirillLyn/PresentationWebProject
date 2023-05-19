using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PresentationWebProject.Models;

public partial class PresentationDbContext : DbContext
{
    public PresentationDbContext()
    {
    }

    public PresentationDbContext(DbContextOptions<PresentationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Presentation> Presentations { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=PresentationDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Presentation>(entity =>
        {
            entity.HasKey(e => e.IdPresent);

            entity.ToTable("Presentation");

            entity.Property(e => e.PresentationFileName).HasMaxLength(50);
            entity.Property(e => e.Prewiew).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Teacher).WithMany(p => p.Presentations)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_Presentation_Teacher");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.IdTeacher);

            entity.ToTable("Teacher");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OtherName).HasMaxLength(50);
            entity.Property(e => e.SurName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
