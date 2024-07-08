using TestWork.Tasks.Application.Models;
using TestWork.Tasks.Dal.Models;
using TestWork.Tasks.Domain.Files;
using TestWork.Tasks.Domain.Tasks;

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
}