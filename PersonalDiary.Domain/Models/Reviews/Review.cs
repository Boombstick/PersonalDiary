using PersonalDiary.Domain.Interfaces;

namespace PersonalDiary.Domain.Models.Reviews
{
    public abstract class Review : ICreatedAt
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
