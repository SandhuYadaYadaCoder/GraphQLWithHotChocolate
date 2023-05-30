using ApplicationShared.Platform.ReadDtos;
using Core.CQRS.QueryManager;

namespace ApplicationShared.Platform.Queries;

public class GetPlatformsQuery : IQuery<IEnumerable<PlatformReadDto>>
{
    
}
