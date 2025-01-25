using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.Places.WalkPlaces;

namespace PersonalDiary.Application.Feature.Places.WalkPlaces
{
    public class Create
    {
        public class Command : BasePlaceCreateCommand<WalkPlaceType>, IRequest<Guid>
        {

        }
        public class Validator : AbstractValidator<Command>
        {

        }
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IWalkPlaceRepository _walkPlaceRepository;
            public Handler(IWalkPlaceRepository walkPlaceRepository)
            {
                _walkPlaceRepository = walkPlaceRepository;
            }
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var guid = Guid.NewGuid();
                WalkPlace place = new WalkPlace
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
                await _walkPlaceRepository.Create(place);
                return guid;
            }
        }
    }
}
