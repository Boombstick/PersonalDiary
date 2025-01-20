using MediatR;
using FluentValidation;
using PersonalDiary.Persistence.Repositories;

namespace PersonalDiary.Application.Feature.Food
{
    public class ReviewList
    {
        public class Query : IRequest<IReadOnlyList<Model>>
        {
            public Guid FoodPlaceId { get; set; }
        }
        public class Model
        {
            public Guid FoodPlaceId { get; set; }
            public byte ServiceRating { get; set; }
            public byte VibeRating { get; set; }
            public byte FoodRating { get; set; }
            public float Rating { get; set; }
            public string Description { get; set; }
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
                var reviews = await _ratingRepository.GetAllReviews(request.FoodPlaceId);
                return reviews.Select(x => new Model
                {
                    FoodRating = x.FoodRating,
                    VibeRating = x.VibeRating,
                    Description = x.Description,
                    FoodPlaceId = x.FoodPlaceId,
                    ServiceRating = x.ServiceRating,
                    Rating = x.Rating,
                }).ToList();
            }
        }

    }
}
