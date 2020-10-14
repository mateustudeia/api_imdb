using Imdb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Interfaces
{
    public interface IRepositoryUser
    {
        void Save(User obj);
        User GetById(int id);
        IList<User> GetAll();
    }
}
