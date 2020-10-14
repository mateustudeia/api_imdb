using Imdb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Interfaces
{
    public interface IRepositoryUser
    {
        void Save(User obj);
        void SoftDelete(User obj);
        IList<User> GetAll();
    }
}
