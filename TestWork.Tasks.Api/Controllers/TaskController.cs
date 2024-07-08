using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestWork.Tasks.Application.Modules.Tasks.Models;
using TestWork.Tasks.Application.Modules.Tasks.Queries;
using TestWork.Tasks.Domain.Modules.Tasks.Filters;
using TestWork.Tasks.Domain.Modules.Tasks.Models;

namespace TestWork.Tasks.Api.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController(ISender mediator) : ControllerBase

{
    /// <summary>
    /// Получить метаинформацию формы редактирования для гибкого построения на клиенте
    /// </summary>
    [HttpGet("metadata")]
    public async Task<IReadOnlyCollection<PropertyMetadata>> GetMetadataAsync(CancellationToken token)
    {
        return await mediator.Send(new GetMetadataQuery(), token);
    }

    /// <summary>
    ///     Получить список задач по фильтру
    /// </summary>
    /// <param name="filter">Фильтр</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Список задач</returns>
    [HttpPost]
    public async Task<IReadOnlyCollection<TaskView>> GetListAsync([FromBody] TaskFilter filter, CancellationToken token)
    {
        return await mediator.Send(new GetTaskListQuery(filter), token);
    }

    /// <summary>
    ///     Получить задачу
    /// </summary>
    /// <param name="id">Идентификатор задачи</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Задача</returns>
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