using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;

namespace PersonalDiary.Application.Feature.TaskBoards
{
    public class List
    {
        public class Query : IRequest<IReadOnlyCollection<Model>>
        {

        }
        public class Model
        {
            public string Name { get; set; }
            public Guid Id { get; set; }
        }
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x);
            }
        }
        public class Handler : IRequestHandler<Query, IReadOnlyCollection<Model>>
        {
            private readonly ITaskBoardRepository _boardRepository;
            public Handler(ITaskBoardRepository boardRepository)
            {
                _boardRepository = boardRepository;
            }
            public async Task<IReadOnlyCollection<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                var boards = await _boardRepository.GetList();
                return boards.Select(x => new Model
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
            }
        }
    }
}
