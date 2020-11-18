using Imdb.Domain.Entities;
using Imdb.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Imdb.Infra.Shared.Mapper
{
    public static class UserMapper
    {
        // Extensions Methods
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
