using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Models.Reviews;
using PersonalDiary.Application.Interfaces;
using PersonalDiary.Domain.Repositories.Reviews;

namespace PersonalDiary.Application.Feature.Places.CulturePlaces
{
    public class CreateReview
    {
        public class Command : IRequest<long>
        {
            public Guid FoodPlaceId { get; set; }
            public byte ServiceRating { get; set; }
            public byte VibeRating { get; set; }
            public byte FoodRating { get; set; }
            public string Comment { get; set; }
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
            private readonly IFoodPlaceReviewRepository _reviewRepository;
            private readonly ICurrentUser _currentUser;
            public Handler(IFoodPlaceReviewRepository reviewRepository, ICurrentUser currentUser)
            {
                _reviewRepository = reviewRepository;
                _currentUser = currentUser;
            }
            public async Task<long> Handle(Command request, CancellationToken cancellationToken)
            {
                var review = new FoodPlaceReview
                {
                    Comment = request.Comment,
                    PlaceId = request.FoodPlaceId,
                    FoodRating = request.FoodRating,
                    ServiceRating = request.ServiceRating,
                    VibeRating = request.VibeRating,
                    AuthorId = _currentUser.Id,
                    CreatedAt = DateTime.UtcNow,
                };
                await _reviewRepository.AddReview(review);
                return review.Id;
            }
        }
    }
}
