using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.Places.FoodPlaces;
using PersonalDiary.Application.Feature.City.Places;

namespace PersonalDiary.Application.Feature.City.Places.FoodPlaces
{
    public class Create
    {
        public class Command : BasePlaceCreateCommand<FoodPlaceType>, IRequest<Guid>
        {

        }
        public class Validator : AbstractValidator<Command>
        {

        }
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IFoodPlaceRepository _foodPlaceRepository;
            public Handler(IFoodPlaceRepository foodPlaceRepository)
            {
                _foodPlaceRepository = foodPlaceRepository;
            }
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var guid = Guid.NewGuid();
                FoodPlace place = new FoodPlace
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
                await _foodPlaceRepository.Create(place);
                return guid;
            }
        }
    }
}
