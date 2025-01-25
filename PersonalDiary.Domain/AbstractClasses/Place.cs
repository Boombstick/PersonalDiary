using PersonalDiary.Domain.Interfaces;
using PersonalDiary.Domain.Models.Dictionaries;

namespace PersonalDiary.Domain.AbstractClasses
{
    public abstract class Place<TType> : ICreatedAt, IUpdatedAt 
        where TType : Enum
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long CityId { get; set; }
        public City City { get; set; }
        public TType Type { get; set; }
    }
}
