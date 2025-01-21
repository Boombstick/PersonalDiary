using MediatR;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using PersonalDiary.Domain.Models.Users;

namespace PersonalDiary.Application.Feature.Accounts
{
    public class Register
    {
        public class Command : IRequest<Guid>
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string UserName { get; set; }

        }
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x);
            }
        }
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly UserManager<User> _userManager;
            public Handler(UserManager<User> userManager)
            {
                _userManager = userManager;
            }
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var id = Guid.NewGuid();
                var user = new User
                {
                    Id = id,
                    Email = request.Email,
                    UserName = request.UserName,
                };
                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                    throw new ValidationException(result.Errors.First().Description);
                
                var asdasd = await _userManager.AddToRoleAsync(user, Role.User);
                return id;
            }
        }
    }
}
