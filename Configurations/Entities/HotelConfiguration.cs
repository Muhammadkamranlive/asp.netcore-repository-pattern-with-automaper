using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trevoir.Data;

namespace Trevoir.Configurations.Entities
{
    public class HotelConfiguration:IEntityTypeConfiguration<Hotels>
    {
        public void Configure(EntityTypeBuilder<Hotels> builder)
        {

            builder.HasData(
                    new Hotels() { Id = 1, Name = "West", CountryId = 1 },
                    new Hotels() { Id = 2, Name = "World", CountryId = 2 },
                    new Hotels() { Id = 3, Name = "USA", CountryId = 3 }
               );
        }
    }
}
