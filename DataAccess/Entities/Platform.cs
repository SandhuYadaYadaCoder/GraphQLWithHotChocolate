namespace DataAccess.Entities;

public class Platform : EntityBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LicenseKey { get; set; }
    public IEnumerable<PlatformCommand> Commands { get; set; }
}
