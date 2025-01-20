using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalDiary.Domain.Models.FoodPlaces;

namespace PersonalDiary.Persistence.Configurations
{
    public class FoodPlaceConfiguration : IEntityTypeConfiguration<FoodPlace>
    {
        public void Configure(EntityTypeBuilder<FoodPlace> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.City)
                .WithMany()
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
