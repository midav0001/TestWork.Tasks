using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWork.Tasks.Dal.Models;
using TestWork.Tasks.Domain.Modules.Tasks.Models;

namespace TestWork.Tasks.Dal.Configurations;

internal sealed class TaskConfigurations : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.HasMany(x => x.Files)
            .WithMany(x => x.Tasks)
            .UsingEntity<TaskFileStorageEntity>(
                j => j
                    .HasOne(pt => pt.File)
                    .WithMany(t => t.TaskFileStorages)
                    .HasForeignKey(pt => pt.FileStorageId),
                j => j
                    .HasOne(pt => pt.Task)
                    .WithMany(p => p.TaskFileStorages)
                    .HasForeignKey(pt => pt.TaskId));

        builder.HasData(GetSeedData());
    }

    private static TaskEntity[] GetSeedData() =>
    [
        new TaskEntity
        {
            Id = new Guid("147fcc75-5a47-4684-a2c9-1a071d323b70"),
            Name = "Задача 1",
            State = TaskStates.Finished,
            CreateDate = new DateTime(2024, 1, 1),
        },
        new TaskEntity
        {
            Id = new Guid("6fa9a90e-0189-4179-83b0-30c80790a517"),
            Name = "Задача 2",
            State = TaskStates.InProcess,
            CreateDate = new DateTime(2024, 1, 2),
        },
        new TaskEntity
        {
            Id = new Guid("e228d8f9-e2e9-4724-bed4-3222fba66ae2"),
            Name = "Задача 3",
            State = TaskStates.New,
            CreateDate = new DateTime(2024, 1, 3)
        }
    ];
}