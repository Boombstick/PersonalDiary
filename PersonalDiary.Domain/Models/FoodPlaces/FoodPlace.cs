using PersonalDiary.Domain.Interfaces;
using PersonalDiary.Domain.AbstractClasses;
using PersonalDiary.Domain.Models.Dictionaries;

namespace PersonalDiary.Domain.Models.FoodPlaces
{
    public class FoodPlace : RateableEntity, ICreatedAt, IUpdatedAt
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public Cousine Cousine { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long CityId { get; set; }
        public City City { get; set; }
    }
}
