using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.Places.FoodPlaces;
using PersonalDiary.Application.Feature.City.Places;

namespace PersonalDiary.Application.Feature.City.Places.FoodPlaces
{
    public class PagedList
    {
        public class Query : BasePlacePagedListQuery<FoodPlaceType>, IRequest<IReadOnlyList<Model>>
        {

        }

        public class Model : BasePlaceDetailsModel<FoodPlaceType>
        {


        }
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {

            }
        }
        public class Handler : IRequestHandler<Query, IReadOnlyList<Model>>
        {
            private readonly IFoodPlaceRepository _foodPlaceRepository;
            public Handler(IFoodPlaceRepository foodPlaceRepository)
            {
                _foodPlaceRepository = foodPlaceRepository;
            }
            public async Task<IReadOnlyList<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                var places = await _foodPlaceRepository.GetPagedList(
                    request.Page,
                    request.PageSize,
                    request.SearchTerm,
                    request.CityId,
                    request.Type);
                return places.Select(foodPlace => new Model
                {
                    Id = foodPlace.Id,
                    Address = foodPlace.Address,
                    City = foodPlace.City.Name,
                    Type = foodPlace.Type,
                    Description = foodPlace.Description,
                    Name = foodPlace.Name,
                    UpdatedAt = foodPlace.UpdatedAt,
                    ReviewsCount = foodPlace.ReviewCount,
                    AverageRating = foodPlace.AverageRating,
                }).ToList();
            }
        }
    }
}
