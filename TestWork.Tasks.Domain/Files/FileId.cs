using TestWork.Tasks.Domain.Common;

namespace TestWork.Tasks.Domain.Files;

/// <summary>
/// Доменная модель идентификатора файла
/// </summary>
public sealed class FileId : AggregateId
{
    private FileId(Guid value) : base(value)
    {
    }

    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="value">Идентификатор файла</param>
    public static FileId Create(Guid value)
    {
        return new FileId(value);
    }
}