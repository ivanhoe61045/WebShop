namespace Persistence.Data.WebShopModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelShop : DbContext
    {
        public ModelShop()
            : base("name=ModelShop")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<OrderState> OrderState { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderHistory> OrderHistory { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .Property(e => e.CountryName)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.GenderName)
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Gender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderState>()
                .Property(e => e.StateOrder)
                .IsUnicode(false);

            modelBuilder.Entity<OrderState>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.OrderState)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderState>()
                .HasMany(e => e.OrderHistory)
                .WithRequired(e => e.OrderState)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categories>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.ProductCategory)
                .WithRequired(e => e.Categories)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Customers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderHistory)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderProduct)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProducName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderProduct)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductCategory)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
            
        }
    }
}
