using Microsoft.AspNetCore.Identity;
using PersonalDiary.Domain.Models.Reviews;

namespace PersonalDiary.Domain.Models.Users
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<FoodPlaceReview> FoodPlaceReviews { get; set; }
    }
}
