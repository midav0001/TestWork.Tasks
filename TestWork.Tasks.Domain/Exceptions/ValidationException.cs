namespace TestWork.Tasks.Domain.Exceptions;

/// <summary>
/// Ошибка валидации доменной модели
/// </summary>
public class ValidationException(string msg) : Exception(msg);