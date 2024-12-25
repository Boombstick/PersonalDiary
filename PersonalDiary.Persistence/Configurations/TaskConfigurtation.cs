using PersonalDiary.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
