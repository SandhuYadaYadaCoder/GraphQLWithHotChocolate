using ApplicationShared.Platform.ReadDtos;

namespace ApplicationShared.PlatformCommand.ReadDtos;

public record PlatformCliReadDto(
    int Id, 
    string HowTo, 
    string CommandLine, 
    int PlatformId,
    PlatformReadDto? Platform = null);