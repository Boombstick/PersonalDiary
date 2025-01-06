using MediatR;
using FluentValidation;

namespace PersonalDiary.Application.Templates
{
    public class QueryTemplate
    {
        public class Query : IRequest<Model>
        {

        }
        public class Model
        {

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
            public Handler()
            {

            }
            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
