using TestWork.Tasks.Application.Modules.Tasks.Models;
using TestWork.Tasks.Dal.Models;
using TestWork.Tasks.Domain.Modules.Files.Models;
using TestWork.Tasks.Domain.Modules.Tasks.Models;

namespace TestWork.Tasks.Dal.Mappers;

public static class TaskMapper
{
    public static TaskModel MapToDomain(this TaskEntity entity)
    {
        var id = TaskId.Create(entity.Id);
        var name = TaskName.Create(entity.Name);
        var fileIds = entity.Files.Select(x => FileId.Create(x.Id)).ToArray();
        return TaskModel.Restore(id, name, fileIds, entity.CreateDate, entity.State);
    }

    public static TaskListItem Map(this TaskEntity entity)
    {
        return new TaskListItem
        {
            Id = entity.Id,
            State = entity.State,
            CreateDate = entity.CreateDate,
            Name = entity.Name,
            Files = entity.Files.Select(x => new FileListItem
            {
                Id = x.Id,
                Name = x.Name
            }).ToArray()
        };
    }

    public static TaskEntity Map(this TaskModel model, TaskEntity? existEntity)
    {
        existEntity ??= new TaskEntity
        {
            Id = model.Id.Value
        };

        existEntity.Name = model.Name.Value;
        existEntity.CreateDate = model.CreateDate;
        existEntity.State = model.State;

        MapFiles(existEntity.TaskFileStorages, model.FileIds, model.Id);

        return existEntity;
    }

    private static void MapFiles(List<TaskFileStorageEntity> existFiles,
        IReadOnlyCollection<FileId> actualFiles, TaskId taskId)
    {
        var actualFileIds = actualFiles.Select(x => x.Value).ToArray();
        var removingFiles = existFiles.Where(x => !actualFileIds.Contains(x.FileStorageId)).ToArray();

        foreach (var removingFile in removingFiles) existFiles.Remove(removingFile);

        foreach (var actualFile in actualFiles)
        {
            var isExist = existFiles.Any(x => x.FileStorageId == actualFile.Value);

            if (isExist) continue;

            var newFile = new TaskFileStorageEntity
            {
                Id = Guid.NewGuid(),
                TaskId = taskId.Value,
                FileStorageId = actualFile.Value
            };

            existFiles.Add(newFile);
        }
    }
}