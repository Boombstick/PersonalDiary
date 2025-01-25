using MediatR;
using FluentValidation;
using PersonalDiary.Application.Common;
using PersonalDiary.Domain.Repositories;

namespace PersonalDiary.Application.Feature.Places.FoodPlaces
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
            private readonly IRatingRepository _ratingRepository;
            public Handler(IRatingRepository ratingRepository)
            {
                _ratingRepository = ratingRepository;
            }
            public async Task<IReadOnlyList<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                var reviews = await _ratingRepository.GetPagedList(request.Page, request.PageSize, request.FoodPlaceId);
                return reviews.Select(x => new Model
                {
                    FoodRating = x.FoodRating,
                    VibeRating = x.VibeRating,
                    Comment = x.Comment,
                    FoodPlaceId = x.FoodPlaceId,
                    ServiceRating = x.ServiceRating
                }).ToList();
            }
        }

    }
}
