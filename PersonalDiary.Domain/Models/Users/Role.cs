using Microsoft.AspNetCore.Identity;

namespace PersonalDiary.Domain.Models.Users
{
    public class Role : IdentityRole<Guid>
    {
        public const string Administrator = "Administrator";
        public const string User = "User";  
    }
}
