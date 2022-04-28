﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        Task<TEntity> AddAsync(TEntity entityToAdd);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<List<TEntity>> GetListAsync(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<List<TEntity>> GetRangeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> UpdateAsync(TEntity entityToUpdate, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}