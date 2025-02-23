using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.Places.CulturePlaces;

namespace PersonalDiary.Application.Feature.City.Places.CulturePlaces
{
    public class Create
    {
        public class Command : BasePlaceCreateCommand<CulturePlaceType>, IRequest<Guid>
        {

        }
        public class Validator : AbstractValidator<Command>
        {

        }
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly ICulturePlaceRepository _culturePlaceRepository;
            public Handler(ICulturePlaceRepository culturePlaceRepository)
            {
                _culturePlaceRepository = culturePlaceRepository;
            }
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var guid = Guid.NewGuid();
                CulturePlace place = new CulturePlace
                {
                    Id = guid,
                    Name = request.Name,
                    CityId = request.CityId,
                    Address = request.Adress,
                    Type = request.Type,
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    Description = request.Description,
                };
                await _culturePlaceRepository.Create(place);
                return guid;
            }
        }
    }
}
