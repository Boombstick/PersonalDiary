using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.FoodPlace;

namespace PersonalDiary.Application.Feature.Food
{
    public class Create
    {
        public class Command : IRequest<Guid>
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public Cousine Cousine { get; set; }
            public string City { get; set; }
            public string Adress { get; set; }
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
                    City = request.City,
                    Address = request.Adress,
                    Cousine = request.Cousine,
                    UpdateAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    Description = request.Description,
                };
                await _foodPlaceRepository.Add(place);
                return guid;
            }
        }
    }
}
