namespace TestWork.Tasks.Application.Modules.Tasks.Models;

public sealed class FileView
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Link { get; set; } = null!;
}