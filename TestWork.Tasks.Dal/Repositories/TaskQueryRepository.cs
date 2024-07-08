using Microsoft.EntityFrameworkCore;
using TestWork.Tasks.Application.Modules.Tasks.Interfaces;
using TestWork.Tasks.Application.Modules.Tasks.Models;
using TestWork.Tasks.Dal.Context;
using TestWork.Tasks.Dal.Mappers;
using TestWork.Tasks.Domain.Modules.Tasks.Filters;
using TestWork.Tasks.Domain.Modules.Tasks.Models;

namespace TestWork.Tasks.Dal.Repositories;

internal class TaskQueryRepository(IDbContextFactory<TaskContext> contextFactory) : ITaskQueryRepository
{
    public async Task<IReadOnlyCollection<TaskListItem>> GetManyAsync(TaskFilter filter, CancellationToken token)
    {
        await using var context = await contextFactory.CreateDbContextAsync(token);
        var query = context.Tasks
            .Include(x => x.Files).Where(x => x.State != TaskStates.Deleted);

        if (filter.Skip.HasValue) query = query.Skip(filter.Skip.Value);

        if (filter.Take.HasValue) query = query.Skip(filter.Take.Value);

        var entities = await query.AsNoTracking().ToArrayAsync(token);

        return entities.Select(x => x.Map()).ToArray();
    }

    public async Task<TaskListItem?> GetAsync(TaskId id, CancellationToken token)
    {
        await using var context = await contextFactory.CreateDbContextAsync(token);
        var task = await context.Tasks.Include(x => x.Files)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id.Value, token);

        return task?.Map();
    }
}