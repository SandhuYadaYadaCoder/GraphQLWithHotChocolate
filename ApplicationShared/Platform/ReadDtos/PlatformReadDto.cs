using ApplicationShared.PlatformCommand.ReadDtos;

namespace ApplicationShared.Platform.ReadDtos;

public record PlatformReadDto(int Id, string Name, IEnumerable<PlatformCliReadDto>? Commands);