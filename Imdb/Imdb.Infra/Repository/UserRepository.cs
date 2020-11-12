using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Infra.Repository
{
    public class UserRepository : IRepositoryUser
    {
        public readonly IRepositoryBase<User> _repositoryBase;

        public UserRepository(IRepositoryBase<User> repositoryBase) 
        {
            _repositoryBase = repositoryBase;
        }
        public void Save(User obj)
        {
            if (obj.Id == 0)
                _repositoryBase.Insert(obj);
            else
                _repositoryBase.Update(obj);
        }
        public User GetById(int id) =>
            _repositoryBase.Select(id);
        public IEnumerable<User> GetAll() =>
            _repositoryBase.Select();


    }
}
