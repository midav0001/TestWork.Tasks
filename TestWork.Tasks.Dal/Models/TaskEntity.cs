using System.ComponentModel.DataAnnotations.Schema;
using TestWork.Tasks.Domain.Modules.Tasks.Models;

namespace TestWork.Tasks.Dal.Models;

[Table("Tasks")]
public class TaskEntity
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
    /// Статус
    /// </summary>
    public TaskStates State { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Список файлов задачи
    /// </summary>
    public List<FileStorageEntity> Files { get; set; } = [];

    public List<TaskFileStorageEntity> TaskFileStorages { get; set; } = [];
}