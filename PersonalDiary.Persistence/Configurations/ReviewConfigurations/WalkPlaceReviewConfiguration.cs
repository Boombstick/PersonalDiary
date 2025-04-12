using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.Reviews;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonalDiary.Persistence.Configurations.ReviewConfigurations
{
    internal class WalkPlaceReviewConfiguration : IEntityTypeConfiguration<WalkPlaceReview>
    {
        public void Configure(EntityTypeBuilder<WalkPlaceReview> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.MediaFiles)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
