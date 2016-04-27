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
    public class DuplicatedUserException : Exception
    {
           public DuplicatedUserException(string message) : base(message){
               
           }
    }
}