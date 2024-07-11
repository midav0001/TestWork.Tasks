using MediatR;
using TestWork.Tasks.Application.Common;
using TestWork.Tasks.Application.Modules.Tasks.Constants;
using TestWork.Tasks.Application.Modules.Tasks.Mappers;
using TestWork.Tasks.Application.Modules.Tasks.Models;
using TestWork.Tasks.Domain.Modules.Tasks.Models;
using TestWork.Tasks.Domain.Modules.Tasks.Repositories;

namespace TestWork.Tasks.Application.Modules.Tasks.Commands;

/// <summary>
/// Команда создания задачи
/// </summary>
/// <param name="task">Новая задача</param>
public sealed class TaskCreateCommand(TaskData task) : IRequest<Guid>
{
    public TaskData Task { get; } = task;


    public sealed class TaskCreateHandler(ITaskRepository taskRepository, IDateTimeService timeService)
        : IRequestHandler<TaskCreateCommand, Guid>
    {
        public async Task<Guid> Handle(TaskCreateCommand request, CancellationToken cancellationToken)
        {
            var task = request.Task;

            var taskId = TaskId.Create(Guid.NewGuid());
            var name = task.Properties.Single(x => x.Key == PropertyNameKeys.Name).Value.ToString();
            var fileIds = task.Properties.MapFiles();

            var taskModel = TaskModel.Create(taskId, TaskName.Create(name), fileIds, timeService.CurrentDateTime);

            await taskRepository.SaveAsync(taskModel, cancellationToken);

            return taskId.Value;
        }
    }
}