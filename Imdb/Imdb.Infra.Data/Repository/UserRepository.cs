using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Infra.Data.Repository
{
    public class UserRepository : IRepositoryUser
    {
        private readonly IRepository<User, int> _repository;

        public UserRepository(IRepository<User, int> repository) 
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
