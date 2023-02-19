using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Common;
using Ordering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        protected readonly AppDbContext _context;
        private DbSet<T> DbSet { get; set; }

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null!, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!, string includeString = null!, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;

            if (disableTracking) query = query.AsNoTracking();

            if(!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if(predicate != null) query = query.Where(predicate);

            if(orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null!, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!, List<Expression<Func<T, object>>> includes = null!, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;

            if (disableTracking) query = query.AsNoTracking();

            if(includes!= null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public IQueryable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            DbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            DbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
