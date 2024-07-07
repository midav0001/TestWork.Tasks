using TestWork.Tasks.Domain.Filters;
using TestWork.Tasks.Domain.Tasks;

namespace TestWork.Tasks.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с задачами
/// </summary>
public interface ITaskRepository
{
    /// <summary>
    ///     Получить задачи по фильтру
    /// </summary>
    /// <param name="filter">Фильтр</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Список задач</returns>
    public Task<IReadOnlyCollection<TaskModel>> GetManyAsync(TaskFilter filter, CancellationToken token);

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