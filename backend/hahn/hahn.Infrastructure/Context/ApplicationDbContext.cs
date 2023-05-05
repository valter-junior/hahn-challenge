using hahn.Domain.Entities;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Domain.Entities.OrderAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<BuyerAddress>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Manager>().HasMany(x => x.Products).WithOne(x => x.Manager)
                .HasForeignKey(x => x.ManagerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Buyer>().HasMany(x => x.Orders).WithOne(x => x.Buyer)
                .HasForeignKey(x => x.BuyerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Buyer>().HasMany(x => x.BuyerAddresses).WithOne(x => x.Buyer)
                .HasForeignKey(x => x.BuyerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BuyerAddress>().HasMany(x => x.Orders).WithOne(x => x.BuyerAddress)
                .HasForeignKey(x => x.BuyerAddressId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>().HasMany(x => x.OrdersItem).WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>().HasMany(x => x.Items).WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderItems>().HasKey(x => new { x.OrderId, x.ProductId });

        }

        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<BuyerAddress> BuyerAddresses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
