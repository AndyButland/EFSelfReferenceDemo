namespace SelfReferenceDemo
{
    using System.Data.Entity;

    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
