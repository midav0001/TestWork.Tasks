using TestWork.Tasks.Domain.Files;

namespace TestWork.Tasks.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с файлами
/// </summary>
public interface IFileStorageRepository
{
    /// <summary>
    ///     Получить данные о файле
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<FileModel?> GetAsync(FileId id, CancellationToken token);

    /// <summary>
    /// Сохранить
    /// </summary>
    /// <param name="file">Модель файла</param>
    /// <param name="token">Токен отмены</param>
    public Task SaveAsync(FileModel file, CancellationToken token);
}