using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Infra.Repository
{
    public class AdministratorRepository : BaseRepository<Administrator, int>, IRepositoryAdministrator
    {
        public AdministratorRepository(ImdbContext imdbContext) : base(imdbContext) { }

        public void Save(Administrator obj)
        {
            if (obj.Id == 0)
                base.Insert(obj);
            else
                base.Update(obj);
        }
        
        public Administrator GetById(int id) =>
            base.Select(id);

    }
}
