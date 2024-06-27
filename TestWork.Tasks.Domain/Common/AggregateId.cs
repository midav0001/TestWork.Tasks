namespace TestWork.Tasks.Domain.Common;

/// <summary>
/// Доменная модель идентификатора файла
/// </summary>
public abstract class AggregateId(Guid value)
{
    /// <summary>
    /// Значение
    /// </summary>
    public Guid Value { get; } = value;
}