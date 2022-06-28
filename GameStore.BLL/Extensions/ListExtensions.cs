using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GameStore.BLL.Extensions
{
    public static class ListExtensions
    {
        public static List<T> SortByParameter<T>(this List<T> items,Expression<Func<T,object>> order,bool desc)
        {
            return !desc ? items.OrderByDescending(order.Compile()).ToList() : items.OrderBy(order.Compile()).ToList();
        }

        public static List<T> GetPage<T>(this List<T> items, int skip, int take)
        {
            return items.Skip((skip-1)*take).Take(take).ToList();
        }
    }
}
