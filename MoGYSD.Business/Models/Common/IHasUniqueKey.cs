using System.Linq.Expressions;

namespace MoGYSD.Business.Models.Common;

public interface IHasUniqueKey<TEntity>
{
    Expression<Func<TEntity, bool>> GetUniquePredicate();
}