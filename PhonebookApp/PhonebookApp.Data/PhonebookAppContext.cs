using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PhonebookApp.Domain;

namespace PhonebookApp.Data
{
    public class PhonebookAppContext : DbContext
    {
        public DbSet<PhoneBook> PhoneBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // IMPORTANT: THIS IS NOT PRODUCTION READY. ONLY FOR DEMO PURPOSES.
            optionsBuilder.UseSqlite("Filename=PhonebookAppDb.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
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
