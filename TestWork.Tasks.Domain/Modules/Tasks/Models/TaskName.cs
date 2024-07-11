using TestWork.Tasks.Domain.Exceptions;

namespace TestWork.Tasks.Domain.Modules.Tasks.Models;

/// <summary>
/// Наименование задачи
/// </summary>
public sealed class TaskName
{
    private TaskName(string value)
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
    public static TaskName Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValidationException("Необходимо задать наименование задачи");
        }

        return new TaskName(value);
    }
}