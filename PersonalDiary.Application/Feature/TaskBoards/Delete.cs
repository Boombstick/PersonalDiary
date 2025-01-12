using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;

namespace PersonalDiary.Application.Feature.TaskBoards
{
    public class Delete
    {
        public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }
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
            ITaskBoardRepository _taskBoardRepository;
            public Handler(ITaskBoardRepository taskBoardRepository)
            {
                _taskBoardRepository = taskBoardRepository;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _taskBoardRepository.DeleteByGuidIdAsync(request.Id);

                return Unit.Value;
            }
        }
    }
}
