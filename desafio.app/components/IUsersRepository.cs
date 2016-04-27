using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Linq.Expressions;
using System.Threading.Tasks;
using desafio.app.context;
using desafio.app.domain;

namespace desafio.app.repository
{
    public interface IUsersRepository : IRepository<User>
    {
        User GetByEmail(string email);
        bool VerifyUserExistsByEmail(string email);
    }
}