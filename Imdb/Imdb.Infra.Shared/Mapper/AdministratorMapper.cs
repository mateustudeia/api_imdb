using Imdb.Domain.Entities;
using Imdb.Domain.Models;

namespace Imdb.Infra.Shared.Mapper
{
    public static class AdministratorMapper
    {
        public static Administrator ConvertToAdministratorEntity(this AdministratorModel administratorModel) =>
            new Administrator(administratorModel);

        public static AdministratorModel ConvertToAdministrator(this Administrator admin) =>
            new AdministratorModel(admin);
    }
}
