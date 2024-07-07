using Microsoft.EntityFrameworkCore;
using TestWork.Tasks.Dal.Models;

namespace TestWork.Tasks.Dal.Context;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
    }

    /// <summary>
    /// Задачи
    /// </summary>
    public DbSet<TaskEntity> Tasks { get; set; } = null!;

    /// <summary>
    /// Файлы
    /// </summary>
    public DbSet<FileStorageEntity> Files { get; set; } = null!;
}