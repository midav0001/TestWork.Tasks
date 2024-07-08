using MediatR;
using TestWork.Tasks.Application.Modules.Tasks.Constants;
using TestWork.Tasks.Application.Modules.Tasks.Interfaces;
using TestWork.Tasks.Application.Modules.Tasks.Models;
using TestWork.Tasks.Domain.Modules.Tasks.Filters;

namespace TestWork.Tasks.Application.Modules.Tasks.Queries;

public sealed class GetTaskListQuery(TaskFilter filter) : IRequest<IReadOnlyCollection<TaskView>>
{
    public TaskFilter Filter { get; } = filter;


    internal sealed class GetTaskListQueryHandler(ITaskQueryRepository taskRepository)
        : IRequestHandler<GetTaskListQuery, IReadOnlyCollection<TaskView>>
    {
        public async Task<IReadOnlyCollection<TaskView>> Handle(GetTaskListQuery request,
            CancellationToken cancellationToken)
        {
            var tasks = await taskRepository.GetManyAsync(request.Filter, cancellationToken);

            return tasks.Select(x =>
                new TaskView
                {
                    Id = x.Id,
                    Properties = new PropertyData[]
                    {
                        new()
                        {
                            Key = PropertyNameKeys.Name,
                            Value = x.Name
                        },
                        new()
                        {
                            Key = PropertyNameKeys.CreateDate,
                            Value = x.CreateDate
                        },
                        new()
                        {
                            Key = PropertyNameKeys.State,
                            Value = x.State
                        }
                    }
                }).ToArray();
        }
    }
}