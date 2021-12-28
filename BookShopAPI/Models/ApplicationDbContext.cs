using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookShopAPI.Models
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<DetailOrder> DetailOrder { get; set; }
        public virtual DbSet<Information> Information { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Voucher> Voucher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Author)
                .HasForeignKey(e => e.IdAuthor);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.DetailOrder)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.IdBook)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.IdCategory);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Information)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.IdCustomer);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.IdCustomer);

            modelBuilder.Entity<Information>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Information)
                .HasForeignKey(e => e.IdInformation);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.DetailOrder)
                .WithRequired(e => e.Orders)
                .HasForeignKey(e => e.IdOrder)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Publisher)
                .HasForeignKey(e => e.IdPublisher);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.State)
                .HasForeignKey(e => e.IdState);

            modelBuilder.Entity<Voucher>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Voucher)
                .HasForeignKey(e => e.IdVoucher);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
