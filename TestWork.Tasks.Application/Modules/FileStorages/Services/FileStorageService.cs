namespace TestWork.Tasks.Application.Modules.FileStorages.Services;

internal sealed class FileStorageService : IFileStorageService
{
    private const string FileRoute = "../TestWork.Tasks.Application/Modules/FileStorages/Data/";

    public async Task<Stream> DownloadFileAsync(Guid id, CancellationToken token)
    {
        var path = FileRoute + id;
        await using var fileStream = new FileStream(path, FileMode.Open);

        var memoryStream = new MemoryStream();
        await fileStream.CopyToAsync(memoryStream, token);

        return memoryStream;
    }

    public Task SaveAsync(Guid id, Stream data, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}