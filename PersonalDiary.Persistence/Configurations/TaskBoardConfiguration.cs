using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.MyTask;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonalDiary.Persistence.Configurations
{
    public class TaskBoardConfiguration : IEntityTypeConfiguration<TaskBoard>
    {
        public void Configure(EntityTypeBuilder<TaskBoard> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Tasks)
                .WithOne(x => x.Board);
        }
    }
}
