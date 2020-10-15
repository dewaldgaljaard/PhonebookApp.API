using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PhonebookApp.Domain;

namespace PhonebookApp.Data
{
    public class PhonebookAppContext : DbContext
    {
        public DbSet<PhoneBook> PhoneBooks { get; set; }

        public PhonebookAppContext(DbContextOptions<PhonebookAppContext> options)
            :base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>().ToTable("Entries");
            modelBuilder.Entity<Entry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
