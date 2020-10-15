using Imdb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public string Name { get; }
        public string Gender { get; }
        public DateTime DateOfBirth { get; }
        public string Email { get; }
        public string Password { get; }
        public bool IsDeleted { get; private set; }

        public User(CreateUserModel user) : base(0)
        {
            Name = user.Name;
            Gender = user.Gender;
            DateOfBirth = user.DateOfBirth;
            Email = user.Email;
            Password = user.Password;
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

        public void DeleteUser()
        {
            IsDeleted = true;
        }
    }
}
