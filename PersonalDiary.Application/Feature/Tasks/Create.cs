using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.MyTask;
using PersonalDiary.Application.Exceptions;

namespace PersonalDiary.Application.Feature.Tasks
{
    public class Create
    {
        public class Command : IRequest<long>
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime? DeadLine { get; set; }
            public Guid BoardId { get; set; }
        }
        public class Validator : AbstractValidator<Command>
        {

        }
        public class Handler : IRequestHandler<Command, long>
        {
            private readonly IMyTaskRepository _taskRepository;
            private readonly ITaskBoardRepository _taskBoardRepository;
            public Handler(IMyTaskRepository foodPlaceRepository, ITaskBoardRepository taskBoardRepository)
            {
                _taskRepository = foodPlaceRepository;
                _taskBoardRepository = taskBoardRepository;
            }
            public async Task<long> Handle(Command request, CancellationToken cancellationToken)
            {
                var guid = Guid.NewGuid();
                var dateTime = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
                if (!await _taskBoardRepository.BoardExists(request.BoardId))
                    throw new NotFoundException($"Board with id {request.BoardId} not found");

                MyTask task = new MyTask
                {
                    Name = request.Name,
                    DeadLine = request.DeadLine.HasValue ? DateTime.SpecifyKind(request.DeadLine.Value, DateTimeKind.Unspecified) : null,
                    CreatedAt = dateTime,
                    UpdatedAt = dateTime,
                    BoardId = request.BoardId,
                    Description = request.Description,
                };
                await _taskRepository.Create(task);
                return task.Id;
            }
        }
    }
}
