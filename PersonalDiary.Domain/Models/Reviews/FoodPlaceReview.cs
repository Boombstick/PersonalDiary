using PersonalDiary.Domain.Models.FoodPlaces;

namespace PersonalDiary.Domain.Models.Reviews
{
    public class FoodPlaceReview : Review
    {
        public byte FoodRating { get; set; }
        public byte VibeRating { get; set; }
        public byte ServiceRating { get; set; }
        public override float Rating
        {
            get { return (float)(FoodRating + VibeRating + ServiceRating) / 3; }
        }
        public Guid FoodPlaceId { get; set; }
        public FoodPlace FoodPlace { get; set; }
    }
}
