using Imdb.Domain.Entities;
using Imdb.Domain.Models;
using System.Collections.Generic;

namespace Imdb.Domain.Interfaces
{
    public interface IServiceUser
    {
        UserModel Register(CreateUserModel userModel);
        UserModel Update(UpdateUserModel userModel);
        void SoftDelete(int id);
        IEnumerable<UserModel> RecoverAll();
        IEnumerable<User> GetAll();
        User GetById(int id);
        void ElectAdministrator(int id);
        User Login(string email, string password);
    }
}
