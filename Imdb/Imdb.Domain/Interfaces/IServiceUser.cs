using Imdb.Domain.Models;
using System.Collections.Generic;

namespace Imdb.Domain.Interfaces
{
    public interface IServiceUser
    {
        UserModel Insert(CreateUserModel userModel);
        UserModel Update(UpdateUserModel userModel);
        void SoftDelete(int id);
        IEnumerable<UserModel> RecoverAll();
    }
}
