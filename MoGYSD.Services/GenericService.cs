using System.Data;
using System.Linq.Expressions;
using MoGYSD.Services.Repository;
using Dapper;
using Humanizer;
using Microsoft.Data.SqlClient;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.ViewModels;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using MoGYSD.Business.Models.Common;

namespace MoGYSD.Services;
public interface IGenericService
{
    List<TEntity> AddRange<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class;

    int Create<TEntity>(TEntity entity)
        where TEntity : class;
    Task<int> Add<TEntity>(TEntity entity, bool UseSentenceCase = true)
        where TEntity : class;
    Task AddOrUpdate<TEntity>(TEntity entity)
        where TEntity : class;

    Task AddOrUpdateAsync<TEntity>(TEntity entity) where TEntity : class;

    void Delete<TEntity>(object id)
        where TEntity : class;

    void Delete<TEntity>(TEntity entity)
        where TEntity : class;

    void DeleteRange<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class;

    IEnumerable<TEntity> Get<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where TEntity : class;

    IEnumerable<TEntity> GetAll<TEntity>(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where TEntity : class;

    Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where TEntity : class;

    Task<IEnumerable<TEntity>> GetAsync<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where TEntity : class;

    TEntity GetById<TEntity>(object id)
        where TEntity : class;

    Task<TEntity> GetByIdAsync<TEntity>(object id)
        where TEntity : class;

    int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
        where TEntity : class;

    Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
        where TEntity : class;

    bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
        where TEntity : class;

    Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
        where TEntity : class;

    TEntity GetFirst<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null)
        where TEntity : class;

    Task<TEntity> GetFirstAsync<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null)
        where TEntity : class;

    //IEnumerable<TEntity> GetManyBySp<TEntity>(
    //    string procName,
    //    string parameterNames = null,
    //    List<ParameterEntity> parameterValues = null)
    //    where TEntity : class;

    TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        where TEntity : class;

    Task<IQueryable<TEntity>> GetSearchableQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,
        int? skip = null, int? take = null) where TEntity : class;

    Task<TEntity> GetOneAsync<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        string includeProperties = null)
        where TEntity : class;

    //TEntity GetOneBySp<TEntity>(
    //    string procName,
    //    string parameterNames = null,
    //    List<ParameterEntity> parameterValues = null)
    //    where TEntity : class;

    void RemoveRange<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class;
    void Save();
    Task SaveAsync();
    Task Update<TEntity>(TEntity entity, bool UseSentenceCase = true) where TEntity : class;
    IQueryable<TResult> GetSet<TResult, TKey, TEntity>(
        Expression<Func<TEntity, TResult>> firstSelector,
        Expression<Func<TResult, TKey>> orderBy,
        Expression<Func<TEntity, bool>> filter = null,
        int? skip = null,
        int? take = null)
        where TEntity : class;
    IQueryable<TReturn> GetGroupedSet<TResult, TKey, TGroup, TReturn, TEntity>(
        Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> firstSelector,
        Expression<Func<TResult, TKey>> orderSelector, Func<TResult, TGroup> groupSelector,
        Func<IGrouping<TGroup, TResult>, TReturn> selector, int? skip, int? take) where TEntity : class;

    IList<TReturn> GetGrouped<TResult, TKey, TGroup, TReturn, TEntity>(Expression<Func<TEntity, bool>> filter,
        Expression<Func<TEntity, TResult>> firstSelector, Expression<Func<TResult, TKey>> orderSelector, Func<TResult, TGroup> groupSelector, Func<IGrouping<TGroup, TResult>, TReturn> selector,
        int? skip = null,
        int? take = null) where TEntity : class;

    //StateViewModel<IEnumerable<T>> Query<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure);
    //StateViewModel<T> QueryFirstOrDefault<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure);
    //StateViewModel<T> QuerySingleOrDefault<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure);
    //StateViewModel<T> QuerySingle<T>(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure);
    //StateViewModel<T> QueryFirst<T>(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure);
    //StateViewModel<SqlMapper.GridReader> QueryMultiple(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure);

    Task<StateViewModel<IEnumerable<T>>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure);
    Task<StateViewModel<T>> QueryFirstOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure);
    Task<StateViewModel<T>> QuerySingleOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure);
    Task<StateViewModel<T>> QuerySingleAsync<T>(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure);
    Task<StateViewModel<T>> QueryFirstAsync<T>(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure);
    Task<StateViewModel<SqlMapper.GridReader>> QueryMultipleAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure);
    void Dispose();
}

