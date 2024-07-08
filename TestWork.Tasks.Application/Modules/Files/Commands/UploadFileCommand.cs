using MediatR;
using Microsoft.AspNetCore.Http;
using TestWork.Tasks.Application.Modules.FileStorages.Services;
using TestWork.Tasks.Domain.Modules.Files.Models;
using TestWork.Tasks.Domain.Modules.Files.Repositories;

namespace TestWork.Tasks.Application.Modules.Files.Commands;

public sealed class UploadFileCommand(IFormFile file) : IRequest<Guid>
{
    public IFormFile File { get; } = file;

    internal class UploadFileCommandHandler(
        IFileStorageService fileStorageService,
        IFileStorageRepository fileStorageRepository)
        : IRequestHandler<UploadFileCommand, Guid>
    {
        public async Task<Guid> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            using var memoryStream = new MemoryStream();
            await request.File.CopyToAsync(memoryStream, cancellationToken);

            var fileModel = FileModel.Create(FileId.Create(Guid.NewGuid()), request.File.FileName);
            await fileStorageService.UploadAsync(fileModel.Id.Value, memoryStream, cancellationToken);
            await fileStorageRepository.SaveAsync(fileModel, cancellationToken);

            return fileModel.Id.Value;
        }
    }
}