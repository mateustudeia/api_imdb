using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Models
{
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
