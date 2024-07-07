using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWork.Tasks.Dal.Models;

namespace TestWork.Tasks.Dal.Configurations;

public class FileStorageConfiguration : IEntityTypeConfiguration<FileStorageEntity>
{
    public void Configure(EntityTypeBuilder<FileStorageEntity> builder)
    {
        builder.HasData(GetSeedData());
    }

    private static FileStorageEntity[] GetSeedData() =>
    [
        new FileStorageEntity
        {
            Id = new Guid("9fa47a41-01b8-47d5-8b4c-2c29cda16bb9"),
            Name = "Test.png"
        },
        new FileStorageEntity
        {
            Id = new Guid("583c1460-501c-444f-b6ef-a1d0e6c6753a"),
            Name = "Test2.png"
        },
    ];
}