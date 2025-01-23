using MediatR;
using FluentValidation;
using PersonalDiary.Application.Common;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.FoodPlaces;

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
            public ICollection<ReviewModel> Reviews { get; set; }
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
                    Name = foodPlace.Name,
                    City = foodPlace.City.Name,
                    Address = foodPlace.Address,
                    Cousine = foodPlace.Cousine,
                    UpdateAt = foodPlace.UpdatedAt,
                    Description = foodPlace.Description,
                    Reviews = foodPlace.Reviews.Select(x => new ReviewModel { Comment = x.Comment, CreatedAt = x.CreatedAt }).ToList()
                };
                return model;
            }
        }
    }
}
