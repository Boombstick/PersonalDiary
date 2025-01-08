using PersonalDiary.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalDiary.Domain.Models.MyTask
{
    public class MyTask : ICreatedAt, IUpdatedAt, IDeadLine
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? DeadLine { get; set; }
        public TaskStatus Status { get; private set; } = TaskStatus.Open;
        [Column(TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime UpdatedAt { get; set; }

        public void ChangeTaskStatus(TaskStatus status)
        {
            Status = status;
        }
    }
}
