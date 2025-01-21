using PersonalDiary.Domain.Models.Users;

namespace PersonalDiary.Application.Interfaces
{
    public interface IJwtTokenProvider
    {
        string GetToken(User user);
    }
}