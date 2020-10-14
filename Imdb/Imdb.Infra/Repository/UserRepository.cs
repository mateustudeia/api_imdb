using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Infra.Repository
{
    public class UserRepository : BaseRepository<User, int>, IRepositoryUser
    {
        public UserRepository(ImdbContext imdbContext) : base(imdbContext)
        {

        }
        public void Save(User obj)
        {
            if (obj.Id == 0)
                base.Insert(obj);
            else
                base.Update(obj, _imdbContext.Entry(obj).Property(prop => prop.Password));
        }
        public void SoftDelete(User obj) => 
            base.Update(obj, _imdbContext.Entry(obj).Property(prop => prop.IsDeleted));
        public IList<User> GetAll() =>
            base.Select();

    }
}
