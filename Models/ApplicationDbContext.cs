﻿using Microsoft.EntityFrameworkCore;

namespace AspWebTest2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> CUSTOMER { get; set; }
        public DbSet<Product> PRODUCT { get; set; }
        public DbSet<ORDERLIST> ORDERLIST { get; set; }
        public DbSet<OrderDetail> ORDERDETAILS { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 주 키 설정
            modelBuilder.Entity<ORDERLIST>().HasKey(o => o.OrderID);
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderID, od.ProductID });

            base.OnModelCreating(modelBuilder);
        }
    }
}
