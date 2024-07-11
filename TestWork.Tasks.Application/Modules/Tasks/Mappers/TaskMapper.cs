using System.Text.Json;
using TestWork.Tasks.Application.Modules.Tasks.Constants;
using TestWork.Tasks.Application.Modules.Tasks.Models;
using TestWork.Tasks.Domain.Modules.Files.Models;

namespace TestWork.Tasks.Application.Modules.Tasks.Mappers;

public static class TaskMapper
{
    public static IReadOnlyCollection<FileId> MapFiles(this IReadOnlyCollection<PropertyData> properties)
    {
        var readOnlyCollection = properties.Single(x => x.Key == PropertyNameKeys.Files).Value.ToString();
        var options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;
        var files = readOnlyCollection is null
            ? Array.Empty<FileView>()
            : JsonSerializer.Deserialize<FileView[]>(readOnlyCollection, options);
        return files?
            .Select(x => FileId.Create(x.Id))
            .ToArray() ?? Array.Empty<FileId>();
    }
}