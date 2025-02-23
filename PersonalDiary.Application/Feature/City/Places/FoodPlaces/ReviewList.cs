using MediatR;
using FluentValidation;
using PersonalDiary.Application.Common;
using PersonalDiary.Domain.Repositories.Reviews;

namespace PersonalDiary.Application.Feature.City.Places.FoodPlaces
{
    public class ReviewList
    {
        public class Query : PagedListQueryBase, IRequest<IReadOnlyList<Model>>
        {
            public Guid FoodPlaceId { get; set; }
        }
        public class Model
        {
            public Guid FoodPlaceId { get; set; }
            public byte ServiceRating { get; set; }
            public byte VibeRating { get; set; }
            public byte FoodRating { get; set; }
            public string Comment { get; set; }
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
            private readonly IFoodPlaceReviewRepository _reviewRepository;
            public Handler(IFoodPlaceReviewRepository ratingRepository)
            {
                _reviewRepository = ratingRepository;
            }
            public async Task<IReadOnlyList<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                var reviews = await _reviewRepository.GetPagedList(request.Page, request.PageSize, request.FoodPlaceId);
                return reviews.Select(x => new Model
                {
                    FoodRating = x.FoodRating,
                    VibeRating = x.VibeRating,
                    Comment = x.Comment,
                    FoodPlaceId = x.PlaceId,
                    ServiceRating = x.ServiceRating
                }).ToList();
            }
        }

    }
}
