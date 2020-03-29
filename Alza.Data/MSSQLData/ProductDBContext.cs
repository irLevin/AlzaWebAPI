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

        DbSet<Product> Products { get; set; }
    }
}
