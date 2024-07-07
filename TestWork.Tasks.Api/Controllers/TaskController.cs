using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestWork.Tasks.Application.Models;
using TestWork.Tasks.Application.Tasks.Queries;
using TestWork.Tasks.Domain.Filters;
using TestWork.Tasks.Domain.Tasks;

namespace TestWork.Tasks.Api.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController(ISender mediator) : ControllerBase

{
    /// <summary>
    ///     Получить метаинформацию формы для гибкого построения на клиенте
    /// </summary>
    [HttpGet("metadata")]
    public async Task<IReadOnlyCollection<PropertyMetadata>> GetMetadataAsync(CancellationToken token)
    {
        return await mediator.Send(new GetMetadataQuery(), token);
    }

    [HttpPost]
    public async Task<IReadOnlyCollection<TaskView>> GetListAsync([FromBody] TaskFilter filter, CancellationToken token)
    {
        return await mediator.Send(new GetTaskListQuery(filter), token);
    }

    [HttpGet("{id:guid}")]
    public async Task<TaskView> GetAsync([FromRoute] Guid id, CancellationToken token)
    {
        return await mediator.Send(new GetTaskQuery(TaskId.Create(id)), token);
    }

    [HttpPost("{id:guid}")]
    public async Task CreateAsync([FromRoute] Guid id, [FromBody] TaskData taskData, CancellationToken token)
    {
    }

    [HttpPut("{id:guid}")]
    public async Task UpdateAsync([FromRoute] Guid id, [FromBody] TaskData taskData, CancellationToken token)
    {
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteAsync([FromRoute] Guid id, CancellationToken token)
    {
    }
}