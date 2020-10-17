using Imdb.Domain.Entities;
using Imdb.Domain.Models;
using System.Collections.Generic;

namespace Imdb.Domain.Interfaces
{
    public interface IServiceAdministrator
    {
        AdministratorModel Insert(AdministratorModel administratorModel);
        AdministratorModel Update(AdministratorModel administratorModel);
        void SoftDelete(int id);
    }
}
