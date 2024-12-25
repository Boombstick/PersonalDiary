namespace PersonalDiary.Domain.Models
{
    public class MyTask
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeadLine { get; set; }
        public TaskStatus Status { get; private set; } = TaskStatus.Open;

        public void ChangeTaskStatus(TaskStatus status)
        {
            Status = status;
        }
    }
}
