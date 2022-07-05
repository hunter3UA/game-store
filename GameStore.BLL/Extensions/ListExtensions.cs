using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GameStore.BLL.Extensions
{
    public static class ListExtensions
    {
        public static List<T> SortByParameter<T>(this List<T> items, Expression<Func<T, object>> order, bool asc)
        {
            
            return !asc ? items.OrderByDescending(order.Compile()).ToList() : items.OrderBy(order.Compile()).ToList();
        }

        public static List<T> GetPage<T>(this List<T> items, int page, int take)
        {
            return items.Skip((page - 1) * take).Take(take).ToList();
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
