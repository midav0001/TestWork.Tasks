using TestWork.Tasks.Dal.Models;
using TestWork.Tasks.Domain.Files;
using TestWork.Tasks.Domain.Tasks;

namespace TestWork.Tasks.Dal.Mappers;

public static class TaskMapper
{
    public static TaskModel Map(this TaskEntity entity)
    {
        var id = TaskId.Create(entity.Id);
        var name = TaskName.Create(entity.Name);
        var fileIds = entity.Files.Select(x => FileId.Create(x.Id)).ToArray();
        return TaskModel.Restore(id, name, fileIds, entity.CreateDate, entity.State);
    }
}