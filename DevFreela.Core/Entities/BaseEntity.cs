using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {

        }

        protected BaseEntity(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
