using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.MyTask;

namespace PersonalDiary.Application.Feature.TaskBoards
{
    public class Details
    {
        public class Query : IRequest<Model>
        {
            public Guid Id { get; set; }
        }
        public class Model
        {
            public string Name { get; set; }
            public Guid Id { get; set; }
            public IReadOnlyCollection<MyTask> Tasks { get; set; }
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
            private readonly ITaskBoardRepository _boardRepository;
            public Handler(ITaskBoardRepository boardRepository)
            {
                _boardRepository = boardRepository;
            }
            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                var board = await _boardRepository.GetDetails(request.Id);
                return new Model
                {
                    Id = board.Id,
                    Tasks = board.Tasks,
                    Name = board.Name,
                };
            }
        }
    }
}
