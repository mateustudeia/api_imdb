using Imdb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Imdb.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public string Name { get; }
        public string Gender { get; }
        public DateTime DateOfBirth { get; }
        public string Email { get; }
        public string Role { get; private set; }
        public bool IsDeleted { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

        #region Foreign Keys
        public virtual ICollection<VoteUserMovie> VoteUserMovie { get; set; }

        #endregion

        #region Constructors
        public User(CreateUserModel user) : base(0)
        {
            Name = user.Name;
            Gender = user.Gender;
            DateOfBirth = user.DateOfBirth;
            Email = user.Email;
            Role = "user";
            IsDeleted = false;
        }

        public User(UpdateUserModel user) : base(user.Id)
        {
            Name = user.Name;
            Gender = user.Gender;
            DateOfBirth = user.DateOfBirth;
            Email = user.Email;
            IsDeleted = user.IsDeleted;
        }

        public User() { }
        #endregion

        public void DeleteUser() =>
            IsDeleted = true;

        public void AdministratorRole() =>
            Role = "administrator";

        public void EncryptPasswords(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
