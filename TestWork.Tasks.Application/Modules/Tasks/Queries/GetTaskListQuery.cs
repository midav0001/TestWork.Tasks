using MediatR;
using TestWork.Tasks.Application.Interfaces;
using TestWork.Tasks.Application.Models;
using TestWork.Tasks.Domain.Filters;

namespace TestWork.Tasks.Application.Modules.Tasks.Queries;

public sealed class GetTaskListQuery(TaskFilter filter) : IRequest<IReadOnlyCollection<TaskView>>
{
    public TaskFilter Filter { get; set; } = filter;


    public sealed class GetTaskListQueryHandler(ITaskQueryRepository taskRepository)
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
                        }
                    }
                }).ToArray();
        }
    }
}