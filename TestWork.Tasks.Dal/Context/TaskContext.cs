using Microsoft.EntityFrameworkCore;
using TestWork.Tasks.Dal.Configurations;
using TestWork.Tasks.Dal.Models;

namespace TestWork.Tasks.Dal.Context;

public class TaskContext : DbContext
{
    /// <summary>
    /// </summary>
    public DbSet<TaskFileStorageEntity> TaskFileStorageEntities = null!;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskConfigurations());
        modelBuilder.ApplyConfiguration(new FileStorageConfiguration());
        modelBuilder.ApplyConfiguration(new TaskFileStorageConfiguration());
    }
}