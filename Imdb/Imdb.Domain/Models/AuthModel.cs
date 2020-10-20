using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Models
{
    public class AuthModel
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
