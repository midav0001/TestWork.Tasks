using TestWork.Tasks.Domain.Modules.Tasks.Models;

namespace TestWork.Tasks.Domain.Modules.Tasks.Repositories;

/// <summary>
/// Репозиторий для работы с задачами
/// </summary>
public interface ITaskRepository
{
    /// <summary>
    /// Получить задачу по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор задачи</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Доменная модель задачи</returns>
    public Task<TaskModel?> GetAsync(TaskId id, CancellationToken token);

    /// <summary>
    /// Сохранить
    /// </summary>
    /// <param name="task">Модель задачи</param>
    /// <param name="token">Токен отмены</param>
    public Task SaveAsync(TaskModel task, CancellationToken token);
}