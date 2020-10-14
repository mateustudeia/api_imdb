using Imdb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Models
{
    public class UpdateUserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        public UpdateUserModel(User user, bool isDeleted)
        {
            Id = user.Id;
            Name = user.Name;
            Gender = user.Gender;
            DateOfBirth = user.DateOfBirth;
            Email = user.Email;
            IsDeleted = isDeleted;
        }
        public UpdateUserModel() { }
    }
}