public class GenericService : IGenericService
{

    protected readonly IGenericRepository _genericRepository;
    protected readonly IDBService _dbService;
    protected readonly UserProfileService _userProfileService;
    protected readonly ISentenceCaseService _sentenceCaseService;
    public GenericService(IGenericRepository iRepository, IDBService dbService, UserProfileService userProfileService, ISentenceCaseService sentenceCaseService)
    {
        _genericRepository = iRepository;
        _dbService = dbService;
        _userProfileService = userProfileService;
        _sentenceCaseService = sentenceCaseService;
    }
    /// <summary>
    /// Adds a collection of entities to the repository after processing them with sentence case conversion and audit fields
    /// </summary>
    /// <typeparam name="TEntity">The type of entity being added</typeparam>
    /// <param name="entities">The collection of entities to add</param>
    /// <returns>List of processed entities that were added</returns>
    /// <exception cref="InvalidOperationException">Thrown when trying to add auditable entities without a logged-in user</exception>
    /// <remarks>
    /// This method performs the following operations:
    /// 1. Applies sentence case formatting to all string properties in each entity
    /// 2. Sets audit fields (CreatedOn, CreatedById) for auditable entities
    /// 3. Validates user context for auditable entities
    /// 4. Persists all changes to the repository
    /// </remarks>
    public List<TEntity> AddRange<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class
    {
        // Get current user context and timestamp
        var userId = _userProfileService.UserId;
        var now = DateTime.Now;

        foreach (var entity in entities)
        {
            _sentenceCaseService.ProcessEntityStrings(entity);
            if (entity is BaseAuditableEntity<int> auditableEntity)
            {
                if (string.IsNullOrWhiteSpace(userId))
                {
                    throw new InvalidOperationException("User must be logged in to add auditable entities.");
                }

                auditableEntity.CreatedOn = now;
                auditableEntity.CreatedById = userId;
            }
        }
        _genericRepository.AddRange(entities);
        _genericRepository.Save();

        return entities.ToList();
    }
    public async Task<int> Add<TEntity>(TEntity entity, bool UseSentenceCase = true)
        where TEntity : class/*, IHasUniqueKey<TEntity>*/
    {
        var now = DateTime.Now;
        var userId = _userProfileService.UserId;

        if (UseSentenceCase)
            _sentenceCaseService.ProcessEntityStrings(entity);
        // Prevent saving BaseAuditableEntity if userId is null
        if (entity is BaseAuditableEntity<int> auditableEntity)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                // You can log this or throw an exception based on preference
                throw new InvalidOperationException("User must be logged in to perform this operation.");
            }
            auditableEntity.CreatedOn = now;
            auditableEntity.CreatedById = userId;
        }
        _genericRepository.Add(entity);
        var record = JsonConvert.SerializeObject(entity, Formatting.Indented,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });

        var auditTrail = new AuditTrail
        {
            ChangeType = "Create",
            Description = $"{JsonConvert.SerializeObject("Created")}",
            TableName = entity.GetType().Name.Pluralize(),
            NewValue = record
        };
        await _dbService.AuditTrail(auditTrail);
        return _genericRepository.Save();
    }
    public int Create<TEntity>(TEntity entity)
        where TEntity : class
    {
        var now = DateTime.Now;
        var userId = _userProfileService.UserId;
        _sentenceCaseService.ProcessEntityStrings(entity);
        // Prevent saving BaseAuditableEntity if userId is null
        if (entity is BaseAuditableEntity<int> auditableEntity)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                // You can log this or throw an exception based on preference
                throw new InvalidOperationException("User must be logged in to perform this operation.");
            }
            auditableEntity.CreatedOn = now;
            auditableEntity.CreatedById = userId;
        }
        _genericRepository.Create(entity);
        return _genericRepository.Save();
    }
    public void Delete<TEntity>(object id)
        where TEntity : class
    {
        _genericRepository.Delete<TEntity>(id);
        _genericRepository.Save();
    }
    public void Delete<TEntity>(TEntity entity)
        where TEntity : class
    {
        _genericRepository.Delete(entity);
        _genericRepository.Save();
    }
    public void DeleteRange<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class
    {
        foreach (var entity in entities)
        {
            _genericRepository.Delete(entity);
        }

        _genericRepository.Save();
    }
    public IEnumerable<TEntity> Get<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where TEntity : class
    {
        return _genericRepository.Get(filter, orderBy, includeProperties, skip, take);
    }
    public IEnumerable<TEntity> GetAll<TEntity>(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where TEntity : class
    {
        return _genericRepository.GetAll(orderBy, includeProperties, skip, take);
    }
    public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where TEntity : class
    {
        return await _genericRepository.GetAllAsync(orderBy, includeProperties, skip, take);
    }
    public async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where TEntity : class
    {
        return await _genericRepository.GetAsync(filter, orderBy, includeProperties, skip, take);
    }
    public TEntity GetById<TEntity>(object id)
        where TEntity : class
    {
        return _genericRepository.GetById<TEntity>(id);
    }
    public async Task<TEntity> GetByIdAsync<TEntity>(object id)
        where TEntity : class
    {
        return await _genericRepository.GetByIdAsync<TEntity>(id);
    }
    public int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
        where TEntity : class
    {
        return _genericRepository.GetCount(filter);
    }
    public async Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
        where TEntity : class
    {
        return await _genericRepository.GetCountAsync(filter);
    }
    public bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
        where TEntity : class
    {
        return _genericRepository.GetExists(filter);
    }
    public async Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
        where TEntity : class
    {
        return await _genericRepository.GetExistsAsync(filter);
    }
    public TEntity GetFirst<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null)
        where TEntity : class
    {
        return _genericRepository.GetFirst(filter, orderBy, includeProperties);
    }
    public async Task<TEntity> GetFirstAsync<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null)
        where TEntity : class
    {
        return await _genericRepository.GetFirstAsync(filter, orderBy, includeProperties);
    }
    public IEnumerable<TEntity> GetManyBySp<TEntity>(
        string procName,
        string parameterNames = null,
        List<ParameterEntity> parameterValues = null)
        where TEntity : class
    {
        return _genericRepository.GetManyBySp<TEntity>(procName, parameterNames, parameterValues);
    }
    public TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        where TEntity : class
    {
        return _genericRepository.GetOne(filter, includeProperties);
    }
    public Task<IQueryable<TEntity>> GetSearchableQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,
        int? skip = null, int? take = null) where TEntity : class
    {
        return _genericRepository.GetSearchableQueryable(filter, orderBy, includeProperties, skip, take);
    }
    public async Task<TEntity> GetOneAsync<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        string includeProperties = null)
        where TEntity : class
    {
        return await _genericRepository.GetOneAsync(filter, includeProperties);
    }
    public void RemoveRange<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class
    {
        _genericRepository.RemoveRange(entities);
        _genericRepository.Save();
    }
    public void Save()
    {
        _genericRepository.Save();
    }
    public async Task SaveAsync()
    {
        await _genericRepository.SaveAsync();
    }
    public async Task Update<TEntity>(TEntity entity, bool UseSentenceCase = true)
    where TEntity : class
    {
        var context = _genericRepository.GetContext();
        var entityType = context.Model.FindEntityType(typeof(TEntity));
        var key = entityType.FindPrimaryKey().Properties.First();
        var keyValue = key.PropertyInfo.GetValue(entity);

        // Detach local tracked entity with the same key (if any)
        var local = context.Set<TEntity>().Local
            .FirstOrDefault(entry => key.PropertyInfo.GetValue(entry).Equals(keyValue));
        if (local != null && !ReferenceEquals(local, entity))
        {
            context.Entry(local).State = EntityState.Detached;
        }

        var dbEntry = context.Entry(entity);

        if (UseSentenceCase)
            _sentenceCaseService.ProcessEntityStrings(entity);
        var now = DateTime.Now;
        var userId = _userProfileService.UserId;

        // Prevent saving BaseAuditableEntity if userId is null
        if (entity is BaseAuditableEntity<int> auditableEntity)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new InvalidOperationException("User must be logged in to perform this operation.");
            }
            auditableEntity.ModifiedOn = now;
            auditableEntity.ModifiedById = userId;
        }

        var changes = new List<string>();
        foreach (var property in dbEntry.OriginalValues.Properties)
        {
            try
            {
                var originalValue = dbEntry.GetDatabaseValues().GetValue<object>(property.Name);
                var currentValue = dbEntry.Property(property.Name).CurrentValue;

                if (!Equals(originalValue, currentValue))
                {
                    changes.Add(property.Name + ": " + originalValue + " -> " + currentValue);
                }
            }
            catch
            {
            }
        }

        var auditTrail = new AuditTrail
        {
            Date = DateTime.Now,
            UserId = userId,
            ChangeType = "Update",
            Description = $"{JsonConvert.SerializeObject(changes)}",
            TableName = entity.GetType().Name.Pluralize()
        };
        _genericRepository.Update(entity);
        await _dbService.AuditTrail(auditTrail);
        _genericRepository.Save();
    }

    public async Task AddOrUpdate<TEntity>(TEntity entity)
        where TEntity : class
    {
        var dbEntry = _genericRepository.GetContext().Entry(entity);
        var id = "";
        try
        {
            id = dbEntry.Property("Id").CurrentValue.ToString();
        }
        catch
        {

        }
        _sentenceCaseService.ProcessEntityStrings(entity);
        var now = DateTime.Now;
        var userId = _userProfileService.UserId;

        // Prevent saving BaseAuditableEntity if userId is null
        if (entity is BaseAuditableEntity<int> auditableEntity)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                // You can log this or throw an exception based on preference
                throw new InvalidOperationException("User must be logged in to perform this operation.");
            }

             id = dbEntry.Property("Id")?.CurrentValue?.ToString();
            if (string.IsNullOrEmpty(id) || id == "0")
            {
                auditableEntity.CreatedOn = now;
                auditableEntity.CreatedById = userId;
            }
            else
            {
                auditableEntity.ModifiedOn = now;
                auditableEntity.ModifiedById = userId;
            }
        }

        //var originalValues = _dbSet.Find(id);
        var changes = new List<string>();
        foreach (var property in dbEntry.OriginalValues.Properties)
        {
            try
            {
                var originalValue = dbEntry.GetDatabaseValues().GetValue<object>(property.Name);
                var currentValue = dbEntry.Property(property.Name).CurrentValue;

                if (!Equals(originalValue, currentValue))
                {
                    changes.Add(property.Name + ": " + originalValue + " -> " + currentValue);
                }
            }
            catch
            {
            }
        }


        var auditTrail = new AuditTrail
        {
            Date = DateTime.Now,
            UserId = userId,
            ChangeType = "Update",
            Description = $"{JsonConvert.SerializeObject(changes)}",
            TableName = entity.GetType().Name.Pluralize()

            // NewValue = JsonConvert.SerializeObject((entity)),
        };
        if (string.IsNullOrEmpty(id) || id.Equals("0"))
        {
            _genericRepository.Add(entity);
        }
        else
        {
            _genericRepository.Update(entity);
        }
        await _dbService.AuditTrail(auditTrail);
        _genericRepository.Save();
    }
    public async Task AddOrUpdateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        var dbContext = _genericRepository.GetContext();
        var dbEntry = dbContext.Entry(entity);
        var now = DateTime.Now;
        var userId = _userProfileService.UserId;
        _sentenceCaseService.ProcessEntityStrings(entity);
        // Prevent saving BaseAuditableEntity if userId is null
        if (entity is BaseAuditableEntity<int> auditableEntity)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                // You can log this or throw an exception based on preference
                throw new InvalidOperationException("User must be logged in to perform this operation.");
            }

            var id = dbEntry.Property("Id")?.CurrentValue?.ToString();
            if (string.IsNullOrEmpty(id) || id == "0")
            {
                auditableEntity.CreatedOn = now;
                auditableEntity.CreatedById = userId;
            }
            else
            {
                auditableEntity.ModifiedOn = now;
                auditableEntity.ModifiedById = userId;
            }
        }

        // Change tracking (optional audit logging)
        var changes = new List<string>();
        try
        {
            var dbValues = dbEntry.GetDatabaseValues();
            foreach (var prop in dbEntry.OriginalValues.Properties)
            {
                var original = dbValues?.GetValue<object>(prop.Name);
                var current = dbEntry.Property(prop.Name).CurrentValue;
                if (!Equals(original, current))
                {
                    changes.Add($"{prop.Name}: {original} -> {current}");
                }
            }
        }
        catch { /* optional: log */ }

        var auditTrail = new AuditTrail
        {
            ChangeType = (dbEntry.State == EntityState.Added || string.IsNullOrEmpty(dbEntry.Property("Id")?.CurrentValue?.ToString())) ? "Create" : "Update",
            Description = JsonConvert.SerializeObject(changes),
            TableName = entity.GetType().Name.Pluralize()
        };

        // Add or update entity
        var isNew = string.IsNullOrEmpty(dbEntry.Property("Id")?.CurrentValue?.ToString()) || dbEntry.Property("Id")?.CurrentValue?.ToString() == "0";
        if (isNew)
        {
            _genericRepository.Add(entity);
        }
        else
        {
            _genericRepository.Update(entity);
        }

        await _dbService.AuditTrail(auditTrail);
        await _genericRepository.SaveAsync();
    }
    public IQueryable<TResult> GetSet<TResult, TKey, TEntity>(
        Expression<Func<TEntity, TResult>> firstSelector,
        Expression<Func<TResult, TKey>> orderBy,
        Expression<Func<TEntity, bool>> filter = null,
        int? skip = null,
        int? take = null)
            where TEntity : class
    {
        return _genericRepository.GetSet(firstSelector, orderBy, filter, skip, take);
    }
    public IQueryable<TReturn> GetGroupedSet<TResult, TKey, TGroup, TReturn, TEntity>(
        Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> firstSelector,
        Expression<Func<TResult, TKey>> orderSelector, Func<TResult, TGroup> groupSelector,
        Func<IGrouping<TGroup, TResult>, TReturn> selector, int? skip, int? take) where TEntity : class
    {
        return _genericRepository.GetGroupedSet(filter, firstSelector, orderSelector, groupSelector, selector, skip,
            take);
    }
    public IList<TReturn> GetGrouped<TResult, TKey, TGroup, TReturn, TEntity>(Expression<Func<TEntity, bool>> filter,
        Expression<Func<TEntity, TResult>> firstSelector, Expression<Func<TResult, TKey>> orderSelector, Func<TResult, TGroup> groupSelector, Func<IGrouping<TGroup, TResult>, TReturn> selector,
        int? skip = null,
        int? take = null) where TEntity : class
    {
        return _genericRepository.GetGrouped(filter,
            firstSelector, orderSelector, groupSelector, selector, skip, take);
    }

    /*Dapper function wrappers*/
    public StateViewModel<IEnumerable<T>> Query<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure)
    {
        StateViewModel<IEnumerable<T>> state = new StateViewModel<IEnumerable<T>>();
        try
        {
            IEnumerable<T> value;
            using (IDbConnection db = new SqlConnection(_dbService.DBConnection()))
            {
                value = db.Query<T>(sql + "  ", param, commandType: commandType, commandTimeout: commandTimeout);

            }
            if (value != null)
            {
                state.Code = 200;

                state.Msg = "Success";

                state.Data = value;
            }
            else
            {
                state.Code = 300;

                state.Msg = "No Record Found";
            }
        }
        catch (Exception msg)
        {
            // ElmahExtensions.RaiseError(msg);

            state.Code = 500;

            state.Msg = msg.Message;
        }

        return state;


    }
    public StateViewModel<T> QueryFirstOrDefault<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure)
    {
        StateViewModel<T> state = new StateViewModel<T>();
        try
        {
            T value;
            using (IDbConnection db = new SqlConnection(_dbService.DBConnection()))
            {
                value = db.QueryFirstOrDefault<T>(sql + "  ", param: param, commandType: commandType, commandTimeout: commandTimeout);

            }
            if (value != null)
            {
                state.Code = 200;

                state.Msg = "Success";

                state.Data = value;
            }
            else
            {
                state.Code = 300;

                state.Msg = "No Record Found";
            }
        }
        catch (Exception msg)
        {
            // ElmahExtensions.RaiseError(msg);

            state.Code = 500;

            state.Msg = msg.Message;
        }

        return state;

    }
    public StateViewModel<T> QuerySingleOrDefault<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure)
    {

        StateViewModel<T> state = new StateViewModel<T>();
        try
        {
            T value;
            using (IDbConnection db = new SqlConnection(_dbService.DBConnection()))
            {
                value = db.QuerySingleOrDefault<T>(sql + "  ", param: param, commandType: commandType, commandTimeout: commandTimeout);

            }
            if (value != null)
            {
                state.Code = 200;

                state.Msg = "Success";

                state.Data = value;
            }
            else
            {
                state.Code = 300;
                state.Msg = "No Record Found";
            }
        }
        catch (Exception msg)
        {
            //  ElmahExtensions.RaiseError(msg);

            state.Code = 500;
            state.Msg = msg.Message;
        }

        return state;

    }
    public StateViewModel<T> QuerySingle<T>(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure)
    {
        StateViewModel<T> state = new StateViewModel<T>();
        try
        {
            T value;
            using (IDbConnection db = new SqlConnection(_dbService.DBConnection()))
            {
                value = db.QuerySingle<T>(sql + "  ", param: param, commandType: commandType, commandTimeout: commandTimeout);

            }
            if (value != null)
            {
                state.Code = 200;

                state.Msg = "Success";

                state.Data = value;
            }
            else
            {
                state.Code = 300;

                state.Msg = "No Record Found";
            }
        }
        catch (Exception msg)
        {
            // ElmahExtensions.RaiseError(msg);

            state.Code = 500;

            state.Msg = msg.Message;
        }

        return state;
    }
    public StateViewModel<T> QueryFirst<T>(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure)
    {
        StateViewModel<T> state = new StateViewModel<T>();
        try
        {
            T value;
            using (IDbConnection db = new SqlConnection(_dbService.DBConnection()))
            {
                value = db.QueryFirst<T>(sql + "  ", param: param, commandType: commandType, commandTimeout: commandTimeout);

            }
            if (value != null)
            {
                state.Code = 200;

                state.Msg = "Success";

                state.Data = value;
            }
            else
            {
                state.Code = 300;

                state.Msg = "No Record Found";
            }
        }
        catch (Exception msg)
        {
            // ElmahExtensions.RaiseError(msg);

            state.Code = 500;

            state.Msg = msg.Message;
        }

        return state;
    }
    public StateViewModel<SqlMapper.GridReader> QueryMultiple(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure)
    {
        StateViewModel<SqlMapper.GridReader> state = new StateViewModel<SqlMapper.GridReader>();
        try
        {
            SqlMapper.GridReader value;
            using (IDbConnection db = new SqlConnection(_dbService.DBConnection()))
            {
                value = db.QueryMultiple(sql + "  ", param: param, commandType: commandType, commandTimeout: commandTimeout);

            }
            if (value != null)
            {
                state.Code = 200;

                state.Msg = "Success";

                state.Data = value;
            }
            else
            {
                state.Code = 300;

                state.Msg = "No Record Found";
            }
        }
        catch (Exception msg)
        {
            //  ElmahExtensions.RaiseError(msg);
            state.Code = 500;
            state.Msg = msg.Message;
        }

        return state;
    }
    public async Task<StateViewModel<IEnumerable<T>>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure)
    {
        StateViewModel<IEnumerable<T>> state = new StateViewModel<IEnumerable<T>>();
        try
        {
            IEnumerable<T> value;
            using (IDbConnection db = new SqlConnection(_dbService.DBConnection()))
            {
                value = await db.QueryAsync<T>(sql + "  ", param, commandType: commandType, commandTimeout: commandTimeout);

            }
            if (value != null)
            {
                state.Code = 200;

                state.Msg = "Success";

                state.Data = value;
            }
            else
            {
                state.Code = 300;

                state.Msg = "No Record Found";
            }
        }
        catch (Exception msg)
        {
            // ElmahExtensions.RaiseError(msg);
            state.Code = 500;
            state.Msg = msg.Message;
        }

        return state;
    }
    public async Task<StateViewModel<T>> QueryFirstOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure)
    {
        StateViewModel<T> state = new StateViewModel<T>();
        try
        {
            T value;
            using (IDbConnection db = new SqlConnection(_dbService.DBConnection()))
            {
                value = await db.QueryFirstOrDefaultAsync<T>(sql + "  ", param: param, commandType: commandType, commandTimeout: commandTimeout);

            }
            if (value != null)
            {
                state.Code = 200;

                state.Msg = "Success";

                state.Data = value;
            }
            else
            {
                state.Code = 300;

                state.Msg = "No Record Found";
            }
        }
        catch (Exception msg)
        {
            // ElmahExtensions.RaiseError(msg);
            state.Code = 500;
            state.Msg = msg.Message;
        }

        return state;
    }
    public async Task<StateViewModel<T>> QuerySingleOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null,
        CommandType? commandType = CommandType.StoredProcedure)
    {
        StateViewModel<T> state = new StateViewModel<T>();
        try
        {
            T value;
            using (IDbConnection db = new SqlConnection(_dbService.DBConnection()))
            {
                value = await db.QuerySingleOrDefaultAsync<T>(sql + "  ", param: param, commandType: commandType, commandTimeout: commandTimeout);

            }
            if (value != null)
            {
                state.Code = 200;

                state.Msg = "Success";

                state.Data = value;
            }
            else
            {
                state.Code = 300;

                state.Msg = "No Record Found";
            }
        }
        catch (Exception msg)
        {
            //  ElmahExtensions.RaiseError(msg);
            state.Code = 500;
            state.Msg = msg.Message;
        }

        return state;
    }
    public async Task<StateViewModel<T>> QuerySingleAsync<T>(Type type, string sql, object param = null, IDbTransaction transaction = null,
        int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure)
    {
        StateViewModel<T> state = new StateViewModel<T>();
        try
        {
            T value;
            using (IDbConnection db = new SqlConnection(_dbService.DBConnection()))
            {
                value = await db.QuerySingleAsync<T>(sql + "  ", param: param, commandType: commandType, commandTimeout: commandTimeout);

            }
            if (value != null)
            {
                state.Code = 200;

                state.Msg = "Success";

                state.Data = value;
            }
            else
            {
                state.Code = 300;

                state.Msg = "No Record Found";
            }
        }
        catch (Exception msg)
        {
            //  ElmahExtensions.RaiseError(msg);
            state.Code = 500;
            state.Msg = msg.Message;
        }

        return state;
    }
    public async Task<StateViewModel<T>> QueryFirstAsync<T>(Type type, string sql, object param = null, IDbTransaction transaction = null,
        int? commandTimeout = null, CommandType? commandType = CommandType.StoredProcedure)
    {
        StateViewModel<T> state = new StateViewModel<T>();
        try
        {
            T value;
            using (IDbConnection db = new SqlConnection(_dbService.DBConnection()))
            {
                value = await db.QueryFirstAsync<T>(sql + "  ", param: param, commandType: commandType, commandTimeout: commandTimeout);

            }
            if (value != null)
            {
                state.Code = 200;

                state.Msg = "Success";

                state.Data = value;
            }
            else
            {
                state.Code = 300;

                state.Msg = "No Record Found";
            }
        }
        catch (Exception msg)
        {
            // ElmahExtensions.RaiseError(msg);
            state.Code = 500;
            state.Msg = msg.Message;
        }

        return state;
    }
    public async Task<StateViewModel<SqlMapper.GridReader>> QueryMultipleAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null,
        CommandType? commandType = CommandType.StoredProcedure)
    {
        StateViewModel<SqlMapper.GridReader> state = new StateViewModel<SqlMapper.GridReader>();
        try
        {
            SqlMapper.GridReader value;
            using (IDbConnection db = new SqlConnection(_dbService.DBConnection()))
            {
                value = await db.QueryMultipleAsync(sql + "  ", param: param, commandType: commandType, commandTimeout: commandTimeout);

            }
            if (value != null)
            {
                state.Code = 200;

                state.Msg = "Success";

                state.Data = value;
            }
            else
            {
                state.Code = 300;

                state.Msg = "No Record Found";
            }
        }
        catch (Exception msg)
        {
            //  ElmahExtensions.RaiseError(msg);
            state.Code = 500;
            state.Msg = msg.Message;
        }

        return state;
    }
    public void Dispose()
    {
        _genericRepository.Dispose();
    }
}
