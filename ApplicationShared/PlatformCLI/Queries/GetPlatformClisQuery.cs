using ApplicationShared.PlatformCommand.ReadDtos;
using Core.CQRS.QueryManager;

namespace ApplicationShared.PlatformCommand.Queries;

public class GetPlatformClisQuery : IQuery<IEnumerable<PlatformCliReadDto>>
{
}
