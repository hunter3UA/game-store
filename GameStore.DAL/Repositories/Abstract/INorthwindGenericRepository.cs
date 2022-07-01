using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface INorthwindGenericRepository<TDocument> where TDocument : class 
    {
        Task<List<TDocument>> GetListAsync();

        Task<TDocument> GetAsync(Expression<Func<TDocument, bool>> expression);

        Task<List<TDocument>> GetRangeAsync(List<Expression<Func<TDocument, bool>>> expression);

        Task<int> GetCountAsync(List<Expression<Func<TDocument, bool>>> filters);

        Task UpdateAsync(TDocument entityToUpdate);

    }
}
