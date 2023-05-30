using ApplicationShared.Platform.ReadDtos;
using Core.CQRS.QueryManager;

namespace ApplicationShared.Platform.Queries;
public class GetPlatformByIdQuery : IQuery<PlatformReadDto>
{
    public GetPlatformByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
