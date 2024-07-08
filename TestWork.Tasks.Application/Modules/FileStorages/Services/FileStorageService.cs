namespace TestWork.Tasks.Application.Modules.FileStorages.Services;

/// <inheritdoc />
internal sealed class FileStorageService : IFileStorageService
{
    private const string FileRoute = "../TestWork.Tasks.Application/Modules/FileStorages/Data/";

    /// <inheritdoc />
    public async Task<Stream> DownloadFileAsync(Guid id, CancellationToken token)
    {
        var path = FileRoute + id;
        await using var fileStream = new FileStream(path, FileMode.Open);

        var memoryStream = new MemoryStream();
        await fileStream.CopyToAsync(memoryStream, token);

        return memoryStream;
    }

    /// <inheritdoc />
    public async Task UploadAsync(Guid id, Stream data, CancellationToken token)
    {
        var path = FileRoute + id;
        await using var fileStream = new FileStream(path, FileMode.CreateNew);
        data.Seek(0, SeekOrigin.Begin);
        await data.CopyToAsync(fileStream, token);
    }
}