using ApplicationShared.Platform.Queries;
using ApplicationShared.Platform.ReadDtos;
using ApplicationShared.PlatformCommand.Queries;
using ApplicationShared.PlatformCommand.ReadDtos;
using Core.CQRS.QueryManager;
using Core.UnitOfWorkManager;
using DataAccess;
using PlatformEntity = DataAccess.Entities.Platform;

namespace Api.GraphQL;

public class Query
{
    private readonly AppDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger;

    public Query(AppDbContext dbContext, IUnitOfWork unitOfWork, ILogger logger)
    {
        _dbContext = dbContext;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    /// <summary>
    /// Not going to work as graphql wan't to have control of DbContext so that it could perform filtering and stuff.
    /// </summary>
    /// <param name="queryManager"></param>
    /// <param name="unitOfWork"></param>
    /// <returns></returns>
    [UseDbContext(typeof(AppDbContext))]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<PlatformEntity>> GetPlatforms([ScopedService] IQueryManager queryManager, 
        [ScopedService] IUnitOfWork unitOfWork)
    {
        return await queryManager.Send(new GetPlatformsQuery(unitOfWork));
    }

    /// <summary>
    /// This is the perfect implementation of Graphql and CQRS.
    /// </summary>
    /// <param name="queryManager"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    [UseDbContext(typeof(AppDbContext))]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<PlatformEntity>> GetPlatformsVersion2([ScopedService] IQueryManager queryManager, 
        [ScopedService] AppDbContext context)
    {
        try
        {

            var result = await queryManager.Send(new GetPlatformsVersion2Query(context));
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError($"Message: {e.Message}");
            _logger.LogError($"Inner Message: {e.InnerException}".ToString());
            throw;
        }
    }


    /// <summary>
    /// Not going to work, as graphql would execute the query on the database and it needs to be done on entity and not Dto
    /// </summary>
    /// <param name="queryManager"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    [UseDbContext(typeof(AppDbContext))]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<PlatformReadDto>> GetPlatformsVersion3([ScopedService] IQueryManager queryManager,
        [ScopedService] AppDbContext context)
    {
        try
        {

            var result = await queryManager.Send(new GetPlatformsVersion3Query(context));
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError($"Message: {e.Message}");
            _logger.LogError($"Inner Message: {e.InnerException}".ToString());
            throw;
        }
    }

    [UseFiltering]
    [UseSorting]
    public async Task<PlatformReadDto?> GetPlatformById(int id, [ScopedService] IQueryManager queryManager)
    {
        PlatformReadDto platform = await queryManager.Send(new GetPlatformByIdQuery(_unitOfWork, id: id));
        return platform;
    }


    [UseFiltering]
    [UseSorting]
    public async Task<List<PlatformCliReadDto>> GetCommands([ScopedService] IQueryManager queryManager)
    {
        IEnumerable<PlatformCliReadDto> platformCommands = await queryManager.Send(new GetPlatformClisQuery(_unitOfWork));
        return platformCommands.ToList();
    }
}
