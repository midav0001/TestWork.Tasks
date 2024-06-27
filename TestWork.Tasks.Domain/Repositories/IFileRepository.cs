using TestWork.Tasks.Domain.Files;

namespace TestWork.Tasks.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с файлами
/// </summary>
public interface IFileRepository
{
    /// <summary>
    /// Сохранить
    /// </summary>
    /// <param name="file">Модель файла</param>
    /// <param name="token">Токен отмены</param>
    public Task SaveAsync(FileModel file, CancellationToken token);
}