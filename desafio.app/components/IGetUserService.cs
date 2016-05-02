using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using desafio.app.model;

namespace desafio.app
{
    public interface IGetUserService
    {   
        RegisteredUserModel Get(string token);
        IEnumerable<RegisteredUserModel> All();
    }
}