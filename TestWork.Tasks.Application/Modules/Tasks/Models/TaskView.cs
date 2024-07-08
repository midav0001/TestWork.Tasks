namespace TestWork.Tasks.Application.Modules.Tasks.Models;

public class TaskView
{
    public Guid Id { get; set; }

    public required IReadOnlyCollection<PropertyData> Properties { get; set; }
}