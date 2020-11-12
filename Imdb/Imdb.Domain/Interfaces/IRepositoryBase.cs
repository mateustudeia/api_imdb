using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        IEnumerable<TEntity> Select();
        TEntity Select(int id);

    }
}
