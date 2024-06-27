namespace TestWork.Tasks.Domain.Files;

/// <summary>
/// Доменная модель файла
/// </summary>
public class FileModel
{
    private FileModel(FileId id, string name, long size)
    {
        Id = id;
        Name = name;
        Size = size;
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
    /// Размер
    /// </summary>
    public long Size { get; }

    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="name">Наименование</param>
    /// <param name="size">Размер файла</param>
    /// <returns>Модель файла</returns>
    public FileModel Create(FileId id, string name, long size)
    {
        return new FileModel(id, name, size);
    }
}