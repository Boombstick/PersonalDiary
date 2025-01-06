using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalDiary.Domain.Models.MyTask;

namespace PersonalDiary.Persistence.Configurations
{
    public class TaskConfigurtation : IEntityTypeConfiguration<MyTask>
    {
        public void Configure(EntityTypeBuilder<MyTask> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
