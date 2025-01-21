using MediatR;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using PersonalDiary.Domain.Models.Users;
using PersonalDiary.Application.Interfaces;

namespace PersonalDiary.Application.Feature.Accounts
{
    public class Login
    {
        public class Command : IRequest<string>
        {
            public string Email { get; set; }
            public string Password { get; set; }

        }
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x);
            }
        }
        public class Handler : IRequestHandler<Command, string>
        {
            private readonly UserManager<User> _userManager;
            private readonly IJwtTokenProvider _jwtTokenProvider;
            public Handler(UserManager<User> userManager, IJwtTokenProvider jwtTokenProvider)
            {
                _userManager = userManager;
                _jwtTokenProvider = jwtTokenProvider;
            }
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {

                var user = await _userManager.FindByEmailAsync(request.Email);
                if (!await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    throw new ValidationException("ss");
                }
                var token = _jwtTokenProvider.GetToken(user);
                return token;
            }
        }
    }
}
