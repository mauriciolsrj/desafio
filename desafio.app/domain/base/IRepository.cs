using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace desafio.app.domain
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll();
        void Insert(T entity);
        void Delete(int id);
        void Delete(T entity);
    }
}