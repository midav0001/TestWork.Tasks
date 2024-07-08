namespace TestWork.Tasks.Application.Modules.FileStorages.Services;

public interface IFileStorageService
{
    public Task<Stream> DownloadFileAsync(Guid id, CancellationToken token);

    public Task SaveAsync(Guid id, Stream data, CancellationToken token);
}