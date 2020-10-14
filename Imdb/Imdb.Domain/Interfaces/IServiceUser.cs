using Imdb.Domain.Entities;
using Imdb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Interfaces
{
    public interface IServiceUser
    {
        UserModel Insert(CreateUserModel userModel);
        UserModel Update(int id, UpdateUserModel userModel);
        void SoftDelete(int id);
        IEnumerable<UserModel> GetAll();
    }
}
