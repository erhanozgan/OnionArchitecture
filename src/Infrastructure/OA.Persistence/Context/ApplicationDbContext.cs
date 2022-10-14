using Microsoft.EntityFrameworkCore;
using OA.Domain.Entities;
using System;

namespace OA.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid(), Name = "Pencil", Quantity = 100, Price = 10 },
                new Product() { Id = Guid.NewGuid(), Name = "Paper A4", Quantity = 100, Price = 1 },
                new Product() { Id = Guid.NewGuid(), Name = "Book", Quantity = 500, Price = 25 }
                );

            //modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}