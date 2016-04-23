using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.app.domain
{
    public class EntityBase<T>
    {
        public EntityBase()
        {
        }
        
        public virtual T Id { get; protected set; }
    }
}
