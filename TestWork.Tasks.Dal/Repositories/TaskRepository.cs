using Microsoft.EntityFrameworkCore;
using TestWork.Tasks.Dal.Context;
using TestWork.Tasks.Dal.Mappers;
using TestWork.Tasks.Domain.Repositories;
using TestWork.Tasks.Domain.Tasks;

namespace TestWork.Tasks.Dal.Repositories;

internal sealed class TaskRepository(IDbContextFactory<TaskContext> contextFactory) : ITaskRepository
{
    public async Task<TaskModel?> GetAsync(TaskId id, CancellationToken token)
    {
        await using var context = await contextFactory.CreateDbContextAsync(token);
        var task = await context.Tasks.Include(x => x.Files)
            .FirstOrDefaultAsync(x => x.Id == id.Value, token);

        return task?.MapToDomain();
    }

    public Task SaveAsync(TaskModel task, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}