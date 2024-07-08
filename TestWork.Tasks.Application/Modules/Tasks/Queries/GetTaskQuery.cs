using MediatR;
using TestWork.Tasks.Application.Modules.Tasks.Interfaces;
using TestWork.Tasks.Application.Modules.Tasks.Models;
using TestWork.Tasks.Domain.Exceptions;
using TestWork.Tasks.Domain.Modules.Tasks.Models;

namespace TestWork.Tasks.Application.Modules.Tasks.Queries;

public sealed class GetTaskQuery(TaskId id) : IRequest<TaskView>
{
    public TaskId Id { get; } = id;

    internal sealed class GetTaskQueryHandler(ITaskQueryRepository taskRepository)
        : IRequestHandler<GetTaskQuery, TaskView>
    {
        public async Task<TaskView> Handle(GetTaskQuery request,
            CancellationToken cancellationToken)
        {
            var x = await taskRepository.GetAsync(request.Id, cancellationToken);
            if (x is null) throw new ValidationException("Не найдена задача по идентификатору");

            return new TaskView
            {
                Id = x.Id,
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
                        Value = x.Files.Select(f => new FileView
                        {
                            Id = f.Id,
                            Name = f.Name,
                            Link = $"http://localhost:5244/file-storage/{f.Id}"
                        }).ToArray()
                    }
                }
            };
        }
    }
}