using PersonalDiary.Application.Common;

namespace PersonalDiary.Application.Feature.City.Places
{
    public class BasePlaceDetailsModel<TType> where TType : struct, Enum
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public TType Type { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long ReviewsCount { get; set; }
        public float AverageRating { get; set; }
        public ICollection<ReviewModel> Reviews { get; set; }
    }
}
