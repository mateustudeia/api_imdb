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

        public UserModel Register(CreateUserModel createUserModel)
        {
            var createUser = createUserModel.ConvertToEntity();

            CreatePasswordHash(createUserModel.Password, out var passwordHash, out var passwordSalt);

            createUser.EncryptPasswords(passwordHash, passwordSalt);

            _repositoryUser.Save(createUser);
            return createUser.ConvertToUser();
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
                .Where(u => u.Role == "User")
                .ToList();
            return users.ConvertToUsers();
        }

        public User GetById(int id) => 
            _repositoryUser.GetById(id);

        public IEnumerable<User> GetAll() =>
            _repositoryUser.GetAll();

        public void ElectAdministrator(int id)
        {
            var user = _repositoryUser.GetById(id);
            user.AdministratorRole();
            _repositoryUser.Save(user);
        }

        public User Login(string email, string password)
        {
            var user = _repositoryUser.GetAll().Where(u => u.IsDeleted != true).FirstOrDefault(u => u.Email == u.Email);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
