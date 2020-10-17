using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Domain.Models;
using Imdb.Service.Exceptions;
using Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var user = _repositoryUser.GetById(userModel.Id);
            if (user != null)
            {
                user = userModel.ConvertToEntity();

                _repositoryUser.Save(user);
                return user.ConvertToUser();
            }
            else if (user.IsDeleted == true)
            {
                throw new InvalidDeleteException(ServicesConstants.ERR_GENERIC_USER_DELETE);
            }

            throw new InvalidDeleteException(ServicesConstants.ERR_GENERIC_USER_NOT_FOUND);
        }
        public void SoftDelete(int id)
        {
            var user = _repositoryUser.GetById(id);
            if(user == null)
            {
                throw new InvalidDeleteException(ServicesConstants.ERR_GENERIC_USER_NOT_FOUND);
            }
            if(!user.IsDeleted)
            {
                user.DeleteUser();
                _repositoryUser.Save(user);
                return;
            }

            throw new InvalidDeleteException(ServicesConstants.ERR_GENERIC_USER_DELETE);
        }

        public IEnumerable<UserModel> RecoverAll()
        {
            var users = _repositoryUser.GetAll()
                .Where(u => !u.IsDeleted)
                .ToList();
            return users.ConvertToUsers();
        }

        public User GetById(int id) => 
            _repositoryUser.GetById(id);
    }
}
