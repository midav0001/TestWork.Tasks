using Microsoft.EntityFrameworkCore;
using TestWork.Tasks.Dal.Context;
using TestWork.Tasks.Dal.Mappers;
using TestWork.Tasks.Domain.Modules.Tasks.Models;
using TestWork.Tasks.Domain.Modules.Tasks.Repositories;

namespace TestWork.Tasks.Dal.Repositories;

/// <inheritdoc />
internal sealed class TaskRepository(IDbContextFactory<TaskContext> contextFactory) : ITaskRepository
{
    /// <inheritdoc />
    public async Task<TaskModel?> GetAsync(TaskId id, CancellationToken token)
    {
        await using var context = await contextFactory.CreateDbContextAsync(token);
        var task = await context.Tasks.Include(x => x.Files)
            .FirstOrDefaultAsync(x => x.Id == id.Value, token);

        return task?.MapToDomain();
    }

    /// <inheritdoc />
    public Task SaveAsync(TaskModel task, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}