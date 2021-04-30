using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PenaltyCalculator.Core.Entities.Abstract;
namespace PenaltyCalculator.Infrastructure.Repository.Abstract
{
    public interface IRepository<T> where T:IEntity
    {
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
        IQueryable<T> GetQueryable();
        int SaveChanges();
    }
}