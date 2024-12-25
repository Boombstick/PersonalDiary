using MediatR;

namespace PersonalDiary.Application.Infrastructure
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
    {
        public RequestValidationBehavior()
        {
                
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            return next();
        }
    }
}
