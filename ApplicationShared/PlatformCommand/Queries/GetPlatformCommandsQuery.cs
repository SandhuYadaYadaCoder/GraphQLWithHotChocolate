using ApplicationShared.PlatformCommand.ReadDtos;
using Core.CQRS.QueryManager;

namespace ApplicationShared.PlatformCommand.Queries;

public class GetPlatformCommandsQuery :IQuery<IEnumerable<CommandReadDto>>
{
}
