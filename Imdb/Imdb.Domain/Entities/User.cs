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
        public bool IsDeleted { get; }

    }
}
