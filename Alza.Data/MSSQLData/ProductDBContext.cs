using Alza.Data.MSSQLData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Data.MSSQLData
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions options) : base(options)
        {
            
        }

        DbSet<Product> Product { get; set; }
        DbSet<Inventory> Inventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
           .HasOne<Inventory>(i => i.ProductInventory)
           .WithOne(p => p.OwnedProduct)
           .HasForeignKey<Inventory>(i => i.ProductId);
            modelBuilder.Seed();
        }
    }
}
