namespace TestWork.Tasks.Domain.Modules.Files.Models;

/// <summary>
/// Доменная модель файла
/// </summary>
public class FileModel
{
    private FileModel(FileId id, string name)
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    /// Идентификатор файла
    /// </summary>
    public FileId Id { get; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; }


    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="name">Наименование</param>
    /// <returns>Модель файла</returns>
    public static FileModel Create(FileId id, string name)
    {
        return new FileModel(id, name);
    }

    /// <summary>
    /// Восстановить. Метод для восстановления модели из бд
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="name">Наименование</param>
    /// <returns>Модель файла</returns>
    public static FileModel Restore(FileId id, string name)
    {
        return new FileModel(id, name);
    }
}