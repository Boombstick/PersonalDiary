using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;

namespace PersonalDiary.Application.Feature.Tasks
{
    public class PagedList
    {
        public class Query : IRequest<IReadOnlyList<Model>>
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
        }

        public class Model
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? DeadLine { get; set; }
            public Domain.Models.MyTask.TaskStatus Status { get; set; }
        }
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x);
            }
        }
        public class Handler : IRequestHandler<Query, IReadOnlyList<Model>>
        {
            private IMyTaskRepository _taskRepository;
            public Handler(IMyTaskRepository taskRepository)
            {
                _taskRepository = taskRepository;
            }
            public async Task<IReadOnlyList<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                var tasks = await _taskRepository.GetPagedList(request.Page, request.PageSize);

                return tasks.Select(x => new Model
                {
                    CreatedAt = x.CreatedAt,
                    DeadLine = x.DeadLine,
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status
                }).ToList();
            }
        }
    }
}
