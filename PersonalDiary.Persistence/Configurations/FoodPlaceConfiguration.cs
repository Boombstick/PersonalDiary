using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.Food;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonalDiary.Persistence.Configurations
{
    public class FoodPlaceConfiguration : IEntityTypeConfiguration<FoodPlace>
    {
        public void Configure(EntityTypeBuilder<FoodPlace> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
