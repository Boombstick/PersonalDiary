using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;

namespace PersonalDiary.Application.Feature.Dictionaries.Cities
{
    public class List
    {
        public class Query : IRequest<IReadOnlyCollection<Model>>
        {

        }
        public class Model
        {
            public long Id { get; set; }
            public string Name { get; set; }
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
            private readonly IDictionaryRepository _dictionaryRepository;
            public Handler(IDictionaryRepository dictionaryRepository)
            {
                _dictionaryRepository = dictionaryRepository;
            }
            public async Task<IReadOnlyCollection<Model>> Handle(Query request, CancellationToken cancellationToken)
            {

                var cities = await _dictionaryRepository.GetCities();
                return cities.Select(x => new Model
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
            }
        }
    }
}
