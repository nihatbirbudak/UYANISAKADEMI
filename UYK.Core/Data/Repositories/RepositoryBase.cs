using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using UYK.Core.Entities;

namespace UYK.Core.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity<int>
    {
        private readonly DbContext context;
        public RepositoryBase(DbContext context)
        {
            this.context = context;
        }

        /// <summary> 
        ///     Add a entity in your database
        /// </summary>
        /// <param name="entity"> Entity </param>
        /// <returns></returns>
        public T Add(T entity)
        {
            return context.Set<T>().Add(entity) as T;
        }

        /// <summary>
        /// Delete a entity in your database
        /// </summary>
        /// <param name="entity"> Entity </param>
        public void Delete(T entity)
        {
            ChangeTrackerDetachedObject(entity);
            var dbSet = context.Set<T>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        /// <summary>
        /// Set the query for all function
        /// </summary>
        /// <param name="filter"> Filter param </param>
        /// <param name="include"> include param </param>
        /// <param name="orderBy"> orderBy param </param>
        /// <param name="skip"> skip param </param>
        /// <param name="take"> take param </param>
        /// <returns></returns>
        protected virtual IQueryable<T> GetQueryable(Expression<Func<T,bool>> filter = null,
                                                      Expression<Func<T,object>> include = null,
                                                      Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null,
                                                      int? skip = null , int? take = null)
        {
            IQueryable<T> query = context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (include != null)
            {
                query = query.Include(include);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            return GetQueryable(filter, null, null).SingleOrDefault();
        }

        public IQueryable<T> Get(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include.Name);
            }
            return query;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, 
                                 Expression<Func<T, object>> include = null)
        {
            return GetQueryable(filter, include, null);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, 
                                 Expression<Func<T, object>> include = null, 
                                 Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
                                 int? skip = null, int? take = null)
        {
            return GetQueryable(filter, include, orderBy, skip, take);
        }

        public IQueryable<T> GetAll()
        {
            return GetQueryable(null, null, null);
        }

        public T GetIncludes(Expression<Func<T, bool>> filter = null, 
                             params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = GetQueryable(filter, null, null);
            foreach (var include in includes)
            {
                query = query.Include(include.Name);
            }
            return query.FirstOrDefault();
        }

        public void Update(T entity)
        {
            ChangeTrackerDetachedObject(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void ChangeTrackerDetachedObject(T entity)
        {
            var local = context.Set<T>().Local.FirstOrDefault(entity => entity.Id.Equals(entity.Id));
            if(local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
        }
    }
}
