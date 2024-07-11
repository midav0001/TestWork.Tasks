using MediatR;
using TestWork.Tasks.Application.Modules.Tasks.Constants;
using TestWork.Tasks.Application.Modules.Tasks.Mappers;
using TestWork.Tasks.Application.Modules.Tasks.Models;
using TestWork.Tasks.Domain.Exceptions;
using TestWork.Tasks.Domain.Modules.Tasks.Models;
using TestWork.Tasks.Domain.Modules.Tasks.Repositories;

namespace TestWork.Tasks.Application.Modules.Tasks.Commands;

public sealed class TaskUpdateCommand(Guid id, TaskData task) : IRequest
{
    public Guid Id { get; } = id;

    public TaskData Task { get; } = task;

    internal sealed class TaskUpdateCommandHandler(ITaskRepository taskRepository) : IRequestHandler<TaskUpdateCommand>
    {
        public async Task Handle(TaskUpdateCommand request, CancellationToken cancellationToken)
        {
            var task = request.Task;
            var taskModel = await taskRepository.GetAsync(TaskId.Create(request.Id), cancellationToken);

            if (taskModel is null) throw new ValidationException("Не найдена задача по идентификатору");

            var name = task.Properties.Single(x => x.Key == PropertyNameKeys.Name).Value.ToString();
            var fileIds = task.Properties.MapFiles();
            taskModel.Update(TaskName.Create(name), fileIds);

            await taskRepository.SaveAsync(taskModel, cancellationToken);
        }
    }
}