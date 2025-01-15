using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.FoodPlace;

namespace PersonalDiary.Application.Feature.Food
{
    public class PagedList
    {
        public class Query : IRequest<IReadOnlyList<Model>>
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
        }

        public class Model
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Description { get; set; }
            public Cousine Cousine { get; set; }
            public DateTime UpdatedAt { get; set; }

        }
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x);
            }
        }
        public class Handler : IRequestHandler<Query, IReadOnlyList<Model>>
        {
            private IFoodPlaceRepository _foodPlaceRepository;
            public Handler(IFoodPlaceRepository foodPlaceRepository)
            {
                _foodPlaceRepository = foodPlaceRepository;
            }
            public async Task<IReadOnlyList<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                var places = await _foodPlaceRepository.GetPagedList(request.Page, request.PageSize);
                return places.Select(foodPlace => new Model
                {
                    Id = foodPlace.Id,
                    Address = foodPlace.Address,
                    City = foodPlace.City.Name,
                    Cousine = foodPlace.Cousine,
                    Description = foodPlace.Description,
                    Name = foodPlace.Name,
                    UpdatedAt = foodPlace.UpdatedAt
                }).ToList();
            }
        }
    }
}
