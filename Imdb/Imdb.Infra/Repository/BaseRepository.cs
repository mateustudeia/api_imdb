using Imdb.Domain.Entities;
using Imdb.Infra.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imdb.Infra.Repository
{
    public class BaseRepository<TEntity, TKeyType> where TEntity : BaseEntity<TKeyType>
    {
        protected readonly ImdbContext _imdbContext;

        public BaseRepository(ImdbContext imdbContext)
        {
            _imdbContext = imdbContext;
        }

        protected virtual void Insert(TEntity obj)
        {
            _imdbContext.Set<TEntity>().Add(obj);
            _imdbContext.SaveChanges();
        }
        protected virtual void Update(TEntity obj)
        {
            _imdbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _imdbContext.SaveChanges();
        }

        protected virtual IEnumerable<TEntity> Select() =>
            _imdbContext.Set<TEntity>();

        protected virtual TEntity Select(int id) =>
            _imdbContext.Set<TEntity>().Find(id);
    }
}
