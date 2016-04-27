using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using desafio.app.model;

namespace desafio.app.service
{
    public interface IRegisterUserService
    {   
        RegisteredUserModel Register(SignUpModel model);
    }
}