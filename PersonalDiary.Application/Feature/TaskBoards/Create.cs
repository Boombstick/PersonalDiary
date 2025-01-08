using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.MyTask;

namespace PersonalDiary.Application.Feature.TaskBoards
{
    public class Create
    {
        public class Command : IRequest<Guid>
        {
            public string Name { get; set; }

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
            private readonly ITaskBoardRepository _boardRepository;

            public Handler(ITaskBoardRepository boardRepository)
            {
                _boardRepository = boardRepository;
            }
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var guid = Guid.NewGuid();
                var board = new TaskBoard
                {
                    Name = request.Name,
                    Id = guid,
                };
                await _boardRepository.Create(board);
                return guid;
            }
        }
    }
}
