using TestWork.Tasks.Dal.Models;
using TestWork.Tasks.Domain.Files;

namespace TestWork.Tasks.Dal.Mappers;

public static class FileMapper
{
    public static FileModel Map(this FileStorageEntity entity)
    {
        var fileId = FileId.Create(entity.Id);
        return FileModel.Restore(fileId, entity.Name);
    }

    public static FileStorageEntity Map(this FileModel model)
    {
        return new FileStorageEntity
        {
            Name = model.Name,
            Id = model.Id.Value
        };
    }
}