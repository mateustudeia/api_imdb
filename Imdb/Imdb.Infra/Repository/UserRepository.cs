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
        public readonly IRepository<User> _repository;

        public UserRepository(IRepository<User> repository) 
        {
            _repository = repository;
        }
        public void Save(User obj)
        {
            if (obj.Id == 0)
                _repository.Insert(obj);
            else
                _repository.Update(obj);
        }
        public User GetById(int id) =>
            _repository.Select(id);
        public IEnumerable<User> GetAll() =>
            _repository.Select();


    }
}
