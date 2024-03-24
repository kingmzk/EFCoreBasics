using EFCoreBasics.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreBasics.Data
{
    public class AppDbContext : DbContext
    {
        private string connectionString;
        public AppDbContext()
        {
              connectionString = "Server=KINGMZK\\SQLEXPRESS;Database=EFCoreBasics;Trusted_Connection=True;TrustServerCertificate=True; ";
        }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //configure primary key
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);

            //Required field using fluent API
            modelBuilder.Entity<Employee>().Property(b => b.EmpFirstName).IsRequired();

            modelBuilder.Entity<EmployeeProject>()
                .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });


            //Many To Many Relationship
            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId);
        }

    }
}
