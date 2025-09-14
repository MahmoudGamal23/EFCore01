using EFCore01.Contexts;

namespace EFCore01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var context = new ITIDbContext();
            context.Database.EnsureCreated();

            Console.WriteLine("Database is created");
        }
    }
}