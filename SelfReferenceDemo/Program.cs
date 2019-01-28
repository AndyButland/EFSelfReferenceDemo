namespace SelfReferenceDemo
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new AppDbContext())
            {
                ClearExistingData(db);
                AddData(db);

                foreach (var employee in db.Employees.Include("Manager"))
                {
                    Console.WriteLine(employee.ToString());
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void ClearExistingData(AppDbContext db)
        {
            db.Employees.RemoveRange(db.Employees);
            db.SaveChanges();
        }

        private static void AddData(AppDbContext db)
        {
            var fred = new Employee { FirstName = "Fred", LastName = "Bloggs" };
            var sally = new Employee { FirstName = "Sally", LastName = "Smith" };
            var jim = new Employee { FirstName = "Jim", LastName = "Jones", Manager = sally };

            db.Employees.Add(fred);
            db.Employees.Add(sally);
            db.Employees.Add(jim);

            db.SaveChanges();
        }
    }
}
