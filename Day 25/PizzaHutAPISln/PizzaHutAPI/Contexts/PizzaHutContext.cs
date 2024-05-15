using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Models;

namespace PizzaHutAPI.contexts
{
    public class PizzaHutContext :DbContext
    {
        public PizzaHutContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserDetails> UsersDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 101, UserName = "Ramu", Phone = "9876543210",Email="ramu@gmail.com",Address="Coimbatore",Role="User"},
                new User() { UserId = 102, UserName = "Bimu", Phone = "9012345678",Email="bimu@gmail.com",Address="Chennai",Role="User"},
                new User() { UserId = 103, UserName = "Somu", Phone = "9988776655", Email = "somu@gmail.com", Address = "Trichy",Role ="Admin" }
                );
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { 
                    PizzaId = 1,
                    Name= "Sizzling Schezwan Chicken",
                    Description= "Loaded with our signature spicy schezwan sauce, juicy schezwan chicken meatballs & 100% mozzarella cheese",
                    size="Medium",
                    Price=199,
                    Stocks=25
                },
                new Pizza()
                {
                    PizzaId = 2,
                    Name = "Awesome American Cheesy Chicken",
                    Description = "Topped with classic chicken pepperoni, cheese and chicken sausage black olives, spicy jalapeno and 100% mozzarella cheese",
                    size = "Large",
                    Price = 299,
                    Stocks = 50
                }
                );
        }
    }
}
