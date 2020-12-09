using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Infra.Data.Context;
using System.Collections.Generic;

namespace Imdb.Infra.Data.Repository
{
    public class Repository<TEntity, TKeyType> : IRepository<TEntity, TKeyType> where TEntity : BaseEntity<TKeyType>
    {
        protected readonly ImdbContext _imdbContext;

        public Repository(ImdbContext imdbContext)
        {
            _imdbContext = imdbContext;
        }

        public virtual void Insert(TEntity obj)
        {
            _imdbContext.Set<TEntity>().Add(obj);
            _imdbContext.SaveChanges();
        }
        public virtual void Update(TEntity obj)
        {
            _imdbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _imdbContext.SaveChanges();
        }

        public virtual IEnumerable<TEntity> Select() =>
            _imdbContext.Set<TEntity>();

        public virtual TEntity Select(int id) =>
            _imdbContext.Set<TEntity>().Find(id);
    }
}
