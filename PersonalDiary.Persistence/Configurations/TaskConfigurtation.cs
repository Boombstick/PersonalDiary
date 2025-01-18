using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.MyTask;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonalDiary.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<MyTask>
    {
        public void Configure(EntityTypeBuilder<MyTask> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
