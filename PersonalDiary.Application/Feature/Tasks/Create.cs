using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Models.MyTask;
using PersonalDiary.Domain.Repositories;

namespace PersonalDiary.Application.Feature.Tasks
{
    public class Create
    {
        public class Command : IRequest<long>
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime? DeadLine { get; set; }
        }
        public class Validator : AbstractValidator<Command>
        {

        }
        public class Handler : IRequestHandler<Command, long>
        {
            private readonly IMyTaskRepository _taskRepository;
            public Handler(IMyTaskRepository foodPlaceRepository)
            {
                _taskRepository = foodPlaceRepository;
            }
            public async Task<long> Handle(Command request, CancellationToken cancellationToken)
            {
                var guid = Guid.NewGuid();
                var dateTime = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
                MyTask task = new MyTask
                {
                    Name = request.Name,
                    DeadLine = request.DeadLine.HasValue ? TimeZoneInfo.ConvertTimeToUtc(request.DeadLine.Value) : null,
                    CreatedAt = dateTime,
                    UpdatedAt = dateTime,
                    Description = request.Description,
                };
                await _taskRepository.Add(task);
                return task.Id;
            }
        }
    }
}
