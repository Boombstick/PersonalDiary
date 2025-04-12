using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalDiary.Domain.AbstractClasses;
using PersonalDiary.Domain.Models;

namespace PersonalDiary.Persistence.Configurations
{
    public class MediaFileConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
