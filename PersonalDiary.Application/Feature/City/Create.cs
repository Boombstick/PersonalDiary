using MediatR;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using PersonalDiary.Application.Interfaces;
using PersonalDiary.Application.FileUploads;

namespace PersonalDiary.Application.Feature.City
{
    public class Create
    {
        public class Command : IRequest<Guid>
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public IFormFileCollection Pictures { get; set; }
        }
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x);
            }
        }
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IFileUploader _fileUploader;
            public Handler(IFileUploader fileUploader)
            {
                _fileUploader = fileUploader;
            }
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {


                var uploadTasks = request.Pictures.Select(picture => _fileUploader.UploadFileAsync(picture.OpenReadStream(), FileMediaType.Photo, picture.FileName, request.Name));
                //foreach (var picture in request.Pictures)
                //{
                //    await _fileUploader.UploadFileAsync(picture.OpenReadStream(), FileMediaType.Photo, picture.FileName, request.Name);
                //}
                var results = await Task.WhenAll(uploadTasks);
                return Guid.NewGuid();
            }
        }
    }
}
