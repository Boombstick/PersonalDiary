using MediatR;
using FluentValidation;
using PersonalDiary.Application.Common;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.Places.WalkPlaces;

namespace PersonalDiary.Application.Feature.Places.WalkPlaces
{
    public class Details
    {
        public class Query : IRequest<Model>
        {
            public Guid Id { get; set; }
        }
        public class Model : BasePlaceDetailsModel<WalkPlaceType>
        {
            
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
            private readonly IWalkPlaceRepository _walkPlaceRepository;
            public Handler(IWalkPlaceRepository walkPlaceRepository)
            {
                _walkPlaceRepository = walkPlaceRepository;
            }
            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                var foodPlace = await _walkPlaceRepository.GetDetails(request.Id);
                var model = new Model
                {
                    Id = foodPlace.Id,
                    Name = foodPlace.Name,
                    City = foodPlace.City.Name,
                    Address = foodPlace.Address,
                    Type = foodPlace.Type,
                    UpdatedAt = foodPlace.UpdatedAt,
                    Description = foodPlace.Description,
                    Reviews = foodPlace.Reviews.Select(x => new ReviewModel { Comment = x.Comment, CreatedAt = x.CreatedAt }).ToList()
                };
                return model;
            }
        }
    }
}
