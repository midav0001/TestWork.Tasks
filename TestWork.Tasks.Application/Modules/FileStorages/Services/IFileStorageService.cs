namespace TestWork.Tasks.Application.Modules.FileStorages.Services;

/// <summary>
///     Сервис для работы с файловым хранилищем
/// </summary>
public interface IFileStorageService
{
    /// <summary>
    ///     Скачать файл
    /// </summary>
    /// <param name="id">Идентификатор файла</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Данные файла</returns>
    public Task<Stream> DownloadFileAsync(Guid id, CancellationToken token);

    /// <summary>
    ///     Загрузить файл
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="data">Данные</param>
    /// <param name="token">Токен отмены</param>
    public Task UploadAsync(Guid id, Stream data, CancellationToken token);
}