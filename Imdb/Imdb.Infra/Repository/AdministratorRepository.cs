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
        public readonly IRepository<Administrator> _repository;

        public AdministratorRepository(IRepository<Administrator> repository)
        {
            _repository = repository;
        }

        public void Save(Administrator obj)
        {
            if (obj.Id == 0)
                _repository.Insert(obj);
            else
                _repository.Update(obj);
        }
        
        public Administrator GetById(int id) =>
            _repository.Select(id);

    }
}
