using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PenaltyCalculator.Core.Entities.Abstract;
namespace PenaltyCalculator.Infrastructure.Repository.Abstract
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext DbContext;
        public BaseRepository(DbContext dbContext)
        {
            DbContext=dbContext;
        }
        public T Add(T entity)
        {
            var set = DbContext.Set<T>();
            var entityEntry = set.Add(entity);
            return entityEntry.Entity;
        }

        public void Delete(int id)
        {
            var set = DbContext.Set<T>();
            var found=GetById(id);
            set.Remove(found);
        }

        public T GetById(int id)
        {
            var set = DbContext.Set<T>();
            var entity=set.Find(id);
            return entity;
        }

        public IQueryable<T> GetQueryable()
        {
            var set = DbContext.Set<T>();
            return set;
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public T Update(T entity)
        {
            var entityEntry=DbContext.Entry(entity);
            entityEntry.State=EntityState.Modified;
            return entityEntry.Entity;
        }
    }
}