using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;

namespace PersonalDiary.Application.Feature.Tasks
{
    public class Delete
    {
        public class Command : IRequest<Unit>
        {
            public long Id { get; set; }
        }
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x);
            }
        }
        public class Handler : IRequestHandler<Command, Unit>
        {
            IMyTaskRepository _myTaskRepository;
            public Handler(IMyTaskRepository myTaskRepository)
            {
                _myTaskRepository = myTaskRepository;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _myTaskRepository.DeleteByNumberIdAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}
