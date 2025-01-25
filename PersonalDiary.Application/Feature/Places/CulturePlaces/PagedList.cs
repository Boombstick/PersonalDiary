using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.Places.CulturePlaces;

namespace PersonalDiary.Application.Feature.Places.CulturePlaces
{
    public class PagedList
    {
        public class Query : BasePlacePagedListQuery<CulturePlaceType>, IRequest<IReadOnlyList<Model>>
        {

        }

        public class Model : BasePlaceDetailsModel<CulturePlaceType>
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
            private readonly ICulturePlaceRepository _culturePlaceRepository;
            public Handler(ICulturePlaceRepository culturePlaceRepository)
            {
                _culturePlaceRepository = culturePlaceRepository;
            }
            public async Task<IReadOnlyList<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                var places = await _culturePlaceRepository.GetPagedList(
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
