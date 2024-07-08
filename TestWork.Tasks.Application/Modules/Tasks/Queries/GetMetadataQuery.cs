using MediatR;
using TestWork.Tasks.Application.Models;

namespace TestWork.Tasks.Application.Modules.Tasks.Queries;

public class GetMetadataQuery : IRequest<IReadOnlyCollection<PropertyMetadata>>
{
    public sealed class TaskCreateHandler : IRequestHandler<GetMetadataQuery, IReadOnlyCollection<PropertyMetadata>>
    {
        public async Task<IReadOnlyCollection<PropertyMetadata>> Handle(GetMetadataQuery request,
            CancellationToken cancellationToken)
        {
            return new[]
            {
                new PropertyMetadata
                {
                    Key = "Name",
                    Name = "Наименование",
                    Type = PropertyType.String,
                    IsEditable = true
                },
                new PropertyMetadata
                {
                    Key = "State",
                    Name = "Статус",
                    Type = PropertyType.String,
                    IsEditable = false
                },
                new PropertyMetadata
                {
                    Key = "CreateDate",
                    Name = "Дата создания",
                    Type = PropertyType.DateTime,
                    IsEditable = false
                }
            };
        }
    }
}