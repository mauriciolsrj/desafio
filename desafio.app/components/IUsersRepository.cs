using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Linq.Expressions;
using System.Threading.Tasks;
using desafio.app.context;
using desafio.app.domain;

namespace desafio.app
{
    public interface IUsersRepository : IRepository<User>
    {
        User GetByEmail(string email);
        User GetByToken(string token);
        User GetById(Guid id);
        IEnumerable<User> GetAll();
    }
}