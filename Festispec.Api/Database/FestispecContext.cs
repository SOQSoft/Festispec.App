using Festispec.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festispec.Api.Database
{
    public class FestispecContext : DbContext
    {
        //public DbSet<Inspection> Inspections { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Application> Applications { get; set; }
        public FestispecContext(DbContextOptions<FestispecContext> options) : base(options) { }
        public FestispecContext()
        {

        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<QuestionItem> QuestionItems { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<IllnessReport> IllnessReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(p => p.Employee)
                .WithOne(i => i.User)
                .HasForeignKey<Employee>(b => b.UserForeignKey);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Festispec.db;Trusted_Connection=True;");
        }

    }
}
