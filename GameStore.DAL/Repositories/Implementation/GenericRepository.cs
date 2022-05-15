using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStore.DAL.Entities;
using GameStore.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using GameStore.DAL.Context;

namespace GameStore.DAL.Repositories.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly StoreDbContext _dbContext;

        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entityToAdd)
        {
            var addedEntity = await _dbSet.AddAsync(entityToAdd);

            return addedEntity.Entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            var searchedEntity = await query.FirstOrDefaultAsync(predicate);

            return searchedEntity;
        }

        public async Task<List<TEntity>> GetListAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            var listOfEntities = await query.ToListAsync();

            return listOfEntities;
        }

        public async Task<List<TEntity>> GetRangeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            var rangeOfEntities = await query.Where(predicate).ToListAsync();

            return rangeOfEntities;
        }

        public async Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entityToRemove = await _dbSet.FirstOrDefaultAsync(predicate);

            if (entityToRemove != null)
            {
                entityToRemove.IsDeleted = true;
                _dbContext.Entry(entityToRemove).State = EntityState.Modified;

                return true;
            }

            return false;
        }

        public async Task<TEntity> UpdateAsync(TEntity entityToUpdate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == entityToUpdate.Id);

            if (entity != null)
            {
                foreach (var navEntity in _dbContext.Entry(entityToUpdate).Navigations)
                {
                    if (navEntity.CurrentValue != null)
                    {
                        var navEntityName = navEntity.Metadata.Name;
                        var navExist = _dbContext.Entry(entity).Navigation(navEntityName);
                        await navExist.LoadAsync();
                        if (navEntity.CurrentValue != null || navExist.CurrentValue != null)
                        {
                            navExist.CurrentValue = navEntity.CurrentValue;
                        }
                    }
                }

                _dbContext.Entry(entity).CurrentValues.SetValues(entityToUpdate);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            return entity;
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
