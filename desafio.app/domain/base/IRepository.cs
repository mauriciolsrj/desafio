using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace desafio.app.domain
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
    }
}