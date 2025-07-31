using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MoGYSD.Services.Repository;
    public class ParameterEntity
    {
        public Tuple<string, object> ParameterTuple { get; set; }

    }

      public static class PredicateBuilder
    {


        public static Expression<Func<X, Y>> Compose<X, Y, Z>(this Expression<Func<Z, Y>> outer, Expression<Func<X, Z>> inner)
        {

            return Expression.Lambda<Func<X, Y>>(
                SubstExpressionVisitor.Replace(outer.Body, outer.Parameters[0], inner.Body),
                inner.Parameters[0]);
        }

        public static Expression<Func<T, bool>> Begin<T>(bool value = false)
        {
            if (value)
            {
                return parameter => true; //value cannot be used in place of true/false
            }

            return parameter => false;
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {
            // return CombineLambdas(left, right, ExpressionType.AndAlso);
            if (b == null)
            {
                return a;
            }

            ParameterExpression p = a.Parameters[0];

            SubstExpressionVisitor visitor = new SubstExpressionVisitor();
            visitor.subst[b.Parameters[0]] = p;

            Expression body = Expression.AndAlso(a.Body, visitor.Visit(b.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {
            //   return CombineLambdas(left, right, ExpressionType.OrElse);

            if (b == null)
            {
                return a;
            }

            ParameterExpression p = a.Parameters[0];

            SubstExpressionVisitor visitor = new SubstExpressionVisitor();
            visitor.subst[b.Parameters[0]] = p;

            Expression body = Expression.OrElse(a.Body, visitor.Visit(b.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }


        private static bool IsExpressionBodyConstant<T>(Expression<Func<T, bool>> left)
        {
            return left.Body.NodeType == ExpressionType.Constant;
        }



        private static Expression<Func<T, bool>> CombineLambdas<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right, ExpressionType expressionType)
        {
            //Remove expressions created with Begin<T>()
            if (IsExpressionBodyConstant(left))
            {
                return (right);
            }

            ParameterExpression p = left.Parameters[0];

            SubstExpressionVisitor visitor = new SubstExpressionVisitor();
            visitor.subst[right.Parameters[0]] = p;

            Expression body = Expression.MakeBinary(expressionType, left.Body, visitor.Visit(right.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }
        internal class SubstExpressionVisitor : ExpressionVisitor
        {
            public Dictionary<Expression, Expression> subst = new Dictionary<Expression, Expression>();
            private ParameterExpression _parameter;
            private Expression _replacement;

            public SubstExpressionVisitor()
            {

            }
            public SubstExpressionVisitor(ParameterExpression parameter, Expression replacement)
            {
                _parameter = parameter;
                _replacement = replacement;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                return subst.TryGetValue(node, out var newValue) ? newValue : node;
            }


            public static Expression Replace(Expression expression, ParameterExpression parameter, Expression replacement)
            {
                return new SubstExpressionVisitor(parameter, replacement).Visit(expression);
            }

        }
    }
    public static class DbSetExtension
    {
        public static async Task<int> ExecuteNonQueryAsync(this DatabaseFacade context, string rawSql,
            params object[] parameters)
        {
            var conn = context.GetDbConnection();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = rawSql;
                if (parameters != null)
                    foreach (var p in parameters)
                        command.Parameters.Add(p);
                await conn.OpenAsync();
                return await command.ExecuteNonQueryAsync();
            }
        }

    public static async Task<T> ExecuteScalarAsync<T>(this DatabaseFacade context, string rawSql, params object[] parameters)
        {
            var conn = context.GetDbConnection();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = rawSql;
                if (parameters != null)
                    foreach (var p in parameters)
                        command.Parameters.Add(p);


                await conn.OpenAsync();
                return (T)await command.ExecuteScalarAsync();
            }
        }

    public static async Task<List<T>> ExecuteListScalarAsync<T>(this DatabaseFacade context, string rawSql, params object[] parameters)
        {
            var conn = context.GetDbConnection();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = rawSql;
                if (parameters != null)
                    foreach (var p in parameters)
                        command.Parameters.Add(p);
                await conn.OpenAsync();
                return (List<T>)await command.ExecuteScalarAsync();
            }
        }



        public static List<T> ExecuteQuery<T>(this DbSet<T> dbSet, string query) where T : class, new()
        {
            using (var command = dbSet.GetContext().Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                dbSet.GetContext().Database.OpenConnection();


                using (var reader = command.ExecuteReader())
                {
                    var lst = new List<T>();
                    var lstColumns = new T().GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).ToList();
                    while (reader.Read())
                    {
                        var newObject = new T();
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            var name = reader.GetName(i);
                            PropertyInfo prop = lstColumns.FirstOrDefault(a => a.Name.ToLower().Equals(name.ToLower()));
                            if (prop == null)
                            {
                                continue;
                            }
                            var val = reader.IsDBNull(i) ? null : reader[i];
                            prop.SetValue(newObject, val, null);
                        }
                        lst.Add(newObject);
                    }

                    return lst;
                }
            }
        }
        public static void AddOrUpdate<T>(this DbSet<T> dbSet, T data) where T : class
        {
            var context = dbSet.GetContext();
            var ids = context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name);

            var t = typeof(T);
            List<PropertyInfo> keyFields = new List<PropertyInfo>();

            foreach (var propt in t.GetProperties())
            {
                var keyAttr = ids.Contains(propt.Name);
                if (keyAttr)
                {
                    keyFields.Add(propt);
                }
            }
            if (keyFields.Count <= 0)
            {
                throw new Exception($"{t.FullName} does not have a KeyAttribute field. Unable to exec AddOrUpdate call.");
            }
            var entities = dbSet.AsNoTracking().ToList();
            foreach (var keyField in keyFields)
            {
                var keyVal = keyField.GetValue(data);
                entities = entities.Where(p => p.GetType().GetProperty(keyField.Name).GetValue(p).Equals(keyVal)).ToList();
            }
            var dbVal = entities.FirstOrDefault();
            if (dbVal != null)
            {
                context.Entry(dbVal).CurrentValues.SetValues(data);
                // context.Entry(dbVal).State = EntityState.Modified;
                return;
            }
            dbSet.Add(data);
        }

        public static void AddOrUpdate<T>(this DbSet<T> dbSet, Expression<Func<T, object>> key, T data) where T : class
        {
            var context = dbSet.GetContext();
            var ids = context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name);
            var t = typeof(T);
            var keyObject = key.Compile()(data);
            PropertyInfo[] keyFields = keyObject.GetType().GetProperties().Select(p => t.GetProperty(p.Name)).ToArray();
            if (keyFields == null)
            {
                throw new Exception($"{t.FullName} does not have a KeyAttribute field. Unable to exec AddOrUpdate call.");
            }
            var keyVals = keyFields.Select(p => p.GetValue(data));
            var entities = dbSet.AsNoTracking().ToList();
            int i = 0;
            foreach (var keyVal in keyVals)
            {
                entities = entities.Where(p => p.GetType().GetProperty(keyFields[i].Name).GetValue(p).Equals(keyVal)).ToList();
                i++;
            }
            if (entities.Any())
            {
                var dbVal = entities.FirstOrDefault();
                var keyAttrs =
                    data.GetType().GetProperties().Where(p => ids.Contains(p.Name)).ToList();
                if (keyAttrs.Any())
                {
                    foreach (var keyAttr in keyAttrs)
                    {
                        keyAttr.SetValue(data,
                            dbVal.GetType()
                                .GetProperties()
                                .FirstOrDefault(p => p.Name == keyAttr.Name)
                                .GetValue(dbVal));
                    }
                    context.Entry(dbVal).CurrentValues.SetValues(data);
                    context.Entry(dbVal).State = EntityState.Modified;
                    return;
                }
            }
            dbSet.Add(data);
        }
    }

    //public static class MultipleResultSets
    //{
    //    public static MultipleResultSetWrapper MultipleResults(this DbContext db)
    //    {
    //        return new MultipleResultSetWrapper(db);
    //    }

    //}

    public static class DbSetTrickExtension
    {
        public static DbContext GetContext<TEntity>(this DbSet<TEntity> dbSet)
            where TEntity : class
        {
            return (DbContext)dbSet
                .GetType().GetTypeInfo()
                .GetField("_context", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(dbSet);
        }
    }


    //public class MultipleResultSetWrapper
    //    {
    //        public List<Func<IObjectContextAdapter, DbDataReader, IEnumerable>> _resultSet;

    //        public List<Func<IObjectContextAdapter, DbDataReader, IEnumerable>> _resultSets;

    //        private readonly string _storedProcedure;

    //        private readonly DbContext db;

    //        public MultipleResultSetWrapper(DbContext db)
    //        {
    //            this.db = db;
    //            _resultSets = new List<Func<IObjectContextAdapter, DbDataReader, IEnumerable>>();
    //        }

    //        //public MultipleResultSetWrapper WithProperties(List<TResult> withProperties = null)
    //        //{
    //        //    var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
    //        //    .Where(type => !String.IsNullOrEmpty(type.Namespace))
    //        //    .Where(type => type.BaseType != null && type.BaseType.IsGenericType
    //        //    && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

    //        //    foreach (var withProperty in withProperties)
    //        //    {
    //        //        this.With<withProperty>();
    //        //    }

    //        //    return this;
    //        //}
    //        public List<IEnumerable> Execute(
    //            string storedProcedure,
    //            string parameterNames = null,
    //            List<ParameterEntity> parameterValues = null,
    //            List<dynamic> withs = null)
    //        {
    //            var results = new List<IEnumerable>();

    //            using (var connection = db.Database.GetDbConnection())
    //            {
    //                connection.Open();
    //                var command = connection.CreateCommand();
    //                command.CommandText = "EXEC " + storedProcedure + "  " + parameterNames;

    //                SqlParameter[] parameters = new SqlParameter[parameterValues.Count];
    //                for (var i = 0; i <= parameterValues.Count - 1; i++)
    //                {
    //                    parameters[i] = new SqlParameter(
    //                        parameterValues[i].ParameterTuple.Item1,
    //                        parameterValues[i].ParameterTuple.Item2);
    //                }

    //                if (parameters.Any())
    //                    command.Parameters.AddRange(parameters);

    //                using (var reader = command.ExecuteReader())
    //                {
    //                    var adapter = (IObjectContextAdapter)db;
    //                    foreach (var resultSet in _resultSets)
    //                    {
    //                        results.Add(resultSet(adapter, reader));
    //                        reader.NextResult();
    //                    }
    //                }

    //                return results;
    //            }
    //        }

    //        public MultipleResultSetWrapper With<TResult>()
    //        {
    //            _resultSets.Add((adapter, reader) => adapter.ObjectContext.Translate<TResult>(reader).ToList());

    //            return this;
    //        }

    //        public MultipleResultSetWrapper WithSingle<TResult>()
    //        {
    //            _resultSets.Add((adapter, reader) => adapter.ObjectContext.Translate<TResult>(reader).ToList());

    //            return this;
    //        }
    //    }
    //}