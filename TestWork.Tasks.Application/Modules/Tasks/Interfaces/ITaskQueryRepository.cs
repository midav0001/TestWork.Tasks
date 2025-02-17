using TestWork.Tasks.Application.Modules.Tasks.Models;
using TestWork.Tasks.Domain.Modules.Tasks.Filters;
using TestWork.Tasks.Domain.Modules.Tasks.Models;

namespace TestWork.Tasks.Application.Modules.Tasks.Interfaces;

/// <summary>
/// Репозиторий для чтения задач
/// </summary>
public interface ITaskQueryRepository
{
    /// <summary>
    /// Получить задачи по фильтру
    /// </summary>
    /// <param name="filter">Фильтр</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Список задач</returns>
    public Task<IReadOnlyCollection<TaskListItem>> GetManyAsync(TaskFilter filter, CancellationToken token);

    /// <summary>
    /// Получить задачу по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор задачи</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Доменная модель задачи</returns>
    public Task<TaskListItem?> GetAsync(TaskId id, CancellationToken token);
}