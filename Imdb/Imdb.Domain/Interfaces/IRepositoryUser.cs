using Imdb.Domain.Entities;
using System.Collections.Generic;

namespace Imdb.Domain.Interfaces
{
    public interface IRepositoryUser
    {
        void Save(User obj);
        User GetById(int id);
        IEnumerable<User> GetAll();
    }
}
