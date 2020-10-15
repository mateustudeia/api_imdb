using Imdb.Domain.Interfaces;
using Imdb.Domain.Models;
using Infra.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Service
{
    public class UserService : IServiceUser
    {
        private readonly IRepositoryUser _repositoryUser;

        public UserService(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }


        public UserModel Insert(CreateUserModel userModel)
        {
            var user = userModel.ConvertToEntity();
            _repositoryUser.Save(user);
            return user.ConvertToUser();
        }
        public UserModel Update(UpdateUserModel userModel)
        {
            var user = userModel.ConvertToEntity();

            _repositoryUser.Save(user);
            return user.ConvertToUser();
        }
        public void SoftDelete(int id)
        {
            var user = _repositoryUser.GetById(id);
            user.DeleteUser();
            _repositoryUser.Save(user);
        }

        public IEnumerable<UserModel> RecoverAll()
        {
            var users = _repositoryUser.GetAll();
            return users.ConvertToUsers();
        }
    }
}
