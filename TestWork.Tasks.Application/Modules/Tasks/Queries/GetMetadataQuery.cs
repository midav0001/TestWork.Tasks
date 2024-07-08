using MediatR;
using TestWork.Tasks.Application.Modules.Tasks.Constants;
using TestWork.Tasks.Application.Modules.Tasks.Models;

namespace TestWork.Tasks.Application.Modules.Tasks.Queries;

public class GetMetadataQuery : IRequest<IReadOnlyCollection<PropertyMetadata>>
{
    internal sealed class TaskCreateHandler : IRequestHandler<GetMetadataQuery, IReadOnlyCollection<PropertyMetadata>>
    {
        public Task<IReadOnlyCollection<PropertyMetadata>> Handle(GetMetadataQuery request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult<IReadOnlyCollection<PropertyMetadata>>(new[]
            {
                new PropertyMetadata
                {
                    Key = PropertyNameKeys.Name,
                    Name = "Наименование",
                    Type = PropertyType.String,
                    IsEditable = true
                },
                new PropertyMetadata
                {
                    Key = PropertyNameKeys.State,
                    Name = "Статус",
                    Type = PropertyType.String,
                    IsEditable = false
                },
                new PropertyMetadata
                {
                    Key = PropertyNameKeys.CreateDate,
                    Name = "Дата создания",
                    Type = PropertyType.DateTime,
                    IsEditable = false
                },
                new PropertyMetadata
                {
                    Key = PropertyNameKeys.Files,
                    Name = "Файлы",
                    Type = PropertyType.File,
                    IsEditable = true
                }
            });
        }
    }
}