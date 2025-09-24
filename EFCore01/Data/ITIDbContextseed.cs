using EFCore01.Contexts;
using EFCore01.Models;
using System.Text.Json;

namespace EFCore01.Data
{
    internal static class ITIDbContextSeed
    {
        public static bool Seed(ITIDbContext dbContext)
        {
            try
            {
                // ---------- Seed Departments ----------
                if (!dbContext.Departments.Any())
                {
                    var deptData = File.ReadAllText("Data/departments.json");
                    var departments = JsonSerializer.Deserialize<List<Department>>(deptData);

                    if (departments != null)
                    {
                       
                        foreach (var d in departments)
                            d.Ins_ID = null;

                        dbContext.Departments.AddRange(departments);
                        dbContext.SaveChanges();
                    }
                }

                // ----------  Seed Instructors ----------
                if (!dbContext.Instructors.Any())
                {
                    var instructors = new List<Instructor>
                    {
                        new Instructor { Name="Ali", Salary=5000, Address="Cairo", HourRate=100, Bonus=500, Dept_ID=1 },
                        new Instructor { Name="Sara", Salary=6000, Address="Giza", HourRate=120, Bonus=800, Dept_ID=2 },
                        new Instructor { Name="Omar", Salary=7000, Address="Alex", HourRate=110, Bonus=600, Dept_ID=3 }
                    };

                    dbContext.Instructors.AddRange(instructors);
                    dbContext.SaveChanges();
                }

                // ---------- Update Departments with Managers ----------
                var firstDept = dbContext.Departments.FirstOrDefault();
                var firstInstructor = dbContext.Instructors.FirstOrDefault();

                if (firstDept != null && firstInstructor != null)
                {
                    firstDept.Ins_ID = firstInstructor.ID; 
                    dbContext.SaveChanges();
                }

                // ---------- Seed Employees ----------
                if (!dbContext.Employees.Any())
                {
                    var empData = File.ReadAllText("Data/employees.json");
                    var employees = JsonSerializer.Deserialize<List<Employee>>(empData);

                    if (employees != null)
                    {
                        dbContext.Employees.AddRange(employees);
                        dbContext.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while seeding data: {ex.Message}");
                return false;
            }
        }
    }
}