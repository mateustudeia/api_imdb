using Imdb.Domain.Entities;
using System.Collections.Generic;

namespace Imdb.Domain.Interfaces
{
    public interface IRepository<TEntity, TKeyType> where TEntity : BaseEntity<TKeyType>
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        IEnumerable<TEntity> Select();
        TEntity Select(int id);

    }
}
