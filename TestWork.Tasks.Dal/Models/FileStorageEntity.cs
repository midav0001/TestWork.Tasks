using System.ComponentModel.DataAnnotations.Schema;

namespace TestWork.Tasks.Dal.Models;

[Table("FileStorages")]
public class FileStorageEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Список задач файла
    /// </summary>
    public List<TaskEntity> Tasks { get; set; } = [];

    public List<TaskFileStorageEntity> TaskFileStorages { get; set; } = [];
}