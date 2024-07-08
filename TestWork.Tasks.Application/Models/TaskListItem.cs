using TestWork.Tasks.Domain.Tasks;

namespace TestWork.Tasks.Application.Models;

public sealed class TaskListItem
{
    /// <summary>
    ///     Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Наименование
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    ///     Статус
    /// </summary>
    public TaskStates State { get; set; }

    /// <summary>
    ///     Дата создания
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    ///     Список файлов
    /// </summary>
    public IReadOnlyCollection<FileListItem> Files { get; set; } = null!;
}