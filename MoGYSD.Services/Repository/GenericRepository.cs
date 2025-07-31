using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MoGYSD.Services.Repository;
    public interface IGenericRepository : IDisposable
    {
        void AddRange<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class;
        void Add<TEntity>(TEntity entity)
          where TEntity : class;
        void Create<TEntity>(TEntity entity)
            where TEntity : class;

      

        void Delete<TEntity>(object id)
            where TEntity : class;

        void Delete<TEntity>(TEntity entity)
            where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        /// <summary>
        /// Sample documentation
        /// </summary>
        /// <typeparam name="TEntity"> Context class </typeparam>
        /// <param name="orderBy"> The Listed Order parameter(s)</param>
        /// <param name="includeProperties"> the include properties</param>
        /// <param name="skip"> int of what to skip </param>
        /// <param name="take"> the list to take </param>
        /// <returns>IQueryable of TEntity</returns>
        IEnumerable<TEntity> GetAll<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        /// <summary>
        ///  Get All IQueryable  Async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
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


        Task<IQueryable<TEntity>> GetSearchableQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;
        TEntity GetById<TEntity>(object id)
            where TEntity : class;

        ValueTask<TEntity> GetByIdAsync<TEntity>(object id)
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

        // TEntity Proc<TEntity>(object id) where TEntity : class;
        IEnumerable<TEntity> GetManyBySp<TEntity>(
            string procName,
            string parameterNames = null,
            List<ParameterEntity> parameterValues = null)
            where TEntity : class;

        //List<IEnumerable> GetMultipleResultSet<TResult>(
        //    string procName,
        //    string parameterNames = null,
        //    List<ParameterEntity> parameterValues = null,
        //    Func<DbDataReader, TResult> mapEntities = null)
        //    where TResult : class;

        TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
            where TEntity : class;

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

        int Save();
        DbContext GetContext();
        Task SaveAsync();

        void Update<TEntity>(TEntity entity)
            where TEntity : class;


        IQueryable<TResult> GetSet<TResult, TKey, TEntity>(
            Expression<Func<TEntity, TResult>> firstSelector,
            Expression<Func<TResult, TKey>> orderBy,
            Expression<Func<TEntity, bool>> filter = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        IQueryable<TReturn> GetGroupedSet<TResult, TKey, TGroup, TReturn, TEntity>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> firstSelector, Expression<Func<TResult, TKey>> orderSelector, Func<TResult, TGroup> groupSelector, Func<IGrouping<TGroup, TResult>, TReturn> selector, int? skip, int? take) where TEntity : class;


        IList<TReturn> GetGrouped<TResult, TKey, TGroup, TReturn, TEntity>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TResult>> firstSelector,
            Expression<Func<TResult, TKey>> orderSelector,
            Func<TResult, TGroup> groupSelector,
            Func<IGrouping<TGroup, TResult>, TReturn> selector,
            int? skip,
            int? take) where TEntity : class;




        new void Dispose();
    }

    public class GenericRepository<TContext> : IGenericRepository
      where TContext : DbContext
    {
        protected readonly TContext _context;

        public GenericRepository(TContext context)
        {
            _context = context;
            _context.Database.SetCommandTimeout(600);
        }

        public GenericRepository()
        {
        }

        public void AddRange<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class
        {
            _context.Set<TEntity>().AddRange(entities);
        }
        public virtual void Add<TEntity>(TEntity entity)
          where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
           
           
        }
        public virtual void Create<TEntity>(TEntity entity)
            where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
        }
       
        public virtual void Update<TEntity>(TEntity entity)
            where TEntity : class
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<TEntity>().Update(entity);
        }


        public virtual void Delete<TEntity>(object id)
            where TEntity : class
        {
            var entity = _context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity)
            where TEntity : class
        {
            var dbSet = _context.Set<TEntity>();
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        public virtual IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            return await GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            return await GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToListAsync();
        }


        public virtual async Task<IQueryable<TEntity>> GetSearchableQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {

            //make it awaitable
            await Task.FromResult(0);
            return GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take);
        }

        public virtual TEntity GetById<TEntity>(object id)
            where TEntity : class
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual ValueTask<TEntity> GetByIdAsync<TEntity>(object id)
            where TEntity : class
        {
            return _context.Set<TEntity>().FindAsync(id);
        }

        public virtual int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter).Count();
        }

        public virtual Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter).CountAsync();
        }

        public virtual bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter).Any();
        }

        public virtual Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter).AnyAsync();
        }

        public virtual TEntity GetFirst<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefault();
        }

        public virtual async Task<TEntity> GetFirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
            where TEntity : class
        {
            return await GetQueryable(filter, orderBy, includeProperties).FirstOrDefaultAsync().ConfigureAwait(true);
        }



        public IEnumerable<TEntity> GetManyBySp<TEntity>(
            string procName,
            string parameterNames = null,
            List<ParameterEntity> parameterValues = null)
            where TEntity : class
        {
            if (parameterValues == null)
            {
                return _context.Database.ExecuteListScalarAsync<TEntity>(procName).Result;
            }

            var storedprocParams = new object[parameterValues.Count];
            for (var i = 0; i <= parameterValues.Count - 1; i++)
            {
                storedprocParams[i] = new SqlParameter(parameterValues[i].ParameterTuple.Item1, parameterValues[i].ParameterTuple.Item2);
            }

            return _context.Database.ExecuteListScalarAsync<TEntity>(procName + ' ' + parameterNames, storedprocParams).Result;


        }

        //public List<IEnumerable> GetMultipleResultSet<TResult>(
        //    string procName,
        //    string parameterNames = null,
        //    List<ParameterEntity> parameterValues = null,
        //    Func<DbDataReader, TResult> mapEntities = null)
        //    where TResult : class
        //{
        //    return _context.MultipleResults().Execute(procName, parameterNames, parameterValues);
        //}

        public virtual TEntity GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter, null, includeProperties).SingleOrDefault();
        }

        public virtual Task<TEntity> GetOneAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null)
            where TEntity : class
        {
            return GetQueryable(filter, null, includeProperties).SingleOrDefaultAsync();
        }

        public TEntity GetOneBySp<TEntity>(
            string procName,
            string parameterNames = null,
            List<ParameterEntity> parameterValues = null)
            where TEntity : class
        {
            if (parameterValues == null)
            {
                return _context.Database.ExecuteScalarAsync<TEntity>(procName).Result;
            }

            var storedprocParams = new object[parameterValues.Count];
            for (var i = 0; i <= parameterValues.Count - 1; i++)
            {
                storedprocParams[i] = new SqlParameter(
                    parameterValues[i].ParameterTuple.Item1,
                    parameterValues[i].ParameterTuple.Item2);
            }

            TEntity tEntity = null;
            try
            {

                // log the Sp called
                tEntity = _context.Database.ExecuteScalarAsync<TEntity>(procName + ' ' + parameterNames,
                    storedprocParams).Result;

            }
            catch (SqlException e)
            {
                var errorMessages = e.Message;
                throw new Exception(e.Message);
            }

            return tEntity;
        }

        public virtual IEnumerable<TEntity> GetWithRawSql<TEntity>(string query, params object[] parameters)
            where TEntity : class
        {
            var tEntity = _context.Database.ExecuteListScalarAsync<TEntity>(query, parameters).Result;

            return tEntity;
        }
        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }


        public virtual int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                //throw (e);
                return 0;
            }
        }

        public virtual Task SaveAsync()
        {
            try
            {
                return _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                //throw (e);
            }
            return Task.FromResult(0);
        }

        

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,

            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }


        public virtual IQueryable<TResult> GetSet<TResult, TKey, TEntity>(
            Expression<Func<TEntity, TResult>> firstSelector,
            Expression<Func<TResult, TKey>> orderBy,
            Expression<Func<TEntity, bool>> filter = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            var predicates = new List<Expression<Func<TEntity, bool>>> { filter };
            var entities = GetQueryable(filter);
            if (skip != null && take != null)
            {
                return predicates
                    .Aggregate(entities, (current, predicate) => current.Where(predicate))
                    .Select(firstSelector)
                    .OrderBy(orderBy)
                    .Skip(skip.Value)
                    .Take(take.Value);

            }
            else
            {
                return predicates
                    .Aggregate(entities, (current, predicate) => current.Where(predicate))
                    .Select(firstSelector)
                    .OrderBy(orderBy);

            }
        }

        public virtual IQueryable<TReturn> GetGroupedSet<TResult, TKey, TGroup, TReturn, TEntity>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> firstSelector, Expression<Func<TResult, TKey>> orderSelector, Func<TResult, TGroup> groupSelector, Func<IGrouping<TGroup, TResult>, TReturn> selector, int? skip, int? take) where TEntity : class
        {
            var predicates = new List<Expression<Func<TEntity, bool>>> { filter };
            var entities = GetQueryable(filter);

            if (skip != null && take != null)
            {
                return predicates
                    .Aggregate(entities, (current, predicate) => current.Where(predicate))
                    .Select(firstSelector)
                    .OrderBy(orderSelector)
                    .GroupBy(groupSelector)
                    .Skip(skip.Value)
                    .Take(take.Value)
                    .Select(selector).AsQueryable();
            }
            else
            {
                return predicates
                    .Aggregate(entities, (current, predicate) => current.Where(predicate))
                    .Select(firstSelector)
                    .OrderBy(orderSelector)
                    .GroupBy(groupSelector)?
                    .Select(selector)?.AsQueryable();
            }
        }


        public virtual IList<TReturn> GetGrouped<TResult, TKey, TGroup, TReturn, TEntity>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> firstSelector, Expression<Func<TResult, TKey>> orderSelector, Func<TResult, TGroup> groupSelector, Func<IGrouping<TGroup, TResult>, TReturn> selector, int? skip, int? take) where TEntity : class
        {
            var predicates = new List<Expression<Func<TEntity, bool>>> { filter };
            var entities = GetQueryable(filter);

            if (skip != null && take != null)
            {
                return predicates
                    .Aggregate(entities, (current, predicate) => current.Where(predicate))
                    .Select(firstSelector)
                    .OrderBy(orderSelector)
                    .GroupBy(groupSelector)
                    .Skip(skip.Value)
                    .Take(take.Value)
                    .Select(selector)
                    .ToList();
            }
            else
            {
                return predicates
                    .Aggregate(entities, (current, predicate) => current.Where(predicate))
                    .Select(firstSelector)
                    .OrderBy(orderSelector)
                    .GroupBy(groupSelector)
                    .Select(selector)
                    .ToList();
            }
        }






        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }


        public static IQueryable<EntityWithCount<TEntity>> GetWithTotal<TEntity>(IQueryable<TEntity> entities, int page, int pageSize) where TEntity : class
        {
            return entities
                .Select(e => new EntityWithCount<TEntity> { Entity = e, Count = entities.Count() })
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

    public DbContext GetContext()
    {
            return _context;
        }
    }
    public class EntityWithCount<T> where T : class
    {
        public T Entity { get; set; }
        public int Count { get; set; }
    }
