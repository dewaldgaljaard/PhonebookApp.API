using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PhonebookApp.Domain;

namespace PhonebookApp.Data
{
    public class PhonebookAppContext : DbContext
    {
        public DbSet<PhoneBook> Type { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // IMPORTANT: THIS IS NOT PRODUCTION READY. ONLY FOR DEMO PURPOSES.
            optionsBuilder.UseSqlite("Filename=PhonebookAppDb.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
        }
    }
}
