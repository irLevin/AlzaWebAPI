using System;
using System.Collections.Generic;
using System.Text;
using Alza.Common.Entities;
//using Alza.Data.MSSQLData.Models;
using Microsoft.EntityFrameworkCore;

namespace Alza.Data.MSSQLData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product() { Id = 100001, Name = "Product 100001", ImgUrl = "http://img.com/100001.jps", Price = (decimal)20.5, Description = "Product 100001 description" },
            new Product() { Id = 100002, Name = "Product 100002", ImgUrl = "http://img.com/100002.jps", Price = (decimal)12.5, Description = "Product 100002 description" },
            new Product() { Id = 100003, Name = "Product 100003", ImgUrl = "http://img.com/100003.jps", Price = (decimal)10, Description = "Product 100003 description" },
            new Product() { Id = 100004, Name = "Product 100004", ImgUrl = "http://img.com/100004.jps", Price = (decimal)16, Description = "Product 100004 description" },
            new Product() { Id = 100005, Name = "Product 100005", ImgUrl = "http://img.com/100005.jps", Price = (decimal)9.5, Description = "Product 100005 description" },
            new Product() { Id = 100006, Name = "Product 100006", ImgUrl = "http://img.com/100006.jps", Price = (decimal)30, Description = "Product 100006 description" },
            new Product() { Id = 100007, Name = "Product 100007", ImgUrl = "http://img.com/100007.jps", Price = (decimal)40, Description = "Product 100007 description" }
            );
            modelBuilder.Entity<Inventory>().HasData(
            new Inventory() { ProductId = 100001, UnitsInStock = 100 },
            new Inventory() { ProductId = 100002, UnitsInStock = 300 },
            new Inventory() {  ProductId = 100003, UnitsInStock = 5 },
            new Inventory() {  ProductId = 100004, UnitsInStock = 0 },
            new Inventory() {  ProductId = 100005, UnitsInStock = 0 },
            new Inventory() { ProductId = 100006, UnitsInStock = 50 },
            new Inventory() {  ProductId = 100007, UnitsInStock = 100 }
            );
        }
    }
}

