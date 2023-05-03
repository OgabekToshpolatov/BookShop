using BulkyBook.Models; 
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

    public  DbSet<Category>? Categories { get; set; } 
    public DbSet<Product>? Products { get;set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", DisplayOrder = 1},
            new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
            new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            );

        modelBuilder.Entity<Product>().HasData(
                new Product 
                {
                    Id =1,
                    Title = "Fortune Of Time",
                    Author = "Bilby Spark",
                    Description = "Praesnt vitae doesnt sodales decabryu. Prasent meolstio orco augue, vitae diecription bnd to array",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId =1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    Title = "Garry Poter",
                    Author = "Roben Sharma",
                    Description = "Praesnt vitae doesnt sodales decabryu. Prasent meolstio orco augue, vitae diecription bnd to array",
                    ISBN = "SWD8899001",
                    ListPrice = 98,
                    Price = 91,
                    Price50 = 84,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "Otgan kunlar",
                    Author = "Abdulla Qodiriy",
                    Description = "Praesnt vitae doesnt sodales decabryu. Prasent meolstio orco augue, vitae diecription bnd to array",
                    ISBN = "SWD9988001",
                    ListPrice = 93,
                    Price = 91,
                    Price50 = 84,
                    Price100 = 83,
                    CategoryId = 2,
                    ImageUrl = ""
                }
            );
    }
}