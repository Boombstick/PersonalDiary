using PersonalDiary.Domain.Models.Places.CulturePlaces;

namespace PersonalDiary.Domain.Models.Reviews
{
    public class CulturePlaceReview : Review
    {
        public CulturePlace CulturePlace { get; set; }
        public Guid CulturePlaceId { get; set; }
    }
}
