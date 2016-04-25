using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using desafio.app.context;
using desafio.app.domain;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace desafio.app.repository
{
    public abstract class RepositoryBase<T>: IRepository<T>, IDisposable where T : class
    {
        protected UsersContext context;

        public RepositoryBase(UsersContext context) {
            this.context = context;
        }

        public abstract T GetById(int id);
        public abstract IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        public abstract IQueryable<T> GetAll();
        public abstract void Insert(T entity);
        public abstract void Delete(int id);
        public abstract void Delete(T entity);

        public void Dispose() {
            if (context != null)
                context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}