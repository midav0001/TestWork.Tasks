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
    public async Task SaveAsync(TaskModel task, CancellationToken token)
    {
        await using var context = await contextFactory.CreateDbContextAsync(token);
        var existTask = await context.Tasks
            .Include(x => x.Files)
            .Include(x => x.TaskFileStorages)
            .FirstOrDefaultAsync(x => x.Id == task.Id.Value, token);

        var isNew = existTask is null;
        var entity = task.Map(existTask);

        if (isNew)
            await context.Tasks.AddAsync(entity, token);
        else
            foreach (var entry in entity.TaskFileStorages
                         .Select(taskFileStorageEntity => context.Entry(taskFileStorageEntity))
                         .Where(entry => entry.State == EntityState.Modified))
                entry.State = EntityState.Added;

        await context.SaveChangesAsync(token);
    }
}