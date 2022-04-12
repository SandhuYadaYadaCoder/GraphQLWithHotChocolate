using HotChocolate.Subscriptions;

namespace Api.GraphQL;

public partial class Mutation
{
    //[UseDbContext(typeof(AppDbContext))]
    //public async Task<AddPlatformPayload> AddPlatformAsync(
    //    AddPlatformInput addPlatformInput, 
    //    [ScopedService] AppDbContext appDbContext,
    //    [Service] ITopicEventSender eventSender,
    //    CancellationToken cancellationToken)
    //{
    //    Platform platform = new() { Name = addPlatformInput.Name, LicenseKey = GuidExtension.FromString(addPlatformInput.Name) };

    //    appDbContext.Platforms.Add(platform);

    //    await appDbContext.SaveChangesAsync(cancellationToken);

    //    await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

    //    return new AddPlatformPayload(platform);
    //}

    //[UseDbContext(typeof(AppDbContext))]
    //public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput addCommandInput, [ScopedService] AppDbContext appDbContext)
    //{
    //    Command command = new()
    //    {
    //        CommandLine = addCommandInput.CommandLine,
    //        HowTo = addCommandInput.HowTo,
    //        PlatformId = addCommandInput.PlatformId
    //    };

    //    appDbContext.Commands.Add(command);

    //    await appDbContext.SaveChangesAsync();

    //    return new AddCommandPayload(command);
    //}
}
