using System.ComponentModel.DataAnnotations.Schema;

namespace TestWork.Tasks.Dal.Models;

[Table("TaskFileStorages")]
public class TaskFileStorageEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Идентификатор файла в файловом хранилище
    /// </summary>
    public Guid FileStorageId { get; set; }

    /// <summary>
    /// Идентификатор задачи
    /// </summary>
    public Guid TaskId { get; set; }

    public TaskEntity Task { get; set; } = null!;

    public FileStorageEntity File { get; set; } = null!;
}