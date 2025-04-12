using PersonalDiary.Domain.Interfaces;
using PersonalDiary.Domain.AbstractClasses;
using PersonalDiary.Domain.Models.Places.FoodPlaces;

namespace PersonalDiary.Domain.Models.Reviews
{
    public class FoodPlaceReview : Review<FoodPlace>
    {
        public byte FoodRating { get; set; }
        public byte VibeRating { get; set; }
        public byte ServiceRating { get; set; }
    }
}
