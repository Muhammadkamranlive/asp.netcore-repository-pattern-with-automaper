using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Trevoir.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotels> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Country>().HasData(
                     new Country() { Id = 1, Name = "PAK" },
                     new Country() { Id = 2, Name = "IND" },
                     new Country() { Id = 3, Name = "USA" }
                );
            builder.Entity<Hotels>().HasData(
                    new Hotels() { Id = 1, Name = "West", CountryId = 1 },
                    new Hotels() { Id = 2, Name = "World", CountryId = 2 },
                    new Hotels() { Id = 3, Name = "USA", CountryId = 3 }
               );
        }
    }
}
