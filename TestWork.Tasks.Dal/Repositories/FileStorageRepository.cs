using Microsoft.EntityFrameworkCore;
using TestWork.Tasks.Dal.Context;
using TestWork.Tasks.Dal.Mappers;
using TestWork.Tasks.Domain.Modules.Files.Models;
using TestWork.Tasks.Domain.Modules.Files.Repositories;

namespace TestWork.Tasks.Dal.Repositories;

/// <inheritdoc />
internal sealed class FileStorageRepository(IDbContextFactory<TaskContext> contextFactory) : IFileStorageRepository
{
    /// <inheritdoc />
    public async Task<FileModel?> GetAsync(FileId id, CancellationToken token)
    {
        await using var context = await contextFactory.CreateDbContextAsync(token);

        var file = await context.Files.FirstOrDefaultAsync(x => x.Id == id.Value, token);

        return file?.Map();
    }

    /// <inheritdoc />
    public async Task SaveAsync(FileModel file, CancellationToken token)
    {
        await using var context = await contextFactory.CreateDbContextAsync(token);
        var fileStorageEntity = file.Map();
        await context.Files.AddAsync(fileStorageEntity, token);
        await context.SaveChangesAsync(token);
    }
}