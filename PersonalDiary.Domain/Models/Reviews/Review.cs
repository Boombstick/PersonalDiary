using PersonalDiary.Domain.Interfaces;
using PersonalDiary.Domain.Models.Users;

namespace PersonalDiary.Domain.Models.Reviews
{
    public abstract class Review : ICreatedAt
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
