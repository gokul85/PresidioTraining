using Microsoft.EntityFrameworkCore;
using PizzaHutAPIWithAuth.Models;

namespace PizzaHutAPIWithAuth.Contexts
{
    public class PizzaHutContext : DbContext
    {
        public PizzaHutContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza{ PizzaId = 1, PizzaName = "Pepperoni Pizza", Description = "Classic pizza topped with pepperoni slices", Price = 199, Stocks = 20},
                new Pizza{ PizzaId = 2, PizzaName = "Margherita Pizza", Description = "Simple yet delicious pizza with tomato sauce, fresh mozzarella, and basil leaves", Price = 299, Stocks = 15},
                new Pizza{ PizzaId = 3, PizzaName = "Vegetarian Pizza", Description = "Pizza loaded with assorted vegetables such as bell peppers, mushrooms, onions, and olives", Price = 399, Stocks = 12}
                );
        }
    }
}
