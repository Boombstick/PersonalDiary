using MediatR;
using FluentValidation;

namespace PersonalDiary.Application.Templates
{
    public class CommandTemplate
    {
        public class Command : IRequest<Guid>
        {

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
            public Handler()
            {

            }
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
