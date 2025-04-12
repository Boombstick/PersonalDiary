using PersonalDiary.Domain.Models;
using PersonalDiary.Domain.Interfaces;
using PersonalDiary.Domain.Models.Users;

namespace PersonalDiary.Domain.AbstractClasses
{
    public abstract class Review<TEntity> : ICreatedAt, IHaveMediaFiles
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid PlaceId { get; set; }
        public TEntity Place { get; set; }
        public ICollection<Media> MediaFiles { get; set; }
    }
}
