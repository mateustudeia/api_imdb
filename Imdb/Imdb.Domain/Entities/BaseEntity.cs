using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Entities
{
    public abstract class BaseEntity<TKeyType>
    {
        //protected BaseEntity(TKeyType id = default)
        //{
        //    Id = id;
        //}

        public virtual TKeyType Id { get; }
    }
}
