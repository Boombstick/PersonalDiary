using PersonalDiary.Domain.Interfaces;
using PersonalDiary.Domain.AbstractClasses;
using PersonalDiary.Domain.Models.Places.WalkPlaces;

namespace PersonalDiary.Domain.Models.Reviews
{
    public class WalkPlaceReview : Review<WalkPlace>
    {
        public byte VibeRating { get; set; }
    }
}
