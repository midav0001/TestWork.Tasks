using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWork.Tasks.Dal.Models;

namespace TestWork.Tasks.Dal.Configurations;

public class TaskFileStorageConfiguration : IEntityTypeConfiguration<TaskFileStorageEntity>
{
    public void Configure(EntityTypeBuilder<TaskFileStorageEntity> builder)
    {
        builder.HasData(GetSeedData());
    }

    private static TaskFileStorageEntity[] GetSeedData() =>
    [
        new TaskFileStorageEntity
        {
            Id = new Guid("e167f406-9583-498f-905c-7acaf7c39478"),
            FileStorageId = new Guid("9fa47a41-01b8-47d5-8b4c-2c29cda16bb9"),
            TaskId = new Guid("147fcc75-5a47-4684-a2c9-1a071d323b70")
        },
        new TaskFileStorageEntity
        {
            Id = new Guid("bf112e43-78aa-4ace-9f88-bfbb8edae945"),
            FileStorageId = new Guid("583c1460-501c-444f-b6ef-a1d0e6c6753a"),
            TaskId = new Guid("6fa9a90e-0189-4179-83b0-30c80790a517"),
        }
    ];
}