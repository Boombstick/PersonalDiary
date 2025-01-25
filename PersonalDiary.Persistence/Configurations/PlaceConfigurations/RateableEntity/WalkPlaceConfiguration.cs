using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.Places.WalkPlaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PersonalDiary.Persistence.Configurations.PlaceConfigurations.RateableEntity
{
    public class WalkPlaceConfiguration : IEntityTypeConfiguration<WalkPlace>
    {
        public void Configure(EntityTypeBuilder<WalkPlace> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.City)
                .WithMany()
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Reviews)
                .WithOne(x => x.WalkPlace)
                .HasForeignKey(x => x.WalkPlaceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
