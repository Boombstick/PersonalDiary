using PersonalDiary.Domain.Models.Places.WalkPlaces;

namespace PersonalDiary.Domain.Models.Reviews
{
    public class WalkPlaceReview : Review
    {
        public byte VibeRating { get; set; }
        public Guid WalkPlaceId { get; set; }
        public WalkPlace WalkPlace { get; set; }

    }
}
