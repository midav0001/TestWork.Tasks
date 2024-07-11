using MediatR;
using TestWork.Tasks.Domain.Exceptions;
using TestWork.Tasks.Domain.Modules.Tasks.Models;
using TestWork.Tasks.Domain.Modules.Tasks.Repositories;

namespace TestWork.Tasks.Application.Modules.Tasks.Commands;

public sealed class TaskDeleteCommand(Guid id) : IRequest
{
    public Guid Id { get; } = id;

    internal sealed class TaskDeleteCommandHandler(ITaskRepository taskRepository) : IRequestHandler<TaskDeleteCommand>
    {
        public async Task Handle(TaskDeleteCommand request, CancellationToken cancellationToken)
        {
            var taskModel = await taskRepository.GetAsync(TaskId.Create(request.Id), cancellationToken);

            if (taskModel is null) throw new ValidationException("Не найдена задача по идентификатору");

            taskModel.Delete();

            await taskRepository.SaveAsync(taskModel, cancellationToken);
        }
    }
}