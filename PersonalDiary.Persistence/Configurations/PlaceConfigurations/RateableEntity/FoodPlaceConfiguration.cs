using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.Places.FoodPlaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonalDiary.Persistence.Configurations.PlaceConfigurations.RateableEntity
{
    public class FoodPlaceConfiguration : IEntityTypeConfiguration<FoodPlace>
    {
        public void Configure(EntityTypeBuilder<FoodPlace> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.City)
                .WithMany(x=>x.FoodPlaces)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Reviews)
                .WithOne(x => x.FoodPlace)
                .HasForeignKey(x => x.FoodPlaceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
