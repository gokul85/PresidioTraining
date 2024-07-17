using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Contexts
{
    public class ProductAPIContext : DbContext
    {
        public ProductAPIContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(r => r.Id);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product A", Price = 299, Description = "Description for Product A" , Image= "image1.jpg" },
                new Product { Id = 2, Name = "Product B", Price = 399, Description = "Description for Product B" , Image= "image2.jpg" },
                new Product { Id = 3, Name = "Product C", Price = 499, Description = "Description for Product C" , Image= "image3.jpg" }
            );
        }
    }
}
