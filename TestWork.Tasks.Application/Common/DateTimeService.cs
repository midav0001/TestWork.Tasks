namespace TestWork.Tasks.Application.Common;

/// <summary>
///     Сервис для работы с датой и временем
/// </summary>
public interface IDateTimeService
{
    /// <summary>
    ///     Текущая дата и время
    /// </summary>
    DateTime CurrentDateTime { get; }
}

///<inheritdoc />
internal sealed class DateTimeService : IDateTimeService
{
    ///<inheritdoc />
    public DateTime CurrentDateTime => DateTime.Now;
}