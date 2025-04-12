using PersonalDiary.Domain.Interfaces;
using PersonalDiary.Domain.AbstractClasses;
using PersonalDiary.Domain.Models.Places.CulturePlaces;

namespace PersonalDiary.Domain.Models.Reviews
{
    public class CulturePlaceReview : Review<CulturePlace>
    {
        public byte VibeRating { get; set; }
        public byte InterestingRating { get; set; }
    }
}
