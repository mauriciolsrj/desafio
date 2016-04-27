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
    public class InvalidUserException : Exception
    {
           public InvalidUserException(string message) : base(message){
               
           }
    }
}