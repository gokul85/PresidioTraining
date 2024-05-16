using Microsoft.EntityFrameworkCore;
using RequestTrackerAPI.Models;

namespace RequestTrackerAPI.Contexts
{
    public class RequestTrackerContext : DbContext
    {
        public RequestTrackerContext(DbContextOptions options) : base(options) 
        { 

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 101, Name = "Ramu", DateOfBirth = new DateTime(2001, 01, 01), Phone = "9876543210", Image = "" },
                new Employee() { Id = 102, Name = "Somu", DateOfBirth = new DateTime(2002, 01, 01), Phone = "9876543211", Image = "" });
        }
    }
}
