
using System;
using System.Linq.Expressions;

namespace GameStore.BLL.Extensions
{
    public static class ExpressionExtension
    {
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left,Expression<Func<T, bool>> right)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.AndAlso(
                    Expression.Invoke(left, param),
                    Expression.Invoke(right, param)
                );
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);

            return lambda;
        }
    }
}
