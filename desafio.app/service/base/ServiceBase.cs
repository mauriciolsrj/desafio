
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Linq.Expressions;
using System.Threading.Tasks;
using desafio.app.context;
using desafio.app.domain;
using desafio.app.repository;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace desafio.app.service
{
    public abstract class ServiceBase
    {
        protected UsersContext context;
        
        public ServiceBase() {
        }
        
        protected void Initialize(){
            context = new UsersContext();
            
            InitializeRepositories();
        }
        
        protected abstract void InitializeRepositories();
        
        protected void DisposeContext(){
            if(context!=null)
                context.Dispose();
        }
    }
}