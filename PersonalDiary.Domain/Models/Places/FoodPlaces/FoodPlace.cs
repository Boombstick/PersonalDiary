using PersonalDiary.Domain.Models.Reviews;
using PersonalDiary.Domain.AbstractClasses;

namespace PersonalDiary.Domain.Models.Places.FoodPlaces
{
    public class FoodPlace : RateablePlaceEntity<FoodPlace, FoodPlaceReview, FoodPlaceType>
    {
    }
}
