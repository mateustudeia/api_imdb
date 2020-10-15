using Imdb.Domain.Entities;
using Imdb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Shared
{
    public static class UserMapper
    {
        public static User ConvertToEntity(this CreateUserModel userModel) =>
            new User(userModel);

        public static User ConvertToEntity(this UpdateUserModel userModel) =>
            new User(userModel);

        public static IEnumerable<UserModel> ConvertToUsers(this IList<User> users) =>
            new List<UserModel>(users.Select(s => new UserModel(s)));

        public static UserModel ConvertToUser(this User user) =>
            new UserModel(user);
            
    }
}
