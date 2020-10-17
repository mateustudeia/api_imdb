using Imdb.Domain.Entities;
using Imdb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Domain.Interfaces
{
    public interface IRepositoryAdministrator
    {
        void Save(Administrator obj);
        Administrator GetById(int id);
    }
}
