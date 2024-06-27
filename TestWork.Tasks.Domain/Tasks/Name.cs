using TestWork.Tasks.Domain.Exceptions;

namespace TestWork.Tasks.Domain.Tasks;

/// <summary>
/// Наименование задачи
/// </summary>
public sealed class Name
{
    private Name(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Значение
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="value">Значение</param>
    /// <returns>Доменная модель наименования</returns>
    public Name Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValidationException("Необходимо задать наименование задачи");
        }

        return new Name(value);
    }
}