using hahn.Domain.Entities;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Domain.Entities.OrderAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            builder.Entity<Product>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<Manager>().HasMany(x => x.Products).WithOne(x => x.Manager).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Buyer>().HasMany(x => x.Orders).WithOne(x => x.Buyer).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Buyer>().HasMany(x => x.BuyerAddresses).WithOne(x => x.Buyer).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<BuyerAddress>().HasMany(x => x.Orders).WithOne(x => x.BuyerAddress).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Product>().HasMany(x => x.Orders).WithMany(x => x.Products).UsingEntity<OrderItems>(
                l => l.HasOne<Order>().WithMany().HasForeignKey(e => e.OrderId),
                r => r.HasOne<Product>().WithMany().HasForeignKey(e => e.ProductId));


        }

        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
