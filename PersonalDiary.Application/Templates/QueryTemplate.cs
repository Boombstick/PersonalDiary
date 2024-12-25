using MediatR;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;

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
