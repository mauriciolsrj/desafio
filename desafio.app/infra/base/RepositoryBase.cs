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
        
        public abstract void Insert(T entity);
        public abstract void Update(T entity);

        public RepositoryBase(UsersContext context) {
            this.context = context;
        }

        public void Dispose() {
            if (context != null)
                context.Dispose();
                
            GC.SuppressFinalize(this);
        }
    }
}