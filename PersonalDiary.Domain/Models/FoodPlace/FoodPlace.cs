using PersonalDiary.Domain.Interfaces;

namespace PersonalDiary.Domain.Models.FoodPlace
{
    public class FoodPlace : ICreatedAt, IUpdatedAt
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public Cousine Cousine { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
