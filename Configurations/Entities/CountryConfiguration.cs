using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trevoir.Data;

namespace Trevoir.Configurations.Entities
{
    public class CountryConfiguration:IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                     new Country() { Id = 1, Name = "PAK" },
                     new Country() { Id = 2, Name = "IND" },
                     new Country() { Id = 3, Name = "USA" }
                );

        }
    }
}
