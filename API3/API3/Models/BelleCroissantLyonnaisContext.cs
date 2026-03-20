using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API3.Models;

public partial class BelleCroissantLyonnaisContext : DbContext
{
    public BelleCroissantLyonnaisContext()
    {
    }

    public BelleCroissantLyonnaisContext(DbContextOptions<BelleCroissantLyonnaisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Costumerse> Costumerses { get; set; }

    public virtual DbSet<OrderItemse> OrderItemses { get; set; }

    public virtual DbSet<Ordersese> Orderseses { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Costumerse>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.AverageOrderValue).HasColumnName("average_order_value");
            entity.Property(e => e.Churned).HasColumnName("churned");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Frequency).HasColumnName("frequency");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.JoinDate).HasColumnName("join_date");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.LastPurchaseDate).HasColumnName("last_purchase_date");
            entity.Property(e => e.MembershipStatus)
                .HasMaxLength(50)
                .HasColumnName("membership_status");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.PostalCode).HasColumnName("postal_code");
            entity.Property(e => e.PreferredCategory)
                .HasMaxLength(50)
                .HasColumnName("preferred_category");
            entity.Property(e => e.TotalSpending).HasColumnName("total_spending");
        });

        modelBuilder.Entity<OrderItemse>(entity =>
        {
            entity.HasKey(e => e.OrdersItems);

            entity.Property(e => e.OrdersItems).ValueGeneratedNever();
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItemses)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItemses_Productos");
        });

        modelBuilder.Entity<Ordersese>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("Ordersese");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("transaction_id");
            entity.Property(e => e.Channel)
                .HasMaxLength(50)
                .HasColumnName("channel");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.PromotionId).HasColumnName("promotion_id");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.StoreId).HasColumnName("store_id");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("product_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Ingredients)
                .HasMaxLength(100)
                .HasColumnName("ingredients");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Seasonal).HasColumnName("seasonal");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
