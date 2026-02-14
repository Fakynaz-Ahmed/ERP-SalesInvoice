using ERP.SalesInvoice.Data.Configurations;
using ERP.SalesInvoice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERP.SalesInvoice.Data
{
    public class AppDbContext : DbContext
    {    
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(InvoiceConfiguration)));

            modelBuilder.Entity<Customer>().HasData(
                new Customer {Id=1, Name = "Ahmed Ali", Email = "ahmed@gmail.com", Phone = "0100000001", Address = "Cairo" },
                new Customer {Id=2, Name = "Sara Mohamed", Email = "sara@gmail.com", Phone = "0100000002", Address = "Giza" },
                new Customer {Id=3, Name = "Omar Hassan", Email = "omar@gmail.com", Phone = "0100000003", Address = "Qena" }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Laptop", Price = 15000, Quantity = 10 },
                new Item { Id = 2, Name = "Mouse", Price = 150, Quantity = 50 },
                new Item { Id = 3, Name = "Keyboard", Price = 400, Quantity = 30 },
                new Item { Id = 4, Name = "Monitor", Price = 3500, Quantity = 20 }
            );
        }

    }
}
