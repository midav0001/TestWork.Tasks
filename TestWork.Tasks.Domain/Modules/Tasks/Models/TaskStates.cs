namespace TestWork.Tasks.Domain.Modules.Tasks.Models;

/// <summary>
/// Статусы выполнения задачи
/// </summary>
public enum TaskStates
{
    /// <summary>
    /// Не задано
    /// </summary>
    None = 0,

    /// <summary>
    /// Новая
    /// </summary>
    New = 1,

    /// <summary>
    /// В процессе
    /// </summary>
    InProcess = 2,

    /// <summary>
    /// Завершено
    /// </summary>
    Finished = 3,

    /// <summary>
    /// Удалена
    /// </summary>
    Deleted = 4
}