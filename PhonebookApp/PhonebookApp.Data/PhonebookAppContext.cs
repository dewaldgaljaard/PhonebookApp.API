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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PhoneBook>().ToTable("PhoneBooks");
            modelBuilder.Entity<PhoneBook>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name);
            });

            modelBuilder.Entity<Entry>().ToTable("Entries");
            modelBuilder.Entity<Entry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name);
            });

            modelBuilder.Entity<Entry>()
                .HasOne(e => e.PhoneBook)
                .WithMany(p => p.Entries)
                .HasForeignKey(e => e.PhoneBookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
 