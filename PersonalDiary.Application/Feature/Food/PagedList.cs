using MediatR;
using FluentValidation;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.FoodPlace;

namespace PersonalDiary.Application.Feature.Food
{
    public class PagedList
    {
        public class Query : IRequest<IReadOnlyList<FoodPlace>>
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
        }

        public class Model : FoodPlace
        {

        }
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x);
            }
        }
        public class Handler : IRequestHandler<Query, IReadOnlyList<FoodPlace>>
        {
            private IFoodPlaceRepository _foodPlaceRepository;
            public Handler(IFoodPlaceRepository foodPlaceRepository)
            {
                _foodPlaceRepository = foodPlaceRepository;
            }
            public async Task<IReadOnlyList<FoodPlace>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _foodPlaceRepository.GetPagedList(request.Page, request.PageSize);
            }
        }
    }
}
