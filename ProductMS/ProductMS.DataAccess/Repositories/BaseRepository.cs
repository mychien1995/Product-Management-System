﻿using Microsoft.EntityFrameworkCore;
using ProductMS.DataAccess.SqlServer.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductMS.DataAccess.SqlServer.Repositories
{
    public class BaseRepository<T> : IEntityRepository<T> where T : class
    {
        public DbSet<T> Dbset;
        protected readonly ProductDbContext DbContext;

        public BaseRepository(ProductDbContext context)
        {
            DbContext = context;
            DbContext.ChangeTracker.LazyLoadingEnabled = true;
            Dbset = context.Set<T>();
        }
        public bool Delete(object id)
        {
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    var entry = DbContext.Entry(entity);
                    entry.State = EntityState.Deleted;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<T> GetAll()
        {
            return Dbset.AsQueryable().ToList();
        }

        public T GetById(object id)
        {
            return Dbset.Find(id);
        }

        public List<T> FindAll(Expression<Func<T, bool>> expression = null, Expression<Func<T, object>>[] includes = null)
        {
            var query = Dbset.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            return query.ToList();
        }

        public IQueryable<T> GetQueryable()
        {
            return Dbset.AsQueryable();
        }

        public T Insert(T t)
        {
            Dbset.Add(t);

            return t;
        }

        public T Update(T t)
        {
            var dbEntityEntry = DbContext.Entry(t);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Dbset.Attach(t);
            }

            dbEntityEntry.State = EntityState.Modified;
            return t;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return DbContext.SaveChangesAsync();
        }
    }
}
