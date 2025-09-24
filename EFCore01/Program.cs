using EFCore01.Contexts;
using EFCore01.Data;
using EFCore01.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new ITIDbContext())
            {
                // ----------  Seeding ----------
                if (ITIDbContextSeed.Seed(context))
                    Console.WriteLine("✅ Database seeded successfully!");
                else
                    Console.WriteLine("❌ Seeding failed!");

                Console.WriteLine("\n------ CRUD Operations ------");

                // ----------  Insert ----------
                var newEmployee = new Employee
                {
                    FirstName = "Mahmoud",
                    LastName = "Saad",
                    Gender = "M",
                    Salary = 12000,
                    HireDate = DateTime.Now,
                    SecurityLevel = SecurityLevel.Developer,
                    Dept_ID = 1 
                };
                context.Employees.Add(newEmployee);
                context.SaveChanges();
                Console.WriteLine($"Inserted Employee: {newEmployee.FirstName} {newEmployee.LastName}");

                // ----------  Select ----------
                var employees = context.Employees.ToList();
                Console.WriteLine("\nAll Employees:");
                foreach (var emp in employees)
                {
                    Console.WriteLine($"- {emp.ID}: {emp.FirstName} {emp.LastName}, Salary={emp.Salary}");
                }

                // ----------  Update ----------
                var firstEmp = context.Employees.FirstOrDefault();
                if (firstEmp != null)
                {
                    firstEmp.Salary += 2000;
                    context.SaveChanges();
                    Console.WriteLine($"\nUpdated {firstEmp.FirstName}'s salary to {firstEmp.Salary}");
                }

                // ----------  Delete ----------
                var lastEmp = context.Employees.OrderByDescending(e => e.ID).FirstOrDefault();
                if (lastEmp != null)
                {
                    context.Employees.Remove(lastEmp);
                    context.SaveChanges();
                    Console.WriteLine($"\nDeleted Employee: {lastEmp.FirstName} {lastEmp.LastName}");
                }

                // ----------  Eager Loading ----------
                Console.WriteLine("\n------ Eager Loading (Departments with Employees) ------");
                var departmentsWithEmployees = context.Departments
                                                      .Include(d => d.Employees)
                                                      .ToList();
                foreach (var dept in departmentsWithEmployees)
                {
                    Console.WriteLine($"Department: {dept.Name}");
                    foreach (var emp in dept.Employees)
                    {
                        Console.WriteLine($"   - {emp.FirstName} {emp.LastName}");
                    }
                }

                // ----------  Lazy Loading ----------
                Console.WriteLine("\n------ Lazy Loading (Employees -> Department) ------");
                var allEmployees = context.Employees.ToList();
                foreach (var emp in allEmployees)
                {
                    
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} works in {emp.Department?.Name}");
                }
            }
        }
    }
}