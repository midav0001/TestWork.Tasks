using MediatR;
using TestWork.Tasks.Application.Models;
using TestWork.Tasks.Domain.Exceptions;
using TestWork.Tasks.Domain.Repositories;
using TestWork.Tasks.Domain.Tasks;

namespace TestWork.Tasks.Application.Tasks.Queries;

public sealed class GetTaskQuery(TaskId id) : IRequest<TaskView>
{
    public TaskId Id { get; set; } = id;


    public sealed class GetTaskQueryHandler(ITaskRepository taskRepository) : IRequestHandler<GetTaskQuery, TaskView>
    {
        public async Task<TaskView> Handle(GetTaskQuery request,
            CancellationToken cancellationToken)
        {
            var x = await taskRepository.GetAsync(request.Id, cancellationToken);
            if (x is null) throw new ValidationException("Не найдена задача по идентификатору");

            return new TaskView
            {
                Id = x.Id.Value,
                Properties = new PropertyData[]
                {
                    new()
                    {
                        Key = "Name",
                        Value = x.Name
                    },
                    new()
                    {
                        Key = "CreateDate",
                        Value = x.CreateDate
                    },
                    new()
                    {
                        Key = "State",
                        Value = x.State
                    },
                    new()
                    {
                        Key = "FileIds",
                        Value = x.FileIds.Select(x => x.Value)
                    }
                }
            };
        }
    }
}