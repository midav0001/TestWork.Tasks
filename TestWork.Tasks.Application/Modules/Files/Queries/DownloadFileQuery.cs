using MediatR;
using Microsoft.AspNetCore.Http;
using TestWork.Tasks.Application.Modules.FileStorages.Services;
using TestWork.Tasks.Domain.Exceptions;
using TestWork.Tasks.Domain.Modules.Files.Models;
using TestWork.Tasks.Domain.Modules.Files.Repositories;

namespace TestWork.Tasks.Application.Modules.Files.Queries;

public sealed class DownloadFileQuery(Guid id) : IRequest<IFormFile>
{
    public Guid Id { get; } = id;

    internal sealed class DownloadFileQueryHandler(
        IFileStorageService fileStorageService,
        IFileStorageRepository fileStorageRepository)
        : IRequestHandler<DownloadFileQuery, IFormFile>
    {
        public async Task<IFormFile> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
        {
            var memoryStream = await fileStorageService.DownloadFileAsync(request.Id, cancellationToken);

            var fileModel = await fileStorageRepository.GetAsync(FileId.Create(request.Id), cancellationToken);
            if (fileModel is null) throw new ValidationException("Не найден файл по идентификатору");


            return new FormFile(memoryStream,
                0,
                memoryStream.Length,
                fileModel.Name,
                fileModel.Name);
        }
    }
}