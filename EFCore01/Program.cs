using EFCore01.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EFCore01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new ITIDbContext())
            {
                
                context.Database.Migrate();

                Console.WriteLine("Database created and migrations applied");
            }
        }
    }
}