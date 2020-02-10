using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Events
{
    public class EntityUpdateEventArgs
    {
        public IEntity EntityObject;
        public readonly IEntity NewEntityObject;

        public EntityUpdateEventArgs(IEntity entityObject, IEntity newEntityObject)
        {
            EntityObject = entityObject;
            NewEntityObject = newEntityObject;
        }
    }
}
