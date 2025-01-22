using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using PersonalDiary.Domain.Models.Users;
using PersonalDiary.Application.Interfaces;

namespace PersonalDiary.Api.Middlewares
{
    public class CurrentUserMiddleware : IMiddleware
    {
        private readonly UserManager<User> _userManager;
        private readonly ICurrentUser _currentUser;
        public CurrentUserMiddleware(UserManager<User> userManager, ICurrentUser currentUser)
        {
            _userManager = userManager;
            _currentUser = currentUser;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.User.Identity!.IsAuthenticated)
            {
                await next(context);
                return;
            }
            var userId = context.User.FindFirst("id")!.Value;
            //var user = await _userManager.FindByIdAsync(userId); Пока нет других данных, нет смысла доставать всю сущность
            _currentUser.Id = Guid.Parse(userId);
            await next(context);
        }
    }
}
