using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Models.Reviews;
using PersonalDiary.Domain.Repositories;

namespace PersonalDiary.Application.Feature.Food
{
    public class CreateReview
    {
        public class Command : IRequest<long>
        {
            public Guid FoodPlaceId { get; set; }
            public byte ServiceRating { get; set; }
            public byte VibeRating { get; set; }
            public byte FoodRating { get; set; }
            public string Description { get; set; }
        }
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x);
            }
        }
        public class Handler : IRequestHandler<Command, long>
        {
            private readonly IRatingRepository _ratingRepository;
            public Handler(IRatingRepository ratingRepository)
            {
                _ratingRepository = ratingRepository;
            }
            public async Task<long> Handle(Command request, CancellationToken cancellationToken)
            {
                var review = new FoodPlaceReview
                {
                    Description = request.Description,
                    FoodPlaceId = request.FoodPlaceId,
                    FoodRating = request.FoodRating,
                    ServiceRating = request.ServiceRating,
                    VibeRating = request.VibeRating,
                };
                await _ratingRepository.AddReview(review);
                return review.Id;
            }
        }
    }
}
