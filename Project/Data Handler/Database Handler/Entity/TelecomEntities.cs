using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Project
{
    public partial class TelecomEntities : DbContext
    {
        public TelecomEntities()
            : base("name=TelecomEntities1")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        //public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerLastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerPhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.SubscriptionCode)
                .IsUnicode(false);

            modelBuilder.Entity<Subscription>()
                .Property(e => e.SubscriptionName)
                .IsUnicode(false);

            modelBuilder.Entity<Subscription>()
                .Property(e => e.SubscriptionCode)
                .IsUnicode(false);

            modelBuilder.Entity<Subscription>()
                .Property(e => e.SubscriptionPackge)
                .IsUnicode(false);
        }
    }
}
