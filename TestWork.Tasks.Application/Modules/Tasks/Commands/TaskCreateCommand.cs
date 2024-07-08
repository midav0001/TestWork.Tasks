namespace TestWork.Tasks.Application.Modules.Tasks.Commands;

/// <summary>
///     Команда создания задачи
/// </summary>
/// <param name="name">Наименование</param>
/// <param name="fileIds">Список файлов</param>
public sealed class TaskCreateCommand(string name, IReadOnlyCollection<Guid> fileIds)
{
    // /// <summary>
    // /// Наименование
    // /// </summary>
    // public string Name { get; } = name;
    //
    // /// <summary>
    // /// Список идентификаторов файлов
    // /// </summary>
    // public IReadOnlyCollection<Guid> FileIds { get; } = fileIds;
    //
    //
    // public sealed class TaskCreateHandler(ITaskRepository taskRepository) : IRequestHandler<TaskCreateCommand>
    // {
    //     public async Task Handle(TaskCreateCommand request, CancellationToken cancellationToken)
    //     {
    //         var model = TaskModel.Create(
    //             TaskId.Create(Guid.NewGuid()),
    //             TaskName.Create(request.Name),
    //             request.FileIds.Select(FileId.Create),
    //             DateTime.UtcNow);
    //
    //         await taskRepository.SaveAsync(model, cancellationToken);
    //     }
    // }
}