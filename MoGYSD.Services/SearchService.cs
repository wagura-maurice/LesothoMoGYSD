using Microsoft.Extensions.DependencyInjection;
using MoGYSD.Business.Persistence;
using MoGYSD.Business.Views.Nissa.Admin;

namespace MoGYSD.Services;

public interface ISearchServiceFactory
{
    ISearchService<T> Create<T>(bool useDbContext = false) where T : class;
}
public class SearchServiceFactory : ISearchServiceFactory
{
    private readonly IServiceScopeFactory _scopeFactory;

    public SearchServiceFactory(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public ISearchService<T> Create<T>(bool useDbContext = false) where T : class
    {
        return new SearchService<T>(_scopeFactory, useDbContext);
    }
}
public interface ISearchService<T>
{
    /// <summary>
    /// Gets the data source used for searching.
    /// </summary>
    List<T> DataSource { get; }

    /// <summary>
    /// An event triggered when the search data changes.
    /// </summary>
    event Func<Task> OnChange;

    /// <summary>
    /// Initializes the search service, typically loading initial data.
    /// </summary>
    void Initialize();

    /// <summary>
    /// Refreshes the data source and triggers the OnChange event.
    /// </summary>
    Task RefreshAsync();
}
public class SearchService<T> : ISearchService<T> where T : class
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly bool _useDbContext;

    public SearchService(IServiceScopeFactory scopeFactory, bool useDbContext = false)
    {
        _scopeFactory = scopeFactory;
        _useDbContext = useDbContext;
    }

    public List<T> DataSource { get; private set; } = new();

    public event Func<Task> OnChange;

    public void Initialize()
    {
        using var scope = _scopeFactory.CreateScope();
        if (_useDbContext)
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            DataSource = dbContext.Set<T>().ToList();
        }
        else
        {
            var service = scope.ServiceProvider.GetRequiredService<IGenericService>();
            DataSource = service.GetAll<T>().ToList();
        }
    }

    public async Task RefreshAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        if (_useDbContext)
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            DataSource = dbContext.Set<T>().ToList();
        }
        else
        {
            var service = scope.ServiceProvider.GetRequiredService<IGenericService>();
            DataSource = service.GetAll<T>().ToList();
        }

        if (OnChange is not null)
            await OnChange.Invoke();
    }
}
public class SystemCodeSearchService : ISystemCodeSearchService
{
    private readonly ApplicationDbContext _context;

    public SystemCodeSearchService(IServiceScopeFactory scopeFactory)
    {
        var scope = scopeFactory.CreateScope();
        _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
    public List<SystemCodeDetailsView> DataSource { get; private set; } = new();

    public event Func<Task> OnChange;

    public void Initialize()
    {
        DataSource = _context.SystemCodeDetailsView.ToList() ?? new List<SystemCodeDetailsView>();
    }

    public void Refresh()
    {
        DataSource = _context.SystemCodeDetailsView.ToList() ?? new List<SystemCodeDetailsView>();
        OnChange?.Invoke();
    }
}
public interface ISystemCodeSearchService
{
    /// <summary>
    /// Gets the data source used for searching.
    /// </summary>
    List<SystemCodeDetailsView> DataSource { get; }

    /// <summary>
    /// An event triggered when the search data changes.
    /// </summary>
    event Func<Task> OnChange;

    /// <summary>
    /// Initializes the search service, typically loading initial data.
    /// </summary>
    void Initialize();

    /// <summary>
    /// Refreshes the data source and triggers the OnChange event.
    /// </summary>
    void Refresh();
}

