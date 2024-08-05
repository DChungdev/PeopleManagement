using Microsoft.EntityFrameworkCore;
using PersonManagement.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Common.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address)
                .WithMany(a => a.People)
                .HasForeignKey(p => p.AddressId);

            modelBuilder.Entity<Student>().HasBaseType<Person>();
            modelBuilder.Entity<Professor>().HasBaseType<Person>();

            modelBuilder.Entity<Professor>()
                .Property(p => p.Salary)
                .HasColumnType("decimal(18,2)");
        }
    }
}
