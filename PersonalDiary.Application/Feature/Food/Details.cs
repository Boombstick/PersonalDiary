using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.FoodPlace;

namespace PersonalDiary.Application.Feature.Food
{
    public class Details
    {
        public class Query : IRequest<Model>
        {
            public Guid Id { get; set; }
        }
        public class Model
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Description { get; set; }
            public Cousine Cousine { get; set; }
            public DateTime UpdateAt { get; set; }
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
            private IFoodPlaceRepository _foodPlaceRepository;
            public Handler(IFoodPlaceRepository foodPlaceRepository)
            {
                _foodPlaceRepository = foodPlaceRepository;
            }
            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                var foodPlace = await _foodPlaceRepository.GetDetails(request.Id);
                var model = new Model
                {
                    Id = foodPlace.Id,
                    Address = foodPlace.Address,
                    City = foodPlace.City.Name,
                    Cousine = foodPlace.Cousine,
                    Description = foodPlace.Description,
                    Name = foodPlace.Name,
                    UpdateAt = foodPlace.UpdatedAt,
                };
                return model;
            }
        }
    }
}
