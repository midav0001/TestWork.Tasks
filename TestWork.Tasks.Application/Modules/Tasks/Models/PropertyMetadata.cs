namespace TestWork.Tasks.Application.Modules.Tasks.Models;

public sealed class PropertyMetadata
{
    public required string Key { get; set; }

    public required string Name { get; set; }


    public required PropertyType Type { get; set; }

    public required bool IsEditable { get; set; }
}