using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentModelFirstApp.Models;

public partial class StudentModelFirstApproachContext : DbContext
{
    public StudentModelFirstApproachContext()
    {
    }

    public StudentModelFirstApproachContext(DbContextOptions<StudentModelFirstApproachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentModelFirstApproach> StudentModelFirstApproaches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentModelFirstApproach>(entity =>
        {
            entity.ToTable("StudentModelFirstApproach");

            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.RollNumber).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
