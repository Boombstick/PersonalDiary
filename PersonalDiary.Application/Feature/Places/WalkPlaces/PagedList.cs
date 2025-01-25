using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.Places.WalkPlaces;

namespace PersonalDiary.Application.Feature.Places.WalkPlaces
{
    public class PagedList
    {
        public class Query : BasePlacePagedListQuery<WalkPlaceType>, IRequest<IReadOnlyList<Model>>
        {

        }

        public class Model : BasePlaceDetailsModel<WalkPlaceType>
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
            private readonly IWalkPlaceRepository _walkPlaceRepository;
            public Handler(IWalkPlaceRepository walkPlaceRepository)
            {
                _walkPlaceRepository = walkPlaceRepository;
            }
            public async Task<IReadOnlyList<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                var places = await _walkPlaceRepository.GetPagedList(
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
