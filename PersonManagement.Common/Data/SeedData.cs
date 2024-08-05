using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Common.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(
                serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.Addresses.Any() || context.People.Any())
                {
                    return;   // DB has been seeded
                }

                var addresses = new Address[]
                {
                new Address { Name = "Address 1", Number = "123" },
                new Address { Name = "Address 2", Number = "456" }
                };
                context.Addresses.AddRange(addresses);
                context.SaveChanges();

                var students = new Student[]
                {
                new Student { Name = "Student 1", PhoneNumber = "123456789", EmailAddress = "student1@example.com", AddressId = addresses[0].Id, StudentNumber = "S001", AverageMark = 8.5 },
                new Student { Name = "Student 2", PhoneNumber = "987654321", EmailAddress = "student2@example.com", AddressId = addresses[1].Id, StudentNumber = "S002", AverageMark = 9.0 }
                };
                context.Students.AddRange(students);
                context.SaveChanges();
                var professors = new Professor[]
                {
                new Professor { Name = "Professor 1", PhoneNumber = "234567890", EmailAddress = "professor1@example.com", AddressId = addresses[0].Id, Salary = 5000.00M },
                new Professor { Name = "Professor 2", PhoneNumber = "876543210", EmailAddress = "professor2@example.com", AddressId = addresses[1].Id, Salary = 6000.00M }
                };
                context.Professors.AddRange(professors);
                context.SaveChanges();
            }
        }
    }

}
