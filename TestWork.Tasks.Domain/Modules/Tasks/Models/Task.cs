using TestWork.Tasks.Domain.Modules.Files.Models;

namespace TestWork.Tasks.Domain.Modules.Tasks.Models;

/// <summary>
/// Доменная модель задачи
/// </summary>
public sealed class TaskModel
{
    private TaskModel(TaskId id, TaskName name, TaskStates state, IReadOnlyCollection<FileId> fileIds,
        DateTime createDate)
    {
        Id = id;
        Name = name;
        State = state;
        FileIds = fileIds;
        CreateDate = createDate;
    }

    /// <summary>
    /// Идентификатор задачи
    /// </summary>
    public TaskId Id { get; }

    /// <summary>
    /// Наименование задачи
    /// </summary>
    public TaskName Name { get; private set; }

    /// <summary>
    /// Статус задачи
    /// </summary>
    public TaskStates State { get; private set; }

    /// <summary>
    /// Список идентификаторов файлов
    /// </summary>
    public IReadOnlyCollection<FileId> FileIds { get; private set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreateDate { get; }

    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="name">Наименование</param>
    /// <param name="fileIds">Список идентификаторов файлов</param>
    /// <param name="createDate">Дата создания</param>
    /// <returns>Доменная модель задачи</returns>
    public static TaskModel Create(TaskId id, TaskName name, IEnumerable<FileId>? fileIds, DateTime createDate)
    {
        return new TaskModel(id, name, TaskStates.New, fileIds?.ToArray() ?? ArraySegment<FileId>.Empty, createDate);
    }


    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="name">Наименование</param>
    /// <param name="fileIds">Список идентификаторов файлов</param>
    /// <param name="createDate">Дата создания</param>
    /// <param name="state">Статус</param>
    /// <returns>Доменная модель задачи</returns>
    public static TaskModel Restore(TaskId id, TaskName name, IEnumerable<FileId> fileIds, DateTime createDate,
        TaskStates state)
    {
        return new TaskModel(id, name, state, fileIds.ToArray(), createDate);
    }

    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="name">Наименование</param>
    /// <param name="fileIds">Список файлов</param>
    public void Update(TaskName name, IReadOnlyCollection<FileId>? fileIds)
    {
        Name = name;
        FileIds = fileIds ?? ArraySegment<FileId>.Empty;
    }

    /// <summary>
    /// Удалить
    /// </summary>
    public void Delete()
    {
        State = TaskStates.Deleted;
    }
}