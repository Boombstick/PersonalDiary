using PersonalDiary.Application.Interfaces;

namespace PersonalDiary.Api.Security
{
    public class CurrentUser : ICurrentUser
    {
        public Guid Id { get; set; }
    }
}
