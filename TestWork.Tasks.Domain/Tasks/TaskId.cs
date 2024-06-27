using TestWork.Tasks.Domain.Common;

namespace TestWork.Tasks.Domain.Tasks;

/// <summary>
/// Доменная модель идентификатора задачи
/// </summary>
public sealed class TaskId : AggregateId
{
    private TaskId(Guid value) : base(value)
    {
    }

    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="value">Идентификатор задачи</param>
    public static TaskId Create(Guid value)
    {
        return new TaskId(value);
    }
}