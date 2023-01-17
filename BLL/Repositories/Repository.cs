﻿

using CORE.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BLL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity 
    {
        private DbContext _context;
        private DbSet<TEntity> dbSet;

        public Repository(DbContext context)
        {
            this._context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetForTest()
        {
            return dbSet;
        }


        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.AsNoTracking();
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public virtual IEnumerable<TEntity> ExecStoreProcedure(string sql, params object[] parameters)
        {
            var result = _context.Set<TEntity>().FromSqlRaw(sql, parameters);
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return result;
        }
        public virtual IEnumerable<TEntity> ExecQuery(string query)
        {
            var result = _context.Set<TEntity>().FromSqlRaw(query);
            return result;
        }

        public virtual TEntity GetById(object id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            return query.AsNoTracking().FirstOrDefault(filter);
        }

        public virtual TEntity GetLastOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if(filter == null) 
            {
                return query.AsNoTracking().LastOrDefault();
            }
            return query.AsNoTracking().LastOrDefault(filter);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Insert(ICollection<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
            //_context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Update(ICollection<TEntity> entities)
        {
            dbSet.UpdateRange(entities);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Delete(string code)
        {
            TEntity entityToDelete = dbSet.Find(code);
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public virtual void DeleteRange(List<TEntity> entity)
        {
            //_context.RemoveRange(entity);
            dbSet.RemoveRange(entity);
        }
        //Specification_1
        public async Task<IReadOnlyList<TEntity>> GetAllAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        //Specification_2
        public async Task<TEntity> GetByIdAsync(int id, ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync(e => e.Id == id);
        }
        //Specification_3
        public async Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();

        }
        //Helper Method
        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator<TEntity>.GetQuery(_context.Set<TEntity>().AsQueryable(), spec);

        }
    }
}
