using MediatR;
using FluentValidation;

namespace PersonalDiary.Application.Feature.City
{
    public class CreateRequest
    {
        public class Command : IRequest<Unit>
        {
            public string Name { get; set; }
        }
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x);
            }
        }
        public class Handler : IRequestHandler<Command, Unit>
        {
            public Handler()
            {

            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                var httpClient = new HttpClient();
                var httpRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://api.telegram.org/bot8153085836:AAHZoASqp5Lz47kQ-eWkeM70nZ5yAEMW5KA/sendMessage?chat_id=958251749&text=%22Эпривет%22")
                };
                await httpClient.SendAsync(httpRequest);
                return Unit.Value;
            }
        }
    }
}
