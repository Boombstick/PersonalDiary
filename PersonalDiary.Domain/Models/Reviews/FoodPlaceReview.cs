using PersonalDiary.Domain.Models.Users;
using PersonalDiary.Domain.Models.FoodPlaces;

namespace PersonalDiary.Domain.Models.Reviews
{
    public class FoodPlaceReview : Review
    {
        public byte FoodRating { get; set; }
        public byte VibeRating { get; set; }
        public byte ServiceRating { get; set; }
        public Guid FoodPlaceId { get; set; }
        public FoodPlace FoodPlace { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }
    }
}
