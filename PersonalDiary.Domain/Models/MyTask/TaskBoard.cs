namespace PersonalDiary.Domain.Models.MyTask
{
    public class TaskBoard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public List<MyTask> Tasks { get; set; }

    }
}
