using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;

namespace PersonalDiary.Application.Feature.Tasks
{
    public class Details
    {
        public class Query : IRequest<Model>
        {
            public long Id { get; set; }
        }
        public class Model
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? DeadLine { get; set; }

        }
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x);
            }
        }
        public class Handler : IRequestHandler<Query, Model>
        {
            private IMyTaskRepository _taskRepository;
            public Handler(IMyTaskRepository taskRepository)
            {
                _taskRepository = taskRepository;
            }
            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                var task = await _taskRepository.GetDetails(request.Id);
                var model = new Model
                {
                    Id = task.Id,
                    Description = task.Description,
                    Name = task.Name,
                    CreatedAt = task.CreatedAt,
                    DeadLine = task.DeadLine,
                };
                return model;
            }
        }
    }
}
