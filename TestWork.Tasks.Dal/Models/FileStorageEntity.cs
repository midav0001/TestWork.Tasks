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
    /// Хэш файла
    /// </summary>
    public string Hash { get; set; }

    /// <summary>
    /// Размер файла
    /// </summary>
    public long Size { get; set; }
    
    /// <summary>
    /// Список задач файла
    /// </summary>
    public List<TaskEntity> Tasks { get; set; }
}