using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Application.Exceptions;

namespace PersonalDiary.Application.Feature.Tasks
{
    public class ChangeStatus
    {
        public class Command : IRequest<Unit>
        {
            public long Id { get; set; }
            public Domain.Models.MyTask.TaskStatus Status { get; set; }
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
            private readonly IMyTaskRepository _taskRepository;
            public Handler(IMyTaskRepository taskRepository)
            {
                _taskRepository = taskRepository;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _taskRepository.ChangeTaskStatus(request.Id, request.Status))
                {
                    return Unit.Value;
                }
                throw new NotFoundException("Not Found");
            }
        }
    }
}
