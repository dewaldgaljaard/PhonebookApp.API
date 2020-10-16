using Microsoft.EntityFrameworkCore;
using PhonebookApp.Domain;

namespace PhonebookApp.Data
{
    public class PhonebookAppContext : DbContext
    {
        public DbSet<PhoneBook> PhoneBooks { get; set; }

        public PhonebookAppContext()
        {
        }

        /// <summary>
        /// Used for in memory testing
        /// </summary>
        /// <param name="options"></param>
        public PhonebookAppContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=PhonebookTestDb.db");
            }
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
 