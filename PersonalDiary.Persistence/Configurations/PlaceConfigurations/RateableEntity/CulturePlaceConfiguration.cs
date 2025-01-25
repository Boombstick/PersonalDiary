using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalDiary.Domain.Models.Places.CulturePlaces;

namespace PersonalDiary.Persistence.Configurations.PlaceConfigurations.RateableEntity
{
    internal class CulturePlaceConfiguration : IEntityTypeConfiguration<CulturePlace>
    {
        public void Configure(EntityTypeBuilder<CulturePlace> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.City)
                .WithMany()
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Reviews)
                .WithOne(x => x.CulturePlace)
                .HasForeignKey(x => x.CulturePlaceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
