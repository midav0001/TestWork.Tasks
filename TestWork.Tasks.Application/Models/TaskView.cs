namespace TestWork.Tasks.Application.Models;

public class TaskView
{
    public Guid Id { get; set; }

    public required IReadOnlyCollection<PropertyData> Properties { get; set; }
}