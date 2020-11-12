using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Infra.Repository
{
    public class AdministratorRepository : IRepositoryAdministrator
    {
        public readonly IRepositoryBase<Administrator> _repositoryBase;

        public AdministratorRepository(IRepositoryBase<Administrator> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Save(Administrator obj)
        {
            if (obj.Id == 0)
                _repositoryBase.Insert(obj);
            else
                _repositoryBase.Update(obj);
        }
        
        public Administrator GetById(int id) =>
            _repositoryBase.Select(id);

    }
}
